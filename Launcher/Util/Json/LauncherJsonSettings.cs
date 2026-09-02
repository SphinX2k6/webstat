using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CSharpScript.Launcher.Util.Json.Generated;

namespace CSharpScript.Launcher.Util.Json
{
	// Token: 0x020044B6 RID: 17590
	[NullableContext(1)]
	[Nullable(0)]
	public class LauncherJsonSettings : IStaticVariableResetter
	{
		// Token: 0x0602E5B8 RID: 189880 RVA: 0x00AE36FC File Offset: 0x00AE18FC
		static LauncherJsonSettings()
		{
			StaticVariableRegister.RegisterAndExecute(new Action(LauncherJsonSettings.CreateStaticDefaultValue), new Action(LauncherJsonSettings.ResetStaticDefaultValue));
		}

		// Token: 0x0602E5B9 RID: 189881 RVA: 0x00AE371C File Offset: 0x00AE191C
		public unsafe static void CreateStaticDefaultValue()
		{
			LauncherJsonSettings.SharedTypeInfoResolver = new DefaultJsonTypeInfoResolver();
			<>y__InlineArray2<IJsonTypeInfoResolver> <>y__InlineArray = default(<>y__InlineArray2<IJsonTypeInfoResolver>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<IJsonTypeInfoResolver>, IJsonTypeInfoResolver>(ref <>y__InlineArray, 0) = LauncherJsonSourceGenContext.Default;
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<IJsonTypeInfoResolver>, IJsonTypeInfoResolver>(ref <>y__InlineArray, 1) = LauncherJsonSettings.SharedTypeInfoResolver;
			LauncherJsonSettings.SerializerTypeInfoResolver = JsonTypeInfoResolver.Combine(<PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<IJsonTypeInfoResolver>, IJsonTypeInfoResolver>(<>y__InlineArray, 2));
			LauncherJsonSettings.JsonOptions = new JsonSerializerOptions
			{
				IncludeFields = true,
				DefaultIgnoreCondition = JsonIgnoreCondition.Never,
				TypeInfoResolver = LauncherJsonSettings.SharedTypeInfoResolver
			};
		}

		// Token: 0x0602E5BA RID: 189882 RVA: 0x00AE378C File Offset: 0x00AE198C
		public static void ResetStaticDefaultValue()
		{
			LauncherJsonSettings.JsonOptions = null;
			LauncherJsonSettings.SharedTypeInfoResolver = null;
			LauncherJsonSettings.SerializerTypeInfoResolver = null;
		}

		// Token: 0x0602E5BB RID: 189883 RVA: 0x00AE37A0 File Offset: 0x00AE19A0
		public static JsonSerializerOptions GetSerializerOptions<[Nullable(2)] T>()
		{
			return LauncherJsonSettings.CreateSerializerOptions<T>();
		}

		// Token: 0x0602E5BC RID: 189884 RVA: 0x00AE37A7 File Offset: 0x00AE19A7
		private static JsonSerializerOptions CreateSerializerOptions<[Nullable(2)] T>()
		{
			JsonSerializerOptions jsonSerializerOptions = LauncherJsonSettings.CreateOptions(JsonIgnoreCondition.WhenWritingNull);
			jsonSerializerOptions.Converters.Add(new LauncherJsonConverter<T>());
			return jsonSerializerOptions;
		}

		// Token: 0x0602E5BD RID: 189885 RVA: 0x00AE37BF File Offset: 0x00AE19BF
		public static JsonSerializerOptions CreateOptions(JsonIgnoreCondition defaultIgnoreCondition)
		{
			return new JsonSerializerOptions
			{
				IncludeFields = true,
				DefaultIgnoreCondition = defaultIgnoreCondition,
				TypeInfoResolver = LauncherJsonSettings.SerializerTypeInfoResolver
			};
		}

		// Token: 0x0602E5BE RID: 189886 RVA: 0x00AE37DF File Offset: 0x00AE19DF
		public static JsonSerializerOptions CreateOptionsLike(JsonSerializerOptions options)
		{
			return new JsonSerializerOptions
			{
				IncludeFields = options.IncludeFields,
				DefaultIgnoreCondition = options.DefaultIgnoreCondition,
				TypeInfoResolver = options.TypeInfoResolver
			};
		}

		// Token: 0x0602E5BF RID: 189887 RVA: 0x00AE380C File Offset: 0x00AE1A0C
		public static JsonSerializerOptions CreateOptionsWithMarkerConverters(JsonSerializerOptions options)
		{
			JsonSerializerOptions jsonSerializerOptions = LauncherJsonSettings.CreateOptionsLike(options);
			HashSet<Type> hashSet = new HashSet<Type>
			{
				typeof(LauncherJsonConverter<bool>),
				typeof(LauncherJsonConverter<long>),
				typeof(LauncherJsonConverter<float>),
				typeof(LauncherJsonConverter<double>)
			};
			foreach (JsonConverter jsonConverter in options.Converters)
			{
				jsonSerializerOptions.Converters.Add(jsonConverter);
				hashSet.Remove(jsonConverter.GetType());
			}
			if (hashSet.Contains(typeof(LauncherJsonConverter<bool>)))
			{
				jsonSerializerOptions.Converters.Add(new LauncherJsonConverter<bool>());
			}
			if (hashSet.Contains(typeof(LauncherJsonConverter<long>)))
			{
				jsonSerializerOptions.Converters.Add(new LauncherJsonConverter<long>());
			}
			if (hashSet.Contains(typeof(LauncherJsonConverter<float>)))
			{
				jsonSerializerOptions.Converters.Add(new LauncherJsonConverter<float>());
			}
			if (hashSet.Contains(typeof(LauncherJsonConverter<double>)))
			{
				jsonSerializerOptions.Converters.Add(new LauncherJsonConverter<double>());
			}
			return jsonSerializerOptions;
		}

		// Token: 0x0602E5C0 RID: 189888 RVA: 0x00AE3948 File Offset: 0x00AE1B48
		public static bool IsGenericDictionary(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Dictionary<, >))
			{
				return true;
			}
			foreach (Type type2 in type.GetInterfaces())
			{
				if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(IDictionary<, >))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0602E5C1 RID: 189889 RVA: 0x00AE39B4 File Offset: 0x00AE1BB4
		public static bool IsGenericHashSet(Type type)
		{
			if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(HashSet<>))
			{
				return true;
			}
			foreach (Type type2 in type.GetInterfaces())
			{
				if (type2.IsGenericType && type2.GetGenericTypeDefinition() == typeof(ISet<>))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0401A57E RID: 107902
		[Nullable(2)]
		public static JsonSerializerOptions JsonOptions;

		// Token: 0x0401A57F RID: 107903
		[Nullable(2)]
		private static IJsonTypeInfoResolver SharedTypeInfoResolver;

		// Token: 0x0401A580 RID: 107904
		[Nullable(2)]
		private static IJsonTypeInfoResolver SerializerTypeInfoResolver;

		// Token: 0x0200A685 RID: 42629
		[Nullable(0)]
		public static class ESpecialValue
		{
			// Token: 0x040337A9 RID: 210857
			public const string Undefined = "___undefined___";

			// Token: 0x040337AA RID: 210858
			public const string NaN = "___NaN___";

			// Token: 0x040337AB RID: 210859
			public const string Infinity = "___Infinity___";

			// Token: 0x040337AC RID: 210860
			public const string InfinityNegative = "___-Infinity___";

			// Token: 0x040337AD RID: 210861
			public const string BigInt = "___BI___";

			// Token: 0x040337AE RID: 210862
			public const string Long = "__kr_long__";

			// Token: 0x040337AF RID: 210863
			public const string BooleanTrue = "___1B___";

			// Token: 0x040337B0 RID: 210864
			public const string BooleanFalse = "___0B___";

			// Token: 0x040337B1 RID: 210865
			public const string Map = "__kr_map__";
		}

		// Token: 0x0200A686 RID: 42630
		[Nullable(0)]
		public static class EMetaType
		{
			// Token: 0x040337B2 RID: 210866
			public const string Map = "___Map___";

			// Token: 0x040337B3 RID: 210867
			public const string Set = "___Set___";
		}

		// Token: 0x0200A687 RID: 42631
		[Nullable(0)]
		public static class EMetaPropertyName
		{
			// Token: 0x040337B4 RID: 210868
			public const string MetaType = "___MetaType___";

			// Token: 0x040337B5 RID: 210869
			public const string Content = "Content";
		}

		// Token: 0x0200A688 RID: 42632
		[NullableContext(2)]
		[Nullable(0)]
		public class MetaJson
		{
			// Token: 0x1700A909 RID: 43273
			// (get) Token: 0x0604A684 RID: 304772 RVA: 0x0143681E File Offset: 0x01434A1E
			// (set) Token: 0x0604A685 RID: 304773 RVA: 0x01436826 File Offset: 0x01434A26
			[JsonPropertyName("___MetaType___")]
			public string MetaType { get; set; }

			// Token: 0x1700A90A RID: 43274
			// (get) Token: 0x0604A686 RID: 304774 RVA: 0x0143682F File Offset: 0x01434A2F
			// (set) Token: 0x0604A687 RID: 304775 RVA: 0x01436837 File Offset: 0x01434A37
			[JsonPropertyName("Content")]
			public object Content { get; set; }
		}
	}
}
