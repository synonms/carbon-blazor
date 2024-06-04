namespace Synonms.CarbonBlazor.Infrastructure.MultiTenancy;

public class TenantSelector
{
    public event EventHandler? TenantSelected;

    public Guid SelectedTenantId { get; private set; } = Guid.Empty;

    public string SelectedTenantName { get; private set; } = string.Empty;

    public void Select(Guid id, string name)
    {
        SelectedTenantId = id;
        SelectedTenantName = name;
        
        TenantSelected?.Invoke(this, EventArgs.Empty);
    }
    
    public bool IsTenantSelected => SelectedTenantId != Guid.Empty;
}