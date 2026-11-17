using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZuesDigitalDesigns.ViewModels;
using ZuesDigitalDesigns.Models;
using ZuesDigitalDesigns.Services;

namespace ZuesDigitalDesigns.Controllers;

public class ServicesController : Controller
{
    
    private readonly ITechnicalWritingService _techWritingService;

    public ServicesController(ITechnicalWritingService technicalWritingService)
    {
        _techWritingService = technicalWritingService;
    }
    
    
    // GET
    /// <summary>
    /// Handles GET requests for the technical writing services showcase by retrieving all available services, selecting the first service as the featured service, and returning the populated view model to the view.
    /// </summary>
    /// <return>
    /// A task representing the asynchronous operation, with an action result that renders the technical writing services view.
    /// </return>
    [HttpGet]
    public async Task<IActionResult> TechnicalWriting()
    {
        List<TechnicalWritingService> allServices = await _techWritingService.GetAllServicesAsync();
        
        TechnicalWritingService? featured = allServices.FirstOrDefault();

        TechnicalWritingShowcaseViewModel viewModel = new TechnicalWritingShowcaseViewModel
        {
            Services = allServices,
            FeaturedService = featured
        };
        return View(viewModel);
    }

    [HttpGet]
    public async Task<IActionResult> ServiceDetails(int id)
    {
        if (id <= 0)
        {
            return BadRequest();
        }
        
        TechnicalWritingService? service = await _techWritingService.GetServiceByIdAsync(id);

        if (service == null)
        {
            return NotFound();
        }
        return View(service);
    }
}