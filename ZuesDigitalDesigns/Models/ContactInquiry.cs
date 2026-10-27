using System.ComponentModel.DataAnnotations;
using System;

namespace ZuesDigitalDesigns.Models;

public class ContactInquiry
{
    
    [Key]
    public int Id { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(100)]
    public required string Name { get; set; }
    
    // Not required
    [MaxLength(150)]
    public string BusinessName { get; set; } = string.Empty;
    
    [Required(AllowEmptyStrings = false)]
    [EmailAddress]
    [MaxLength(100)]
    public required string Email { get; set; }
    
    [Required(AllowEmptyStrings = false)]
    [MaxLength(1000)]
    public required string Message { get; set; }
    
    // Automatically the time they submit the form
    public DateTime SubmittedOn { get; set; } = DateTime.UtcNow;
}