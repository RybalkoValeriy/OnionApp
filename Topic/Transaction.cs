using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class Transaction
    {
        public int Id { get; set; }
        public Buyer Buyer { get; set; }
        public Car Products { get; set; }
        public int Count { get; set; }
        public DateTime Date { get; set; }
        public string SessionID { get; set; }
    }
}
