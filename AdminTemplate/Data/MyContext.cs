using AdminTemplate.Models.Entities;
using AdminTemplate.Models.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AdminTemplate.Data
{
    public sealed class MyContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
    {
        public MyContext(DbContextOptions options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>(entity =>
            {
                entity.Property(x => x.Name).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.Surname).HasMaxLength(50).IsRequired(false);
                entity.Property(x => x.RegisterDate).HasColumnType("datetime");
            });

            builder.Entity<ApplicationRole>(entity =>
            {
                entity.Property(x => x.Description).HasMaxLength(120).IsRequired(false);
            });

            builder.Entity<Category>(entity =>
            {
                entity.HasIndex(x => x.Id);
                entity.HasMany(x => x.Products)
                    .WithOne(x => x.Category)
                    .HasForeignKey(x => x.Category.Id);
                entity.Property(x => x.Name).IsRequired().HasMaxLength(50);
                entity.Property(x => x.Description).IsRequired(false).HasMaxLength(250);
            });
        }
    }
}
