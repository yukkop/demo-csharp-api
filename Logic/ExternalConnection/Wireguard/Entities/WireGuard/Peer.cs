using System.Text.Json.Serialization;

namespace Logic.ExternalConnection.Wireguard.Entities.WireGuard;

public class Peer
{
    [JsonPropertyName("public_key")] public string? PublicKey { get; set; }
    [JsonPropertyName("url_safe_public_key")] public string? UrlSafePublicKey { get; set; }
    [JsonPropertyName("allowed_ips")] public List<string>? AllowedIps { get; set; }
    [JsonPropertyName("last_handshake_time")] public DateTime LastHandshakeTime { get; set; }
    [JsonPropertyName("persistent_keepalive_interval")] public string? PersistentKeepaliveInterval { get; set; }
    [JsonPropertyName("endpoint")] public string? Endpoint { get; set; }
    [JsonPropertyName("receive_bytes")] public ulong ReceiveBytes { get; set; }
    [JsonPropertyName("transmit_bytes")] public ulong TransmitBytes { get; set; }
}