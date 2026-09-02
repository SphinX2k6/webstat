using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068CD RID: 26829
	public class EDropCatchTextIdJsonConverter : JsonConverter<EDropCatchTextId>
	{
		// Token: 0x06042B7F RID: 273279 RVA: 0x0111FE30 File Offset: 0x0111E030
		public override EDropCatchTextId Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchTextId.TextScoreLevel;
			}
			return EDropCatchTextIdExtensions.FromString(@string);
		}

		// Token: 0x06042B80 RID: 273280 RVA: 0x0111FE54 File Offset: 0x0111E054
		public override void Write(Utf8JsonWriter writer, EDropCatchTextId value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
