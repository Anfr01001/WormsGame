using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Picture_to_array
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            //pictureBox1.Image =
        }

        

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = openFileDialog.FileName;
            }

        }

        private void Startbtn_Click(object sender, EventArgs e)
        {
            OutputBox.Text = "";

            Bitmap img = new Bitmap(pictureBox1.ImageLocation);
            for (int i = 0; i < img.Height; i++)
            {
                OutputBox.Text = OutputBox.Text + "{";
                for (int j = 0; j < img.Width; j++)
                {
                    Color pixel = img.GetPixel(j, i);

                    if (pixel.R == 255 && pixel.G == 255 && pixel.B == 255)
                    {
                        OutputBox.Text = OutputBox.Text + "0,";
                    } else
                    {
                        OutputBox.Text = OutputBox.Text + "1,";
                    }
                }

                OutputBox.Text = OutputBox.Text.Remove(OutputBox.Text.Length - 1);
                OutputBox.Text = OutputBox.Text + "},";
            }
        }

        private void OutputBox_TextChanged(object sender, EventArgs e)
        {
           // OutputBox.Text = "{0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },";
        }
    }
}
