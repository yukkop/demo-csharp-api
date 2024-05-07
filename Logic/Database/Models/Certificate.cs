namespace Logic.Database.Models;

// TODO rename Peer
public class Certificate: Base
{
  public Certificate() { }
  
  public string PublicKey { get; set; }
  
  public Guid? ServerId { get; set; }
  public Server? Server { get; set; }

  public ulong ReceiveBytes { get; set; }
  public ulong TransmitBytes { get; set; }
}