using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using CoreEntities;

namespace Data
{

    public class MyContext : DbContext
    {
        public MyContext() : base("myconn")
        {
            Database.SetInitializer<MyContext>(new DatabaseCustomInitilize());
        }

        public DbSet<Car> DbSetCar { get; set; }
        public DbSet<Buyer> DbSetBuyer { get; set; }
        public DbSet<Transaction> DbSetTransaction { get; set; }
    }
}
