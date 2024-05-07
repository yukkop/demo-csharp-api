namespace Logic.Database.Models;

public class EmployeeAccess: Base
{
    public Bundle Bundle { get; set; }
    public Guid BundleId { get; set; }
    public VpnUser? VpnUser { get; set; }
    public Guid? VpnUserId { get; set; }
    public Guid Code { get; set; }
    public bool IsDelete { get; set; }
}