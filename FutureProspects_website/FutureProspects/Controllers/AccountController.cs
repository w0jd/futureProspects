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
/*        public IActionResult Login()
        {
            return View();
        }*/
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
            return RedirectToAction("Index", "Account");
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
        private async Task SignInUser(string username)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),//tworzy coś w rodzaju obiektu o tuch wartościach
                /**///new Claim("MyCustomClaim", "my claim value")
            };

            var claimsIdentity = new ClaimsIdentity(
                claims, CookieAuthenticationDefaults.AuthenticationScheme);//tworzy obiekt reprezentujący tożsamość uzytkownika składjący się z jego nazwy i typu uwierzytenienia 

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity));// zapisuje informacje o użytkownkiu w pliku cookie  claimsPrincipal reprezentuje identyfkacje i autoryzację użytkownika 
        }
        public async Task <IActionResult> Login(UserLoginRequest request)// w ajkiś sposób utworzenie w tym momęcie obiektu dopisuje do niego pasujące dane z formularza
        {
            var user =_context.Employees.First(u=>u.Email == request.email);
            if (user == null)
            {
                TempData["success"] = "user not found";
                return RedirectToAction("Index", "Home");
            }
        /*    if (user.VerifiedAt == null)
            {
                return BadRequest("not verified");
            }*/
            if (!VerifyPasswordHash(request.password, user.PasswordHash,user.PasswordSalt)) {
                TempData["success"]="wrong password";
                return RedirectToAction("Index", "Home");

            }
            await SignInUser(user.Email);
            var username = HttpContext.User.Identity.Name;
            var u = username;
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
