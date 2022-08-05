﻿using Microsoft.EntityFrameworkCore;
using Resto.API.Products.Models;

namespace Resto.API.Products.Database
{
	public class ProductsContext : DbContext
	{
		public ProductsContext(DbContextOptions<ProductsContext> options) : base(options)
		{

		}

        protected override void OnModelCreating(ModelBuilder builder)
        {

            var decimalProps = builder.Model
                                .GetEntityTypes()
                                .SelectMany(t => t.GetProperties())
                                .Where(p => (System.Nullable.GetUnderlyingType(p.ClrType) ?? p.ClrType) == typeof(decimal));

            foreach (var property in decimalProps)
            {
                property.SetPrecision(18);
                property.SetScale(2);
            }
        }

        public DbSet<Product> Products { get; set; }
	}
}
