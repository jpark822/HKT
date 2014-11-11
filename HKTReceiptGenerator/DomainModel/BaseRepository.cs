using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public abstract class BaseRepository
    {
        public static string ConvertDateTimeToUTCString(DateTime? dateTime)
        {
            if (dateTime == null)
            {
                return null;
            }
            
            return ((DateTime)dateTime).ToString("yyyy-MM-dd HH:mm:ss");
        }
    }
}
