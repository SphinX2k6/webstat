using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002054 RID: 8276
[NullableContext(1)]
[Nullable(0)]
public class MainInterfaceData
{
	// Token: 0x0600FC23 RID: 64547 RVA: 0x00454788 File Offset: 0x00452988
	public void InsertItemRewardInfo(AddCountItemInfo[] addCountItemInfo)
	{
		foreach (AddCountItemInfo addCountItemInfo2 in addCountItemInfo)
		{
			ItemConfig itemConfigData = ConfigBase<InventoryConfig>.Instance.GetItemConfigData(addCountItemInfo2.Id);
			if (itemConfigData != null && itemConfigData.ShowInBag)
			{
				ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
				itemRewardInfo.ItemCount = new int?(addCountItemInfo2.Count);
				itemRewardInfo.ItemId = new int?(addCountItemInfo2.Id);
				itemRewardInfo.Quality = itemConfigData.QualityId;
				this.WaitList.Add(itemRewardInfo);
			}
		}
		this.WaitList.Sort((ItemRewardInfo aRewardInfo, ItemRewardInfo bRewardInfo) => bRewardInfo.Quality - aRewardInfo.Quality);
	}

	// Token: 0x0600FC24 RID: 64548 RVA: 0x00454834 File Offset: 0x00452A34
	public void AddItemRewardInfo(ItemRewardInfo addItem)
	{
		if (addItem == null)
		{
			return;
		}
		this.WaitList.Add(addItem);
	}

	// Token: 0x0600FC25 RID: 64549 RVA: 0x00454848 File Offset: 0x00452A48
	public void SortWaitList()
	{
		this.WaitList.RemoveAll((ItemRewardInfo x) => x == null);
		this.WaitList.Sort((ItemRewardInfo aRewardInfo, ItemRewardInfo bRewardInfo) => bRewardInfo.Quality - aRewardInfo.Quality);
	}

	// Token: 0x0600FC26 RID: 64550 RVA: 0x004548AA File Offset: 0x00452AAA
	public void Clear()
	{
	}

	// Token: 0x04007903 RID: 30979
	public List<ItemRewardInfo> WaitList = new List<ItemRewardInfo>();
}
