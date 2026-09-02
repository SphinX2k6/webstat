using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.AutoPilot
{
	// Token: 0x02006151 RID: 24913
	public class AutoPilotDefine_EAutoPilotResourceIdJsonConverter : JsonConverter<AutoPilotDefine.EAutoPilotResourceId>
	{
		// Token: 0x0603EF43 RID: 257859 RVA: 0x01023060 File Offset: 0x01021260
		public override AutoPilotDefine.EAutoPilotResourceId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return AutoPilotDefine.EAutoPilotResourceId.AutoPilotNavBtn;
			}
			return AutoPilotDefine_EAutoPilotResourceIdExtensions.FromString(@string);
		}

		// Token: 0x0603EF44 RID: 257860 RVA: 0x01023084 File Offset: 0x01021284
		public override void Write(Utf8JsonWriter writer, AutoPilotDefine.EAutoPilotResourceId value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
