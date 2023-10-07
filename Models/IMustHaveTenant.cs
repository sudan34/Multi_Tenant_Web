namespace Multi_Tenant_Web.Models
{
    public interface IMustHaveTenant
    {
        public string? TenantId { get; set; }
    }
}
