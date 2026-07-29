using Logistics.Core;
using Logistics.UI.Components.Layout;
using Logistics.Web.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddLogisticsCore();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

//app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode()
    // Server-side routing builds its endpoints from the assemblies listed here; the
    // <Router> in Routes.razor only covers routing once the app is interactive.
    .AddAdditionalAssemblies(typeof(MainLayout).Assembly);

app.Run();
