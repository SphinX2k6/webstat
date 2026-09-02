using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.BaseConfig
{
	// Token: 0x02004692 RID: 18066
	public class TBuildInfoKeyJsonConverter : JsonConverter<TBuildInfoKey>
	{
		// Token: 0x0602F08D RID: 192653 RVA: 0x00B25144 File Offset: 0x00B23344
		public override TBuildInfoKey Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return TBuildInfoKey.BuildId;
			}
			return TBuildInfoKeyExtensions.FromString(@string);
		}

		// Token: 0x0602F08E RID: 192654 RVA: 0x00B25168 File Offset: 0x00B23368
		public override void Write(Utf8JsonWriter writer, TBuildInfoKey value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
