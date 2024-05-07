namespace logic.Model.Dto.Employee;

public class EmployeeAccessRequestModel
{
    public Guid Id { get; set; }
    public Guid Code { get; set; }
    public Guid? UserId { get; set; }
}