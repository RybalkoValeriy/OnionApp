using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;


namespace IRepositories
{
    public interface IUofW :IDisposable
    {
        IRepository<Car> repositoryCar { get; }
        IRepository<Transaction> repositoryTransaction { get; }
        IRepository<Buyer> repositoryBuyer { get; }
        void Save();
    }
}
