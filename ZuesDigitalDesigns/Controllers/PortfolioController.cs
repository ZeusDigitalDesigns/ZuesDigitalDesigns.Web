using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ZuesDigitalDesigns.Data;
using ZuesDigitalDesigns.Models;

namespace ZuesDigitalDesigns.Controllers
{
    /// <summary>
    /// Handles portfolio-related requests, such as displaying a list of projects.
    /// Communicates with the database using <see cref="ApplicationDbContext"/>
    /// to retrieve and display project data.
    /// </summary>
    public class PortfolioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public PortfolioController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Project> projects = new List<Project>();

            try
            {
                // Order by newest, limit to 12 to prevent memory limits
                projects = _context.Projects
                    .OrderByDescending(p => p.Id)
                    .Take(12)
                    .ToList();
            }
            catch (Exception)
            {
                // If SQL goes down, fallback to an empty list 
                // so the webpage still loads gracefully without a 500 error.
                projects = new List<Project>();
            }

            return View(projects);
        }
    }
}