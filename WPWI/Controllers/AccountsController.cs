using AutoMapper;
using DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WPWI.Models.ViewModels;

namespace WPWI.Controllers
{
    public class AccountsController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMapper _mapper;
        private readonly SignInManager<AppUser> _signInManager;


        public AccountsController(UserManager<AppUser> userManager,
                                  IMapper mapper,
                                  SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(AppUserVM user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }

            var isUserInDatabase = await _userManager.FindByEmailAsync(user.Email);
            if (isUserInDatabase != null)
            {
                ModelState.AddModelError("Email", "Email already exist bruh");
                return View(user);
            }

            var newUser = _mapper.Map<AppUser>(user);
            newUser.UserName = user.Email;

            var result = await _userManager.CreateAsync(newUser, user.Password);
            if (result.Succeeded)
            {
                var res = await _userManager.AddToRoleAsync(newUser, "User");
                if (!res.Succeeded)
                {
                    ModelState.AddModelError(String.Empty, "Unable to complete the registration");
                    return View(user);
                }

                var claim = new Claim("id", newUser.Id);
                res = await _userManager.AddClaimAsync(newUser, claim);
                if (!res.Succeeded)
                {
                    ModelState.AddModelError(String.Empty, "Unable to complete the registration");
                    return View(user);
                }

                return RedirectToAction("Dashboard", "Wedding");
            }
            else
            {
                foreach (var err in result.Errors)
                {
                    Console.WriteLine(err.Code + " " + err.Description);

                }
                return View(user);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVM user)
        {
            if (!ModelState.IsValid)
            {
                return View(user);
            }
            AppUser isUserInDb = await _userManager.FindByEmailAsync(user.Email);

            if (isUserInDb == null)
            {
                ModelState.AddModelError("Uesr", "User Doesn't exist");
                return View(user);
            }

            var validPassword = await _userManager.CheckPasswordAsync(isUserInDb, user.Password);
            if (validPassword != true)
            {
                ModelState.AddModelError("Password", "Bad Password!!!");
                return View(user);
            }

            await _signInManager.SignInAsync(isUserInDb, validPassword);

            return RedirectToAction("Dashboard", "Wedding");
        }
    }
}
