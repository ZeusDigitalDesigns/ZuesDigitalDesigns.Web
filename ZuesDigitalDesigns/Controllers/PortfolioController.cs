using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using ZuesDigitalDesigns.Models;
using ZuesDigitalDesigns.Data;

namespace ZuesDigitalDesigns.Controllers;

/// <summary>
/// Controller responsible for handling portfolio-related functionality
/// within the application. Provides methods for interacting with and displaying
/// design project data stored in the database.
/// </summary>
public class PortfolioController : Controller
{
    // Holds the database context.
    private readonly ApplicationDbContext _context;
    
    // Injects the database context via the constructor.
    public PortfolioController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET
    // Returns the main gallery grid view.
    public IActionResult Index()
    {
        // Retrieve all projects from the database
        List<Project> projects = _context.Projects.ToList();
        
        // Pass the populated list directly into the view
        return View(projects);
    }
}