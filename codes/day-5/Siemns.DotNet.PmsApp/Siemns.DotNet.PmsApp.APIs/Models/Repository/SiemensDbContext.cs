using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Siemns.DotNet.PmsApp.APIs.Models.Entities;

namespace Siemns.DotNet.PmsApp.APIs.Models.Repository
{
    public class SiemensDbContext : DbContext
    {
        public SiemensDbContext(DbContextOptions<SiemensDbContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=JOYDIP-PC\\SQLEXPRESS;database=siemensdb;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityTypeBuilder<Category> categoryBuilder = modelBuilder.Entity<Category>();

            categoryBuilder
                .ToTable("categories")
                .HasKey(c => c.CategoryId);

            categoryBuilder
                .Property<int>(c => c.CategoryId)
                .HasColumnName("category_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(100, 1)
                .IsRequired();

            categoryBuilder
                .Property<string>(c => c.CategoryName)
                .HasColumnType("varchar(50)")
                .HasColumnName("category_name")
                .IsRequired();

            var productBuilder = modelBuilder.Entity<Product>();
            productBuilder.ToTable("products")
                .HasKey(p => p.ProductId);

            productBuilder
                .Property<int>(p => p.ProductId)
                .HasColumnName("product_id")
                .HasColumnType("int")
                .ValueGeneratedOnAdd()
                .UseIdentityColumn(1000, 1)
                .IsRequired();

            productBuilder
                .Property<string>(p => p.ProductName)
                .HasColumnName("product_name")
                .HasColumnType("varchar(50)")
                .IsRequired();

            productBuilder
                .Property<decimal?>(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .HasColumnName("price")
                .IsRequired(false);

            productBuilder
                .Property<string?>(p => p.Description)
                .HasColumnName("product_desc")
                .HasColumnType("varchar(max)")
                .IsRequired(false);

            productBuilder
                .Property<int?>(p => p.CategoryId)
                .HasColumnType("int")
                .HasColumnName("category_id")
                .IsRequired(false);

            productBuilder
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

        }
    }
}
