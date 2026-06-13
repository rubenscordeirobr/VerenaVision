namespace VerenaVision.Shared.Interfaces.Identities;

public interface ITenantOwned
{
    Guid Tenant_Id { get; }
}
