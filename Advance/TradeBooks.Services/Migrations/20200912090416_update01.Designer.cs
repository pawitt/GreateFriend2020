﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TradeBooks.Services;

namespace TradeBooks.Services.Migrations
{
    [DbContext(typeof(AppDb))]
    [Migration("20200912090416_update01")]
    partial class update01
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TradeBooks.Models.Fund", b =>
                {
                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<decimal>("NAV")
                        .HasColumnType("decimal(18, 4)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Code");

                    b.ToTable("Funds");
                });

            modelBuilder.Entity("TradeBooks.Models.Subscription", b =>
                {
                    b.Property<int>("SubscriptionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal?>("AllocNAV")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("AllocUnits")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("DateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("FundCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OwnerUnitHolderId")
                        .IsRequired()
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("SubscriptionId");

                    b.HasIndex("FundCode");

                    b.HasIndex("OwnerUnitHolderId");

                    b.ToTable("Subscriptions");
                });

            modelBuilder.Entity("TradeBooks.Models.UnitHolder", b =>
                {
                    b.Property<string>("UnitHolderId")
                        .HasColumnType("nchar(12)")
                        .IsFixedLength(true)
                        .HasMaxLength(12);

                    b.Property<DateTime>("CreatedDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(20)")
                        .HasMaxLength(20);

                    b.Property<DateTime?>("LastLoginDateUtc")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UnitHolderId");

                    b.ToTable("UnitHolders");
                });

            modelBuilder.Entity("TradeBooks.Models.Subscription", b =>
                {
                    b.HasOne("TradeBooks.Models.Fund", "Fund")
                        .WithMany()
                        .HasForeignKey("FundCode")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TradeBooks.Models.UnitHolder", "Owner")
                        .WithMany("Subscriptions")
                        .HasForeignKey("OwnerUnitHolderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
