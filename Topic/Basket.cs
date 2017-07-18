using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreEntities
{
    public class Basket
    {
        public string guidSessinoID { get; set; }
        public Car car { get; set; }
        public int Count { get; set; }
    }
}
