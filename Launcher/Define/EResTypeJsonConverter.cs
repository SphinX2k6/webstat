using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Define
{
	// Token: 0x0200466B RID: 18027
	public class EResTypeJsonConverter : JsonConverter<EResType>
	{
		// Token: 0x0602F010 RID: 192528 RVA: 0x00B228D8 File Offset: 0x00B20AD8
		public override EResType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EResType.Launcher;
			}
			return EResTypeExtensions.FromString(@string);
		}

		// Token: 0x0602F011 RID: 192529 RVA: 0x00B228FC File Offset: 0x00B20AFC
		public override void Write(Utf8JsonWriter writer, EResType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
