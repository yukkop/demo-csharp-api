using Logic.Library;

namespace Logic.Model.Dto.Region;

public interface IRegionResponse
{

}

public class RegionResponseException : Exception, IRegionResponse
{

}

public class RegionResponseModel : IRegionResponse
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? IsoCountryCode { get; set; }

    public override bool Equals(object obj)
    {
        return Comparator.Equals<RegionResponseModel>(this, obj as RegionResponseModel);
    }
}
