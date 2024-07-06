using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoCalculadoraSeguroDesemprego.Interfaces;
using ProjetoCalculadoraSeguroDesemprego.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar serviços ao contêiner.
builder.Services.AddControllersWithViews();

// Adicionar injeção de dependência
builder.Services.AddTransient<ICalculadoraSeguroDesempregoService, CalculoraSeguroDesempregoService>();
builder.Services.AddTransient<ICalculadoraMesesTrabalhadosService, CalculadoraMesesTrabalhadosService>();
builder.Services.AddTransient<ICalculoSeguroDesempregoService, CalculoSeguroDesempregoService>();

var app = builder.Build();

// Configurar o pipeline de requisição HTTP.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
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
