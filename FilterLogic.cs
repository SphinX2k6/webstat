using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using FilterDefine;

// Token: 0x020018DF RID: 6367
[NullableContext(1)]
[Nullable(0)]
public class FilterLogic
{
	// Token: 0x0600B6EB RID: 46827 RVA: 0x0030A130 File Offset: 0x00308330
	public Func<int[], FilterItemData[]> GetDataFuncByType(FilterDefine.EFilterType type)
	{
		Func<int[], FilterItemData[]> result;
		if (this.FilterTypeMapInternal.TryGetValue(type, out result))
		{
			return result;
		}
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Filter;
		ELogAuthor author = ELogAuthor.WDX;
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(28, 1);
		defaultInterpolatedStringHandler.AppendLiteral("GetDataFuncByType not found ");
		defaultInterpolatedStringHandler.AppendFormatted<FilterDefine.EFilterType>(type);
		instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
		return null;
	}

	// Token: 0x0600B6EC RID: 46828 RVA: 0x0030A18F File Offset: 0x0030838F
	private TDefaultFilter[] GetDefaultFilterFunction(EFilterDataType dataType)
	{
		return this.DataMapInternal[dataType].DefaultFilterList();
	}

	// Token: 0x0600B6ED RID: 46829 RVA: 0x0030A1A4 File Offset: 0x003083A4
	[NullableContext(2)]
	private unsafe TFilterConfig GetFilterFunctionByParam(EFilterDataType dataType, FilterDefine.EFilterType filterType)
	{
		CommonFilter commonFilter = this.DataMapInternal[dataType];
		commonFilter.InitFilterMap();
		TFilterConfig filterFunction = commonFilter.GetFilterFunction(filterType);
		if (filterFunction == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Filter;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "传入的筛选项id查找不到对应方法";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("数据类型", dataType);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("筛选表格类型", filterType);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			return null;
		}
		return filterFunction;
	}

	// Token: 0x0600B6EE RID: 46830 RVA: 0x0030A230 File Offset: 0x00308430
	private List<T> GetFilterListIntersection<[Nullable(2)] T>(List<T> dataList, EFilterDataType dataType, FilterDefine.EFilterType typeId, Dictionary<int, string> idMap)
	{
		TFilterConfig filterFunctionByParam = this.GetFilterFunctionByParam(dataType, typeId);
		if (filterFunctionByParam == null)
		{
			return dataList;
		}
		List<T> list = new List<T>();
		foreach (T t in dataList)
		{
			object obj = filterFunctionByParam(t, idMap);
			if (obj != null)
			{
				Array array = obj as Array;
				if (array != null)
				{
					using (IEnumerator enumerator2 = array.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj2 = enumerator2.Current;
							if (idMap.ContainsKey((int)obj2))
							{
								list.Add(t);
								break;
							}
						}
						continue;
					}
				}
				IList list2 = obj as IList;
				if (list2 != null)
				{
					using (IEnumerator enumerator2 = list2.GetEnumerator())
					{
						while (enumerator2.MoveNext())
						{
							object obj3 = enumerator2.Current;
							if (idMap.ContainsKey((int)obj3))
							{
								list.Add(t);
								break;
							}
						}
						continue;
					}
				}
				if (idMap.ContainsKey((int)obj))
				{
					list.Add(t);
				}
			}
		}
		return list;
	}

	// Token: 0x0600B6EF RID: 46831 RVA: 0x0030A3B8 File Offset: 0x003085B8
	[return: TupleElementNames(new string[]
	{
		"FindList",
		"UnFindList"
	})]
	[return: Nullable(new byte[]
	{
		0,
		1,
		1,
		1,
		1
	})]
	private ValueTuple<List<T>, List<T>> GetFilterListUnion<[Nullable(2)] T>(List<T> dataList, EFilterDataType dataType, FilterDefine.EFilterType typeId, Dictionary<int, string> idMap)
	{
		TFilterConfig filterFunctionByParam = this.GetFilterFunctionByParam(dataType, typeId);
		if (filterFunctionByParam == null)
		{
			return new ValueTuple<List<T>, List<T>>(new List<T>(), dataList);
		}
		List<T> list = new List<T>();
		List<T> list2 = new List<T>();
		foreach (T t in dataList)
		{
			object obj = filterFunctionByParam(t, idMap);
			if (obj == null)
			{
				list2.Add(t);
			}
			else
			{
				Array array = obj as Array;
				if (array != null)
				{
					bool flag = false;
					foreach (object obj2 in array)
					{
						if (idMap.ContainsKey((int)obj2))
						{
							list.Add(t);
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						list2.Add(t);
					}
				}
				else if (idMap.ContainsKey((int)obj))
				{
					list.Add(t);
				}
				else
				{
					list2.Add(t);
				}
			}
		}
		return new ValueTuple<List<T>, List<T>>(list, list2);
	}

	// Token: 0x0600B6F0 RID: 46832 RVA: 0x0030A4F0 File Offset: 0x003086F0
	public List<T> GetFilterList<[Nullable(2)] T>(List<T> dataList, EFilterDataType dataType, bool isSupportSelectAll, bool isSelectAllUnion, Dictionary<FilterDefine.EFilterType, Dictionary<int, string>> ruleData)
	{
		List<T> list = new List<T>();
		List<T> list2 = new List<T>();
		TDefaultFilter[] defaultFilterFunction = this.GetDefaultFilterFunction(dataType);
		if (defaultFilterFunction.Length == 0)
		{
			list2 = dataList;
		}
		foreach (TDefaultFilter tdefaultFilter in defaultFilterFunction)
		{
			foreach (T t in dataList)
			{
				if (tdefaultFilter(t))
				{
					list.Add(t);
				}
				else
				{
					list2.Add(t);
				}
			}
		}
		if (!isSupportSelectAll || !isSelectAllUnion)
		{
			List<T> list3 = list2;
			foreach (KeyValuePair<FilterDefine.EFilterType, Dictionary<int, string>> keyValuePair in ruleData)
			{
				FilterDefine.EFilterType key = keyValuePair.Key;
				Dictionary<int, string> value = keyValuePair.Value;
				if (value.Count > 0)
				{
					list3 = this.GetFilterListIntersection<T>(list3, dataType, key, value);
				}
			}
			list3.AddRange(list);
			return list3;
		}
		List<T> list4 = list2;
		List<T> list5 = new List<T>();
		bool flag = false;
		foreach (KeyValuePair<FilterDefine.EFilterType, Dictionary<int, string>> keyValuePair2 in ruleData)
		{
			FilterDefine.EFilterType key2 = keyValuePair2.Key;
			Dictionary<int, string> value2 = keyValuePair2.Value;
			if (value2.Count > 0)
			{
				flag = true;
				ValueTuple<List<T>, List<T>> filterListUnion = this.GetFilterListUnion<T>(list4, dataType, key2, value2);
				list4 = filterListUnion.Item2;
				list5.AddRange(filterListUnion.Item1);
			}
		}
		if (!flag)
		{
			List<T> list6 = new List<T>(list4);
			list6.AddRange(list);
			return list6;
		}
		list5.AddRange(list);
		return list5;
	}

	// Token: 0x0600B6F1 RID: 46833 RVA: 0x0030A6AC File Offset: 0x003088AC
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<FilterItemData> GetFilterItemDataList(int ruleId, int configId)
	{
		FilterRule value = ConfigBase<FilterConfig>.Instance.GetFilterRuleConfig(ruleId).Value;
		FilterDefine.EFilterType filterType = (FilterDefine.EFilterType)value.FilterType;
		Func<int[], FilterItemData[]> func;
		if (!this.FilterTypeMapInternal.TryGetValue(filterType, out func))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Filter;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "传入的筛选表格类型未进行枚举定义以及方法实现";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("FilterDefine.EFilterType", filterType);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		Filter value2 = ConfigBase<FilterConfig>.Instance.GetFilterConfig(configId).Value;
		FilterItemData[] array = func(value.IdList());
		foreach (FilterItemData filterItemData in array)
		{
			filterItemData.SetIsShowIcon(value2.IsShowIcon);
			filterItemData.NeedChangeColor = value.NeedChangeColor;
		}
		return array.ToList<FilterItemData>();
	}

	// Token: 0x0600B6F2 RID: 46834 RVA: 0x0030A778 File Offset: 0x00308978
	public FilterLogic()
	{
		Dictionary<FilterDefine.EFilterType, Func<int[], FilterItemData[]>> dictionary = new Dictionary<FilterDefine.EFilterType, Func<int[], FilterItemData[]>>();
		FilterDefine.EFilterType key = FilterDefine.EFilterType.Element;
		Func<int[], FilterItemData[]> value;
		if ((value = FilterLogic.<>O.<0>__GetElementFilterData) == null)
		{
			value = (FilterLogic.<>O.<0>__GetElementFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetElementFilterData));
		}
		dictionary.Add(key, value);
		FilterDefine.EFilterType key2 = FilterDefine.EFilterType.Weapon;
		Func<int[], FilterItemData[]> value2;
		if ((value2 = FilterLogic.<>O.<1>__GetWeaponFilterData) == null)
		{
			value2 = (FilterLogic.<>O.<1>__GetWeaponFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetWeaponFilterData));
		}
		dictionary.Add(key2, value2);
		FilterDefine.EFilterType key3 = FilterDefine.EFilterType.Phantom;
		Func<int[], FilterItemData[]> value3;
		if ((value3 = FilterLogic.<>O.<2>__GetPhantomFilterData) == null)
		{
			value3 = (FilterLogic.<>O.<2>__GetPhantomFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomFilterData));
		}
		dictionary.Add(key3, value3);
		FilterDefine.EFilterType key4 = FilterDefine.EFilterType.PhantomFetter;
		Func<int[], FilterItemData[]> value4;
		if ((value4 = FilterLogic.<>O.<2>__GetPhantomFilterData) == null)
		{
			value4 = (FilterLogic.<>O.<2>__GetPhantomFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomFilterData));
		}
		dictionary.Add(key4, value4);
		FilterDefine.EFilterType key5 = FilterDefine.EFilterType.MonsterDetect;
		Func<int[], FilterItemData[]> value5;
		if ((value5 = FilterLogic.<>O.<3>__GetDetectFilterData) == null)
		{
			value5 = (FilterLogic.<>O.<3>__GetDetectFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDetectFilterData));
		}
		dictionary.Add(key5, value5);
		FilterDefine.EFilterType key6 = FilterDefine.EFilterType.SilentAreaDetect;
		Func<int[], FilterItemData[]> value6;
		if ((value6 = FilterLogic.<>O.<3>__GetDetectFilterData) == null)
		{
			value6 = (FilterLogic.<>O.<3>__GetDetectFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDetectFilterData));
		}
		dictionary.Add(key6, value6);
		FilterDefine.EFilterType key7 = FilterDefine.EFilterType.DungeonDetect;
		Func<int[], FilterItemData[]> value7;
		if ((value7 = FilterLogic.<>O.<3>__GetDetectFilterData) == null)
		{
			value7 = (FilterLogic.<>O.<3>__GetDetectFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDetectFilterData));
		}
		dictionary.Add(key7, value7);
		FilterDefine.EFilterType key8 = FilterDefine.EFilterType.CookMenu;
		Func<int[], FilterItemData[]> value8;
		if ((value8 = FilterLogic.<>O.<4>__GetCookMenuFilterData) == null)
		{
			value8 = (FilterLogic.<>O.<4>__GetCookMenuFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetCookMenuFilterData));
		}
		dictionary.Add(key8, value8);
		FilterDefine.EFilterType key9 = FilterDefine.EFilterType.CookType;
		Func<int[], FilterItemData[]> value9;
		if ((value9 = FilterLogic.<>O.<5>__GetCookTypeFilterData) == null)
		{
			value9 = (FilterLogic.<>O.<5>__GetCookTypeFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetCookTypeFilterData));
		}
		dictionary.Add(key9, value9);
		FilterDefine.EFilterType key10 = FilterDefine.EFilterType.ComposeMenu;
		Func<int[], FilterItemData[]> value10;
		if ((value10 = FilterLogic.<>O.<6>__GetComposeFilterData) == null)
		{
			value10 = (FilterLogic.<>O.<6>__GetComposeFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetComposeFilterData));
		}
		dictionary.Add(key10, value10);
		FilterDefine.EFilterType key11 = FilterDefine.EFilterType.ComposeStructureMenu;
		Func<int[], FilterItemData[]> value11;
		if ((value11 = FilterLogic.<>O.<6>__GetComposeFilterData) == null)
		{
			value11 = (FilterLogic.<>O.<6>__GetComposeFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetComposeFilterData));
		}
		dictionary.Add(key11, value11);
		FilterDefine.EFilterType key12 = FilterDefine.EFilterType.PhantomRarity;
		Func<int[], FilterItemData[]> value12;
		if ((value12 = FilterLogic.<>O.<7>__GetPhantomRarityFilterData) == null)
		{
			value12 = (FilterLogic.<>O.<7>__GetPhantomRarityFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomRarityFilterData));
		}
		dictionary.Add(key12, value12);
		FilterDefine.EFilterType key13 = FilterDefine.EFilterType.PhantomFettersEquip;
		Func<int[], FilterItemData[]> value13;
		if ((value13 = FilterLogic.<>O.<8>__GetPhantomFettersEquipFilterData) == null)
		{
			value13 = (FilterLogic.<>O.<8>__GetPhantomFettersEquipFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomFettersEquipFilterData));
		}
		dictionary.Add(key13, value13);
		FilterDefine.EFilterType key14 = FilterDefine.EFilterType.PhantomFettersHas;
		Func<int[], FilterItemData[]> value14;
		if ((value14 = FilterLogic.<>O.<9>__GetPhantomFettersHasFilterData) == null)
		{
			value14 = (FilterLogic.<>O.<9>__GetPhantomFettersHasFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomFettersHasFilterData));
		}
		dictionary.Add(key14, value14);
		FilterDefine.EFilterType key15 = FilterDefine.EFilterType.MonsterType;
		Func<int[], FilterItemData[]> value15;
		if ((value15 = FilterLogic.<>O.<3>__GetDetectFilterData) == null)
		{
			value15 = (FilterLogic.<>O.<3>__GetDetectFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDetectFilterData));
		}
		dictionary.Add(key15, value15);
		FilterDefine.EFilterType key16 = FilterDefine.EFilterType.VisionRarity1;
		Func<int[], FilterItemData[]> value16;
		if ((value16 = FilterLogic.<>O.<10>__GetPhantomRarityZeroFilterData) == null)
		{
			value16 = (FilterLogic.<>O.<10>__GetPhantomRarityZeroFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomRarityZeroFilterData));
		}
		dictionary.Add(key16, value16);
		FilterDefine.EFilterType key17 = FilterDefine.EFilterType.VisionRarity2;
		Func<int[], FilterItemData[]> value17;
		if ((value17 = FilterLogic.<>O.<11>__GetPhantomRarityOneFilterData) == null)
		{
			value17 = (FilterLogic.<>O.<11>__GetPhantomRarityOneFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomRarityOneFilterData));
		}
		dictionary.Add(key17, value17);
		FilterDefine.EFilterType key18 = FilterDefine.EFilterType.VisionRarity3;
		Func<int[], FilterItemData[]> value18;
		if ((value18 = FilterLogic.<>O.<12>__GetPhantomRarityTwoFilterData) == null)
		{
			value18 = (FilterLogic.<>O.<12>__GetPhantomRarityTwoFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomRarityTwoFilterData));
		}
		dictionary.Add(key18, value18);
		FilterDefine.EFilterType key19 = FilterDefine.EFilterType.VisionRarity4;
		Func<int[], FilterItemData[]> value19;
		if ((value19 = FilterLogic.<>O.<13>__GetPhantomRarityThreeFilterData) == null)
		{
			value19 = (FilterLogic.<>O.<13>__GetPhantomRarityThreeFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomRarityThreeFilterData));
		}
		dictionary.Add(key19, value19);
		FilterDefine.EFilterType key20 = FilterDefine.EFilterType.ItemQuality;
		Func<int[], FilterItemData[]> value20;
		if ((value20 = FilterLogic.<>O.<14>__GetItemQualityFilterData) == null)
		{
			value20 = (FilterLogic.<>O.<14>__GetItemQualityFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetItemQualityFilterData));
		}
		dictionary.Add(key20, value20);
		FilterDefine.EFilterType key21 = FilterDefine.EFilterType.VisionDestroyCost;
		Func<int[], FilterItemData[]> value21;
		if ((value21 = FilterLogic.<>O.<15>__GetVisionDestroyCostData) == null)
		{
			value21 = (FilterLogic.<>O.<15>__GetVisionDestroyCostData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetVisionDestroyCostData));
		}
		dictionary.Add(key21, value21);
		FilterDefine.EFilterType key22 = FilterDefine.EFilterType.VisionDestroyQuality;
		Func<int[], FilterItemData[]> value22;
		if ((value22 = FilterLogic.<>O.<16>__GetVisionDestroyQualityData) == null)
		{
			value22 = (FilterLogic.<>O.<16>__GetVisionDestroyQualityData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetVisionDestroyQualityData));
		}
		dictionary.Add(key22, value22);
		FilterDefine.EFilterType key23 = FilterDefine.EFilterType.VisionDestroyFetterGroup;
		Func<int[], FilterItemData[]> value23;
		if ((value23 = FilterLogic.<>O.<17>__GetVisionDestroyFetterGroupData) == null)
		{
			value23 = (FilterLogic.<>O.<17>__GetVisionDestroyFetterGroupData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetVisionDestroyFetterGroupData));
		}
		dictionary.Add(key23, value23);
		FilterDefine.EFilterType key24 = FilterDefine.EFilterType.VisionDestroyAttribute;
		Func<int[], FilterItemData[]> value24;
		if ((value24 = FilterLogic.<>O.<18>__GetVisionDestroyAttribute) == null)
		{
			value24 = (FilterLogic.<>O.<18>__GetVisionDestroyAttribute = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetVisionDestroyAttribute));
		}
		dictionary.Add(key24, value24);
		FilterDefine.EFilterType key25 = FilterDefine.EFilterType.RoleTag;
		Func<int[], FilterItemData[]> value25;
		if ((value25 = FilterLogic.<>O.<19>__GetRoleTagFilterList) == null)
		{
			value25 = (FilterLogic.<>O.<19>__GetRoleTagFilterList = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetRoleTagFilterList));
		}
		dictionary.Add(key25, value25);
		FilterDefine.EFilterType key26 = FilterDefine.EFilterType.PhantomDeprecate;
		Func<int[], FilterItemData[]> value26;
		if ((value26 = FilterLogic.<>O.<20>__GetItemDeprecateFilterList) == null)
		{
			value26 = (FilterLogic.<>O.<20>__GetItemDeprecateFilterList = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetItemDeprecateFilterList));
		}
		dictionary.Add(key26, value26);
		FilterDefine.EFilterType key27 = FilterDefine.EFilterType.Attribute;
		Func<int[], FilterItemData[]> value27;
		if ((value27 = FilterLogic.<>O.<21>__GetVisionGroupAttributeFilterList) == null)
		{
			value27 = (FilterLogic.<>O.<21>__GetVisionGroupAttributeFilterList = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetVisionGroupAttributeFilterList));
		}
		dictionary.Add(key27, value27);
		FilterDefine.EFilterType key28 = FilterDefine.EFilterType.FishingTech;
		Func<int[], FilterItemData[]> value28;
		if ((value28 = FilterLogic.<>O.<22>__GetFishingTechData) == null)
		{
			value28 = (FilterLogic.<>O.<22>__GetFishingTechData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetFishingTechData));
		}
		dictionary.Add(key28, value28);
		FilterDefine.EFilterType key29 = FilterDefine.EFilterType.FishingArea;
		Func<int[], FilterItemData[]> value29;
		if ((value29 = FilterLogic.<>O.<23>__GetFishingAreaData) == null)
		{
			value29 = (FilterLogic.<>O.<23>__GetFishingAreaData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetFishingAreaData));
		}
		dictionary.Add(key29, value29);
		FilterDefine.EFilterType key30 = FilterDefine.EFilterType.FishingTime;
		Func<int[], FilterItemData[]> value30;
		if ((value30 = FilterLogic.<>O.<24>__GetFishingTimeData) == null)
		{
			value30 = (FilterLogic.<>O.<24>__GetFishingTimeData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetFishingTimeData));
		}
		dictionary.Add(key30, value30);
		FilterDefine.EFilterType key31 = FilterDefine.EFilterType.FishingType;
		Func<int[], FilterItemData[]> value31;
		if ((value31 = FilterLogic.<>O.<25>__GetFishingTypeData) == null)
		{
			value31 = (FilterLogic.<>O.<25>__GetFishingTypeData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetFishingTypeData));
		}
		dictionary.Add(key31, value31);
		FilterDefine.EFilterType key32 = FilterDefine.EFilterType.DangoAbyssPluginQuality;
		Func<int[], FilterItemData[]> value32;
		if ((value32 = FilterLogic.<>O.<26>__GetDangoAbyssPluginQualityData) == null)
		{
			value32 = (FilterLogic.<>O.<26>__GetDangoAbyssPluginQualityData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDangoAbyssPluginQualityData));
		}
		dictionary.Add(key32, value32);
		FilterDefine.EFilterType key33 = FilterDefine.EFilterType.DangoAbyssPluginProp;
		Func<int[], FilterItemData[]> value33;
		if ((value33 = FilterLogic.<>O.<27>__GetDangoAbyssPluginPropData) == null)
		{
			value33 = (FilterLogic.<>O.<27>__GetDangoAbyssPluginPropData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDangoAbyssPluginPropData));
		}
		dictionary.Add(key33, value33);
		FilterDefine.EFilterType key34 = FilterDefine.EFilterType.DangoAbyssPluginTag;
		Func<int[], FilterItemData[]> value34;
		if ((value34 = FilterLogic.<>O.<28>__GetDangoAbyssPluginTagData) == null)
		{
			value34 = (FilterLogic.<>O.<28>__GetDangoAbyssPluginTagData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDangoAbyssPluginTagData));
		}
		dictionary.Add(key34, value34);
		FilterDefine.EFilterType key35 = FilterDefine.EFilterType.DangoAbyssPluginEquipState;
		Func<int[], FilterItemData[]> value35;
		if ((value35 = FilterLogic.<>O.<8>__GetPhantomFettersEquipFilterData) == null)
		{
			value35 = (FilterLogic.<>O.<8>__GetPhantomFettersEquipFilterData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomFettersEquipFilterData));
		}
		dictionary.Add(key35, value35);
		FilterDefine.EFilterType key36 = FilterDefine.EFilterType.DangoAbyssPluginLockState;
		Func<int[], FilterItemData[]> value36;
		if ((value36 = FilterLogic.<>O.<29>__GetDangoAbyssPluginLockStateData) == null)
		{
			value36 = (FilterLogic.<>O.<29>__GetDangoAbyssPluginLockStateData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetDangoAbyssPluginLockStateData));
		}
		dictionary.Add(key36, value36);
		FilterDefine.EFilterType key37 = FilterDefine.EFilterType.DangoAbyssPluginDeprecateState;
		Func<int[], FilterItemData[]> value37;
		if ((value37 = FilterLogic.<>O.<20>__GetItemDeprecateFilterList) == null)
		{
			value37 = (FilterLogic.<>O.<20>__GetItemDeprecateFilterList = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetItemDeprecateFilterList));
		}
		dictionary.Add(key37, value37);
		FilterDefine.EFilterType key38 = FilterDefine.EFilterType.PhantomManageFirstMainProp;
		Func<int[], FilterItemData[]> value38;
		if ((value38 = FilterLogic.<>O.<30>__GetPhantomManageFirstMainPropData) == null)
		{
			value38 = (FilterLogic.<>O.<30>__GetPhantomManageFirstMainPropData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomManageFirstMainPropData));
		}
		dictionary.Add(key38, value38);
		FilterDefine.EFilterType key39 = FilterDefine.EFilterType.PhantomManageCost;
		Func<int[], FilterItemData[]> value39;
		if ((value39 = FilterLogic.<>O.<31>__GetPhantomManageCostData) == null)
		{
			value39 = (FilterLogic.<>O.<31>__GetPhantomManageCostData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPhantomManageCostData));
		}
		dictionary.Add(key39, value39);
		FilterDefine.EFilterType key40 = FilterDefine.EFilterType.PinballRoleBd;
		Func<int[], FilterItemData[]> value40;
		if ((value40 = FilterLogic.<>O.<32>__GetPinballRoleBdData) == null)
		{
			value40 = (FilterLogic.<>O.<32>__GetPinballRoleBdData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPinballRoleBdData));
		}
		dictionary.Add(key40, value40);
		FilterDefine.EFilterType key41 = FilterDefine.EFilterType.PinballRoleClass;
		Func<int[], FilterItemData[]> value41;
		if ((value41 = FilterLogic.<>O.<33>__GetPinballRoleClassData) == null)
		{
			value41 = (FilterLogic.<>O.<33>__GetPinballRoleClassData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPinballRoleClassData));
		}
		dictionary.Add(key41, value41);
		FilterDefine.EFilterType key42 = FilterDefine.EFilterType.PinballWeaponType;
		Func<int[], FilterItemData[]> value42;
		if ((value42 = FilterLogic.<>O.<34>__GetPinballWeaponTypeData) == null)
		{
			value42 = (FilterLogic.<>O.<34>__GetPinballWeaponTypeData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPinballWeaponTypeData));
		}
		dictionary.Add(key42, value42);
		FilterDefine.EFilterType key43 = FilterDefine.EFilterType.PinballWeaponQuality;
		Func<int[], FilterItemData[]> value43;
		if ((value43 = FilterLogic.<>O.<35>__GetPinballWeaponQualityData) == null)
		{
			value43 = (FilterLogic.<>O.<35>__GetPinballWeaponQualityData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetPinballWeaponQualityData));
		}
		dictionary.Add(key43, value43);
		FilterDefine.EFilterType key44 = FilterDefine.EFilterType.RoleLangCustomType;
		Func<int[], FilterItemData[]> value44;
		if ((value44 = FilterLogic.<>O.<36>__GetRoleLangCustomData) == null)
		{
			value44 = (FilterLogic.<>O.<36>__GetRoleLangCustomData = new Func<int[], FilterItemData[]>(FilterTypeFunctionLibrary.GetRoleLangCustomData));
		}
		dictionary.Add(key44, value44);
		this.FilterTypeMapInternal = dictionary;
		base..ctor();
	}

	// Token: 0x04005688 RID: 22152
	private readonly Dictionary<EFilterDataType, CommonFilter> DataMapInternal = new Dictionary<EFilterDataType, CommonFilter>
	{
		{
			EFilterDataType.Role,
			new RoleFilter()
		},
		{
			EFilterDataType.Phantom,
			new PhantomFilter()
		},
		{
			EFilterDataType.PhantomFetter,
			new PhantomFetterFilter()
		},
		{
			EFilterDataType.CalabashCollect,
			new CalabashCollectFilter()
		},
		{
			EFilterDataType.ItemData,
			new ItemFilter()
		},
		{
			EFilterDataType.MonsterDetect,
			new MonsterDetectFilter()
		},
		{
			EFilterDataType.SilentAreaDetect,
			new SilentAreaDetectFilter()
		},
		{
			EFilterDataType.DungeonDetect,
			new DungeonDetectFilter()
		},
		{
			EFilterDataType.Cook,
			new CookFilter()
		},
		{
			EFilterDataType.Reagent,
			new ComposeFilter()
		},
		{
			EFilterDataType.Structure,
			new ComposeFilter()
		},
		{
			EFilterDataType.InventoryItem,
			new InventoryFilter()
		},
		{
			EFilterDataType.VisionDestroy,
			new VisionDestroyFilter()
		},
		{
			EFilterDataType.VisionAssemble,
			new VisionAssembleFilter()
		},
		{
			EFilterDataType.FishingItem,
			new FishingItemFilter()
		},
		{
			EFilterDataType.EditFormationRole,
			new EditFormationRoleFilter()
		},
		{
			EFilterDataType.DangoAbyssPlugin,
			new DangoAbyssPluginFilter()
		},
		{
			EFilterDataType.MonsterHandBook,
			new MonsterHandBookFilter()
		},
		{
			EFilterDataType.WeaponHandBook,
			new WeaponHandBookFilter()
		},
		{
			EFilterDataType.WeaponSkinHandBook,
			new WeaponSkinHandBookFilter()
		},
		{
			EFilterDataType.PinballFormation,
			new PinballFormationFilter()
		},
		{
			EFilterDataType.PinballWeapon,
			new PinballWeaponFilter()
		},
		{
			EFilterDataType.PinballRoleSelect,
			new PinballRoleSelectFilter()
		}
	};

	// Token: 0x04005689 RID: 22153
	private readonly Dictionary<FilterDefine.EFilterType, Func<int[], FilterItemData[]>> FilterTypeMapInternal;

	// Token: 0x02007C50 RID: 31824
	[CompilerGenerated]
	private static class <>O
	{
		// Token: 0x0402A746 RID: 173894
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <0>__GetElementFilterData;

		// Token: 0x0402A747 RID: 173895
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <1>__GetWeaponFilterData;

		// Token: 0x0402A748 RID: 173896
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <2>__GetPhantomFilterData;

		// Token: 0x0402A749 RID: 173897
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <3>__GetDetectFilterData;

		// Token: 0x0402A74A RID: 173898
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <4>__GetCookMenuFilterData;

		// Token: 0x0402A74B RID: 173899
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <5>__GetCookTypeFilterData;

		// Token: 0x0402A74C RID: 173900
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <6>__GetComposeFilterData;

		// Token: 0x0402A74D RID: 173901
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <7>__GetPhantomRarityFilterData;

		// Token: 0x0402A74E RID: 173902
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <8>__GetPhantomFettersEquipFilterData;

		// Token: 0x0402A74F RID: 173903
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <9>__GetPhantomFettersHasFilterData;

		// Token: 0x0402A750 RID: 173904
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <10>__GetPhantomRarityZeroFilterData;

		// Token: 0x0402A751 RID: 173905
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <11>__GetPhantomRarityOneFilterData;

		// Token: 0x0402A752 RID: 173906
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <12>__GetPhantomRarityTwoFilterData;

		// Token: 0x0402A753 RID: 173907
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <13>__GetPhantomRarityThreeFilterData;

		// Token: 0x0402A754 RID: 173908
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <14>__GetItemQualityFilterData;

		// Token: 0x0402A755 RID: 173909
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <15>__GetVisionDestroyCostData;

		// Token: 0x0402A756 RID: 173910
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <16>__GetVisionDestroyQualityData;

		// Token: 0x0402A757 RID: 173911
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <17>__GetVisionDestroyFetterGroupData;

		// Token: 0x0402A758 RID: 173912
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <18>__GetVisionDestroyAttribute;

		// Token: 0x0402A759 RID: 173913
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <19>__GetRoleTagFilterList;

		// Token: 0x0402A75A RID: 173914
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <20>__GetItemDeprecateFilterList;

		// Token: 0x0402A75B RID: 173915
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <21>__GetVisionGroupAttributeFilterList;

		// Token: 0x0402A75C RID: 173916
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <22>__GetFishingTechData;

		// Token: 0x0402A75D RID: 173917
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <23>__GetFishingAreaData;

		// Token: 0x0402A75E RID: 173918
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <24>__GetFishingTimeData;

		// Token: 0x0402A75F RID: 173919
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <25>__GetFishingTypeData;

		// Token: 0x0402A760 RID: 173920
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <26>__GetDangoAbyssPluginQualityData;

		// Token: 0x0402A761 RID: 173921
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <27>__GetDangoAbyssPluginPropData;

		// Token: 0x0402A762 RID: 173922
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <28>__GetDangoAbyssPluginTagData;

		// Token: 0x0402A763 RID: 173923
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <29>__GetDangoAbyssPluginLockStateData;

		// Token: 0x0402A764 RID: 173924
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <30>__GetPhantomManageFirstMainPropData;

		// Token: 0x0402A765 RID: 173925
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <31>__GetPhantomManageCostData;

		// Token: 0x0402A766 RID: 173926
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <32>__GetPinballRoleBdData;

		// Token: 0x0402A767 RID: 173927
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <33>__GetPinballRoleClassData;

		// Token: 0x0402A768 RID: 173928
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <34>__GetPinballWeaponTypeData;

		// Token: 0x0402A769 RID: 173929
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <35>__GetPinballWeaponQualityData;

		// Token: 0x0402A76A RID: 173930
		[Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})]
		public static Func<int[], FilterItemData[]> <36>__GetRoleLangCustomData;
	}
}
