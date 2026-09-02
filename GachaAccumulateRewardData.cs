using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.ItemReward;

// Token: 0x02001CBB RID: 7355
[NullableContext(1)]
[Nullable(0)]
public class GachaAccumulateRewardData
{
	// Token: 0x0600D7D7 RID: 55255 RVA: 0x0039B50C File Offset: 0x0039970C
	public RewardItemData[] GetRewardItemList()
	{
		List<RewardItemData> list = new List<RewardItemData>();
		foreach (KeyValuePair<int, int> keyValuePair in this.RewardContent)
		{
			list.Add(new RewardItemData(keyValuePair.Key, keyValuePair.Value, null, EDropItemType.Normal));
		}
		return list.ToArray();
	}

	// Token: 0x0600D7D8 RID: 55256 RVA: 0x0039B588 File Offset: 0x00399788
	public bool GetIfResonantGift()
	{
		foreach (KeyValuePair<int, int> keyValuePair in this.RewardContent)
		{
			ItemInfo? itemConfig = ConfigBase<InventoryConfig>.Instance.GetItemConfig(keyValuePair.Key);
			if (itemConfig != null && itemConfig.GetValueOrDefault().ItemType == 11)
			{
				int num2;
				int num = itemConfig.Value.Parameters().TryGetValue(2, out num2) ? num2 : 0;
				if (num != 0)
				{
					GiftPackage? giftPackageConfig = ConfigBase<GiftPackageConfig>.Instance.GetGiftPackageConfig(num);
					if (giftPackageConfig != null && giftPackageConfig.GetValueOrDefault().Type == GiftType.ResonantChainOptional)
					{
						return true;
					}
				}
			}
		}
		return false;
	}

	// Token: 0x0600D7D9 RID: 55257 RVA: 0x0039B66C File Offset: 0x0039986C
	public bool GetIfCyclic()
	{
		return this.CycleCount != 0;
	}

	// Token: 0x0600D7DA RID: 55258 RVA: 0x0039B678 File Offset: 0x00399878
	public int GetCyclicPendingClaimCount(int currentGachaNum, int baseGachaNum)
	{
		if (!this.GetIfCyclic())
		{
			return 0;
		}
		if (this.GachaNum <= 0)
		{
			return 0;
		}
		int num = baseGachaNum + this.GachaNum;
		if (currentGachaNum < num)
		{
			return 0;
		}
		int val = (int)Math.Floor((double)(currentGachaNum - baseGachaNum) / (double)this.GachaNum);
		int val2 = (this.CycleCount == -1) ? int.MaxValue : this.CycleCount;
		int num2 = Math.Min(val, val2) - this.CycleRewardedTimes;
		if (num2 <= 0)
		{
			return 0;
		}
		return num2;
	}

	// Token: 0x040066C1 RID: 26305
	public int Id;

	// Token: 0x040066C2 RID: 26306
	public int GroupId;

	// Token: 0x040066C3 RID: 26307
	public int GachaNum;

	// Token: 0x040066C4 RID: 26308
	public readonly Dictionary<int, int> RewardContent = new Dictionary<int, int>();

	// Token: 0x040066C5 RID: 26309
	public EGachaAccumulateRewardStatus Status;

	// Token: 0x040066C6 RID: 26310
	public bool IsBigReward;

	// Token: 0x040066C7 RID: 26311
	public int CycleCount;

	// Token: 0x040066C8 RID: 26312
	public int CycleRewardedTimes;

	// Token: 0x040066C9 RID: 26313
	public bool IsPreView;
}
