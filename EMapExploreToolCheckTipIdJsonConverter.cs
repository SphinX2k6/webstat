using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x020034FB RID: 13563
public class EMapExploreToolCheckTipIdJsonConverter : JsonConverter<EMapExploreToolCheckTipId>
{
	// Token: 0x0601CA7B RID: 117371 RVA: 0x0089996C File Offset: 0x00897B6C
	public override EMapExploreToolCheckTipId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return EMapExploreToolCheckTipId.NotHost;
		}
		return EMapExploreToolCheckTipIdExtensions.FromString(@string);
	}

	// Token: 0x0601CA7C RID: 117372 RVA: 0x00899990 File Offset: 0x00897B90
	public override void Write(Utf8JsonWriter writer, EMapExploreToolCheckTipId value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
