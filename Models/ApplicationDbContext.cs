using Microsoft.EntityFrameworkCore;
using Multi_Tenant_Web.Services;

namespace Multi_Tenant_Web.Models
{

    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentTenantService _tenantService;
        public string CurrentTenantId { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, ICurrentTenantService currentTenantService) : base(options)
        {
            _tenantService = currentTenantService;
            CurrentTenantId = _tenantService.TenantId;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        // on app startup
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Product>().HasQueryFilter(a=>a.TenantId == CurrentTenantId);
        }
        //everytime we save something
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        case EntityState.Modified:
                        entry.Entity.TenantId = CurrentTenantId;
                        break;
                }
            }
            var result = base.SaveChanges();
            return result;
        }
    }
}
