using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.DropCatch
{
	// Token: 0x020068D9 RID: 26841
	public class EDropCatchModifierTypeJsonConverter : JsonConverter<EDropCatchModifierType>
	{
		// Token: 0x06042BB5 RID: 273333 RVA: 0x01120CE8 File Offset: 0x0111EEE8
		public override EDropCatchModifierType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EDropCatchModifierType.Override;
			}
			return EDropCatchModifierTypeExtensions.FromString(@string);
		}

		// Token: 0x06042BB6 RID: 273334 RVA: 0x01120D0C File Offset: 0x0111EF0C
		public override void Write(Utf8JsonWriter writer, EDropCatchModifierType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
