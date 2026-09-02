using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02002382 RID: 9090
[NullableContext(1)]
[Nullable(0)]
public class BattlePassRewardData
{
	// Token: 0x060116BF RID: 71359 RVA: 0x004CD44B File Offset: 0x004CB64B
	public BattlePassRewardData(int? level)
	{
		this.Level = level;
	}

	// Token: 0x060116C0 RID: 71360 RVA: 0x004CD47C File Offset: 0x004CB67C
	public bool IsThisType(EBattlePassItemType type)
	{
		foreach (BattlePassRewardItem battlePassRewardItem in this.FreeRewardItem)
		{
			EBattlePassItemType? itemType = battlePassRewardItem.ItemType;
			if (itemType.GetValueOrDefault() == type & itemType != null)
			{
				return true;
			}
		}
		foreach (BattlePassRewardItem battlePassRewardItem2 in this.PayRewardItem)
		{
			EBattlePassItemType? itemType = battlePassRewardItem2.ItemType;
			if (itemType.GetValueOrDefault() == type & itemType != null)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060116C1 RID: 71361 RVA: 0x004CD544 File Offset: 0x004CB744
	public int GetItemCount(BattlePassType type, int itemId)
	{
		if (type == BattlePassType.Free)
		{
			return this.GetFreeRewardItem(itemId).Item.Value.Count;
		}
		return this.GetPayRewardItem(itemId).Item.Value.Count;
	}

	// Token: 0x060116C2 RID: 71362 RVA: 0x004CD578 File Offset: 0x004CB778
	[NullableContext(2)]
	public BattlePassRewardItem GetFreeRewardItem(int itemId)
	{
		foreach (BattlePassRewardItem battlePassRewardItem in this.FreeRewardItem)
		{
			if (battlePassRewardItem.Item.Value.ItemData.ItemId == itemId)
			{
				return battlePassRewardItem;
			}
		}
		return null;
	}

	// Token: 0x060116C3 RID: 71363 RVA: 0x004CD5E4 File Offset: 0x004CB7E4
	[NullableContext(2)]
	public BattlePassRewardItem GetPayRewardItem(int itemId)
	{
		foreach (BattlePassRewardItem battlePassRewardItem in this.PayRewardItem)
		{
			if (battlePassRewardItem.Item.Value.ItemData.ItemId == itemId)
			{
				return battlePassRewardItem;
			}
		}
		return null;
	}

	// Token: 0x040088C1 RID: 35009
	public List<BattlePassRewardItem> FreeRewardItem = new List<BattlePassRewardItem>();

	// Token: 0x040088C2 RID: 35010
	public List<BattlePassRewardItem> PayRewardItem = new List<BattlePassRewardItem>();

	// Token: 0x040088C3 RID: 35011
	public int? Level = new int?(0);
}
