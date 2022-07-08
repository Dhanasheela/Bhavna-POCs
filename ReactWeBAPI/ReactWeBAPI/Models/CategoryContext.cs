using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.CodeAnalysis;


namespace ReactWeBAPI.CommonLayer.Model
{
    public class CategoryContext: DbContext
    {
        public CategoryContext()
        {
        }

        public CategoryContext(DbContextOptions<CategoryContext> options)
                : base(options)
            {
            }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }

        public DbSet<RegisterModel> RegisterModel { get; set; }

        public DbSet<ShoppingDetails> shoppingdetails { get; set; }
        //public DbSet<AllProductModel> allProductModels { get; set; }


    }

}
