// ============================================================================
// 
// Rgba を JSON から読み込むコンバーター
// 
// ============================================================================

// ----------------------------------------------------------------------------
// Rgba には各要素の setter が無く標準ではデシリアライズできないため、カスタムコンバーターでの対応が必要
// ----------------------------------------------------------------------------

using System.Text.Json;
using System.Text.Json.Serialization;

namespace TestAotTips.Models.Json;

internal class RgbaConverter : JsonConverter<Rgba>
{
	public override Rgba Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		Single r = 0.0f;
		Single g = 0.0f;
		Single b = 0.0f;
		Single a = 1.0f;

		while (reader.Read())
		{
			if (reader.TokenType == JsonTokenType.EndObject)
			{
				break;
			}
			if (reader.TokenType != JsonTokenType.PropertyName)
			{
				continue;
			}
			String? propertyName = reader.GetString();
			if (!reader.Read())
			{
				break;
			}
			if (reader.TokenType != JsonTokenType.Number)
			{
				continue;
			}
			Single propertyValue = reader.GetSingle();
			switch (propertyName)
			{
				case nameof(Rgba.R):
					r = propertyValue;
					break;
				case nameof(Rgba.G):
					g = propertyValue;
					break;
				case nameof(Rgba.B):
					b = propertyValue;
					break;
				case nameof(Rgba.A):
					a = propertyValue;
					break;
			}
		}
		return new Rgba(r, g, b, a);
	}

	public override void Write(Utf8JsonWriter writer, Rgba value, JsonSerializerOptions options)
	{
		// シリアライズではカスタムコンバーター不要なので実装しない
		throw new NotImplementedException();

#if false
		// 仮に実装するならこんな感じ
		if (value is null)
		{
			writer.WriteNullValue();
			return;
		}

		writer.WriteStartObject();

		writer.WriteNumber(nameof(Rgba.R), value.R);
		writer.WriteNumber(nameof(Rgba.G), value.G);
		writer.WriteNumber(nameof(Rgba.B), value.B);
		writer.WriteNumber(nameof(Rgba.A), value.A);

		writer.WriteEndObject();
#endif
	}
}
