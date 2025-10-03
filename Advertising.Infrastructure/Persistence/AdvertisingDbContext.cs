using Advertising.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advertising.Infrastructure.Persistence
{
    public class AdvertisingDbContext:DbContext
    {
        public AdvertisingDbContext(DbContextOptions<AdvertisingDbContext> options) : base(options) { }

        public DbSet<Campaign> campaigns => Set<Campaign>();
        public DbSet<Banner> banners => Set<Banner>();
        public DbSet<CampaignLocation> campaignLocations => Set<CampaignLocation>();

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

            modelBuilder.Entity<CampaignLocation>(b =>
            {
                b.HasKey(x => x.Id);
            });

        }
    }
}
