using System.Runtime.Intrinsics;

namespace TestAotTips.Models.Json;

/// <summary>
/// カスタムコンバーターの使い分けが不要の場合は、[JsonConverter(typeof(RgbaConverter))] を使用する
/// </summary>
internal class Rgba
{
	private readonly Vector128<Single> _value;

	public Rgba(Single red, Single green, Single blue, Single alpha = 1.0f)
	{
		_value = Vector128.Create(red, green, blue, alpha);
	}

	public float R => _value.GetElement(0);

	public float G => _value.GetElement(1);

	public float B => _value.GetElement(2);

	public float A => _value.GetElement(3);
}
