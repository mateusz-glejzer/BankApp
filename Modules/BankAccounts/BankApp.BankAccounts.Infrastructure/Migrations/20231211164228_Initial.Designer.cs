﻿// <auto-generated />
using System;
using BankApp.BankAccounts.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BankApp.BankAccounts.Infrastructure.Migrations
{
    [DbContext(typeof(AccountsDbContext))]
    [Migration("20231211164228_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("bankAccounts")
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("BankApp.BankAccounts.Domain.Accounts.Account", b =>
                {
                    b.Property<Guid>("AccountId")
                        .HasColumnType("uuid");

                    b.Property<int>("AccountState")
                        .HasColumnType("integer");

                    b.Property<int>("Currency")
                        .HasColumnType("integer");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("AccountId");

                    b.ToTable("Accounts", "bankAccounts");
                });

            modelBuilder.Entity("BankApp.BankAccounts.Infrastructure.Outbox.OutboxMessage", b =>
                {
                    b.Property<Guid>("MessageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Message")
                        .HasColumnType("text");

                    b.Property<string>("MessageType")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ProcessedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime>("SentAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("MessageId");

                    b.ToTable("OutboxMessages", "bankAccounts");
                });
#pragma warning restore 612, 618
        }
    }
}