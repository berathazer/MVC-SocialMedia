using System.Globalization;
using System.Reflection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Options;
using SocialMedia.Business.Abstract;
using SocialMedia.Business.Concrete;

using SocialMedia.DataAccess.Abstract;
using SocialMedia.DataAccess.Concrete;
using SocialMedia.DataAccess.Concrete.EfCore;

using SocialMedia.WebUI.Services;

var builder = WebApplication.CreateBuilder(args);

#region Localizer
builder.Services.AddSingleton<LanguageService>();
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");
builder.Services.AddMvc().AddViewLocalization().AddDataAnnotationsLocalization(options =>
    options.DataAnnotationLocalizerProvider = (type, factory) =>
    {
        var assemblyName = new AssemblyName(typeof(SharedResource).GetTypeInfo().Assembly.FullName!);
        return factory.Create(nameof(SharedResource), assemblyName.Name!);
    });

builder.Services.Configure<RequestLocalizationOptions>(options =>
{
    var supportCultures = new List<CultureInfo>
    {
        new CultureInfo("en-US"),
        new CultureInfo("tr-TR"),
    };
    options.DefaultRequestCulture = new RequestCulture(culture: "tr-TR", uiCulture: "tr-TR");
    options.SupportedCultures = supportCultures;
    options.SupportedUICultures = supportCultures;
    options.RequestCultureProviders.Insert(0, new QueryStringRequestCultureProvider());
});
#endregion

// IConfiguration ekleniyor
builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.Cookie.Name = "MVC.Auth-Cookie";
            options.LoginPath = "/Auth/Login"; // Kullanıcı giriş yapmadığında yönlendirilecek sayfa
            options.AccessDeniedPath = "/Auth/AccessDenied"; // Yetkisiz erişim durumunda yönlendirilecek sayfa
            options.ExpireTimeSpan = TimeSpan.FromDays(1); // Oturum süresi
            options.SlidingExpiration = true; // Oturum süresini uzatma
        });


//Signletons
builder.Services.AddSingleton<IUserRepository, EfUserRepository>();
builder.Services.AddSingleton<IUserService, UserManager>();
builder.Services.AddScoped<IAuthService, AuthManager>();

var app = builder.Build();

// geliştirme modunda olması gereken kısımlar
if (app.Environment.IsDevelopment())
{
    await SeedDatabase.Seed();
    app.UseDeveloperExceptionPage();
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRequestLocalization(app.Services.GetRequiredService<IOptions<RequestLocalizationOptions>>().Value);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
