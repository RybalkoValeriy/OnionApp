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
        IRepository<Car> repoCar;
        IRepository<Buyer> repoBuyer;
        IRepository<Transaction> repoTrans;



        public IRepository<Car> RepositoryCar
        {
            get
            {
                if (repoCar == null)
                    repoCar = new RepositoryCar(db);
                return repoCar;
            }
            set
            {
                repoCar = value;
            }
        }

        public IRepository<Buyer> RepositoryBuyer
        {
            get
            {
                if (repoBuyer == null)
                    repoBuyer = new RepositoryBuyer(db);
                return repoBuyer;
            }
            set
            {
                repoBuyer = value;
            }
        }

        public IRepository<Transaction> RepositoryTransaction
        {
            get
            {
                if (repoTrans == null)
                    repoTrans = new RepositoryTransaction(db);
                return repoTrans;
            }
            set
            {
                repoTrans = value;
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
