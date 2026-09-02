using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.LevelGamePlay.Guarantee
{
	// Token: 0x02006E6E RID: 28270
	public class EGuaranteeActionJsonConverter : JsonConverter<EGuaranteeAction>
	{
		// Token: 0x0604497B RID: 280955 RVA: 0x011D5030 File Offset: 0x011D3230
		public override EGuaranteeAction Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EGuaranteeAction.EnablePlayerMoveControl;
			}
			return EGuaranteeActionExtensions.FromString(@string);
		}

		// Token: 0x0604497C RID: 280956 RVA: 0x011D5054 File Offset: 0x011D3254
		public override void Write(Utf8JsonWriter writer, EGuaranteeAction value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
