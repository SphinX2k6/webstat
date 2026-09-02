using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x020034F9 RID: 13561
public class EBpTypeNameJsonConverter : JsonConverter<EBpTypeName>
{
	// Token: 0x0601CA72 RID: 117362 RVA: 0x00899530 File Offset: 0x00897730
	public override EBpTypeName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return EBpTypeName.DataTableUtil_C;
		}
		return EBpTypeNameExtensions.FromString(@string);
	}

	// Token: 0x0601CA73 RID: 117363 RVA: 0x00899554 File Offset: 0x00897754
	public override void Write(Utf8JsonWriter writer, EBpTypeName value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
