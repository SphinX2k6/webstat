using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Tetris
{
	// Token: 0x020062F1 RID: 25329
	public class EComboBgTexturePathJsonConverter : JsonConverter<EComboBgTexturePath>
	{
		// Token: 0x0603FACE RID: 260814 RVA: 0x01053054 File Offset: 0x01051254
		public override EComboBgTexturePath Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EComboBgTexturePath.Good;
			}
			return EComboBgTexturePathExtensions.FromString(@string);
		}

		// Token: 0x0603FACF RID: 260815 RVA: 0x01053078 File Offset: 0x01051278
		public override void Write(Utf8JsonWriter writer, EComboBgTexturePath value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
