using MarialaTemplate.Areas.MarialaAdmin.ViewModels;
using MarialaTemplate.Models;
using MarialaTemplate.Utilities.Enums;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MarialaTemplate.Areas.MarialaAdmin.Controllers
{
    [Area("MarialaAdmin")]
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager,SignInManager<AppUser> signInManager,RoleManager<IdentityRole> roleManager    )
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            if (!ModelState.IsValid)
            {
                return View(registerVM);
            }
            AppUser user = new AppUser
            {
                Name = registerVM.Name,
                Surname = registerVM.Surname,
                UserName = registerVM.Username,
                Email = registerVM.Email 
            };
            IdentityResult passResult = await _userManager.CreateAsync(user, registerVM.Password);
            if (!passResult.Succeeded)
            {
                foreach (var error in passResult.Errors)
                {
                    ModelState.AddModelError(String.Empty, error.Description);
                    return View();
                }
            }
            await _userManager.AddToRoleAsync(user, UserRoles.Member.ToString());
            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index","Home",new {area=""});
        }
        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home", new {area=""});
        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM loginVM)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser existedUser = await _userManager.FindByEmailAsync(loginVM.UsernameOrEmail);
            if (existedUser == null)
            {
                existedUser =await _userManager.FindByNameAsync(loginVM.UsernameOrEmail);
                if (existedUser == null)
                {
                    ModelState.AddModelError(String.Empty, "Username,Email or Password is incorrect");
                    return View();
                }
            }
            var passresult = await _signInManager.PasswordSignInAsync(existedUser, loginVM.Password, loginVM.IsRemembered, false);
            if (!passresult.Succeeded)
            {
                ModelState.AddModelError(String.Empty, "Username,Email or Password is incorrect");
                return View();
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
        public async Task<IActionResult> CreateRole()
        {
            foreach (var item in Enum.GetValues(typeof(UserRoles)))
            {
                await _roleManager.CreateAsync(new IdentityRole
                {
                    Name = item.ToString(),
                });
            }
            return RedirectToAction("Index","Home");
        }
    }
}
