using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SQLite;

namespace DomainModel.TicketAlterations
{
    //TODO use mapping library (probably NHibernate) to pipe in values from the database.
    public class TicketAlterationRepository
    {
        public void InsertAlterations(TicketAlterationResource alterationResource)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            List<Dictionary<String, object>> alterationDicts = ConvertAlterationsIntoDictionaries(alterationResource);
            for (int i = 0; i < alterationDicts.Count; i++)
            {
               db.Insert("Ticket_alterations", alterationDicts[i]);
            }
        }

        public void DeleteAndReinsertAlterations(TicketAlterationResource alterationResource, int ticketId)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            db.Delete("Ticket_alterations", "ticket_id = " + ticketId);

            List<Dictionary<String, object>> alterationDicts = ConvertAlterationsIntoDictionaries(alterationResource);
            for (int i = 0; i < alterationDicts.Count; i++)
            {
                db.Insert("Ticket_alterations", alterationDicts[i]);
            }
        }

        public TicketAlterationResource GetAlterationsByTicketId(int ticketId)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            String sql = "select * from Ticket_alterations where ticket_id = " + ticketId;
            DataTable alterationsTable = db.GetDataTable(sql);

            List<TicketAlterationResourceItem> alterationItems = new List<TicketAlterationResourceItem>();
            foreach (DataRow row in alterationsTable.Rows)
            {
            alterationItems.Add(new TicketAlterationResourceItem
                                    {
                                        Price = Convert.ToDouble(row["price"]),
                                        Quantity = Convert.ToInt32(row["quantity"]),
                                        Description = (String)row["description"],
                                        Taxable = Convert.ToInt32(row["taxable"])
                                    });
            }

            TicketAlterationResource alterationRes = TicketAlterationFactory.CreateTicketAlterationResource(alterationItems);
            return alterationRes;
        }

        public void DeleteAlterationsByTicketID(int ticketId)
        {
            SQLiteDatabase db = new SQLiteDatabase();
            db.Delete("Ticket_alterations", "ticket_id = " + ticketId);
        }

        private List<Dictionary<String, object>> ConvertAlterationsIntoDictionaries(TicketAlterationResource alterationsResource)
        {
            List<TicketAlterationResourceItem> alterations = alterationsResource.Alterations;
            List<Dictionary<String, object>> listOfDictArgs = new List<Dictionary<String, object>>();

            for (int i = 0; i < alterations.Count; i++)
            {
                Dictionary<String, object> dict = new Dictionary<string, object>();
                dict.Add("ticket_id", alterations[i].TicketId);
                dict.Add("price", alterations[i].Price);
                dict.Add("quantity", alterations[i].Quantity);
                dict.Add("description", alterations[i].Description);
                dict.Add("taxable", alterations[i].Taxable);

                listOfDictArgs.Add(dict);
            }
            return listOfDictArgs;
        }

    }
}
