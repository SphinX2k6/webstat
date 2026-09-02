using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044B3 RID: 17587
	public class EMetaTypeJsonConverter : JsonConverter<EMetaType>
	{
		// Token: 0x0602E5A1 RID: 189857 RVA: 0x00AE2C94 File Offset: 0x00AE0E94
		public override EMetaType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EMetaType.Map;
			}
			return EMetaTypeExtensions.FromString(@string);
		}

		// Token: 0x0602E5A2 RID: 189858 RVA: 0x00AE2CB8 File Offset: 0x00AE0EB8
		public override void Write(Utf8JsonWriter writer, EMetaType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
