using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HKTReceiptGenerator.AddAlterationModal
{
    public partial class AddOtherModal : Form
    {
        private AlterationForm.ArticleSelectedCallback articleSelectedCallback;
        public AddOtherModal(AlterationForm.ArticleSelectedCallback articleSelectedCallback)
        {
            this.articleSelectedCallback = articleSelectedCallback;
            InitializeComponent();
        }

        private void AddOtherModal_Load(object sender, EventArgs e)
        {
            DescriptionTextBox.Focus();
        }

        private void OkayButton_Click(object sender, EventArgs e)
        {
            if (validateForm())
            {
                articleSelectedCallback(new AlterationModalCallbackArguments
                {
                    Description = DescriptionTextBox.Text,
                    Price = Convert.ToDouble(PriceTextBox.Text)
                });
            }
            this.Close();
        }

        private Boolean validateForm()
        {
            if (DescriptionTextBox.Text == "")
            {
                MessageBox.Show("Please enter a description.");
                return false;
            }
            else if (PriceTextBox.Text == "")
            {
                MessageBox.Show("Please enter a price.");
                return false;
            }

            try
            {
                Convert.ToDouble(PriceTextBox.Text);
            }
            catch
            {
                MessageBox.Show("You must enter a valid price.");
                return false;
            }
            return true;
        }

        private void PriceTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void DescriptionTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
