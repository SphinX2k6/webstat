using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;

// Token: 0x02001FDF RID: 8159
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class InfluenceReputationModel : ModelBase<InfluenceReputationModel>
{
	// Token: 0x0600F63C RID: 63036 RVA: 0x00436984 File Offset: 0x00434B84
	public void SetInfluenceInfoList(OneInfluenceInfo[] infoList)
	{
		foreach (OneInfluenceInfo oneInfluenceInfo in infoList)
		{
			InfluenceInstance influenceInstance;
			if (this.InfluenceInstanceMap.TryGetValue(oneInfluenceInfo.InfluenceId, out influenceInstance))
			{
				influenceInstance.SetRelation((EInfluenceRelation)oneInfluenceInfo.Relation);
				influenceInstance.SetReceiveReward(oneInfluenceInfo.RewardIndex);
			}
			else
			{
				this.InfluenceInstanceMap.Add(oneInfluenceInfo.InfluenceId, new InfluenceInstance(oneInfluenceInfo.InfluenceId, oneInfluenceInfo.RewardIndex, oneInfluenceInfo.Relation));
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RedDotInfluence, oneInfluenceInfo.InfluenceId);
		}
	}

	// Token: 0x0600F63D RID: 63037 RVA: 0x00436A14 File Offset: 0x00434C14
	public bool UpdateInfluenceRewardIndex(int id, int rewardIndex)
	{
		InfluenceInstance influenceInstance;
		if (!this.InfluenceInstanceMap.TryGetValue(id, out influenceInstance))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.InfluenceReputation;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "奖励获取有问题,当前客户端没有该势力数据";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		influenceInstance.SetReceiveReward(rewardIndex);
		return true;
	}

	// Token: 0x0600F63E RID: 63038 RVA: 0x00436A6C File Offset: 0x00434C6C
	[NullableContext(2)]
	public InfluenceInstance GetInfluenceInstance(int id)
	{
		InfluenceInstance result;
		if (this.InfluenceInstanceMap.TryGetValue(id, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600F63F RID: 63039 RVA: 0x00436A8C File Offset: 0x00434C8C
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"IsAllReceived",
		"Reward"
	})]
	public ValueTuple<bool, IntPair>? GetCanReceiveReward(int influenceId)
	{
		if (influenceId == 0)
		{
			return null;
		}
		Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(influenceId);
		InfluenceInstance influenceInstance = this.GetInfluenceInstance(influenceId);
		if (influenceInstance == null || influenceConfig == null)
		{
			return null;
		}
		IntPair[] array = influenceConfig.Value.ReputationReward();
		if (array.Length == influenceInstance.RewardIndex + 1)
		{
			return new ValueTuple<bool, IntPair>?(new ValueTuple<bool, IntPair>(true, array[influenceInstance.RewardIndex]));
		}
		return new ValueTuple<bool, IntPair>?(new ValueTuple<bool, IntPair>(false, array[influenceInstance.RewardIndex + 1]));
	}

	// Token: 0x0600F640 RID: 63040 RVA: 0x00436B20 File Offset: 0x00434D20
	[return: Nullable(new byte[]
	{
		1,
		0
	})]
	public List<ValueTuple<int, int>> GetRewardList(int dropId)
	{
		DropPackage? dropPackage = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackage(dropId);
		List<ValueTuple<int, int>> list = new List<ValueTuple<int, int>>();
		if (dropPackage != null)
		{
			foreach (KeyValuePair<int, int> keyValuePair in dropPackage.Value.DropPreview())
			{
				list.Add(new ValueTuple<int, int>(keyValuePair.Key, keyValuePair.Value));
			}
		}
		return list;
	}

	// Token: 0x0600F641 RID: 63041 RVA: 0x00436BAC File Offset: 0x00434DAC
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"Current",
		"Max"
	})]
	public ValueTuple<int, int> GetReputationProgress(int influenceId)
	{
		int num = 0;
		int num2 = 0;
		Influence? influenceConfig = ConfigBase<InfluenceConfig>.Instance.GetInfluenceConfig(influenceId);
		if (influenceConfig != null)
		{
			foreach (IntPair intPair in influenceConfig.Value.ReputationItem())
			{
				num += intPair.Item2;
				int itemCountByConfigId = ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(intPair.Item1, 0);
				num2 += Singleton<MathUtils>.Instance.Clamp(itemCountByConfigId, 0, intPair.Item2);
			}
		}
		return new ValueTuple<int, int>(num2, num);
	}

	// Token: 0x0600F642 RID: 63042 RVA: 0x00436C3C File Offset: 0x00434E3C
	public void SetUnLockCountry(int[] unlockCountryList)
	{
		int i = 0;
		int num = unlockCountryList.Length;
		while (i < num)
		{
			this.CountrySet.Add(unlockCountryList[i]);
			i++;
		}
	}

	// Token: 0x0600F643 RID: 63043 RVA: 0x00436C68 File Offset: 0x00434E68
	public int[] GetUnLockCountry()
	{
		int[] array = new int[this.CountrySet.Count];
		this.CountrySet.CopyTo(array);
		return array;
	}

	// Token: 0x0600F644 RID: 63044 RVA: 0x00436C93 File Offset: 0x00434E93
	public bool IsCountryUnLock(int countryId)
	{
		return this.CountrySet.Contains(countryId);
	}

	// Token: 0x0600F645 RID: 63045 RVA: 0x00436CA4 File Offset: 0x00434EA4
	public List<int> FilterUnLockInfluence(int[] influenceList, string filterText)
	{
		List<int> list = new List<int>();
		int i = 0;
		int num = influenceList.Length;
		while (i < num)
		{
			int num2 = influenceList[i];
			if (num2 != 0 && this.InfluenceInstanceMap.ContainsKey(num2))
			{
				string influenceTitle = ConfigBase<InfluenceConfig>.Instance.GetInfluenceTitle(num2);
				if (new Regex(filterText, RegexOptions.IgnoreCase).Match(influenceTitle).Index >= 0)
				{
					list.Add(num2);
				}
			}
			i++;
		}
		return list;
	}

	// Token: 0x0600F646 RID: 63046 RVA: 0x00436D08 File Offset: 0x00434F08
	public InfluenceSearchData FilterUnLockInfluenceList(int[] countryIdList, string filterText)
	{
		InfluenceSearchData influenceSearchData = new InfluenceSearchData
		{
			HasResult = false,
			InfluenceList = new List<ValueTuple<int, List<int>>>()
		};
		foreach (int num in countryIdList)
		{
			if (num != 0)
			{
				Country? countryConfig = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(num);
				if (countryConfig != null)
				{
					List<int> list = this.FilterUnLockInfluence(countryConfig.Value.Influences(), filterText);
					influenceSearchData.InfluenceList.Add(new ValueTuple<int, List<int>>(num, list));
					influenceSearchData.HasResult = (influenceSearchData.HasResult || list.Count > 0);
				}
			}
		}
		return influenceSearchData;
	}

	// Token: 0x0600F647 RID: 63047 RVA: 0x00436DB0 File Offset: 0x00434FB0
	public bool RedDotInfluenceRewardCondition(int influenceId)
	{
		ValueTuple<bool, IntPair>? canReceiveReward = this.GetCanReceiveReward(influenceId);
		return canReceiveReward != null && !canReceiveReward.Value.Item1 && this.GetReputationProgress(influenceId).Item1 >= canReceiveReward.Value.Item2.Item1;
	}

	// Token: 0x0600F648 RID: 63048 RVA: 0x00436E08 File Offset: 0x00435008
	public bool HasRedDotExcludeCurrentCountry(int currentCountryId)
	{
		foreach (int num in this.CountrySet)
		{
			if (num != currentCountryId && this.HasRedDotInCurrentCountry(num))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600F649 RID: 63049 RVA: 0x00436E68 File Offset: 0x00435068
	public bool HasRedDotInCurrentCountry(int countryId)
	{
		Country? countryConfig = ConfigBase<InfluenceConfig>.Instance.GetCountryConfig(countryId);
		if (countryConfig != null)
		{
			foreach (int influenceId in countryConfig.Value.Influences())
			{
				if (this.RedDotInfluenceRewardCondition(influenceId))
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x0400770D RID: 30477
	private readonly Dictionary<int, InfluenceInstance> InfluenceInstanceMap = new Dictionary<int, InfluenceInstance>();

	// Token: 0x0400770E RID: 30478
	private readonly HashSet<int> CountrySet = new HashSet<int>();
}
