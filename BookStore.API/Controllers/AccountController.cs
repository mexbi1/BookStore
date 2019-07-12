
using System;
using System.Net;
using System.Threading.Tasks;
using BookStore.BusinessLogicLayer.Services;
using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AccountViews;
using BookStore.DataAccessLayer.Models;
using BookStore.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BookStore.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        // private readonly IAccountService _accountService;
        // private ILogger<AccountController> _logger;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        //private readonly RoleManager<>

        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        //public async Task<IActionResult> Login([FromBody] LoginAccountViews model)
        //{
        //    try
        //    {
        //        var result = await _accountService.Login(model);
        //        return Ok(result);
        //    }
        //    catch (BusinessLogicException exception)
        //    {
        //        return BadRequest(exception.Message);
        //    }
        //    catch (Exception exception)
        //    {
        //        _logger.Logcritical(exception.Message);
        //        return StatusCode((int)HttpStatusCode.InternalServerError);
        //    }
        //}

        [HttpPost]
        //public async Task<IActionResult> Register([FromBody] RegisterAccountViews model)
        //{
        //try
        //{
        //    var result = await _accountService.Register(model);
        //    return Ok(result);
        //}
        //catch (BusinessLogicException exception)
        //{
        //    return BadRequest(exception);
        //}
        //catch (Exception exeption)
        //{
        //    _logger.LogInformation(exeption.Message);
        //    return StatusCode((int)HttpStatusCode.InternalServerError);
        //}

        public async Task<IActionResult> Register(RegisterAccountView model)
        {
            User user = new User { Email = model.Email, UserName = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                var callbackUrl = Url.Action(
                    "ConfirmEmail",
                    "Account",
                    new { userId = user.Id, code = code },
                    protocol: HttpContext.Request.Scheme);
                EmailService emailService = new EmailService();
                await emailService.SendEmailAsync(model.Email, "Confirm you account",
                    $"Подтвердите регистрацию перейдя по ссылке: <a href = '{callbackUrl}'>link/a");
                return Content("Для завершения регистрации проверьте электронную почту и перейдите по ссылке, указанной в письме");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }
            return Ok(model);
        }
        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string code)
        {
            if (userId == null || code == null)
            {
                return Ok("Error");
            }
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return Ok("Error");
            }
            var retsult = await _userManager.ConfirmEmailAsync(user, code);
            if (retsult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
                return Ok();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginAccountView model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    // проверяем, подтвержден ли email
                    if (!await _userManager.IsEmailConfirmedAsync(user))
                    {
                        ModelState.AddModelError(string.Empty, "Вы не подтвердили свой email");
                        return Ok(model);
                    }
                }

                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return Ok(model);
        }
    }
}