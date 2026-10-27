using System.ComponentModel.DataAnnotations;

namespace ZuesDigitalDesigns.Models;

/// <summary>
/// Represents a project model used within the application, encapsulating details about a design project.
/// </summary>
public class Project
{
    [Key] 
    public int DesignId { get; set; }

    [Required]
    [MaxLengthAttribute(100)]
    public string Title { get; set; } = string.Empty;
    
    [Required]
    [MaxLength(500)]
    public string Description { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string ImagePath { get; set; } = string.Empty;
    
    [MaxLength(255)]
    public string RepoUrl { get; set; } = string.Empty;
}