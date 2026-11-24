using System.Security.Claims;
using e_sportsMVC.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace e_sportsMVC.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous, HttpGet]
        public IActionResult Login(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View(new LoginViewModel());
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View(model);

            UserModel? user = DataBaseModel.Users.FirstOrDefault(u =>
                u.Email.Equals(model.Email.Trim(), StringComparison.OrdinalIgnoreCase)
                && u.Password == model.Password);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Email ou palavra-passe incorretos.");
                return View(model);
            }

            await SignIn(user, model.RememberMe);

            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                return Redirect(returnUrl);

            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous, HttpGet]
        public IActionResult Register()
        {
            return View(new RegisterViewModel());
        }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            string email = model.Email.Trim();

            if (DataBaseModel.Users.Any(u =>
                u.Email.Equals(email, StringComparison.OrdinalIgnoreCase)))
            {
                ModelState.AddModelError(nameof(model.Email), "Já existe uma conta com este email.");
                return View(model);
            }

            int nextId = DataBaseModel.Users.Count == 0
                ? 1
                : DataBaseModel.Users.Max(u => u.ID) + 1;

            var user = new UserModel(
                nextId,
                model.FullName.Trim(),
                email,
                UserModel.enumRole.User,
                model.Password
            );

            DataBaseModel.Users.Add(user);

            await SignIn(user, false);
            return RedirectToAction("Index", "Home");
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        private async Task SignIn(UserModel user, bool remember)
        {
            var claims = new List<Claim>
            {
                new(ClaimTypes.NameIdentifier, user.ID.ToString()),
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Email, user.Email),
                new(ClaimTypes.Role, user.Role.ToString())
            };

            var identity = new ClaimsIdentity(
                claims,
                CookieAuthenticationDefaults.AuthenticationScheme
            );

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(identity),
                new AuthenticationProperties
                {
                    IsPersistent = remember,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8)
                }
            );
        }
    }
}
