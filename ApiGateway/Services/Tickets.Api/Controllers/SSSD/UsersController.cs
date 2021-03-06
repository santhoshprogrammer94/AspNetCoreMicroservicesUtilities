﻿using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Tickets.Api.Controllers.Sssd
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly ILogger _logger;

        public UsersController(ILogger<UsersController> logger)
        {
            _logger = logger;
        }

        private static readonly string RouterAddress = "http://router:80/users_service";

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("UsersController: Get called");
            try
            {
                await new HttpClient().GetAsync(RouterAddress + "/users");
                return Ok("UsersController: Get ok");
            }
            catch
            {
                return BadRequest("Not resolved");
            }
        }
    }
}