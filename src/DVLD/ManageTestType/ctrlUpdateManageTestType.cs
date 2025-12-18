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

namespace DVLD.ManageTestType
{
    public partial class ctrlUpdateManageTestType : UserControl
    {
        private clsManageTestType _ApplicationsTypesContect;
        private int _TypesID;
        public ctrlUpdateManageTestType()
        {
            InitializeComponent();
        }

        private void _FullControlData(clsManageTestType ApplicationsTypesContect)
        {
            lbID.Text = ApplicationsTypesContect.ID.ToString();
            txTitle.Text = ApplicationsTypesContect.Titile;
            txDescription.Text = ApplicationsTypesContect.Description;
            txFees.Text = ApplicationsTypesContect.Fees.ToString("0");
        }
        public void FindTypesID(int TypesID)
        {
            _ApplicationsTypesContect = clsManageTestType.GetInfoID(TypesID);
            _FullControlData(_ApplicationsTypesContect);
        }
        private void ctrlUpdateManageTestType_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationsTypesContect.Titile = txTitle.Text;
            _ApplicationsTypesContect.Description = txDescription.Text;
            _ApplicationsTypesContect.Fees = Decimal.Parse(txFees.Text);

            if (_ApplicationsTypesContect.updateTestType(_TypesID , _ApplicationsTypesContect.Titile , _ApplicationsTypesContect.Description , _ApplicationsTypesContect.Fees))
            {
                MessageBox.Show("Data update Successfully.");
            }
            else
                MessageBox.Show("Error: Data Is not update Successfully.");


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }
    }
}
