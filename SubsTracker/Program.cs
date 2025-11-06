using Microsoft.EntityFrameworkCore;
using SubsTracker.Database;
using SubsTracker.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure the database context to use SQL Server with a connection string.
builder.Services.AddDbContext<SubsTrackerContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Integrated Security=true"));

// Add a developer exception page for database-related exceptions.
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Add Services to the container.
builder.Services.AddTransient<ISubscriptionService, SubscriptionService>();

var app = builder.Build();

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
