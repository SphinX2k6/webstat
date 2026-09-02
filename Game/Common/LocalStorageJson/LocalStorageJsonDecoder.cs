using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x02007068 RID: 28776
	public static class LocalStorageJsonDecoder
	{
		// Token: 0x1700A530 RID: 42288
		// (get) Token: 0x06045AB1 RID: 285361 RVA: 0x01234C6D File Offset: 0x01232E6D
		private unsafe static ReadOnlySpan<byte> UndefinedUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.B0806E217A11A22D00115F92E9E87AA90C0F4A60C7FECCD0B178E83DD3ED0FB4), 15);
			}
		}

		// Token: 0x1700A531 RID: 42289
		// (get) Token: 0x06045AB2 RID: 285362 RVA: 0x01234C7B File Offset: 0x01232E7B
		private unsafe static ReadOnlySpan<byte> NaNUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.D83BE94451FCFE05C71DAD7B862938E0934A66CF2C94397AD3C0613E30285AB4), 9);
			}
		}

		// Token: 0x1700A532 RID: 42290
		// (get) Token: 0x06045AB3 RID: 285363 RVA: 0x01234C89 File Offset: 0x01232E89
		private unsafe static ReadOnlySpan<byte> InfinityUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.7AAD3A78EE4DA8AC37F3E9591CEA3E6302D7EB8A4C7A2E2EBCB9F5392DBED708), 14);
			}
		}

		// Token: 0x1700A533 RID: 42291
		// (get) Token: 0x06045AB4 RID: 285364 RVA: 0x01234C97 File Offset: 0x01232E97
		private unsafe static ReadOnlySpan<byte> InfinityNegativeUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.AE409D506004148BB51FD75BA12F9059C0681340510BFE0439075C7E9473226F), 15);
			}
		}

		// Token: 0x1700A534 RID: 42292
		// (get) Token: 0x06045AB5 RID: 285365 RVA: 0x01234CA5 File Offset: 0x01232EA5
		private unsafe static ReadOnlySpan<byte> BooleanTrueUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.1F9F3C0705925E748B75DCE1A487E849FBDF4ACA0398904368F271BA409C9F88), 8);
			}
		}

		// Token: 0x1700A535 RID: 42293
		// (get) Token: 0x06045AB6 RID: 285366 RVA: 0x01234CB2 File Offset: 0x01232EB2
		private unsafe static ReadOnlySpan<byte> BooleanFalseUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.C1C09635A8381661D4B865AD73FB9804BBF6B542A7219FD5E3444E701B55F941), 8);
			}
		}

		// Token: 0x1700A536 RID: 42294
		// (get) Token: 0x06045AB7 RID: 285367 RVA: 0x01234CBF File Offset: 0x01232EBF
		private unsafe static ReadOnlySpan<byte> BigIntMarkerUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.78E14F28A8A77FAAF461BB92A742F0D7EFF3E8B082D52681C0EB6D96B3C7DC65), 8);
			}
		}

		// Token: 0x1700A537 RID: 42295
		// (get) Token: 0x06045AB8 RID: 285368 RVA: 0x01234CCC File Offset: 0x01232ECC
		private static ReadOnlySpan<char> BigIntMarkerChars
		{
			get
			{
				return "___BI___";
			}
		}

		// Token: 0x1700A538 RID: 42296
		// (get) Token: 0x06045AB9 RID: 285369 RVA: 0x01234CD8 File Offset: 0x01232ED8
		private unsafe static ReadOnlySpan<byte> MetaTypePropertyNameUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.CB7FCD77FBF798BB027D6B91EF60854663C5E25F6559D6FB22E56EE9005E9AEB), 14);
			}
		}

		// Token: 0x1700A539 RID: 42297
		// (get) Token: 0x06045ABA RID: 285370 RVA: 0x01234CE6 File Offset: 0x01232EE6
		private unsafe static ReadOnlySpan<byte> ContentPropertyNameUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.E305279D5B112237FACF20D5545320776D9036138AA37F94ABF7D2F5C3BA5CF9), 7);
			}
		}

		// Token: 0x1700A53A RID: 42298
		// (get) Token: 0x06045ABB RID: 285371 RVA: 0x01234CF3 File Offset: 0x01232EF3
		private unsafe static ReadOnlySpan<byte> MetaMapValueUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.895B3A303B19374C59863E6460BE02CD703D6BC19A4FD5053D05D46ED7328E89), 9);
			}
		}

		// Token: 0x1700A53B RID: 42299
		// (get) Token: 0x06045ABC RID: 285372 RVA: 0x01234D01 File Offset: 0x01232F01
		private unsafe static ReadOnlySpan<byte> MetaSetValueUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.E268DB06C48A79ACE3AFE80EC6C89859FDBED4178BAD7409E3A707BBD4AFA538), 9);
			}
		}

		// Token: 0x06045ABD RID: 285373 RVA: 0x01234D10 File Offset: 0x01232F10
		[NullableContext(2)]
		public static T Decode<T>(ref Utf8JsonReader reader, [Nullable(1)] JsonSerializerOptions options)
		{
			Type targetType = LocalStorageJsonContext.UnwrapNullable(typeof(T));
			JsonTokenType tokenType = reader.TokenType;
			if (tokenType != JsonTokenType.StartObject)
			{
				switch (tokenType)
				{
				case JsonTokenType.String:
					return LocalStorageJsonDecoder.DecodeStringPayload<T>(ref reader, targetType);
				case JsonTokenType.Number:
					return LocalStorageJsonDecoder.DecodeNumberPayload<T>(ref reader, targetType);
				case JsonTokenType.Null:
					return default(T);
				}
				return JsonSerializer.Deserialize<T>(ref reader, LocalStorageJsonContext.InternalJsonOptions);
			}
			return LocalStorageJsonDecoder.DecodeObjectPayload<T>(ref reader, targetType, options);
		}

		// Token: 0x06045ABE RID: 285374 RVA: 0x01234D84 File Offset: 0x01232F84
		[NullableContext(2)]
		private static T DecodeStringPayload<T>(ref Utf8JsonReader reader, [Nullable(1)] Type targetType)
		{
			if (reader.ValueTextEquals(LocalStorageJsonDecoder.UndefinedUtf8))
			{
				return default(T);
			}
			if (reader.ValueTextEquals(LocalStorageJsonDecoder.NaNUtf8))
			{
				return LocalStorageJsonDecoder.CastFloating<T>(double.NaN, targetType);
			}
			if (reader.ValueTextEquals(LocalStorageJsonDecoder.InfinityUtf8))
			{
				return LocalStorageJsonDecoder.CastFloating<T>(double.PositiveInfinity, targetType);
			}
			if (reader.ValueTextEquals(LocalStorageJsonDecoder.InfinityNegativeUtf8))
			{
				return LocalStorageJsonDecoder.CastFloating<T>(double.NegativeInfinity, targetType);
			}
			if (reader.ValueTextEquals(LocalStorageJsonDecoder.BooleanTrueUtf8))
			{
				return LocalStorageJsonDecoder.CastBoolean<T>(true, targetType);
			}
			if (reader.ValueTextEquals(LocalStorageJsonDecoder.BooleanFalseUtf8))
			{
				return LocalStorageJsonDecoder.CastBoolean<T>(false, targetType);
			}
			string @string = reader.GetString();
			if (@string == null)
			{
				return default(T);
			}
			if (@string.AsSpan().EndsWith(LocalStorageJsonDecoder.BigIntMarkerChars, StringComparison.Ordinal))
			{
				return LocalStorageJsonDecoder.CastBigInt<T>(@string.AsSpan(0, @string.Length - LocalStorageJsonDecoder.BigIntMarkerChars.Length), targetType);
			}
			if (targetType == typeof(string))
			{
				return (T)((object)@string);
			}
			return JsonSerializer.Deserialize<T>("\"" + @string + "\"", LocalStorageJsonContext.InternalJsonOptions);
		}

		// Token: 0x06045ABF RID: 285375 RVA: 0x01234EA8 File Offset: 0x012330A8
		[NullableContext(2)]
		private unsafe static T DecodeNumberPayload<T>(ref Utf8JsonReader reader, [Nullable(1)] Type targetType)
		{
			if (!(targetType == typeof(bool)))
			{
				return JsonSerializer.Deserialize<T>(ref reader, LocalStorageJsonContext.InternalJsonOptions);
			}
			bool flag = reader.GetDecimal() != 0m;
			if (!(typeof(T) != targetType))
			{
				return *Unsafe.As<bool, T>(ref flag);
			}
			return (T)((object)flag);
		}

		// Token: 0x06045AC0 RID: 285376 RVA: 0x01234F10 File Offset: 0x01233110
		[NullableContext(1)]
		private unsafe static T CastBoolean<[Nullable(2)] T>(bool b, Type targetType)
		{
			if (targetType != typeof(bool))
			{
				throw new JsonException("Cannot convert " + (b ? "___1B___" : "___0B___") + " to " + typeof(T).Name);
			}
			if (!(typeof(T) != targetType))
			{
				return *Unsafe.As<bool, T>(ref b);
			}
			return (T)((object)b);
		}

		// Token: 0x06045AC1 RID: 285377 RVA: 0x01234F8C File Offset: 0x0123318C
		[NullableContext(2)]
		private unsafe static T CastFloating<T>(double v, [Nullable(1)] Type targetType)
		{
			bool flag = typeof(T) != targetType;
			if (targetType == typeof(double))
			{
				double num = v;
				if (!flag)
				{
					return *Unsafe.As<double, T>(ref num);
				}
				return (T)((object)num);
			}
			else
			{
				if (!(targetType == typeof(float)))
				{
					throw new JsonException("特殊浮点值无法赋给类型 " + targetType.Name);
				}
				float num2 = (float)v;
				if (!flag)
				{
					return *Unsafe.As<float, T>(ref num2);
				}
				return (T)((object)num2);
			}
		}

		// Token: 0x06045AC2 RID: 285378 RVA: 0x01235020 File Offset: 0x01233220
		[NullableContext(2)]
		private unsafe static T CastBigInt<T>([Nullable(0)] ReadOnlySpan<char> num, [Nullable(1)] Type targetType)
		{
			bool flag = typeof(T) != targetType;
			long num2;
			ulong num3;
			int num4;
			uint num5;
			short num6;
			ushort num7;
			byte b;
			sbyte b2;
			if (targetType == typeof(long) && long.TryParse(num, out num2))
			{
				if (!flag)
				{
					return *Unsafe.As<long, T>(ref num2);
				}
				return (T)((object)num2);
			}
			else if (targetType == typeof(ulong) && ulong.TryParse(num, out num3))
			{
				if (!flag)
				{
					return *Unsafe.As<ulong, T>(ref num3);
				}
				return (T)((object)num3);
			}
			else if (targetType == typeof(int) && int.TryParse(num, out num4))
			{
				if (!flag)
				{
					return *Unsafe.As<int, T>(ref num4);
				}
				return (T)((object)num4);
			}
			else if (targetType == typeof(uint) && uint.TryParse(num, out num5))
			{
				if (!flag)
				{
					return *Unsafe.As<uint, T>(ref num5);
				}
				return (T)((object)num5);
			}
			else if (targetType == typeof(short) && short.TryParse(num, out num6))
			{
				if (!flag)
				{
					return *Unsafe.As<short, T>(ref num6);
				}
				return (T)((object)num6);
			}
			else if (targetType == typeof(ushort) && ushort.TryParse(num, out num7))
			{
				if (!flag)
				{
					return *Unsafe.As<ushort, T>(ref num7);
				}
				return (T)((object)num7);
			}
			else if (targetType == typeof(byte) && byte.TryParse(num, out b))
			{
				if (!flag)
				{
					return *Unsafe.As<byte, T>(ref b);
				}
				return (T)((object)b);
			}
			else if (targetType == typeof(sbyte) && sbyte.TryParse(num, out b2))
			{
				if (!flag)
				{
					return *Unsafe.As<sbyte, T>(ref b2);
				}
				return (T)((object)b2);
			}
			else
			{
				BigInteger bigInteger;
				if (!(targetType == typeof(BigInteger)) || !BigInteger.TryParse(num, NumberStyles.Integer, CultureInfo.InvariantCulture, out bigInteger))
				{
					BigInteger bigInteger2;
					if (BigInteger.TryParse(num, NumberStyles.Integer, CultureInfo.InvariantCulture, out bigInteger2))
					{
						try
						{
							return (T)((object)Convert.ChangeType(bigInteger2, targetType));
						}
						catch
						{
						}
					}
					throw new JsonException("BigInt(" + num.ToString() + ") 无法转换到目标类型 " + targetType.Name);
				}
				if (!flag)
				{
					return *Unsafe.As<BigInteger, T>(ref bigInteger);
				}
				return (T)((object)bigInteger);
			}
		}

		// Token: 0x06045AC3 RID: 285379 RVA: 0x012352A8 File Offset: 0x012334A8
		[NullableContext(1)]
		[return: Nullable(2)]
		private static T DecodeObjectPayload<[Nullable(2)] T>(ref Utf8JsonReader reader, Type targetType, JsonSerializerOptions options)
		{
			T result;
			using (JsonDocument jsonDocument = JsonDocument.ParseValue(ref reader))
			{
				JsonElement rootElement = jsonDocument.RootElement;
				JsonElement jsonElement;
				if (rootElement.ValueKind == JsonValueKind.Object && rootElement.TryGetProperty(LocalStorageJsonDecoder.MetaTypePropertyNameUtf8, out jsonElement) && jsonElement.ValueKind == JsonValueKind.String)
				{
					JsonElement contentArray;
					if (!rootElement.TryGetProperty(LocalStorageJsonDecoder.ContentPropertyNameUtf8, out contentArray))
					{
						throw new JsonException("MetaJson 缺少 Content 字段");
					}
					if (jsonElement.ValueEquals(LocalStorageJsonDecoder.MetaMapValueUtf8))
					{
						return LocalStorageJsonDecoder.DecodeMap<T>(contentArray, targetType);
					}
					if (jsonElement.ValueEquals(LocalStorageJsonDecoder.MetaSetValueUtf8))
					{
						return LocalStorageJsonDecoder.DecodeSet<T>(contentArray, targetType);
					}
				}
				result = (T)((object)LocalStorageJsonDecoder.DeserializeObjectByMembers(rootElement, targetType));
			}
			return result;
		}

		// Token: 0x06045AC4 RID: 285380 RVA: 0x01235360 File Offset: 0x01233560
		[NullableContext(1)]
		[return: Nullable(2)]
		private static object DeserializeObjectByMembers(JsonElement root, Type targetType)
		{
			JsonTypeInfo typeInfo = LocalStorageJsonContext.GetTypeInfo(targetType);
			object obj = (typeInfo.CreateObject != null) ? typeInfo.CreateObject() : RuntimeHelpers.GetUninitializedObject(targetType);
			JsonSerializerOptions nestedJsonOptions = LocalStorageJsonContext.NestedJsonOptions;
			Dictionary<string, JsonPropertyInfo> dictionary = new Dictionary<string, JsonPropertyInfo>(typeInfo.Properties.Count, StringComparer.Ordinal);
			foreach (JsonPropertyInfo jsonPropertyInfo in typeInfo.Properties)
			{
				if (jsonPropertyInfo.Set != null)
				{
					dictionary[jsonPropertyInfo.Name] = jsonPropertyInfo;
				}
			}
			foreach (JsonProperty jsonProperty in root.EnumerateObject())
			{
				JsonPropertyInfo jsonPropertyInfo2;
				if (dictionary.TryGetValue(jsonProperty.Name, out jsonPropertyInfo2))
				{
					try
					{
						object arg = jsonProperty.Value.Deserialize(jsonPropertyInfo2.PropertyType, nestedJsonOptions);
						jsonPropertyInfo2.Set(obj, arg);
					}
					catch
					{
					}
				}
			}
			return obj;
		}

		// Token: 0x06045AC5 RID: 285381 RVA: 0x01235490 File Offset: 0x01233690
		[NullableContext(2)]
		private static T DecodeMap<T>(JsonElement contentArray, [Nullable(1)] Type targetType)
		{
			if (!LocalStorageJsonContext.IsDictionaryType(targetType))
			{
				throw new JsonException("目标类型 " + targetType.Name + " 不是 Dictionary，但 JSON 是 Map MetaJson");
			}
			if (contentArray.ValueKind != JsonValueKind.Array)
			{
				throw new JsonException("Map.Content 不是数组");
			}
			Type[] genericArguments = targetType.GetGenericArguments();
			Type type = genericArguments[0];
			Type type2 = genericArguments[1];
			JsonSerializerOptions nestedSerializerOptions = LocalStorageJsonContext.GetNestedSerializerOptions(type);
			JsonSerializerOptions nestedSerializerOptions2 = LocalStorageJsonContext.GetNestedSerializerOptions(type2);
			T result;
			if (LocalStorageJsonMapDecoder.TryDecode<T>(contentArray, targetType, nestedSerializerOptions, nestedSerializerOptions2, out result))
			{
				return result;
			}
			IDictionary dictionary = (IDictionary)Activator.CreateInstance(typeof(Dictionary<, >).MakeGenericType(new Type[]
			{
				type,
				type2
			}));
			foreach (JsonElement jsonElement in contentArray.EnumerateArray())
			{
				if (jsonElement.ValueKind != JsonValueKind.Array)
				{
					throw new JsonException("Map.Content 元素不是 [k,v] 数组");
				}
				using (JsonElement.ArrayEnumerator enumerator2 = jsonElement.EnumerateArray().GetEnumerator())
				{
					if (!enumerator2.MoveNext())
					{
						throw new JsonException("Map.Content 元素缺少 key");
					}
					object obj = enumerator2.Current.Deserialize(type, nestedSerializerOptions);
					if (!enumerator2.MoveNext())
					{
						throw new JsonException("Map.Content 元素缺少 value");
					}
					object value = enumerator2.Current.Deserialize(type2, nestedSerializerOptions2);
					if (obj != null)
					{
						dictionary[obj] = value;
					}
				}
			}
			return (T)((object)dictionary);
		}

		// Token: 0x06045AC6 RID: 285382 RVA: 0x01235618 File Offset: 0x01233818
		[NullableContext(2)]
		private static T DecodeSet<T>(JsonElement contentArray, [Nullable(1)] Type targetType)
		{
			if (!LocalStorageJsonContext.IsSetType(targetType))
			{
				throw new JsonException("目标类型 " + targetType.Name + " 不是 HashSet，但 JSON 是 Set MetaJson");
			}
			if (contentArray.ValueKind != JsonValueKind.Array)
			{
				throw new JsonException("Set.Content 不是数组");
			}
			JsonSerializerOptions nestedSerializerOptions = LocalStorageJsonContext.GetNestedSerializerOptions(targetType.GetGenericArguments()[0]);
			T result;
			if (LocalStorageJsonSetDecoder.TryDecode<T>(contentArray, targetType, nestedSerializerOptions, out result))
			{
				return result;
			}
			return contentArray.Deserialize(LocalStorageJsonContext.InternalJsonOptions);
		}

		// Token: 0x0402701D RID: 159773
		private const NumberStyles BigIntNumberStyles = NumberStyles.Integer;
	}
}
