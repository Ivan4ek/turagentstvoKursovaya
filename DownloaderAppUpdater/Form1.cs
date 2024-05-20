using System;
using System.Net;
using System.Reflection;
using System.Windows.Forms;

namespace DownloaderAppUpdater
{
    public partial class Form1 : Form
    {
        string currentVersion = Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (WebClient webClient = new WebClient())
            {
                if (Internet.CheckConnection())
                {
                    string readVersion = webClient.DownloadString("https://github.com/Ivan4ek/turagentstvoKursovaya");
                    MessageBox.Show("Актуальная версия программы: " + readVersion, "Уведомление!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Нет доступа в сеть", "Ошибка доступа в сеть!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    class Internet
    {
        public static bool CheckConnection()
        {
            try
            {
                Dns.GetHostEntry("github.com");
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
