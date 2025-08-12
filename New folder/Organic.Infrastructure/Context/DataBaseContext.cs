using Microsoft.EntityFrameworkCore;
using Organic.Domain.Model.Address;
using Organic.Domain.Model.Discount;
using Organic.Domain.Model.Message;
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
        public DbSet<ProductModel> ProductModel { get; set; }
        public DbSet<ProductCategoryModel> ProductCategoryModel { get; set; }
        public DbSet<ProductImageModel> ProductImages { get; set; }
        public DbSet<OrderItemModel> orderItemModels { get; set; }
        public DbSet<OrderModel> OrderModels { get; set; }
        public DbSet<DiscountModel> discountModels { get; set; }
        public DbSet<AddressModel> addressModels { get; set; }
        public DbSet<MessageModel> massegeModels { get; set; }
        public DbSet<Point_of_viewModel> point_Of_Views { get; set; }
        public DbSet<FavoriteslistModel> favoriteslistModels { get; set; }



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

            modelBuilder.Entity<MessageModel>(entity => 
            {
                entity.Property(x => x.FullName).IsRequired().HasMaxLength(50);
                entity.Property(x => x.Email).IsRequired();
                entity.Property(x => x.Title).IsRequired().HasMaxLength(50);
                entity.Property(x => x.Description).IsRequired().HasMaxLength(100);
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

            modelBuilder.Entity<Basket>()
                .HasMany(b => b.basketItemModels)
                .WithOne(i => i.Basket)
                .HasForeignKey(i => i.BasketId);

            modelBuilder.Entity<UserModel>()
                .HasMany(b => b.Addresses)
                .WithOne(i => i.User)
                .HasForeignKey(i => i.UserId);
        }
    }
}
