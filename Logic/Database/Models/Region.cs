namespace Logic.Database.Models;

public class Region: Base
{
  public Region() { }
  
  public string Name { get; set; }
  public string IsoCountryCode { get; set; }
  
  public IEnumerable<Server> Servers { get; set; }
}