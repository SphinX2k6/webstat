using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x02003507 RID: 13575
public class EDataLayerTypeJsonConverter : JsonConverter<EDataLayerType>
{
	// Token: 0x0601CAB1 RID: 117425 RVA: 0x008A02C4 File Offset: 0x0089E4C4
	public override EDataLayerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return EDataLayerType.Default;
		}
		return EDataLayerTypeExtensions.FromString(@string);
	}

	// Token: 0x0601CAB2 RID: 117426 RVA: 0x008A02E8 File Offset: 0x0089E4E8
	public override void Write(Utf8JsonWriter writer, EDataLayerType value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
