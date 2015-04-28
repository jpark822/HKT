using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Ticket
{
    public class TicketResource
    {
        public int TicketId { get; set; }
        public String Status { get; set; }
        public String Title { get; set; }
        public String FirstName { get; set; }
        public String MiddleName { get; set; }
        public String LastName { get; set; }
        public String Address { get; set; }
        public String City { get; set; }
        public String State { get; set; }
        public String Zip { get; set; }
        public String Telephone { get; set; }
        public String Email { get; set; }
        public String Comments { get; set; }
        public String PickedUp { get; set; }
        public DateTime LastModifiedTimestamp { get; set; }
        public DateTime DateIn { get; set; }
        public DateTime DateReady { get; set; }
        public double TotalPrice { get; set; }
        public double Deposit { get; set; }
        public String TailorName { get; set; }
        public String OrderId { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int CustomerID { get; set; }
    }
}
