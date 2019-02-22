using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.AdonetLayer.Repositories
{
    public abstract class BaseRepository
    {
        protected string ConnectionString
        {
            get
            {
                return Properties.Settings.Default.PBConnectionString;
            }
        }
    }
}
