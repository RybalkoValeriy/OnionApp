using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessInterfaces;
using CoreEntities;
using Data;
using IRepositories;

namespace BusinessLogic
{
    public class OrderCar : IOrderProducts
    {
        public void ToOrder(Buyer buyer, IEnumerable<Basket> basket, IUofW uofw)
        {
            uofw.RepositoryBuyer.CreateEntity(buyer);
            foreach (var item in basket)
            {
                Transaction transaction = new Transaction()
                {
                    Buyer = buyer,
                    Date = DateTime.UtcNow,
                    SessionId = item.SessionID,
                    Count = item.Count,
                    Car=item.Car
                };
                try
                {
                    item.Car.Transaction.Add(transaction);
                    uofw.RepositoryCar.CreateEntity(item.Car);
                    uofw.Save();
                }
                catch (Exception)
                {
                    throw;
                }
            }
        }
    }
}
