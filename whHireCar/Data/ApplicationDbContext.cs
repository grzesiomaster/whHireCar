﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using whHireCar.Models;

namespace whHireCar.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.Migrate();
            DataSeed();
        }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Hire> Hires { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }


        public void DataSeed()
        {
            var carCount = Cars.Count();
            var brandCount = Brands.Count();
            var customersCount = Customers.Count();
            var hireCount = Hires.Count();
				//if data doesn't exists
            if ( carCount == 0 && brandCount == 0 && customersCount == 0 && hireCount == 0)
            {
                var brands = new List<Brand>()
                {
                    new Brand()
                    {
                        Name = "Audi",
                    },
                    new Brand()
                    {
                        Name = "Mercedes"
                    },
                    new Brand()
                    {
                        Name = "BMW"
                    },
                    new Brand()
                    {
                        Name = "Vw"
                    }
                };
                var customers = new List<Customer>()
                {
                    new Customer()
                    {
                        Name = "Mickey",
                    },
                    new Customer()
                    {
                        Name = "Goffy",
                    },
                    new Customer()
                    {
                        Name = "Donald",
                    }
                };
                Brands.AddRange(brands);
                Customers.AddRange(customers);
                SaveChanges();
                
                var Mercedes = Brands.Where(x => x.Name == "Mercedes").FirstOrDefault();
                var BMW = Brands.Where(x => x.Name == "BMW").FirstOrDefault();
                var Audi = Brands.Where(x => x.Name == "Audi").FirstOrDefault();
                var Vw = Brands.Where(x => x.Name == "Vw").FirstOrDefault();

                var cars = new List<Car>()
                {
                    new Car()
                    {
                        Model = "W124 300D",
                        Number = "BIA 3242",
                        Brand = Mercedes
                    },
                    new Car()
                    {
                        Model = "W123 200D",
                        Number = "BIA 4891",
                        Brand = Mercedes
                    },
                    new Car()
                    {
                        Model = "e38 750iL",
                        Number = "BI 32442",
                        Brand = BMW
                    },
                    new Car()
                    {
                        Model = "TT 1.8T",
                        Number = "BI 4987",
                        Brand = Audi
                    },
                    new Car()
                    {
                        Model = "80 1.9TDI",
                        Number = "BSK 1892",
                        Brand = Audi
                    },
                    new Car()
                    {
                        Model = "Passat B5 1.9TDI",
                        Number = "BIA 96G6",
                        Brand = Vw
                    },
                    new Car()
                    {
                        Model = "Golf 4 1.4",
                        Number = "BIA 43446",
                        Brand = Vw
                    },
                    new Car()
                    {
                        Model = "Pasat B2 1.6D",
                        Number = "BIA 1997",
                        Brand = Vw
                    }
                };
                Cars.AddRange(cars);
                SaveChanges();
            }
        }
    }
}
