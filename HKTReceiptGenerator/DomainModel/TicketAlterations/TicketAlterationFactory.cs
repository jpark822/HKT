using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel.TicketAlterations
{
    public class TicketAlterationFactory
    {
        //raise domain event (AlterationResourceCreated) and run validations on created objects
        public static TicketAlterationResource CreateTicketAlterationResource(List<TicketAlterationResourceItem> alterations)
        {
            TicketAlterationResource alterationResource = new TicketAlterationResource
            {
                Alterations = alterations
            };
            return alterationResource;
        }
    }
}
