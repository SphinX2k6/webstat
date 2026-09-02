using System;
using System.Buffers;
using System.Buffers.Text;
using System.Collections;
using System.Globalization;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization.Metadata;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x02007069 RID: 28777
	public static class LocalStorageJsonEncoder
	{
		// Token: 0x1700A53C RID: 42300
		// (get) Token: 0x06045AC7 RID: 285383 RVA: 0x01235684 File Offset: 0x01233884
		private unsafe static ReadOnlySpan<byte> BigIntMarkerUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.78E14F28A8A77FAAF461BB92A742F0D7EFF3E8B082D52681C0EB6D96B3C7DC65), 8);
			}
		}

		// Token: 0x1700A53D RID: 42301
		// (get) Token: 0x06045AC8 RID: 285384 RVA: 0x01235691 File Offset: 0x01233891
		private unsafe static ReadOnlySpan<byte> MetaTypePropertyNameUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.CB7FCD77FBF798BB027D6B91EF60854663C5E25F6559D6FB22E56EE9005E9AEB), 14);
			}
		}

		// Token: 0x1700A53E RID: 42302
		// (get) Token: 0x06045AC9 RID: 285385 RVA: 0x0123569F File Offset: 0x0123389F
		private unsafe static ReadOnlySpan<byte> ContentPropertyNameUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.E305279D5B112237FACF20D5545320776D9036138AA37F94ABF7D2F5C3BA5CF9), 7);
			}
		}

		// Token: 0x1700A53F RID: 42303
		// (get) Token: 0x06045ACA RID: 285386 RVA: 0x012356AC File Offset: 0x012338AC
		private unsafe static ReadOnlySpan<byte> MetaMapValueUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.895B3A303B19374C59863E6460BE02CD703D6BC19A4FD5053D05D46ED7328E89), 9);
			}
		}

		// Token: 0x1700A540 RID: 42304
		// (get) Token: 0x06045ACB RID: 285387 RVA: 0x012356BA File Offset: 0x012338BA
		private unsafe static ReadOnlySpan<byte> MetaSetValueUtf8
		{
			get
			{
				return new ReadOnlySpan<byte>((void*)(&<PrivateImplementationDetails>.E268DB06C48A79ACE3AFE80EC6C89859FDBED4178BAD7409E3A707BBD4AFA538), 9);
			}
		}

		// Token: 0x1700A541 RID: 42305
		// (get) Token: 0x06045ACC RID: 285388 RVA: 0x012356C8 File Offset: 0x012338C8
		private static ReadOnlySpan<char> BigIntMarkerChars
		{
			get
			{
				return "___BI___";
			}
		}

		// Token: 0x06045ACD RID: 285389 RVA: 0x012356D4 File Offset: 0x012338D4
		[NullableContext(1)]
		public static void Encode<[Nullable(2)] T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			Type type = typeof(T).IsValueType ? LocalStorageJsonContext.UnwrapNullable(typeof(T)) : LocalStorageJsonContext.UnwrapNullable(value.GetType());
			if (LocalStorageJsonContext.IsScalarType(type))
			{
				LocalStorageJsonEncoder.WriteScalar(writer, value, type);
				return;
			}
			if (LocalStorageJsonContext.IsDictionaryType(type))
			{
				LocalStorageJsonEncoder.WriteAsMap(writer, (IDictionary)((object)value), type);
				return;
			}
			if (LocalStorageJsonContext.IsSetType(type))
			{
				LocalStorageJsonEncoder.WriteAsSet(writer, (IEnumerable)((object)value), type);
				return;
			}
			if (value is IEnumerable && !(value is string))
			{
				LocalStorageJsonEncoder.WriteAsArray(writer, (IEnumerable)((object)value), type);
				return;
			}
			LocalStorageJsonEncoder.WriteAsObject(writer, value, type);
		}

		// Token: 0x06045ACE RID: 285390 RVA: 0x012357AC File Offset: 0x012339AC
		[NullableContext(1)]
		private static void WriteAsObject(Utf8JsonWriter writer, object value, Type runtimeType)
		{
			writer.WriteStartObject();
			JsonTypeInfo typeInfo = LocalStorageJsonContext.GetTypeInfo(runtimeType);
			JsonSerializerOptions nestedJsonOptions = LocalStorageJsonContext.NestedJsonOptions;
			foreach (JsonPropertyInfo jsonPropertyInfo in typeInfo.Properties)
			{
				if (jsonPropertyInfo.Get != null)
				{
					object obj;
					try
					{
						obj = jsonPropertyInfo.Get(value);
					}
					catch
					{
						continue;
					}
					if ((jsonPropertyInfo.ShouldSerialize == null || jsonPropertyInfo.ShouldSerialize(value, obj)) && obj != null)
					{
						writer.WritePropertyName(jsonPropertyInfo.Name);
						JsonSerializer.Serialize(writer, obj, jsonPropertyInfo.PropertyType, nestedJsonOptions);
					}
				}
			}
			writer.WriteEndObject();
		}

		// Token: 0x06045ACF RID: 285391 RVA: 0x01235864 File Offset: 0x01233A64
		[NullableContext(1)]
		private static void WriteScalar(Utf8JsonWriter writer, object value, Type runtimeType)
		{
			if (value is bool)
			{
				bool flag = (bool)value;
				writer.WriteStringValue(flag ? "___1B___" : "___0B___");
				return;
			}
			if (value is long)
			{
				long value2 = (long)value;
				LocalStorageJsonEncoder.WriteLongWithBigIntMarker(writer, value2);
				return;
			}
			if (value is ulong)
			{
				ulong value3 = (ulong)value;
				LocalStorageJsonEncoder.WriteUlongWithBigIntMarker(writer, value3);
				return;
			}
			if (value is BigInteger)
			{
				BigInteger value4 = (BigInteger)value;
				LocalStorageJsonEncoder.WriteBigIntegerWithBigIntMarker(writer, value4);
				return;
			}
			if (value is float)
			{
				float num = (float)value;
				if (float.IsNaN(num))
				{
					writer.WriteStringValue("___NaN___");
					return;
				}
				if (float.IsPositiveInfinity(num))
				{
					writer.WriteStringValue("___Infinity___");
					return;
				}
				if (float.IsNegativeInfinity(num))
				{
					writer.WriteStringValue("___-Infinity___");
					return;
				}
				writer.WriteNumberValue(num);
				return;
			}
			else
			{
				if (!(value is double))
				{
					JsonSerializer.Serialize(writer, value, runtimeType, LocalStorageJsonContext.InternalJsonOptions);
					return;
				}
				double num2 = (double)value;
				if (double.IsNaN(num2))
				{
					writer.WriteStringValue("___NaN___");
					return;
				}
				if (double.IsPositiveInfinity(num2))
				{
					writer.WriteStringValue("___Infinity___");
					return;
				}
				if (double.IsNegativeInfinity(num2))
				{
					writer.WriteStringValue("___-Infinity___");
					return;
				}
				writer.WriteNumberValue(num2);
				return;
			}
		}

		// Token: 0x06045AD0 RID: 285392 RVA: 0x012359A8 File Offset: 0x01233BA8
		[NullableContext(1)]
		private unsafe static void WriteLongWithBigIntMarker(Utf8JsonWriter writer, long value)
		{
			Span<byte> destination = new Span<byte>(stackalloc byte[(UIntPtr)32], 32);
			int num;
			if (Utf8Formatter.TryFormat(value, destination, out num, default(StandardFormat)))
			{
				LocalStorageJsonEncoder.BigIntMarkerUtf8.CopyTo(destination.Slice(num));
				writer.WriteStringValue(destination.Slice(0, num + LocalStorageJsonEncoder.BigIntMarkerUtf8.Length));
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted<long>(value);
			defaultInterpolatedStringHandler.AppendFormatted("___BI___");
			writer.WriteStringValue(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06045AD1 RID: 285393 RVA: 0x01235A38 File Offset: 0x01233C38
		[NullableContext(1)]
		private unsafe static void WriteUlongWithBigIntMarker(Utf8JsonWriter writer, ulong value)
		{
			Span<byte> destination = new Span<byte>(stackalloc byte[(UIntPtr)32], 32);
			int num;
			if (Utf8Formatter.TryFormat(value, destination, out num, default(StandardFormat)))
			{
				LocalStorageJsonEncoder.BigIntMarkerUtf8.CopyTo(destination.Slice(num));
				writer.WriteStringValue(destination.Slice(0, num + LocalStorageJsonEncoder.BigIntMarkerUtf8.Length));
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted<ulong>(value);
			defaultInterpolatedStringHandler.AppendFormatted("___BI___");
			writer.WriteStringValue(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06045AD2 RID: 285394 RVA: 0x01235AC8 File Offset: 0x01233CC8
		[NullableContext(1)]
		private unsafe static void WriteBigIntegerWithBigIntMarker(Utf8JsonWriter writer, BigInteger value)
		{
			Span<char> span = new Span<char>(stackalloc byte[(UIntPtr)128], 64);
			Span<char> destination = span;
			IFormatProvider invariantCulture = CultureInfo.InvariantCulture;
			int num;
			if (value.TryFormat(destination, out num, default(ReadOnlySpan<char>), invariantCulture) && span.Slice(num).Length >= LocalStorageJsonEncoder.BigIntMarkerChars.Length)
			{
				LocalStorageJsonEncoder.BigIntMarkerChars.CopyTo(span.Slice(num));
				writer.WriteStringValue(span.Slice(0, num + LocalStorageJsonEncoder.BigIntMarkerChars.Length));
				return;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 2);
			defaultInterpolatedStringHandler.AppendFormatted<BigInteger>(value);
			defaultInterpolatedStringHandler.AppendFormatted("___BI___");
			writer.WriteStringValue(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06045AD3 RID: 285395 RVA: 0x01235B84 File Offset: 0x01233D84
		[NullableContext(1)]
		private static void WriteAsMap(Utf8JsonWriter writer, IDictionary dict, Type runtimeType)
		{
			Type[] genericArguments = runtimeType.GetGenericArguments();
			Type type = genericArguments[0];
			Type type2 = genericArguments[1];
			JsonSerializerOptions nestedSerializerOptions = LocalStorageJsonContext.GetNestedSerializerOptions(type);
			JsonSerializerOptions nestedSerializerOptions2 = LocalStorageJsonContext.GetNestedSerializerOptions(type2);
			writer.WriteStartObject();
			writer.WriteString(LocalStorageJsonEncoder.MetaTypePropertyNameUtf8, LocalStorageJsonEncoder.MetaMapValueUtf8);
			writer.WritePropertyName(LocalStorageJsonEncoder.ContentPropertyNameUtf8);
			writer.WriteStartArray();
			foreach (object obj in dict)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				writer.WriteStartArray();
				JsonSerializer.Serialize(writer, dictionaryEntry.Key, type, nestedSerializerOptions);
				JsonSerializer.Serialize(writer, dictionaryEntry.Value, type2, nestedSerializerOptions2);
				writer.WriteEndArray();
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}

		// Token: 0x06045AD4 RID: 285396 RVA: 0x01235C54 File Offset: 0x01233E54
		[NullableContext(1)]
		private static void WriteAsArray(Utf8JsonWriter writer, IEnumerable enumerable, Type runtimeType)
		{
			Type enumerableElementType = LocalStorageJsonEncoder.GetEnumerableElementType(runtimeType);
			JsonSerializerOptions nestedSerializerOptions = LocalStorageJsonContext.GetNestedSerializerOptions(enumerableElementType);
			writer.WriteStartArray();
			foreach (object value in enumerable)
			{
				JsonSerializer.Serialize(writer, value, enumerableElementType, nestedSerializerOptions);
			}
			writer.WriteEndArray();
		}

		// Token: 0x06045AD5 RID: 285397 RVA: 0x01235CC4 File Offset: 0x01233EC4
		[NullableContext(1)]
		private static void WriteAsSet(Utf8JsonWriter writer, IEnumerable set, Type runtimeType)
		{
			Type type = runtimeType.GetGenericArguments()[0];
			JsonSerializerOptions nestedSerializerOptions = LocalStorageJsonContext.GetNestedSerializerOptions(type);
			writer.WriteStartObject();
			writer.WriteString(LocalStorageJsonEncoder.MetaTypePropertyNameUtf8, LocalStorageJsonEncoder.MetaSetValueUtf8);
			writer.WritePropertyName(LocalStorageJsonEncoder.ContentPropertyNameUtf8);
			writer.WriteStartArray();
			foreach (object value in set)
			{
				JsonSerializer.Serialize(writer, value, type, nestedSerializerOptions);
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}

		// Token: 0x06045AD6 RID: 285398 RVA: 0x01235D5C File Offset: 0x01233F5C
		[NullableContext(1)]
		private static Type GetEnumerableElementType(Type runtimeType)
		{
			if (runtimeType.IsArray)
			{
				return runtimeType.GetElementType() ?? typeof(object);
			}
			if (runtimeType.IsGenericType)
			{
				Type[] genericArguments = runtimeType.GetGenericArguments();
				if (genericArguments.Length == 1)
				{
					return genericArguments[0];
				}
			}
			return typeof(object);
		}

		// Token: 0x0402701E RID: 159774
		private const int LongUtf8BufferSize = 32;

		// Token: 0x0402701F RID: 159775
		private const int UlongUtf8BufferSize = 32;

		// Token: 0x04027020 RID: 159776
		private const int BigIntegerCharBufferSize = 64;
	}
}
