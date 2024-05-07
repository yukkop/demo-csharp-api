using Logic.Library;
using Logic.Model.Dto.Region;

namespace Logic.Model.Dto.Server;

public class ServerResponseModel
{
    public string Id { get; set; }
    public string Ip { get; set; }
    public string Port { get; set; }
    public string Name { get; set; }
    public int CountUsers { get; set; }
    public RegionResponseModel Region { get; set; }
    
    public override bool Equals(object obj)
    {
        return Comparator.Equals<ServerResponseModel>(this, obj as ServerResponseModel);
    }
}