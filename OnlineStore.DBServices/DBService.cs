using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Data;

namespace OnlineStore.DBServices
{
    public abstract class DBService
    {
        protected OnlineStoreContext DB = new OnlineStoreContext();
    }
}
