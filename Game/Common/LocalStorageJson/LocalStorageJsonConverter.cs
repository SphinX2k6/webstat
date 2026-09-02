using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x02007066 RID: 28774
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class LocalStorageJsonConverter<[Nullable(2)] T> : JsonConverter<T>
	{
		// Token: 0x1700A52F RID: 42287
		// (get) Token: 0x06045AAA RID: 285354 RVA: 0x01234C1F File Offset: 0x01232E1F
		public override bool HandleNull
		{
			get
			{
				return true;
			}
		}

		// Token: 0x06045AAB RID: 285355 RVA: 0x01234C22 File Offset: 0x01232E22
		[return: Nullable(2)]
		public override T Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			return LocalStorageJsonDecoder.Decode<T>(ref reader, options);
		}

		// Token: 0x06045AAC RID: 285356 RVA: 0x01234C2B File Offset: 0x01232E2B
		public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			LocalStorageJsonEncoder.Encode<T>(writer, value, options);
		}
	}
}
