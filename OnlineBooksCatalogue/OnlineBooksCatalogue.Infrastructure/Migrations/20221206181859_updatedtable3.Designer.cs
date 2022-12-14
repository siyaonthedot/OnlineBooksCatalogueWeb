// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OnlineBooksCatalogue.Infrastructure;

#nullable disable

namespace OnlineBooksCatalogue.Infrastructure.Migrations
{
    [DbContext(typeof(OBCDbContext))]
    [Migration("20221206181859_updatedtable3")]
    partial class updatedtable3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("OnlineBooksCatalogue.Core.Models.Book", b =>
                {
                    b.Property<int>("BookId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookId"), 1L, 1);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("PurchasePrice")
                        .HasColumnType("float");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BookId");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("OnlineBooksCatalogue.Core.Models.Catalogue", b =>
                {
                    b.Property<int>("CatalogueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CatalogueId"), 1L, 1);

                    b.Property<int?>("BooksBookId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CatalogueId");

                    b.HasIndex("BooksBookId");

                    b.ToTable("Catalogues");
                });

            modelBuilder.Entity("OnlineBooksCatalogue.Core.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SubscriptionId"), 1L, 1);

                    b.Property<int?>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("BookId");

                    b.HasIndex("UserId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("OnlineBooksCatalogue.Core.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("EmailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("OnlineBooksCatalogue.Core.Models.Catalogue", b =>
                {
                    b.HasOne("OnlineBooksCatalogue.Core.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BooksBookId");

                    b.Navigation("Books");
                });

            modelBuilder.Entity("OnlineBooksCatalogue.Core.Models.Subscription", b =>
                {
                    b.HasOne("OnlineBooksCatalogue.Core.Models.Book", "Books")
                        .WithMany()
                        .HasForeignKey("BookId");

                    b.HasOne("OnlineBooksCatalogue.Core.Models.User", "Users")
                        .WithMany()
                        .HasForeignKey("UserId");

                    b.Navigation("Books");

                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
