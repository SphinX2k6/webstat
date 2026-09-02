using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Activity.ActivityContent.RoadBook
{
	// Token: 0x020064C3 RID: 25795
	public class ERoadBookAnimJsonConverter : JsonConverter<ERoadBookAnim>
	{
		// Token: 0x06040A1D RID: 264733 RVA: 0x010914DC File Offset: 0x0108F6DC
		public override ERoadBookAnim Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ERoadBookAnim.AniOpen;
			}
			return ERoadBookAnimExtensions.FromString(@string);
		}

		// Token: 0x06040A1E RID: 264734 RVA: 0x01091500 File Offset: 0x0108F700
		public override void Write(Utf8JsonWriter writer, ERoadBookAnim value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
