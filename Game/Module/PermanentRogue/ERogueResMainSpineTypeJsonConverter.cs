using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x020056B0 RID: 22192
	public class ERogueResMainSpineTypeJsonConverter : JsonConverter<ERogueResMainSpineType>
	{
		// Token: 0x060387C1 RID: 231361 RVA: 0x00E4FD5C File Offset: 0x00E4DF5C
		public override ERogueResMainSpineType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ERogueResMainSpineType.Female;
			}
			return ERogueResMainSpineTypeExtensions.FromString(@string);
		}

		// Token: 0x060387C2 RID: 231362 RVA: 0x00E4FD80 File Offset: 0x00E4DF80
		public override void Write(Utf8JsonWriter writer, ERogueResMainSpineType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
