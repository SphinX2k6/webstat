using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x02004669 RID: 18025
	public class EResFileJsonConverter : JsonConverter<EResFile>
	{
		// Token: 0x0602F007 RID: 192519 RVA: 0x00B22720 File Offset: 0x00B20920
		public override EResFile Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EResFile.PAK;
			}
			return EResFileExtensions.FromString(@string);
		}

		// Token: 0x0602F008 RID: 192520 RVA: 0x00B22744 File Offset: 0x00B20944
		public override void Write(Utf8JsonWriter writer, EResFile value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
