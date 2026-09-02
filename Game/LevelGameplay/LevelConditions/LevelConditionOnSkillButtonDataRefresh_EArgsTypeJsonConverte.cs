using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.LevelGamePlay.LevelConditions
{
	// Token: 0x02006E07 RID: 28167
	public class LevelConditionOnSkillButtonDataRefresh_EArgsTypeJsonConverter : JsonConverter<LevelConditionOnSkillButtonDataRefresh.EArgsType>
	{
		// Token: 0x0604466D RID: 280173 RVA: 0x011C4F80 File Offset: 0x011C3180
		public override LevelConditionOnSkillButtonDataRefresh.EArgsType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return LevelConditionOnSkillButtonDataRefresh.EArgsType.ActionType;
			}
			return LevelConditionOnSkillButtonDataRefresh_EArgsTypeExtensions.FromString(@string);
		}

		// Token: 0x0604466E RID: 280174 RVA: 0x011C4FA4 File Offset: 0x011C31A4
		public override void Write(Utf8JsonWriter writer, LevelConditionOnSkillButtonDataRefresh.EArgsType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
