using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShoeApp2.Logic.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using ShoeApp2.Models.AcountModels;
using System.Security.Claims;
using ShoeApp2.ViewModels.AccountViewModels;

namespace ShoeApp2.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserContainer  _userContainer; 

        public AccountController(IUserContainer userContainer)
        {
            _userContainer = userContainer; 
        }
        
        //GET: Account/Login
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home"); 
            }

            return View(); 
        }

        //POST: Account/Login
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if(ModelState.IsValid)
            {
                if (_userContainer.ComparePasswords(model.EmailAddress, model.Password))
                {
                    var user = _userContainer.GetUserByEmail(model.EmailAddress);

                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaim(new Claim(ClaimTypes.Name, user.Email));
                    identity.AddClaim(new Claim(ClaimTypes.GivenName, user.Username));

                    var principal = new ClaimsPrincipal(identity);

                    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, new AuthenticationProperties { IsPersistent = model.RememberMe });

                    return RedirectToAction("ListShoe", "Shoe");
                }

                ModelState.AddModelError(string.Empty, "Invalid login.");
                return View();
            }

            return View(); 
        }

        //GET:Account/Profile
        [HttpGet]
        public IActionResult Profile()
        {
            var user = _userContainer.GetUserByEmail(User.Identity.Name);

            return View(new ProfileViewModel() { EmailAddress = user.Email, Username = user.Username }); 
        }

        //POST:Account/Profile
        [HttpPost]
        public IActionResult Profile(ProfileViewModel model)
        {
            if(ModelState.IsValid)
            {
                var user = _userContainer.GetUserByEmail(User.Identity.Name);

                _userContainer.UpdateProfile(model.Username, model.EmailAddress, user.Id);

                return View(); 
            }
            return View(model); 
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Login", "Account");
        }

        //GET: Account/Users

        [HttpGet]
        public IActionResult Users()
        {
            var result = _userContainer.GetAllUsers();
            var users = new List<UserViewModel>();

            foreach (var user in result)
            {
                var model = new UserViewModel(user);
                users.Add(model);
            }
            return View(users);
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            return View(); 
        }
    }
}
