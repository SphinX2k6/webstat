using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CSharpScript.Core.Common;
using CSharpScript.Game.Common.LocalStorageJson.Generated;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x02007065 RID: 28773
	[NullableContext(1)]
	[Nullable(0)]
	public class LocalStorageJsonContext : IStaticVariableResetter
	{
		// Token: 0x06045A97 RID: 285335 RVA: 0x01234863 File Offset: 0x01232A63
		static LocalStorageJsonContext()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LocalStorageJsonContext.CreateStaticDefaultValue), new Action(LocalStorageJsonContext.ResetStaticDefaultValue));
		}

		// Token: 0x06045A98 RID: 285336 RVA: 0x01234884 File Offset: 0x01232A84
		public static LocalStorageJsonContext.Scope EnterScope(ELocalStorageGlobalKey key)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Global:");
			defaultInterpolatedStringHandler.AppendFormatted<ELocalStorageGlobalKey>(key);
			return new LocalStorageJsonContext.Scope(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06045A99 RID: 285337 RVA: 0x012348BC File Offset: 0x01232ABC
		public static LocalStorageJsonContext.Scope EnterScope(ELocalStoragePlayerKey key)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Player:");
			defaultInterpolatedStringHandler.AppendFormatted<ELocalStoragePlayerKey>(key);
			return new LocalStorageJsonContext.Scope(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06045A9A RID: 285338 RVA: 0x012348F4 File Offset: 0x01232AF4
		public static LocalStorageJsonContext.Scope EnterScope(ELocalStorageDeviceKey key)
		{
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(7, 1);
			defaultInterpolatedStringHandler.AppendLiteral("Device:");
			defaultInterpolatedStringHandler.AppendFormatted<ELocalStorageDeviceKey>(key);
			return new LocalStorageJsonContext.Scope(defaultInterpolatedStringHandler.ToStringAndClear());
		}

		// Token: 0x06045A9B RID: 285339 RVA: 0x0123492A File Offset: 0x01232B2A
		public static string GetCurrentProcessKey()
		{
			return LocalStorageJsonContext.CurrentProcessKey ?? "Unknown";
		}

		// Token: 0x06045A9C RID: 285340 RVA: 0x0123493A File Offset: 0x01232B3A
		public static JsonSerializerOptions GetSerializerOptions<[Nullable(2)] T>()
		{
			return LocalStorageJsonContext.OptionsCache.GetOrAdd(typeof(T), (Type _) => LocalStorageJsonContext.BuildSerializerOptions<T>());
		}

		// Token: 0x06045A9D RID: 285341 RVA: 0x0123496F File Offset: 0x01232B6F
		private static JsonSerializerOptions BuildSerializerOptions<[Nullable(2)] T>()
		{
			return new JsonSerializerOptions
			{
				IncludeFields = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				TypeInfoResolver = LocalStorageJsonContext.CreateTypeInfoResolver(),
				Converters = 
				{
					new LocalStorageJsonConverter<T>()
				}
			};
		}

		// Token: 0x06045A9E RID: 285342 RVA: 0x0123499F File Offset: 0x01232B9F
		public static JsonSerializerOptions GetNestedSerializerOptions(Type valueType)
		{
			return LocalStorageJsonContext.NestedJsonOptions;
		}

		// Token: 0x06045A9F RID: 285343 RVA: 0x012349A6 File Offset: 0x01232BA6
		[NullableContext(2)]
		[return: Nullable(1)]
		public static ArrayToKvpConverter<TKey, TValue> GetArrayToKvpConverter<TKey, TValue>()
		{
			return new ArrayToKvpConverter<TKey, TValue>();
		}

		// Token: 0x06045AA0 RID: 285344 RVA: 0x012349AD File Offset: 0x01232BAD
		public static HashSetJsonConverter<T> GetHashSetJsonConverter<[Nullable(2)] T>()
		{
			return new HashSetJsonConverter<T>();
		}

		// Token: 0x06045AA1 RID: 285345 RVA: 0x012349B4 File Offset: 0x01232BB4
		public static JsonTypeInfo GetTypeInfo(Type type)
		{
			return LocalStorageJsonContext.InternalJsonOptions.GetTypeInfo(type);
		}

		// Token: 0x06045AA2 RID: 285346 RVA: 0x012349C1 File Offset: 0x01232BC1
		public static Type UnwrapNullable(Type type)
		{
			return Nullable.GetUnderlyingType(type) ?? type;
		}

		// Token: 0x06045AA3 RID: 285347 RVA: 0x012349D0 File Offset: 0x01232BD0
		public static bool IsScalarType(Type type)
		{
			type = LocalStorageJsonContext.UnwrapNullable(type);
			return type.IsPrimitive || (type == typeof(string) || type == typeof(decimal) || type == typeof(BigInteger) || type == typeof(DateTime) || type == typeof(DateTimeOffset) || type == typeof(Guid) || type == typeof(TimeSpan)) || type.IsEnum;
		}

		// Token: 0x06045AA4 RID: 285348 RVA: 0x01234A78 File Offset: 0x01232C78
		public static bool IsDictionaryType(Type type)
		{
			type = LocalStorageJsonContext.UnwrapNullable(type);
			if (!type.IsGenericType)
			{
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			return genericTypeDefinition == typeof(Dictionary<, >) || genericTypeDefinition == typeof(IDictionary<, >) || genericTypeDefinition == typeof(SortedDictionary<, >) || genericTypeDefinition == typeof(ConcurrentDictionary<, >);
		}

		// Token: 0x06045AA5 RID: 285349 RVA: 0x01234AE8 File Offset: 0x01232CE8
		public static bool IsSetType(Type type)
		{
			type = LocalStorageJsonContext.UnwrapNullable(type);
			if (!type.IsGenericType)
			{
				return false;
			}
			Type genericTypeDefinition = type.GetGenericTypeDefinition();
			return genericTypeDefinition == typeof(HashSet<>) || genericTypeDefinition == typeof(SortedSet<>);
		}

		// Token: 0x06045AA6 RID: 285350 RVA: 0x01234B34 File Offset: 0x01232D34
		public static void CreateStaticDefaultValue()
		{
			LocalStorageJsonContext.GeneratedTypeInfoResolver = LocalStorageJsonSourceGenContext.Default;
			LocalStorageJsonContext.InternalJsonOptions = new JsonSerializerOptions
			{
				IncludeFields = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				TypeInfoResolver = LocalStorageJsonContext.CreateTypeInfoResolver()
			};
			LocalStorageJsonContext.OptionsCache = new ConcurrentDictionary<Type, JsonSerializerOptions>();
			LocalStorageJsonContext.NestedJsonOptions = new JsonSerializerOptions
			{
				IncludeFields = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
				TypeInfoResolver = LocalStorageJsonContext.CreateTypeInfoResolver()
			};
			LocalStorageJsonContext.NestedJsonOptions.Converters.Add(new LocalStorageJsonConverterFactory());
		}

		// Token: 0x06045AA7 RID: 285351 RVA: 0x01234BAF File Offset: 0x01232DAF
		public static void ResetStaticDefaultValue()
		{
			LocalStorageJsonContext.InternalJsonOptions = null;
			LocalStorageJsonContext.OptionsCache = null;
			LocalStorageJsonContext.NestedJsonOptions = null;
			LocalStorageJsonContext.CurrentProcessKey = null;
		}

		// Token: 0x06045AA8 RID: 285352 RVA: 0x01234BCC File Offset: 0x01232DCC
		private unsafe static IJsonTypeInfoResolver CreateTypeInfoResolver()
		{
			DefaultJsonTypeInfoResolver defaultJsonTypeInfoResolver = new DefaultJsonTypeInfoResolver();
			if (LocalStorageJsonContext.GeneratedTypeInfoResolver == null)
			{
				return defaultJsonTypeInfoResolver;
			}
			<>y__InlineArray2<IJsonTypeInfoResolver> <>y__InlineArray = default(<>y__InlineArray2<IJsonTypeInfoResolver>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<IJsonTypeInfoResolver>, IJsonTypeInfoResolver>(ref <>y__InlineArray, 0) = LocalStorageJsonContext.GeneratedTypeInfoResolver;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<IJsonTypeInfoResolver>, IJsonTypeInfoResolver>(ref <>y__InlineArray, 1) = defaultJsonTypeInfoResolver;
			return JsonTypeInfoResolver.Combine(<PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<IJsonTypeInfoResolver>, IJsonTypeInfoResolver>(<>y__InlineArray, 2));
		}

		// Token: 0x04027018 RID: 159768
		[Nullable(2)]
		public static string CurrentProcessKey;

		// Token: 0x04027019 RID: 159769
		[Nullable(2)]
		public static JsonSerializerOptions InternalJsonOptions;

		// Token: 0x0402701A RID: 159770
		[Nullable(2)]
		[StaticVariableRuleIgnore]
		public static IJsonTypeInfoResolver GeneratedTypeInfoResolver;

		// Token: 0x0402701B RID: 159771
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private static ConcurrentDictionary<Type, JsonSerializerOptions> OptionsCache;

		// Token: 0x0402701C RID: 159772
		[Nullable(2)]
		public static JsonSerializerOptions NestedJsonOptions;

		// Token: 0x0200CC7F RID: 52351
		[Nullable(0)]
		public static class ESpecialValue
		{
			// Token: 0x0403EB0D RID: 256781
			public const string Undefined = "___undefined___";

			// Token: 0x0403EB0E RID: 256782
			public const string NaN = "___NaN___";

			// Token: 0x0403EB0F RID: 256783
			public const string Infinity = "___Infinity___";

			// Token: 0x0403EB10 RID: 256784
			public const string InfinityNegative = "___-Infinity___";

			// Token: 0x0403EB11 RID: 256785
			public const string BigInt = "___BI___";

			// Token: 0x0403EB12 RID: 256786
			public const string BooleanTrue = "___1B___";

			// Token: 0x0403EB13 RID: 256787
			public const string BooleanFalse = "___0B___";
		}

		// Token: 0x0200CC80 RID: 52352
		[Nullable(0)]
		public static class EMetaType
		{
			// Token: 0x0403EB14 RID: 256788
			public const string Map = "___Map___";

			// Token: 0x0403EB15 RID: 256789
			public const string Set = "___Set___";
		}

		// Token: 0x0200CC81 RID: 52353
		[NullableContext(2)]
		[Nullable(0)]
		public class MetaJson
		{
			// Token: 0x1700AA68 RID: 43624
			// (get) Token: 0x0604FA77 RID: 326263 RVA: 0x01639D27 File Offset: 0x01637F27
			// (set) Token: 0x0604FA78 RID: 326264 RVA: 0x01639D2F File Offset: 0x01637F2F
			[JsonPropertyName("___MetaType___")]
			public string MetaType { get; set; }

			// Token: 0x1700AA69 RID: 43625
			// (get) Token: 0x0604FA79 RID: 326265 RVA: 0x01639D38 File Offset: 0x01637F38
			// (set) Token: 0x0604FA7A RID: 326266 RVA: 0x01639D40 File Offset: 0x01637F40
			[JsonPropertyName("Content")]
			public JsonElement Content { get; set; }
		}

		// Token: 0x0200CC82 RID: 52354
		[NullableContext(0)]
		public readonly struct Scope : IDisposable
		{
			// Token: 0x0604FA7C RID: 326268 RVA: 0x01639D51 File Offset: 0x01637F51
			[NullableContext(1)]
			internal Scope(string key)
			{
				this.PreviousKey = LocalStorageJsonContext.CurrentProcessKey;
				LocalStorageJsonContext.CurrentProcessKey = key;
			}

			// Token: 0x0604FA7D RID: 326269 RVA: 0x01639D64 File Offset: 0x01637F64
			public void Dispose()
			{
				LocalStorageJsonContext.CurrentProcessKey = this.PreviousKey;
			}

			// Token: 0x0403EB18 RID: 256792
			[Nullable(2)]
			private readonly string PreviousKey;
		}
	}
}
