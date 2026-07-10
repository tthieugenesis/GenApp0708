using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ThanVong
{
    public static class Dimmer_Class
    {
        static int countDK4C = 0;
        static int countDK2A = 0;
        static int countDK3C = 0;
        static int countDK2B = 0;

        public static async void HandMessage(string message)
        {
            string regex = @"DIMMER-\d{1,3}-DONE\r\n";
            Regex Myregex = new Regex(regex);

            if (Myregex.IsMatch(message))
            {
                try
                {
                    string valueStr = message.Split('-')[1];
                    int value = int.Parse(valueStr);
                    frmMain.trackBar1.Value = value;
                    frmMain.label1.Text = value.ToString() + "%";
                }
                catch { }
            }

            if (message.Contains("CONG_TAC_HANH_TRINH_CORRECT"))
            {
                if (frmMain.isPlayMusicDoaMa == true)
                {
                    _ = frmMain.PhongCho_Server.SendMessageAsync("PHONG_CHO-CONG_TAC_HANH_TRINH");
                    Mp3.PlaySong(Mp3.SOUND_14);
                    frmMain.isPlayMusicDoaMa = false;
                    frmMain.button158.BackColor = Color.Gainsboro;
                    _ = frmMain.Tudien_Server.SendMessageAsync("NOT_BLYNK_DEN_ROI_SAN_KHAU");
                }

            }

        }
    }
}
