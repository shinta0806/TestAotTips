using System.Text.Json.Serialization;

namespace TestAotTips.Models.Json;

/// <summary>
/// Rgba にカスタムコンバーターは使用しない（書き込み用）
/// </summary>
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true)]
[JsonSerializable(typeof(AddressBook))]
[JsonSerializable(typeof(Rgba))]
internal partial class MyJsonSerializerContext : JsonSerializerContext
{
}

/// <summary>
/// Rgba をカスタムコンバーターを使用して読み込む
/// </summary>
[JsonSourceGenerationOptions(PropertyNameCaseInsensitive = true, Converters = [typeof(RgbaConverter)])]
[JsonSerializable(typeof(Rgba))]
internal partial class RgbaReadJsonSerializerContext : JsonSerializerContext
{
}
