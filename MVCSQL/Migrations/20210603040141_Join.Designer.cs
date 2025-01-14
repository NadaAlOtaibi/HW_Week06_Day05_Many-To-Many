﻿// <auto-generated />
using System;
using MVCSQL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVCSQL.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20210603040141_Join")]
    partial class Join
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("MVCSQL.Models.BranchModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Area")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Branches");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Riyadh",
                            Area = 1,
                            Name = "Br1"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Makkah",
                            Area = 12,
                            Name = "Br2"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Jeddah",
                            Area = 3,
                            Name = "Br3"
                        },
                        new
                        {
                            Id = 4,
                            Address = "Dammam",
                            Area = 8,
                            Name = "Br4"
                        },
                        new
                        {
                            Id = 5,
                            Address = "Riyadh",
                            Area = 9,
                            Name = "Br5"
                        });
                });

            modelBuilder.Entity("MVCSQL.Models.CouponCustomer", b =>
                {
                    b.Property<int>("CouponId")
                        .HasColumnType("int");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.HasKey("CouponId", "CustomerId");

                    b.HasIndex("CustomerId");

                    b.ToTable("CouponCustomer");
                });

            modelBuilder.Entity("MVCSQL.Models.CouponModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CodeSale")
                        .HasColumnType("text");

                    b.Property<DateTime>("Expiry")
                        .HasColumnType("datetime");

                    b.HasKey("Id");

                    b.ToTable("Coupons");
                });

            modelBuilder.Entity("MVCSQL.Models.CustomerModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("varchar(15)")
                        .HasMaxLength(15);

                    b.HasKey("Id");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("MVCSQL.Models.ProductModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("BranchId")
                        .HasColumnType("int");

                    b.Property<string>("Color")
                        .HasColumnType("varchar(20)")
                        .HasMaxLength(20);

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<float>("Price")
                        .HasColumnType("float")
                        .HasMaxLength(20);

                    b.HasKey("Id");

                    b.HasIndex("BranchId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("MVCSQL.Models.ProfileModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<bool>("Active")
                        .HasColumnType("tinyint(1)");

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId")
                        .IsUnique();

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("MVCSQL.Models.CouponCustomer", b =>
                {
                    b.HasOne("MVCSQL.Models.CouponModel", "Coupon")
                        .WithMany("CouponCustomer")
                        .HasForeignKey("CouponId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MVCSQL.Models.CustomerModel", "Customer")
                        .WithMany("CouponCustomer")
                        .HasForeignKey("CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCSQL.Models.ProductModel", b =>
                {
                    b.HasOne("MVCSQL.Models.BranchModel", "Branch")
                        .WithMany("Products")
                        .HasForeignKey("BranchId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MVCSQL.Models.ProfileModel", b =>
                {
                    b.HasOne("MVCSQL.Models.CustomerModel", "Customer")
                        .WithOne("Profile")
                        .HasForeignKey("MVCSQL.Models.ProfileModel", "CustomerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
