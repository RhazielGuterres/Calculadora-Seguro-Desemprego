using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProjetoCalculadoraSeguroDesemprego.Interfaces;
using ProjetoCalculadoraSeguroDesemprego.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar servi�os ao cont�iner.
builder.Services.AddControllersWithViews();

// Adicionar inje��o de depend�ncia
builder.Services.AddTransient<ICalculoSeguroDesemprego, CalculoSeguroDesemprego>();
builder.Services.AddTransient<ICalculoMesesTrabalhados, CalculoMesesTrabalhados>();
builder.Services.AddTransient<CalculoSeguroDesempregoService>();

var app = builder.Build();

// Configurar o pipeline de requisi��o HTTP.
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
