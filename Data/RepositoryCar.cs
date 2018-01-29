using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;
using IRepositories;

namespace Data
{
    public class RepositoryCar : IRepository<Car>
    {
        public MyContext Context;

        public RepositoryCar(MyContext newContext)
        {
            Context = newContext;
        }

        public Car FindOne(dynamic id)
        {
            Car car = Context.DbSetCar.Find(id);
            return car; 
        }

        public IEnumerable<Car> GetAll()
        {
            return Context.DbSetCar;
        }

        public void CreateEntity(Car car)
        {
            Context.DbSetCar.Add(car);
        }

    }

    

}
