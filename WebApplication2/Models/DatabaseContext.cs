using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication2.Models
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(

                new Country
                {
                    Id = 1,
                    Name = "India",
                    ShortName = "IN"

                },

                 new Country
                 {
                     Id = 2,
                     Name = "SriLanka",
                     ShortName = "SL"

                 },

                  new Country
                  {
                      Id = 3,
                      Name = "SouthAfrica",
                      ShortName = "SA"

                  }


                );

            modelBuilder.Entity<Hotel>().HasData(

               new Hotel
               {
                   Id = 1,
                   Name = "Taj Hotel",
                   Address="Mumbai",
                   CountryId=1,
                   Rating=5

               },

                new Hotel
                {
                    Id = 2,
                    Name = "Hotel Sri lanka",
                    Address = "XYZ",
                    CountryId = 2,
                    Rating = 3
                },

                 new Hotel
                 {
                     Id = 3,
                     Name = "Hotel South Africa",
                     Address = "Jamaica",
                     CountryId = 3,
                     Rating = 4

                 }
             );;



        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

    }
}
