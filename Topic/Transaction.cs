using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public int Count { get; set; }
        public DateTime DateTransaction { get; set; }

        public int BuyerId { get; set; }
        public virtual Buyer Buyer { get; set; }
        public int CarId { get; set; }
        public virtual Car Car { get; set; }

        public Transaction()
        {
            Id = Guid.NewGuid();
            DateTransaction = DateTime.UtcNow;
        }
    }
}
