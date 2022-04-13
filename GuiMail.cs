using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class GuiMail : Form
    {
        Attachment attach = null;
        public GuiMail()
        {
            InitializeComponent();
        }
        void GuiMaill(string from, string to, string subject, string message, Attachment file = null)
        {
            try
            {
                MailMessage mess = new MailMessage(from, to, subject, message);
                if (attach != null)
                {
                    mess.Attachments.Add(attach);
                }
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Credentials = new NetworkCredential("vuducnham1123@gmail.com", "14082002nham");
                client.Send(mess);
                MessageBox.Show("Gửi thành công");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void GuiMail_Load(object sender, EventArgs e)
        {

        }

        private void btnGui_Click(object sender, EventArgs e)
        {
            attach = null;
            try
            {
                FileInfo file = new FileInfo(textBox1.Text);
                attach = new Attachment(textBox1.Text);
                GuiMaill("vuducnham1123@gmail.com", txtTo.Text, txtSubject.Text, richTextBoxMessage.Text, attach);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Gửi không thành công" + ex.Message);
            }
        }

        private void btnTaiFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }
    }
}
