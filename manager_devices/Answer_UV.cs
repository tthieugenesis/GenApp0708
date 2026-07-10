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
    public partial class Answer_UV : Form
    {
        public Answer_UV()
        {
            InitializeComponent();
        }

        void GetData(int index)
        {
            string pic1FilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\de_uv\\Mat_na.jpg";

            string picFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\de_uv\\";
            // Path to the image
            picFilePath += "De_"+index.ToString() +".jpg";

            // Load the image from the file and set it to the PictureBox
            try
            {
                pictureBox1.Image = Image.FromFile(pic1FilePath);
                pictureBox2.Image = Image.FromFile(picFilePath);
                label1.Text = "Đề " + index.ToString() + " người";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        private void Answer_UV_Load(object sender, EventArgs e)
        {
            if (frmMain.De_4_nguoi == true)
            {
                GetData(4);
            }
            else if (frmMain.De_5_nguoi == true)
            {
                GetData(5);
            }
            else if (frmMain.De_6_nguoi == true)
            {
                GetData(6);
            }
            else if (frmMain.De_7_nguoi == true)
            {
                GetData(7);
            }
            else if (frmMain.De_8_nguoi == true)
            {
                GetData(8);
            }

        }
    }
}
