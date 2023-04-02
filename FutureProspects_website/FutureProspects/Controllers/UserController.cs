using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FutureProspects.Data;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Identity;
using FutureProspects.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FutureProspects.Controllers
{
 [Route("api/[controller]")]/**/
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }
       [HttpPost("Register")]
        public async Task<IActionResult> Register(UserRegisterRequest request)
        {
            if (_context.Employees.Any(u => u.Email == request.email))
            {
                return BadRequest("User lready exist");
            }
            CreatePasswordHash(request.password, out byte[] passwordHash, out byte[] passwordSalt);
            var user = new Employee
            {
                Name = request.name,
                Surname = request.surname,
                City = request.city,
                Degree = request.degree,
                university = request.university,
                Phone = request.phone,
             


                Email = request.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };
            _context.Employees.Add(user);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }
        
        private void CreatePasswordHash(string password,
                                        out byte[] passwordHash,
                                        out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512()) {
                passwordSalt = hmac.Key;
                passwordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
        private string CreateRandomToken()
         {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
         }
    }
}
