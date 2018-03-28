﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using ProductsManager.Models.DAO;


namespace ProductsManager.DataAccess.Context
{
    public class DataContext : DbContext
    {

        private readonly DatabaseOptions _options;
        public DataContext() { }
        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        { }

        public DataContext(IOptions<DatabaseOptions> options)
        {
            _options = options.Value;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_options.ConnectionString);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }

    }
}