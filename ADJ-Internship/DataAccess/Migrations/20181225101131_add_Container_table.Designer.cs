﻿// <auto-generated />
using System;
using ADJ.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ADJ.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20181225101131_add_Container_table")]
    partial class add_Container_table
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADJ.DataModel.DeliveryTrack.DCBooking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<string>("BookingRef")
                        .HasMaxLength(12);

                    b.Property<string>("BookingTime")
                        .HasMaxLength(12);

                    b.Property<DateTime>("Created");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("DeliveryMethod")
                        .HasMaxLength(20);

                    b.Property<string>("Haulier")
                        .HasMaxLength(30);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("WareHouse")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("DCBookings");
                });

            modelBuilder.Entity("ADJ.DataModel.DeliveryTrack.DCBookingDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cartons");

                    b.Property<string>("Container")
                        .HasMaxLength(20);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<decimal>("Cube");

                    b.Property<int>("DCBookingId");

                    b.Property<int?>("DCConfirmationDetailId");

                    b.Property<string>("Item")
                        .HasMaxLength(50);

                    b.Property<string>("Line")
                        .HasMaxLength(30);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Quantity");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("DCBookingId");

                    b.HasIndex("DCConfirmationDetailId");

                    b.HasIndex("OrderId");

                    b.ToTable("DCBookingDetails");
                });

            modelBuilder.Entity("ADJ.DataModel.DeliveryTrack.DCConfirmation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<string>("DeliveryTime")
                        .HasMaxLength(12);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.ToTable("DCConfirmations");
                });

            modelBuilder.Entity("ADJ.DataModel.DeliveryTrack.DCConfirmationDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Cartons");

                    b.Property<string>("Container")
                        .HasMaxLength(20);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<int>("DCConfirmationId");

                    b.Property<string>("Item")
                        .HasMaxLength(50);

                    b.Property<string>("Line")
                        .HasMaxLength(30);

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<string>("Order")
                        .HasMaxLength(30);

                    b.Property<decimal>("Quantity");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("DCConfirmationId");

                    b.ToTable("DCConfirmationDetails");
                });

            modelBuilder.Entity("ADJ.DataModel.OrderTrack.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Buyer")
                        .HasMaxLength(30);

                    b.Property<string>("Company")
                        .HasMaxLength(30);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<int>("Currency");

                    b.Property<DateTime>("DeliveryDate");

                    b.Property<string>("Department")
                        .HasMaxLength(30);

                    b.Property<string>("Factory")
                        .HasMaxLength(30);

                    b.Property<DateTime>("LatestShipDate");

                    b.Property<string>("Mode");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<DateTime>("OrderDate");

                    b.Property<string>("OrderType")
                        .HasMaxLength(30);

                    b.Property<string>("Origin")
                        .IsRequired();

                    b.Property<string>("PONumber");

                    b.Property<decimal>("POQuantity");

                    b.Property<string>("PortOfDelivery")
                        .IsRequired();

                    b.Property<string>("PortOfLoading")
                        .IsRequired();

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Season");

                    b.Property<DateTime>("ShipDate");

                    b.Property<int>("Status");

                    b.Property<string>("Supplier")
                        .HasMaxLength(30);

                    b.Property<string>("Vendor")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("ADJ.DataModel.OrderTrack.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<float>("Cartons");

                    b.Property<string>("Colour")
                        .HasMaxLength(30);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<float>("Cube");

                    b.Property<string>("Description")
                        .HasMaxLength(255);

                    b.Property<string>("Item");

                    b.Property<string>("ItemNumber");

                    b.Property<float>("KGS");

                    b.Property<string>("Line");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<int>("OrderId");

                    b.Property<decimal>("Quantity");

                    b.Property<float>("RetailPrice");

                    b.Property<decimal>("ReviseQuantity");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Size")
                        .HasMaxLength(30);

                    b.Property<int>("Status");

                    b.Property<string>("Tariff");

                    b.Property<float>("UnitPrice");

                    b.Property<string>("Warehouse")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.ToTable("OrderDetails");
                });

            modelBuilder.Entity("ADJ.DataModel.OrderTrack.ProgressCheck", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Comments");

                    b.Property<bool>("Complete");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<decimal>("EstQtyToShip");

                    b.Property<DateTime>("InspectionDate");

                    b.Property<DateTime>("IntendedShipDate");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<bool>("OnSchedule");

                    b.Property<int>("OrderId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("OrderId")
                        .IsUnique();

                    b.ToTable("ProgressChecks");
                });

            modelBuilder.Entity("ADJ.DataModel.PurchaseOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Test");

                    b.HasKey("Id");

                    b.ToTable("PurchaseOrders");
                });

            modelBuilder.Entity("ADJ.DataModel.PurchaseOrderItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<int>("PurchaseOrderId");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Test");

                    b.HasKey("Id");

                    b.HasIndex("PurchaseOrderId");

                    b.ToTable("PurchaseOrderItems");
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.ArriveOfDespatch", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookingId");

                    b.Property<DateTime>("CTD");

                    b.Property<string>("Carrier");

                    b.Property<string>("Confirmed");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("DestinationPort");

                    b.Property<DateTime>("ETA");

                    b.Property<string>("Mode");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<string>("OriginPort");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Vessel");

                    b.Property<string>("Voyage");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("ArriveOfDepacths");
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.Booking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("BookingDate");

                    b.Property<string>("BookingType");

                    b.Property<string>("Carrier");

                    b.Property<float>("Cartons");

                    b.Property<string>("Consignee");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<float>("Cube");

                    b.Property<DateTime>("ETA");

                    b.Property<DateTime>("ETD");

                    b.Property<string>("Factory");

                    b.Property<string>("FreightTerms");

                    b.Property<decimal>("GrossWeight");

                    b.Property<string>("ItemNumber");

                    b.Property<string>("Line");

                    b.Property<string>("LoadingType");

                    b.Property<string>("Mode");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<string>("PONumber");

                    b.Property<string>("PackType");

                    b.Property<string>("PortOfDelivery");

                    b.Property<string>("PortOfLoading");

                    b.Property<decimal>("Quantity");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<Guid>("ShipmentID");

                    b.Property<int>("Status");

                    b.Property<string>("Vessel");

                    b.Property<string>("Voyage");

                    b.HasKey("Id");

                    b.ToTable("Bookings");
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.CA", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ArrivalDate");

                    b.Property<int>("BookingId");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.ToTable("CAs");
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.Container", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<string>("Loading");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<string>("Name");

                    b.Property<string>("PackType");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Size");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("Container");
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.Manifest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Bars");

                    b.Property<int>("BookingId");

                    b.Property<float>("Cartons");

                    b.Property<decimal>("ChargeableKGS");

                    b.Property<int>("ContainerId");

                    b.Property<string>("CreatedBy")
                        .IsRequired();

                    b.Property<DateTime>("CreatedDateUtc");

                    b.Property<float>("Cube");

                    b.Property<string>("Equipment");

                    b.Property<string>("FreightTerms");

                    b.Property<float>("KGS");

                    b.Property<string>("Loading");

                    b.Property<string>("ModifiedBy");

                    b.Property<DateTime?>("ModifiedDateUtc");

                    b.Property<decimal>("NetKGS");

                    b.Property<string>("PackType");

                    b.Property<decimal>("Quantity");

                    b.Property<byte[]>("RowVersion")
                        .IsConcurrencyToken()
                        .ValueGeneratedOnAddOrUpdate();

                    b.Property<string>("Seal");

                    b.Property<string>("Size");

                    b.HasKey("Id");

                    b.HasIndex("BookingId");

                    b.HasIndex("ContainerId");

                    b.ToTable("Manifests");
                });

            modelBuilder.Entity("ADJ.DataModel.DeliveryTrack.DCBookingDetail", b =>
                {
                    b.HasOne("ADJ.DataModel.DeliveryTrack.DCBooking", "DCBooking")
                        .WithMany("DCBookingDetails")
                        .HasForeignKey("DCBookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADJ.DataModel.DeliveryTrack.DCConfirmationDetail")
                        .WithMany("DCBookingDetails")
                        .HasForeignKey("DCConfirmationDetailId");

                    b.HasOne("ADJ.DataModel.OrderTrack.Order", "Order")
                        .WithMany()
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.DeliveryTrack.DCConfirmationDetail", b =>
                {
                    b.HasOne("ADJ.DataModel.DeliveryTrack.DCConfirmation", "DCConfirmation")
                        .WithMany()
                        .HasForeignKey("DCConfirmationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.OrderTrack.OrderDetail", b =>
                {
                    b.HasOne("ADJ.DataModel.OrderTrack.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.OrderTrack.ProgressCheck", b =>
                {
                    b.HasOne("ADJ.DataModel.OrderTrack.Order")
                        .WithOne("ProgressCheck")
                        .HasForeignKey("ADJ.DataModel.OrderTrack.ProgressCheck", "OrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.PurchaseOrderItem", b =>
                {
                    b.HasOne("ADJ.DataModel.PurchaseOrder", "PurchaseOrder")
                        .WithMany("Items")
                        .HasForeignKey("PurchaseOrderId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.ArriveOfDespatch", b =>
                {
                    b.HasOne("ADJ.DataModel.ShipmentTrack.Booking", "Booking")
                        .WithMany("ArriveOfDespatches")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.CA", b =>
                {
                    b.HasOne("ADJ.DataModel.ShipmentTrack.Booking", "Booking")
                        .WithMany("CAs")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ADJ.DataModel.ShipmentTrack.Manifest", b =>
                {
                    b.HasOne("ADJ.DataModel.ShipmentTrack.Booking", "Booking")
                        .WithMany("Manifests")
                        .HasForeignKey("BookingId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ADJ.DataModel.ShipmentTrack.Container", "Container")
                        .WithMany("Manifests")
                        .HasForeignKey("ContainerId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
