using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

var databaseName = builder.Configuration["Database"];
switch (databaseName)
{
    case "MSSQL":
        builder.Services.AddDbContext<JulietsStoreDbContext>(options => {
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultMSSQLConnection"),
                o => o.MigrationsAssembly("JulietsStore.Infra"));
        });
        break;
    case "SQLite":
        builder.Services.AddDbContext<JulietsStoreDbContext>(options => {
            options.UseSqlite(builder.Configuration.GetConnectionString("DefaultSQLiteConnection"),
                o => o.MigrationsAssembly("JulietsStore.Infra.Sqlite"));
        });
        break;
}

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<IOrderRepo, OrdersRepo>();
builder.Services.AddScoped<ICart>(x => SessionCart.GetCart(x));
builder.Services.AddServerSideBlazor();
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<JulietsStoreDbContext>();

var app = builder.Build();

if (app.Environment.IsProduction())
{
    app.UseExceptionHandler("/error");
}
else
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
}

app.UseStaticFiles();
app.UseSession();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();
app.MapRazorPages();
app.MapBlazorHub();
app.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");

await SeedData.EnsurePopulated(app);

app.Run();
