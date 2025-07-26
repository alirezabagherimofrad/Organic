using Microsoft.EntityFrameworkCore;
using Organic.Domain.Model;
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

        public DbSet<UserModel> userModels { get; set; }
        public DbSet<UserImageModel> uploadeUserPicthers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserModel>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(50);
                entity.Property(x => x.Email).IsRequired().HasMaxLength(60);
                entity.Property(x => x.Password).IsRequired().HasMaxLength(10);
                entity.Property(x => x.NationalCode).IsRequired().HasMaxLength(10);
                entity.Property(x => x.PhoneNumber).IsRequired().HasMaxLength(11);
                modelBuilder.Entity<UserImageModel>()
                    .HasOne(ui => ui.User) 
                    .WithOne(u => u.Image) 
                    .HasForeignKey<UserImageModel>(ui => ui.UserId);

            });

        }
    }
}
