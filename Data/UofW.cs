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

        private bool isDisposeState = false;

        private void IsDisposable(bool state)
        {
            if (!isDisposeState)
            {
                if (state)
                {
                    db.Dispose();
                }
            }
            isDisposeState = true;
        }

        public void Dispose()
        {
            IsDisposable(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
