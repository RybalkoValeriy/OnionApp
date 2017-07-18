using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace Data
{
    class RepositoryTransaction : ITransactionRepositor
    {
        MyContext context;
        public RepositoryTransaction()
        {
            context = new MyContext();
        }

        public IEnumerable<Transaction> GetAll()
        {
            return context.DbSetTransaction;
        }
    }
}
