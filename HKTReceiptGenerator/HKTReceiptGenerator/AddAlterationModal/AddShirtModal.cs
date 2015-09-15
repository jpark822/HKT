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
    public partial class AddShirtModal : Form
    {
        private AlterationForm.ArticleSelectedCallback articleSelectedCallback;
        public AddShirtModal(AlterationForm.ArticleSelectedCallback articleSelectedCallback)
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

        private void TaperSidesButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("S Taper Sides ($30.00)", 30.00);
        }

        private void ShortenSleevesButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("S Shorten Sleeves ($20.00)", 20);
        }

        private void ShortenLengthButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("S Shorten Length ($20.00)", 20);
        }

        private void DartsButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("S Darts ($10.00)", 10);
        }

        private void AddShirtModal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}
