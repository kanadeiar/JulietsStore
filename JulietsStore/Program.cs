var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<JulietsStoreDbContext>(options => {
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();
builder.Services.AddScoped<IProductsRepo, ProductsRepo>();
builder.Services.AddScoped<ICart>(x => SessionCart.GetCart(x));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

app.UseDeveloperExceptionPage();
app.UseStatusCodePages();

app.UseStaticFiles();

app.UseSession();
app.UseRouting();
app.MapDefaultControllerRoute();
app.MapRazorPages();

await SeedData.EnsurePopulated(app);

app.Run();
