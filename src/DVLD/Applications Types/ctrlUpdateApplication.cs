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

namespace DVLD.Applications_Types
{
    public partial class ctrlUpdateApplication : UserControl
    {
         private clsApplicationTypes _ApplicationsTypes;
        private int _ApplicationID;
        public ctrlUpdateApplication()
        {
            InitializeComponent();
            
        }
      
        private void _FullControlData(clsApplicationTypes ApplicationsID)
        {
            lbID.Text = ApplicationsID.ID.ToString();
            txTitle.Text = ApplicationsID.Title;
            txFees.Text = ApplicationsID.Fees.ToString("0");
        }
         public void FindApplicationID(int AppID)
         {
            _ApplicationsTypes = clsApplicationTypes.FindID(AppID);
            _FullControlData(_ApplicationsTypes);
         }
       

        private void btnSave_Click(object sender, EventArgs e)
        {
            _ApplicationsTypes.Title = txTitle.Text;
            _ApplicationsTypes.Fees = Decimal.Parse( txFees.Text );

            if(_ApplicationsTypes.UpdateTitleAndfeesOfApplications(_ApplicationID , _ApplicationsTypes.Title , _ApplicationsTypes.Fees))
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
