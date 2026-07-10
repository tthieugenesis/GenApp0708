using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThanVong
{
    public partial class ShowAnswer : Form
    {
        public ShowAnswer()
        {
            InitializeComponent();


        }

        void GetData(int index, int index2)
        {
            string picFilePath = System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\pic_ghe_ngoi\\";
            // Path to the image
            picFilePath += index.ToString() + "ng đề " + index2.ToString() + " đ.an.jpg";

            // Load the image from the file and set it to the PictureBox
            try
            {
                pictureBox1.Image = Image.FromFile(picFilePath);
                label1.Text = index.ToString() + "ng đề " + index2.ToString() + " đ.an";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
        }

        private void ShowAnswer_Load(object sender, EventArgs e)
        {
            if (frmMain.De_4_1 == true)
            {
                GetData(4, 1);
            }
            else if (frmMain.De_4_2 == true)
            {
                GetData(4, 2);
            }
            else if (frmMain.De_5_1 == true)
            {
                GetData(5, 1);
            }
            else if (frmMain.De_5_2 == true)
            {
                GetData(5, 2);
            }
            if (frmMain.De_6_1 == true)
            {
                GetData(6, 1);
            }
            else if (frmMain.De_6_2 == true)
            {
                GetData(6, 2);
            }
            if (frmMain.De_7_1 == true)
            {
                GetData(7, 1);
            }
            else if (frmMain.De_7_2 == true)
            {
                GetData(7, 2);
            }
            if (frmMain.De_8_1 == true)
            {
                GetData(8, 1);
            }
            else if (frmMain.De_8_2 == true)
            {
                GetData(8, 2);
            }
        }
    }
}
