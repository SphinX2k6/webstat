using System;
using System.Collections;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CSharpScript.Launcher.Util.Json
{
	// Token: 0x020044B7 RID: 17591
	[NullableContext(1)]
	[Nullable(0)]
	public static class LauncherJsonWriter
	{
		// Token: 0x0602E5C3 RID: 189891 RVA: 0x00AE3A28 File Offset: 0x00AE1C28
		public static void Write<[Nullable(2)] T>(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
		{
			if (value == null)
			{
				writer.WriteNullValue();
				return;
			}
			Type typeFromHandle = typeof(T);
			if (LauncherJsonSettings.IsGenericDictionary(typeFromHandle))
			{
				LauncherJsonWriter.WriteDictionary<T>(writer, value, typeFromHandle);
				return;
			}
			if (LauncherJsonSettings.IsGenericHashSet(typeFromHandle))
			{
				LauncherJsonWriter.WriteHashSet<T>(writer, value, typeFromHandle);
				return;
			}
			LauncherJsonWriter.WriteScalarValue<T>(writer, value, typeFromHandle);
		}

		// Token: 0x0602E5C4 RID: 189892 RVA: 0x00AE3A7C File Offset: 0x00AE1C7C
		private static void WriteScalarValue<[Nullable(2)] T>(Utf8JsonWriter writer, T value, Type type)
		{
			if (value is long)
			{
				long num = value as long;
				if (num >= -9007199254740991L && num <= 9007199254740991L)
				{
					writer.WriteNumberValue(num);
					return;
				}
				writer.WriteStringValue(num.ToString() + "___BI___");
				return;
			}
			else
			{
				if (value is BigInteger)
				{
					writer.WriteStringValue((value as BigInteger).ToString() + "___BI___");
					return;
				}
				if (value is bool)
				{
					bool flag = value as bool;
					writer.WriteStringValue(flag ? "___1B___" : "___0B___");
					return;
				}
				if (value is float)
				{
					float num2 = value as float;
					if (float.IsNaN(num2))
					{
						writer.WriteStringValue("___NaN___");
						return;
					}
					if (float.IsPositiveInfinity(num2))
					{
						writer.WriteStringValue("___Infinity___");
						return;
					}
					if (float.IsNegativeInfinity(num2))
					{
						writer.WriteStringValue("___-Infinity___");
						return;
					}
					writer.WriteNumberValue(num2);
					return;
				}
				else if (value is double)
				{
					double num3 = value as double;
					if (double.IsNaN(num3))
					{
						writer.WriteStringValue("___NaN___");
						return;
					}
					if (double.IsPositiveInfinity(num3))
					{
						writer.WriteStringValue("___Infinity___");
						return;
					}
					if (double.IsNegativeInfinity(num3))
					{
						writer.WriteStringValue("___-Infinity___");
						return;
					}
					writer.WriteNumberValue(num3);
					return;
				}
				else
				{
					if (value is int)
					{
						int value2 = value as int;
						writer.WriteNumberValue(value2);
						return;
					}
					if (value is uint)
					{
						uint value3 = value as uint;
						writer.WriteNumberValue(value3);
						return;
					}
					if (value is short)
					{
						short value4 = value as short;
						writer.WriteNumberValue((int)value4);
						return;
					}
					if (value is ushort)
					{
						ushort value5 = value as ushort;
						writer.WriteNumberValue((int)value5);
						return;
					}
					if (value is byte)
					{
						byte value6 = value as byte;
						writer.WriteNumberValue((int)value6);
						return;
					}
					if (value is sbyte)
					{
						sbyte value7 = value as sbyte;
						writer.WriteNumberValue((int)value7);
						return;
					}
					if (value is ulong)
					{
						ulong value8 = value as ulong;
						writer.WriteNumberValue(value8);
						return;
					}
					if (value is decimal)
					{
						decimal value9 = value as decimal;
						writer.WriteNumberValue(value9);
						return;
					}
					JsonSerializer.Serialize(writer, value, type, LauncherJsonSettings.JsonOptions);
					return;
				}
			}
		}

		// Token: 0x0602E5C5 RID: 189893 RVA: 0x00AE3DB0 File Offset: 0x00AE1FB0
		private static void WriteDictionary<[Nullable(2)] T>(Utf8JsonWriter writer, T value, Type type)
		{
			Type[] genericArguments = type.GetGenericArguments();
			Type inputType = genericArguments[0];
			Type type2 = genericArguments[1];
			IDictionary dictionary = value as IDictionary;
			if (dictionary == null)
			{
				throw new JsonException("Failed to serialize Dictionary: " + type.Name + ".");
			}
			JsonSerializerOptions jsonSerializerOptions = LauncherJsonSettings.CreateOptionsWithMarkerConverters(LauncherJsonSettings.JsonOptions);
			if (LauncherJsonSettings.IsGenericDictionary(type2) || LauncherJsonSettings.IsGenericHashSet(type2))
			{
				Type type3 = typeof(LauncherJsonConverter<>).MakeGenericType(new Type[]
				{
					type2
				});
				jsonSerializerOptions.Converters.Add((JsonConverter)Activator.CreateInstance(type3));
			}
			writer.WriteStartObject();
			writer.WriteString("___MetaType___", "___Map___");
			writer.WritePropertyName("Content");
			writer.WriteStartArray();
			foreach (object obj in dictionary)
			{
				DictionaryEntry dictionaryEntry = (DictionaryEntry)obj;
				writer.WriteStartArray();
				JsonSerializer.Serialize(writer, dictionaryEntry.Key, inputType, jsonSerializerOptions);
				JsonSerializer.Serialize(writer, dictionaryEntry.Value, type2, jsonSerializerOptions);
				writer.WriteEndArray();
			}
			writer.WriteEndArray();
			writer.WriteEndObject();
		}

		// Token: 0x0602E5C6 RID: 189894 RVA: 0x00AE3EE8 File Offset: 0x00AE20E8
		private static void WriteHashSet<[Nullable(2)] T>(Utf8JsonWriter writer, T value, Type type)
		{
			JsonSerializerOptions options = LauncherJsonSettings.CreateOptionsWithMarkerConverters(LauncherJsonSettings.JsonOptions);
			writer.WriteStartObject();
			writer.WriteString("___MetaType___", "___Set___");
			writer.WritePropertyName("Content");
			JsonSerializer.Serialize(writer, value, type, options);
			writer.WriteEndObject();
		}

		// Token: 0x0401A581 RID: 107905
		private const long JS_MAX_SAFE_INTEGER = 9007199254740991L;
	}
}
