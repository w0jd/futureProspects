var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
/*builder.Services.AddRazorPages().AddRazorRuntimeCompilation();*/

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                // Specify where to redirect un-authenticated users
                options.LoginPath = "/Account/Index";

                // Specify the name of the auth cookie.
                // ASP.NET picks a dumb name by default.
                options.Cookie.Name = "my_app_auth_cookie";
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


// Configure cookie based authentication

  


    // Configure authentication.
    // This should be done before app.UseEndpoints() is called!
    app.UseAuthentication();
    app.UseAuthorization();

    // ...snip... Other ASP.NET Core configuration here!

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
