using System.Runtime.Intrinsics;
using System.Text.Json.Serialization;

namespace TestAotTips.Models.Json;

[JsonConverter(typeof(RgbaConverter))]
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
