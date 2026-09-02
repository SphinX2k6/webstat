using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x02003503 RID: 13571
public class ERedDotNameJsonConverter : JsonConverter<ERedDotName>
{
	// Token: 0x0601CA9F RID: 117407 RVA: 0x0089FF8C File Offset: 0x0089E18C
	public override ERedDotName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return ERedDotName.Test;
		}
		return ERedDotNameExtensions.FromString(@string);
	}

	// Token: 0x0601CAA0 RID: 117408 RVA: 0x0089FFB0 File Offset: 0x0089E1B0
	public override void Write(Utf8JsonWriter writer, ERedDotName value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
