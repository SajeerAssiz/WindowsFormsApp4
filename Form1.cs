using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraReports.UI;
using System.Collections.Generic;
using System.Net.Mail;
using System.Configuration;

namespace WindowsFormsApp4
{
   
    public partial class Form1 : Form
    {
        public string start = "";
        public Form1()
        {
            InitializeComponent();
            
            var appSettings = ConfigurationManager.AppSettings;

             start = appSettings["Start"].ToString();
            string strSPFEmail = appSettings["SPFEmail"].ToString();
            string strTFSEmail = appSettings["TFSEmail"].ToString();
            string strTestEmail = appSettings["TestEmail"].ToString();

            if (start == "Auto")

            {
                txtSPF.Text = strSPFEmail;
                txtTFS.Text = strTFSEmail;


                EventArgs k = new EventArgs();
                System.Threading.Thread.Sleep(5000);
                button2_Click_1(this, k);

                System.Threading.Thread.Sleep(5000);
                button1_Click_1(this, k);

                Application.Exit();

            }

            if (start == "Test")
            {
                txtSPF.Text = strTestEmail;
                txtTFS.Text = strTestEmail;

                EventArgs k = new EventArgs();
               // System.Threading.Thread.Sleep(5000);
                button2_Click_1(this, k);

              //  System.Threading.Thread.Sleep(5000);
                button1_Click_1(this, k);

                
            }

      
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport1();

            using (SmtpClient client = new SmtpClient("smtp.office365.com", 587))
            {
                using (MailMessage message = report.ExportToMail("techheroes@thesolutionglobal.com",
                "assiz@thesolutionglobal.com", "SPF DSR"))
                {
                    client.Credentials = new System.Net.NetworkCredential("techheroes@thesolutionglobal.com", "pass@word1");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // documentViewer1.
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport2();
            report.Parameters[0].Value = "TFS";
            using (SmtpClient client = new SmtpClient("smtp.office365.com", 587))
            {
                using (MailMessage message = report.ExportToMail("ax.d365support@al-ghurair.com", txtTFS.Text
                , "TFS DSR"))
                {
                    client.Credentials = new System.Net.NetworkCredential("ax.d365support@al-ghurair.com", "@x365dyn@20!9");
                   // client.Credentials = new System.Net.NetworkCredential("techheroes@thesolutionglobal.com", "pass@word1");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            XtraReport report = new XtraReport2();
            report.Parameters[0].Value = "SPF";
            using (SmtpClient client = new SmtpClient("smtp.office365.com", 587))
            {
                using (MailMessage message = report.ExportToMail("ax.d365support@al-ghurair.com", txtSPF.Text
                , "SPF DSR"))
                {
                    client.Credentials = new System.Net.NetworkCredential("ax.d365support@al-ghurair.com", "@x365dyn@20!9");
                    // client.Credentials = new System.Net.NetworkCredential("techheroes@thesolutionglobal.com", "pass@word1");
                    client.EnableSsl = true;
                    client.Send(message);
                }
            }

        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        
        private void Form1_Load(object sender, EventArgs e)
        {
            if ((start == "Auto") || (start == "Test"))

                this.Close();


        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
