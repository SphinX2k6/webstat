using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using Google.Protobuf.Collections;

// Token: 0x02002846 RID: 10310
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class RoleFavorConditionModel : ModelBase<RoleFavorConditionModel>
{
	// Token: 0x06014748 RID: 83784 RVA: 0x005AE3C0 File Offset: 0x005AC5C0
	public void UpdateRoleFavorCondition(int roleId, ConditionInfo conditionInfo)
	{
		Dictionary<EFavorContentType, Dictionary<int, List<int>>> dictionary;
		if (!this.RoleFavorConditionMap.TryGetValue(roleId, out dictionary))
		{
			dictionary = new Dictionary<EFavorContentType, Dictionary<int, List<int>>>();
		}
		foreach (KeyValuePair<int, ConditionItem> keyValuePair in conditionInfo.FinishConditionMap)
		{
			EFavorContentType key = (EFavorContentType)keyValuePair.Key;
			MapField<int, ItemFinishList> itemFinishMap = keyValuePair.Value.ItemFinishMap;
			Dictionary<int, List<int>> dictionary2;
			if (!dictionary.TryGetValue(key, out dictionary2))
			{
				dictionary2 = new Dictionary<int, List<int>>();
			}
			foreach (KeyValuePair<int, ItemFinishList> keyValuePair2 in itemFinishMap)
			{
				int key2 = keyValuePair2.Key;
				RepeatedField<int> conditionIdList = keyValuePair2.Value.ConditionIdList;
				List<int> list;
				if (!dictionary2.TryGetValue(key2, out list))
				{
					list = new List<int>();
				}
				int count = conditionIdList.Count;
				for (int i = 0; i < count; i++)
				{
					int item = conditionIdList[i];
					list.Add(item);
				}
				dictionary2[key2] = list;
			}
			dictionary[key] = dictionary2;
		}
		this.RoleFavorConditionMap[roleId] = dictionary;
	}

	// Token: 0x06014749 RID: 83785 RVA: 0x005AE4F8 File Offset: 0x005AC6F8
	public bool IsConditionFinish(int roleId, EFavorContentType type, int id, int conditionId)
	{
		Dictionary<EFavorContentType, Dictionary<int, List<int>>> dictionary;
		if (!this.RoleFavorConditionMap.TryGetValue(roleId, out dictionary))
		{
			return false;
		}
		Dictionary<int, List<int>> dictionary2;
		if (!dictionary.TryGetValue(type, out dictionary2))
		{
			return false;
		}
		List<int> list;
		if (!dictionary2.TryGetValue(id, out list))
		{
			return false;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i] == conditionId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x04009E25 RID: 40485
	private readonly Dictionary<int, Dictionary<EFavorContentType, Dictionary<int, List<int>>>> RoleFavorConditionMap = new Dictionary<int, Dictionary<EFavorContentType, Dictionary<int, List<int>>>>();
}
