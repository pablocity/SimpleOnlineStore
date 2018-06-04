using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OnlineStore.Data;

namespace OnlineStore.Common
{
    public static class Utility
    {
        public static string QuantityString(this Product product)
        {
            int count = product.Quantity;

            if (count == 1)
                return $"{count} sztuka";
            else if (count < 5 && count != 0)
                return $"{count} sztuki";
            else
                return $"{count} sztuk";
        }
    }
}
