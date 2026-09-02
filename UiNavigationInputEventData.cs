using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002CC5 RID: 11461
[NullableContext(1)]
[Nullable(0)]
public class UiNavigationInputEventData : IStaticVariableResetter
{
	// Token: 0x060170E7 RID: 94439 RVA: 0x0066303D File Offset: 0x0066123D
	static UiNavigationInputEventData()
	{
		StaticVariableRegister.RegisterAndExecute(new Action(UiNavigationInputEventData.CreateStaticDefaultValue), new Action(UiNavigationInputEventData.ResetStaticDefaultValue));
	}

	// Token: 0x060170E8 RID: 94440 RVA: 0x0066305C File Offset: 0x0066125C
	public static void CreateStaticDefaultValue()
	{
		UiNavigationInputEventData.CurrentMaxEventId = 999;
		UiNavigationInputEventData.EmptyEventIdList = new List<int>();
		UiNavigationInputEventData.InUseInputEventDataMap = new Dictionary<int, Dictionary<TsUiNavigationBehaviorListener, int>>();
	}

	// Token: 0x060170E9 RID: 94441 RVA: 0x0066307C File Offset: 0x0066127C
	public static void ResetStaticDefaultValue()
	{
		UiNavigationInputEventData.CurrentMaxEventId = 999;
		UiNavigationInputEventData.EmptyEventIdList = null;
		UiNavigationInputEventData.InUseInputEventDataMap = null;
	}

	// Token: 0x060170EA RID: 94442 RVA: 0x00663094 File Offset: 0x00661294
	public static int ActivateInputEventDataOnce()
	{
		return UiNavigationInputEventData.CurrentMaxEventId;
	}

	// Token: 0x060170EB RID: 94443 RVA: 0x0066309C File Offset: 0x0066129C
	public static int CreateInputEventData(int configId, TsUiNavigationBehaviorListener listener)
	{
		Dictionary<TsUiNavigationBehaviorListener, int> dictionary;
		if (!UiNavigationInputEventData.InUseInputEventDataMap.TryGetValue(configId, out dictionary))
		{
			dictionary = new Dictionary<TsUiNavigationBehaviorListener, int>();
			UiNavigationInputEventData.InUseInputEventDataMap[configId] = dictionary;
		}
		int num;
		if (dictionary.TryGetValue(listener, out num))
		{
			return num;
		}
		if (UiNavigationInputEventData.EmptyEventIdList.Count > 0)
		{
			num = UiNavigationInputEventData.EmptyEventIdList[0];
			UiNavigationInputEventData.EmptyEventIdList.RemoveAt(0);
			dictionary[listener] = num;
		}
		else
		{
			num = UiNavigationInputEventData.CurrentMaxEventId++;
			dictionary[listener] = num;
		}
		return num;
	}

	// Token: 0x060170EC RID: 94444 RVA: 0x0066311C File Offset: 0x0066131C
	public static int RecycleInputEventData(int configId, TsUiNavigationBehaviorListener listener)
	{
		Dictionary<TsUiNavigationBehaviorListener, int> dictionary;
		if (!UiNavigationInputEventData.InUseInputEventDataMap.TryGetValue(configId, out dictionary) || !dictionary.ContainsKey(listener))
		{
			return 999;
		}
		int num;
		if (dictionary.TryGetValue(listener, out num))
		{
			dictionary.Remove(listener);
			UiNavigationInputEventData.EmptyEventIdList.Add(num);
			return num;
		}
		return 999;
	}

	// Token: 0x060170ED RID: 94445 RVA: 0x0066316C File Offset: 0x0066136C
	public static List<int> TryClearUnValidData()
	{
		List<int> list = new List<int>();
		foreach (KeyValuePair<int, Dictionary<TsUiNavigationBehaviorListener, int>> keyValuePair in UiNavigationInputEventData.InUseInputEventDataMap)
		{
			Dictionary<TsUiNavigationBehaviorListener, int> value = keyValuePair.Value;
			List<ValueTuple<TsUiNavigationBehaviorListener, int>> list2 = new List<ValueTuple<TsUiNavigationBehaviorListener, int>>();
			foreach (KeyValuePair<TsUiNavigationBehaviorListener, int> keyValuePair2 in value)
			{
				TsUiNavigationBehaviorListener key = keyValuePair2.Key;
				int value2 = keyValuePair2.Value;
				if (!key.IsValid() || !key.GetNavigationComponent().IsActive())
				{
					list2.Add(new ValueTuple<TsUiNavigationBehaviorListener, int>(key, value2));
				}
			}
			foreach (ValueTuple<TsUiNavigationBehaviorListener, int> valueTuple in list2)
			{
				value.Remove(valueTuple.Item1);
				UiNavigationInputEventData.EmptyEventIdList.Add(valueTuple.Item2);
				list.Add(valueTuple.Item2);
			}
		}
		return list;
	}

	// Token: 0x0400B1A1 RID: 45473
	protected static int CurrentMaxEventId;

	// Token: 0x0400B1A2 RID: 45474
	protected static List<int> EmptyEventIdList;

	// Token: 0x0400B1A3 RID: 45475
	protected static Dictionary<int, Dictionary<TsUiNavigationBehaviorListener, int>> InUseInputEventDataMap;
}
