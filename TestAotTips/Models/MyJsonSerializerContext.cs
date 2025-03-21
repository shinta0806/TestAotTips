using System.Text.Json.Serialization;

namespace TestAotTips.Models;

[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(AddressBook))]
internal partial class MyJsonSerializerContext : JsonSerializerContext
{
}
