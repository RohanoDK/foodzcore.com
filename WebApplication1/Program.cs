using foodzcore.Data;
using foodzcore.Services.AccountServices;
using foodzcore.Services.LoginServices;
using foodzcore.Services.RecipeServices;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;



var builder = WebApplication.CreateBuilder(args);

// Services added to the DI-container.
builder.Services.AddRazorPages();
builder.Services.AddScoped<AccountCreateService>();
builder.Services.AddScoped<AccountReadService>();
builder.Services.AddScoped<AccountUpdateService>();
builder.Services.AddScoped<AccountDeleteService>();
builder.Services.AddScoped<RecipeCreateService>();
builder.Services.AddScoped<RecipeReadService>();
builder.Services.AddScoped<RecipeUpdateService>();
builder.Services.AddScoped<RecipeDeleteService>();
builder.Services.AddScoped<foodzcoreAuthenticationService>();
builder.Services.AddDbContext<foodzcoreEFDBContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.Configure<CookiePolicyOptions>(options => {
    // This lambda determines whether user consent for non-essential cookies is needed for a given request. options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.None;

});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(cookieOptions => {
    cookieOptions.LoginPath = "/Login";
    cookieOptions.Cookie.SecurePolicy = CookieSecurePolicy.Always; // Set the Secure attribute
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHttpsRedirection();
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseStaticFiles();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints => {
    endpoints.MapRazorPages();
});

app.Run();
