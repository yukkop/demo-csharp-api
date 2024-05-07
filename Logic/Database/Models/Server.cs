using System.ComponentModel.DataAnnotations.Schema;

namespace Logic.Database.Models;

public class Server: Base
{
  public Server() { }

  // TODO add protocol field { http, https }
  public string Port { get; set; }
  public string Ip { get; set; }
  public string Name { get; set; }
  public int CountUsers { get; set; }
  
  public Guid RegionId { get; set; }
  public Region Region { get; set; }

  [NotMapped] public string Host => $"{Ip}:{Port}";
}