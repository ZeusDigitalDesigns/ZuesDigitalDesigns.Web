using Microsoft.AspNetCore.Mvc;

namespace ZuesDigitalDesigns.Controllers;

/// <summary>
/// Handles the presentation and management of portfolio-related views and actions.
/// This controller is responsible for serving the "Portfolio" section of the application.
/// </summary>
public class PortfolioController : Controller
{
    // GET
    // Returns the main gallery grid view.
    public IActionResult Index()
    {
        return View();
    }
}