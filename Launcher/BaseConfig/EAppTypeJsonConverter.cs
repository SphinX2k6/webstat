using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004696 RID: 18070
	public class EAppTypeJsonConverter : JsonConverter<EAppType>
	{
		// Token: 0x0602F09F RID: 192671 RVA: 0x00B25738 File Offset: 0x00B23938
		public override EAppType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EAppType.DEVELOPMENT;
			}
			return EAppTypeExtensions.FromString(@string);
		}

		// Token: 0x0602F0A0 RID: 192672 RVA: 0x00B2575C File Offset: 0x00B2395C
		public override void Write(Utf8JsonWriter writer, EAppType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
