using SubsTracker.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SubsTracker.Models.Entities;

public class SubscriptionEntity
{
    // Core properties
    [Key]
    public string Id { get; set; } = null!;

    [Required, MaxLength(30)]
    public string Name { get; set; } = null!;

    [MaxLength(250)]
    public string? Description { get; set; }

    [Required]
    [Column(TypeName = "decimal(18, 2)")]
    public decimal Value { get; set; }

    [Required, MaxLength(5)]
    [StringLength(5)]
    public string Currency { get; set; } = null!;

    public string Category { get; set; } = null!;

    [Required]
    public DateTime PaymentDate { get; set; } // Date that the payment starts

    public FrecuencyEnum Frecuency { get; set; }

    public bool IsActive { get; set; } = true;

    // Computed property for next payment date. Store or Not?
    // public DateTime NextPaymentDate { get; set; }


    // TODO: Add properties for User association

    // TODO: Add navigation properties if needed
}