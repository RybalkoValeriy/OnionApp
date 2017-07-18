using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace IRepositories
{
    public interface IBuyerRepositor
    {
        IEnumerable<Buyer> GetAll();
    }
}
