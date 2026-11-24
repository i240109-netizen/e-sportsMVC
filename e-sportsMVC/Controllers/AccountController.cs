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
        public IActionResult Login(string? returnUrl = null) { ViewData["ReturnUrl"] = returnUrl; return View(new LoginViewModel()); }

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null) {
            ViewData["ReturnUrl"] = returnUrl;
            if (!ModelState.IsValid) return View(model);
            var user = AccountStore.FindByEmail(model.Email);
            if (user == null || !AccountStore.VerifyPassword(user, model.Password)) {
                ModelState.AddModelError(string.Empty, "Email ou palavra-passe incorretos."); return View(model);
            }
            await SignIn(user, model.RememberMe);
            if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl)) return Redirect(returnUrl);
            return RedirectToAction("Index", "Home");
        }

        [AllowAnonymous, HttpGet]
        public IActionResult Register() => View(new RegisterViewModel());

        [AllowAnonymous, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model) {
            if (!ModelState.IsValid) return View(model);
            if (!AccountStore.Register(model.FullName, model.Email, model.Password)) {
                ModelState.AddModelError(nameof(model.Email), "Já existe uma conta com este email."); return View(model);
            }
            await SignIn(AccountStore.FindByEmail(model.Email)!, false);
            return RedirectToAction("Index", "Home");
        }

        [Authorize, HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout() {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction(nameof(Login));
        }

        private async Task SignIn(AccountRecord user, bool remember) {
            var claims = new List<Claim> {
                new(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new(ClaimTypes.Name, user.FullName),
                new(ClaimTypes.Email, user.Email)
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity),
                new AuthenticationProperties { IsPersistent = remember, ExpiresUtc = DateTimeOffset.UtcNow.AddHours(8) });
        }
    }
}