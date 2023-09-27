using ControleProdutosQ3Retomada.Data;
using ControleProdutosQ3Retomada.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorPages()
 .AddMvcOptions(options =>
 {
     options.MaxModelValidationErrors = 50;
     options.ModelBindingMessageProvider.SetValueMustNotBeNullAccessor(
     _ => "Este campo � obrigat�rio.");
 });

builder.Services.AddDbContext<BancoContext>(
	o => o.UseSqlServer(
			builder.Configuration.GetConnectionString("Database")
		)
	);

builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();

// Add services to the container.
builder.Services.AddControllersWithViews();

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
