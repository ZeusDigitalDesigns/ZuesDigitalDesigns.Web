using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ZuesDigitalDesigns.Models;
using ZuesDigitalDesigns.Data;

namespace ZuesDigitalDesigns.Controllers;

/// <summary>
/// Responsible for managing interactions related to the contact form,
/// including rendering the contact form view, processing submitted data,
/// and displaying a thank-you page upon successful submission.
/// </summary>
public class ContactController : Controller
{
    
    private readonly ApplicationDbContext _context;

    public ContactController(ApplicationDbContext context)
    {
        _context = context;
    }
    
    // GET: Gives the contact form
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }
    
    // POST: Receives the contact form data

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(ContactInquiry inquiry)
    {
        
        // Failsafe for bad data
        if (!ModelState.IsValid)
        {
            
            // Returns the from with validation error message
            return View(inquiry);
        }
        
        // Make sure the timestamp is always accurate
        inquiry.SubmittedOn = DateTimeOffset.UtcNow;
        
        // Save it to the DB
        _context.ContactInquiries.Add(inquiry);
        await _context.SaveChangesAsync();
        
        // Redirect to a thank you page
        return RedirectToAction("ThankYou");
    }
    
    // GET: Thank you page
    [HttpGet]
    public IActionResult ThankYou()
    {
        return View();
    }
}