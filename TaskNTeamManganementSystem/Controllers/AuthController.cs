using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Scripting;
using Microsoft.IdentityModel.Tokens;
using Org.BouncyCastle.Crypto.Generators;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskNTeamManganementSystem.Application.DTOs;
using TaskNTeamManganementSystem.Application.Interfaces;
using TaskNTeamManganementSystem.Domain.Entities;
using TaskNTeamManganementSystem.Infrastructure.Persistent.Data;

[ApiController]
[Route("api/[controller]")]
public class AuthController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IConfiguration _configuration;
    private readonly IJwtTokenGenerator _jwt;

    public AuthController(ApplicationDbContext context, IConfiguration configuration, IJwtTokenGenerator jwt)
    {
        _context = context;
        _configuration = configuration;
        _jwt = jwt;
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public IActionResult Register([FromBody] RegisterRequestDTO request)
    {
        if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Invalid registration request");
        }

        // Check if email already exists
        if (_context.Users.Any(u => u.Email == request.Email))
        {
            return BadRequest("Email already registered");
        }

        var passwordHash = "mehedi123"; //BCrypt.Net.BCrypt.HashPassword(request.Password);

        var user = new User
        {
            FullName = request.FullName,
            Email = request.Email,
            PasswordHash = passwordHash,
            Role = request.Role
        };

        _context.Users.Add(user);
        _context.SaveChanges();

        var token = _jwt.GenerateToken(user); 

        return Ok(new
        {
            Token = token,
            User = new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.Role
            }
        });
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        if (request == null || string.IsNullOrEmpty(request.Email) || string.IsNullOrEmpty(request.Password))
        {
            return BadRequest("Invalid login request");
        }
        var user = _context.Users.FirstOrDefault(u => u.Email == request.Email);
        if (user == null || user.PasswordHash != request.Password) //BCrypt.Net.BCrypt.Verify(request.Password, user.PasswordHash))
        {
            return Unauthorized("Invalid email or password");
        }
        var token = _jwt.GenerateToken(user); 
        return Ok(new
        {
            Token = token,
            User = new
            {
                user.Id,
                user.FullName,
                user.Email,
                user.Role
            }
        });
    }
}
