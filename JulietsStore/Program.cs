var builder = WebApplication.CreateBuilder(args);

builder.WebHost.ConfigureServices(x => 
{
    x.AddDbContext<JulietsStoreDbContext>(options => {
        options.UseSqlServer(builder.Configuration.GetConnectionString("JulietsStoreConnection"));
    });
    x.AddControllersWithViews();
    builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
});

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseStaticFiles();

app.UseRouting();
app.MapDefaultControllerRoute();

await SeedData.EnsurePopulated(app);

app.Run();
