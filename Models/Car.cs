using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace Project.NET.Models
{
    public class Car
    {
        
        [Key, Column("car_id")]
        public int CarID { get; set; }
        [MinLength(1, ErrorMessage ="The length of the model name can't be less than 2"),
            MaxLength(30, ErrorMessage ="The length of the model name can't be more than 30")]
        public string ModelName { get; set; }
        public int Odometer { get; set; }
        public string Color { get; set; }
        public int YearProduction { get; set; }

    }

    public class DbCars: DbContext
    {
        public DbCars() : base("DbConnectionString")
        {
            // set initiliazer here 
            Database.SetInitializer<DbCars>(new CustomInit());
        }

        public class CustomInit : DropCreateDatabaseAlways<DbCars>
        {
            // class initializer 
            protected override void Seed(DbCars cars)
            {
                cars.Cars.Add(new Car
                {
                    ModelName = "Laguna",
                    Odometer = 200001,
                    Color = "Green",
                    YearProduction = 2001
                }
                );
                cars.Cars.Add(new Car
                {
                    ModelName = "Solenza",
                    Odometer = 300000,
                    Color = "Yellow",
                    YearProduction = 2005
                });

                cars.Cars.Add(new Car
                {
                    ModelName = "A6",
                    Odometer = 330000,
                    Color = "Silver",
                    YearProduction = 1998
                });

                cars.SaveChanges();
                base.Seed(cars);
            }
        }

        public DbSet<Car> Cars { get; set; }


    }
}