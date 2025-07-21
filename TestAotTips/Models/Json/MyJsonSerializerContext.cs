using System.Text.Json.Serialization;

namespace TestAotTips.Models.Json;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(AddressBook))]
[JsonSerializable(typeof(Rgba))]
internal partial class MyJsonSerializerContext : JsonSerializerContext
{
}
