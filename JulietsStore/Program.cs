var builder = WebApplication.CreateBuilder(args);

builder.Host.ConfigureServices(x => 
{
    x.AddControllersWithViews();
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseStaticFiles();
app.MapDefaultControllerRoute();

app.Run();
