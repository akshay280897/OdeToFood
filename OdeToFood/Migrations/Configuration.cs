namespace OdeToFood.Migrations
{
    using Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<OdeToFood.Models.OdeToFoodDb>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            ContextKey = "OdeToFood.Models.OdeToFoodDb";
        }

        protected override void Seed(OdeToFood.Models.OdeToFoodDb context)
        {
            

            context.Restaurant.AddOrUpdate(
                r => r.Name,
                //new Restaurant { Name = "Durga Cafe", City = "Sangli", Country = "India" },
                //new Restaurant { Name = "D C", City = "Pune", Country = "India" },
                //new Restaurant
                //{
                //    Name = "Seasons",
                //    City = "Kolhapur",
                //    Country = "India",
                //    Reviews = new List<Reviews> {
                //        new Reviews { Body="Good Food",Rating=9,ReviewerName="akshay"},     
                //         new Reviews { Body="Good Food",Rating=9,ReviewerName="akshay3"}
                //    }

                //}

                new Restaurant
                {
                    Name = "test",
                    City = "Kolhapur",
                    Country = "India",
                    Reviews = new List<Reviews> {
                        new Reviews { Body="Good Food",Rating=9,ReviewerName="akshay"},
                         new Reviews { Body="Good Food",Rating=9,ReviewerName="akshay3"}
                    }

                }
                );
            for(int i=0;i<100;i++)
            { 
            context.Restaurant.AddOrUpdate(
                r=>r.Name,
                new Restaurant { Name = i.ToString(),City="Nowhere",Country="India"}
                
                );
            }
        }
    }
}
