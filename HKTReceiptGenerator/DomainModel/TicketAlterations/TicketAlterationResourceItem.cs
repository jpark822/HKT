using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.TicketAlterations
{
    //TODO create a factory for this class
    public class TicketAlterationResourceItem
    {
        public int TicketId { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public String Description { get; set; }
        public int Taxable { get; set; }
    }
}
