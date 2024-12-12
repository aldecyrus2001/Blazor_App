using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using API.Services;
using API.Models;
using Microsoft.AspNetCore.Identity.Data;


namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private readonly ApplicationDbContext _context;
        private readonly PasswordHasher<Administrator> _passwordHasher;


        public AuthController(ApplicationDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<Administrator>();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest loginRequest)
        {
            if (string.IsNullOrEmpty(loginRequest.Email) || string.IsNullOrEmpty(loginRequest.Password))
            {
                return BadRequest("Email and password are required.");
            }

            var administrator = await _context.Administrators
                .FirstOrDefaultAsync(a => a.email == loginRequest.Email && a.isDeleted == "0");

            if (administrator == null)
            {
                return Unauthorized("Invalid email or password.");
            }

            // Compare the provided password with the stored password hash
            var result = _passwordHasher.VerifyHashedPassword(administrator, administrator.password, loginRequest.Password);
            if (result != PasswordVerificationResult.Success)
            {
                return Unauthorized("Invalid email or password.");
            }

            // If login is successful, return the adminID and a message
            return Ok(new { message = "Login successful", adminID = administrator.adminID });
        }
    }
}
