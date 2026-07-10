using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
    public class SanKhau_Class
    {
        bool Turn1A = false;
        public static void GetFrame(string message)
        {
            try
            {
                string data = message.Split('-')[1];
                if (data == "ON_DEN_SONG")
                {
                    _ = frmMain.button163.Invoke((MethodInvoker)delegate
                    {
                        _ = frmMain.button163.BackColor = Color.Green;
                    });
                }
                else if(data == "OFF_DEN_SONG")
                {
                    _ = frmMain.button163.Invoke((MethodInvoker)delegate
                    {
                        _ = frmMain.button163.BackColor = Color.Gainsboro;
                    });
                }
                else if (data[0] == '1' || data[0] == '2' || data[0] == '3' || data[0] == '4')
                {
                    _ = frmMain.text_Dap_an_cam_xuc.Text = data;
                }
                else if (data.Contains("DE_1"))
                {
                    Mp3.PlaySong(Mp3.SOUND_20);
                }
                else if (data.Contains("DE_2"))
                {
                    Mp3.PlaySong(Mp3.SOUND_21);
                }
                else if (data.Contains("DE_3"))
                {
                    Mp3.PlaySong(Mp3.SOUND_22);
                }
                else if (data.Contains("DE_4"))
                {
                    Mp3.PlaySong(Mp3.SOUND_23);
                }
                else if (data.Contains("Dam_dung"))
                {
                    Mp3.PlaySong(Mp3.SOUND_25);
                }
                else if (data.Contains("Dam_sai"))
                {
                    Mp3.PlaySong(Mp3.SOUND_24);
                }
                else if (data.Contains("Chien_thang_cam_xuc"))
                {
                    Mp3.PlaySong(Mp3.SOUND_26);
                }
                else if (data.Contains("Chien_thang_mach_cam_xuc"))
                {
                    Mp3.PlaySong(Mp3.SOUND_27);
                }
                else if (data.Contains("MO_TU_HANH_LANG_TRANG_DIEM"))
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("OFF-" + frmMain.NUT_12.ToString());

                }
                else if (data.Contains("MO_DEN_ROI_TRANG_DIEM"))
                {
                    _ = frmMain.Tudien_Server.SendMessageAsync("ON-" + frmMain.NUT_8.ToString());

                }
            }
            catch (Exception e)
            {
                Log.Error(e.ToString());
            }


        }

    }
}
