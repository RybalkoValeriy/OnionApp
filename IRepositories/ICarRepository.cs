using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace IRepositories
{
    public interface ICarRepository
    {
        IEnumerable<Car> GetAll();
        Car GetOneCar(int id);
    }
}
