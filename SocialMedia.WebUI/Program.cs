using SocialMedia.Business.Abstract;
using SocialMedia.Business.Concrete;

using SocialMedia.DataAccess.Abstract;
using SocialMedia.DataAccess.Concrete;
using SocialMedia.DataAccess.Concrete.EfCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Signletons
builder.Services.AddSingleton<IUserRepository, EfUserRepository>();
builder.Services.AddSingleton<IUserService, UserManager>();


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

app.UseRouting();

app.UseAuthorization();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
