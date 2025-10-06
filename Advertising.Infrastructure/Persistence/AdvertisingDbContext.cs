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
        public DbSet<Location> Locations => Set<Location>();
        public DbSet<Status> Statuses => Set<Status>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Campaign>(b =>
            {
                b.HasKey(x => x.Id);
                b.Property(x => x.Name).HasMaxLength(250).IsRequired();
                // This preserves existing numeric values from the old enum column.
                b.Property(x => x.StatusId)
                 .HasColumnName("Status")
                 .IsRequired()
                 .HasDefaultValue(0);

                // set up FK to Status table and restrict delete (don't delete statuses when campaigns exist)
                b.HasOne(c => c.Status)
                 .WithMany()
                 .HasForeignKey(c => c.StatusId)
                 .OnDelete(DeleteBehavior.Restrict);
                b.HasMany(x => x.Banners).WithOne().HasForeignKey(b => b.CampaignId).OnDelete(DeleteBehavior.Cascade);
                b.HasMany(x => x.Locations).WithOne().HasForeignKey(l => l.CampaignId).OnDelete(DeleteBehavior.Cascade);
            });

            // STATUS (new)
            modelBuilder.Entity<Status>(b =>
            {
                b.HasKey(s => s.Id);
                b.Property(s => s.Name).HasMaxLength(100).IsRequired();

                // seed default statuses matching previous enum integers
                b.HasData(
                    new Status { Id = -1, Name = "Draft" },
                    new Status { Id = -2, Name = "Pending" },
                    new Status { Id = -3, Name = "Paid" },
                    new Status { Id = -4, Name = "Running" },
                    new Status { Id = -5, Name = "Completed" }
                );
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
