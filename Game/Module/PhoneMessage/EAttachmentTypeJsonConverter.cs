using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.PhoneMessage
{
	// Token: 0x0200545D RID: 21597
	public class EAttachmentTypeJsonConverter : JsonConverter<EAttachmentType>
	{
		// Token: 0x06037041 RID: 225345 RVA: 0x00DF6D14 File Offset: 0x00DF4F14
		public override EAttachmentType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EAttachmentType.Image;
			}
			return EAttachmentTypeExtensions.FromString(@string);
		}

		// Token: 0x06037042 RID: 225346 RVA: 0x00DF6D38 File Offset: 0x00DF4F38
		public override void Write(Utf8JsonWriter writer, EAttachmentType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
