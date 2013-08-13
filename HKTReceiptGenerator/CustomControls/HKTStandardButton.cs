using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace CustomControls
{
    public class HKTStandardButton : Button
    {
        public HKTStandardButton()
        {
            SetupButton();
        }

        private void SetupButton()
        {
            this.MouseDown += HKTStandardButton_MouseDown;
            this.MouseUp += HKTStandardButton_MouseUp;

            this.Font = new Font("Trajan Pro", 14);
            this.ForeColor = Color.White;
            this.BackColor = Color.Maroon;
        }

        void HKTStandardButton_MouseUp(object sender, MouseEventArgs e)
        {
            ForeColor = Color.White;
            BackColor = Color.Maroon;
        }

        void HKTStandardButton_MouseDown(object sender, MouseEventArgs e)
        {
            ForeColor = Color.Maroon;
            BackColor = Color.White;
        }
    }
}
