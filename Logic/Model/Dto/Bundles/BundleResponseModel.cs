namespace logic.Model.Dto.Bundles;

public class BundleResponseModel
{
    public Guid Id { get; set; }
    public int MaxEmployees { get; set; }
    // public List<EmployeeAccessRequestModel> EmployeeAccesses { get; set; }
    public DateTime LastBalanceDecreaseAt { get; set; }
    public int Balance { get; set; }
}