// dotnet ef --startup-project ../JulietsStore/ migrations add init --context JulietsStoreDbContext

namespace JulietsStore.Infra.Data;

public class JulietsStoreDbContext : DbContext
{
    public DbSet<Product> Products => Set<Product>();
    public DbSet<Order> Orders => Set<Order>();
    public JulietsStoreDbContext(DbContextOptions<JulietsStoreDbContext> options) : base(options)
    { }
}