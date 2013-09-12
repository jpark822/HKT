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
    public partial class AddJacketModal : Form
    {
        private AlterationForm.ArticleSelectedCallback articleSelectedCallback;
        public AddJacketModal(AlterationForm.ArticleSelectedCallback articleSelectedCallback)
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

        private void SleevesShortLengthButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Sleeves - Shorten or Lengthen ($25.00)", 25.00);
        }

        private void ShouldersButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Shoulders ($125.00)", 125.00);
        }

        private void SleevesTaperLetButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Sleeves - Taper or Let Out ($30.00)", 30.00);
        }

        private void LowerRollBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Lower Roll Behind Collar ($35.00)", 35.00);
        }

        private void ExtensiveRollBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Lift Back Panel For Extensive Roll Behind Collar ($75.00)", 75.00);
        }

        private void SidesBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Sides ($45.00)", 45.00);
        }

        private void DartsAtFrontBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Darts at Front ($25.00)", 25.00);
        }

        private void CollarInBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Collar in ($50.00)", 50.00);
        }

        private void CollarInToWasitBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Collar in to Waistline ($75.00)", 75.00);
        }

        private void ShouldPadReplaceBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Shoulder Pad Replace - One Pad ($20.00)", 20.00);
        }

        private void NarrowLapelsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Narrow Lapels ($100.00)", 100.00);
        }

        private void FunctionalButtonHolesSleevesBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Functional Button holes in Sleeves or Lapel ($10)", 10);
        }

        private void FunctionalButtonHolesLapelBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Functional Button Holes on front panel or Lapel ($20)", 20);
        }

        private void NewLiningBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J New Lining ($150.00)", 150);
        }

        private void ShortenLengthBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Shorten Length ($45.00)", 45);
        }

        private void CloseSingleVentsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Close Single Vents ($20.00)", 20);
        }

        private void CloseTwoVentsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Close Two Vents ($30.00)", 30);
        }

        private void DoubleToSingleBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Double Brested to Single Brested ($100.00)", 100);
        }

        private void AddJacketModal_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
