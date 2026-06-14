using Ai_Virtual_Campus_Management_System.Data;
using Ai_Virtual_Campus_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ai_Virtual_Campus_Management_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class EventController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EventController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var eventsList = _context.Events.ToList();
            return View(eventsList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Event eventObj)
        {
            _context.Events.Add(eventObj);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}