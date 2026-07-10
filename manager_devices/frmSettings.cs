using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
        }

        private void btnConnectCOM_Click(object sender, EventArgs e)
        {
            try
            {
                frmMain.serialPort1.PortName = cbComPort.SelectedItem.ToString();
                frmMain.serialPort1.Open();
                frmMain.bComPortConnect = true;
            }
            catch
            {
                frmMain.bComPortConnect = false;

            }
        }
    }
}
