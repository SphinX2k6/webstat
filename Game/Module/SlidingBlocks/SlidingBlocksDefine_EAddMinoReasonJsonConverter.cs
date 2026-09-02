using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.SlidingBlocks
{
	// Token: 0x02004F08 RID: 20232
	public class SlidingBlocksDefine_EAddMinoReasonJsonConverter : JsonConverter<SlidingBlocksDefine.EAddMinoReason>
	{
		// Token: 0x060344D0 RID: 214224 RVA: 0x00D15E40 File Offset: 0x00D14040
		public override SlidingBlocksDefine.EAddMinoReason Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			string @string = reader.GetString();
			if (string.IsNullOrEmpty(@string))
			{
				return SlidingBlocksDefine.EAddMinoReason.LineClearFall;
			}
			return SlidingBlocksDefine_EAddMinoReasonExtensions.FromString(@string);
		}

		// Token: 0x060344D1 RID: 214225 RVA: 0x00D15E64 File Offset: 0x00D14064
		public override void Write(Utf8JsonWriter writer, SlidingBlocksDefine.EAddMinoReason value, JsonSerializerOptions options)
		{
			writer.WriteStringValue(value.ToEnumString());
		}
	}
}
