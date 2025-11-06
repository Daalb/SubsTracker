using Microsoft.EntityFrameworkCore;
using SubsTracker.Database;
using SubsTracker.Models.Entities;
using SubsTracker.Models.ViewModels;

namespace SubsTracker.Services;

public interface ISubscriptionService
{
    Task<List<SubscriptionViewModel>> GetAllSubscriptionsAsync();
    Task<SubscriptionViewModel> CreateSubscriptionAsync(SubscriptionViewModel subscription);
}

public class SubscriptionService(SubsTrackerContext context) : ISubscriptionService
{
    public async Task<List<SubscriptionViewModel>> GetAllSubscriptionsAsync()
    {
        var subscriptions = await context.Subscriptions.ToListAsync();
        return subscriptions.Select(s => new SubscriptionViewModel
        {
            Id = s.Id,
            Name = s.Name,
            Description = s.Description,
            Value = s.Value,
            Currency = s.Currency,
            Category = s.Category,
            PaymentDate = s.PaymentDate,
            Frecuency = s.Frecuency
        }).ToList();
    }

    public async Task<SubscriptionViewModel> CreateSubscriptionAsync(SubscriptionViewModel subscription)
    {
        var subscriptionId = subscription.Id;
        SubscriptionEntity subscriptionEntity = new()
        {
            Id = subscriptionId,
            Name = subscription.Name,
            Description = subscription.Description,
            Value = subscription.Value,
            Currency = subscription.Currency,
            Category = subscription.Category,
            PaymentDate = subscription.PaymentDate,
            Frecuency = subscription.Frecuency
        };
        context.Add(subscriptionEntity);
        await context.SaveChangesAsync();

        subscription.Id = subscriptionId;
        return subscription;
    }

}