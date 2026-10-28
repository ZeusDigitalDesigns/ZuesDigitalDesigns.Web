using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using ZuesDigitalDesigns.Data;
using ZuesDigitalDesigns.Models;

namespace ZuesDigitalDesigns.Controllers
{
    /// <summary>
    /// Provides functionality for handling contact-related interactions, such as submitting
    /// inquiries through a contact form. Includes features like rate-limiting, deduplication,
    /// and persisting valid inquiries to the database.
    /// </summary>
    public class ContactController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMemoryCache _cache; // Injected for rate limiting

        public ContactController(ApplicationDbContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// Handles the submission of a contact inquiry, applying rate-limiting, deduplication,
        /// and saving valid inquiries to the database.
        /// </summary>
        /// <param name="inquiry">
        /// The contact inquiry submitted by the user, containing details such as name, email,
        /// and message.
        /// </param>
        /// <returns>
        /// A redirection to the ThankYou view if the submission is successful or flagged (rate limit or duplication).
        /// Returns the original view with validation errors if the model state is invalid.
        /// </returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ContactInquiry inquiry)
        {
            if (!ModelState.IsValid)
            {
                return View(inquiry);
            }

            inquiry.Id = 0;

            // RATE LIMITING 
            // Grab the user's IP to track how many times they submit
            string clientIp = HttpContext.Connection.RemoteIpAddress?.ToString() 
                              ?? "unknown_ip";
            string cacheKey = $"Contact_Limit_{clientIp}";

            if (_cache.TryGetValue(cacheKey, out int submissions))
            {
                if (submissions >= 3)
                {
                    // If they hit the limit, silently redirect them. 
                    // Bots will think it worked and move on.
                    return RedirectToAction("ThankYou");
                }
                
                // Increment their count for the next hour
                _cache.Set(cacheKey, submissions + 1, TimeSpan.FromHours(1));
            }
            else
            {
                // First submission, start the counter
                _cache.Set(cacheKey, 1, TimeSpan.FromHours(1));
            }

            // DEDUPLICATION 
            DateTimeOffset yesterday = DateTimeOffset.UtcNow.AddDays(-1);
            bool isDuplicate = _context.ContactInquiries.Any(c => 
                c.Email == inquiry.Email && 
                c.Message == inquiry.Message && 
                c.SubmittedOn > yesterday);

            if (isDuplicate)
            {
                return RedirectToAction("ThankYou");
            }

            // SAVE TO DATABASE 
            inquiry.SubmittedOn = DateTimeOffset.UtcNow;
            _context.ContactInquiries.Add(inquiry);
            await _context.SaveChangesAsync();

            return RedirectToAction("ThankYou");
        }

        [HttpGet]
        public IActionResult ThankYou()
        {
            return View();
        }
    }
}