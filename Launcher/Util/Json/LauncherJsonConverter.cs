using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Util.Json
{
	// Token: 0x020044B4 RID: 17588
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LauncherJsonConverter<[Nullable(2)] T> : JsonConverter<T>
	{
		// Token: 0x0602E5A4 RID: 189860 RVA: 0x00AE2CCE File Offset: 0x00AE0ECE
		[return: Nullable(2)]
		public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return LauncherJsonReader.Read<T>(ref reader, options);
		}

		// Token: 0x0602E5A5 RID: 189861 RVA: 0x00AE2CD7 File Offset: 0x00AE0ED7
		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			LauncherJsonWriter.Write<T>(writer, value, options);
		}
	}
}
