using Microsoft.EntityFrameworkCore;
using SubsTracker.Models.Entities;

namespace SubsTracker.Database;

public class SubsTrackerContext(
    DbContextOptions<SubsTrackerContext> options) : DbContext(options)
{
    // DbSets for each entity
    public DbSet<SubscriptionEntity> Subscriptions { get; set; }
}
