using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A61 RID: 27233
	public class ELevelGeneralConditionJsonConverter : JsonConverter<ELevelGeneralCondition>
	{
		// Token: 0x060435DE RID: 275934 RVA: 0x01159D18 File Offset: 0x01157F18
		public override ELevelGeneralCondition Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return ELevelGeneralCondition.DistanceLess;
			}
			return ELevelGeneralConditionExtensions.FromString(@string);
		}

		// Token: 0x060435DF RID: 275935 RVA: 0x01159D3C File Offset: 0x01157F3C
		public override void Write(Utf8JsonWriter writer, ELevelGeneralCondition value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
