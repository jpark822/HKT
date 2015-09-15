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
            AlterationChosen("P Waist and Seat ($25.00)", 25);
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
            AlterationChosen("P Taper Legs Inside ($25.00)", 25);
        }

        private void HemNoCuffsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Hem No Cuffs ($15.00)", 15);
        }

        private void HemWithCuffsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Hem With Cuffs ($20.00)", 20);
        }

        private void OriginalHemJeansBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Original Hem Jeans ($35.00)", 35);
        }

        private void NewLiningFront_Click(object sender, EventArgs e)
        {
            AlterationChosen("P New Lining Pants - Front Only ($60.00)", 60);
        }

        private void NewLiningFrontBack_Click(object sender, EventArgs e)
        {
            AlterationChosen("P New Lining Pants - Front and Back ($95.00)", 95);
        }

        private void ShirtGuardBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Shirt Guard ($40.00)", 40);
        }

        private void LowerWaistBandBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Lower Waist Band ($50.00)", 50);
        }

        private void WaistAndDartsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Waist And Darts ($30.00)", 30);
        }

        private void AddPantsModal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void HemNoLiningButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Hem With Lining ($10.00)", 10);
        }

        private void TaperLegsOutsideButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("P Taper Legs Outside ($25.00)", 25);
        }
    }
}
