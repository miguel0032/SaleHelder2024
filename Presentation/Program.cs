using Microsoft.EntityFrameworkCore;
using Presentation.Data;
using SaleHelder.Application;

var builder = WebApplication.CreateBuilder(args);

// Inyectando dependencias --richard
builder.Services.AddInfrastructureLayer(builder.Configuration);

// Resto del código de configuración
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();
builder.Services.AddApplicationLayer();
builder.Services.AddSession();
builder.Services.AddMvc();
var app = builder.Build();

// Configuración del pipeline de solicitud HTTP y enrutamiento
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
