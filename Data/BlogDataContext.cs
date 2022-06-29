﻿using AspNet_Api_EfCore.Data.Mappings;
using AspNet_Api_EfCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspNet_Api_EfCore.Data
{
    public class BlogDataContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost,1433;Database=Blog;User ID=sa;Password=Futur@1313;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryMap());
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new PostMap());
        }

    }
}
