using System;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

// Token: 0x02000052 RID: 82
[NullableContext(1)]
[Nullable(0)]
public class NumberConverter : JsonConverter<Number>
{
	// Token: 0x0600017D RID: 381 RVA: 0x00009DFC File Offset: 0x00007FFC
	public override Number Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler;
		if (reader.TokenType != JsonTokenType.Number)
		{
			defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
			defaultInterpolatedStringHandler.AppendLiteral("[LRX]无法将 token 类型 '");
			defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
			defaultInterpolatedStringHandler.AppendLiteral("' 反序列化为 Number");
			throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
		}
		long num;
		if (reader.TryGetInt64(out num))
		{
			return Number.FromInt((int)num);
		}
		double value;
		if (reader.TryGetDouble(out value))
		{
			return Number.FromDouble(value);
		}
		defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
		defaultInterpolatedStringHandler.AppendLiteral("[LRX]无法将 token 类型 '");
		defaultInterpolatedStringHandler.AppendFormatted<JsonTokenType>(reader.TokenType);
		defaultInterpolatedStringHandler.AppendLiteral("' 反序列化为 Number");
		throw new JsonException(defaultInterpolatedStringHandler.ToStringAndClear());
	}

	// Token: 0x0600017E RID: 382 RVA: 0x00009EAC File Offset: 0x000080AC
	public override void Write(Utf8JsonWriter writer, Number value, JsonSerializerOptions options)
	{
		if (value.IsInt())
		{
			writer.WriteNumberValue(value.GetLong());
			return;
		}
		writer.WriteNumberValue(value.GetDouble());
	}
}
