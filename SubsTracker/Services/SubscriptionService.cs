using Microsoft.EntityFrameworkCore;
using SubsTracker.Database;
using SubsTracker.Models.Entities;
using SubsTracker.Models.ViewModels;

namespace SubsTracker.Services;

public interface ISubscriptionService
{
    Task<List<SubscriptionViewModel>> GetAllSubscriptionsAsync();
    Task<SubscriptionViewModel> GetSubscriptionByIdAsync(string id);
    Task<SubscriptionViewModel> CreateSubscriptionAsync(SubscriptionViewModel subscription);
    Task DeleteSubscriptionAsync(SubscriptionViewModel subscription);
}

public class SubscriptionService(SubsTrackerContext context) : ISubscriptionService
{
    public async Task<SubscriptionViewModel> GetSubscriptionByIdAsync(string id)
    {
        var subscriptionEntity = await context.Subscriptions
            .Where(sub => sub.Id == id)
            .FirstOrDefaultAsync();
        
        if(subscriptionEntity is not null)
        {
            return new SubscriptionViewModel
            {
                Id = subscriptionEntity.Id,
                Name = subscriptionEntity.Name,
                Description = subscriptionEntity.Description,
                Value = subscriptionEntity.Value,
                Currency = subscriptionEntity.Currency,
                Category = subscriptionEntity.Category,
                PaymentDate = subscriptionEntity.PaymentDate,
                Frecuency = subscriptionEntity.Frecuency
            };
        }
        return null!;
    }

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

    public async Task DeleteSubscriptionAsync(SubscriptionViewModel subscription)
    {
        if (subscription != null)
        {
            context.Subscriptions.Remove(subscription);
            await context.SaveChangesAsync();
        }
    }
}