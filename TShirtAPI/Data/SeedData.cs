using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TShirtAPI.Data;
using TShirtAPI.Models;

namespace ContosoPets.Api.Data
{
    public static class SeedData
    {
        public static void Initialize(TshirtContext context)
        {
            
            
            if (!context.TSHIRTS.Any())
            {
                context.TSHIRTS.AddRange(
                    new tshirt
                    {
                        Name = "Nike",
                        Gender = "Male",
                        
                        
                    },
                    new tshirt
                    {
                        Name = "Adidas",
                        Gender = "Female",

                    }
                );

                context.SaveChanges();
            }
        }
    }
}
