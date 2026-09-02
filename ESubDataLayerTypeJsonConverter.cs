using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x02003509 RID: 13577
public class ESubDataLayerTypeJsonConverter : JsonConverter<ESubDataLayerType>
{
	// Token: 0x0601CABA RID: 117434 RVA: 0x008A0418 File Offset: 0x0089E618
	public override ESubDataLayerType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return ESubDataLayerType.Default;
		}
		return ESubDataLayerTypeExtensions.FromString(@string);
	}

	// Token: 0x0601CABB RID: 117435 RVA: 0x008A043C File Offset: 0x0089E63C
	public override void Write(Utf8JsonWriter writer, ESubDataLayerType value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
