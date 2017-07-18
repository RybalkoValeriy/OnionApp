using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace Data
{
    public class RepositoryCar : ICarRepository
    {
        private MyContext context; 

        public RepositoryCar()
        {
            context = new MyContext();
        }

        public Car GetOneCar(int id)
        {
            var r = context.DbSetCar.SingleOrDefault(x=>x.Id==id);
            return r;
        }

        IEnumerable<Car> ICarRepository.GetAll()
        {
            return context.DbSetCar;
        }



    }

    

}
