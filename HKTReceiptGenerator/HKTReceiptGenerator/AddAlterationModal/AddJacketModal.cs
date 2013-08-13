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
            AlterationChosen("Sleeves - Shorten or Lengthen ($25.00)", 25.00);
        }

        private void ShouldersButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("Shoulders ($125.00)", 125.00);
        }

        private void SleevesTaperLetButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("Sleeves - Taper or Let Out ($30.00)", 30.00);
        }

        private void LowerRollBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Lower Roll Behind Collar ($35.00)", 35.00);
        }

        private void ExtensiveRollBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Lift Back Panel For Extensive Roll Behind Collar ($75.00)", 75.00);
        }

        private void SidesBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Sides ($45.00)", 45.00);
        }

        private void DartsAtFrontBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Darts at Front ($25.00)", 25.00);
        }

        private void CollarInBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Collar in ($50.00)", 50.00);
        }

        private void CollarInToWasitBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Collar in to Waistline ($75.00)", 75.00);
        }

        private void ShouldPadReplaceBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Shoulder Pad Replace - One Pad ($20.00)", 20.00);
        }

        private void NarrowLapelsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Narrow Lapels ($100.00)", 100.00);
        }

        private void FunctionalButtonHolesSleevesBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Funtional Button holes in Sleeves or Lapel ($10)", 10);
        }

        private void FunctionalButtonHolesLapelBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Funtional Button Holes on front panel or Lapel ($20)", 20);
        }

        private void NewLiningBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("New Lining ($150.00)", 150);
        }

        private void ShortenLengthBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Shorten Length ($45.00)", 45);
        }

        private void CloseSingleVentsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Close Single Vents ($20.00)", 20);
        }

        private void CloseTwoVentsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Close Two Vents ($30.00)", 30);
        }

        private void DoubleToSingleBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("Double Brested to Single Brested ($100.00)", 100);
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
