using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FaceRecognition;
namespace WindowsFormsApp4
{
    public partial class BaoDanhBangKhuonMat : Form
    {
        public BaoDanhBangKhuonMat()
        {
            InitializeComponent();
        }
        FaceRec faceRec = new FaceRec();
        private void button1_Click(object sender, EventArgs e)
        {
            faceRec.openCamera(pictureBox1, pictureBox2);
            faceRec.isTrained = true;
            faceRec.getPersonName(textBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            faceRec.Save_IMAGE(textBox1.Text);
            MessageBox.Show("Thành công");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                faceRec.isTrained = false;
                if (BUSINESS.General_BUS.BaoDanh(textBox1.Text) == true)
                {
                    MessageBox.Show("Báo danh thành công");
                }
                else
                {
                    MessageBox.Show("Báo danh không thành công");
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }
    }
}
