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
using System.Diagnostics;
using HKTReceiptGenerator.PasswordLockForm;

namespace HKTReceiptGenerator
{
    public partial class MainForm : Form, IMessageFilter
    {
        const double oneHour = 60 * 60 * 1000;
        System.Timers.Timer backupDbTimer = new System.Timers.Timer(oneHour);
        private Int64 idleTicks;
        private System.Windows.Forms.Timer idleTimer;
        private DateTime wentIdle;
        private PasswordLockForm.PasswordLockForm lockForm = new PasswordLockForm.PasswordLockForm();
        private const int idleTimeoutValue = 60 * 15; //this is in seconds, not milliseconds because its based on the idle timer's interval.

        private bool isUserInput(Message m)
        {
            // look for any message that was the result of user input
            if (m.Msg == 0x200) { return true; } // WM_MOUSEMOVE
            if (m.Msg == 0x020A) { return true; } // WM_MOUSEWHEEL
            if (m.Msg == 0x100) { return true; } // WM_KEYDOWN
            if (m.Msg == 0x101) { return true; } // WM_KEYUP

            return false;
        }

        public bool PreFilterMessage(ref Message m)
        {
            // reset our last idle time if the message was user input. will trigger when not idle.
            if (isUserInput(m))
            {
                wentIdle = DateTime.MaxValue;
                idleTicks = 0;
            }

            return false;
        }

        public MainForm()
        {
            
            InitializeComponent();
            backupDbTimer.Enabled = true;
            this.Shown += MainForm_Shown;
            Application.Idle += Application_Idle;
            this.FormClosing += MainForm_FormClosing;
            Application.AddMessageFilter(this);
            this.FormClosed += delegate { Application.RemoveMessageFilter(this); };

            idleTimer = new System.Windows.Forms.Timer();
            idleTimer.Interval = 1000;
            idleTimer.Tick += idleTimer_Tick;
            idleTimer.Start();
        }

        void idleTimer_Tick(object sender, EventArgs e)
        {
            TimeSpan diff = DateTime.Now - wentIdle;
            // see if we have been idle longer than our configured value. not needed currently.
            //if (diff.TotalSeconds >= time in seconds)
            //{

            //}

            /**  OR  **/

            // see if we have gone idle based on our configured value
            if (idleTicks++ >= idleTimeoutValue)
            {
                if (lockForm.Visible == false)
                {
                    lockForm.ShowDialog();
                }
            }
        }
        
        void Application_Idle(object sender, EventArgs e)
        {
            wentIdle = DateTime.Now;
        }


        void MainForm_Shown(object sender, EventArgs e)
        {
            lockForm.ShowDialog();

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
            Customer.CustomerSearch customerForm = new Customer.CustomerSearch();
            customerForm.Show();
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

        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit the program?", "Quit", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                e.Cancel = true;
            }
            else
            {
                Application.Idle -= Application_Idle;
            }
        }
    }
}
