using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F0C RID: 20236
	public class SlidingBlocksDefine_ETetrominoTypeJsonConverter : JsonConverter<SlidingBlocksDefine.ETetrominoType>
	{
		// Token: 0x060344E2 RID: 214242 RVA: 0x00D16794 File Offset: 0x00D14994
		public override SlidingBlocksDefine.ETetrominoType Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return SlidingBlocksDefine.ETetrominoType.I块;
			}
			return SlidingBlocksDefine_ETetrominoTypeExtensions.FromString(@string);
		}

		// Token: 0x060344E3 RID: 214243 RVA: 0x00D167B8 File Offset: 0x00D149B8
		public override void Write(Utf8JsonWriter writer, SlidingBlocksDefine.ETetrominoType value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
