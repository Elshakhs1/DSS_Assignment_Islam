using DSS_Assignment_Islam.Repository;
using DSS_Assignment_Islam.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DBContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConnectionStr")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddTransient<ICircus, CircusRepository>();
builder.Services.AddTransient<IActor, ActorRepository>();
builder.Services.AddTransient<IAct, ActRepository>();
builder.Services.AddTransient<ITrick, TrickRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
