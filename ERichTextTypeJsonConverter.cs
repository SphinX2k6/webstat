using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x02003505 RID: 13573
public class ERichTextTypeJsonConverter : JsonConverter<ERichTextType>
{
	// Token: 0x0601CAA8 RID: 117416 RVA: 0x008A0170 File Offset: 0x0089E370
	public override ERichTextType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return ERichTextType.PlayerName;
		}
		return ERichTextTypeExtensions.FromString(@string);
	}

	// Token: 0x0601CAA9 RID: 117417 RVA: 0x008A0194 File Offset: 0x0089E394
	public override void Write(Utf8JsonWriter writer, ERichTextType value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
