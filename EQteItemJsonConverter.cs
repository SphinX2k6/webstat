using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x020034FF RID: 13567
public class EQteItemJsonConverter : JsonConverter<EQteItem>
{
	// Token: 0x0601CA8D RID: 117389 RVA: 0x00899FF0 File Offset: 0x008981F0
	public override EQteItem Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return EQteItem.SingleClickItem;
		}
		return EQteItemExtensions.FromString(@string);
	}

	// Token: 0x0601CA8E RID: 117390 RVA: 0x0089A014 File Offset: 0x00898214
	public override void Write(Utf8JsonWriter writer, EQteItem value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
