using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Rs_Api.Models;

public partial class RsdbContext : DbContext
{
    public RsdbContext()
    {
    }

    public RsdbContext(DbContextOptions<RsdbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Allergy> Allergies { get; set; }

    public virtual DbSet<Basket> Baskets { get; set; }

    public virtual DbSet<Checkout> Checkouts { get; set; }

    public virtual DbSet<Clock> Clocks { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<Inventory> Inventories { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductContent> ProductContents { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<Task> Tasks { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        string? key = Environment.GetEnvironmentVariable("CUSTOMCONNSTR_DefaultConnection");
        if (key is null)
        {
            key = File.ReadAllText(@"C:\Users\admin\Desktop\Derby\WebTechnologies\AzureCloud\key.txt");
        }
        optionsBuilder.UseNpgsql(key);  
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Allergy>(entity =>
        {
            entity.HasKey(e => e.AllergyId).HasName("Allergy_pk");

            entity.ToTable("Allergy");

            entity.Property(e => e.AllergyId).HasDefaultValueSql("nextval('allergy_seq'::regclass)");
            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.ImageUrl).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Basket>(entity =>
        {
            entity.HasKey(e => e.BacketId).HasName("Basket_pk");

            entity.ToTable("Basket");

            entity.Property(e => e.BacketId).HasDefaultValueSql("nextval('basket_seq'::regclass)");
            entity.Property(e => e.CreateTime).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.Checkout).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.CheckoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Basket_Checkout_CheckoutId_fk");

            entity.HasOne(d => d.Product).WithMany(p => p.Baskets)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Basket_Product_ProductId_fk");
        });

        modelBuilder.Entity<Checkout>(entity =>
        {
            entity.HasKey(e => e.CheckoutId).HasName("Checkout_pk");

            entity.ToTable("Checkout");

            entity.Property(e => e.CheckoutId).HasDefaultValueSql("nextval('basket_seq'::regclass)");
            entity.Property(e => e.CreateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ModifyTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasColumnType("character varying");
            entity.Property(e => e.Type).HasColumnType("character varying");

            entity.HasOne(d => d.Customer).WithMany(p => p.Checkouts)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("Checkout_Customer_CustomerId_fk");
        });

        modelBuilder.Entity<Clock>(entity =>
        {
            entity.HasKey(e => e.ClockId).HasName("Clock_pk");

            entity.ToTable("Clock");

            entity.Property(e => e.ClockId).HasDefaultValueSql("nextval('clock_seq'::regclass)");
            entity.Property(e => e.ClockInTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ClockOutTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasColumnType("character varying");

            entity.HasOne(d => d.Staff).WithMany(p => p.Clocks)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Clock_Staff_StaffId_fk");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("Customer_pk");

            entity.ToTable("Customer");

            entity.Property(e => e.CustomerId).HasDefaultValueSql("nextval('customer_seq'::regclass)");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.CreateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FirstName).HasColumnType("character varying");
            entity.Property(e => e.LastName).HasColumnType("character varying");
            entity.Property(e => e.ModifyTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasColumnType("character varying");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.GuideId).HasName("Guide_pk");

            entity.ToTable("Guide");

            entity.Property(e => e.GuideId).HasDefaultValueSql("nextval('guide_seq'::regclass)");
            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.ImageUrl).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
        });

        modelBuilder.Entity<Inventory>(entity =>
        {
            entity.HasKey(e => e.InventoryId).HasName("Inventory_pk");

            entity.ToTable("Inventory");

            entity.Property(e => e.InventoryId).HasDefaultValueSql("nextval('inventory_seq'::regclass)");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.ExpireDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.ManufactureDate).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasColumnType("character varying");
            entity.Property(e => e.StockDate).HasColumnType("timestamp without time zone");

            entity.HasOne(d => d.ProductContent).WithMany(p => p.Inventories)
                .HasForeignKey(d => d.ProductContentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Inventory_Stock_StockId_fk");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("Payment_pk");

            entity.ToTable("Payment");

            entity.Property(e => e.PaymentId).HasDefaultValueSql("nextval('payment_seq'::regclass)");
            entity.Property(e => e.CreateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Type).HasColumnType("character varying");

            entity.HasOne(d => d.Checkout).WithMany(p => p.Payments)
                .HasForeignKey(d => d.CheckoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Checkout_CheckoutId_fk");

            entity.HasOne(d => d.Staff).WithMany(p => p.Payments)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Payment_Staff_StaffId_fk");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("Product_pk");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasDefaultValueSql("nextval('product_seq'::regclass)");
            entity.Property(e => e.Description).HasColumnType("character varying");
            entity.Property(e => e.Name).HasColumnType("character varying");
            entity.Property(e => e.Size).HasColumnType("character varying");
            entity.Property(e => e.Status).HasColumnType("character varying");

            entity.HasOne(d => d.Alergy).WithMany(p => p.Products)
                .HasForeignKey(d => d.AlergyId)
                .HasConstraintName("Product_Allergy_AllergyId_fk");

            entity.HasOne(d => d.Guide).WithMany(p => p.Products)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("Product_Guide_GuideId_fk");
        });

        modelBuilder.Entity<ProductContent>(entity =>
        {
            entity.HasKey(e => e.ProductContentId).HasName("ProductContent_pk");

            entity.ToTable("ProductContent");

            entity.Property(e => e.ProductContentId).HasDefaultValueSql("nextval('product_content_seq'::regclass)");
            entity.Property(e => e.Name).HasColumnType("character varying");

            entity.HasOne(d => d.Product).WithMany(p => p.ProductContents)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("ProductContent_Product_ProductId_fk");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("Staff_pk");

            entity.Property(e => e.StaffId).HasDefaultValueSql("nextval('staff_seq'::regclass)");
            entity.Property(e => e.Address).HasColumnType("character varying");
            entity.Property(e => e.Brpno)
                .HasColumnType("character varying")
                .HasColumnName("BRPNo");
            entity.Property(e => e.CreateTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.FirstName).HasColumnType("character varying");
            entity.Property(e => e.LastName).HasColumnType("character varying");
            entity.Property(e => e.Nino).HasColumnName("NINo");
            entity.Property(e => e.Status).HasColumnType("character varying");
        });

        modelBuilder.Entity<Task>(entity =>
        {
            entity.HasKey(e => e.TaskId).HasName("Task_pk");

            entity.ToTable("Task");

            entity.Property(e => e.TaskId).HasDefaultValueSql("nextval('task_seq'::regclass)");
            entity.Property(e => e.Comment).HasColumnType("character varying");
            entity.Property(e => e.EndTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.StartTime).HasColumnType("timestamp without time zone");
            entity.Property(e => e.Status).HasColumnType("character varying");
            entity.Property(e => e.Task1)
                .HasColumnType("character varying")
                .HasColumnName("Task");

            entity.HasOne(d => d.Checkout).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.CheckoutId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_Checkout_CheckoutId_fk");

            entity.HasOne(d => d.Staff).WithMany(p => p.Tasks)
                .HasForeignKey(d => d.StaffId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("Task_Staff_StaffId_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
