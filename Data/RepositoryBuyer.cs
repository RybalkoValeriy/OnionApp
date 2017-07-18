using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace Data
{
    class RepositoryBuyer:IBuyerRepositor
    {
        public MyContext context;

        public RepositoryBuyer()
        {
            context = new MyContext();
        }

        IEnumerable<Buyer> IBuyerRepositor.GetAll()
        {
            return context.DbSetBuyer;
        }
    }
}
