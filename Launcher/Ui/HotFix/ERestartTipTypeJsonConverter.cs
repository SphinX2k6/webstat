using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Ui.HotFix
{
	// Token: 0x0200451D RID: 17693
	public class ERestartTipTypeJsonConverter : JsonConverter<ERestartTipType>
	{
		// Token: 0x0602E9D6 RID: 190934 RVA: 0x00B0B2A0 File Offset: 0x00B094A0
		public override ERestartTipType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ERestartTipType.HotFixComplete;
			}
			return ERestartTipTypeExtensions.FromString(@string);
		}

		// Token: 0x0602E9D7 RID: 190935 RVA: 0x00B0B2C4 File Offset: 0x00B094C4
		public override void Write(Utf8JsonWriter writer, ERestartTipType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
