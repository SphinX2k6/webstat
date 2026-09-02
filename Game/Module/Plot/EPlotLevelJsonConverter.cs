using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Plot
{
	// Token: 0x0200537E RID: 21374
	public class EPlotLevelJsonConverter : JsonConverter<EPlotLevel>
	{
		// Token: 0x06036832 RID: 223282 RVA: 0x00DC6E08 File Offset: 0x00DC5008
		public override EPlotLevel Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return EPlotLevel.LevelA;
			}
			return EPlotLevelExtensions.FromString(@string);
		}

		// Token: 0x06036833 RID: 223283 RVA: 0x00DC6E2C File Offset: 0x00DC502C
		public override void Write(Utf8JsonWriter writer, EPlotLevel value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
