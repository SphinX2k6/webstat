using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Json.Serialization.Metadata;
using CSharpScript.Game.Module.WorldMap;
using FilterDefine;

namespace CSharpScript.Game.Common.LocalStorageJson.Generated
{
	// Token: 0x0200706D RID: 28781
	[JsonSourceGenerationOptions(GenerationMode = JsonSourceGenerationMode.Metadata, IncludeFields = true, DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull)]
	[JsonSerializable(typeof(bool))]
	[JsonSerializable(typeof(bool?))]
	[JsonSerializable(typeof(double))]
	[JsonSerializable(typeof(double?))]
	[JsonSerializable(typeof(double[]))]
	[JsonSerializable(typeof(float))]
	[JsonSerializable(typeof(float?))]
	[JsonSerializable(typeof(float[]))]
	[JsonSerializable(typeof(AbyssDangoOwnerData))]
	[JsonSerializable(typeof(ActivityCacheData))]
	[JsonSerializable(typeof(AreaExplorePlayState))]
	[JsonSerializable(typeof(EMapNoteId))]
	[JsonSerializable(typeof(EExploreType))]
	[JsonSerializable(typeof(EFunction))]
	[JsonSerializable(typeof(EMotorMusicPlayMode))]
	[JsonSerializable(typeof(EPlayPointState))]
	[JsonSerializable(typeof(ERouletteType))]
	[JsonSerializable(typeof(ERouletteType?))]
	[JsonSerializable(typeof(EVisionLevelUpIdentify))]
	[JsonSerializable(typeof(EVisionLevelUpIdentify?))]
	[JsonSerializable(typeof(EVisionLevelUpMaterialPutInMode))]
	[JsonSerializable(typeof(EVisionLevelUpMaterialPutInMode?))]
	[JsonSerializable(typeof(EVisionLevelUpMaterialUseType))]
	[JsonSerializable(typeof(EVisionLevelUpMaterialUseType?))]
	[JsonSerializable(typeof(FilterDefine.EFilterType))]
	[JsonSerializable(typeof(FilterStorageData))]
	[JsonSerializable(typeof(GamepadTypeUsage))]
	[JsonSerializable(typeof(GameQualityData))]
	[JsonSerializable(typeof(LocalFriendApplication))]
	[JsonSerializable(typeof(LocalPlayerIpLevelData))]
	[JsonSerializable(typeof(LocalPlayerIpLevelData[]))]
	[JsonSerializable(typeof(MarqueeStorageData))]
	[JsonSerializable(typeof(RacingBetsRedDotState))]
	[JsonSerializable(typeof(RegionAndIpSt))]
	[JsonSerializable(typeof(SortStorageData))]
	[JsonSerializable(typeof(Dictionary<EFunction, int>))]
	[JsonSerializable(typeof(Dictionary<FilterDefine.EFilterType, List<int>>))]
	[JsonSerializable(typeof(Dictionary<int, bool>))]
	[JsonSerializable(typeof(Dictionary<int, double>))]
	[JsonSerializable(typeof(Dictionary<int, float>))]
	[JsonSerializable(typeof(Dictionary<int, float[]>))]
	[JsonSerializable(typeof(Dictionary<int, AbyssDangoOwnerData>))]
	[JsonSerializable(typeof(Dictionary<int, AreaExplorePlayState>))]
	[JsonSerializable(typeof(Dictionary<int, LocalFriendApplication>))]
	[JsonSerializable(typeof(Dictionary<int, Dictionary<int, double>>))]
	[JsonSerializable(typeof(Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>))]
	[JsonSerializable(typeof(Dictionary<int, Dictionary<int, AreaExplorePlayState>>))]
	[JsonSerializable(typeof(Dictionary<int, Dictionary<int, HashSet<int>>>))]
	[JsonSerializable(typeof(Dictionary<int, HashSet<int>>))]
	[JsonSerializable(typeof(Dictionary<int, List<int>>))]
	[JsonSerializable(typeof(Dictionary<int, int>))]
	[JsonSerializable(typeof(Dictionary<int, int[]>))]
	[JsonSerializable(typeof(Dictionary<int, long>))]
	[JsonSerializable(typeof(Dictionary<int, string>))]
	[JsonSerializable(typeof(Dictionary<string, bool>))]
	[JsonSerializable(typeof(Dictionary<string, FilterStorageData>))]
	[JsonSerializable(typeof(Dictionary<string, GamepadTypeUsage>))]
	[JsonSerializable(typeof(Dictionary<string, LocalPlayerIpLevelData[]>))]
	[JsonSerializable(typeof(Dictionary<string, MarqueeStorageData>))]
	[JsonSerializable(typeof(Dictionary<string, RegionAndIpSt>))]
	[JsonSerializable(typeof(Dictionary<string, SortStorageData>))]
	[JsonSerializable(typeof(Dictionary<string, List<ActivityCacheData>>))]
	[JsonSerializable(typeof(Dictionary<string, int>))]
	[JsonSerializable(typeof(HashSet<EMapNoteId>))]
	[JsonSerializable(typeof(HashSet<int>))]
	[JsonSerializable(typeof(List<ActivityCacheData>))]
	[JsonSerializable(typeof(List<EPlayPointState>))]
	[JsonSerializable(typeof(List<int>))]
	[JsonSerializable(typeof(List<string>))]
	[JsonSerializable(typeof(int))]
	[JsonSerializable(typeof(int?))]
	[JsonSerializable(typeof(int[]))]
	[JsonSerializable(typeof(long))]
	[JsonSerializable(typeof(object))]
	[JsonSerializable(typeof(string))]
	[JsonSerializable(typeof(string[]))]
	[JsonSerializable(typeof(IRacingBetsSettlementMainViewRecord))]
	[JsonSerializable(typeof(Dictionary<string, IList<IList<string>>>))]
	[GeneratedCode("System.Text.Json.SourceGeneration", "9.0.12.26613")]
	internal class LocalStorageJsonSourceGenContext : JsonSerializerContext, IJsonTypeInfoResolver
	{
		// Token: 0x1700A542 RID: 42306
		// (get) Token: 0x06045ADD RID: 285405 RVA: 0x012365D4 File Offset: 0x012347D4
		public JsonTypeInfo<bool> Boolean
		{
			get
			{
				JsonTypeInfo<bool> result;
				if ((result = this._Boolean) == null)
				{
					result = (this._Boolean = (JsonTypeInfo<bool>)base.Options.GetTypeInfo(typeof(bool)));
				}
				return result;
			}
		}

		// Token: 0x06045ADE RID: 285406 RVA: 0x01236610 File Offset: 0x01234810
		[NullableContext(1)]
		private JsonTypeInfo<bool> Create_Boolean(JsonSerializerOptions options)
		{
			JsonTypeInfo<bool> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<bool>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool>(options, JsonMetadataServices.BooleanConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A543 RID: 42307
		// (get) Token: 0x06045ADF RID: 285407 RVA: 0x0123663C File Offset: 0x0123483C
		public JsonTypeInfo<bool?> NullableBoolean
		{
			get
			{
				JsonTypeInfo<bool?> result;
				if ((result = this._NullableBoolean) == null)
				{
					result = (this._NullableBoolean = (JsonTypeInfo<bool?>)base.Options.GetTypeInfo(typeof(bool?)));
				}
				return result;
			}
		}

		// Token: 0x06045AE0 RID: 285408 RVA: 0x01236678 File Offset: 0x01234878
		[NullableContext(1)]
		private JsonTypeInfo<bool?> Create_NullableBoolean(JsonSerializerOptions options)
		{
			JsonTypeInfo<bool?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<bool?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<bool>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<bool?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A544 RID: 42308
		// (get) Token: 0x06045AE1 RID: 285409 RVA: 0x012366A8 File Offset: 0x012348A8
		public JsonTypeInfo<double> Double
		{
			get
			{
				JsonTypeInfo<double> result;
				if ((result = this._Double) == null)
				{
					result = (this._Double = (JsonTypeInfo<double>)base.Options.GetTypeInfo(typeof(double)));
				}
				return result;
			}
		}

		// Token: 0x06045AE2 RID: 285410 RVA: 0x012366E4 File Offset: 0x012348E4
		[NullableContext(1)]
		private JsonTypeInfo<double> Create_Double(JsonSerializerOptions options)
		{
			JsonTypeInfo<double> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<double>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<double>(options, JsonMetadataServices.DoubleConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A545 RID: 42309
		// (get) Token: 0x06045AE3 RID: 285411 RVA: 0x01236710 File Offset: 0x01234910
		public JsonTypeInfo<double?> NullableDouble
		{
			get
			{
				JsonTypeInfo<double?> result;
				if ((result = this._NullableDouble) == null)
				{
					result = (this._NullableDouble = (JsonTypeInfo<double?>)base.Options.GetTypeInfo(typeof(double?)));
				}
				return result;
			}
		}

		// Token: 0x06045AE4 RID: 285412 RVA: 0x0123674C File Offset: 0x0123494C
		[NullableContext(1)]
		private JsonTypeInfo<double?> Create_NullableDouble(JsonSerializerOptions options)
		{
			JsonTypeInfo<double?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<double?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<double>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<double?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A546 RID: 42310
		// (get) Token: 0x06045AE5 RID: 285413 RVA: 0x0123677C File Offset: 0x0123497C
		public JsonTypeInfo<double[]> DoubleArray
		{
			get
			{
				JsonTypeInfo<double[]> result;
				if ((result = this._DoubleArray) == null)
				{
					result = (this._DoubleArray = (JsonTypeInfo<double[]>)base.Options.GetTypeInfo(typeof(double[])));
				}
				return result;
			}
		}

		// Token: 0x06045AE6 RID: 285414 RVA: 0x012367B8 File Offset: 0x012349B8
		[NullableContext(1)]
		private JsonTypeInfo<double[]> Create_DoubleArray(JsonSerializerOptions options)
		{
			JsonTypeInfo<double[]> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<double[]>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<double[]> collectionInfo = new JsonCollectionInfoValues<double[]>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo<double>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A547 RID: 42311
		// (get) Token: 0x06045AE7 RID: 285415 RVA: 0x01236804 File Offset: 0x01234A04
		public JsonTypeInfo<float> Single
		{
			get
			{
				JsonTypeInfo<float> result;
				if ((result = this._Single) == null)
				{
					result = (this._Single = (JsonTypeInfo<float>)base.Options.GetTypeInfo(typeof(float)));
				}
				return result;
			}
		}

		// Token: 0x06045AE8 RID: 285416 RVA: 0x01236840 File Offset: 0x01234A40
		[NullableContext(1)]
		private JsonTypeInfo<float> Create_Single(JsonSerializerOptions options)
		{
			JsonTypeInfo<float> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<float>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<float>(options, JsonMetadataServices.SingleConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A548 RID: 42312
		// (get) Token: 0x06045AE9 RID: 285417 RVA: 0x0123686C File Offset: 0x01234A6C
		public JsonTypeInfo<float?> NullableSingle
		{
			get
			{
				JsonTypeInfo<float?> result;
				if ((result = this._NullableSingle) == null)
				{
					result = (this._NullableSingle = (JsonTypeInfo<float?>)base.Options.GetTypeInfo(typeof(float?)));
				}
				return result;
			}
		}

		// Token: 0x06045AEA RID: 285418 RVA: 0x012368A8 File Offset: 0x01234AA8
		[NullableContext(1)]
		private JsonTypeInfo<float?> Create_NullableSingle(JsonSerializerOptions options)
		{
			JsonTypeInfo<float?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<float?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<float>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<float?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A549 RID: 42313
		// (get) Token: 0x06045AEB RID: 285419 RVA: 0x012368D8 File Offset: 0x01234AD8
		public JsonTypeInfo<float[]> SingleArray
		{
			get
			{
				JsonTypeInfo<float[]> result;
				if ((result = this._SingleArray) == null)
				{
					result = (this._SingleArray = (JsonTypeInfo<float[]>)base.Options.GetTypeInfo(typeof(float[])));
				}
				return result;
			}
		}

		// Token: 0x06045AEC RID: 285420 RVA: 0x01236914 File Offset: 0x01234B14
		[NullableContext(1)]
		private JsonTypeInfo<float[]> Create_SingleArray(JsonSerializerOptions options)
		{
			JsonTypeInfo<float[]> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<float[]>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<float[]> collectionInfo = new JsonCollectionInfoValues<float[]>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo<float>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A54A RID: 42314
		// (get) Token: 0x06045AED RID: 285421 RVA: 0x01236960 File Offset: 0x01234B60
		public JsonTypeInfo<AbyssDangoOwnerData> AbyssDangoOwnerData
		{
			get
			{
				JsonTypeInfo<AbyssDangoOwnerData> result;
				if ((result = this._AbyssDangoOwnerData) == null)
				{
					result = (this._AbyssDangoOwnerData = (JsonTypeInfo<AbyssDangoOwnerData>)base.Options.GetTypeInfo(typeof(AbyssDangoOwnerData)));
				}
				return result;
			}
		}

		// Token: 0x06045AEE RID: 285422 RVA: 0x0123699C File Offset: 0x01234B9C
		[NullableContext(1)]
		private JsonTypeInfo<AbyssDangoOwnerData> Create_AbyssDangoOwnerData(JsonSerializerOptions options)
		{
			JsonTypeInfo<AbyssDangoOwnerData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<AbyssDangoOwnerData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<AbyssDangoOwnerData> jsonObjectInfoValues = new JsonObjectInfoValues<AbyssDangoOwnerData>();
				jsonObjectInfoValues.ObjectCreator = (() => new AbyssDangoOwnerData());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.AbyssDangoOwnerDataPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(AbyssDangoOwnerData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<AbyssDangoOwnerData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<AbyssDangoOwnerData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045AEF RID: 285423 RVA: 0x01236A64 File Offset: 0x01234C64
		[NullableContext(1)]
		private static JsonPropertyInfo[] AbyssDangoOwnerDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[5];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(AbyssDangoOwnerData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((AbyssDangoOwnerData)obj).PlayerId);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((AbyssDangoOwnerData)obj).PlayerId = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "PlayerId";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(AbyssDangoOwnerData).GetField("PlayerId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<int> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(AbyssDangoOwnerData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((AbyssDangoOwnerData)obj).RoleCfgId);
			jsonPropertyInfoValues2.Setter = delegate(object obj, int value)
			{
				((AbyssDangoOwnerData)obj).RoleCfgId = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "RoleCfgId";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(AbyssDangoOwnerData).GetField("RoleCfgId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo2);
			JsonPropertyInfoValues<int> jsonPropertyInfoValues3 = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues3.IsProperty = false;
			jsonPropertyInfoValues3.IsPublic = true;
			jsonPropertyInfoValues3.IsVirtual = false;
			jsonPropertyInfoValues3.DeclaringType = typeof(AbyssDangoOwnerData);
			jsonPropertyInfoValues3.Converter = null;
			jsonPropertyInfoValues3.Getter = ((object obj) => ((AbyssDangoOwnerData)obj).DangoId);
			jsonPropertyInfoValues3.Setter = delegate(object obj, int value)
			{
				((AbyssDangoOwnerData)obj).DangoId = value;
			};
			jsonPropertyInfoValues3.IgnoreCondition = null;
			jsonPropertyInfoValues3.HasJsonInclude = false;
			jsonPropertyInfoValues3.IsExtensionData = false;
			jsonPropertyInfoValues3.NumberHandling = null;
			jsonPropertyInfoValues3.PropertyName = "DangoId";
			jsonPropertyInfoValues3.JsonPropertyName = null;
			jsonPropertyInfoValues3.AttributeProviderFactory = (() => typeof(AbyssDangoOwnerData).GetField("DangoId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo3 = jsonPropertyInfoValues3;
			array[2] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo3);
			JsonPropertyInfoValues<int> jsonPropertyInfoValues4 = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues4.IsProperty = false;
			jsonPropertyInfoValues4.IsPublic = true;
			jsonPropertyInfoValues4.IsVirtual = false;
			jsonPropertyInfoValues4.DeclaringType = typeof(AbyssDangoOwnerData);
			jsonPropertyInfoValues4.Converter = null;
			jsonPropertyInfoValues4.Getter = ((object obj) => ((AbyssDangoOwnerData)obj).DangoLevel);
			jsonPropertyInfoValues4.Setter = delegate(object obj, int value)
			{
				((AbyssDangoOwnerData)obj).DangoLevel = value;
			};
			jsonPropertyInfoValues4.IgnoreCondition = null;
			jsonPropertyInfoValues4.HasJsonInclude = false;
			jsonPropertyInfoValues4.IsExtensionData = false;
			jsonPropertyInfoValues4.NumberHandling = null;
			jsonPropertyInfoValues4.PropertyName = "DangoLevel";
			jsonPropertyInfoValues4.JsonPropertyName = null;
			jsonPropertyInfoValues4.AttributeProviderFactory = (() => typeof(AbyssDangoOwnerData).GetField("DangoLevel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo4 = jsonPropertyInfoValues4;
			array[3] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo4);
			JsonPropertyInfoValues<int[]> jsonPropertyInfoValues5 = new JsonPropertyInfoValues<int[]>();
			jsonPropertyInfoValues5.IsProperty = false;
			jsonPropertyInfoValues5.IsPublic = true;
			jsonPropertyInfoValues5.IsVirtual = false;
			jsonPropertyInfoValues5.DeclaringType = typeof(AbyssDangoOwnerData);
			jsonPropertyInfoValues5.Converter = null;
			jsonPropertyInfoValues5.Getter = ((object obj) => ((AbyssDangoOwnerData)obj).DangoEquipIds);
			jsonPropertyInfoValues5.Setter = delegate(object obj, [Nullable(2)] int[] value)
			{
				((AbyssDangoOwnerData)obj).DangoEquipIds = value;
			};
			jsonPropertyInfoValues5.IgnoreCondition = null;
			jsonPropertyInfoValues5.HasJsonInclude = false;
			jsonPropertyInfoValues5.IsExtensionData = false;
			jsonPropertyInfoValues5.NumberHandling = null;
			jsonPropertyInfoValues5.PropertyName = "DangoEquipIds";
			jsonPropertyInfoValues5.JsonPropertyName = null;
			jsonPropertyInfoValues5.AttributeProviderFactory = (() => typeof(AbyssDangoOwnerData).GetField("DangoEquipIds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int[]> propertyInfo5 = jsonPropertyInfoValues5;
			array[4] = JsonMetadataServices.CreatePropertyInfo<int[]>(options, propertyInfo5);
			array[4].IsGetNullable = false;
			array[4].IsSetNullable = false;
			return array;
		}

		// Token: 0x1700A54B RID: 42315
		// (get) Token: 0x06045AF0 RID: 285424 RVA: 0x01236F24 File Offset: 0x01235124
		public JsonTypeInfo<ActivityCacheData> ActivityCacheData
		{
			get
			{
				JsonTypeInfo<ActivityCacheData> result;
				if ((result = this._ActivityCacheData) == null)
				{
					result = (this._ActivityCacheData = (JsonTypeInfo<ActivityCacheData>)base.Options.GetTypeInfo(typeof(ActivityCacheData)));
				}
				return result;
			}
		}

		// Token: 0x06045AF1 RID: 285425 RVA: 0x01236F60 File Offset: 0x01235160
		[NullableContext(1)]
		private JsonTypeInfo<ActivityCacheData> Create_ActivityCacheData(JsonSerializerOptions options)
		{
			JsonTypeInfo<ActivityCacheData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<ActivityCacheData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<ActivityCacheData> jsonObjectInfoValues = new JsonObjectInfoValues<ActivityCacheData>();
				jsonObjectInfoValues.ObjectCreator = (() => new ActivityCacheData());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.ActivityCacheDataPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(ActivityCacheData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<ActivityCacheData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<ActivityCacheData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045AF2 RID: 285426 RVA: 0x01237028 File Offset: 0x01235228
		[NullableContext(1)]
		private static JsonPropertyInfo[] ActivityCacheDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(ActivityCacheData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((ActivityCacheData)obj).Key);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((ActivityCacheData)obj).Key = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "Key";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(ActivityCacheData).GetField("Key", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<int> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(ActivityCacheData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((ActivityCacheData)obj).Value);
			jsonPropertyInfoValues2.Setter = delegate(object obj, int value)
			{
				((ActivityCacheData)obj).Value = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "Value";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(ActivityCacheData).GetField("Value", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo2);
			return array;
		}

		// Token: 0x1700A54C RID: 42316
		// (get) Token: 0x06045AF3 RID: 285427 RVA: 0x01237210 File Offset: 0x01235410
		public JsonTypeInfo<AreaExplorePlayState> AreaExplorePlayState
		{
			get
			{
				JsonTypeInfo<AreaExplorePlayState> result;
				if ((result = this._AreaExplorePlayState) == null)
				{
					result = (this._AreaExplorePlayState = (JsonTypeInfo<AreaExplorePlayState>)base.Options.GetTypeInfo(typeof(AreaExplorePlayState)));
				}
				return result;
			}
		}

		// Token: 0x06045AF4 RID: 285428 RVA: 0x0123724C File Offset: 0x0123544C
		[NullableContext(1)]
		private JsonTypeInfo<AreaExplorePlayState> Create_AreaExplorePlayState(JsonSerializerOptions options)
		{
			JsonTypeInfo<AreaExplorePlayState> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<AreaExplorePlayState>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<AreaExplorePlayState> jsonObjectInfoValues = new JsonObjectInfoValues<AreaExplorePlayState>();
				jsonObjectInfoValues.ObjectCreator = (() => new AreaExplorePlayState());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.AreaExplorePlayStatePropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(AreaExplorePlayState).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<AreaExplorePlayState> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<AreaExplorePlayState>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045AF5 RID: 285429 RVA: 0x01237314 File Offset: 0x01235514
		[NullableContext(1)]
		private static JsonPropertyInfo[] AreaExplorePlayStatePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<EExploreType> jsonPropertyInfoValues = new JsonPropertyInfoValues<EExploreType>();
			jsonPropertyInfoValues.IsProperty = true;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(AreaExplorePlayState);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((AreaExplorePlayState)obj).ExploreType);
			jsonPropertyInfoValues.Setter = delegate(object obj, EExploreType value)
			{
				((AreaExplorePlayState)obj).ExploreType = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "ExploreType";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(AreaExplorePlayState).GetProperty("ExploreType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(EExploreType), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<EExploreType> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<EExploreType>(options, propertyInfo);
			JsonPropertyInfoValues<List<EPlayPointState>> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<List<EPlayPointState>>();
			jsonPropertyInfoValues2.IsProperty = true;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(AreaExplorePlayState);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((AreaExplorePlayState)obj).PlayPointStateList);
			jsonPropertyInfoValues2.Setter = delegate(object obj, [Nullable(2)] List<EPlayPointState> value)
			{
				((AreaExplorePlayState)obj).PlayPointStateList = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "PlayPointStateList";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(AreaExplorePlayState).GetProperty("PlayPointStateList", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<EPlayPointState>), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<List<EPlayPointState>> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<List<EPlayPointState>>(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		// Token: 0x1700A54D RID: 42317
		// (get) Token: 0x06045AF6 RID: 285430 RVA: 0x0123750C File Offset: 0x0123570C
		public JsonTypeInfo<EMapNoteId> EMapNoteId
		{
			get
			{
				JsonTypeInfo<EMapNoteId> result;
				if ((result = this._EMapNoteId) == null)
				{
					result = (this._EMapNoteId = (JsonTypeInfo<EMapNoteId>)base.Options.GetTypeInfo(typeof(EMapNoteId)));
				}
				return result;
			}
		}

		// Token: 0x06045AF7 RID: 285431 RVA: 0x01237548 File Offset: 0x01235748
		[NullableContext(1)]
		private JsonTypeInfo<EMapNoteId> Create_EMapNoteId(JsonSerializerOptions options)
		{
			JsonTypeInfo<EMapNoteId> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EMapNoteId>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EMapNoteId>(options, JsonMetadataServices.GetEnumConverter<EMapNoteId>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A54E RID: 42318
		// (get) Token: 0x06045AF8 RID: 285432 RVA: 0x01237574 File Offset: 0x01235774
		public JsonTypeInfo<EExploreType> EExploreType
		{
			get
			{
				JsonTypeInfo<EExploreType> result;
				if ((result = this._EExploreType) == null)
				{
					result = (this._EExploreType = (JsonTypeInfo<EExploreType>)base.Options.GetTypeInfo(typeof(EExploreType)));
				}
				return result;
			}
		}

		// Token: 0x06045AF9 RID: 285433 RVA: 0x012375B0 File Offset: 0x012357B0
		[NullableContext(1)]
		private JsonTypeInfo<EExploreType> Create_EExploreType(JsonSerializerOptions options)
		{
			JsonTypeInfo<EExploreType> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EExploreType>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EExploreType>(options, JsonMetadataServices.GetEnumConverter<EExploreType>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A54F RID: 42319
		// (get) Token: 0x06045AFA RID: 285434 RVA: 0x012375DC File Offset: 0x012357DC
		public JsonTypeInfo<EFunction> EFunction
		{
			get
			{
				JsonTypeInfo<EFunction> result;
				if ((result = this._EFunction) == null)
				{
					result = (this._EFunction = (JsonTypeInfo<EFunction>)base.Options.GetTypeInfo(typeof(EFunction)));
				}
				return result;
			}
		}

		// Token: 0x06045AFB RID: 285435 RVA: 0x01237618 File Offset: 0x01235818
		[NullableContext(1)]
		private JsonTypeInfo<EFunction> Create_EFunction(JsonSerializerOptions options)
		{
			JsonTypeInfo<EFunction> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EFunction>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EFunction>(options, JsonMetadataServices.GetEnumConverter<EFunction>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A550 RID: 42320
		// (get) Token: 0x06045AFC RID: 285436 RVA: 0x01237644 File Offset: 0x01235844
		public JsonTypeInfo<EMotorMusicPlayMode> EMotorMusicPlayMode
		{
			get
			{
				JsonTypeInfo<EMotorMusicPlayMode> result;
				if ((result = this._EMotorMusicPlayMode) == null)
				{
					result = (this._EMotorMusicPlayMode = (JsonTypeInfo<EMotorMusicPlayMode>)base.Options.GetTypeInfo(typeof(EMotorMusicPlayMode)));
				}
				return result;
			}
		}

		// Token: 0x06045AFD RID: 285437 RVA: 0x01237680 File Offset: 0x01235880
		[NullableContext(1)]
		private JsonTypeInfo<EMotorMusicPlayMode> Create_EMotorMusicPlayMode(JsonSerializerOptions options)
		{
			JsonTypeInfo<EMotorMusicPlayMode> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EMotorMusicPlayMode>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EMotorMusicPlayMode>(options, JsonMetadataServices.GetEnumConverter<EMotorMusicPlayMode>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A551 RID: 42321
		// (get) Token: 0x06045AFE RID: 285438 RVA: 0x012376AC File Offset: 0x012358AC
		public JsonTypeInfo<EPlayPointState> EPlayPointState
		{
			get
			{
				JsonTypeInfo<EPlayPointState> result;
				if ((result = this._EPlayPointState) == null)
				{
					result = (this._EPlayPointState = (JsonTypeInfo<EPlayPointState>)base.Options.GetTypeInfo(typeof(EPlayPointState)));
				}
				return result;
			}
		}

		// Token: 0x06045AFF RID: 285439 RVA: 0x012376E8 File Offset: 0x012358E8
		[NullableContext(1)]
		private JsonTypeInfo<EPlayPointState> Create_EPlayPointState(JsonSerializerOptions options)
		{
			JsonTypeInfo<EPlayPointState> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EPlayPointState>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EPlayPointState>(options, JsonMetadataServices.GetEnumConverter<EPlayPointState>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A552 RID: 42322
		// (get) Token: 0x06045B00 RID: 285440 RVA: 0x01237714 File Offset: 0x01235914
		public JsonTypeInfo<ERouletteType> ERouletteType
		{
			get
			{
				JsonTypeInfo<ERouletteType> result;
				if ((result = this._ERouletteType) == null)
				{
					result = (this._ERouletteType = (JsonTypeInfo<ERouletteType>)base.Options.GetTypeInfo(typeof(ERouletteType)));
				}
				return result;
			}
		}

		// Token: 0x06045B01 RID: 285441 RVA: 0x01237750 File Offset: 0x01235950
		[NullableContext(1)]
		private JsonTypeInfo<ERouletteType> Create_ERouletteType(JsonSerializerOptions options)
		{
			JsonTypeInfo<ERouletteType> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<ERouletteType>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ERouletteType>(options, JsonMetadataServices.GetEnumConverter<ERouletteType>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A553 RID: 42323
		// (get) Token: 0x06045B02 RID: 285442 RVA: 0x0123777C File Offset: 0x0123597C
		public JsonTypeInfo<ERouletteType?> NullableERouletteType
		{
			get
			{
				JsonTypeInfo<ERouletteType?> result;
				if ((result = this._NullableERouletteType) == null)
				{
					result = (this._NullableERouletteType = (JsonTypeInfo<ERouletteType?>)base.Options.GetTypeInfo(typeof(ERouletteType?)));
				}
				return result;
			}
		}

		// Token: 0x06045B03 RID: 285443 RVA: 0x012377B8 File Offset: 0x012359B8
		[NullableContext(1)]
		private JsonTypeInfo<ERouletteType?> Create_NullableERouletteType(JsonSerializerOptions options)
		{
			JsonTypeInfo<ERouletteType?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<ERouletteType?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<ERouletteType>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<ERouletteType?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A554 RID: 42324
		// (get) Token: 0x06045B04 RID: 285444 RVA: 0x012377E8 File Offset: 0x012359E8
		public JsonTypeInfo<EVisionLevelUpIdentify> EVisionLevelUpIdentify
		{
			get
			{
				JsonTypeInfo<EVisionLevelUpIdentify> result;
				if ((result = this._EVisionLevelUpIdentify) == null)
				{
					result = (this._EVisionLevelUpIdentify = (JsonTypeInfo<EVisionLevelUpIdentify>)base.Options.GetTypeInfo(typeof(EVisionLevelUpIdentify)));
				}
				return result;
			}
		}

		// Token: 0x06045B05 RID: 285445 RVA: 0x01237824 File Offset: 0x01235A24
		[NullableContext(1)]
		private JsonTypeInfo<EVisionLevelUpIdentify> Create_EVisionLevelUpIdentify(JsonSerializerOptions options)
		{
			JsonTypeInfo<EVisionLevelUpIdentify> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EVisionLevelUpIdentify>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EVisionLevelUpIdentify>(options, JsonMetadataServices.GetEnumConverter<EVisionLevelUpIdentify>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A555 RID: 42325
		// (get) Token: 0x06045B06 RID: 285446 RVA: 0x01237850 File Offset: 0x01235A50
		public JsonTypeInfo<EVisionLevelUpIdentify?> NullableEVisionLevelUpIdentify
		{
			get
			{
				JsonTypeInfo<EVisionLevelUpIdentify?> result;
				if ((result = this._NullableEVisionLevelUpIdentify) == null)
				{
					result = (this._NullableEVisionLevelUpIdentify = (JsonTypeInfo<EVisionLevelUpIdentify?>)base.Options.GetTypeInfo(typeof(EVisionLevelUpIdentify?)));
				}
				return result;
			}
		}

		// Token: 0x06045B07 RID: 285447 RVA: 0x0123788C File Offset: 0x01235A8C
		[NullableContext(1)]
		private JsonTypeInfo<EVisionLevelUpIdentify?> Create_NullableEVisionLevelUpIdentify(JsonSerializerOptions options)
		{
			JsonTypeInfo<EVisionLevelUpIdentify?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EVisionLevelUpIdentify?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<EVisionLevelUpIdentify>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EVisionLevelUpIdentify?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A556 RID: 42326
		// (get) Token: 0x06045B08 RID: 285448 RVA: 0x012378BC File Offset: 0x01235ABC
		public JsonTypeInfo<EVisionLevelUpMaterialPutInMode> EVisionLevelUpMaterialPutInMode
		{
			get
			{
				JsonTypeInfo<EVisionLevelUpMaterialPutInMode> result;
				if ((result = this._EVisionLevelUpMaterialPutInMode) == null)
				{
					result = (this._EVisionLevelUpMaterialPutInMode = (JsonTypeInfo<EVisionLevelUpMaterialPutInMode>)base.Options.GetTypeInfo(typeof(EVisionLevelUpMaterialPutInMode)));
				}
				return result;
			}
		}

		// Token: 0x06045B09 RID: 285449 RVA: 0x012378F8 File Offset: 0x01235AF8
		[NullableContext(1)]
		private JsonTypeInfo<EVisionLevelUpMaterialPutInMode> Create_EVisionLevelUpMaterialPutInMode(JsonSerializerOptions options)
		{
			JsonTypeInfo<EVisionLevelUpMaterialPutInMode> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EVisionLevelUpMaterialPutInMode>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EVisionLevelUpMaterialPutInMode>(options, JsonMetadataServices.GetEnumConverter<EVisionLevelUpMaterialPutInMode>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A557 RID: 42327
		// (get) Token: 0x06045B0A RID: 285450 RVA: 0x01237924 File Offset: 0x01235B24
		public JsonTypeInfo<EVisionLevelUpMaterialPutInMode?> NullableEVisionLevelUpMaterialPutInMode
		{
			get
			{
				JsonTypeInfo<EVisionLevelUpMaterialPutInMode?> result;
				if ((result = this._NullableEVisionLevelUpMaterialPutInMode) == null)
				{
					result = (this._NullableEVisionLevelUpMaterialPutInMode = (JsonTypeInfo<EVisionLevelUpMaterialPutInMode?>)base.Options.GetTypeInfo(typeof(EVisionLevelUpMaterialPutInMode?)));
				}
				return result;
			}
		}

		// Token: 0x06045B0B RID: 285451 RVA: 0x01237960 File Offset: 0x01235B60
		[NullableContext(1)]
		private JsonTypeInfo<EVisionLevelUpMaterialPutInMode?> Create_NullableEVisionLevelUpMaterialPutInMode(JsonSerializerOptions options)
		{
			JsonTypeInfo<EVisionLevelUpMaterialPutInMode?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EVisionLevelUpMaterialPutInMode?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<EVisionLevelUpMaterialPutInMode>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EVisionLevelUpMaterialPutInMode?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A558 RID: 42328
		// (get) Token: 0x06045B0C RID: 285452 RVA: 0x01237990 File Offset: 0x01235B90
		public JsonTypeInfo<EVisionLevelUpMaterialUseType> EVisionLevelUpMaterialUseType
		{
			get
			{
				JsonTypeInfo<EVisionLevelUpMaterialUseType> result;
				if ((result = this._EVisionLevelUpMaterialUseType) == null)
				{
					result = (this._EVisionLevelUpMaterialUseType = (JsonTypeInfo<EVisionLevelUpMaterialUseType>)base.Options.GetTypeInfo(typeof(EVisionLevelUpMaterialUseType)));
				}
				return result;
			}
		}

		// Token: 0x06045B0D RID: 285453 RVA: 0x012379CC File Offset: 0x01235BCC
		[NullableContext(1)]
		private JsonTypeInfo<EVisionLevelUpMaterialUseType> Create_EVisionLevelUpMaterialUseType(JsonSerializerOptions options)
		{
			JsonTypeInfo<EVisionLevelUpMaterialUseType> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EVisionLevelUpMaterialUseType>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EVisionLevelUpMaterialUseType>(options, JsonMetadataServices.GetEnumConverter<EVisionLevelUpMaterialUseType>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A559 RID: 42329
		// (get) Token: 0x06045B0E RID: 285454 RVA: 0x012379F8 File Offset: 0x01235BF8
		public JsonTypeInfo<EVisionLevelUpMaterialUseType?> NullableEVisionLevelUpMaterialUseType
		{
			get
			{
				JsonTypeInfo<EVisionLevelUpMaterialUseType?> result;
				if ((result = this._NullableEVisionLevelUpMaterialUseType) == null)
				{
					result = (this._NullableEVisionLevelUpMaterialUseType = (JsonTypeInfo<EVisionLevelUpMaterialUseType?>)base.Options.GetTypeInfo(typeof(EVisionLevelUpMaterialUseType?)));
				}
				return result;
			}
		}

		// Token: 0x06045B0F RID: 285455 RVA: 0x01237A34 File Offset: 0x01235C34
		[NullableContext(1)]
		private JsonTypeInfo<EVisionLevelUpMaterialUseType?> Create_NullableEVisionLevelUpMaterialUseType(JsonSerializerOptions options)
		{
			JsonTypeInfo<EVisionLevelUpMaterialUseType?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<EVisionLevelUpMaterialUseType?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<EVisionLevelUpMaterialUseType>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<EVisionLevelUpMaterialUseType?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A55A RID: 42330
		// (get) Token: 0x06045B10 RID: 285456 RVA: 0x01237A64 File Offset: 0x01235C64
		public JsonTypeInfo<FilterDefine.EFilterType> EFilterType
		{
			get
			{
				JsonTypeInfo<FilterDefine.EFilterType> result;
				if ((result = this._EFilterType) == null)
				{
					result = (this._EFilterType = (JsonTypeInfo<FilterDefine.EFilterType>)base.Options.GetTypeInfo(typeof(FilterDefine.EFilterType)));
				}
				return result;
			}
		}

		// Token: 0x06045B11 RID: 285457 RVA: 0x01237AA0 File Offset: 0x01235CA0
		[NullableContext(1)]
		private JsonTypeInfo<FilterDefine.EFilterType> Create_EFilterType(JsonSerializerOptions options)
		{
			JsonTypeInfo<FilterDefine.EFilterType> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<FilterDefine.EFilterType>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<FilterDefine.EFilterType>(options, JsonMetadataServices.GetEnumConverter<FilterDefine.EFilterType>(options));
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A55B RID: 42331
		// (get) Token: 0x06045B12 RID: 285458 RVA: 0x01237ACC File Offset: 0x01235CCC
		public JsonTypeInfo<FilterStorageData> FilterStorageData
		{
			get
			{
				JsonTypeInfo<FilterStorageData> result;
				if ((result = this._FilterStorageData) == null)
				{
					result = (this._FilterStorageData = (JsonTypeInfo<FilterStorageData>)base.Options.GetTypeInfo(typeof(FilterStorageData)));
				}
				return result;
			}
		}

		// Token: 0x06045B13 RID: 285459 RVA: 0x01237B08 File Offset: 0x01235D08
		[NullableContext(1)]
		private JsonTypeInfo<FilterStorageData> Create_FilterStorageData(JsonSerializerOptions options)
		{
			JsonTypeInfo<FilterStorageData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<FilterStorageData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<FilterStorageData> jsonObjectInfoValues = new JsonObjectInfoValues<FilterStorageData>();
				jsonObjectInfoValues.ObjectCreator = (() => new FilterStorageData());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.FilterStorageDataPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(FilterStorageData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<FilterStorageData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<FilterStorageData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B14 RID: 285460 RVA: 0x01237BD0 File Offset: 0x01235DD0
		[NullableContext(1)]
		private static JsonPropertyInfo[] FilterStorageDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = true;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(FilterStorageData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((FilterStorageData)obj).ConfigId);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((FilterStorageData)obj).ConfigId = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "ConfigId";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(FilterStorageData).GetProperty("ConfigId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<Dictionary<FilterDefine.EFilterType, List<int>>> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<Dictionary<FilterDefine.EFilterType, List<int>>>();
			jsonPropertyInfoValues2.IsProperty = true;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(FilterStorageData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((FilterStorageData)obj).SelectRuleMap);
			jsonPropertyInfoValues2.Setter = delegate(object obj, [Nullable(new byte[]
			{
				2,
				1
			})] Dictionary<FilterDefine.EFilterType, List<int>> value)
			{
				((FilterStorageData)obj).SelectRuleMap = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "SelectRuleMap";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(FilterStorageData).GetProperty("SelectRuleMap", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(Dictionary<FilterDefine.EFilterType, List<int>>), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<Dictionary<FilterDefine.EFilterType, List<int>>> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<Dictionary<FilterDefine.EFilterType, List<int>>>(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		// Token: 0x1700A55C RID: 42332
		// (get) Token: 0x06045B15 RID: 285461 RVA: 0x01237DC8 File Offset: 0x01235FC8
		public JsonTypeInfo<GamepadTypeUsage> GamepadTypeUsage
		{
			get
			{
				JsonTypeInfo<GamepadTypeUsage> result;
				if ((result = this._GamepadTypeUsage) == null)
				{
					result = (this._GamepadTypeUsage = (JsonTypeInfo<GamepadTypeUsage>)base.Options.GetTypeInfo(typeof(GamepadTypeUsage)));
				}
				return result;
			}
		}

		// Token: 0x06045B16 RID: 285462 RVA: 0x01237E04 File Offset: 0x01236004
		[NullableContext(1)]
		private JsonTypeInfo<GamepadTypeUsage> Create_GamepadTypeUsage(JsonSerializerOptions options)
		{
			JsonTypeInfo<GamepadTypeUsage> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<GamepadTypeUsage>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<GamepadTypeUsage> jsonObjectInfoValues = new JsonObjectInfoValues<GamepadTypeUsage>();
				jsonObjectInfoValues.ObjectCreator = (() => new GamepadTypeUsage());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.GamepadTypeUsagePropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(GamepadTypeUsage).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<GamepadTypeUsage> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<GamepadTypeUsage>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B17 RID: 285463 RVA: 0x01237ECC File Offset: 0x012360CC
		[NullableContext(1)]
		private static JsonPropertyInfo[] GamepadTypeUsagePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(GamepadTypeUsage);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((GamepadTypeUsage)obj).Count);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((GamepadTypeUsage)obj).Count = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "Count";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(GamepadTypeUsage).GetField("Count", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<double> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<double>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(GamepadTypeUsage);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((GamepadTypeUsage)obj).Time);
			jsonPropertyInfoValues2.Setter = delegate(object obj, double value)
			{
				((GamepadTypeUsage)obj).Time = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "Time";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(GamepadTypeUsage).GetField("Time", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<double> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<double>(options, propertyInfo2);
			return array;
		}

		// Token: 0x1700A55D RID: 42333
		// (get) Token: 0x06045B18 RID: 285464 RVA: 0x012380B4 File Offset: 0x012362B4
		public JsonTypeInfo<GameQualityData> GameQualityData
		{
			get
			{
				JsonTypeInfo<GameQualityData> result;
				if ((result = this._GameQualityData) == null)
				{
					result = (this._GameQualityData = (JsonTypeInfo<GameQualityData>)base.Options.GetTypeInfo(typeof(GameQualityData)));
				}
				return result;
			}
		}

		// Token: 0x06045B19 RID: 285465 RVA: 0x012380F0 File Offset: 0x012362F0
		[NullableContext(1)]
		private JsonTypeInfo<GameQualityData> Create_GameQualityData(JsonSerializerOptions options)
		{
			JsonTypeInfo<GameQualityData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<GameQualityData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<GameQualityData> jsonObjectInfoValues = new JsonObjectInfoValues<GameQualityData>();
				jsonObjectInfoValues.ObjectCreator = (() => new GameQualityData());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.GameQualityDataPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(GameQualityData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<GameQualityData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<GameQualityData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B1A RID: 285466 RVA: 0x012381B8 File Offset: 0x012363B8
		[NullableContext(1)]
		private static JsonPropertyInfo[] GameQualityDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[52];
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((GameQualityData)obj).KeyQualityLevel);
			jsonPropertyInfoValues.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyQualityLevel = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "KeyQualityLevel";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyQualityLevel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((GameQualityData)obj).KeyCustomFrameRate);
			jsonPropertyInfoValues2.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyCustomFrameRate = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "KeyCustomFrameRate";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyCustomFrameRate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo2);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues3 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues3.IsProperty = false;
			jsonPropertyInfoValues3.IsPublic = true;
			jsonPropertyInfoValues3.IsVirtual = false;
			jsonPropertyInfoValues3.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues3.Converter = null;
			jsonPropertyInfoValues3.Getter = ((object obj) => ((GameQualityData)obj).KeyNewShadowQuality);
			jsonPropertyInfoValues3.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNewShadowQuality = value;
			};
			jsonPropertyInfoValues3.IgnoreCondition = null;
			jsonPropertyInfoValues3.HasJsonInclude = false;
			jsonPropertyInfoValues3.IsExtensionData = false;
			jsonPropertyInfoValues3.NumberHandling = null;
			jsonPropertyInfoValues3.PropertyName = "KeyNewShadowQuality";
			jsonPropertyInfoValues3.JsonPropertyName = null;
			jsonPropertyInfoValues3.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNewShadowQuality", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo3 = jsonPropertyInfoValues3;
			array[2] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo3);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues4 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues4.IsProperty = false;
			jsonPropertyInfoValues4.IsPublic = true;
			jsonPropertyInfoValues4.IsVirtual = false;
			jsonPropertyInfoValues4.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues4.Converter = null;
			jsonPropertyInfoValues4.Getter = ((object obj) => ((GameQualityData)obj).KeyNiagaraQuality);
			jsonPropertyInfoValues4.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNiagaraQuality = value;
			};
			jsonPropertyInfoValues4.IgnoreCondition = null;
			jsonPropertyInfoValues4.HasJsonInclude = false;
			jsonPropertyInfoValues4.IsExtensionData = false;
			jsonPropertyInfoValues4.NumberHandling = null;
			jsonPropertyInfoValues4.PropertyName = "KeyNiagaraQuality";
			jsonPropertyInfoValues4.JsonPropertyName = null;
			jsonPropertyInfoValues4.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNiagaraQuality", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo4 = jsonPropertyInfoValues4;
			array[3] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo4);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues5 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues5.IsProperty = false;
			jsonPropertyInfoValues5.IsPublic = true;
			jsonPropertyInfoValues5.IsVirtual = false;
			jsonPropertyInfoValues5.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues5.Converter = null;
			jsonPropertyInfoValues5.Getter = ((object obj) => ((GameQualityData)obj).KeyImageDetail);
			jsonPropertyInfoValues5.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyImageDetail = value;
			};
			jsonPropertyInfoValues5.IgnoreCondition = null;
			jsonPropertyInfoValues5.HasJsonInclude = false;
			jsonPropertyInfoValues5.IsExtensionData = false;
			jsonPropertyInfoValues5.NumberHandling = null;
			jsonPropertyInfoValues5.PropertyName = "KeyImageDetail";
			jsonPropertyInfoValues5.JsonPropertyName = null;
			jsonPropertyInfoValues5.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyImageDetail", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo5 = jsonPropertyInfoValues5;
			array[4] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo5);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues6 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues6.IsProperty = false;
			jsonPropertyInfoValues6.IsPublic = true;
			jsonPropertyInfoValues6.IsVirtual = false;
			jsonPropertyInfoValues6.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues6.Converter = null;
			jsonPropertyInfoValues6.Getter = ((object obj) => ((GameQualityData)obj).KeyAntiAliasing);
			jsonPropertyInfoValues6.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyAntiAliasing = value;
			};
			jsonPropertyInfoValues6.IgnoreCondition = null;
			jsonPropertyInfoValues6.HasJsonInclude = false;
			jsonPropertyInfoValues6.IsExtensionData = false;
			jsonPropertyInfoValues6.NumberHandling = null;
			jsonPropertyInfoValues6.PropertyName = "KeyAntiAliasing";
			jsonPropertyInfoValues6.JsonPropertyName = null;
			jsonPropertyInfoValues6.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyAntiAliasing", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo6 = jsonPropertyInfoValues6;
			array[5] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo6);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues7 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues7.IsProperty = false;
			jsonPropertyInfoValues7.IsPublic = true;
			jsonPropertyInfoValues7.IsVirtual = false;
			jsonPropertyInfoValues7.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues7.Converter = null;
			jsonPropertyInfoValues7.Getter = ((object obj) => ((GameQualityData)obj).KeySceneAo);
			jsonPropertyInfoValues7.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeySceneAo = value;
			};
			jsonPropertyInfoValues7.IgnoreCondition = null;
			jsonPropertyInfoValues7.HasJsonInclude = false;
			jsonPropertyInfoValues7.IsExtensionData = false;
			jsonPropertyInfoValues7.NumberHandling = null;
			jsonPropertyInfoValues7.PropertyName = "KeySceneAo";
			jsonPropertyInfoValues7.JsonPropertyName = null;
			jsonPropertyInfoValues7.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeySceneAo", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo7 = jsonPropertyInfoValues7;
			array[6] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo7);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues8 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues8.IsProperty = false;
			jsonPropertyInfoValues8.IsPublic = true;
			jsonPropertyInfoValues8.IsVirtual = false;
			jsonPropertyInfoValues8.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues8.Converter = null;
			jsonPropertyInfoValues8.Getter = ((object obj) => ((GameQualityData)obj).KeyVolumeFog);
			jsonPropertyInfoValues8.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyVolumeFog = value;
			};
			jsonPropertyInfoValues8.IgnoreCondition = null;
			jsonPropertyInfoValues8.HasJsonInclude = false;
			jsonPropertyInfoValues8.IsExtensionData = false;
			jsonPropertyInfoValues8.NumberHandling = null;
			jsonPropertyInfoValues8.PropertyName = "KeyVolumeFog";
			jsonPropertyInfoValues8.JsonPropertyName = null;
			jsonPropertyInfoValues8.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyVolumeFog", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo8 = jsonPropertyInfoValues8;
			array[7] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo8);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues9 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues9.IsProperty = false;
			jsonPropertyInfoValues9.IsPublic = true;
			jsonPropertyInfoValues9.IsVirtual = false;
			jsonPropertyInfoValues9.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues9.Converter = null;
			jsonPropertyInfoValues9.Getter = ((object obj) => ((GameQualityData)obj).KeyVolumeLight);
			jsonPropertyInfoValues9.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyVolumeLight = value;
			};
			jsonPropertyInfoValues9.IgnoreCondition = null;
			jsonPropertyInfoValues9.HasJsonInclude = false;
			jsonPropertyInfoValues9.IsExtensionData = false;
			jsonPropertyInfoValues9.NumberHandling = null;
			jsonPropertyInfoValues9.PropertyName = "KeyVolumeLight";
			jsonPropertyInfoValues9.JsonPropertyName = null;
			jsonPropertyInfoValues9.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyVolumeLight", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo9 = jsonPropertyInfoValues9;
			array[8] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo9);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues10 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues10.IsProperty = false;
			jsonPropertyInfoValues10.IsPublic = true;
			jsonPropertyInfoValues10.IsVirtual = false;
			jsonPropertyInfoValues10.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues10.Converter = null;
			jsonPropertyInfoValues10.Getter = ((object obj) => ((GameQualityData)obj).KeyMotionBlur);
			jsonPropertyInfoValues10.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyMotionBlur = value;
			};
			jsonPropertyInfoValues10.IgnoreCondition = null;
			jsonPropertyInfoValues10.HasJsonInclude = false;
			jsonPropertyInfoValues10.IsExtensionData = false;
			jsonPropertyInfoValues10.NumberHandling = null;
			jsonPropertyInfoValues10.PropertyName = "KeyMotionBlur";
			jsonPropertyInfoValues10.JsonPropertyName = null;
			jsonPropertyInfoValues10.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyMotionBlur", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo10 = jsonPropertyInfoValues10;
			array[9] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo10);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues11 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues11.IsProperty = false;
			jsonPropertyInfoValues11.IsPublic = true;
			jsonPropertyInfoValues11.IsVirtual = false;
			jsonPropertyInfoValues11.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues11.Converter = null;
			jsonPropertyInfoValues11.Getter = ((object obj) => ((GameQualityData)obj).KeyStreamLevel);
			jsonPropertyInfoValues11.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyStreamLevel = value;
			};
			jsonPropertyInfoValues11.IgnoreCondition = null;
			jsonPropertyInfoValues11.HasJsonInclude = false;
			jsonPropertyInfoValues11.IsExtensionData = false;
			jsonPropertyInfoValues11.NumberHandling = null;
			jsonPropertyInfoValues11.PropertyName = "KeyStreamLevel";
			jsonPropertyInfoValues11.JsonPropertyName = null;
			jsonPropertyInfoValues11.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyStreamLevel", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo11 = jsonPropertyInfoValues11;
			array[10] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo11);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues12 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues12.IsProperty = false;
			jsonPropertyInfoValues12.IsPublic = true;
			jsonPropertyInfoValues12.IsVirtual = false;
			jsonPropertyInfoValues12.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues12.Converter = null;
			jsonPropertyInfoValues12.Getter = ((object obj) => ((GameQualityData)obj).KeyPcVsync);
			jsonPropertyInfoValues12.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyPcVsync = value;
			};
			jsonPropertyInfoValues12.IgnoreCondition = null;
			jsonPropertyInfoValues12.HasJsonInclude = false;
			jsonPropertyInfoValues12.IsExtensionData = false;
			jsonPropertyInfoValues12.NumberHandling = null;
			jsonPropertyInfoValues12.PropertyName = "KeyPcVsync";
			jsonPropertyInfoValues12.JsonPropertyName = null;
			jsonPropertyInfoValues12.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyPcVsync", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo12 = jsonPropertyInfoValues12;
			array[11] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo12);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues13 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues13.IsProperty = false;
			jsonPropertyInfoValues13.IsPublic = true;
			jsonPropertyInfoValues13.IsVirtual = false;
			jsonPropertyInfoValues13.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues13.Converter = null;
			jsonPropertyInfoValues13.Getter = ((object obj) => ((GameQualityData)obj).KeyMobileResolution);
			jsonPropertyInfoValues13.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyMobileResolution = value;
			};
			jsonPropertyInfoValues13.IgnoreCondition = null;
			jsonPropertyInfoValues13.HasJsonInclude = false;
			jsonPropertyInfoValues13.IsExtensionData = false;
			jsonPropertyInfoValues13.NumberHandling = null;
			jsonPropertyInfoValues13.PropertyName = "KeyMobileResolution";
			jsonPropertyInfoValues13.JsonPropertyName = null;
			jsonPropertyInfoValues13.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyMobileResolution", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo13 = jsonPropertyInfoValues13;
			array[12] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo13);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues14 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues14.IsProperty = false;
			jsonPropertyInfoValues14.IsPublic = true;
			jsonPropertyInfoValues14.IsVirtual = false;
			jsonPropertyInfoValues14.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues14.Converter = null;
			jsonPropertyInfoValues14.Getter = ((object obj) => ((GameQualityData)obj).KeySuperResolution);
			jsonPropertyInfoValues14.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeySuperResolution = value;
			};
			jsonPropertyInfoValues14.IgnoreCondition = null;
			jsonPropertyInfoValues14.HasJsonInclude = false;
			jsonPropertyInfoValues14.IsExtensionData = false;
			jsonPropertyInfoValues14.NumberHandling = null;
			jsonPropertyInfoValues14.PropertyName = "KeySuperResolution";
			jsonPropertyInfoValues14.JsonPropertyName = null;
			jsonPropertyInfoValues14.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeySuperResolution", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo14 = jsonPropertyInfoValues14;
			array[13] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo14);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues15 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues15.IsProperty = false;
			jsonPropertyInfoValues15.IsPublic = true;
			jsonPropertyInfoValues15.IsVirtual = false;
			jsonPropertyInfoValues15.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues15.Converter = null;
			jsonPropertyInfoValues15.Getter = ((object obj) => ((GameQualityData)obj).KeyPcResolutionWidth);
			jsonPropertyInfoValues15.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyPcResolutionWidth = value;
			};
			jsonPropertyInfoValues15.IgnoreCondition = null;
			jsonPropertyInfoValues15.HasJsonInclude = false;
			jsonPropertyInfoValues15.IsExtensionData = false;
			jsonPropertyInfoValues15.NumberHandling = null;
			jsonPropertyInfoValues15.PropertyName = "KeyPcResolutionWidth";
			jsonPropertyInfoValues15.JsonPropertyName = null;
			jsonPropertyInfoValues15.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyPcResolutionWidth", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo15 = jsonPropertyInfoValues15;
			array[14] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo15);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues16 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues16.IsProperty = false;
			jsonPropertyInfoValues16.IsPublic = true;
			jsonPropertyInfoValues16.IsVirtual = false;
			jsonPropertyInfoValues16.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues16.Converter = null;
			jsonPropertyInfoValues16.Getter = ((object obj) => ((GameQualityData)obj).KeyPcResolutionHeight);
			jsonPropertyInfoValues16.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyPcResolutionHeight = value;
			};
			jsonPropertyInfoValues16.IgnoreCondition = null;
			jsonPropertyInfoValues16.HasJsonInclude = false;
			jsonPropertyInfoValues16.IsExtensionData = false;
			jsonPropertyInfoValues16.NumberHandling = null;
			jsonPropertyInfoValues16.PropertyName = "KeyPcResolutionHeight";
			jsonPropertyInfoValues16.JsonPropertyName = null;
			jsonPropertyInfoValues16.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyPcResolutionHeight", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo16 = jsonPropertyInfoValues16;
			array[15] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo16);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues17 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues17.IsProperty = false;
			jsonPropertyInfoValues17.IsPublic = true;
			jsonPropertyInfoValues17.IsVirtual = false;
			jsonPropertyInfoValues17.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues17.Converter = null;
			jsonPropertyInfoValues17.Getter = ((object obj) => ((GameQualityData)obj).KeyBrightness);
			jsonPropertyInfoValues17.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyBrightness = value;
			};
			jsonPropertyInfoValues17.IgnoreCondition = null;
			jsonPropertyInfoValues17.HasJsonInclude = false;
			jsonPropertyInfoValues17.IsExtensionData = false;
			jsonPropertyInfoValues17.NumberHandling = null;
			jsonPropertyInfoValues17.PropertyName = "KeyBrightness";
			jsonPropertyInfoValues17.JsonPropertyName = null;
			jsonPropertyInfoValues17.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyBrightness", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo17 = jsonPropertyInfoValues17;
			array[16] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo17);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues18 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues18.IsProperty = false;
			jsonPropertyInfoValues18.IsPublic = true;
			jsonPropertyInfoValues18.IsVirtual = false;
			jsonPropertyInfoValues18.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues18.Converter = null;
			jsonPropertyInfoValues18.Getter = ((object obj) => ((GameQualityData)obj).KeyPcWindowMode);
			jsonPropertyInfoValues18.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyPcWindowMode = value;
			};
			jsonPropertyInfoValues18.IgnoreCondition = null;
			jsonPropertyInfoValues18.HasJsonInclude = false;
			jsonPropertyInfoValues18.IsExtensionData = false;
			jsonPropertyInfoValues18.NumberHandling = null;
			jsonPropertyInfoValues18.PropertyName = "KeyPcWindowMode";
			jsonPropertyInfoValues18.JsonPropertyName = null;
			jsonPropertyInfoValues18.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyPcWindowMode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo18 = jsonPropertyInfoValues18;
			array[17] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo18);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues19 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues19.IsProperty = false;
			jsonPropertyInfoValues19.IsPublic = true;
			jsonPropertyInfoValues19.IsVirtual = false;
			jsonPropertyInfoValues19.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues19.Converter = null;
			jsonPropertyInfoValues19.Getter = ((object obj) => ((GameQualityData)obj).KeyNvidiaSuperSamplingEnable);
			jsonPropertyInfoValues19.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNvidiaSuperSamplingEnable = value;
			};
			jsonPropertyInfoValues19.IgnoreCondition = null;
			jsonPropertyInfoValues19.HasJsonInclude = false;
			jsonPropertyInfoValues19.IsExtensionData = false;
			jsonPropertyInfoValues19.NumberHandling = null;
			jsonPropertyInfoValues19.PropertyName = "KeyNvidiaSuperSamplingEnable";
			jsonPropertyInfoValues19.JsonPropertyName = null;
			jsonPropertyInfoValues19.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNvidiaSuperSamplingEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo19 = jsonPropertyInfoValues19;
			array[18] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo19);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues20 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues20.IsProperty = false;
			jsonPropertyInfoValues20.IsPublic = true;
			jsonPropertyInfoValues20.IsVirtual = false;
			jsonPropertyInfoValues20.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues20.Converter = null;
			jsonPropertyInfoValues20.Getter = ((object obj) => ((GameQualityData)obj).KeyNvidiaSuperSamplingFrameGenerate);
			jsonPropertyInfoValues20.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNvidiaSuperSamplingFrameGenerate = value;
			};
			jsonPropertyInfoValues20.IgnoreCondition = null;
			jsonPropertyInfoValues20.HasJsonInclude = false;
			jsonPropertyInfoValues20.IsExtensionData = false;
			jsonPropertyInfoValues20.NumberHandling = null;
			jsonPropertyInfoValues20.PropertyName = "KeyNvidiaSuperSamplingFrameGenerate";
			jsonPropertyInfoValues20.JsonPropertyName = null;
			jsonPropertyInfoValues20.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNvidiaSuperSamplingFrameGenerate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo20 = jsonPropertyInfoValues20;
			array[19] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo20);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues21 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues21.IsProperty = false;
			jsonPropertyInfoValues21.IsPublic = true;
			jsonPropertyInfoValues21.IsVirtual = false;
			jsonPropertyInfoValues21.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues21.Converter = null;
			jsonPropertyInfoValues21.Getter = ((object obj) => ((GameQualityData)obj).KeyNvidiaSuperSamplingMode);
			jsonPropertyInfoValues21.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNvidiaSuperSamplingMode = value;
			};
			jsonPropertyInfoValues21.IgnoreCondition = null;
			jsonPropertyInfoValues21.HasJsonInclude = false;
			jsonPropertyInfoValues21.IsExtensionData = false;
			jsonPropertyInfoValues21.NumberHandling = null;
			jsonPropertyInfoValues21.PropertyName = "KeyNvidiaSuperSamplingMode";
			jsonPropertyInfoValues21.JsonPropertyName = null;
			jsonPropertyInfoValues21.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNvidiaSuperSamplingMode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo21 = jsonPropertyInfoValues21;
			array[20] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo21);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues22 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues22.IsProperty = false;
			jsonPropertyInfoValues22.IsPublic = true;
			jsonPropertyInfoValues22.IsVirtual = false;
			jsonPropertyInfoValues22.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues22.Converter = null;
			jsonPropertyInfoValues22.Getter = ((object obj) => ((GameQualityData)obj).KeyNvidiaSuperSamplingSharpness);
			jsonPropertyInfoValues22.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNvidiaSuperSamplingSharpness = value;
			};
			jsonPropertyInfoValues22.IgnoreCondition = null;
			jsonPropertyInfoValues22.HasJsonInclude = false;
			jsonPropertyInfoValues22.IsExtensionData = false;
			jsonPropertyInfoValues22.NumberHandling = null;
			jsonPropertyInfoValues22.PropertyName = "KeyNvidiaSuperSamplingSharpness";
			jsonPropertyInfoValues22.JsonPropertyName = null;
			jsonPropertyInfoValues22.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNvidiaSuperSamplingSharpness", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo22 = jsonPropertyInfoValues22;
			array[21] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo22);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues23 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues23.IsProperty = false;
			jsonPropertyInfoValues23.IsPublic = true;
			jsonPropertyInfoValues23.IsVirtual = false;
			jsonPropertyInfoValues23.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues23.Converter = null;
			jsonPropertyInfoValues23.Getter = ((object obj) => ((GameQualityData)obj).KeyNvidiaReflex);
			jsonPropertyInfoValues23.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNvidiaReflex = value;
			};
			jsonPropertyInfoValues23.IgnoreCondition = null;
			jsonPropertyInfoValues23.HasJsonInclude = false;
			jsonPropertyInfoValues23.IsExtensionData = false;
			jsonPropertyInfoValues23.NumberHandling = null;
			jsonPropertyInfoValues23.PropertyName = "KeyNvidiaReflex";
			jsonPropertyInfoValues23.JsonPropertyName = null;
			jsonPropertyInfoValues23.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNvidiaReflex", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo23 = jsonPropertyInfoValues23;
			array[22] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo23);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues24 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues24.IsProperty = false;
			jsonPropertyInfoValues24.IsPublic = true;
			jsonPropertyInfoValues24.IsVirtual = false;
			jsonPropertyInfoValues24.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues24.Converter = null;
			jsonPropertyInfoValues24.Getter = ((object obj) => ((GameQualityData)obj).KeyFsrEnable);
			jsonPropertyInfoValues24.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyFsrEnable = value;
			};
			jsonPropertyInfoValues24.IgnoreCondition = null;
			jsonPropertyInfoValues24.HasJsonInclude = false;
			jsonPropertyInfoValues24.IsExtensionData = false;
			jsonPropertyInfoValues24.NumberHandling = null;
			jsonPropertyInfoValues24.PropertyName = "KeyFsrEnable";
			jsonPropertyInfoValues24.JsonPropertyName = null;
			jsonPropertyInfoValues24.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyFsrEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo24 = jsonPropertyInfoValues24;
			array[23] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo24);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues25 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues25.IsProperty = false;
			jsonPropertyInfoValues25.IsPublic = true;
			jsonPropertyInfoValues25.IsVirtual = false;
			jsonPropertyInfoValues25.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues25.Converter = null;
			jsonPropertyInfoValues25.Getter = ((object obj) => ((GameQualityData)obj).KeyXessEnable);
			jsonPropertyInfoValues25.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyXessEnable = value;
			};
			jsonPropertyInfoValues25.IgnoreCondition = null;
			jsonPropertyInfoValues25.HasJsonInclude = false;
			jsonPropertyInfoValues25.IsExtensionData = false;
			jsonPropertyInfoValues25.NumberHandling = null;
			jsonPropertyInfoValues25.PropertyName = "KeyXessEnable";
			jsonPropertyInfoValues25.JsonPropertyName = null;
			jsonPropertyInfoValues25.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyXessEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo25 = jsonPropertyInfoValues25;
			array[24] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo25);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues26 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues26.IsProperty = false;
			jsonPropertyInfoValues26.IsPublic = true;
			jsonPropertyInfoValues26.IsVirtual = false;
			jsonPropertyInfoValues26.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues26.Converter = null;
			jsonPropertyInfoValues26.Getter = ((object obj) => ((GameQualityData)obj).KeyXessQuality);
			jsonPropertyInfoValues26.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyXessQuality = value;
			};
			jsonPropertyInfoValues26.IgnoreCondition = null;
			jsonPropertyInfoValues26.HasJsonInclude = false;
			jsonPropertyInfoValues26.IsExtensionData = false;
			jsonPropertyInfoValues26.NumberHandling = null;
			jsonPropertyInfoValues26.PropertyName = "KeyXessQuality";
			jsonPropertyInfoValues26.JsonPropertyName = null;
			jsonPropertyInfoValues26.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyXessQuality", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo26 = jsonPropertyInfoValues26;
			array[25] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo26);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues27 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues27.IsProperty = false;
			jsonPropertyInfoValues27.IsPublic = true;
			jsonPropertyInfoValues27.IsVirtual = false;
			jsonPropertyInfoValues27.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues27.Converter = null;
			jsonPropertyInfoValues27.Getter = ((object obj) => ((GameQualityData)obj).KeyMetalFxEnable);
			jsonPropertyInfoValues27.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyMetalFxEnable = value;
			};
			jsonPropertyInfoValues27.IgnoreCondition = null;
			jsonPropertyInfoValues27.HasJsonInclude = false;
			jsonPropertyInfoValues27.IsExtensionData = false;
			jsonPropertyInfoValues27.NumberHandling = null;
			jsonPropertyInfoValues27.PropertyName = "KeyMetalFxEnable";
			jsonPropertyInfoValues27.JsonPropertyName = null;
			jsonPropertyInfoValues27.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyMetalFxEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo27 = jsonPropertyInfoValues27;
			array[26] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo27);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues28 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues28.IsProperty = false;
			jsonPropertyInfoValues28.IsPublic = true;
			jsonPropertyInfoValues28.IsVirtual = false;
			jsonPropertyInfoValues28.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues28.Converter = null;
			jsonPropertyInfoValues28.Getter = ((object obj) => ((GameQualityData)obj).KeyIrxEnable);
			jsonPropertyInfoValues28.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyIrxEnable = value;
			};
			jsonPropertyInfoValues28.IgnoreCondition = null;
			jsonPropertyInfoValues28.HasJsonInclude = false;
			jsonPropertyInfoValues28.IsExtensionData = false;
			jsonPropertyInfoValues28.NumberHandling = null;
			jsonPropertyInfoValues28.PropertyName = "KeyIrxEnable";
			jsonPropertyInfoValues28.JsonPropertyName = null;
			jsonPropertyInfoValues28.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyIrxEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo28 = jsonPropertyInfoValues28;
			array[27] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo28);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues29 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues29.IsProperty = false;
			jsonPropertyInfoValues29.IsPublic = true;
			jsonPropertyInfoValues29.IsVirtual = false;
			jsonPropertyInfoValues29.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues29.Converter = null;
			jsonPropertyInfoValues29.Getter = ((object obj) => ((GameQualityData)obj).KeyBloomEnable);
			jsonPropertyInfoValues29.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyBloomEnable = value;
			};
			jsonPropertyInfoValues29.IgnoreCondition = null;
			jsonPropertyInfoValues29.HasJsonInclude = false;
			jsonPropertyInfoValues29.IsExtensionData = false;
			jsonPropertyInfoValues29.NumberHandling = null;
			jsonPropertyInfoValues29.PropertyName = "KeyBloomEnable";
			jsonPropertyInfoValues29.JsonPropertyName = null;
			jsonPropertyInfoValues29.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyBloomEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo29 = jsonPropertyInfoValues29;
			array[28] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo29);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues30 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues30.IsProperty = false;
			jsonPropertyInfoValues30.IsPublic = true;
			jsonPropertyInfoValues30.IsVirtual = false;
			jsonPropertyInfoValues30.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues30.Converter = null;
			jsonPropertyInfoValues30.Getter = ((object obj) => ((GameQualityData)obj).KeyNpcDensity);
			jsonPropertyInfoValues30.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).KeyNpcDensity = value;
			};
			jsonPropertyInfoValues30.IgnoreCondition = null;
			jsonPropertyInfoValues30.HasJsonInclude = false;
			jsonPropertyInfoValues30.IsExtensionData = false;
			jsonPropertyInfoValues30.NumberHandling = null;
			jsonPropertyInfoValues30.PropertyName = "KeyNpcDensity";
			jsonPropertyInfoValues30.JsonPropertyName = null;
			jsonPropertyInfoValues30.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("KeyNpcDensity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo30 = jsonPropertyInfoValues30;
			array[29] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo30);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues31 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues31.IsProperty = false;
			jsonPropertyInfoValues31.IsPublic = true;
			jsonPropertyInfoValues31.IsVirtual = false;
			jsonPropertyInfoValues31.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues31.Converter = null;
			jsonPropertyInfoValues31.Getter = ((object obj) => ((GameQualityData)obj).HorizontalViewSensitivity);
			jsonPropertyInfoValues31.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).HorizontalViewSensitivity = value;
			};
			jsonPropertyInfoValues31.IgnoreCondition = null;
			jsonPropertyInfoValues31.HasJsonInclude = false;
			jsonPropertyInfoValues31.IsExtensionData = false;
			jsonPropertyInfoValues31.NumberHandling = null;
			jsonPropertyInfoValues31.PropertyName = "HorizontalViewSensitivity";
			jsonPropertyInfoValues31.JsonPropertyName = null;
			jsonPropertyInfoValues31.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("HorizontalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo31 = jsonPropertyInfoValues31;
			array[30] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo31);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues32 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues32.IsProperty = false;
			jsonPropertyInfoValues32.IsPublic = true;
			jsonPropertyInfoValues32.IsVirtual = false;
			jsonPropertyInfoValues32.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues32.Converter = null;
			jsonPropertyInfoValues32.Getter = ((object obj) => ((GameQualityData)obj).VerticalViewSensitivity);
			jsonPropertyInfoValues32.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).VerticalViewSensitivity = value;
			};
			jsonPropertyInfoValues32.IgnoreCondition = null;
			jsonPropertyInfoValues32.HasJsonInclude = false;
			jsonPropertyInfoValues32.IsExtensionData = false;
			jsonPropertyInfoValues32.NumberHandling = null;
			jsonPropertyInfoValues32.PropertyName = "VerticalViewSensitivity";
			jsonPropertyInfoValues32.JsonPropertyName = null;
			jsonPropertyInfoValues32.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("VerticalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo32 = jsonPropertyInfoValues32;
			array[31] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo32);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues33 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues33.IsProperty = false;
			jsonPropertyInfoValues33.IsPublic = true;
			jsonPropertyInfoValues33.IsVirtual = false;
			jsonPropertyInfoValues33.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues33.Converter = null;
			jsonPropertyInfoValues33.Getter = ((object obj) => ((GameQualityData)obj).AimHorizontalViewSensitivity);
			jsonPropertyInfoValues33.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).AimHorizontalViewSensitivity = value;
			};
			jsonPropertyInfoValues33.IgnoreCondition = null;
			jsonPropertyInfoValues33.HasJsonInclude = false;
			jsonPropertyInfoValues33.IsExtensionData = false;
			jsonPropertyInfoValues33.NumberHandling = null;
			jsonPropertyInfoValues33.PropertyName = "AimHorizontalViewSensitivity";
			jsonPropertyInfoValues33.JsonPropertyName = null;
			jsonPropertyInfoValues33.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("AimHorizontalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo33 = jsonPropertyInfoValues33;
			array[32] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo33);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues34 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues34.IsProperty = false;
			jsonPropertyInfoValues34.IsPublic = true;
			jsonPropertyInfoValues34.IsVirtual = false;
			jsonPropertyInfoValues34.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues34.Converter = null;
			jsonPropertyInfoValues34.Getter = ((object obj) => ((GameQualityData)obj).AimVerticalViewSensitivity);
			jsonPropertyInfoValues34.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).AimVerticalViewSensitivity = value;
			};
			jsonPropertyInfoValues34.IgnoreCondition = null;
			jsonPropertyInfoValues34.HasJsonInclude = false;
			jsonPropertyInfoValues34.IsExtensionData = false;
			jsonPropertyInfoValues34.NumberHandling = null;
			jsonPropertyInfoValues34.PropertyName = "AimVerticalViewSensitivity";
			jsonPropertyInfoValues34.JsonPropertyName = null;
			jsonPropertyInfoValues34.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("AimVerticalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo34 = jsonPropertyInfoValues34;
			array[33] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo34);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues35 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues35.IsProperty = false;
			jsonPropertyInfoValues35.IsPublic = true;
			jsonPropertyInfoValues35.IsVirtual = false;
			jsonPropertyInfoValues35.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues35.Converter = null;
			jsonPropertyInfoValues35.Getter = ((object obj) => ((GameQualityData)obj).CameraShakeStrength);
			jsonPropertyInfoValues35.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).CameraShakeStrength = value;
			};
			jsonPropertyInfoValues35.IgnoreCondition = null;
			jsonPropertyInfoValues35.HasJsonInclude = false;
			jsonPropertyInfoValues35.IsExtensionData = false;
			jsonPropertyInfoValues35.NumberHandling = null;
			jsonPropertyInfoValues35.PropertyName = "CameraShakeStrength";
			jsonPropertyInfoValues35.JsonPropertyName = null;
			jsonPropertyInfoValues35.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("CameraShakeStrength", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo35 = jsonPropertyInfoValues35;
			array[34] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo35);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues36 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues36.IsProperty = false;
			jsonPropertyInfoValues36.IsPublic = true;
			jsonPropertyInfoValues36.IsVirtual = false;
			jsonPropertyInfoValues36.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues36.Converter = null;
			jsonPropertyInfoValues36.Getter = ((object obj) => ((GameQualityData)obj).MobileHorizontalViewSensitivity);
			jsonPropertyInfoValues36.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).MobileHorizontalViewSensitivity = value;
			};
			jsonPropertyInfoValues36.IgnoreCondition = null;
			jsonPropertyInfoValues36.HasJsonInclude = false;
			jsonPropertyInfoValues36.IsExtensionData = false;
			jsonPropertyInfoValues36.NumberHandling = null;
			jsonPropertyInfoValues36.PropertyName = "MobileHorizontalViewSensitivity";
			jsonPropertyInfoValues36.JsonPropertyName = null;
			jsonPropertyInfoValues36.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("MobileHorizontalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo36 = jsonPropertyInfoValues36;
			array[35] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo36);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues37 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues37.IsProperty = false;
			jsonPropertyInfoValues37.IsPublic = true;
			jsonPropertyInfoValues37.IsVirtual = false;
			jsonPropertyInfoValues37.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues37.Converter = null;
			jsonPropertyInfoValues37.Getter = ((object obj) => ((GameQualityData)obj).MobileVerticalViewSensitivity);
			jsonPropertyInfoValues37.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).MobileVerticalViewSensitivity = value;
			};
			jsonPropertyInfoValues37.IgnoreCondition = null;
			jsonPropertyInfoValues37.HasJsonInclude = false;
			jsonPropertyInfoValues37.IsExtensionData = false;
			jsonPropertyInfoValues37.NumberHandling = null;
			jsonPropertyInfoValues37.PropertyName = "MobileVerticalViewSensitivity";
			jsonPropertyInfoValues37.JsonPropertyName = null;
			jsonPropertyInfoValues37.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("MobileVerticalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo37 = jsonPropertyInfoValues37;
			array[36] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo37);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues38 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues38.IsProperty = false;
			jsonPropertyInfoValues38.IsPublic = true;
			jsonPropertyInfoValues38.IsVirtual = false;
			jsonPropertyInfoValues38.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues38.Converter = null;
			jsonPropertyInfoValues38.Getter = ((object obj) => ((GameQualityData)obj).MobileAimHorizontalViewSensitivity);
			jsonPropertyInfoValues38.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).MobileAimHorizontalViewSensitivity = value;
			};
			jsonPropertyInfoValues38.IgnoreCondition = null;
			jsonPropertyInfoValues38.HasJsonInclude = false;
			jsonPropertyInfoValues38.IsExtensionData = false;
			jsonPropertyInfoValues38.NumberHandling = null;
			jsonPropertyInfoValues38.PropertyName = "MobileAimHorizontalViewSensitivity";
			jsonPropertyInfoValues38.JsonPropertyName = null;
			jsonPropertyInfoValues38.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("MobileAimHorizontalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo38 = jsonPropertyInfoValues38;
			array[37] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo38);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues39 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues39.IsProperty = false;
			jsonPropertyInfoValues39.IsPublic = true;
			jsonPropertyInfoValues39.IsVirtual = false;
			jsonPropertyInfoValues39.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues39.Converter = null;
			jsonPropertyInfoValues39.Getter = ((object obj) => ((GameQualityData)obj).MobileAimVerticalViewSensitivity);
			jsonPropertyInfoValues39.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).MobileAimVerticalViewSensitivity = value;
			};
			jsonPropertyInfoValues39.IgnoreCondition = null;
			jsonPropertyInfoValues39.HasJsonInclude = false;
			jsonPropertyInfoValues39.IsExtensionData = false;
			jsonPropertyInfoValues39.NumberHandling = null;
			jsonPropertyInfoValues39.PropertyName = "MobileAimVerticalViewSensitivity";
			jsonPropertyInfoValues39.JsonPropertyName = null;
			jsonPropertyInfoValues39.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("MobileAimVerticalViewSensitivity", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo39 = jsonPropertyInfoValues39;
			array[38] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo39);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues40 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues40.IsProperty = false;
			jsonPropertyInfoValues40.IsPublic = true;
			jsonPropertyInfoValues40.IsVirtual = false;
			jsonPropertyInfoValues40.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues40.Converter = null;
			jsonPropertyInfoValues40.Getter = ((object obj) => ((GameQualityData)obj).CommonSpringArmLength);
			jsonPropertyInfoValues40.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).CommonSpringArmLength = value;
			};
			jsonPropertyInfoValues40.IgnoreCondition = null;
			jsonPropertyInfoValues40.HasJsonInclude = false;
			jsonPropertyInfoValues40.IsExtensionData = false;
			jsonPropertyInfoValues40.NumberHandling = null;
			jsonPropertyInfoValues40.PropertyName = "CommonSpringArmLength";
			jsonPropertyInfoValues40.JsonPropertyName = null;
			jsonPropertyInfoValues40.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("CommonSpringArmLength", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo40 = jsonPropertyInfoValues40;
			array[39] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo40);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues41 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues41.IsProperty = false;
			jsonPropertyInfoValues41.IsPublic = true;
			jsonPropertyInfoValues41.IsVirtual = false;
			jsonPropertyInfoValues41.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues41.Converter = null;
			jsonPropertyInfoValues41.Getter = ((object obj) => ((GameQualityData)obj).FightSpringArmLength);
			jsonPropertyInfoValues41.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).FightSpringArmLength = value;
			};
			jsonPropertyInfoValues41.IgnoreCondition = null;
			jsonPropertyInfoValues41.HasJsonInclude = false;
			jsonPropertyInfoValues41.IsExtensionData = false;
			jsonPropertyInfoValues41.NumberHandling = null;
			jsonPropertyInfoValues41.PropertyName = "FightSpringArmLength";
			jsonPropertyInfoValues41.JsonPropertyName = null;
			jsonPropertyInfoValues41.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("FightSpringArmLength", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo41 = jsonPropertyInfoValues41;
			array[40] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo41);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues42 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues42.IsProperty = false;
			jsonPropertyInfoValues42.IsPublic = true;
			jsonPropertyInfoValues42.IsVirtual = false;
			jsonPropertyInfoValues42.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues42.Converter = null;
			jsonPropertyInfoValues42.Getter = ((object obj) => ((GameQualityData)obj).IsResetFocusEnable);
			jsonPropertyInfoValues42.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).IsResetFocusEnable = value;
			};
			jsonPropertyInfoValues42.IgnoreCondition = null;
			jsonPropertyInfoValues42.HasJsonInclude = false;
			jsonPropertyInfoValues42.IsExtensionData = false;
			jsonPropertyInfoValues42.NumberHandling = null;
			jsonPropertyInfoValues42.PropertyName = "IsResetFocusEnable";
			jsonPropertyInfoValues42.JsonPropertyName = null;
			jsonPropertyInfoValues42.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("IsResetFocusEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo42 = jsonPropertyInfoValues42;
			array[41] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo42);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues43 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues43.IsProperty = false;
			jsonPropertyInfoValues43.IsPublic = true;
			jsonPropertyInfoValues43.IsVirtual = false;
			jsonPropertyInfoValues43.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues43.Converter = null;
			jsonPropertyInfoValues43.Getter = ((object obj) => ((GameQualityData)obj).IsSidestepCameraEnable);
			jsonPropertyInfoValues43.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).IsSidestepCameraEnable = value;
			};
			jsonPropertyInfoValues43.IgnoreCondition = null;
			jsonPropertyInfoValues43.HasJsonInclude = false;
			jsonPropertyInfoValues43.IsExtensionData = false;
			jsonPropertyInfoValues43.NumberHandling = null;
			jsonPropertyInfoValues43.PropertyName = "IsSidestepCameraEnable";
			jsonPropertyInfoValues43.JsonPropertyName = null;
			jsonPropertyInfoValues43.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("IsSidestepCameraEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo43 = jsonPropertyInfoValues43;
			array[42] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo43);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues44 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues44.IsProperty = false;
			jsonPropertyInfoValues44.IsPublic = true;
			jsonPropertyInfoValues44.IsVirtual = false;
			jsonPropertyInfoValues44.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues44.Converter = null;
			jsonPropertyInfoValues44.Getter = ((object obj) => ((GameQualityData)obj).IsSoftLockCameraEnable);
			jsonPropertyInfoValues44.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).IsSoftLockCameraEnable = value;
			};
			jsonPropertyInfoValues44.IgnoreCondition = null;
			jsonPropertyInfoValues44.HasJsonInclude = false;
			jsonPropertyInfoValues44.IsExtensionData = false;
			jsonPropertyInfoValues44.NumberHandling = null;
			jsonPropertyInfoValues44.PropertyName = "IsSoftLockCameraEnable";
			jsonPropertyInfoValues44.JsonPropertyName = null;
			jsonPropertyInfoValues44.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("IsSoftLockCameraEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo44 = jsonPropertyInfoValues44;
			array[43] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo44);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues45 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues45.IsProperty = false;
			jsonPropertyInfoValues45.IsPublic = true;
			jsonPropertyInfoValues45.IsVirtual = false;
			jsonPropertyInfoValues45.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues45.Converter = null;
			jsonPropertyInfoValues45.Getter = ((object obj) => ((GameQualityData)obj).JoystickShakeStrength);
			jsonPropertyInfoValues45.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).JoystickShakeStrength = value;
			};
			jsonPropertyInfoValues45.IgnoreCondition = null;
			jsonPropertyInfoValues45.HasJsonInclude = false;
			jsonPropertyInfoValues45.IsExtensionData = false;
			jsonPropertyInfoValues45.NumberHandling = null;
			jsonPropertyInfoValues45.PropertyName = "JoystickShakeStrength";
			jsonPropertyInfoValues45.JsonPropertyName = null;
			jsonPropertyInfoValues45.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("JoystickShakeStrength", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo45 = jsonPropertyInfoValues45;
			array[44] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo45);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues46 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues46.IsProperty = false;
			jsonPropertyInfoValues46.IsPublic = true;
			jsonPropertyInfoValues46.IsVirtual = false;
			jsonPropertyInfoValues46.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues46.Converter = null;
			jsonPropertyInfoValues46.Getter = ((object obj) => ((GameQualityData)obj).JoystickShakeType);
			jsonPropertyInfoValues46.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).JoystickShakeType = value;
			};
			jsonPropertyInfoValues46.IgnoreCondition = null;
			jsonPropertyInfoValues46.HasJsonInclude = false;
			jsonPropertyInfoValues46.IsExtensionData = false;
			jsonPropertyInfoValues46.NumberHandling = null;
			jsonPropertyInfoValues46.PropertyName = "JoystickShakeType";
			jsonPropertyInfoValues46.JsonPropertyName = null;
			jsonPropertyInfoValues46.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("JoystickShakeType", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo46 = jsonPropertyInfoValues46;
			array[45] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo46);
			JsonPropertyInfoValues<float?> jsonPropertyInfoValues47 = new JsonPropertyInfoValues<float?>();
			jsonPropertyInfoValues47.IsProperty = false;
			jsonPropertyInfoValues47.IsPublic = true;
			jsonPropertyInfoValues47.IsVirtual = false;
			jsonPropertyInfoValues47.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues47.Converter = null;
			jsonPropertyInfoValues47.Getter = ((object obj) => ((GameQualityData)obj).WalkOrRunRate);
			jsonPropertyInfoValues47.Setter = delegate(object obj, float? value)
			{
				((GameQualityData)obj).WalkOrRunRate = value;
			};
			jsonPropertyInfoValues47.IgnoreCondition = null;
			jsonPropertyInfoValues47.HasJsonInclude = false;
			jsonPropertyInfoValues47.IsExtensionData = false;
			jsonPropertyInfoValues47.NumberHandling = null;
			jsonPropertyInfoValues47.PropertyName = "WalkOrRunRate";
			jsonPropertyInfoValues47.JsonPropertyName = null;
			jsonPropertyInfoValues47.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("WalkOrRunRate", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<float?> propertyInfo47 = jsonPropertyInfoValues47;
			array[46] = JsonMetadataServices.CreatePropertyInfo<float?>(options, propertyInfo47);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues48 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues48.IsProperty = false;
			jsonPropertyInfoValues48.IsPublic = true;
			jsonPropertyInfoValues48.IsVirtual = false;
			jsonPropertyInfoValues48.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues48.Converter = null;
			jsonPropertyInfoValues48.Getter = ((object obj) => ((GameQualityData)obj).JoystickMode);
			jsonPropertyInfoValues48.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).JoystickMode = value;
			};
			jsonPropertyInfoValues48.IgnoreCondition = null;
			jsonPropertyInfoValues48.HasJsonInclude = false;
			jsonPropertyInfoValues48.IsExtensionData = false;
			jsonPropertyInfoValues48.NumberHandling = null;
			jsonPropertyInfoValues48.PropertyName = "JoystickMode";
			jsonPropertyInfoValues48.JsonPropertyName = null;
			jsonPropertyInfoValues48.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("JoystickMode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo48 = jsonPropertyInfoValues48;
			array[47] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo48);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues49 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues49.IsProperty = false;
			jsonPropertyInfoValues49.IsPublic = true;
			jsonPropertyInfoValues49.IsVirtual = false;
			jsonPropertyInfoValues49.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues49.Converter = null;
			jsonPropertyInfoValues49.Getter = ((object obj) => ((GameQualityData)obj).IsAutoSwitchSkillButtonMode);
			jsonPropertyInfoValues49.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).IsAutoSwitchSkillButtonMode = value;
			};
			jsonPropertyInfoValues49.IgnoreCondition = null;
			jsonPropertyInfoValues49.HasJsonInclude = false;
			jsonPropertyInfoValues49.IsExtensionData = false;
			jsonPropertyInfoValues49.NumberHandling = null;
			jsonPropertyInfoValues49.PropertyName = "IsAutoSwitchSkillButtonMode";
			jsonPropertyInfoValues49.JsonPropertyName = null;
			jsonPropertyInfoValues49.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("IsAutoSwitchSkillButtonMode", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo49 = jsonPropertyInfoValues49;
			array[48] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo49);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues50 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues50.IsProperty = false;
			jsonPropertyInfoValues50.IsPublic = true;
			jsonPropertyInfoValues50.IsVirtual = false;
			jsonPropertyInfoValues50.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues50.Converter = null;
			jsonPropertyInfoValues50.Getter = ((object obj) => ((GameQualityData)obj).AimAssistEnable);
			jsonPropertyInfoValues50.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).AimAssistEnable = value;
			};
			jsonPropertyInfoValues50.IgnoreCondition = null;
			jsonPropertyInfoValues50.HasJsonInclude = false;
			jsonPropertyInfoValues50.IsExtensionData = false;
			jsonPropertyInfoValues50.NumberHandling = null;
			jsonPropertyInfoValues50.PropertyName = "AimAssistEnable";
			jsonPropertyInfoValues50.JsonPropertyName = null;
			jsonPropertyInfoValues50.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("AimAssistEnable", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo50 = jsonPropertyInfoValues50;
			array[49] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo50);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues51 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues51.IsProperty = false;
			jsonPropertyInfoValues51.IsPublic = true;
			jsonPropertyInfoValues51.IsVirtual = false;
			jsonPropertyInfoValues51.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues51.Converter = null;
			jsonPropertyInfoValues51.Getter = ((object obj) => ((GameQualityData)obj).HorizontalViewRevert);
			jsonPropertyInfoValues51.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).HorizontalViewRevert = value;
			};
			jsonPropertyInfoValues51.IgnoreCondition = null;
			jsonPropertyInfoValues51.HasJsonInclude = false;
			jsonPropertyInfoValues51.IsExtensionData = false;
			jsonPropertyInfoValues51.NumberHandling = null;
			jsonPropertyInfoValues51.PropertyName = "HorizontalViewRevert";
			jsonPropertyInfoValues51.JsonPropertyName = null;
			jsonPropertyInfoValues51.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("HorizontalViewRevert", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo51 = jsonPropertyInfoValues51;
			array[50] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo51);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues52 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues52.IsProperty = false;
			jsonPropertyInfoValues52.IsPublic = true;
			jsonPropertyInfoValues52.IsVirtual = false;
			jsonPropertyInfoValues52.DeclaringType = typeof(GameQualityData);
			jsonPropertyInfoValues52.Converter = null;
			jsonPropertyInfoValues52.Getter = ((object obj) => ((GameQualityData)obj).VerticalViewRevert);
			jsonPropertyInfoValues52.Setter = delegate(object obj, int? value)
			{
				((GameQualityData)obj).VerticalViewRevert = value;
			};
			jsonPropertyInfoValues52.IgnoreCondition = null;
			jsonPropertyInfoValues52.HasJsonInclude = false;
			jsonPropertyInfoValues52.IsExtensionData = false;
			jsonPropertyInfoValues52.NumberHandling = null;
			jsonPropertyInfoValues52.PropertyName = "VerticalViewRevert";
			jsonPropertyInfoValues52.JsonPropertyName = null;
			jsonPropertyInfoValues52.AttributeProviderFactory = (() => typeof(GameQualityData).GetField("VerticalViewRevert", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int?> propertyInfo52 = jsonPropertyInfoValues52;
			array[51] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo52);
			return array;
		}

		// Token: 0x1700A55E RID: 42334
		// (get) Token: 0x06045B1B RID: 285467 RVA: 0x0123B214 File Offset: 0x01239414
		public JsonTypeInfo<IRacingBetsSettlementMainViewRecord> IRacingBetsSettlementMainViewRecord
		{
			get
			{
				JsonTypeInfo<IRacingBetsSettlementMainViewRecord> result;
				if ((result = this._IRacingBetsSettlementMainViewRecord) == null)
				{
					result = (this._IRacingBetsSettlementMainViewRecord = (JsonTypeInfo<IRacingBetsSettlementMainViewRecord>)base.Options.GetTypeInfo(typeof(IRacingBetsSettlementMainViewRecord)));
				}
				return result;
			}
		}

		// Token: 0x06045B1C RID: 285468 RVA: 0x0123B250 File Offset: 0x01239450
		[NullableContext(1)]
		private JsonTypeInfo<IRacingBetsSettlementMainViewRecord> Create_IRacingBetsSettlementMainViewRecord(JsonSerializerOptions options)
		{
			JsonTypeInfo<IRacingBetsSettlementMainViewRecord> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<IRacingBetsSettlementMainViewRecord>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<IRacingBetsSettlementMainViewRecord> objectInfo = new JsonObjectInfoValues<IRacingBetsSettlementMainViewRecord>
				{
					ObjectCreator = null,
					ObjectWithParameterizedConstructorCreator = null,
					PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.IRacingBetsSettlementMainViewRecordPropInit(options)),
					ConstructorParameterMetadataInitializer = null,
					ConstructorAttributeProviderFactory = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<IRacingBetsSettlementMainViewRecord>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B1D RID: 285469 RVA: 0x0123B2D8 File Offset: 0x012394D8
		[NullableContext(1)]
		private static JsonPropertyInfo[] IRacingBetsSettlementMainViewRecordPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = true;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = true;
			jsonPropertyInfoValues.DeclaringType = typeof(IRacingBetsSettlementMainViewRecord);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((IRacingBetsSettlementMainViewRecord)obj).SeasonId);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((IRacingBetsSettlementMainViewRecord)obj).SeasonId = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "SeasonId";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(IRacingBetsSettlementMainViewRecord).GetProperty("SeasonId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<List<int>> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<List<int>>();
			jsonPropertyInfoValues2.IsProperty = true;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = true;
			jsonPropertyInfoValues2.DeclaringType = typeof(IRacingBetsSettlementMainViewRecord);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((IRacingBetsSettlementMainViewRecord)obj).ViewedLegMatchIds);
			jsonPropertyInfoValues2.Setter = delegate(object obj, [Nullable(2)] List<int> value)
			{
				((IRacingBetsSettlementMainViewRecord)obj).ViewedLegMatchIds = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "ViewedLegMatchIds";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(IRacingBetsSettlementMainViewRecord).GetProperty("ViewedLegMatchIds", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<int>), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<List<int>> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<List<int>>(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		// Token: 0x1700A55F RID: 42335
		// (get) Token: 0x06045B1E RID: 285470 RVA: 0x0123B4D0 File Offset: 0x012396D0
		public JsonTypeInfo<LocalFriendApplication> LocalFriendApplication
		{
			get
			{
				JsonTypeInfo<LocalFriendApplication> result;
				if ((result = this._LocalFriendApplication) == null)
				{
					result = (this._LocalFriendApplication = (JsonTypeInfo<LocalFriendApplication>)base.Options.GetTypeInfo(typeof(LocalFriendApplication)));
				}
				return result;
			}
		}

		// Token: 0x06045B1F RID: 285471 RVA: 0x0123B50C File Offset: 0x0123970C
		[NullableContext(1)]
		private JsonTypeInfo<LocalFriendApplication> Create_LocalFriendApplication(JsonSerializerOptions options)
		{
			JsonTypeInfo<LocalFriendApplication> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<LocalFriendApplication>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<LocalFriendApplication> jsonObjectInfoValues = new JsonObjectInfoValues<LocalFriendApplication>();
				jsonObjectInfoValues.ObjectCreator = (() => new LocalFriendApplication());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.LocalFriendApplicationPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(LocalFriendApplication).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<LocalFriendApplication> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<LocalFriendApplication>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B20 RID: 285472 RVA: 0x0123B5D4 File Offset: 0x012397D4
		[NullableContext(1)]
		private static JsonPropertyInfo[] LocalFriendApplicationPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<bool> jsonPropertyInfoValues = new JsonPropertyInfoValues<bool>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(LocalFriendApplication);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((LocalFriendApplication)obj).Fresh);
			jsonPropertyInfoValues.Setter = delegate(object obj, bool value)
			{
				((LocalFriendApplication)obj).Fresh = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "Fresh";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(LocalFriendApplication).GetField("Fresh", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<bool> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<bool>(options, propertyInfo);
			JsonPropertyInfoValues<long> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<long>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(LocalFriendApplication);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((LocalFriendApplication)obj).CreatedTime);
			jsonPropertyInfoValues2.Setter = delegate(object obj, long value)
			{
				((LocalFriendApplication)obj).CreatedTime = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "CreatedTime";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(LocalFriendApplication).GetField("CreatedTime", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<long> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<long>(options, propertyInfo2);
			return array;
		}

		// Token: 0x1700A560 RID: 42336
		// (get) Token: 0x06045B21 RID: 285473 RVA: 0x0123B7BC File Offset: 0x012399BC
		public JsonTypeInfo<LocalPlayerIpLevelData> LocalPlayerIpLevelData
		{
			get
			{
				JsonTypeInfo<LocalPlayerIpLevelData> result;
				if ((result = this._LocalPlayerIpLevelData) == null)
				{
					result = (this._LocalPlayerIpLevelData = (JsonTypeInfo<LocalPlayerIpLevelData>)base.Options.GetTypeInfo(typeof(LocalPlayerIpLevelData)));
				}
				return result;
			}
		}

		// Token: 0x06045B22 RID: 285474 RVA: 0x0123B7F8 File Offset: 0x012399F8
		[NullableContext(1)]
		private JsonTypeInfo<LocalPlayerIpLevelData> Create_LocalPlayerIpLevelData(JsonSerializerOptions options)
		{
			JsonTypeInfo<LocalPlayerIpLevelData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<LocalPlayerIpLevelData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<LocalPlayerIpLevelData> jsonObjectInfoValues = new JsonObjectInfoValues<LocalPlayerIpLevelData>();
				jsonObjectInfoValues.ObjectCreator = (() => new LocalPlayerIpLevelData());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.LocalPlayerIpLevelDataPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(LocalPlayerIpLevelData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<LocalPlayerIpLevelData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<LocalPlayerIpLevelData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B23 RID: 285475 RVA: 0x0123B8C0 File Offset: 0x01239AC0
		[NullableContext(1)]
		private static JsonPropertyInfo[] LocalPlayerIpLevelDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> jsonPropertyInfoValues = new JsonPropertyInfoValues<string>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(LocalPlayerIpLevelData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((LocalPlayerIpLevelData)obj).Region);
			jsonPropertyInfoValues.Setter = delegate(object obj, [Nullable(2)] string value)
			{
				((LocalPlayerIpLevelData)obj).Region = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "Region";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(LocalPlayerIpLevelData).GetField("Region", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<string> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<string>(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<int> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(LocalPlayerIpLevelData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((LocalPlayerIpLevelData)obj).Level);
			jsonPropertyInfoValues2.Setter = delegate(object obj, int value)
			{
				((LocalPlayerIpLevelData)obj).Level = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "Level";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(LocalPlayerIpLevelData).GetField("Level", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo2);
			return array;
		}

		// Token: 0x1700A561 RID: 42337
		// (get) Token: 0x06045B24 RID: 285476 RVA: 0x0123BAB8 File Offset: 0x01239CB8
		public JsonTypeInfo<LocalPlayerIpLevelData[]> LocalPlayerIpLevelDataArray
		{
			get
			{
				JsonTypeInfo<LocalPlayerIpLevelData[]> result;
				if ((result = this._LocalPlayerIpLevelDataArray) == null)
				{
					result = (this._LocalPlayerIpLevelDataArray = (JsonTypeInfo<LocalPlayerIpLevelData[]>)base.Options.GetTypeInfo(typeof(LocalPlayerIpLevelData[])));
				}
				return result;
			}
		}

		// Token: 0x06045B25 RID: 285477 RVA: 0x0123BAF4 File Offset: 0x01239CF4
		[NullableContext(1)]
		private JsonTypeInfo<LocalPlayerIpLevelData[]> Create_LocalPlayerIpLevelDataArray(JsonSerializerOptions options)
		{
			JsonTypeInfo<LocalPlayerIpLevelData[]> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<LocalPlayerIpLevelData[]>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<LocalPlayerIpLevelData[]> collectionInfo = new JsonCollectionInfoValues<LocalPlayerIpLevelData[]>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo<LocalPlayerIpLevelData>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A562 RID: 42338
		// (get) Token: 0x06045B26 RID: 285478 RVA: 0x0123BB40 File Offset: 0x01239D40
		public JsonTypeInfo<MarqueeStorageData> MarqueeStorageData
		{
			get
			{
				JsonTypeInfo<MarqueeStorageData> result;
				if ((result = this._MarqueeStorageData) == null)
				{
					result = (this._MarqueeStorageData = (JsonTypeInfo<MarqueeStorageData>)base.Options.GetTypeInfo(typeof(MarqueeStorageData)));
				}
				return result;
			}
		}

		// Token: 0x06045B27 RID: 285479 RVA: 0x0123BB7C File Offset: 0x01239D7C
		[NullableContext(1)]
		private JsonTypeInfo<MarqueeStorageData> Create_MarqueeStorageData(JsonSerializerOptions options)
		{
			JsonTypeInfo<MarqueeStorageData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<MarqueeStorageData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<MarqueeStorageData> jsonObjectInfoValues = new JsonObjectInfoValues<MarqueeStorageData>();
				jsonObjectInfoValues.ObjectCreator = null;
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = ((object[] args) => new MarqueeStorageData((double)args[0]));
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.MarqueeStorageDataPropInit(options));
				Func<JsonParameterInfoValues[]> constructorParameterMetadataInitializer;
				if ((constructorParameterMetadataInitializer = LocalStorageJsonSourceGenContext.<>O.<0>__MarqueeStorageDataCtorParamInit) == null)
				{
					constructorParameterMetadataInitializer = (LocalStorageJsonSourceGenContext.<>O.<0>__MarqueeStorageDataCtorParamInit = new Func<JsonParameterInfoValues[]>(LocalStorageJsonSourceGenContext.MarqueeStorageDataCtorParamInit));
				}
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = constructorParameterMetadataInitializer;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(MarqueeStorageData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, new Type[]
				{
					typeof(double)
				}, null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<MarqueeStorageData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<MarqueeStorageData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B28 RID: 285480 RVA: 0x0123BC60 File Offset: 0x01239E60
		[NullableContext(1)]
		private static JsonPropertyInfo[] MarqueeStorageDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(MarqueeStorageData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((MarqueeStorageData)obj).ScrollingTime);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((MarqueeStorageData)obj).ScrollingTime = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "ScrollingTime";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(MarqueeStorageData).GetField("ScrollingTime", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<double> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<double>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(MarqueeStorageData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((MarqueeStorageData)obj).EndTime);
			jsonPropertyInfoValues2.Setter = delegate(object obj, double value)
			{
				((MarqueeStorageData)obj).EndTime = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "EndTime";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(MarqueeStorageData).GetField("EndTime", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<double> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<double>(options, propertyInfo2);
			return array;
		}

		// Token: 0x06045B29 RID: 285481 RVA: 0x0123BE48 File Offset: 0x0123A048
		[NullableContext(1)]
		private static JsonParameterInfoValues[] MarqueeStorageDataCtorParamInit()
		{
			return new JsonParameterInfoValues[]
			{
				new JsonParameterInfoValues
				{
					Name = "endTime",
					ParameterType = typeof(double),
					Position = 0,
					HasDefaultValue = false,
					DefaultValue = null,
					IsNullable = false
				}
			};
		}

		// Token: 0x1700A563 RID: 42339
		// (get) Token: 0x06045B2A RID: 285482 RVA: 0x0123BE9C File Offset: 0x0123A09C
		public JsonTypeInfo<RacingBetsRedDotState> RacingBetsRedDotState
		{
			get
			{
				JsonTypeInfo<RacingBetsRedDotState> result;
				if ((result = this._RacingBetsRedDotState) == null)
				{
					result = (this._RacingBetsRedDotState = (JsonTypeInfo<RacingBetsRedDotState>)base.Options.GetTypeInfo(typeof(RacingBetsRedDotState)));
				}
				return result;
			}
		}

		// Token: 0x06045B2B RID: 285483 RVA: 0x0123BED8 File Offset: 0x0123A0D8
		[NullableContext(1)]
		private JsonTypeInfo<RacingBetsRedDotState> Create_RacingBetsRedDotState(JsonSerializerOptions options)
		{
			JsonTypeInfo<RacingBetsRedDotState> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<RacingBetsRedDotState>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<RacingBetsRedDotState> jsonObjectInfoValues = new JsonObjectInfoValues<RacingBetsRedDotState>();
				jsonObjectInfoValues.ObjectCreator = (() => new RacingBetsRedDotState());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.RacingBetsRedDotStatePropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(RacingBetsRedDotState).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<RacingBetsRedDotState> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<RacingBetsRedDotState>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B2C RID: 285484 RVA: 0x0123BFA0 File Offset: 0x0123A1A0
		[NullableContext(1)]
		private static JsonPropertyInfo[] RacingBetsRedDotStatePropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<bool> jsonPropertyInfoValues = new JsonPropertyInfoValues<bool>();
			jsonPropertyInfoValues.IsProperty = true;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(RacingBetsRedDotState);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((RacingBetsRedDotState)obj).HasViewed);
			jsonPropertyInfoValues.Setter = delegate(object obj, bool value)
			{
				((RacingBetsRedDotState)obj).HasViewed = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "HasViewed";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(RacingBetsRedDotState).GetProperty("HasViewed", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<bool> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<bool>(options, propertyInfo);
			JsonPropertyInfoValues<long> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<long>();
			jsonPropertyInfoValues2.IsProperty = true;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(RacingBetsRedDotState);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((RacingBetsRedDotState)obj).LastViewedData);
			jsonPropertyInfoValues2.Setter = delegate(object obj, long value)
			{
				((RacingBetsRedDotState)obj).LastViewedData = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "LastViewedData";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(RacingBetsRedDotState).GetProperty("LastViewedData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(long), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<long> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<long>(options, propertyInfo2);
			return array;
		}

		// Token: 0x1700A564 RID: 42340
		// (get) Token: 0x06045B2D RID: 285485 RVA: 0x0123C188 File Offset: 0x0123A388
		public JsonTypeInfo<RegionAndIpSt> RegionAndIpSt
		{
			get
			{
				JsonTypeInfo<RegionAndIpSt> result;
				if ((result = this._RegionAndIpSt) == null)
				{
					result = (this._RegionAndIpSt = (JsonTypeInfo<RegionAndIpSt>)base.Options.GetTypeInfo(typeof(RegionAndIpSt)));
				}
				return result;
			}
		}

		// Token: 0x06045B2E RID: 285486 RVA: 0x0123C1C4 File Offset: 0x0123A3C4
		[NullableContext(1)]
		private JsonTypeInfo<RegionAndIpSt> Create_RegionAndIpSt(JsonSerializerOptions options)
		{
			JsonTypeInfo<RegionAndIpSt> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<RegionAndIpSt>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<RegionAndIpSt> jsonObjectInfoValues = new JsonObjectInfoValues<RegionAndIpSt>();
				jsonObjectInfoValues.ObjectCreator = (() => new RegionAndIpSt());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.RegionAndIpStPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(RegionAndIpSt).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<RegionAndIpSt> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<RegionAndIpSt>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B2F RID: 285487 RVA: 0x0123C28C File Offset: 0x0123A48C
		[NullableContext(1)]
		private static JsonPropertyInfo[] RegionAndIpStPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[2];
			JsonPropertyInfoValues<string> jsonPropertyInfoValues = new JsonPropertyInfoValues<string>();
			jsonPropertyInfoValues.IsProperty = false;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(RegionAndIpSt);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((RegionAndIpSt)obj).Region);
			jsonPropertyInfoValues.Setter = delegate(object obj, [Nullable(2)] string value)
			{
				((RegionAndIpSt)obj).Region = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "Region";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(RegionAndIpSt).GetField("Region", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<string> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<string>(options, propertyInfo);
			array[0].IsGetNullable = false;
			array[0].IsSetNullable = false;
			JsonPropertyInfoValues<string> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<string>();
			jsonPropertyInfoValues2.IsProperty = false;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(RegionAndIpSt);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((RegionAndIpSt)obj).Ip);
			jsonPropertyInfoValues2.Setter = delegate(object obj, [Nullable(2)] string value)
			{
				((RegionAndIpSt)obj).Ip = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "Ip";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(RegionAndIpSt).GetField("Ip", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic));
			JsonPropertyInfoValues<string> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<string>(options, propertyInfo2);
			array[1].IsGetNullable = false;
			array[1].IsSetNullable = false;
			return array;
		}

		// Token: 0x1700A565 RID: 42341
		// (get) Token: 0x06045B30 RID: 285488 RVA: 0x0123C498 File Offset: 0x0123A698
		public JsonTypeInfo<SortStorageData> SortStorageData
		{
			get
			{
				JsonTypeInfo<SortStorageData> result;
				if ((result = this._SortStorageData) == null)
				{
					result = (this._SortStorageData = (JsonTypeInfo<SortStorageData>)base.Options.GetTypeInfo(typeof(SortStorageData)));
				}
				return result;
			}
		}

		// Token: 0x06045B31 RID: 285489 RVA: 0x0123C4D4 File Offset: 0x0123A6D4
		[NullableContext(1)]
		private JsonTypeInfo<SortStorageData> Create_SortStorageData(JsonSerializerOptions options)
		{
			JsonTypeInfo<SortStorageData> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<SortStorageData>(options, out jsonTypeInfo))
			{
				JsonObjectInfoValues<SortStorageData> jsonObjectInfoValues = new JsonObjectInfoValues<SortStorageData>();
				jsonObjectInfoValues.ObjectCreator = (() => new SortStorageData());
				jsonObjectInfoValues.ObjectWithParameterizedConstructorCreator = null;
				jsonObjectInfoValues.PropertyMetadataInitializer = ((JsonSerializerContext _) => LocalStorageJsonSourceGenContext.SortStorageDataPropInit(options));
				jsonObjectInfoValues.ConstructorParameterMetadataInitializer = null;
				jsonObjectInfoValues.ConstructorAttributeProviderFactory = (() => typeof(SortStorageData).GetConstructor(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, Array.Empty<Type>(), null));
				jsonObjectInfoValues.SerializeHandler = null;
				JsonObjectInfoValues<SortStorageData> objectInfo = jsonObjectInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateObjectInfo<SortStorageData>(options, objectInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x06045B32 RID: 285490 RVA: 0x0123C59C File Offset: 0x0123A79C
		[NullableContext(1)]
		private static JsonPropertyInfo[] SortStorageDataPropInit(JsonSerializerOptions options)
		{
			JsonPropertyInfo[] array = new JsonPropertyInfo[4];
			JsonPropertyInfoValues<int> jsonPropertyInfoValues = new JsonPropertyInfoValues<int>();
			jsonPropertyInfoValues.IsProperty = true;
			jsonPropertyInfoValues.IsPublic = true;
			jsonPropertyInfoValues.IsVirtual = false;
			jsonPropertyInfoValues.DeclaringType = typeof(SortStorageData);
			jsonPropertyInfoValues.Converter = null;
			jsonPropertyInfoValues.Getter = ((object obj) => ((SortStorageData)obj).ConfigId);
			jsonPropertyInfoValues.Setter = delegate(object obj, int value)
			{
				((SortStorageData)obj).ConfigId = value;
			};
			jsonPropertyInfoValues.IgnoreCondition = null;
			jsonPropertyInfoValues.HasJsonInclude = false;
			jsonPropertyInfoValues.IsExtensionData = false;
			jsonPropertyInfoValues.NumberHandling = null;
			jsonPropertyInfoValues.PropertyName = "ConfigId";
			jsonPropertyInfoValues.JsonPropertyName = null;
			jsonPropertyInfoValues.AttributeProviderFactory = (() => typeof(SortStorageData).GetProperty("ConfigId", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<int> propertyInfo = jsonPropertyInfoValues;
			array[0] = JsonMetadataServices.CreatePropertyInfo<int>(options, propertyInfo);
			JsonPropertyInfoValues<int?> jsonPropertyInfoValues2 = new JsonPropertyInfoValues<int?>();
			jsonPropertyInfoValues2.IsProperty = true;
			jsonPropertyInfoValues2.IsPublic = true;
			jsonPropertyInfoValues2.IsVirtual = false;
			jsonPropertyInfoValues2.DeclaringType = typeof(SortStorageData);
			jsonPropertyInfoValues2.Converter = null;
			jsonPropertyInfoValues2.Getter = ((object obj) => ((SortStorageData)obj).SelectBaseSort);
			jsonPropertyInfoValues2.Setter = delegate(object obj, int? value)
			{
				((SortStorageData)obj).SelectBaseSort = value;
			};
			jsonPropertyInfoValues2.IgnoreCondition = null;
			jsonPropertyInfoValues2.HasJsonInclude = false;
			jsonPropertyInfoValues2.IsExtensionData = false;
			jsonPropertyInfoValues2.NumberHandling = null;
			jsonPropertyInfoValues2.PropertyName = "SelectBaseSort";
			jsonPropertyInfoValues2.JsonPropertyName = null;
			jsonPropertyInfoValues2.AttributeProviderFactory = (() => typeof(SortStorageData).GetProperty("SelectBaseSort", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(int?), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<int?> propertyInfo2 = jsonPropertyInfoValues2;
			array[1] = JsonMetadataServices.CreatePropertyInfo<int?>(options, propertyInfo2);
			JsonPropertyInfoValues<List<int>> jsonPropertyInfoValues3 = new JsonPropertyInfoValues<List<int>>();
			jsonPropertyInfoValues3.IsProperty = true;
			jsonPropertyInfoValues3.IsPublic = true;
			jsonPropertyInfoValues3.IsVirtual = false;
			jsonPropertyInfoValues3.DeclaringType = typeof(SortStorageData);
			jsonPropertyInfoValues3.Converter = null;
			jsonPropertyInfoValues3.Getter = ((object obj) => ((SortStorageData)obj).SelectAttributeSort);
			jsonPropertyInfoValues3.Setter = delegate(object obj, [Nullable(2)] List<int> value)
			{
				((SortStorageData)obj).SelectAttributeSort = value;
			};
			jsonPropertyInfoValues3.IgnoreCondition = null;
			jsonPropertyInfoValues3.HasJsonInclude = false;
			jsonPropertyInfoValues3.IsExtensionData = false;
			jsonPropertyInfoValues3.NumberHandling = null;
			jsonPropertyInfoValues3.PropertyName = "SelectAttributeSort";
			jsonPropertyInfoValues3.JsonPropertyName = null;
			jsonPropertyInfoValues3.AttributeProviderFactory = (() => typeof(SortStorageData).GetProperty("SelectAttributeSort", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(List<int>), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<List<int>> propertyInfo3 = jsonPropertyInfoValues3;
			array[2] = JsonMetadataServices.CreatePropertyInfo<List<int>>(options, propertyInfo3);
			JsonPropertyInfoValues<bool> jsonPropertyInfoValues4 = new JsonPropertyInfoValues<bool>();
			jsonPropertyInfoValues4.IsProperty = true;
			jsonPropertyInfoValues4.IsPublic = true;
			jsonPropertyInfoValues4.IsVirtual = false;
			jsonPropertyInfoValues4.DeclaringType = typeof(SortStorageData);
			jsonPropertyInfoValues4.Converter = null;
			jsonPropertyInfoValues4.Getter = ((object obj) => ((SortStorageData)obj).IsAscending);
			jsonPropertyInfoValues4.Setter = delegate(object obj, bool value)
			{
				((SortStorageData)obj).IsAscending = value;
			};
			jsonPropertyInfoValues4.IgnoreCondition = null;
			jsonPropertyInfoValues4.HasJsonInclude = false;
			jsonPropertyInfoValues4.IsExtensionData = false;
			jsonPropertyInfoValues4.NumberHandling = null;
			jsonPropertyInfoValues4.PropertyName = "IsAscending";
			jsonPropertyInfoValues4.JsonPropertyName = null;
			jsonPropertyInfoValues4.AttributeProviderFactory = (() => typeof(SortStorageData).GetProperty("IsAscending", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, typeof(bool), Array.Empty<Type>(), null));
			JsonPropertyInfoValues<bool> propertyInfo4 = jsonPropertyInfoValues4;
			array[3] = JsonMetadataServices.CreatePropertyInfo<bool>(options, propertyInfo4);
			return array;
		}

		// Token: 0x1700A566 RID: 42342
		// (get) Token: 0x06045B33 RID: 285491 RVA: 0x0123C95C File Offset: 0x0123AB5C
		public JsonTypeInfo<Dictionary<EFunction, int>> DictionaryEFunctionInt32
		{
			get
			{
				JsonTypeInfo<Dictionary<EFunction, int>> result;
				if ((result = this._DictionaryEFunctionInt32) == null)
				{
					result = (this._DictionaryEFunctionInt32 = (JsonTypeInfo<Dictionary<EFunction, int>>)base.Options.GetTypeInfo(typeof(Dictionary<EFunction, int>)));
				}
				return result;
			}
		}

		// Token: 0x06045B34 RID: 285492 RVA: 0x0123C998 File Offset: 0x0123AB98
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<EFunction, int>> Create_DictionaryEFunctionInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<EFunction, int>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<EFunction, int>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<EFunction, int>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<EFunction, int>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<EFunction, int>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<EFunction, int>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<EFunction, int>, EFunction, int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A567 RID: 42343
		// (get) Token: 0x06045B35 RID: 285493 RVA: 0x0123CA00 File Offset: 0x0123AC00
		public JsonTypeInfo<Dictionary<FilterDefine.EFilterType, List<int>>> DictionaryEFilterTypeListInt32
		{
			get
			{
				JsonTypeInfo<Dictionary<FilterDefine.EFilterType, List<int>>> result;
				if ((result = this._DictionaryEFilterTypeListInt32) == null)
				{
					result = (this._DictionaryEFilterTypeListInt32 = (JsonTypeInfo<Dictionary<FilterDefine.EFilterType, List<int>>>)base.Options.GetTypeInfo(typeof(Dictionary<FilterDefine.EFilterType, List<int>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B36 RID: 285494 RVA: 0x0123CA3C File Offset: 0x0123AC3C
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<FilterDefine.EFilterType, List<int>>> Create_DictionaryEFilterTypeListInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<FilterDefine.EFilterType, List<int>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<FilterDefine.EFilterType, List<int>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<FilterDefine.EFilterType, List<int>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<FilterDefine.EFilterType, List<int>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<FilterDefine.EFilterType, List<int>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<FilterDefine.EFilterType, List<int>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<FilterDefine.EFilterType, List<int>>, FilterDefine.EFilterType, List<int>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A568 RID: 42344
		// (get) Token: 0x06045B37 RID: 285495 RVA: 0x0123CAA4 File Offset: 0x0123ACA4
		public JsonTypeInfo<Dictionary<int, bool>> DictionaryInt32Boolean
		{
			get
			{
				JsonTypeInfo<Dictionary<int, bool>> result;
				if ((result = this._DictionaryInt32Boolean) == null)
				{
					result = (this._DictionaryInt32Boolean = (JsonTypeInfo<Dictionary<int, bool>>)base.Options.GetTypeInfo(typeof(Dictionary<int, bool>)));
				}
				return result;
			}
		}

		// Token: 0x06045B38 RID: 285496 RVA: 0x0123CAE0 File Offset: 0x0123ACE0
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, bool>> Create_DictionaryInt32Boolean(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, bool>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, bool>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, bool>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, bool>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, bool>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, bool>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, bool>, int, bool>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A569 RID: 42345
		// (get) Token: 0x06045B39 RID: 285497 RVA: 0x0123CB48 File Offset: 0x0123AD48
		public JsonTypeInfo<Dictionary<int, double>> DictionaryInt32Double
		{
			get
			{
				JsonTypeInfo<Dictionary<int, double>> result;
				if ((result = this._DictionaryInt32Double) == null)
				{
					result = (this._DictionaryInt32Double = (JsonTypeInfo<Dictionary<int, double>>)base.Options.GetTypeInfo(typeof(Dictionary<int, double>)));
				}
				return result;
			}
		}

		// Token: 0x06045B3A RID: 285498 RVA: 0x0123CB84 File Offset: 0x0123AD84
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, double>> Create_DictionaryInt32Double(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, double>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, double>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, double>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, double>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, double>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, double>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, double>, int, double>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A56A RID: 42346
		// (get) Token: 0x06045B3B RID: 285499 RVA: 0x0123CBEC File Offset: 0x0123ADEC
		public JsonTypeInfo<Dictionary<int, float[]>> DictionaryInt32SingleArray
		{
			get
			{
				JsonTypeInfo<Dictionary<int, float[]>> result;
				if ((result = this._DictionaryInt32SingleArray) == null)
				{
					result = (this._DictionaryInt32SingleArray = (JsonTypeInfo<Dictionary<int, float[]>>)base.Options.GetTypeInfo(typeof(Dictionary<int, float[]>)));
				}
				return result;
			}
		}

		// Token: 0x06045B3C RID: 285500 RVA: 0x0123CC28 File Offset: 0x0123AE28
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, float[]>> Create_DictionaryInt32SingleArray(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, float[]>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, float[]>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, float[]>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, float[]>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, float[]>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, float[]>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, float[]>, int, float[]>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A56B RID: 42347
		// (get) Token: 0x06045B3D RID: 285501 RVA: 0x0123CC90 File Offset: 0x0123AE90
		public JsonTypeInfo<Dictionary<int, float>> DictionaryInt32Single
		{
			get
			{
				JsonTypeInfo<Dictionary<int, float>> result;
				if ((result = this._DictionaryInt32Single) == null)
				{
					result = (this._DictionaryInt32Single = (JsonTypeInfo<Dictionary<int, float>>)base.Options.GetTypeInfo(typeof(Dictionary<int, float>)));
				}
				return result;
			}
		}

		// Token: 0x06045B3E RID: 285502 RVA: 0x0123CCCC File Offset: 0x0123AECC
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, float>> Create_DictionaryInt32Single(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, float>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, float>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, float>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, float>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, float>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, float>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, float>, int, float>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A56C RID: 42348
		// (get) Token: 0x06045B3F RID: 285503 RVA: 0x0123CD34 File Offset: 0x0123AF34
		public JsonTypeInfo<Dictionary<int, AbyssDangoOwnerData>> DictionaryInt32AbyssDangoOwnerData
		{
			get
			{
				JsonTypeInfo<Dictionary<int, AbyssDangoOwnerData>> result;
				if ((result = this._DictionaryInt32AbyssDangoOwnerData) == null)
				{
					result = (this._DictionaryInt32AbyssDangoOwnerData = (JsonTypeInfo<Dictionary<int, AbyssDangoOwnerData>>)base.Options.GetTypeInfo(typeof(Dictionary<int, AbyssDangoOwnerData>)));
				}
				return result;
			}
		}

		// Token: 0x06045B40 RID: 285504 RVA: 0x0123CD70 File Offset: 0x0123AF70
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, AbyssDangoOwnerData>> Create_DictionaryInt32AbyssDangoOwnerData(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, AbyssDangoOwnerData>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, AbyssDangoOwnerData>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, AbyssDangoOwnerData>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, AbyssDangoOwnerData>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, AbyssDangoOwnerData>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, AbyssDangoOwnerData>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, AbyssDangoOwnerData>, int, AbyssDangoOwnerData>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A56D RID: 42349
		// (get) Token: 0x06045B41 RID: 285505 RVA: 0x0123CDD8 File Offset: 0x0123AFD8
		public JsonTypeInfo<Dictionary<int, AreaExplorePlayState>> DictionaryInt32AreaExplorePlayState
		{
			get
			{
				JsonTypeInfo<Dictionary<int, AreaExplorePlayState>> result;
				if ((result = this._DictionaryInt32AreaExplorePlayState) == null)
				{
					result = (this._DictionaryInt32AreaExplorePlayState = (JsonTypeInfo<Dictionary<int, AreaExplorePlayState>>)base.Options.GetTypeInfo(typeof(Dictionary<int, AreaExplorePlayState>)));
				}
				return result;
			}
		}

		// Token: 0x06045B42 RID: 285506 RVA: 0x0123CE14 File Offset: 0x0123B014
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, AreaExplorePlayState>> Create_DictionaryInt32AreaExplorePlayState(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, AreaExplorePlayState>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, AreaExplorePlayState>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, AreaExplorePlayState>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, AreaExplorePlayState>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, AreaExplorePlayState>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, AreaExplorePlayState>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, AreaExplorePlayState>, int, AreaExplorePlayState>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A56E RID: 42350
		// (get) Token: 0x06045B43 RID: 285507 RVA: 0x0123CE7C File Offset: 0x0123B07C
		public JsonTypeInfo<Dictionary<int, LocalFriendApplication>> DictionaryInt32LocalFriendApplication
		{
			get
			{
				JsonTypeInfo<Dictionary<int, LocalFriendApplication>> result;
				if ((result = this._DictionaryInt32LocalFriendApplication) == null)
				{
					result = (this._DictionaryInt32LocalFriendApplication = (JsonTypeInfo<Dictionary<int, LocalFriendApplication>>)base.Options.GetTypeInfo(typeof(Dictionary<int, LocalFriendApplication>)));
				}
				return result;
			}
		}

		// Token: 0x06045B44 RID: 285508 RVA: 0x0123CEB8 File Offset: 0x0123B0B8
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, LocalFriendApplication>> Create_DictionaryInt32LocalFriendApplication(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, LocalFriendApplication>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, LocalFriendApplication>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, LocalFriendApplication>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, LocalFriendApplication>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, LocalFriendApplication>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, LocalFriendApplication>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, LocalFriendApplication>, int, LocalFriendApplication>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A56F RID: 42351
		// (get) Token: 0x06045B45 RID: 285509 RVA: 0x0123CF20 File Offset: 0x0123B120
		public JsonTypeInfo<Dictionary<int, Dictionary<int, double>>> DictionaryInt32DictionaryInt32Double
		{
			get
			{
				JsonTypeInfo<Dictionary<int, Dictionary<int, double>>> result;
				if ((result = this._DictionaryInt32DictionaryInt32Double) == null)
				{
					result = (this._DictionaryInt32DictionaryInt32Double = (JsonTypeInfo<Dictionary<int, Dictionary<int, double>>>)base.Options.GetTypeInfo(typeof(Dictionary<int, Dictionary<int, double>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B46 RID: 285510 RVA: 0x0123CF5C File Offset: 0x0123B15C
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, double>>> Create_DictionaryInt32DictionaryInt32Double(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, Dictionary<int, double>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, Dictionary<int, double>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, double>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, Dictionary<int, double>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, Dictionary<int, double>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, double>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, Dictionary<int, double>>, int, Dictionary<int, double>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A570 RID: 42352
		// (get) Token: 0x06045B47 RID: 285511 RVA: 0x0123CFC4 File Offset: 0x0123B1C4
		public JsonTypeInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> DictionaryInt32DictionaryInt32AbyssDangoOwnerData
		{
			get
			{
				JsonTypeInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> result;
				if ((result = this._DictionaryInt32DictionaryInt32AbyssDangoOwnerData) == null)
				{
					result = (this._DictionaryInt32DictionaryInt32AbyssDangoOwnerData = (JsonTypeInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>>)base.Options.GetTypeInfo(typeof(Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B48 RID: 285512 RVA: 0x0123D000 File Offset: 0x0123B200
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> Create_DictionaryInt32DictionaryInt32AbyssDangoOwnerData(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>, int, Dictionary<int, AbyssDangoOwnerData>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A571 RID: 42353
		// (get) Token: 0x06045B49 RID: 285513 RVA: 0x0123D068 File Offset: 0x0123B268
		public JsonTypeInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> DictionaryInt32DictionaryInt32AreaExplorePlayState
		{
			get
			{
				JsonTypeInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> result;
				if ((result = this._DictionaryInt32DictionaryInt32AreaExplorePlayState) == null)
				{
					result = (this._DictionaryInt32DictionaryInt32AreaExplorePlayState = (JsonTypeInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>)base.Options.GetTypeInfo(typeof(Dictionary<int, Dictionary<int, AreaExplorePlayState>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B4A RID: 285514 RVA: 0x0123D0A4 File Offset: 0x0123B2A4
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> Create_DictionaryInt32DictionaryInt32AreaExplorePlayState(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, Dictionary<int, AreaExplorePlayState>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, Dictionary<int, AreaExplorePlayState>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>, int, Dictionary<int, AreaExplorePlayState>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A572 RID: 42354
		// (get) Token: 0x06045B4B RID: 285515 RVA: 0x0123D10C File Offset: 0x0123B30C
		public JsonTypeInfo<Dictionary<int, Dictionary<int, HashSet<int>>>> DictionaryInt32DictionaryInt32HashSetInt32
		{
			get
			{
				JsonTypeInfo<Dictionary<int, Dictionary<int, HashSet<int>>>> result;
				if ((result = this._DictionaryInt32DictionaryInt32HashSetInt32) == null)
				{
					result = (this._DictionaryInt32DictionaryInt32HashSetInt32 = (JsonTypeInfo<Dictionary<int, Dictionary<int, HashSet<int>>>>)base.Options.GetTypeInfo(typeof(Dictionary<int, Dictionary<int, HashSet<int>>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B4C RID: 285516 RVA: 0x0123D148 File Offset: 0x0123B348
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, HashSet<int>>>> Create_DictionaryInt32DictionaryInt32HashSetInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, Dictionary<int, HashSet<int>>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, Dictionary<int, HashSet<int>>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, HashSet<int>>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, Dictionary<int, HashSet<int>>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, Dictionary<int, HashSet<int>>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, Dictionary<int, HashSet<int>>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, Dictionary<int, HashSet<int>>>, int, Dictionary<int, HashSet<int>>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A573 RID: 42355
		// (get) Token: 0x06045B4D RID: 285517 RVA: 0x0123D1B0 File Offset: 0x0123B3B0
		public JsonTypeInfo<Dictionary<int, HashSet<int>>> DictionaryInt32HashSetInt32
		{
			get
			{
				JsonTypeInfo<Dictionary<int, HashSet<int>>> result;
				if ((result = this._DictionaryInt32HashSetInt32) == null)
				{
					result = (this._DictionaryInt32HashSetInt32 = (JsonTypeInfo<Dictionary<int, HashSet<int>>>)base.Options.GetTypeInfo(typeof(Dictionary<int, HashSet<int>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B4E RID: 285518 RVA: 0x0123D1EC File Offset: 0x0123B3EC
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, HashSet<int>>> Create_DictionaryInt32HashSetInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, HashSet<int>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, HashSet<int>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, HashSet<int>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, HashSet<int>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, HashSet<int>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, HashSet<int>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, HashSet<int>>, int, HashSet<int>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A574 RID: 42356
		// (get) Token: 0x06045B4F RID: 285519 RVA: 0x0123D254 File Offset: 0x0123B454
		public JsonTypeInfo<Dictionary<int, List<int>>> DictionaryInt32ListInt32
		{
			get
			{
				JsonTypeInfo<Dictionary<int, List<int>>> result;
				if ((result = this._DictionaryInt32ListInt32) == null)
				{
					result = (this._DictionaryInt32ListInt32 = (JsonTypeInfo<Dictionary<int, List<int>>>)base.Options.GetTypeInfo(typeof(Dictionary<int, List<int>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B50 RID: 285520 RVA: 0x0123D290 File Offset: 0x0123B490
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, List<int>>> Create_DictionaryInt32ListInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, List<int>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, List<int>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, List<int>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, List<int>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, List<int>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, List<int>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, List<int>>, int, List<int>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A575 RID: 42357
		// (get) Token: 0x06045B51 RID: 285521 RVA: 0x0123D2F8 File Offset: 0x0123B4F8
		public JsonTypeInfo<Dictionary<int, int[]>> DictionaryInt32Int32Array
		{
			get
			{
				JsonTypeInfo<Dictionary<int, int[]>> result;
				if ((result = this._DictionaryInt32Int32Array) == null)
				{
					result = (this._DictionaryInt32Int32Array = (JsonTypeInfo<Dictionary<int, int[]>>)base.Options.GetTypeInfo(typeof(Dictionary<int, int[]>)));
				}
				return result;
			}
		}

		// Token: 0x06045B52 RID: 285522 RVA: 0x0123D334 File Offset: 0x0123B534
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, int[]>> Create_DictionaryInt32Int32Array(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, int[]>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, int[]>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, int[]>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, int[]>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, int[]>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, int[]>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, int[]>, int, int[]>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A576 RID: 42358
		// (get) Token: 0x06045B53 RID: 285523 RVA: 0x0123D39C File Offset: 0x0123B59C
		public JsonTypeInfo<Dictionary<int, int>> DictionaryInt32Int32
		{
			get
			{
				JsonTypeInfo<Dictionary<int, int>> result;
				if ((result = this._DictionaryInt32Int32) == null)
				{
					result = (this._DictionaryInt32Int32 = (JsonTypeInfo<Dictionary<int, int>>)base.Options.GetTypeInfo(typeof(Dictionary<int, int>)));
				}
				return result;
			}
		}

		// Token: 0x06045B54 RID: 285524 RVA: 0x0123D3D8 File Offset: 0x0123B5D8
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, int>> Create_DictionaryInt32Int32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, int>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, int>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, int>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, int>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, int>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, int>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, int>, int, int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A577 RID: 42359
		// (get) Token: 0x06045B55 RID: 285525 RVA: 0x0123D440 File Offset: 0x0123B640
		public JsonTypeInfo<Dictionary<int, long>> DictionaryInt32Int64
		{
			get
			{
				JsonTypeInfo<Dictionary<int, long>> result;
				if ((result = this._DictionaryInt32Int64) == null)
				{
					result = (this._DictionaryInt32Int64 = (JsonTypeInfo<Dictionary<int, long>>)base.Options.GetTypeInfo(typeof(Dictionary<int, long>)));
				}
				return result;
			}
		}

		// Token: 0x06045B56 RID: 285526 RVA: 0x0123D47C File Offset: 0x0123B67C
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, long>> Create_DictionaryInt32Int64(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, long>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, long>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, long>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, long>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, long>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, long>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, long>, int, long>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A578 RID: 42360
		// (get) Token: 0x06045B57 RID: 285527 RVA: 0x0123D4E4 File Offset: 0x0123B6E4
		public JsonTypeInfo<Dictionary<int, string>> DictionaryInt32String
		{
			get
			{
				JsonTypeInfo<Dictionary<int, string>> result;
				if ((result = this._DictionaryInt32String) == null)
				{
					result = (this._DictionaryInt32String = (JsonTypeInfo<Dictionary<int, string>>)base.Options.GetTypeInfo(typeof(Dictionary<int, string>)));
				}
				return result;
			}
		}

		// Token: 0x06045B58 RID: 285528 RVA: 0x0123D520 File Offset: 0x0123B720
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<int, string>> Create_DictionaryInt32String(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<int, string>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<int, string>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<int, string>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<int, string>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<int, string>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<int, string>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<int, string>, int, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A579 RID: 42361
		// (get) Token: 0x06045B59 RID: 285529 RVA: 0x0123D588 File Offset: 0x0123B788
		public JsonTypeInfo<Dictionary<string, bool>> DictionaryStringBoolean
		{
			get
			{
				JsonTypeInfo<Dictionary<string, bool>> result;
				if ((result = this._DictionaryStringBoolean) == null)
				{
					result = (this._DictionaryStringBoolean = (JsonTypeInfo<Dictionary<string, bool>>)base.Options.GetTypeInfo(typeof(Dictionary<string, bool>)));
				}
				return result;
			}
		}

		// Token: 0x06045B5A RID: 285530 RVA: 0x0123D5C4 File Offset: 0x0123B7C4
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, bool>> Create_DictionaryStringBoolean(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, bool>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, bool>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, bool>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, bool>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, bool>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, bool>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, bool>, string, bool>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A57A RID: 42362
		// (get) Token: 0x06045B5B RID: 285531 RVA: 0x0123D62C File Offset: 0x0123B82C
		public JsonTypeInfo<Dictionary<string, FilterStorageData>> DictionaryStringFilterStorageData
		{
			get
			{
				JsonTypeInfo<Dictionary<string, FilterStorageData>> result;
				if ((result = this._DictionaryStringFilterStorageData) == null)
				{
					result = (this._DictionaryStringFilterStorageData = (JsonTypeInfo<Dictionary<string, FilterStorageData>>)base.Options.GetTypeInfo(typeof(Dictionary<string, FilterStorageData>)));
				}
				return result;
			}
		}

		// Token: 0x06045B5C RID: 285532 RVA: 0x0123D668 File Offset: 0x0123B868
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, FilterStorageData>> Create_DictionaryStringFilterStorageData(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, FilterStorageData>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, FilterStorageData>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, FilterStorageData>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, FilterStorageData>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, FilterStorageData>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, FilterStorageData>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, FilterStorageData>, string, FilterStorageData>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A57B RID: 42363
		// (get) Token: 0x06045B5D RID: 285533 RVA: 0x0123D6D0 File Offset: 0x0123B8D0
		public JsonTypeInfo<Dictionary<string, GamepadTypeUsage>> DictionaryStringGamepadTypeUsage
		{
			get
			{
				JsonTypeInfo<Dictionary<string, GamepadTypeUsage>> result;
				if ((result = this._DictionaryStringGamepadTypeUsage) == null)
				{
					result = (this._DictionaryStringGamepadTypeUsage = (JsonTypeInfo<Dictionary<string, GamepadTypeUsage>>)base.Options.GetTypeInfo(typeof(Dictionary<string, GamepadTypeUsage>)));
				}
				return result;
			}
		}

		// Token: 0x06045B5E RID: 285534 RVA: 0x0123D70C File Offset: 0x0123B90C
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, GamepadTypeUsage>> Create_DictionaryStringGamepadTypeUsage(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, GamepadTypeUsage>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, GamepadTypeUsage>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, GamepadTypeUsage>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, GamepadTypeUsage>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, GamepadTypeUsage>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, GamepadTypeUsage>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, GamepadTypeUsage>, string, GamepadTypeUsage>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A57C RID: 42364
		// (get) Token: 0x06045B5F RID: 285535 RVA: 0x0123D774 File Offset: 0x0123B974
		public JsonTypeInfo<Dictionary<string, LocalPlayerIpLevelData[]>> DictionaryStringLocalPlayerIpLevelDataArray
		{
			get
			{
				JsonTypeInfo<Dictionary<string, LocalPlayerIpLevelData[]>> result;
				if ((result = this._DictionaryStringLocalPlayerIpLevelDataArray) == null)
				{
					result = (this._DictionaryStringLocalPlayerIpLevelDataArray = (JsonTypeInfo<Dictionary<string, LocalPlayerIpLevelData[]>>)base.Options.GetTypeInfo(typeof(Dictionary<string, LocalPlayerIpLevelData[]>)));
				}
				return result;
			}
		}

		// Token: 0x06045B60 RID: 285536 RVA: 0x0123D7B0 File Offset: 0x0123B9B0
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, LocalPlayerIpLevelData[]>> Create_DictionaryStringLocalPlayerIpLevelDataArray(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, LocalPlayerIpLevelData[]>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, LocalPlayerIpLevelData[]>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, LocalPlayerIpLevelData[]>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, LocalPlayerIpLevelData[]>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, LocalPlayerIpLevelData[]>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, LocalPlayerIpLevelData[]>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, LocalPlayerIpLevelData[]>, string, LocalPlayerIpLevelData[]>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A57D RID: 42365
		// (get) Token: 0x06045B61 RID: 285537 RVA: 0x0123D818 File Offset: 0x0123BA18
		public JsonTypeInfo<Dictionary<string, MarqueeStorageData>> DictionaryStringMarqueeStorageData
		{
			get
			{
				JsonTypeInfo<Dictionary<string, MarqueeStorageData>> result;
				if ((result = this._DictionaryStringMarqueeStorageData) == null)
				{
					result = (this._DictionaryStringMarqueeStorageData = (JsonTypeInfo<Dictionary<string, MarqueeStorageData>>)base.Options.GetTypeInfo(typeof(Dictionary<string, MarqueeStorageData>)));
				}
				return result;
			}
		}

		// Token: 0x06045B62 RID: 285538 RVA: 0x0123D854 File Offset: 0x0123BA54
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, MarqueeStorageData>> Create_DictionaryStringMarqueeStorageData(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, MarqueeStorageData>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, MarqueeStorageData>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, MarqueeStorageData>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, MarqueeStorageData>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, MarqueeStorageData>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, MarqueeStorageData>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, MarqueeStorageData>, string, MarqueeStorageData>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A57E RID: 42366
		// (get) Token: 0x06045B63 RID: 285539 RVA: 0x0123D8BC File Offset: 0x0123BABC
		public JsonTypeInfo<Dictionary<string, RegionAndIpSt>> DictionaryStringRegionAndIpSt
		{
			get
			{
				JsonTypeInfo<Dictionary<string, RegionAndIpSt>> result;
				if ((result = this._DictionaryStringRegionAndIpSt) == null)
				{
					result = (this._DictionaryStringRegionAndIpSt = (JsonTypeInfo<Dictionary<string, RegionAndIpSt>>)base.Options.GetTypeInfo(typeof(Dictionary<string, RegionAndIpSt>)));
				}
				return result;
			}
		}

		// Token: 0x06045B64 RID: 285540 RVA: 0x0123D8F8 File Offset: 0x0123BAF8
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, RegionAndIpSt>> Create_DictionaryStringRegionAndIpSt(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, RegionAndIpSt>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, RegionAndIpSt>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, RegionAndIpSt>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, RegionAndIpSt>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, RegionAndIpSt>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, RegionAndIpSt>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, RegionAndIpSt>, string, RegionAndIpSt>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A57F RID: 42367
		// (get) Token: 0x06045B65 RID: 285541 RVA: 0x0123D960 File Offset: 0x0123BB60
		public JsonTypeInfo<Dictionary<string, SortStorageData>> DictionaryStringSortStorageData
		{
			get
			{
				JsonTypeInfo<Dictionary<string, SortStorageData>> result;
				if ((result = this._DictionaryStringSortStorageData) == null)
				{
					result = (this._DictionaryStringSortStorageData = (JsonTypeInfo<Dictionary<string, SortStorageData>>)base.Options.GetTypeInfo(typeof(Dictionary<string, SortStorageData>)));
				}
				return result;
			}
		}

		// Token: 0x06045B66 RID: 285542 RVA: 0x0123D99C File Offset: 0x0123BB9C
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, SortStorageData>> Create_DictionaryStringSortStorageData(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, SortStorageData>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, SortStorageData>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, SortStorageData>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, SortStorageData>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, SortStorageData>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, SortStorageData>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, SortStorageData>, string, SortStorageData>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A580 RID: 42368
		// (get) Token: 0x06045B67 RID: 285543 RVA: 0x0123DA04 File Offset: 0x0123BC04
		public JsonTypeInfo<Dictionary<string, IList<IList<string>>>> DictionaryStringIListIListString
		{
			get
			{
				JsonTypeInfo<Dictionary<string, IList<IList<string>>>> result;
				if ((result = this._DictionaryStringIListIListString) == null)
				{
					result = (this._DictionaryStringIListIListString = (JsonTypeInfo<Dictionary<string, IList<IList<string>>>>)base.Options.GetTypeInfo(typeof(Dictionary<string, IList<IList<string>>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B68 RID: 285544 RVA: 0x0123DA40 File Offset: 0x0123BC40
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, IList<IList<string>>>> Create_DictionaryStringIListIListString(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, IList<IList<string>>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, IList<IList<string>>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, IList<IList<string>>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, IList<IList<string>>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, IList<IList<string>>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, IList<IList<string>>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, IList<IList<string>>>, string, IList<IList<string>>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A581 RID: 42369
		// (get) Token: 0x06045B69 RID: 285545 RVA: 0x0123DAA8 File Offset: 0x0123BCA8
		public JsonTypeInfo<Dictionary<string, List<ActivityCacheData>>> DictionaryStringListActivityCacheData
		{
			get
			{
				JsonTypeInfo<Dictionary<string, List<ActivityCacheData>>> result;
				if ((result = this._DictionaryStringListActivityCacheData) == null)
				{
					result = (this._DictionaryStringListActivityCacheData = (JsonTypeInfo<Dictionary<string, List<ActivityCacheData>>>)base.Options.GetTypeInfo(typeof(Dictionary<string, List<ActivityCacheData>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B6A RID: 285546 RVA: 0x0123DAE4 File Offset: 0x0123BCE4
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, List<ActivityCacheData>>> Create_DictionaryStringListActivityCacheData(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, List<ActivityCacheData>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, List<ActivityCacheData>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, List<ActivityCacheData>>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, List<ActivityCacheData>>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, List<ActivityCacheData>>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, List<ActivityCacheData>>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, List<ActivityCacheData>>, string, List<ActivityCacheData>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A582 RID: 42370
		// (get) Token: 0x06045B6B RID: 285547 RVA: 0x0123DB4C File Offset: 0x0123BD4C
		public JsonTypeInfo<Dictionary<string, int>> DictionaryStringInt32
		{
			get
			{
				JsonTypeInfo<Dictionary<string, int>> result;
				if ((result = this._DictionaryStringInt32) == null)
				{
					result = (this._DictionaryStringInt32 = (JsonTypeInfo<Dictionary<string, int>>)base.Options.GetTypeInfo(typeof(Dictionary<string, int>)));
				}
				return result;
			}
		}

		// Token: 0x06045B6C RID: 285548 RVA: 0x0123DB88 File Offset: 0x0123BD88
		[NullableContext(1)]
		private JsonTypeInfo<Dictionary<string, int>> Create_DictionaryStringInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<Dictionary<string, int>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<Dictionary<string, int>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<Dictionary<string, int>> jsonCollectionInfoValues = new JsonCollectionInfoValues<Dictionary<string, int>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new Dictionary<string, int>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<Dictionary<string, int>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateDictionaryInfo<Dictionary<string, int>, string, int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A583 RID: 42371
		// (get) Token: 0x06045B6D RID: 285549 RVA: 0x0123DBF0 File Offset: 0x0123BDF0
		public JsonTypeInfo<HashSet<EMapNoteId>> HashSetEMapNoteId
		{
			get
			{
				JsonTypeInfo<HashSet<EMapNoteId>> result;
				if ((result = this._HashSetEMapNoteId) == null)
				{
					result = (this._HashSetEMapNoteId = (JsonTypeInfo<HashSet<EMapNoteId>>)base.Options.GetTypeInfo(typeof(HashSet<EMapNoteId>)));
				}
				return result;
			}
		}

		// Token: 0x06045B6E RID: 285550 RVA: 0x0123DC2C File Offset: 0x0123BE2C
		[NullableContext(1)]
		private JsonTypeInfo<HashSet<EMapNoteId>> Create_HashSetEMapNoteId(JsonSerializerOptions options)
		{
			JsonTypeInfo<HashSet<EMapNoteId>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<HashSet<EMapNoteId>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<HashSet<EMapNoteId>> jsonCollectionInfoValues = new JsonCollectionInfoValues<HashSet<EMapNoteId>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new HashSet<EMapNoteId>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<HashSet<EMapNoteId>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateISetInfo<HashSet<EMapNoteId>, EMapNoteId>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A584 RID: 42372
		// (get) Token: 0x06045B6F RID: 285551 RVA: 0x0123DC94 File Offset: 0x0123BE94
		public JsonTypeInfo<HashSet<int>> HashSetInt32
		{
			get
			{
				JsonTypeInfo<HashSet<int>> result;
				if ((result = this._HashSetInt32) == null)
				{
					result = (this._HashSetInt32 = (JsonTypeInfo<HashSet<int>>)base.Options.GetTypeInfo(typeof(HashSet<int>)));
				}
				return result;
			}
		}

		// Token: 0x06045B70 RID: 285552 RVA: 0x0123DCD0 File Offset: 0x0123BED0
		[NullableContext(1)]
		private JsonTypeInfo<HashSet<int>> Create_HashSetInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<HashSet<int>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<HashSet<int>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<HashSet<int>> jsonCollectionInfoValues = new JsonCollectionInfoValues<HashSet<int>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new HashSet<int>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<HashSet<int>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateISetInfo<HashSet<int>, int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A585 RID: 42373
		// (get) Token: 0x06045B71 RID: 285553 RVA: 0x0123DD38 File Offset: 0x0123BF38
		public JsonTypeInfo<IList<IList<string>>> IListIListString
		{
			get
			{
				JsonTypeInfo<IList<IList<string>>> result;
				if ((result = this._IListIListString) == null)
				{
					result = (this._IListIListString = (JsonTypeInfo<IList<IList<string>>>)base.Options.GetTypeInfo(typeof(IList<IList<string>>)));
				}
				return result;
			}
		}

		// Token: 0x06045B72 RID: 285554 RVA: 0x0123DD74 File Offset: 0x0123BF74
		[NullableContext(1)]
		private JsonTypeInfo<IList<IList<string>>> Create_IListIListString(JsonSerializerOptions options)
		{
			JsonTypeInfo<IList<IList<string>>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<IList<IList<string>>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<IList<string>>> collectionInfo = new JsonCollectionInfoValues<IList<IList<string>>>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<IList<string>>, IList<string>>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A586 RID: 42374
		// (get) Token: 0x06045B73 RID: 285555 RVA: 0x0123DDC0 File Offset: 0x0123BFC0
		public JsonTypeInfo<IList<string>> IListString
		{
			get
			{
				JsonTypeInfo<IList<string>> result;
				if ((result = this._IListString) == null)
				{
					result = (this._IListString = (JsonTypeInfo<IList<string>>)base.Options.GetTypeInfo(typeof(IList<string>)));
				}
				return result;
			}
		}

		// Token: 0x06045B74 RID: 285556 RVA: 0x0123DDFC File Offset: 0x0123BFFC
		[NullableContext(1)]
		private JsonTypeInfo<IList<string>> Create_IListString(JsonSerializerOptions options)
		{
			JsonTypeInfo<IList<string>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<IList<string>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<IList<string>> collectionInfo = new JsonCollectionInfoValues<IList<string>>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateIListInfo<IList<string>, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A587 RID: 42375
		// (get) Token: 0x06045B75 RID: 285557 RVA: 0x0123DE48 File Offset: 0x0123C048
		public JsonTypeInfo<List<ActivityCacheData>> ListActivityCacheData
		{
			get
			{
				JsonTypeInfo<List<ActivityCacheData>> result;
				if ((result = this._ListActivityCacheData) == null)
				{
					result = (this._ListActivityCacheData = (JsonTypeInfo<List<ActivityCacheData>>)base.Options.GetTypeInfo(typeof(List<ActivityCacheData>)));
				}
				return result;
			}
		}

		// Token: 0x06045B76 RID: 285558 RVA: 0x0123DE84 File Offset: 0x0123C084
		[NullableContext(1)]
		private JsonTypeInfo<List<ActivityCacheData>> Create_ListActivityCacheData(JsonSerializerOptions options)
		{
			JsonTypeInfo<List<ActivityCacheData>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<List<ActivityCacheData>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<ActivityCacheData>> jsonCollectionInfoValues = new JsonCollectionInfoValues<List<ActivityCacheData>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new List<ActivityCacheData>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<List<ActivityCacheData>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<ActivityCacheData>, ActivityCacheData>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A588 RID: 42376
		// (get) Token: 0x06045B77 RID: 285559 RVA: 0x0123DEEC File Offset: 0x0123C0EC
		public JsonTypeInfo<List<EPlayPointState>> ListEPlayPointState
		{
			get
			{
				JsonTypeInfo<List<EPlayPointState>> result;
				if ((result = this._ListEPlayPointState) == null)
				{
					result = (this._ListEPlayPointState = (JsonTypeInfo<List<EPlayPointState>>)base.Options.GetTypeInfo(typeof(List<EPlayPointState>)));
				}
				return result;
			}
		}

		// Token: 0x06045B78 RID: 285560 RVA: 0x0123DF28 File Offset: 0x0123C128
		[NullableContext(1)]
		private JsonTypeInfo<List<EPlayPointState>> Create_ListEPlayPointState(JsonSerializerOptions options)
		{
			JsonTypeInfo<List<EPlayPointState>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<List<EPlayPointState>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<EPlayPointState>> jsonCollectionInfoValues = new JsonCollectionInfoValues<List<EPlayPointState>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new List<EPlayPointState>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<List<EPlayPointState>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<EPlayPointState>, EPlayPointState>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A589 RID: 42377
		// (get) Token: 0x06045B79 RID: 285561 RVA: 0x0123DF90 File Offset: 0x0123C190
		public JsonTypeInfo<List<int>> ListInt32
		{
			get
			{
				JsonTypeInfo<List<int>> result;
				if ((result = this._ListInt32) == null)
				{
					result = (this._ListInt32 = (JsonTypeInfo<List<int>>)base.Options.GetTypeInfo(typeof(List<int>)));
				}
				return result;
			}
		}

		// Token: 0x06045B7A RID: 285562 RVA: 0x0123DFCC File Offset: 0x0123C1CC
		[NullableContext(1)]
		private JsonTypeInfo<List<int>> Create_ListInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<List<int>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<List<int>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<int>> jsonCollectionInfoValues = new JsonCollectionInfoValues<List<int>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new List<int>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<List<int>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<int>, int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A58A RID: 42378
		// (get) Token: 0x06045B7B RID: 285563 RVA: 0x0123E034 File Offset: 0x0123C234
		public JsonTypeInfo<List<string>> ListString
		{
			get
			{
				JsonTypeInfo<List<string>> result;
				if ((result = this._ListString) == null)
				{
					result = (this._ListString = (JsonTypeInfo<List<string>>)base.Options.GetTypeInfo(typeof(List<string>)));
				}
				return result;
			}
		}

		// Token: 0x06045B7C RID: 285564 RVA: 0x0123E070 File Offset: 0x0123C270
		[NullableContext(1)]
		private JsonTypeInfo<List<string>> Create_ListString(JsonSerializerOptions options)
		{
			JsonTypeInfo<List<string>> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<List<string>>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<List<string>> jsonCollectionInfoValues = new JsonCollectionInfoValues<List<string>>();
				jsonCollectionInfoValues.ObjectCreator = (() => new List<string>());
				jsonCollectionInfoValues.SerializeHandler = null;
				JsonCollectionInfoValues<List<string>> collectionInfo = jsonCollectionInfoValues;
				jsonTypeInfo = JsonMetadataServices.CreateListInfo<List<string>, string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A58B RID: 42379
		// (get) Token: 0x06045B7D RID: 285565 RVA: 0x0123E0D8 File Offset: 0x0123C2D8
		public JsonTypeInfo<int> Int32
		{
			get
			{
				JsonTypeInfo<int> result;
				if ((result = this._Int32) == null)
				{
					result = (this._Int32 = (JsonTypeInfo<int>)base.Options.GetTypeInfo(typeof(int)));
				}
				return result;
			}
		}

		// Token: 0x06045B7E RID: 285566 RVA: 0x0123E114 File Offset: 0x0123C314
		[NullableContext(1)]
		private JsonTypeInfo<int> Create_Int32(JsonSerializerOptions options)
		{
			JsonTypeInfo<int> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<int>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int>(options, JsonMetadataServices.Int32Converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A58C RID: 42380
		// (get) Token: 0x06045B7F RID: 285567 RVA: 0x0123E140 File Offset: 0x0123C340
		public JsonTypeInfo<int?> NullableInt32
		{
			get
			{
				JsonTypeInfo<int?> result;
				if ((result = this._NullableInt32) == null)
				{
					result = (this._NullableInt32 = (JsonTypeInfo<int?>)base.Options.GetTypeInfo(typeof(int?)));
				}
				return result;
			}
		}

		// Token: 0x06045B80 RID: 285568 RVA: 0x0123E17C File Offset: 0x0123C37C
		[NullableContext(1)]
		private JsonTypeInfo<int?> Create_NullableInt32(JsonSerializerOptions options)
		{
			JsonTypeInfo<int?> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<int?>(options, out jsonTypeInfo))
			{
				JsonConverter nullableConverter = JsonMetadataServices.GetNullableConverter<int>(options);
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<int?>(options, nullableConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A58D RID: 42381
		// (get) Token: 0x06045B81 RID: 285569 RVA: 0x0123E1AC File Offset: 0x0123C3AC
		public JsonTypeInfo<int[]> Int32Array
		{
			get
			{
				JsonTypeInfo<int[]> result;
				if ((result = this._Int32Array) == null)
				{
					result = (this._Int32Array = (JsonTypeInfo<int[]>)base.Options.GetTypeInfo(typeof(int[])));
				}
				return result;
			}
		}

		// Token: 0x06045B82 RID: 285570 RVA: 0x0123E1E8 File Offset: 0x0123C3E8
		[NullableContext(1)]
		private JsonTypeInfo<int[]> Create_Int32Array(JsonSerializerOptions options)
		{
			JsonTypeInfo<int[]> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<int[]>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<int[]> collectionInfo = new JsonCollectionInfoValues<int[]>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo<int>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A58E RID: 42382
		// (get) Token: 0x06045B83 RID: 285571 RVA: 0x0123E234 File Offset: 0x0123C434
		public JsonTypeInfo<long> Int64
		{
			get
			{
				JsonTypeInfo<long> result;
				if ((result = this._Int64) == null)
				{
					result = (this._Int64 = (JsonTypeInfo<long>)base.Options.GetTypeInfo(typeof(long)));
				}
				return result;
			}
		}

		// Token: 0x06045B84 RID: 285572 RVA: 0x0123E270 File Offset: 0x0123C470
		[NullableContext(1)]
		private JsonTypeInfo<long> Create_Int64(JsonSerializerOptions options)
		{
			JsonTypeInfo<long> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<long>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<long>(options, JsonMetadataServices.Int64Converter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A58F RID: 42383
		// (get) Token: 0x06045B85 RID: 285573 RVA: 0x0123E29C File Offset: 0x0123C49C
		public JsonTypeInfo<object> Object
		{
			get
			{
				JsonTypeInfo<object> result;
				if ((result = this._Object) == null)
				{
					result = (this._Object = (JsonTypeInfo<object>)base.Options.GetTypeInfo(typeof(object)));
				}
				return result;
			}
		}

		// Token: 0x06045B86 RID: 285574 RVA: 0x0123E2D8 File Offset: 0x0123C4D8
		[NullableContext(1)]
		private JsonTypeInfo<object> Create_Object(JsonSerializerOptions options)
		{
			JsonTypeInfo<object> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<object>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<object>(options, JsonMetadataServices.ObjectConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A590 RID: 42384
		// (get) Token: 0x06045B87 RID: 285575 RVA: 0x0123E304 File Offset: 0x0123C504
		public JsonTypeInfo<string> String
		{
			get
			{
				JsonTypeInfo<string> result;
				if ((result = this._String) == null)
				{
					result = (this._String = (JsonTypeInfo<string>)base.Options.GetTypeInfo(typeof(string)));
				}
				return result;
			}
		}

		// Token: 0x06045B88 RID: 285576 RVA: 0x0123E340 File Offset: 0x0123C540
		[NullableContext(1)]
		private JsonTypeInfo<string> Create_String(JsonSerializerOptions options)
		{
			JsonTypeInfo<string> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<string>(options, out jsonTypeInfo))
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<string>(options, JsonMetadataServices.StringConverter);
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A591 RID: 42385
		// (get) Token: 0x06045B89 RID: 285577 RVA: 0x0123E36C File Offset: 0x0123C56C
		public JsonTypeInfo<string[]> StringArray
		{
			get
			{
				JsonTypeInfo<string[]> result;
				if ((result = this._StringArray) == null)
				{
					result = (this._StringArray = (JsonTypeInfo<string[]>)base.Options.GetTypeInfo(typeof(string[])));
				}
				return result;
			}
		}

		// Token: 0x06045B8A RID: 285578 RVA: 0x0123E3A8 File Offset: 0x0123C5A8
		[NullableContext(1)]
		private JsonTypeInfo<string[]> Create_StringArray(JsonSerializerOptions options)
		{
			JsonTypeInfo<string[]> jsonTypeInfo;
			if (!LocalStorageJsonSourceGenContext.TryGetTypeInfoForRuntimeCustomConverter<string[]>(options, out jsonTypeInfo))
			{
				JsonCollectionInfoValues<string[]> collectionInfo = new JsonCollectionInfoValues<string[]>
				{
					ObjectCreator = null,
					SerializeHandler = null
				};
				jsonTypeInfo = JsonMetadataServices.CreateArrayInfo<string>(options, collectionInfo);
				jsonTypeInfo.NumberHandling = null;
			}
			jsonTypeInfo.OriginatingResolver = this;
			return jsonTypeInfo;
		}

		// Token: 0x1700A592 RID: 42386
		// (get) Token: 0x06045B8B RID: 285579 RVA: 0x0123E3F2 File Offset: 0x0123C5F2
		[Nullable(1)]
		public static LocalStorageJsonSourceGenContext Default { [NullableContext(1)] get; } = new LocalStorageJsonSourceGenContext(new JsonSerializerOptions(LocalStorageJsonSourceGenContext.s_defaultOptions));

		// Token: 0x1700A593 RID: 42387
		// (get) Token: 0x06045B8C RID: 285580 RVA: 0x0123E3F9 File Offset: 0x0123C5F9
		[Nullable(2)]
		protected override JsonSerializerOptions GeneratedSerializerOptions { [NullableContext(2)] get; } = LocalStorageJsonSourceGenContext.s_defaultOptions;

		// Token: 0x06045B8D RID: 285581 RVA: 0x0123E401 File Offset: 0x0123C601
		public LocalStorageJsonSourceGenContext() : base(null)
		{
		}

		// Token: 0x06045B8E RID: 285582 RVA: 0x0123E415 File Offset: 0x0123C615
		[NullableContext(1)]
		public LocalStorageJsonSourceGenContext(JsonSerializerOptions options) : base(options)
		{
		}

		// Token: 0x06045B8F RID: 285583 RVA: 0x0123E42C File Offset: 0x0123C62C
		[NullableContext(1)]
		private static bool TryGetTypeInfoForRuntimeCustomConverter<[Nullable(2)] TJsonMetadataType>(JsonSerializerOptions options, out JsonTypeInfo<TJsonMetadataType> jsonTypeInfo)
		{
			JsonConverter runtimeConverterForType = LocalStorageJsonSourceGenContext.GetRuntimeConverterForType(typeof(TJsonMetadataType), options);
			if (runtimeConverterForType != null)
			{
				jsonTypeInfo = JsonMetadataServices.CreateValueInfo<TJsonMetadataType>(options, runtimeConverterForType);
				return true;
			}
			jsonTypeInfo = null;
			return false;
		}

		// Token: 0x06045B90 RID: 285584 RVA: 0x0123E45C File Offset: 0x0123C65C
		[NullableContext(1)]
		[return: Nullable(2)]
		private static JsonConverter GetRuntimeConverterForType(Type type, JsonSerializerOptions options)
		{
			for (int i = 0; i < options.Converters.Count; i++)
			{
				JsonConverter jsonConverter = options.Converters[i];
				if (jsonConverter != null && jsonConverter.CanConvert(type))
				{
					return LocalStorageJsonSourceGenContext.ExpandConverter(type, jsonConverter, options, false);
				}
			}
			return null;
		}

		// Token: 0x06045B91 RID: 285585 RVA: 0x0123E4A4 File Offset: 0x0123C6A4
		[NullableContext(1)]
		private static JsonConverter ExpandConverter(Type type, JsonConverter converter, JsonSerializerOptions options, bool validateCanConvert = true)
		{
			if (validateCanConvert && !converter.CanConvert(type))
			{
				throw new InvalidOperationException(string.Format("The converter '{0}' is not compatible with the type '{1}'.", converter.GetType(), type));
			}
			JsonConverterFactory jsonConverterFactory = converter as JsonConverterFactory;
			if (jsonConverterFactory != null)
			{
				converter = jsonConverterFactory.CreateConverter(type, options);
				if (converter == null || converter is JsonConverterFactory)
				{
					throw new InvalidOperationException(string.Format("The converter '{0}' cannot return null or a JsonConverterFactory instance.", jsonConverterFactory.GetType()));
				}
			}
			return converter;
		}

		// Token: 0x06045B92 RID: 285586 RVA: 0x0123E50C File Offset: 0x0123C70C
		[NullableContext(1)]
		[return: Nullable(2)]
		public override JsonTypeInfo GetTypeInfo(Type type)
		{
			JsonTypeInfo result;
			base.Options.TryGetTypeInfo(type, out result);
			return result;
		}

		// Token: 0x06045B93 RID: 285587 RVA: 0x0123E52C File Offset: 0x0123C72C
		[NullableContext(1)]
		[return: Nullable(2)]
		JsonTypeInfo IJsonTypeInfoResolver.GetTypeInfo(Type type, JsonSerializerOptions options)
		{
			if (type == typeof(bool))
			{
				return this.Create_Boolean(options);
			}
			if (type == typeof(bool?))
			{
				return this.Create_NullableBoolean(options);
			}
			if (type == typeof(double))
			{
				return this.Create_Double(options);
			}
			if (type == typeof(double?))
			{
				return this.Create_NullableDouble(options);
			}
			if (type == typeof(double[]))
			{
				return this.Create_DoubleArray(options);
			}
			if (type == typeof(float))
			{
				return this.Create_Single(options);
			}
			if (type == typeof(float?))
			{
				return this.Create_NullableSingle(options);
			}
			if (type == typeof(float[]))
			{
				return this.Create_SingleArray(options);
			}
			if (type == typeof(AbyssDangoOwnerData))
			{
				return this.Create_AbyssDangoOwnerData(options);
			}
			if (type == typeof(ActivityCacheData))
			{
				return this.Create_ActivityCacheData(options);
			}
			if (type == typeof(AreaExplorePlayState))
			{
				return this.Create_AreaExplorePlayState(options);
			}
			if (type == typeof(EMapNoteId))
			{
				return this.Create_EMapNoteId(options);
			}
			if (type == typeof(EExploreType))
			{
				return this.Create_EExploreType(options);
			}
			if (type == typeof(EFunction))
			{
				return this.Create_EFunction(options);
			}
			if (type == typeof(EMotorMusicPlayMode))
			{
				return this.Create_EMotorMusicPlayMode(options);
			}
			if (type == typeof(EPlayPointState))
			{
				return this.Create_EPlayPointState(options);
			}
			if (type == typeof(ERouletteType))
			{
				return this.Create_ERouletteType(options);
			}
			if (type == typeof(ERouletteType?))
			{
				return this.Create_NullableERouletteType(options);
			}
			if (type == typeof(EVisionLevelUpIdentify))
			{
				return this.Create_EVisionLevelUpIdentify(options);
			}
			if (type == typeof(EVisionLevelUpIdentify?))
			{
				return this.Create_NullableEVisionLevelUpIdentify(options);
			}
			if (type == typeof(EVisionLevelUpMaterialPutInMode))
			{
				return this.Create_EVisionLevelUpMaterialPutInMode(options);
			}
			if (type == typeof(EVisionLevelUpMaterialPutInMode?))
			{
				return this.Create_NullableEVisionLevelUpMaterialPutInMode(options);
			}
			if (type == typeof(EVisionLevelUpMaterialUseType))
			{
				return this.Create_EVisionLevelUpMaterialUseType(options);
			}
			if (type == typeof(EVisionLevelUpMaterialUseType?))
			{
				return this.Create_NullableEVisionLevelUpMaterialUseType(options);
			}
			if (type == typeof(FilterDefine.EFilterType))
			{
				return this.Create_EFilterType(options);
			}
			if (type == typeof(FilterStorageData))
			{
				return this.Create_FilterStorageData(options);
			}
			if (type == typeof(GamepadTypeUsage))
			{
				return this.Create_GamepadTypeUsage(options);
			}
			if (type == typeof(GameQualityData))
			{
				return this.Create_GameQualityData(options);
			}
			if (type == typeof(IRacingBetsSettlementMainViewRecord))
			{
				return this.Create_IRacingBetsSettlementMainViewRecord(options);
			}
			if (type == typeof(LocalFriendApplication))
			{
				return this.Create_LocalFriendApplication(options);
			}
			if (type == typeof(LocalPlayerIpLevelData))
			{
				return this.Create_LocalPlayerIpLevelData(options);
			}
			if (type == typeof(LocalPlayerIpLevelData[]))
			{
				return this.Create_LocalPlayerIpLevelDataArray(options);
			}
			if (type == typeof(MarqueeStorageData))
			{
				return this.Create_MarqueeStorageData(options);
			}
			if (type == typeof(RacingBetsRedDotState))
			{
				return this.Create_RacingBetsRedDotState(options);
			}
			if (type == typeof(RegionAndIpSt))
			{
				return this.Create_RegionAndIpSt(options);
			}
			if (type == typeof(SortStorageData))
			{
				return this.Create_SortStorageData(options);
			}
			if (type == typeof(Dictionary<EFunction, int>))
			{
				return this.Create_DictionaryEFunctionInt32(options);
			}
			if (type == typeof(Dictionary<FilterDefine.EFilterType, List<int>>))
			{
				return this.Create_DictionaryEFilterTypeListInt32(options);
			}
			if (type == typeof(Dictionary<int, bool>))
			{
				return this.Create_DictionaryInt32Boolean(options);
			}
			if (type == typeof(Dictionary<int, double>))
			{
				return this.Create_DictionaryInt32Double(options);
			}
			if (type == typeof(Dictionary<int, float[]>))
			{
				return this.Create_DictionaryInt32SingleArray(options);
			}
			if (type == typeof(Dictionary<int, float>))
			{
				return this.Create_DictionaryInt32Single(options);
			}
			if (type == typeof(Dictionary<int, AbyssDangoOwnerData>))
			{
				return this.Create_DictionaryInt32AbyssDangoOwnerData(options);
			}
			if (type == typeof(Dictionary<int, AreaExplorePlayState>))
			{
				return this.Create_DictionaryInt32AreaExplorePlayState(options);
			}
			if (type == typeof(Dictionary<int, LocalFriendApplication>))
			{
				return this.Create_DictionaryInt32LocalFriendApplication(options);
			}
			if (type == typeof(Dictionary<int, Dictionary<int, double>>))
			{
				return this.Create_DictionaryInt32DictionaryInt32Double(options);
			}
			if (type == typeof(Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>))
			{
				return this.Create_DictionaryInt32DictionaryInt32AbyssDangoOwnerData(options);
			}
			if (type == typeof(Dictionary<int, Dictionary<int, AreaExplorePlayState>>))
			{
				return this.Create_DictionaryInt32DictionaryInt32AreaExplorePlayState(options);
			}
			if (type == typeof(Dictionary<int, Dictionary<int, HashSet<int>>>))
			{
				return this.Create_DictionaryInt32DictionaryInt32HashSetInt32(options);
			}
			if (type == typeof(Dictionary<int, HashSet<int>>))
			{
				return this.Create_DictionaryInt32HashSetInt32(options);
			}
			if (type == typeof(Dictionary<int, List<int>>))
			{
				return this.Create_DictionaryInt32ListInt32(options);
			}
			if (type == typeof(Dictionary<int, int[]>))
			{
				return this.Create_DictionaryInt32Int32Array(options);
			}
			if (type == typeof(Dictionary<int, int>))
			{
				return this.Create_DictionaryInt32Int32(options);
			}
			if (type == typeof(Dictionary<int, long>))
			{
				return this.Create_DictionaryInt32Int64(options);
			}
			if (type == typeof(Dictionary<int, string>))
			{
				return this.Create_DictionaryInt32String(options);
			}
			if (type == typeof(Dictionary<string, bool>))
			{
				return this.Create_DictionaryStringBoolean(options);
			}
			if (type == typeof(Dictionary<string, FilterStorageData>))
			{
				return this.Create_DictionaryStringFilterStorageData(options);
			}
			if (type == typeof(Dictionary<string, GamepadTypeUsage>))
			{
				return this.Create_DictionaryStringGamepadTypeUsage(options);
			}
			if (type == typeof(Dictionary<string, LocalPlayerIpLevelData[]>))
			{
				return this.Create_DictionaryStringLocalPlayerIpLevelDataArray(options);
			}
			if (type == typeof(Dictionary<string, MarqueeStorageData>))
			{
				return this.Create_DictionaryStringMarqueeStorageData(options);
			}
			if (type == typeof(Dictionary<string, RegionAndIpSt>))
			{
				return this.Create_DictionaryStringRegionAndIpSt(options);
			}
			if (type == typeof(Dictionary<string, SortStorageData>))
			{
				return this.Create_DictionaryStringSortStorageData(options);
			}
			if (type == typeof(Dictionary<string, IList<IList<string>>>))
			{
				return this.Create_DictionaryStringIListIListString(options);
			}
			if (type == typeof(Dictionary<string, List<ActivityCacheData>>))
			{
				return this.Create_DictionaryStringListActivityCacheData(options);
			}
			if (type == typeof(Dictionary<string, int>))
			{
				return this.Create_DictionaryStringInt32(options);
			}
			if (type == typeof(HashSet<EMapNoteId>))
			{
				return this.Create_HashSetEMapNoteId(options);
			}
			if (type == typeof(HashSet<int>))
			{
				return this.Create_HashSetInt32(options);
			}
			if (type == typeof(IList<IList<string>>))
			{
				return this.Create_IListIListString(options);
			}
			if (type == typeof(IList<string>))
			{
				return this.Create_IListString(options);
			}
			if (type == typeof(List<ActivityCacheData>))
			{
				return this.Create_ListActivityCacheData(options);
			}
			if (type == typeof(List<EPlayPointState>))
			{
				return this.Create_ListEPlayPointState(options);
			}
			if (type == typeof(List<int>))
			{
				return this.Create_ListInt32(options);
			}
			if (type == typeof(List<string>))
			{
				return this.Create_ListString(options);
			}
			if (type == typeof(int))
			{
				return this.Create_Int32(options);
			}
			if (type == typeof(int?))
			{
				return this.Create_NullableInt32(options);
			}
			if (type == typeof(int[]))
			{
				return this.Create_Int32Array(options);
			}
			if (type == typeof(long))
			{
				return this.Create_Int64(options);
			}
			if (type == typeof(object))
			{
				return this.Create_Object(options);
			}
			if (type == typeof(string))
			{
				return this.Create_String(options);
			}
			if (type == typeof(string[]))
			{
				return this.Create_StringArray(options);
			}
			return null;
		}

		// Token: 0x04027021 RID: 159777
		[Nullable(2)]
		private JsonTypeInfo<bool> _Boolean;

		// Token: 0x04027022 RID: 159778
		[Nullable(2)]
		private JsonTypeInfo<bool?> _NullableBoolean;

		// Token: 0x04027023 RID: 159779
		[Nullable(2)]
		private JsonTypeInfo<double> _Double;

		// Token: 0x04027024 RID: 159780
		[Nullable(2)]
		private JsonTypeInfo<double?> _NullableDouble;

		// Token: 0x04027025 RID: 159781
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<double[]> _DoubleArray;

		// Token: 0x04027026 RID: 159782
		[Nullable(2)]
		private JsonTypeInfo<float> _Single;

		// Token: 0x04027027 RID: 159783
		[Nullable(2)]
		private JsonTypeInfo<float?> _NullableSingle;

		// Token: 0x04027028 RID: 159784
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<float[]> _SingleArray;

		// Token: 0x04027029 RID: 159785
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<AbyssDangoOwnerData> _AbyssDangoOwnerData;

		// Token: 0x0402702A RID: 159786
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<ActivityCacheData> _ActivityCacheData;

		// Token: 0x0402702B RID: 159787
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<AreaExplorePlayState> _AreaExplorePlayState;

		// Token: 0x0402702C RID: 159788
		[Nullable(2)]
		private JsonTypeInfo<EMapNoteId> _EMapNoteId;

		// Token: 0x0402702D RID: 159789
		[Nullable(2)]
		private JsonTypeInfo<EExploreType> _EExploreType;

		// Token: 0x0402702E RID: 159790
		[Nullable(2)]
		private JsonTypeInfo<EFunction> _EFunction;

		// Token: 0x0402702F RID: 159791
		[Nullable(2)]
		private JsonTypeInfo<EMotorMusicPlayMode> _EMotorMusicPlayMode;

		// Token: 0x04027030 RID: 159792
		[Nullable(2)]
		private JsonTypeInfo<EPlayPointState> _EPlayPointState;

		// Token: 0x04027031 RID: 159793
		[Nullable(2)]
		private JsonTypeInfo<ERouletteType> _ERouletteType;

		// Token: 0x04027032 RID: 159794
		[Nullable(2)]
		private JsonTypeInfo<ERouletteType?> _NullableERouletteType;

		// Token: 0x04027033 RID: 159795
		[Nullable(2)]
		private JsonTypeInfo<EVisionLevelUpIdentify> _EVisionLevelUpIdentify;

		// Token: 0x04027034 RID: 159796
		[Nullable(2)]
		private JsonTypeInfo<EVisionLevelUpIdentify?> _NullableEVisionLevelUpIdentify;

		// Token: 0x04027035 RID: 159797
		[Nullable(2)]
		private JsonTypeInfo<EVisionLevelUpMaterialPutInMode> _EVisionLevelUpMaterialPutInMode;

		// Token: 0x04027036 RID: 159798
		[Nullable(2)]
		private JsonTypeInfo<EVisionLevelUpMaterialPutInMode?> _NullableEVisionLevelUpMaterialPutInMode;

		// Token: 0x04027037 RID: 159799
		[Nullable(2)]
		private JsonTypeInfo<EVisionLevelUpMaterialUseType> _EVisionLevelUpMaterialUseType;

		// Token: 0x04027038 RID: 159800
		[Nullable(2)]
		private JsonTypeInfo<EVisionLevelUpMaterialUseType?> _NullableEVisionLevelUpMaterialUseType;

		// Token: 0x04027039 RID: 159801
		[Nullable(2)]
		private JsonTypeInfo<FilterDefine.EFilterType> _EFilterType;

		// Token: 0x0402703A RID: 159802
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<FilterStorageData> _FilterStorageData;

		// Token: 0x0402703B RID: 159803
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<GamepadTypeUsage> _GamepadTypeUsage;

		// Token: 0x0402703C RID: 159804
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<GameQualityData> _GameQualityData;

		// Token: 0x0402703D RID: 159805
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<IRacingBetsSettlementMainViewRecord> _IRacingBetsSettlementMainViewRecord;

		// Token: 0x0402703E RID: 159806
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<LocalFriendApplication> _LocalFriendApplication;

		// Token: 0x0402703F RID: 159807
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<LocalPlayerIpLevelData> _LocalPlayerIpLevelData;

		// Token: 0x04027040 RID: 159808
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<LocalPlayerIpLevelData[]> _LocalPlayerIpLevelDataArray;

		// Token: 0x04027041 RID: 159809
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<MarqueeStorageData> _MarqueeStorageData;

		// Token: 0x04027042 RID: 159810
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<RacingBetsRedDotState> _RacingBetsRedDotState;

		// Token: 0x04027043 RID: 159811
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<RegionAndIpSt> _RegionAndIpSt;

		// Token: 0x04027044 RID: 159812
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<SortStorageData> _SortStorageData;

		// Token: 0x04027045 RID: 159813
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<Dictionary<EFunction, int>> _DictionaryEFunctionInt32;

		// Token: 0x04027046 RID: 159814
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<FilterDefine.EFilterType, List<int>>> _DictionaryEFilterTypeListInt32;

		// Token: 0x04027047 RID: 159815
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<Dictionary<int, bool>> _DictionaryInt32Boolean;

		// Token: 0x04027048 RID: 159816
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<Dictionary<int, double>> _DictionaryInt32Double;

		// Token: 0x04027049 RID: 159817
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, float[]>> _DictionaryInt32SingleArray;

		// Token: 0x0402704A RID: 159818
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<Dictionary<int, float>> _DictionaryInt32Single;

		// Token: 0x0402704B RID: 159819
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, AbyssDangoOwnerData>> _DictionaryInt32AbyssDangoOwnerData;

		// Token: 0x0402704C RID: 159820
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, AreaExplorePlayState>> _DictionaryInt32AreaExplorePlayState;

		// Token: 0x0402704D RID: 159821
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, LocalFriendApplication>> _DictionaryInt32LocalFriendApplication;

		// Token: 0x0402704E RID: 159822
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, double>>> _DictionaryInt32DictionaryInt32Double;

		// Token: 0x0402704F RID: 159823
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>> _DictionaryInt32DictionaryInt32AbyssDangoOwnerData;

		// Token: 0x04027050 RID: 159824
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, AreaExplorePlayState>>> _DictionaryInt32DictionaryInt32AreaExplorePlayState;

		// Token: 0x04027051 RID: 159825
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, Dictionary<int, HashSet<int>>>> _DictionaryInt32DictionaryInt32HashSetInt32;

		// Token: 0x04027052 RID: 159826
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, HashSet<int>>> _DictionaryInt32HashSetInt32;

		// Token: 0x04027053 RID: 159827
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, List<int>>> _DictionaryInt32ListInt32;

		// Token: 0x04027054 RID: 159828
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, int[]>> _DictionaryInt32Int32Array;

		// Token: 0x04027055 RID: 159829
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<Dictionary<int, int>> _DictionaryInt32Int32;

		// Token: 0x04027056 RID: 159830
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<Dictionary<int, long>> _DictionaryInt32Int64;

		// Token: 0x04027057 RID: 159831
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<int, string>> _DictionaryInt32String;

		// Token: 0x04027058 RID: 159832
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, bool>> _DictionaryStringBoolean;

		// Token: 0x04027059 RID: 159833
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, FilterStorageData>> _DictionaryStringFilterStorageData;

		// Token: 0x0402705A RID: 159834
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, GamepadTypeUsage>> _DictionaryStringGamepadTypeUsage;

		// Token: 0x0402705B RID: 159835
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, LocalPlayerIpLevelData[]>> _DictionaryStringLocalPlayerIpLevelDataArray;

		// Token: 0x0402705C RID: 159836
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, MarqueeStorageData>> _DictionaryStringMarqueeStorageData;

		// Token: 0x0402705D RID: 159837
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, RegionAndIpSt>> _DictionaryStringRegionAndIpSt;

		// Token: 0x0402705E RID: 159838
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, SortStorageData>> _DictionaryStringSortStorageData;

		// Token: 0x0402705F RID: 159839
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, IList<IList<string>>>> _DictionaryStringIListIListString;

		// Token: 0x04027060 RID: 159840
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, List<ActivityCacheData>>> _DictionaryStringListActivityCacheData;

		// Token: 0x04027061 RID: 159841
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<Dictionary<string, int>> _DictionaryStringInt32;

		// Token: 0x04027062 RID: 159842
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<HashSet<EMapNoteId>> _HashSetEMapNoteId;

		// Token: 0x04027063 RID: 159843
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<HashSet<int>> _HashSetInt32;

		// Token: 0x04027064 RID: 159844
		[Nullable(new byte[]
		{
			2,
			1,
			1,
			1
		})]
		private JsonTypeInfo<IList<IList<string>>> _IListIListString;

		// Token: 0x04027065 RID: 159845
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<IList<string>> _IListString;

		// Token: 0x04027066 RID: 159846
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<List<ActivityCacheData>> _ListActivityCacheData;

		// Token: 0x04027067 RID: 159847
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<List<EPlayPointState>> _ListEPlayPointState;

		// Token: 0x04027068 RID: 159848
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<List<int>> _ListInt32;

		// Token: 0x04027069 RID: 159849
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<List<string>> _ListString;

		// Token: 0x0402706A RID: 159850
		[Nullable(2)]
		private JsonTypeInfo<int> _Int32;

		// Token: 0x0402706B RID: 159851
		[Nullable(2)]
		private JsonTypeInfo<int?> _NullableInt32;

		// Token: 0x0402706C RID: 159852
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<int[]> _Int32Array;

		// Token: 0x0402706D RID: 159853
		[Nullable(2)]
		private JsonTypeInfo<long> _Int64;

		// Token: 0x0402706E RID: 159854
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<object> _Object;

		// Token: 0x0402706F RID: 159855
		[Nullable(new byte[]
		{
			2,
			1
		})]
		private JsonTypeInfo<string> _String;

		// Token: 0x04027070 RID: 159856
		[Nullable(new byte[]
		{
			2,
			1,
			1
		})]
		private JsonTypeInfo<string[]> _StringArray;

		// Token: 0x04027071 RID: 159857
		[Nullable(1)]
		private static readonly JsonSerializerOptions s_defaultOptions = new JsonSerializerOptions
		{
			DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
			IncludeFields = true
		};

		// Token: 0x04027072 RID: 159858
		private const BindingFlags InstanceMemberBindingFlags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic;

		// Token: 0x0200CC84 RID: 52356
		[CompilerGenerated]
		private static class <>O
		{
			// Token: 0x0403EB1B RID: 256795
			[Nullable(new byte[]
			{
				0,
				1,
				1
			})]
			public static Func<JsonParameterInfoValues[]> <0>__MarqueeStorageDataCtorParamInit;
		}
	}
}
