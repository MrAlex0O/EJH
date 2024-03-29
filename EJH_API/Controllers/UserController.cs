﻿using API.Authorization.Attributes;
using API.Authorization.Models;
using API.Authorization.Models.Users;
using API.Authorization.Services;
using AutoMapper;
using DataBase.Contexts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace API.Controllers
{
    //[Authorization.Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public UserController(IUserService userService, IMapper mapper, IOptions<AppSettings> appSettings)
        {
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<ActionResult<AuthResponse>> Authenticate(AuthRequest model)
        {
            var response = _userService.Authenticate(model);
            return Ok(response);

        }

        [AllowAnonymous]
        [HttpGet("roles")]
        public async Task<ActionResult<List<RoleResponse>>> GetRoles()
        {
            var response = _userService.GetRoles();
            return Ok(response);
        }

        [RequireAuthorization(Roles.Admin)]
        [HttpPost("register")]
        public IActionResult Register(RegisterRequest model)
        {
            if (_userService.Register(model))
                return Ok(new { message = "Registration successful" });
            else
                return BadRequest("Username '" + model.Username + "' is already taken");
        }

        [HttpGet]
        [RequireAuthorization(Roles.Admin)]
        public IActionResult GetAll()
        {
            var users = _userService.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            var user = _userService.GetById(id);
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(Guid id, UpdateRequest model)
        {
            _userService.Update(id, model);
            return Ok(new { message = "User updated successfully" });
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            _userService.Delete(id);
            return Ok(new { message = "User deleted successfully" });
        }
    }
}
