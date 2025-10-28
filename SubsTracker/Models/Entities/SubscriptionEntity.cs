using SubsTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace SubsTracker.Models.Entities;

public class SubscriptionEntity
{
    [Key]
    public string Id { get; set; } = null!;

    [Required, MaxLength(30)]
    public string Name { get; set; } = null!;

    [MaxLength(250)]
    public string? Description { get; set; }

    [Required]
    public decimal Value { get; set; }

    [Required, MaxLength(3)]
    public string Currency { get; set; } = null!;

    public string Category { get; set; } = null!;

    [Required]
    public DateTime PaymentDate { get; set; }

    public FrecuencyEnum Frecuency { get; set; }
}
