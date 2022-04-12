﻿using Identity101.Models;
using Identity101.Models.Identity;
using Identity101.Models.Role;
using Identity101.Services.Email;
using Identity101.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using System.Text.Encodings.Web;

namespace Identity101.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IEmailService _emailService;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        public AccountController(UserManager<ApplicationUser> userManager,IEmailService emailService,RoleManager<ApplicationRole> roleManager,SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _emailService = emailService;
            _roleManager = roleManager;
            _signInManager = signInManager;
            CheckRoles();
        }
        
        private void CheckRoles()
        {
            foreach(var item in Roles.RoleList)
            {
                if (_roleManager.RoleExistsAsync(item).Result)
                    continue;
                var result = _roleManager.CreateAsync(new ApplicationRole()
                {
                    Name = item
                }).Result;
            }
        }

        [HttpGet("~/kayit-ol")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost("~/kayit-ol")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bir hata oluştu");
                return View(model);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName,
                Email = model.Email,
                Name = model.Name,
                Surname = model.Surname
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //Rol Atma
                var count = _userManager.Users.Count();
                result = await _userManager.AddToRoleAsync(user,count == 1 ? Roles.Admin : Roles.Passive);
                //TODO: Email gönderme - Aktivasyon
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                var callbackUrl = Url.Action("ConfirmEmail","Account",new { userId = user.Id, code = code },Request.Scheme);
                
                var email = new MailModel()
                {
                    To = new List<EmailModel>
                    {
                        new EmailModel(){
                            Adress = user.Email, Name = user.UserName
                        }
                    },

                    Body = $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.",
                    Subject = "Confirm your email"
                };
                await _emailService.SendMailAsync(email);
                //TODO: Login olma
                return RedirectToAction("Login");
            }
            var messages = string.Join("\n", result.Errors.Select(x => x.Description));
            ModelState.AddModelError(string.Empty, messages);

            return View(model);
        }
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if(userId == null || code == null)
            {
                return RedirectToAction("Index", "Home");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if(user == null)
            {
                return NotFound($"Unable to load user with ID '{userId}'.");
            }

            code = Encoding.UTF8.GetString(WebEncoders.Base64UrlDecode(code));
            var result = await _userManager.ConfirmEmailAsync(user, code);
            ViewBag.StatusMessage =
                result.Succeeded ? "Thank you for confirming your email." : "Error confirming your email.";

            if (result.Succeeded && _userManager.IsInRoleAsync(user, Roles.Passive).Result)
            {
                await _userManager.RemoveFromRoleAsync(user,Roles.Passive);
                await _userManager.AddToRoleAsync(user,Roles.User);
            }
            return View();
        }

        [HttpGet("~/giris-yap")]
        public IActionResult Login()
        {
            return View();
        }
        
        [HttpPost("~/giris-yap")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }
            
                var user = await _userManager.FindByNameAsync(model.UserName);

                var result =  await _signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, true);
            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else if(result.IsLockedOut)
            {
                 // TODO: Kilitlenmişse ne yapılacağı
            }
            else if(result.RequiresTwoFactor)
            {
                //TODO: 2fa yönlendirmesi yapılacak
            }

                ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                return View(model);
           
        }
        

    }
}
