using Ai_Virtual_Campus_Management_System.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ai_Virtual_Campus_Management_System.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<ChatMessage> ChatMessages { get; set; }
    }
}