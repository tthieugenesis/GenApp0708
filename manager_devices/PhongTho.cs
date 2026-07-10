using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
    public static class PhongTho_Class
    {
        public static void GetFrame(string message)
        {
            try
            {
                //string data = message.Split('-')[1];
                if (message.Contains("ON_NHANG_TRAI"))
                {
                    //bat tat den lap lop
                    frmMain.button53.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_NHANG_TRAI"))
                {
                    frmMain.button53.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("ON_NHANG_GIUA"))
                {
                    frmMain.button56.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_NHANG_GIUA"))
                {
                    frmMain.button56.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("ON_NHANG_PHAI"))
                {
                    frmMain.button57.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_NHANG_PHAI"))
                {
                    frmMain.button57.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("ON_CUA_TU_TRAI"))
                {
                    frmMain.button170.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_CUA_TU_TRAI"))
                {
                    frmMain.button170.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("ON_CUA_TU_PHAI"))
                {
                    frmMain.button169.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_CUA_TU_PHAI"))
                {
                    frmMain.button169.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("ON_DEN_DAU_TRAI"))
                {
                    frmMain.button168.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_DEN_DAU_TRAI"))
                {
                    frmMain.button168.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("ON_DEN_DAU_PHAI"))
                {
                    frmMain.button167.BackColor = Color.Green;
                }
                else if (message.Contains("OFF_DEN_DAU_PHAI"))
                {
                    frmMain.button167.BackColor = Color.Gainsboro;
                }else if (message.Contains("STOP"))
                {
                    frmMain.button166.BackColor = Color.Gainsboro;
                }
                else if (message.Contains("PLAY"))
                {
                    frmMain.button166.BackColor = Color.Green;
                }
            }
            catch { }

        }
    }
}
