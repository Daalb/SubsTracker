using SubsTracker.Models.Enums;

namespace SubsTracker.Models.Entities;

public class SubscriptionEntity
{
    public string Id { get; set; } = null!;
    
    public string Name { get; set; } = null!;
    
    public string? Description { get; set; }
    
    public decimal Value { get; set; }

    public string Currency { get; set; } = null!;

    public string Category { get; set; } = null!;

    public DateTime PaymentDate { get; set; }

    public FrecuencyEnum Frecuency { get; set; }
}
