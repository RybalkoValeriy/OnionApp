using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace BusinessInterfaces
{
    public interface IOrderProducts
    {
         void ToOrder(Buyer buyer, IEnumerable<Basket> basket, IUofW uofw);
    }
}
