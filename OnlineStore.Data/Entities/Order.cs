using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineStore.Data
{
    public class Order
    {
        [Key]
        public long Id { get; set; }
        public long CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
