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
                    Car = item.Car,
                    Count = item.Count
                };

                try
                {
                    uofw.RepositoryTransaction.CreateEntity(transaction);
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
