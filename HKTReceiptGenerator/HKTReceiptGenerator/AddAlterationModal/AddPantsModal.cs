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
    public partial class AddPantsModal : Form
    {
        private AlterationForm.ArticleSelectedCallback articleSelectedCallback;
        public AddPantsModal(AlterationForm.ArticleSelectedCallback articleSelectedCallback)
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

        private void WaistAndSeatButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Waist and Seat ($20.00)", 20);
        }

        private void WaistSeatCrotchThigh_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Waist, seat, crotch, thigh (W/S/C/T) ($30.00)", 30);
        }

        private void WSCTToBottom_Click(object sender, EventArgs e)
        {
            AlterationChosen("P W/S/C/T and Taper Legs to Bottom ($40.00)", 40);
        }

        private void TaperLegBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Taper Legs ($20.00)", 20);
        }

        private void HemNoCuffsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Hem No Cuffs ($10.00)", 10);
        }

        private void HemWithCuffsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Hem With Cuffs ($12.00)", 12);
        }

        private void HemJeansBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Hem Jeans ($12.00)", 12);
        }

        private void OriginalHemJeansBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Original Hem Jeans ($30.00)", 30);
        }

        private void NewLiningFront_Click(object sender, EventArgs e)
        {
            AlterationChosen("P New Lining Pants - Front Only ($45.00)", 45);
        }

        private void NewLiningFrontBack_Click(object sender, EventArgs e)
        {
            AlterationChosen("P New Lining Pants - Front and Back ($75.00)", 75);
        }

        private void ShirtGuardBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Shirt Guard ($40.00)", 40);
        }

        private void LowerWaistBandBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Lower Waist Band ($40.00)", 40);
        }

        private void WaistAndDartsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Waist And Darts ($25.00)", 25);
        }

        private void AddPantsModal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
