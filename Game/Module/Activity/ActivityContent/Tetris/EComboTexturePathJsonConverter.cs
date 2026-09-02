using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062EF RID: 25327
	public class EComboTexturePathJsonConverter : JsonConverter<EComboTexturePath>
	{
		// Token: 0x0603FAC5 RID: 260805 RVA: 0x01052E70 File Offset: 0x01051070
		public override EComboTexturePath Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EComboTexturePath.Good;
			}
			return EComboTexturePathExtensions.FromString(@string);
		}

		// Token: 0x0603FAC6 RID: 260806 RVA: 0x01052E94 File Offset: 0x01051094
		public override void Write(Utf8JsonWriter writer, EComboTexturePath value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
