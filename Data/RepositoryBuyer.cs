using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace Data
{
    public class RepositoryBuyer:IRepository<Buyer>
    {
        public MyContext context;

        public RepositoryBuyer(MyContext newcontext)
        {
            context = newcontext;
        }

        public void CreateEntity(Buyer buyer)
        {
            context.DbSetBuyer.Add(buyer);       
        }

        public Buyer FindOne(dynamic id)
        {
            Buyer buyer = context.DbSetBuyer.Find(id);
            return buyer;
        }

        public IEnumerable<Buyer> GetAll()
        {
            return context.DbSetBuyer;
        }
    }
}
