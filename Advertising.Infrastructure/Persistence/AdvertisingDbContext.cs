using Advertising.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Infrastructure.Persistence
{
    public class AdvertisingDbContext:IdentityDbContext<User,Role, Guid>
    {
        public AdvertisingDbContext(DbContextOptions<AdvertisingDbContext> options) : base(options) { }

        public DbSet<Campaign> Campaigns => Set<Campaign>();
        public DbSet<Banner> Banners => Set<Banner>();
        public DbSet<CampaignLocation> CampaignLocations => Set<CampaignLocation>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campaign>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(250).IsRequired();
                b.HasMany(x => x.Banners).WithOne().HasForeignKey(b => b.CampaignId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.Locations).WithOne().HasForeignKey(l => l.CampaignId).OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<Banner>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Url).IsRequired();
                b.Property(x => x.PublicId).IsRequired();
            });

            // LOCATION
            // -------------------------
            modelBuilder.Entity<Location>(b =>
            {
                b.HasKey(x => x.Id);

                b.Property(x => x.Name)
                    .HasMaxLength(150)
                    .IsRequired();

                b.Property(x => x.State)
                    .HasMaxLength(100)
                    .IsRequired();

                b.Property(x => x.Country)
                    .HasMaxLength(100)
                    .IsRequired();

                b.HasMany(x => x.Campaigns)
                    .WithOne()
                    .HasForeignKey(cl => cl.LocationId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            modelBuilder.Entity<CampaignLocation>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.DailyBudget)
                    .HasPrecision(18, 2)
                    .IsRequired();

                b.Property(x => x.TotalBudget)
                    .HasPrecision(18, 2)
                    .IsRequired();

                // Optionally: composite unique constraint (Campaign + Location)
                b.HasIndex(x => new { x.CampaignId, x.LocationId })
                    .IsUnique();
            });

        }
    }
}
