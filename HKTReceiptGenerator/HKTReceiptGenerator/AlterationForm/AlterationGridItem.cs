using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKTReceiptGenerator
{
    public class AlterationGridItem
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }
        public bool Taxable { get; set; }

        public AlterationGridItem(double price, int quantity, String description, bool taxable)
        {
            Price = price;
            Quantity = quantity;
            Description = description;
            Taxable = taxable;
        }
    }
}
