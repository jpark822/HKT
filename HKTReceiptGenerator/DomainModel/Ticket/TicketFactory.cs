using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.Ticket
{
    //TODO: raise domain event (TicketResourceCreate) and run validations on created objects
    public class TicketFactory
    {
        public static TicketResource CreateTicket(int ticketId, String status, String title, String firstName, String lastName, String middleName, String address, String city, String state, String zip, String telephone, String email, String comments,
            String pickedUp, DateTime dateIn, DateTime dateReady, double totalPrice, double Deposit, String tailorName, String orderId, DateTime? completedDate, int customerId)
        {
            TicketResource ticket = new TicketResource
            {
                TicketId = ticketId,
                Status = status,
                Title = title,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                Telephone = telephone,
                Email = email,
                Comments = comments,
                PickedUp = pickedUp,
                DateIn = dateIn,
                DateReady = dateReady,
                TotalPrice = totalPrice,
                Deposit = Deposit,
                TailorName = tailorName,
                OrderId = orderId,
                CompletedDate = completedDate,
                CustomerID = customerId
            };
            return ticket;
        }

        public static TicketResource CreateTicket(String status, String firstName, String lastName, String middleName, String address, String city, String state, String zip, String telephone, String email, String comments,
            String pickedUp, DateTime dateIn, DateTime dateReady, double totalPrice, double Deposit, String tailorName)
        {
            TicketResource ticket = new TicketResource
            {
                Status = status,
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                Address = address,
                City = city,
                State = state,
                Zip = zip,
                Telephone = telephone,
                Email = email,
                Comments = comments,
                PickedUp = pickedUp,
                DateIn = dateIn,
                DateReady = dateReady,
                TotalPrice = totalPrice,
                Deposit = Deposit,
                TailorName = tailorName
            };
            return ticket;
        }
    }
}
