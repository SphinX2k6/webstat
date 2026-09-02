using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.PreWarm
{
	// Token: 0x02006588 RID: 25992
	public class EActivityPreWarmHexColorJsonConverter : JsonConverter<EActivityPreWarmHexColor>
	{
		// Token: 0x06040E97 RID: 265879 RVA: 0x010A73EC File Offset: 0x010A55EC
		public override EActivityPreWarmHexColor Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EActivityPreWarmHexColor.Red;
			}
			return EActivityPreWarmHexColorExtensions.FromString(@string);
		}

		// Token: 0x06040E98 RID: 265880 RVA: 0x010A7410 File Offset: 0x010A5610
		public override void Write(Utf8JsonWriter writer, EActivityPreWarmHexColor value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
