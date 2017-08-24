using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace Data
{
    public class RepositoryTransaction : IRepository<Transaction>
    {
        public MyContext context;

        public RepositoryTransaction(MyContext newcontext)
        {
            context = newcontext;
        }

        public Transaction FindOne(dynamic id)
        {
            Transaction transaction = context.DbSetTransaction.Find(id);
            return transaction;
        }

        public IEnumerable<Transaction> GetAll()
        {
            return context.DbSetTransaction;
        }

        public void CreateEntity(Transaction transaction)
        {
            context.DbSetTransaction.Add(transaction);
        }
    }
}
