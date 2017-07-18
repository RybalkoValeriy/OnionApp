using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace IOrderProducts
{
    public interface IOrderProducts
    {
         void ToOrder(IEnumerable<Car> products, Buyer buyer);
    }
}
