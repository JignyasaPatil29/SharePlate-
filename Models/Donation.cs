
using System;
using System.ComponentModel.DataAnnotations;

namespace SharePlate.Models;

public class Donation
{
    public int Id { get; set; }

    [Required]
    [StringLength(100)]
    [Display(Name = "Food Name")]
    public string FoodName { get; set; } = string.Empty;

    [Required]
    [Range(1, 100000)]
    [Display(Name = "Quantity (meals)")]
    public int Quantity { get; set; }

    [Required]
    [StringLength(150)]
    [Display(Name = "Donor Name")]
    public string DonorName { get; set; } = string.Empty;

    [Required]
    [StringLength(250)]
    [Display(Name = "Pickup Location")]
    public string PickupLocation { get; set; } = string.Empty;

    [Required]
    [DataType(DataType.DateTime)]
    [Display(Name = "Pickup Deadline")]
    public DateTime PickupDeadline { get; set; }

    [Required]
    [RegularExpression(
        "^(Available|Reserved|Picked Up|Completed)$",
        ErrorMessage = "Choose a valid donation status.")]
    public string Status { get; set; } = "Available";

    [StringLength(500)]
    public string? Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
