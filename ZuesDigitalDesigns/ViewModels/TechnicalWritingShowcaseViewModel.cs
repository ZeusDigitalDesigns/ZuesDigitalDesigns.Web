using ZuesDigitalDesigns.Models;

namespace ZuesDigitalDesigns.ViewModels;

public class TechnicalWritingShowcaseViewModel
{
    public List<TechnicalWritingService> Services { get; set; } 
        = new List<TechnicalWritingService>();
    
    public TechnicalWritingService? FeaturedService { get; set; }
    
    public string PageHeading { get; set; } 
        = "Operational Systems & Technical Documentation";

    public string PageSubheading { get; set; } 
        = "Technical writing services for operational systems and technical documentation";

    public string PageMetaDescription { get; set; } 
        = "Zues Digital Designs offers technical writing services for operational " +
          "systems and technical documentation. Our team of experts provides high-quality, " +
          "tailored solutions to meet your specific needs.";
}