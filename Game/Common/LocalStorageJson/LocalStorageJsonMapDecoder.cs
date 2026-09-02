using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.Json;
using FilterDefine;

namespace CSharpScript.Game.Common.LocalStorageJson
{
	// Token: 0x0200706B RID: 28779
	[NullableContext(1)]
	[Nullable(0)]
	internal static class LocalStorageJsonMapDecoder
	{
		// Token: 0x06045AD9 RID: 285401 RVA: 0x01235F68 File Offset: 0x01234168
		public static bool TryDecode<[Nullable(2)] T>(JsonElement contentArray, Type targetType, JsonSerializerOptions keyOptions, JsonSerializerOptions valueOptions, [Nullable(2)] out T result)
		{
			if (targetType == typeof(Dictionary<EFunction, int>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<EFunction, int>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<FilterDefine.EFilterType, List<int>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<FilterDefine.EFilterType, List<int>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, bool>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, bool>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, double>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, double>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, float>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, float>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, float[]>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, float[]>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, AbyssDangoOwnerData>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, AbyssDangoOwnerData>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, AreaExplorePlayState>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, AreaExplorePlayState>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, LocalFriendApplication>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, LocalFriendApplication>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, Dictionary<int, double>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, Dictionary<int, double>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, Dictionary<int, AbyssDangoOwnerData>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, Dictionary<int, AbyssDangoOwnerData>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, Dictionary<int, AreaExplorePlayState>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, Dictionary<int, AreaExplorePlayState>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, Dictionary<int, HashSet<int>>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, Dictionary<int, HashSet<int>>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, HashSet<int>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, HashSet<int>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, List<int>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, List<int>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, int>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, int>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, int[]>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, int[]>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, long>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, long>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<int, string>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<int, string>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, bool>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, bool>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, FilterStorageData>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, FilterStorageData>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, GamepadTypeUsage>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, GamepadTypeUsage>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, LocalPlayerIpLevelData[]>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, LocalPlayerIpLevelData[]>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, MarqueeStorageData>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, MarqueeStorageData>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, RegionAndIpSt>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, RegionAndIpSt>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, SortStorageData>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, SortStorageData>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, IList<IList<string>>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, IList<IList<string>>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, List<ActivityCacheData>>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, List<ActivityCacheData>>(contentArray, keyOptions, valueOptions));
				return true;
			}
			if (targetType == typeof(Dictionary<string, int>))
			{
				result = (T)((object)LocalStorageJsonMapDecoder.DecodeDictionary<string, int>(contentArray, keyOptions, valueOptions));
				return true;
			}
			result = default(T);
			return false;
		}

		// Token: 0x06045ADA RID: 285402 RVA: 0x01236408 File Offset: 0x01234608
		private static Dictionary<TKey, TValue> DecodeDictionary<TKey, [Nullable(2)] TValue>(JsonElement contentArray, JsonSerializerOptions keyOptions, JsonSerializerOptions valueOptions)
		{
			Dictionary<TKey, TValue> dictionary = new Dictionary<TKey, TValue>();
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
					TKey tkey = enumerator2.Current.Deserialize(keyOptions);
					if (!enumerator2.MoveNext())
					{
						throw new JsonException("Map.Content 元素缺少 value");
					}
					TValue value = enumerator2.Current.Deserialize(valueOptions);
					if (tkey != null)
					{
						dictionary[tkey] = value;
					}
				}
			}
			return dictionary;
		}
	}
}
