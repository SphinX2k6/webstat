using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068DD RID: 26845
	public class EDropCatchGameplayLeftMsgTypeJsonConverter : JsonConverter<EDropCatchGameplayLeftMsgType>
	{
		// Token: 0x06042BC7 RID: 273351 RVA: 0x01120ED8 File Offset: 0x0111F0D8
		public override EDropCatchGameplayLeftMsgType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchGameplayLeftMsgType.Gameplay;
			}
			return EDropCatchGameplayLeftMsgTypeExtensions.FromString(@string);
		}

		// Token: 0x06042BC8 RID: 273352 RVA: 0x01120EFC File Offset: 0x0111F0FC
		public override void Write(Utf8JsonWriter writer, EDropCatchGameplayLeftMsgType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
