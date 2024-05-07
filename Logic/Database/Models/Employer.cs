namespace Logic.Database.Models;

public class Employer: Base
{
    public User User { get; set; }
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Website { get; set; }
}