using System;
using System.Collections.Generic;
using BusinessInterfaces;
using CoreEntities;
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
                    Count = item.Count,
                    CarId = item.Car.Id
                };
                uofw.RepositoryTransaction.CreateEntity(transaction);
            }
            try
            {
                uofw.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
