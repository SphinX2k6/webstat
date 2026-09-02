using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using CSharpScript.Core.Common;

namespace CSharpScript.Core.Define.TdConfigExtensions
{
	// Token: 0x02007132 RID: 28978
	[NullableContext(2)]
	[Nullable(0)]
	public static class RpcArgUtils
	{
		// Token: 0x060462A8 RID: 287400 RVA: 0x0126D3B4 File Offset: 0x0126B5B4
		[NullableContext(1)]
		public static T To<T>([Nullable(2)] object value)
		{
			if (value == null || RpcArgUtils.IsJsonNull(value))
			{
				throw new ArgumentException("RpcArgUtils.To<" + typeof(T).Name + ">: 需要非空参数,实际为 null");
			}
			T t = RpcArgUtils.Decode<T>(value);
			if (t == null)
			{
				throw new ArgumentException("RpcArgUtils.To<" + typeof(T).Name + ">: 解析结果为 null");
			}
			return t;
		}

		// Token: 0x060462A9 RID: 287401 RVA: 0x0126D424 File Offset: 0x0126B624
		public static T ToNullable<T>(object value)
		{
			if (value == null || RpcArgUtils.IsJsonNull(value))
			{
				return default(T);
			}
			return RpcArgUtils.Decode<T>(value);
		}

		// Token: 0x060462AA RID: 287402 RVA: 0x0126D44C File Offset: 0x0126B64C
		private static T Decode<T>([Nullable(1)] object value)
		{
			if (value is T)
			{
				return (T)((object)value);
			}
			if (value is JsonElement)
			{
				JsonElement element = (JsonElement)value;
				return element.Deserialize(JsonSettings.DecodeOptions);
			}
			if (value == null)
			{
				return default(T);
			}
			T result;
			if (RpcArgUtils.TryConvert<T>(value, out result))
			{
				return result;
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(26, 3);
			defaultInterpolatedStringHandler.AppendLiteral("RpcArgUtils.To<");
			defaultInterpolatedStringHandler.AppendFormatted(typeof(T).Name);
			defaultInterpolatedStringHandler.AppendLiteral(">: 需要 ");
			defaultInterpolatedStringHandler.AppendFormatted(typeof(T).Name);
			defaultInterpolatedStringHandler.AppendLiteral(",实际为 ");
			defaultInterpolatedStringHandler.AppendFormatted(value.GetType().Name);
			throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x060462AB RID: 287403 RVA: 0x0126D51C File Offset: 0x0126B71C
		private static bool IsJsonNull(object value)
		{
			if (value is JsonElement)
			{
				JsonValueKind valueKind = ((JsonElement)value).ValueKind;
				if (valueKind == JsonValueKind.Undefined || valueKind == JsonValueKind.Null)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060462AC RID: 287404 RVA: 0x0126D550 File Offset: 0x0126B750
		private static bool TryConvert<T>([Nullable(1)] object value, out T result)
		{
			Type type = Nullable.GetUnderlyingType(typeof(T)) ?? typeof(T);
			try
			{
				if (type.IsEnum)
				{
					result = (T)((object)Enum.ToObject(type, value));
					return true;
				}
				if (value is IConvertible && typeof(IConvertible).IsAssignableFrom(type))
				{
					result = (T)((object)Convert.ChangeType(value, type));
					return true;
				}
			}
			catch
			{
			}
			result = default(T);
			return false;
		}

		// Token: 0x060462AD RID: 287405 RVA: 0x0126D5E8 File Offset: 0x0126B7E8
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public static OneOf<T1, T2> ToOneOf<T1, T2>(object value)
		{
			if (value == null || RpcArgUtils.IsJsonNull(value))
			{
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(39, 2);
				defaultInterpolatedStringHandler.AppendLiteral("RpcArgUtils.ToOneOf<");
				defaultInterpolatedStringHandler.AppendFormatted(typeof(T1).Name);
				defaultInterpolatedStringHandler.AppendLiteral(",");
				defaultInterpolatedStringHandler.AppendFormatted(typeof(T2).Name);
				defaultInterpolatedStringHandler.AppendLiteral(">: 需要非空参数,实际为 null");
				throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
			}
			return RpcArgUtils.DecodeOneOf<T1, T2>(value);
		}

		// Token: 0x060462AE RID: 287406 RVA: 0x0126D670 File Offset: 0x0126B870
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		public static OneOf<T1, T2>? ToOneOfNullable<T1, T2>(object value)
		{
			if (value == null || RpcArgUtils.IsJsonNull(value))
			{
				return null;
			}
			return new OneOf<T1, T2>?(RpcArgUtils.DecodeOneOf<T1, T2>(value));
		}

		// Token: 0x060462AF RID: 287407 RVA: 0x0126D6A0 File Offset: 0x0126B8A0
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private static OneOf<T1, T2> DecodeOneOf<T1, T2>([Nullable(1)] object value)
		{
			if (value is OneOf<T1, T2>)
			{
				return (OneOf<T1, T2>)value;
			}
			if (value is T1)
			{
				T1 value2 = (T1)((object)value);
				return value2;
			}
			if (value is T2)
			{
				T2 value3 = (T2)((object)value);
				return value3;
			}
			if (value is JsonElement)
			{
				JsonElement element = (JsonElement)value;
				return RpcArgUtils.FromJsonElement<T1, T2>(element);
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 3);
			defaultInterpolatedStringHandler.AppendLiteral("RpcArgUtils.DecodeOneOf<");
			defaultInterpolatedStringHandler.AppendFormatted(typeof(T1).Name);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted(typeof(T2).Name);
			defaultInterpolatedStringHandler.AppendLiteral(">: 无法转换 ");
			defaultInterpolatedStringHandler.AppendFormatted(value.GetType().Name);
			throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x060462B0 RID: 287408 RVA: 0x0126D780 File Offset: 0x0126B980
		[return: Nullable(new byte[]
		{
			0,
			1,
			1
		})]
		private static OneOf<T1, T2> FromJsonElement<T1, T2>(JsonElement element)
		{
			bool flag = RpcArgUtils.KindMatches(typeof(T1), element.ValueKind);
			bool flag2 = RpcArgUtils.KindMatches(typeof(T2), element.ValueKind);
			if (flag && !flag2)
			{
				return new OneOf<T1, T2>(element.Deserialize(JsonSettings.DecodeOptions));
			}
			if (flag2 && !flag)
			{
				return new OneOf<T1, T2>(element.Deserialize(JsonSettings.DecodeOptions));
			}
			try
			{
				T1 t = element.Deserialize(JsonSettings.DecodeOptions);
				if (t != null)
				{
					return new OneOf<T1, T2>(t);
				}
			}
			catch
			{
			}
			try
			{
				T2 t2 = element.Deserialize(JsonSettings.DecodeOptions);
				if (t2 != null)
				{
					return new OneOf<T1, T2>(t2);
				}
			}
			catch
			{
			}
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(50, 3);
			defaultInterpolatedStringHandler.AppendLiteral("RpcArgUtils.FromJsonElement<");
			defaultInterpolatedStringHandler.AppendFormatted(typeof(T1).Name);
			defaultInterpolatedStringHandler.AppendLiteral(",");
			defaultInterpolatedStringHandler.AppendFormatted(typeof(T2).Name);
			defaultInterpolatedStringHandler.AppendLiteral(">: ");
			defaultInterpolatedStringHandler.AppendLiteral("JSON 形态 ");
			defaultInterpolatedStringHandler.AppendFormatted<JsonValueKind>(element.ValueKind);
			defaultInterpolatedStringHandler.AppendLiteral(" 无法解析为任一分支");
			throw new ArgumentException(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x060462B1 RID: 287409 RVA: 0x0126D8E4 File Offset: 0x0126BAE4
		[NullableContext(1)]
		private static bool KindMatches(Type type, JsonValueKind kind)
		{
			Type type2 = Nullable.GetUnderlyingType(type) ?? type;
			if (type2 == typeof(string))
			{
				return kind == JsonValueKind.String;
			}
			if (RpcArgUtils.IsBase64Bytes(type2))
			{
				return kind == JsonValueKind.String;
			}
			if (RpcArgUtils.IsDictionary(type2))
			{
				return kind == JsonValueKind.Object;
			}
			if (typeof(IEnumerable).IsAssignableFrom(type2))
			{
				return kind == JsonValueKind.Array;
			}
			if (type2 == typeof(bool))
			{
				return kind - JsonValueKind.True <= 1;
			}
			if (type2.IsEnum)
			{
				return kind == ((Attribute.IsDefined(type2, typeof(EnumExtensionsAttribute)) && Attribute.IsDefined(type2, typeof(JsonConverterAttribute))) ? JsonValueKind.String : JsonValueKind.Number);
			}
			if (type2.IsPrimitive || type2 == typeof(decimal))
			{
				return kind == JsonValueKind.Number;
			}
			return kind == JsonValueKind.Object;
		}

		// Token: 0x060462B2 RID: 287410 RVA: 0x0126D9C1 File Offset: 0x0126BBC1
		[NullableContext(1)]
		private static bool IsBase64Bytes(Type t)
		{
			return t == typeof(byte[]) || t == typeof(Memory<byte>) || t == typeof(ReadOnlyMemory<byte>);
		}

		// Token: 0x060462B3 RID: 287411 RVA: 0x0126D9FC File Offset: 0x0126BBFC
		[NullableContext(1)]
		private static bool IsDictionary(Type t)
		{
			if (typeof(IDictionary).IsAssignableFrom(t))
			{
				return true;
			}
			if (RpcArgUtils.IsDictionaryGenericInterface(t))
			{
				return true;
			}
			Type[] interfaces = t.GetInterfaces();
			for (int i = 0; i < interfaces.Length; i++)
			{
				if (RpcArgUtils.IsDictionaryGenericInterface(interfaces[i]))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060462B4 RID: 287412 RVA: 0x0126DA4C File Offset: 0x0126BC4C
		[NullableContext(1)]
		private static bool IsDictionaryGenericInterface(Type i)
		{
			if (!i.IsGenericType)
			{
				return false;
			}
			Type genericTypeDefinition = i.GetGenericTypeDefinition();
			return genericTypeDefinition == typeof(IDictionary<, >) || genericTypeDefinition == typeof(IReadOnlyDictionary<, >);
		}
	}
}
