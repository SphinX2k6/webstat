using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068DB RID: 26843
	public class EDropCatchCommandSourceJsonConverter : JsonConverter<EDropCatchCommandSource>
	{
		// Token: 0x06042BBE RID: 273342 RVA: 0x01120DC4 File Offset: 0x0111EFC4
		public override EDropCatchCommandSource Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchCommandSource.Skill;
			}
			return EDropCatchCommandSourceExtensions.FromString(@string);
		}

		// Token: 0x06042BBF RID: 273343 RVA: 0x01120DE8 File Offset: 0x0111EFE8
		public override void Write(Utf8JsonWriter writer, EDropCatchCommandSource value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
