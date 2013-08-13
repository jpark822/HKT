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
    public partial class AddAlterationBaseForm : Form
    {
        AlterationForm.ClothingSelectedCallback clothingSelectedCallback;

        public AddAlterationBaseForm(AlterationForm.ClothingSelectedCallback clothingSelectedCallback)
        {
            InitializeComponent();
            this.clothingSelectedCallback = clothingSelectedCallback;
        }

        private void JacketButton_Click(object sender, EventArgs e)
        {
            clothingSelectedCallback(AlterationForm.TypeOfClothing.Jacket);
            this.Close();
        }

        private void ShirtButton_Click(object sender, EventArgs e)
        {
            clothingSelectedCallback(AlterationForm.TypeOfClothing.Shirt);
            this.Close();
        }

        private void PantsButton_Click(object sender, EventArgs e)
        {
            clothingSelectedCallback(AlterationForm.TypeOfClothing.Pants);
            this.Close();
        }

        private void VestBttn_Click(object sender, EventArgs e)
        {
            clothingSelectedCallback(AlterationForm.TypeOfClothing.Vest);
            this.Close();
        }

        private void MiscellaneousBttn_Click(object sender, EventArgs e)
        {
            clothingSelectedCallback(AlterationForm.TypeOfClothing.Miscellaneous);
            this.Close();
        }

        private void AddAlterationBaseForm_Load(object sender, EventArgs e)
        {
            this.Top = 0;
        }

        private void AddOtherAlterationButton_Click(object sender, EventArgs e)
        {
            clothingSelectedCallback(AlterationForm.TypeOfClothing.Other);
            this.Close();
        }
    }
}
