using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Util
{
	// Token: 0x020044B1 RID: 17585
	public class ESpecialValueJsonConverter : JsonConverter<ESpecialValue>
	{
		// Token: 0x0602E598 RID: 189848 RVA: 0x00AE2B80 File Offset: 0x00AE0D80
		public override ESpecialValue Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ESpecialValue.Undefined;
			}
			return ESpecialValueExtensions.FromString(@string);
		}

		// Token: 0x0602E599 RID: 189849 RVA: 0x00AE2BA4 File Offset: 0x00AE0DA4
		public override void Write(Utf8JsonWriter writer, ESpecialValue value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
