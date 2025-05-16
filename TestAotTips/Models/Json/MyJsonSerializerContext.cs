using System.Text.Json.Serialization;

namespace TestAotTips.Models.Json;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(AddressBook))]
internal partial class MyJsonSerializerContext : JsonSerializerContext
{
}
