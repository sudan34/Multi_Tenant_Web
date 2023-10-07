using Microsoft.EntityFrameworkCore;
using Multi_Tenant_Web.Models;

namespace Multi_Tenant_Web.Services
{
    public class CurrentTenantService : ICurrentTenantService
    {
        private readonly ApplicationDbContext _context;

        public CurrentTenantService(ApplicationDbContext context)
        {
            _context = context;
        }

        public string? TenantId {get; set; }

        public async Task<bool> SetTanant(string tenantId)
        {
            var tenantInfo = await _context.Tenants.Where(x=>x.Id == tenantId).FirstOrDefaultAsync();
            if (tenantInfo != null)
            {
                TenantId = tenantInfo.Id;
                return true;
            }
            else
            {
                throw new Exception("Tenant invalid");
            }
        }
    }
}
