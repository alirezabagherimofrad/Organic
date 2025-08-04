using Microsoft.EntityFrameworkCore;
using Organic.Domain.Model.Order;
using Organic.Domain.Model.Product;
using Organic.Domain.Model.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Organic.Infrastructure.Context
{
    public class DataBaseContext : DbContext
    {
        public DataBaseContext() { }

        public DataBaseContext(DbContextOptions<DataBaseContext> options) : base(options)
        {

        }

        public DbSet<UserModel> User { get; set; }
        public DbSet<UserImageModel> UserImage { get; set; }
        public DbSet<Basket> baskets { get; set; }
        public DbSet<BasketItemModel> basketItemModels { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.First_Name).IsRequired().HasMaxLength(50);
                entity.Property(x => x.Last_Name).IsRequired().HasMaxLength(50);
                entity.Property(x => x.Email).IsRequired().HasMaxLength(60);
                entity.Property(x => x.Password).IsRequired().HasMaxLength(30);
                entity.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
            });

            modelBuilder.Entity<UserImageModel>()
                    .HasOne(ui => ui.User)
                    .WithOne(u => u.Image)
                    .HasForeignKey<UserImageModel>(ui => ui.UserId);

            modelBuilder.Entity<ProductImageModel>()
                .HasOne(ui => ui.Product)
                .WithMany(u => u.ProductImages)
                .HasForeignKey(ui => ui.ProductId);


            modelBuilder.Entity<ProductModel>()
                .HasOne(ui => ui.ProductCategory)
                .WithMany(u => u.Products)
                .HasForeignKey(ui => ui.CatrgoryId);

            modelBuilder.Entity<OrderItemModel>()
                .HasOne(oi => oi.Order)
                .WithMany(o => o.OrderItems)
                .HasForeignKey(oi => oi.OrderId);
        }
    }
}
