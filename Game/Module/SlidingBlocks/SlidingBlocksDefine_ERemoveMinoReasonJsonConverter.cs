using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F0A RID: 20234
	public class SlidingBlocksDefine_ERemoveMinoReasonJsonConverter : JsonConverter<SlidingBlocksDefine.ERemoveMinoReason>
	{
		// Token: 0x060344D9 RID: 214233 RVA: 0x00D15F54 File Offset: 0x00D14154
		public override SlidingBlocksDefine.ERemoveMinoReason Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return SlidingBlocksDefine.ERemoveMinoReason.LineClearFall;
			}
			return SlidingBlocksDefine_ERemoveMinoReasonExtensions.FromString(@string);
		}

		// Token: 0x060344DA RID: 214234 RVA: 0x00D15F78 File Offset: 0x00D14178
		public override void Write(Utf8JsonWriter writer, SlidingBlocksDefine.ERemoveMinoReason value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
