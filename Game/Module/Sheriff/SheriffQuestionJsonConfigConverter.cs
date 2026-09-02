using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FAF RID: 20399
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class SheriffQuestionJsonConfigConverter : JsonConverter<ISheriffQuestionJsonConfig>
	{
		// Token: 0x06034A35 RID: 215605 RVA: 0x00D348AB File Offset: 0x00D32AAB
		[return: Nullable(2)]
		public override ISheriffQuestionJsonConfig Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return JsonSerializer.Deserialize<SheriffQuestionJsonConfig>(ref reader, options);
		}

		// Token: 0x06034A36 RID: 215606 RVA: 0x00D348B4 File Offset: 0x00D32AB4
		public override void Write(Utf8JsonWriter writer, ISheriffQuestionJsonConfig value, JsonSerializerOptions options)
		{
			JsonSerializer.Serialize<SheriffQuestionJsonConfig>(writer, (SheriffQuestionJsonConfig)value, options);
		}
	}
}
