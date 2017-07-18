using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessInterfaces;
using CoreEntities;
using Data;

namespace BusinessLogic
{
    public class OrderCar : IOrderProducts
    {
        public void ToOrder(Buyer buyer, IEnumerable<Basket> basket)
        {
            MyContext context = new MyContext();
            context.DbSetBuyer.Add(buyer);
            foreach (var item in basket)
            {
                Transaction tr = new Transaction()
                {
                    Buyer = buyer,
                    Date = DateTime.UtcNow,
                    SessionID = item.guidSessinoID,
                    Products = item.car,
                    Count=item.Count
                };

                try
                {
                    context.DbSetTransaction.Add(tr);
                    context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
