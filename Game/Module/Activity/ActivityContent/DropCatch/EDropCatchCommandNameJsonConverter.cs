using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D7 RID: 26839
	public class EDropCatchCommandNameJsonConverter : JsonConverter<EDropCatchCommandName>
	{
		// Token: 0x06042BAC RID: 273324 RVA: 0x01120B90 File Offset: 0x0111ED90
		public override EDropCatchCommandName Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchCommandName.SpawnDropItem;
			}
			return EDropCatchCommandNameExtensions.FromString(@string);
		}

		// Token: 0x06042BAD RID: 273325 RVA: 0x01120BB4 File Offset: 0x0111EDB4
		public override void Write(Utf8JsonWriter writer, EDropCatchCommandName value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
