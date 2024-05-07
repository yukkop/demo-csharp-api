namespace Logic.Model.Dto.Server;

public class AddServerRequestModel
{
    public string Ip { get; set; }
    public string Port { get; set; }
    public string Name { get; set; }
    public Guid RegionId { get; set; }
}