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
        IRepository<Car> RepositoryCar { get; set; }
        IRepository<Transaction> RepositoryTransaction { get; set; }
        IRepository<Buyer> RepositoryBuyer { get; set; }
        void Save();
    }
}
