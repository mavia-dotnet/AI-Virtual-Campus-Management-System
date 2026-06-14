using Ai_Virtual_Campus_Management_System.Data;
using Ai_Virtual_Campus_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ai_Virtual_Campus_Management_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class NoticeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NoticeController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var notices = _context.Notices.ToList();
            return View(notices);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Notice notice)
        {
            _context.Notices.Add(notice);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}