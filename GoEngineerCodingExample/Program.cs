using GoEngineerCodingExample.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<DataContext>(options =>
{
	var connection = builder.Configuration.GetConnectionString("DefaultConnection");

    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

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
	pattern: "{controller=StarShipModels}/{action=Home}/{id?}");

using var scope = app.Services.CreateScope();
IServiceProvider services = scope.ServiceProvider;

try
{
	DataContext context = services.GetRequiredService<DataContext>();
	if (!context.Database.EnsureCreated())
	{
		await context.Database.MigrateAsync();
	}
	await Seed.SeedData(context);
}
catch (Exception ex)
{
	ILogger? logger = services.GetService<ILogger<Program>>();
    logger.LogError(ex, "An error occured during migration");
}

app.Run();
