using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;


namespace Data
{
    public class UofW : IUofW, IDisposable
    {
        MyContext db = new MyContext();
        RepositoryCar repoCar;
        RepositoryBuyer repoBuyer;
        RepositoryTransaction repoTrans;


        public IRepository<Car> repositoryCar
        {
            get
            {
                if (repoCar == null)
                    repoCar = new RepositoryCar(db);
                return repoCar;

            }
        }

        public IRepository<Buyer> repositoryBuyer
        {
            get
            {
                if (repoBuyer == null)
                    repoBuyer = new RepositoryBuyer(db);
                return repoBuyer;
            }
        }


        public IRepository<Transaction> repositoryTransaction
        {
            get
            {
                if (repoTrans == null)
                    repoTrans = new RepositoryTransaction(db);
                return repoTrans;
            }
        }


        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
