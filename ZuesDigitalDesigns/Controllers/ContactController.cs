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
    

    // POST: Catches the submitted form data
    [HttpPost]
    [ValidateAntiForgeryToken] 
    public async Task<IActionResult> Index(ContactInquiry inquiry)
    {
        if (!ModelState.IsValid)
        {
            return View(inquiry); 
        }

        // Zero out the ID to prevent explicit identity insert crashes
        inquiry.Id = 0;

        // Prevent double-clicks and basic bot spam by checking for 
        // the exact same message from the same email in the last 24 hours.
        DateTimeOffset yesterday = DateTimeOffset.UtcNow.AddDays(-1);
            
        bool isDuplicate = _context.ContactInquiries.Any(c => 
            c.Email == inquiry.Email && 
            c.Message == inquiry.Message && 
            c.SubmittedOn > yesterday);

        if (isDuplicate)
        {
            // Silently redirect duplicates so bots get no feedback
            // and double-clicking users just see the success page.
            return RedirectToAction("ThankYou");
        }

        inquiry.SubmittedOn = DateTimeOffset.UtcNow;

        _context.ContactInquiries.Add(inquiry);
        await _context.SaveChangesAsync();

        return RedirectToAction("ThankYou");
    }
    
    // GET: Thank you page
    [HttpGet]
    public IActionResult ThankYou()
    {
        return View();
    }
}