using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Roverlike
{
	// Token: 0x02006470 RID: 25712
	public class ERoverActionSubViewTypeJsonConverter : JsonConverter<ERoverActionSubViewType>
	{
		// Token: 0x060407F2 RID: 264178 RVA: 0x010875C4 File Offset: 0x010857C4
		public override ERoverActionSubViewType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ERoverActionSubViewType.None;
			}
			return ERoverActionSubViewTypeExtensions.FromString(@string);
		}

		// Token: 0x060407F3 RID: 264179 RVA: 0x010875E8 File Offset: 0x010857E8
		public override void Write(Utf8JsonWriter writer, ERoverActionSubViewType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
