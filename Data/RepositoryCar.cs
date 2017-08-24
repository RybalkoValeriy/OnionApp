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
        public MyContext context;

        public RepositoryCar(MyContext newcontext)
        {
            context = newcontext;
        }

        public Car FindOne(dynamic id)
        {
            Car car = context.DbSetCar.Find(id);
            return car; 
        }

        public IEnumerable<Car> GetAll()
        {
            return context.DbSetCar;
        }

        public void CreateEntity(Car car)
        {
            context.DbSetCar.Add(car);
        }

    }

    

}
