using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.QuickHack
{
	// Token: 0x02005303 RID: 21251
	public class EQuickHackSkillConditionJsonConverter : JsonConverter<EQuickHackSkillCondition>
	{
		// Token: 0x06036406 RID: 222214 RVA: 0x00DABF2C File Offset: 0x00DAA12C
		public override EQuickHackSkillCondition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EQuickHackSkillCondition.CheckTargetTypeMatch;
			}
			return EQuickHackSkillConditionExtensions.FromString(@string);
		}

		// Token: 0x06036407 RID: 222215 RVA: 0x00DABF50 File Offset: 0x00DAA150
		public override void Write(Utf8JsonWriter writer, EQuickHackSkillCondition value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
