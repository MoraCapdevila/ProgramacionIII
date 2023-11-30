﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProgramacionIII.Data.Context;

#nullable disable

namespace ProgramacionIII.Migrations
{
    [DbContext(typeof(EcommerceContext))]
    partial class EcommerceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.13");

            modelBuilder.Entity("ProgramacionIII.Data.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Blanca",
                            Name = "Remera",
                            Price = 2000f
                        },
                        new
                        {
                            Id = 2,
                            Description = "Negro",
                            Name = "Pantalon",
                            Price = 5000f
                        });
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.SaleOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CustomerId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("SaleOrders");
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.SaleOrderLine", b =>
                {
                    b.Property<int>("SaleOrderLineId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductQuantity")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SaleOrderId")
                        .HasColumnType("INTEGER");

                    b.Property<float>("TotalPrice")
                        .HasColumnType("REAL");

                    b.HasKey("SaleOrderLineId");

                    b.HasIndex("ProductId");

                    b.HasIndex("SaleOrderId");

                    b.ToTable("SaleOrderLines");
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("LastName")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("UserType")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("UserType").HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.Admin", b =>
                {
                    b.HasBaseType("ProgramacionIII.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Admin");

                    b.HasData(
                        new
                        {
                            Id = 3,
                            Email = "morcapdevila457@gmail.com",
                            LastName = "Capdevila",
                            Name = "Mora",
                            Password = "12345678",
                            UserName = "moracapde"
                        },
                        new
                        {
                            Id = 4,
                            Email = "perezjuan@gmail.com",
                            LastName = "Perez",
                            Name = "Juan",
                            Password = "123456789",
                            UserName = "perez.juan"
                        });
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.Customer", b =>
                {
                    b.HasBaseType("ProgramacionIII.Data.Entities.User");

                    b.HasDiscriminator().HasValue("Customer");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "juanitasan@gmail.com",
                            LastName = "Sanchez",
                            Name = "Juana",
                            Password = "123456",
                            UserName = "juana_san"
                        },
                        new
                        {
                            Id = 2,
                            Email = "lopeztomas@gmail.com",
                            LastName = "Lopez",
                            Name = "Tomas",
                            Password = "1234567",
                            UserName = "tomi_lopez"
                        });
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.SaleOrder", b =>
                {
                    b.HasOne("ProgramacionIII.Data.Entities.Customer", "Customer")
                        .WithMany("SaleOrders")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.SaleOrderLine", b =>
                {
                    b.HasOne("ProgramacionIII.Data.Entities.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProgramacionIII.Data.Entities.SaleOrder", "SaleOrder")
                        .WithMany("SaleOrderLines")
                        .HasForeignKey("SaleOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("SaleOrder");
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.SaleOrder", b =>
                {
                    b.Navigation("SaleOrderLines");
                });

            modelBuilder.Entity("ProgramacionIII.Data.Entities.Customer", b =>
                {
                    b.Navigation("SaleOrders");
                });
#pragma warning restore 612, 618
        }
    }
}
