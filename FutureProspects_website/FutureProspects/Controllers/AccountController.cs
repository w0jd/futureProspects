﻿using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;

namespace FutureProspects.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult registerEmployee()
        {
            return View();
        }
        public IActionResult registerEmployer()
        {
            return View();
        }
        private readonly ApplicationDbContext _context;
        public AccountController(ApplicationDbContext context)
        {
            _context = context;
          

       }
    [HttpPost("Register")]
        public IActionResult Register(UserRegisterRequest request)// w ajkiś sposób utworzenie w tym momęcie obiektu dopisuje do niego pasujące dane z formularza
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
                Phone =  request.phone,
                Email = request.email,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                VerificationToken = CreateRandomToken()
            };
            _context.Employees.Add(user);
            _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");
        }

        private void CreatePasswordHash(string password,
                                        out byte[] passwordHash,
                                        out byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));

            }
        }
        private string CreateRandomToken()
        {
            return Convert.ToHexString(RandomNumberGenerator.GetBytes(64));
        }


    }
}
