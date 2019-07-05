
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BookStore.BusinessLogicLayer.Services;
using BookStore.BusinessLogicLayer.Services.Interfaces;
using BookStore.BusinessLogicLayer.Views.AccountViews;
using BookStore.DataAccessLayer.Models;
using BookStore.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace BookStore.API.Controllers
{
    [Route("api/[controller/action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private IAccountService _accountService;
        private ILogger<AccountController> _logger;

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginAccountViews model)
        {
            try
            {
                var result = await _accountService.Login(model);
                return Ok(result);
            }
            catch (BusinessLogicException exception)
            {
                return BadRequest(exception.Message);
            }
            catch (Exception exception)
            {
                _logger.LogInformation(exception.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterAccountViews model)
        {
            try
            {
                var result = await _accountService.Register(model);
                return Ok(result);
            }
            catch (BusinessLogicException exception)
            {
                return BadRequest(exception);
            }
            catch (Exception exeption)
            {
                _logger.LogInformation(exeption.Message);
                return StatusCode((int)HttpStatusCode.InternalServerError);
            }
        }
        }

       

    }
}