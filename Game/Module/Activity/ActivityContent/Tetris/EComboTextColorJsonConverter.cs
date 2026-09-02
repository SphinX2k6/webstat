using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062F3 RID: 25331
	public class EComboTextColorJsonConverter : JsonConverter<EComboTextColor>
	{
		// Token: 0x0603FAD7 RID: 260823 RVA: 0x01053238 File Offset: 0x01051438
		public override EComboTextColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EComboTextColor.Good;
			}
			return EComboTextColorExtensions.FromString(@string);
		}

		// Token: 0x0603FAD8 RID: 260824 RVA: 0x0105325C File Offset: 0x0105145C
		public override void Write(Utf8JsonWriter writer, EComboTextColor value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
