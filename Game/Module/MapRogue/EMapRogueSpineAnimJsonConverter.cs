using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.MapRogue
{
	// Token: 0x0200599F RID: 22943
	public class EMapRogueSpineAnimJsonConverter : JsonConverter<EMapRogueSpineAnim>
	{
		// Token: 0x0603A161 RID: 237921 RVA: 0x00EB34D0 File Offset: 0x00EB16D0
		public override EMapRogueSpineAnim Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EMapRogueSpineAnim.Idle;
			}
			return EMapRogueSpineAnimExtensions.FromString(@string);
		}

		// Token: 0x0603A162 RID: 237922 RVA: 0x00EB34F4 File Offset: 0x00EB16F4
		public override void Write(Utf8JsonWriter writer, EMapRogueSpineAnim value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
