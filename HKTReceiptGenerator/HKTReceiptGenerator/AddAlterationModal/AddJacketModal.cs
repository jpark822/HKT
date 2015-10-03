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
            AlterationChosen("J Sleeves - Shorten or Lengthen ($30.00)", 30.00);
        }

        private void ShouldersButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Shoulders ($175.00)", 175.00);
        }

        private void SleevesTaperLetButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Sleeves - Taper or Let Out ($35.00)", 35.00);
        }

        private void LowerRollBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Lower Roll Behind Collar ($40.00)", 40.00);
        }

        private void ExtensiveRollBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Lift Back Panel For Extensive Roll Behind Collar ($120.00)", 120.00);
        }

        private void SidesBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Sides ($55.00)", 55.00);
        }

        private void DartsAtFrontBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Darts at Front ($35.00)", 35.00);
        }

        private void CollarInBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Collar in ($70.00)", 70.00);
        }

        private void CollarInToWasitBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Collar in to Waistline ($100.00)", 100.00);
        }

        private void ShouldPadReplaceBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Shoulder Pad Replace - One Pad ($20.00)", 20.00);
        }

        private void NarrowLapelsBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Narrow Lapels ($120.00)", 120.00);
        }

        private void FunctionalButtonHolesSleevesBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Functional Button holes in Sleeves or Lapel ($15)", 15);
        }

        private void FunctionalButtonHolesLapelBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Functional Button Holes on front panel or Lapel ($25)", 25);
        }

        private void NewLiningBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J New Lining ($200.00)", 200);
        }

        private void ShortenLengthBttn_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Shorten Length ($60.00)", 60);
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

        private void DartUnderLapelButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Dart Under Lapel ($75.00)", 75);
        }

        private void ButtonHoleReadySleevesButton_Click(object sender, EventArgs e)
        {
            AlterationChosen("J Button Hole Ready Sleeves ($25)", 25);
        }
    }
}
