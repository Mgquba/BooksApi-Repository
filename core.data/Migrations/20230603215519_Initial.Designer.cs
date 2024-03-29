﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using core.data.Context;

#nullable disable

namespace core.data.Migrations
{
    [DbContext(typeof(BookServiceContext))]
    [Migration("20230603215519_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("core.data.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("core.data.Entities.Book", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("AuthorName")
                        .HasColumnType("text");

                    b.Property<string>("CoverUrl")
                        .HasColumnType("text");

                    b.Property<DateTime?>("DateAdded")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<string>("Genre")
                        .HasColumnType("text");

                    b.Property<bool?>("IsRead")
                        .HasColumnType("boolean");

                    b.Property<Guid?>("PublisherId")
                        .HasColumnType("uuid");

                    b.Property<int?>("Rate")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasData(
                        new
                        {
                            Id = new Guid("ab87c0b1-2038-4b4e-a8ef-9f7399bfa06a")
                        },
                        new
                        {
                            Id = new Guid("f71f4168-b571-493f-b611-51b163b09835")
                        },
                        new
                        {
                            Id = new Guid("236807d4-2934-4066-8f1d-4d9e69ab5246")
                        },
                        new
                        {
                            Id = new Guid("3492cfd6-ca5b-4804-8866-4e4a259b735c"),
                            AuthorName = "JohnDoe",
                            CoverUrl = "RichDadPoorDad.png",
                            DateAdded = new DateTime(2023, 6, 3, 21, 55, 19, 168, DateTimeKind.Utc).AddTicks(8363),
                            DateRead = new DateTime(2023, 6, 3, 21, 55, 19, 168, DateTimeKind.Utc).AddTicks(8361),
                            Description = "Story of a rich and poor dad",
                            Genre = "Non-Fiction",
                            IsRead = true,
                            PublisherId = new Guid("6067d832-74b9-400a-ad79-8b57360ab375"),
                            Rate = 5,
                            Title = "Rich Dad Poor Dad"
                        });
                });

            modelBuilder.Entity("core.data.Entities.Book_Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("BookId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("Books_Authors");

                    b.HasData(
                        new
                        {
                            Id = new Guid("47f118a4-eedd-4272-9f07-4b2a2e5bee82"),
                            AuthorId = new Guid("458e616b-da29-4b9c-b98f-9af22661cee0"),
                            BookId = new Guid("426a6881-bd04-41fa-8460-f14b1ed6d3f2")
                        },
                        new
                        {
                            Id = new Guid("ebf80ff2-d547-4581-99d4-b4587ca46443"),
                            AuthorId = new Guid("effc238d-ec04-4537-894d-bd96087935d9"),
                            BookId = new Guid("6cddd0fc-1aa3-4ac7-bdf0-d52388e8efff")
                        });
                });

            modelBuilder.Entity("core.data.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Publishers");

                    b.HasData(
                        new
                        {
                            Id = new Guid("36022146-b10a-4d2b-bb2a-e434fe96ff16"),
                            FullName = "Mike Best"
                        },
                        new
                        {
                            Id = new Guid("d311092e-a78a-48b7-a8ea-76a766a84c44"),
                            FullName = "Maria Rose"
                        },
                        new
                        {
                            Id = new Guid("98a68d6c-c875-4f96-bba7-68a64cb493c4"),
                            FullName = "Chris John"
                        });
                });

            modelBuilder.Entity("core.data.Entities.Book", b =>
                {
                    b.HasOne("core.data.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("core.data.Entities.Book_Author", b =>
                {
                    b.HasOne("core.data.Entities.Author", "Author")
                        .WithMany("Book_Author")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("core.data.Entities.Book", "Book")
                        .WithMany("Book_Author")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("core.data.Entities.Author", b =>
                {
                    b.Navigation("Book_Author");
                });

            modelBuilder.Entity("core.data.Entities.Book", b =>
                {
                    b.Navigation("Book_Author");
                });

            modelBuilder.Entity("core.data.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
