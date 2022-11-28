using System.Text.Json;
using System.Text.Json.Serialization;

namespace Program.Models;

public record class Actor
{
    public uint Id { get; set; }
    public string? Login { get; set; }
    [JsonPropertyNameAttribute("gravatar_id")]
    public string? GravatarId { get; set; }
    public string? url { get; set; }
    [JsonPropertyNameAttribute("avatar_url")]
    public string? AvatarUrl { get; set; }
}

public record class Repo
{
    public uint Id { get; set; }
    public string? Name { get; set; }
    public string? Url { get; set; }
}


public record class JData
{
    public string? Id { get; set; }
    public string? Type { get; set; } 
    public Actor? Actor { get; set; }
    public Repo? Repo { get; set; } 
    public JsonElement? Payload { get; set; }
    public bool Public { get; set; }
    [JsonPropertyNameAttribute("created_at")]
    public DateTimeOffset CreatedAt { get; set; }
}
