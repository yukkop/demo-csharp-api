namespace Logic.Database.Models;

public class Bundle: Base
{
    public int MaxEmployees { get; set; }
    public DateTime LastBalanceDecreaseAt { get; set; }
    public int Balance { get; set; }
    public Employer Employer { get; set; }
    public Guid EmployerId { get; set; }
    public List<EmployeeAccess> EmployeeAccesses { get; set; }
}