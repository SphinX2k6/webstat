using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x02006586 RID: 25990
	public class EPreWarmTxtJsonConverter : JsonConverter<EPreWarmTxt>
	{
		// Token: 0x06040E8E RID: 265870 RVA: 0x010A7294 File Offset: 0x010A5494
		public override EPreWarmTxt Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EPreWarmTxt.RewardTxtUnFinish;
			}
			return EPreWarmTxtExtensions.FromString(@string);
		}

		// Token: 0x06040E8F RID: 265871 RVA: 0x010A72B8 File Offset: 0x010A54B8
		public override void Write(Utf8JsonWriter writer, EPreWarmTxt value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
