using System;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x020034FD RID: 13565
public class EMapExploreToolUseTipIdJsonConverter : JsonConverter<EMapExploreToolUseTipId>
{
	// Token: 0x0601CA84 RID: 117380 RVA: 0x00899A80 File Offset: 0x00897C80
	public override EMapExploreToolUseTipId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		string @string = reader.GetString();
		if (string.IsNullOrEmpty(@string))
		{
			return EMapExploreToolUseTipId.MapExploreToolDeploySuccess;
		}
		return EMapExploreToolUseTipIdExtensions.FromString(@string);
	}

	// Token: 0x0601CA85 RID: 117381 RVA: 0x00899AA4 File Offset: 0x00897CA4
	public override void Write(Utf8JsonWriter writer, EMapExploreToolUseTipId value, JsonSerializerOptions options)
	{
		writer.WriteStringValue(value.ToEnumString());
	}
}
