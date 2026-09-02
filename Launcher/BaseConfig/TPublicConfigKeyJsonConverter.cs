using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004694 RID: 18068
	public class TPublicConfigKeyJsonConverter : JsonConverter<TPublicConfigKey>
	{
		// Token: 0x0602F096 RID: 192662 RVA: 0x00B255E0 File Offset: 0x00B237E0
		public override TPublicConfigKey Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return TPublicConfigKey.AppTag;
			}
			return TPublicConfigKeyExtensions.FromString(@string);
		}

		// Token: 0x0602F097 RID: 192663 RVA: 0x00B25604 File Offset: 0x00B23804
		public override void Write(Utf8JsonWriter writer, TPublicConfigKey value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
