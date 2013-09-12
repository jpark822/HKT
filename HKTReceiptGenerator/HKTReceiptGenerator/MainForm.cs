using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.IO;
using System.Configuration;
using HKTReceiptGenerator.AdminStats;
using System.Timers;

namespace HKTReceiptGenerator
{
    public partial class MainForm : Form
    {
        const double oneHour = 60 * 60 * 1000;
        System.Timers.Timer backupDbTimer = new System.Timers.Timer(oneHour);      

        public MainForm()
        {
            
            InitializeComponent();
            backupDbTimer.Elapsed += backupDbTimer_Elapsed;
            backupDbTimer.Enabled = true;
            this.Shown += MainForm_Shown;
        }

        void backupDbTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            if (DateTime.Now.Hour == 20)
            {
                Emailer.SendBackupToEmail();
            }
        }

        void MainForm_Shown(object sender, EventArgs e)
        {
            string username = ConfigurationManager.AppSettings["UserName"];
            string password = ConfigurationManager.AppSettings["Password"];

            if (username == "" || password == "")
            {
                LoginForm form = new LoginForm();
                form.ShowDialog();
            }
        }

        private void NewTicketBttn_Click(object sender, EventArgs e)
        {
            AlterationForm altForm = new AlterationForm();
            altForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            SearchForm searchForm = new SearchForm();
            searchForm.Show();
        }

        private void AdminStatsButton_Click(object sender, EventArgs e)
        {
            AdminStatsForm form = new AdminStatsForm();
            form.Show();
        }
    }
}
