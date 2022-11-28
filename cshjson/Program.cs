using Program.Models;
using System.Diagnostics;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Program;

[JsonSerializable(typeof(Repo))]
[JsonSerializable(typeof(Actor))]
[JsonSerializable(typeof(JsonElement))]
[JsonSerializable(typeof(JsonDocument))]
[JsonSerializable(typeof(JData))]
[JsonSerializable(typeof(List<JData>))]
internal partial class SourceGenerationContext : JsonSerializerContext
{
}

internal class ChJson
{
    internal const string FILE_NAME = "/home/agyonov/large-file.json";
    internal readonly static JsonSerializerOptions JS_OPT = new JsonSerializerOptions
    {
        AllowTrailingCommas = true,
        DictionaryKeyPolicy = JsonNamingPolicy.CamelCase,
        PropertyNameCaseInsensitive = false,
        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
        ReadCommentHandling = JsonCommentHandling.Skip,
        WriteIndented = false,
        Encoder = JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
        NumberHandling = JsonNumberHandling.AllowReadingFromString,
        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
        TypeInfoResolver = SourceGenerationContext.Default
    };

    static void Main(string[] args)
    {
        // locals
        string str = string.Empty;
        string serialized = string.Empty;
        List<JData>? jData;
        Stopwatch sw = new Stopwatch();

        // Read file
        try {
            using (var sr = new StreamReader(FILE_NAME)) {
                str = sr.ReadToEnd();
            }
            Console.WriteLine($"Read {str.Length} chars");
        } catch (Exception err) {
            Console.WriteLine(err.Message);
            return;
        }

        for (int idx = 0; idx < 50; idx++) {
            // Deserialize
            sw.Restart();
            try {
                jData = JsonSerializer.Deserialize<List<JData>>(str, JS_OPT);
            } catch (JsonException je) {
                Console.WriteLine(je.Message);
                return;
            }
            sw.Stop();
            Console.WriteLine($"Run [{idx}]. Deserialized\t{jData!.Count} records. In {sw.ElapsedMilliseconds} ms.");

            // Serialize
            sw.Restart();
            serialized = JsonSerializer.Serialize(jData, JS_OPT);
            sw.Stop();

            Console.WriteLine($"Run [{idx}]. Seriliazed\t{serialized.Length} chars. In {sw.ElapsedMilliseconds} ms.");
        }
    }
}
