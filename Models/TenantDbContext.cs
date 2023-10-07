using Microsoft.EntityFrameworkCore;

namespace Multi_Tenant_Web.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext(DbContextOptions<TenantDbContext> options): base(options)
        {
        }
        public DbSet<Tenant> Tenants { get; set; }    
    }
}
