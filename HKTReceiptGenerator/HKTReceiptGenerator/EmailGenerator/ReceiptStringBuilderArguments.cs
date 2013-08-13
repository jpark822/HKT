using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKTReceiptGenerator
{
    public class ReceiptStringBuilderArguments
    {
        public int TicketId { get; set; }
        public String Status { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Comments { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateReady { get; set; }
        public double TotalPrice { get; set; }
        public double Deposit { get; set; }
        public String TailorName { get; set; }
        public List<AlterationGridItem> GridItems = new List<AlterationGridItem>();
        public String Telephone { get; set; }
        public Boolean isCustomerCopy;
    }
}
