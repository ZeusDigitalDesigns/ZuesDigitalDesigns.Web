using Microsoft.AspNetCore.Mvc;
using ZuesDigitalDesigns.Data;
using ZuesDigitalDesigns.Models;
using ZuesDigitalDesigns.Services;

namespace ZuesDigitalDesigns.Controllers;

public class ContactController : Controller
{
    private readonly ApplicationDbContext _context;
    private readonly EmailService _emailService;

    public ContactController(ApplicationDbContext context,  EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public IActionResult ThankYou()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> SubmitQuote(ContactInquiry inquiry, string? botTrapWebsite)
    {
        // Honeypot Check: Send bots to the success page too
        if (!string.IsNullOrEmpty(botTrapWebsite))
        {
            return RedirectToAction("ThankYou");
        }

        if (ModelState.IsValid)
        {
            _context.ContactInquiries.Add(inquiry);
            await _context.SaveChangesAsync();

            await _emailService.SendEmailAsync(
                inquiry.Name, 
                inquiry.Email, 
                inquiry.Message);
            
            // Redirect actual users to the new page
            return RedirectToAction("ThankYou");
        }

        return View("Index", inquiry);
    }

    
}
