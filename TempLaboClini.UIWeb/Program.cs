using Microsoft.EntityFrameworkCore;
using TempLaboClini.Application.Interfaces;
using TempLaboClini.Application.Services;
using TempLaboClini.Domain.Entities;
using TempLaboClini.Domain.Interfaces;
using TempLaboClini.Infrastructure.Data;
using TempLaboClini.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configura el contexto de base de datos
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("labConex")));

// Si tienes interfaces genéricas para otros repositorios:
builder.Services.AddScoped<IPacienteRepository, PacienteRepository>();
builder.Services.AddScoped<ISolicitudExamenRepository, SolicitudExamenRepository>();


builder.Services.AddScoped<IExamenRepository, ExamenRepository>();
builder.Services.AddScoped<IExamenSolicitadoLineRepository, ExamenSolicitadoRepository>();
// Add services to the container.
builder.Services.AddControllersWithViews();


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
