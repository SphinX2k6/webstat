using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.Encircle
{
	// Token: 0x02006881 RID: 26753
	public class ESpineAnimationJsonConverter : JsonConverter<ESpineAnimation>
	{
		// Token: 0x06042A9E RID: 273054 RVA: 0x0111CE00 File Offset: 0x0111B000
		public override ESpineAnimation Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ESpineAnimation.Die;
			}
			return ESpineAnimationExtensions.FromString(@string);
		}

		// Token: 0x06042A9F RID: 273055 RVA: 0x0111CE24 File Offset: 0x0111B024
		public override void Write(Utf8JsonWriter writer, ESpineAnimation value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
