using Microsoft.EntityFrameworkCore;
using SubsTracker.Models.Entities;

namespace SubsTracker.Database;

/// <summary>
/// The database context for the SubsTracker application. 
/// This context manages the connection to the database.
/// And it provides DbSet properties for each entity in the application.
/// </summary>
/// <param name="options"></param>
public class SubsTrackerContext(
    DbContextOptions<SubsTrackerContext> options) : DbContext(options)
{
    // DbSets for each entity. Entities represent tables in the database.
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SubscriptionEntity>(entity =>
        {
            entity.HasData(
                new SubscriptionEntity { 
                    Id  = "2513c007-b0c0-4740-88ca-be481c8c1065",
                    Name = "Netflix",
                    Description = "Streaming service for movies and TV shows",
                    Value = 19900m,
                    Currency = "COP",
                    Category = "Entertainment",
                    PaymentDate = new DateTime(2025, 11, 19),
                    Frecuency = Models.Enums.FrecuencyEnum.Monthly
                }
            );
        });
    }
}
