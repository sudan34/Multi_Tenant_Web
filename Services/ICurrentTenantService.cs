namespace Multi_Tenant_Web.Services
{
    public interface ICurrentTenantService
    {
        string? TenantId { get; set; }
        public Task<bool> SetTanant(string tenantId);

    }
}
