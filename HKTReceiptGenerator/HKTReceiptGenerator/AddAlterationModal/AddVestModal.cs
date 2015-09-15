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
    public partial class AddVestModal : Form
    {
        private AlterationForm.ArticleSelectedCallback articleSelectedCallback;
        public AddVestModal(AlterationForm.ArticleSelectedCallback articleSelectedCallback)
        {
            this.articleSelectedCallback = articleSelectedCallback;
            InitializeComponent();
        }

        private void AlterationChosen(String description, double price)
        {
            articleSelectedCallback(new AlterationModalCallbackArguments
            {
                Description = description,
                Price = price
            });
        }

        private void TaperBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("V Taper Sides ($30.00)", 30);
        }

        private void BackPanelBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("V New Back Panel ($75.00)", 75);
        }

        private void ShortenBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("V Shorten Length ($40.00)", 40);
        }

        private void AddVestModal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
