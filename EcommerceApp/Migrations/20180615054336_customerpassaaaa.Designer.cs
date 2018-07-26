﻿// <auto-generated />
using EcommerceApp.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace EcommerceApp.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20180615054336_customerpassaaaa")]
    partial class customerpassaaaa
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("EcommerceApp.DatabaseContext.ApplicationRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("EcommerceApp.Models.CartItem", b =>
                {
                    b.Property<int>("CartId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("CustomerId");

                    b.Property<string>("CustomerId1");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("Quantity");

                    b.Property<decimal?>("UnitPrice");

                    b.HasKey("CartId");

                    b.HasIndex("CustomerId1");

                    b.HasIndex("ProductId");

                    b.ToTable("CartItem");
                });

            modelBuilder.Entity("EcommerceApp.Models.Category", b =>
                {
                    b.Property<int>("categoryId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("categoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("categoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("EcommerceApp.Models.Customer", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("Address1");

                    b.Property<string>("Address2");

                    b.Property<string>("City");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("CustomerName");

                    b.Property<DateTime?>("DateEntered");

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int>("PostalCode");

                    b.Property<string>("RoleName");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.Property<string>("password");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("EcommerceApp.Models.Order", b =>
                {
                    b.Property<int>("OrderId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CustomerId");

                    b.Property<string>("CustomerId1");

                    b.Property<DateTime?>("OrderDate");

                    b.Property<decimal>("OrderTotal");

                    b.HasKey("OrderId");

                    b.HasIndex("CustomerId1");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("EcommerceApp.Models.OrderLine", b =>
                {
                    b.Property<int>("OrderLineId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("OrderId");

                    b.Property<int?>("Price");

                    b.Property<int?>("ProductId");

                    b.Property<int?>("Quantity");

                    b.Property<int?>("UnitPrice");

                    b.HasKey("OrderLineId");

                    b.HasIndex("OrderId");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderLine");
                });

            modelBuilder.Entity("EcommerceApp.Models.Picture", b =>
                {
                    b.Property<int>("PictureId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("fileNamee");

                    b.Property<int?>("productId");

                    b.HasKey("PictureId");

                    b.HasIndex("productId");

                    b.ToTable("Picture");
                });

            modelBuilder.Entity("EcommerceApp.Models.Product", b =>
                {
                    b.Property<int>("productId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CartId");

                    b.Property<int?>("CategoryId");

                    b.Property<int>("OrderLineId");

                    b.Property<int?>("PictureId");

                    b.Property<string>("productDetails")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.Property<byte[]>("productImagePath");

                    b.Property<string>("productName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<decimal>("unitPrice");

                    b.Property<int?>("unitsInStock");

                    b.HasKey("productId");

                    b.HasIndex("CategoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("EcommerceApp.Models.SubCategory", b =>
                {
                    b.Property<int>("SubCatId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("categoryId");

                    b.Property<string>("subCategoryName")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("SubCatId");

                    b.HasIndex("categoryId");

                    b.ToTable("SubCategory");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("EcommerceApp.Models.CartItem", b =>
                {
                    b.HasOne("EcommerceApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1");

                    b.HasOne("EcommerceApp.Models.Product", "Product")
                        .WithMany("CartItems")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("EcommerceApp.Models.Order", b =>
                {
                    b.HasOne("EcommerceApp.Models.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId1");
                });

            modelBuilder.Entity("EcommerceApp.Models.OrderLine", b =>
                {
                    b.HasOne("EcommerceApp.Models.Order", "Order")
                        .WithMany("OrderLines")
                        .HasForeignKey("OrderId");

                    b.HasOne("EcommerceApp.Models.Product", "Product")
                        .WithMany("OrderLines")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("EcommerceApp.Models.Picture", b =>
                {
                    b.HasOne("EcommerceApp.Models.Product", "Product")
                        .WithMany("Pictures")
                        .HasForeignKey("productId");
                });

            modelBuilder.Entity("EcommerceApp.Models.Product", b =>
                {
                    b.HasOne("EcommerceApp.Models.Category", "Category")
                        .WithMany("Products")
                        .HasForeignKey("CategoryId");
                });

            modelBuilder.Entity("EcommerceApp.Models.SubCategory", b =>
                {
                    b.HasOne("EcommerceApp.Models.Category", "Category")
                        .WithMany("SubCategories")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("EcommerceApp.DatabaseContext.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("EcommerceApp.Models.Customer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("EcommerceApp.Models.Customer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("EcommerceApp.DatabaseContext.ApplicationRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("EcommerceApp.Models.Customer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("EcommerceApp.Models.Customer")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
