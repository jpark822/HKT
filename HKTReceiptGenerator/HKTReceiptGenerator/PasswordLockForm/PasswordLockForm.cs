using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKTReceiptGenerator.PasswordLockForm
{
    public partial class PasswordLockForm : Form
    {
        private const String passwordString = "963";
        private const int WS_SYSMENU = 0x80000;

        //hides min max and close buttons
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                cp.Style &= ~WS_SYSMENU;
                return cp;
            }
        }

        public PasswordLockForm()
        {
            InitializeComponent();
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (passwordTextBox.Text == passwordString)
            {
                passwordTextBox.Text = "";
                this.Close();
            }
            else
            {
                passwordTextBox.Text = "";
                MessageBox.Show("You entered an incorrect password. Please try again.", "Incorrect Password", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
