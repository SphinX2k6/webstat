using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Core.Common
{
	// Token: 0x02007151 RID: 29009
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		0,
		1,
		1
	})]
	public class ArrayToKvpConverter<[Nullable(2)] TKey, [Nullable(2)] TValue> : JsonConverter<KeyValuePair<TKey, TValue>>
	{
		// Token: 0x060463B3 RID: 287667 RVA: 0x01271EF4 File Offset: 0x012700F4
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public override KeyValuePair<TKey, TValue> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
		{
			if (reader.TokenType != JsonTokenType.StartArray)
			{
				throw new JsonException("Expected array start");
			}
			reader.Read();
			TKey key = JsonSerializer.Deserialize<TKey>(ref reader, options);
			reader.Read();
			TValue value = JsonSerializer.Deserialize<TValue>(ref reader, options);
			reader.Read();
			if (reader.TokenType != JsonTokenType.EndArray)
			{
				throw new JsonException("Expected array end");
			}
			return new KeyValuePair<TKey, TValue>(key, value);
		}

		// Token: 0x060463B4 RID: 287668 RVA: 0x01271F53 File Offset: 0x01270153
		public override void Write(Utf8JsonWriter writer, [Nullable(new byte[]
		{
			0,
			1,
			1
		})] KeyValuePair<TKey, TValue> value, JsonSerializerOptions options)
		{
			writer.WriteStartArray();
			JsonSerializer.Serialize<TKey>(writer, value.Key, options);
			JsonSerializer.Serialize<TValue>(writer, value.Value, options);
			writer.WriteEndArray();
		}
	}
}
