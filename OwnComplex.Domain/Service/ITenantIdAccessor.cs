namespace OwnComplex.Domain.Service;

public interface ITenantIdAccessor
{
    Guid GetTenantId();
    void SetTenantId(Guid tenantId);
}

public class TenantIdAccessor : ITenantIdAccessor
{
    private Guid _currentTenant = new();

    public Guid GetTenantId()
    {
        return _currentTenant;
    }

    public void SetTenantId(Guid tenantId)
    {
        _currentTenant = tenantId;
    }
}