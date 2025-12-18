using DVLD.User_Form;
using DVLD_BusineesLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.Control_Users
{
    public partial class ctrlUsers : UserControl
    {
        static public DataTable dtUsers;
        public ctrlUsers()
        {
            InitializeComponent();
            dtUsers = clsUser.GetAllUsers();
        }
        private void _RefrechContactList(bool RefreshDataFroomDB = false)
        {
            if (RefreshDataFroomDB)
            {
                dtUsers = clsUser.GetAllUsers();

                dgvListUsers.DataSource = dtUsers;
                lbRecord.Text = dgvListUsers.RowCount.ToString();
            }
        }
        static public bool IsUsersExisting(int UsersID)
        {
            return (clsUser.FindByUserID(UsersID) != null);
        }
        static public bool IsUserNameExisiting(string  UserName)
        {
            return (clsUser.FindByUserName(UserName) != null);
        }
        static public bool IsPersonIDExisiting(int PersonID)
        {
            return (clsUser.FindByPersonID(PersonID) != null);
        }
        private void ctrlUsers_Load(object sender, EventArgs e)
        {
            _RefrechContactList(true);
           
           cbisActive.Visible = false;
           txfilter.Visible = false;
           cbFilterUsers.SelectedIndex = 0;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form frmAdduser = new frmAddNewUserUpdate();
            frmAdduser.ShowDialog();
            _RefrechContactList(true);
        }
        private void txfilter_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txfilter.Text))
            {
                dtUsers.DefaultView.RowFilter = null;
            }
            else
            {
                switch (cbFilterUsers.Text.ToString())
                {
                    case "User ID":
                        int ValueUser;
                        if (int.TryParse(txfilter.Text, out ValueUser))
                        {
                            dtUsers.DefaultView.RowFilter = "UserID = " + ValueUser;
                        }
                        break;
                    case "Person ID":
                        int ValuePerson;
                        if (int.TryParse(txfilter.Text, out ValuePerson))
                        {
                            dtUsers.DefaultView.RowFilter = "PersonID = " + ValuePerson;
                        }
                        break;
                    case "Full Name":
                        dtUsers.DefaultView.RowFilter = "FullName like '%" + txfilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;
                    case "UserName":
                        dtUsers.DefaultView.RowFilter = "UserName like '%" + txfilter.Text.Trim().Replace("'", string.Empty) + "%'";
                        break;
                    
                }
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
        private void cbFilterUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            txfilter.Visible= (cbFilterUsers.Text != "None");

           cbisActive.Visible = (cbFilterUsers.Text == "Is Active");
            cbisActive.SelectedIndex = 0;
        }
        private void txfilter_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (cbFilterUsers.Text == "User ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }
            }
            else if (cbFilterUsers.Text == "Person ID")
            {
                if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                {
                    e.Handled = true;
                }
                else
                {
                    e.Handled = false;
                }

            }
        }
        private void cbisActive_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbFilterUsers.Text == "Is Active")
            {
                switch (cbisActive.Text.ToString())
                {
                    case "All":
                            dtUsers.DefaultView.RowFilter = null;
                     break;

                    case "Yes":
                        dtUsers.DefaultView.RowFilter = "IsActive = " + true;
                    break;
                    case "No":
                        dtUsers.DefaultView.RowFilter = "IsActive = " + false;
                     break;
                }
            }
        }
        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int Person = (int)dgvListUsers.CurrentRow.Cells["PersonID"].Value;
            Form frmAdduser = new frmAddNewUserUpdate(Person);
            frmAdduser.ShowDialog();
            _RefrechContactList(true);
        }
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int UserID = (int)dgvListUsers.CurrentRow.Cells["UserID"].Value;
            bool IsActive = (bool)dgvListUsers.CurrentRow.Cells["IsActive"].Value;
            if(clsUser.IsUserExsist(UserID) )
            {
                if (IsActive == true)
                {
                    MessageBox.Show("An active user cannot be deleted. You must deactivate their account first [" + UserID + "]?", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (IsActive == false)
                {
                   
                        if(clsUser.DeleteUsers(UserID))
                        {
                            MessageBox.Show("Person Delete Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            _RefrechContactList(true);
                        }
                        else
                        {
                             MessageBox.Show("Failed to delete the user.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                }
            }
        }
        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListUsers.CurrentRow.Cells["PersonID"].Value;
            int UserID = (int)dgvListUsers.CurrentRow.Cells["UserID"].Value;
            Form frmChangePass = new frmChangePassword(PersonID , UserID);
           frmChangePass.ShowDialog();
        }

        private void showToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int PersonID = (int)dgvListUsers.CurrentRow.Cells["PersonID"].Value;
            int UserID = (int)dgvListUsers.CurrentRow.Cells["UserID"].Value;

            Form frmShowDetails = new FrmShowDetails(PersonID , UserID);
            frmShowDetails.ShowDialog();
        }
    }
}
