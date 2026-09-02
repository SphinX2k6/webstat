using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Core.Common
{
	// Token: 0x02007152 RID: 29010
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1,
		1
	})]
	public class HashSetJsonConverter<[Nullable(2)] T> : JsonConverter<HashSet<T>>
	{
		// Token: 0x060463B6 RID: 287670 RVA: 0x01271F88 File Offset: 0x01270188
		public override HashSet<T> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray)
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(25, 1);
				defaultInterpolatedStringHandler.AppendLiteral("Expected StartArray, got ");
				defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
				throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			HashSet<T> hashSet = new HashSet<T>();
			while (reader.Read() && reader.TokenType != JsonTokenType.EndArray)
			{
				T t = JsonSerializer.Deserialize<T>(ref reader, options);
				if (t != null)
				{
					hashSet.Add(t);
				}
			}
			return hashSet;
		}

		// Token: 0x060463B7 RID: 287671 RVA: 0x01272000 File Offset: 0x01270200
		public override void Write(Utf8JsonWriter writer, HashSet<T> value, JsonSerializerOptions options)
		{
			JsonSerializer.Serialize<T[]>(writer, value.ToArray<T>(), options);
		}
	}
}
