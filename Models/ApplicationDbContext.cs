using Microsoft.EntityFrameworkCore;
using Multi_Tenant_Web.Services;

namespace Multi_Tenant_Web.Models
{

    public class ApplicationDbContext : DbContext
    {
        private readonly ICurrentTenantService _tenantService;
        public string CurrentTenentId { get; set; }
        public ApplicationDbContext(DbContextOptions options, ICurrentTenantService currentTenantService) : base(options)
        {
            _tenantService = currentTenantService;
            CurrentTenentId = _tenantService.TenantId;
        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Tenant> Tenants { get; set; }

        //everytime we save something
        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries<IMustHaveTenant>().ToList())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        case EntityState.Modified:
                        entry.Entity.TenentId = CurrentTenentId;
                        break;
                }
            }
            var result = base.SaveChanges();
            return result;
        }
    }
}
