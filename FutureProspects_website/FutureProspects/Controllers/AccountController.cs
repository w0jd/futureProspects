using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Login()
        {
            return View();
        }
        public IActionResult Index()
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
            return RedirectToAction("Index","Account");
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
        [HttpPost("Login")]
        public IActionResult Login(UserLoginRequest request)// w ajkiś sposób utworzenie w tym momęcie obiektu dopisuje do niego pasujące dane z formularza
        {
            if(_context.Employees.Any(u => u.Name == request.email)){
               Console.WriteLine(_context.Employees.FirstOrDefaultAsync(u => u.Email == request.email));
            }
            var user =_context.Employees.First(u=>u.Email == request.email);
            if (user == null)
            {
                return BadRequest("User not found");
            }
        /*    if (user.VerifiedAt == null)
            {
                return BadRequest("not verified");
            }*/
            if (!VerifyPasswordHash(request.password, user.PasswordHash,user.PasswordSalt)) {
                return BadRequest("wrong password");
            }
            TempData["success"] = $"logged as {user.Email}";
            return RedirectToAction("Index", "Home");
        }
        private bool VerifyPasswordHash(string password,
                                        byte[] passwordHash,
                                       byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                return computedHash.SequenceEqual(passwordHash);
            }
        }
    }
}
