using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook.DapperLayer.Repositories
{
    public abstract class BaseDapperRepository
    {
        protected string ConnectionString
        {
            get
            {
                return Properties.Settings.Default.PBPhonebook;
            }
        }
    }
}
