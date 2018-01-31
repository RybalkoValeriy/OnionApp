using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreEntities;

namespace Data
{
    class DatabaseCustomInitilize : CreateDatabaseIfNotExists<MyContext>
    {
        protected override void Seed(MyContext context)
        {
            var cars = new List<Car>
            {
                new Car
                {
                    Name="FERRARI F12 BERLINETTA",
                    Description="The F12berlinetta’s 200-bar, direct-injection 6262 cc 65° V12 delivers absolutely unprecedented performance for a naturally aspirated 12-cylinder engine in terms of both power and revs.",
                    Price=1000000.99M,
                    UrlImage="berlinetta.jpg"
                }
                ,
                new Car
                {
                    Name="FERRARI 488 GTB",
                    Description="The 488 GTB name marks a return to the classic Ferrari model designation with the 488 in its moniker indicating the engine''s unitary displacement, while the GTB stands for Gran Turismo Berlinetta. The new car not only delivers unparalleled performance, it also makes that extreme power exploitable and controllable to an unprecedented level even by less expert drivers.",
                    Price=1003320.89M,
                    UrlImage="main.resized.png"
                },
                new Car
                {
                    Name="FERRARI 458 SPIDER",
                    Description="The 458 Spider is the first car ever to combine a mid-rear engine with a retractable folding hard top that delivers both unprecedented in-cabin comfort when closed and unparalleled Spider performance.",
                    Price=2000200.00M,
                    UrlImage="slide.jpg"
                },
                new Car
                {
                    Name="FERRARI FF",
                    Description="A four-seater that utterly changes the whole GT sports car concept, hailing nothing short of a revolution in the automotive world.",
                    Price=202220.55M,
                    UrlImage="ff.jpg"
                },
                new Car
                {
                    Name="FERRARI CALIFORNIA T",
                    Description="THE FERRARI CALIFORNIA T EPITOMISES THE SUBLIME ELEGANCE, SPORTINESS, VERSATILITY AND EXCLUSIVITY THAT HAVE DISTINGUISHED EVERY CALIFORNIA MODEL SINCE THE 1950S. IT IS A CAR BRIMMING WITH INNOVATION THAT WILL MORE THAN MEET",
                    Price=100000.99M,
                    UrlImage="140211_California_D3_4ant_sx_basso_280_110.jpg"
                }
            };
            context.DbSetCar.AddRange(cars);
            context.SaveChanges();
        }
    }
}
