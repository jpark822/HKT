using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HKTReceiptGenerator
{
    public class ReceiptStringBulder
    {
        public static String BuildStringFromArgs(ReceiptStringBuilderArguments args, Boolean isCusomterCopy, Boolean isEmailCopy)
        {
            StringBuilder text = new StringBuilder();
            if (isCusomterCopy)
            {
                text.AppendLine("                Hong Kong Tailors");
                text.AppendLine("           5378 Buford Highway NE");
                text.AppendLine("                Atlanta, GA 30340");
                text.AppendLine("                    770.458.8682");
                text.AppendLine("            www.hongkongtailor.com");
                text.AppendLine();  
            }
            text.AppendLine("Ticket ID: " + args.TicketId);

            String nameTitle = "";
            if (args.Title != "" && args.Title != null)
            {
                nameTitle = args.Title + " ";
            }
            text.AppendLine("Name: " + nameTitle + args.FirstName + " " + args.LastName);
            text.AppendLine("Date In: " + args.DateIn.ToLongDateString());
            text.AppendLine("Date Ready: " + args.DateReady.ToLongDateString() + " After 4:00PM");
            if (!isCusomterCopy)
            {
                text.AppendLine("Phone: " + args.Telephone);
            }
            text.AppendLine("Number of Items: " + args.GridItems.Sum(x => x.Quantity));
            text.AppendLine();

            for (int i = 0; i < args.GridItems.Count; i++)
            {
                AlterationGridItem item = args.GridItems[i];
                string quantity = item.Quantity == 0 ? "" : item.Quantity.ToString();
                string price = item.Price == 0 ? "" : String.Format("{0:C}", item.Price);
                text.AppendLine(quantity + " " + item.Description + " " + price);
            }

            text.AppendLine();
            text.AppendLine(String.Format("Total Price: {0:C}", args.TotalPrice));
            text.AppendLine(String.Format("Deposit: {0:C}", args.Deposit));
            text.AppendLine(String.Format("Balance: {0:C}", args.TotalPrice - args.Deposit));
            text.AppendLine();

            if (isCusomterCopy && isEmailCopy)
            {
                text.AppendLine("Please DO NOT reply to this automated email as its inbox is unmonitored. Please contact HKT@hongkongtailor.com if you have any questions or concerns.");
                text.AppendLine();
            }
            if (isCusomterCopy)
            {
                text.AppendLine("All major cards accepted. ");
                text.AppendLine("We are not responsible for alterations left at store for more than 60 days or once garments have been picked up from the store. ");
                text.AppendLine();
                text.AppendLine("New, unused, unaltered merchandise can be exchanged or returned up to 15 days from date of purchase.");
                text.AppendLine("No refunds or exchanges on custom clothing. ");
                text.AppendLine("Custom orders are generally ready 4 to 6 weeks from order date. ");
                text.AppendLine("Refunds will be issued in the original tender of the purchase, except cash refunds will be issued by check.");
                text.AppendLine("Hong Kong Tailors reserves the right to modify its return and exchange policy");
                text.AppendLine();
                text.AppendLine("Thank you for choosing Hong Kong Tailors!");
            }
            else if (!isCusomterCopy)
            {
                text.AppendLine("Tailor: " + args.TailorName);
                text.AppendLine(args.Comments);
            }

            return text.ToString();
        }

    }
}
