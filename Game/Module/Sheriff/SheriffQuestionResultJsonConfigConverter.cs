using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FB2 RID: 20402
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SheriffQuestionResultJsonConfigConverter : JsonConverter<ISheriffQuestionResultJsonConfig>
	{
		// Token: 0x06034A51 RID: 215633 RVA: 0x00D3495A File Offset: 0x00D32B5A
		[return: Nullable(2)]
		public override ISheriffQuestionResultJsonConfig Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return JsonSerializer.Deserialize<SheriffQuestionResultJsonConfig>(ref reader, options);
		}

		// Token: 0x06034A52 RID: 215634 RVA: 0x00D34963 File Offset: 0x00D32B63
		public override void Write(Utf8JsonWriter writer, ISheriffQuestionResultJsonConfig value, JsonSerializerOptions options)
		{
			JsonSerializer.Serialize<SheriffQuestionResultJsonConfig>(writer, (SheriffQuestionResultJsonConfig)value, options);
		}
	}
}
