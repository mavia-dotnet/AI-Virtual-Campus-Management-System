using Ai_Virtual_Campus_Management_System.Data;
using Ai_Virtual_Campus_Management_System.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ai_Virtual_Campus_Management_System.Controllers
{
    [Authorize(Roles = "Admin")]
    public class DepartmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public DepartmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // SHOW DATA
        public IActionResult Index()
        {
            var departments = _context.Departments.ToList();

            return View(departments);
        }

        // CREATE PAGE
        public IActionResult Create()
        {
            return View();
        }

        // SAVE DATA
        [HttpPost]
        public IActionResult Create(Department department)
        {
            _context.Departments.Add(department);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // EDIT PAGE
        public IActionResult Edit(int id)
        {
            var department = _context.Departments.Find(id);

            return View(department);
        }

        // UPDATE DATA
        [HttpPost]
        public IActionResult Edit(Department department)
        {
            _context.Departments.Update(department);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }

        // DELETE PAGE
        public IActionResult Delete(int id)
        {
            var department = _context.Departments.Find(id);

            return View(department);
        }

        // DELETE DATA
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var department = _context.Departments.Find(id);

            _context.Departments.Remove(department);

            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}