using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x020034F7 RID: 13559
public class ELogLevelJsonConverter : JsonConverter<ELogLevel>
{
	// Token: 0x0601CA69 RID: 117353 RVA: 0x00898D60 File Offset: 0x00896F60
	public override ELogLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return ELogLevel.Error;
		}
		return ELogLevelExtensions.FromString(@string);
	}

	// Token: 0x0601CA6A RID: 117354 RVA: 0x00898D84 File Offset: 0x00896F84
	public override void Write(Utf8JsonWriter writer, ELogLevel value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
