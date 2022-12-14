// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using _01_AssignmentDbWpf.Context;

#nullable disable

namespace _01AssignmentDbWpf.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20221201200626_worthless")]
    partial class worthless
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("_01_AssignmentDbWpf.Models.Entities.CustomerEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("_01_AssignmentDbWpf.Models.Entities.OrderEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CustomerId")
                        .HasColumnType("int");

                    b.Property<int?>("CustomersId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("TotalCost")
                        .HasColumnType("money");

                    b.HasKey("Id");

                    b.HasIndex("CustomersId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("_01_AssignmentDbWpf.Models.Entities.ProductEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("OrdersId")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("money");

                    b.Property<string>("ProductName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("OrdersId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("_01_AssignmentDbWpf.Models.Entities.OrderEntity", b =>
                {
                    b.HasOne("_01_AssignmentDbWpf.Models.Entities.CustomerEntity", "Customers")
                        .WithMany("Orders")
                        .HasForeignKey("CustomersId");

                    b.Navigation("Customers");
                });

            modelBuilder.Entity("_01_AssignmentDbWpf.Models.Entities.ProductEntity", b =>
                {
                    b.HasOne("_01_AssignmentDbWpf.Models.Entities.OrderEntity", "Orders")
                        .WithMany()
                        .HasForeignKey("OrdersId");

                    b.Navigation("Orders");
                });

            modelBuilder.Entity("_01_AssignmentDbWpf.Models.Entities.CustomerEntity", b =>
                {
                    b.Navigation("Orders");
                });
#pragma warning restore 612, 618
        }
    }
}
