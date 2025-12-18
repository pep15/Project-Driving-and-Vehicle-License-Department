using DVLD.Persons_Form;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DVLD_BusineesLayer;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using System.Security.Policy;
using System.Xml.Linq;
  


namespace DVLD.ControlerPerson
{
    public partial class ctrlPeople : UserControl
    {
        static public DataTable dtPeople;
        public ctrlPeople()
        {
            InitializeComponent();
            dtPeople = clsPerson.GetAllPersons();
        }
         private void _RefrechContactList(bool RefreshDataFroomDB = false)
         {
            if(RefreshDataFroomDB)
            {
                dtPeople = clsPerson.GetAllPersons();
                
                dgvListPeople.DataSource = dtPeople;
                lbRecord.Text = dgvListPeople.Rows.Count.ToString();
            }

        }
        static public bool IsPersonIdExisting(int PersonID)
        {
           return (clsPerson.FindByID(PersonID) != null);
        }
        static public bool isNationalityexisting(string Nationality)
        {
            return (clsPerson.FindByNationalID(Nationality) != null);
        }
        private void btnAddPepole_Click(object sender, EventArgs e)
        {
            Form frmAddNewPepole = new  frmAdd_EditPepole();
            frmAddNewPepole.ShowDialog();
            _RefrechContactList(true);
            //lbRecord_Click(sender, e);
        }
        public void ctrlPeople_Load(object sender, EventArgs e)
        {
            _RefrechContactList(true);
           // lbRecord_Click(sender, e);
            txFilter.Visible = false;
            cbFilter.SelectedIndex = 0;
            dgvListPeople.Columns["CountryName"].HeaderCell.Value = "Nationality";
            
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void txFilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txFilter.Text))
            {
                //txFilter.Text = string.Empty;
                dtPeople.DefaultView.RowFilter = "";
            }
            else
            {
                switch (cbFilter.Text.ToString())
                {
                    case "Person ID":
                        int Value;
                        if (int.TryParse(txFilter.Text, out Value))
                        {
                            dtPeople.DefaultView.RowFilter = "PersonID = " + Value;
                        }
                        break;
                    case "National No":
                        dtPeople.DefaultView.RowFilter = "NationalNo Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "First Name":
                        dtPeople.DefaultView.RowFilter = "FirstName Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Second Name":
                        dtPeople.DefaultView.RowFilter = "SecondName Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Third Name":
                        dtPeople.DefaultView.RowFilter = "ThirdName Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Last Name":
                        dtPeople.DefaultView.RowFilter = "LastName Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Nationality":
                        dtPeople.DefaultView.RowFilter = "Nationality Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;

                    case "Phone":
                        int Phone;
                        if (int.TryParse(txFilter.Text.Trim(), out Phone))
                        {
                            dtPeople.DefaultView.RowFilter = "Phone Like '%" + Phone + "%'";
                        }
                        break;

                    case "Email":
                        dtPeople.DefaultView.RowFilter = "Email Like '%" + txFilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;
                }
            }
            
        }  
        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            txFilter.Visible = (cbFilter.Text != "None");
        }
        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells["PersonID"].Value;
            Form frmDetails = new FrmPersonDetails(PersonID);
            frmDetails.ShowDialog();
            
        }
        public void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells["PersonID"].Value;
            Form frmUpdate = new FrmUpdateUser(PersonID);
            frmUpdate.ShowDialog();
            _RefrechContactList(true);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListPeople.CurrentRow.Cells["PersonID"].Value;
            if(MessageBox.Show("Are you sure you want to delete Person [" + PersonID + "]?", "Confirmation", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                if(clsPerson.DeletePerson(PersonID))
                {
                    MessageBox.Show("Person Delete Successfully" , "Success" , MessageBoxButtons.OK , MessageBoxIcon.Information );

                    _RefrechContactList(true);
                }
                
            }
            else
            {
                MessageBox.Show("Could not delete person.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            

            
        }
        private void txFilter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(cbFilter.Text ==  "Person ID")
            {
                if(!char.IsDigit(e.KeyChar) && ! char.IsControl(e.KeyChar))
                {
                    e.Handled = true;   
                }
                else
                {
                    e.Handled= false;
                }
            }
        }
    }
}
