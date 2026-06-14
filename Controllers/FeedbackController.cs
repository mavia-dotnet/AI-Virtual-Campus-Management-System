using Ai_Virtual_Campus_Management_System.Data;
using Ai_Virtual_Campus_Management_System.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ai_Virtual_Campus_Management_System.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FeedbackController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var feedbacks = _context.Feedbacks.ToList();

            return View(feedbacks);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Feedback feedback)
        {
            _context.Feedbacks.Add(feedback);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}