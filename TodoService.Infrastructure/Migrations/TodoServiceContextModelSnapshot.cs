﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TodoService.Infrastructure;

namespace TodoService.Infrastructure.Migrations
{
    [DbContext(typeof(TodoServiceContext))]
    partial class TodoServiceContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TodoService.Infrastructure.Entities.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("TodoService.Infrastructure.Entities.Table", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AccountId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Tables");
                });

            modelBuilder.Entity("TodoService.Infrastructure.Entities.TableTask", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("EditDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("TableId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TableTasks");
                });
#pragma warning restore 612, 618
        }
    }
}
