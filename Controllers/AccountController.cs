using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Ai_Virtual_Campus_Management_System.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            var result = await _signInManager.PasswordSignInAsync(email, password, false, false);

            if (result.Succeeded)
            {
                var user = await _userManager.FindByEmailAsync(email);

                if (user != null && await _userManager.IsInRoleAsync(user, "Admin"))
                    return RedirectToAction("Index", "Department");

                if (user != null && await _userManager.IsInRoleAsync(user, "Student"))
                    return RedirectToAction("Index", "Notice");

                if (user != null && await _userManager.IsInRoleAsync(user, "Faculty"))
                    return RedirectToAction("Index", "Event");

                if (user != null && await _userManager.IsInRoleAsync(user, "Security"))
                    return RedirectToAction("Index", "Home");

                return RedirectToAction("Index", "Home");
            }

            ViewBag.Error = "Invalid email or password";
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string email, string password, string role)
        {
            var user = new IdentityUser
            {
                UserName = email,
                Email = email
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                var roleResult = await _userManager.AddToRoleAsync(user, role);

                if (roleResult.Succeeded)
                {
                    return RedirectToAction("Login");
                }

                ViewBag.Error = string.Join("<br>", roleResult.Errors.Select(e => e.Description));
                return View();
            }

            ViewBag.Error = string.Join("<br>", result.Errors.Select(e => e.Description));
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login");
        }
    }
}