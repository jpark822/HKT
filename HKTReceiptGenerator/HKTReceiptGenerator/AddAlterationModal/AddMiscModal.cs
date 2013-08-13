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
    public partial class AddMiscModal : Form
    {
        private AlterationForm.ArticleSelectedCallback articleSelectedCallback;
        public AddMiscModal(AlterationForm.ArticleSelectedCallback articleSelectedCallback)
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

        private void PatchBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Patch ($5.00)", 5);
        }

        private void CDCBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Public Health Service Braids On Sleeves ($35.00)", 35);
        }

        private void TieExtendShortenBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Tie Extension/Shortening ($20.00)", 20);
        }

        private void TieNarrowingBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Tie Narrowing ($20.00)", 20);
        }

        private void AddMiscModal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
