using a1_bookstore_ict715.Data;
using a1_bookstore_ict715.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace a1_bookstore_ict715.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        // private readonly ApplicationDbContext _context;
        // public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            // _context = context;
        }
        //public async Task<IActionResult> Books()
        //{
        //    var applicationDbContext = _context.Books.Include(c => c.Name);
        //    return View(applicationDbContext.ToListAsync());
        //}
        public IActionResult Index()
        {
            ViewBag.Name = "Travis Wahlfeldt";
            ViewBag.Email = "grumio999@gmail.com";

            return View();
        }
        /// <summary>
        /// Get user contact information and inquiry
        /// </summary>
        [Route("contactus")]
        [HttpGet]
        public IActionResult ContactUs()
        {
            ContactUsModel contactUs = new ContactUsModel();
            return View(contactUs);
        }
        /// <summary>
        /// Check for valid entries and log to console for now
        /// </summary>
        [HttpPost]
        public IActionResult ContactUS(ContactUsModel contactUs)
        {
            if (ModelState.IsValid)
            {
                Debug.WriteLine(contactUs.UserName);
                Debug.WriteLine(contactUs.Email);
                Debug.WriteLine(contactUs.PhoneNumber);
                Debug.WriteLine(contactUs.Message);
                return RedirectToAction("Index");
            }
            else
            {
                return View(contactUs);
            }
        }

        [Route("privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}