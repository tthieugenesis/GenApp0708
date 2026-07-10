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
    public partial class Chair : Form
    {
        public static int DataChair = 0;
        public Chair()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            string temp = btn.Text.Split(' ')[1].Trim();
            MessageBox.Show(btn.Text);
            switch (temp)
            {
                case "1":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~2097152;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 2097152;
                        }
                        break;
                    }
                case "2":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~512;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 512;
                        }
                        break;
                    }
                case "3":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~16384;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 16384;
                        }
                        break;
                    }
                case "4":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~128;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 128;
                        }
                        break;
                    }
                case "5":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~4096;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 4096;
                        }
                        break;
                    }
                case "6":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~2048;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 2048;
                        }
                        break;
                    }
                case "7":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~1024;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 1024;
                        }
                        break;
                    }
                case "8":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~256;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 256;
                        }
                        break;
                    }
                case "9":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~8192;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 8192;
                        }
                        break;
                    }
                case "10":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~32;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 32;
                        }
                        break;
                    }
                case "11":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~64;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 64;
                        }
                        break;
                    }
                case "12":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~16;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 16;
                        }
                        break;
                    }
                case "13":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~32768;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 32768;
                        }
                        break;
                    }
                case "14":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~131072;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 131072;
                        }
                        break;
                    }
                case "15":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~524288;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 524288;
                        }
                        break;
                    }
                case "16":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~65536;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 65536;
                        }
                        break;

                    }
                case "17":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~262144;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 262144;
                        }
                        break;

                    }
                case "18":
                    {
                        if (btn.BackColor == Color.Green)
                        {
                            btn.BackColor = Color.Transparent;
                            DataChair &= ~1048576;
                        }
                        else
                        {
                            btn.BackColor = Color.Green;
                            DataChair |= 1048576;
                        }
                        break;

                    }
            }
        }

        private void button22_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button20_Click(object sender, EventArgs e)
        {
            //frmMain.san
            _ = frmMain.PhongCho_Server.SendMessageAsync("SAN_KHAU-CREATE_EXAMPLE-" + DataChair.ToString());
            this.Close();
        }

        private void Chair_Load(object sender, EventArgs e)
        {
            if ((Chair.DataChair & 2097152) == 2097152)
            {
                sghe1.BackColor = Color.Green;
            }

            if ((Chair.DataChair & 512) == 512)
            {
                sghe2.BackColor = Color.Green;
            }

            if ((Chair.DataChair & 16384) == 16384)
            {
                sghe3.BackColor = Color.Green;
            }

            if ((Chair.DataChair & 128) == 128)
            {
                sghe4.BackColor = Color.Green;
            }

            if ((Chair.DataChair & 4096) == 4096)
            {
                sghe5.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 2048) == 2048)
            {
                sghe6.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 1024) == 1024)
            {
                sghe7.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 256) == 256)
            {
                sghe8.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 8192) == 8192)
            {
                sghe9.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 32) == 32)
            {
                sghe10.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 64) == 64)
            {
                sghe11.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 16) == 16)
            {
                sghe12.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 32768) == 32768)
            {
                sghe13.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 131072) == 131072)
            {
                sghe14.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 524288) == 524288)
            {
                sghe15.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 65536) == 65536)
            {
                sghe16.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 262144) == 262144)
            {
                sghe17.BackColor = Color.Green;
            }
            if ((Chair.DataChair & 1048576) == 1048576)
            {
                sghe18.BackColor = Color.Green;
            }
        }

        private void button21_Click(object sender, EventArgs e)
        {
            DataChair = 0;
            sghe9.BackColor = Color.Transparent;
            sghe1.BackColor = Color.Transparent;
            sghe14.BackColor = Color.Transparent;
            sghe13.BackColor = Color.Transparent;
            sghe8.BackColor = Color.Transparent;
            sghe3.BackColor = Color.Transparent;
            sghe2.BackColor = Color.Transparent;
            sghe15.BackColor = Color.Transparent;
            sghe7.BackColor = Color.Transparent;
            sghe17.BackColor = Color.Transparent;
            sghe6.BackColor = Color.Transparent;
            sghe10.BackColor = Color.Transparent;
            sghe4.BackColor = Color.Transparent;
            sghe11.BackColor = Color.Transparent;
            sghe18.BackColor = Color.Transparent;
            sghe12.BackColor = Color.Transparent;
            sghe16.BackColor = Color.Transparent;
            sghe5.BackColor = Color.Transparent;
        }
    }
}
