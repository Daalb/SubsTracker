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
}
