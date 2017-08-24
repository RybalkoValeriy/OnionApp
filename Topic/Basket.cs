using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class Basket
    {
        public string SessionID { get; set; }
        public Car Car { get; set; }
        public int Count { get; set; }
    }
}
