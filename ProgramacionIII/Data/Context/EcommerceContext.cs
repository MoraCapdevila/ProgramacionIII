﻿using Microsoft.EntityFrameworkCore;
using ProgramacionIII.Data.Entities;


namespace ProgramacionIII.Data.Context
{
    public class EcommerceContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<SaleOrderLine> SaleOrderLines { get; set; }

        public DbSet<Admin> Admin { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlite("Data Source=EcommerceContext.db");
        //}
        public EcommerceContext(DbContextOptions<EcommerceContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasDiscriminator(u => u.UserType);
            modelBuilder.Entity<Customer>().HasData(
                new Customer
                {
                    Id = 1,
                    Name = "Juana",
                    LastName = "Sanchez",
                    Email = "juanitasan@gmail.com",
                    Password = "123456",
                    UserName = "juana_san"
                },
                new Customer
                {
                    Id = 2,
                    Name = "Tomas",
                    LastName = "Lopez",
                    Email = "lopeztomas@gmail.com",
                    Password = "1234567",
                    UserName = "tomi_lopez"
                });
            modelBuilder.Entity<Admin>().HasData(
                new Admin
                {
                    Id = 3,
                    Name = "Mora",
                    LastName = "Capdevila",
                    Email = "morcapdevila457@gmail.com",
                    Password = "12345678",
                    UserName = "moracapde"
                },
                new Admin
                {
                    Id = 4,
                    Name = "Juan",
                    LastName = "Perez",
                    Email = "perezjuan@gmail.com",
                    Password = "123456789",
                    UserName = "perez.juan"
                });

            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "Remera",
                    Description = "Blanca",
                    Price = 2000
                },
                new Product
                {
                    Id = 2,
                    Name = "Pantalon",
                    Description = "Negro",
                    Price = 5000
                });

            //hay que establecer bien las relaciones y poder plantear las tablas

            base.OnModelCreating(modelBuilder);
        }


    }
}
