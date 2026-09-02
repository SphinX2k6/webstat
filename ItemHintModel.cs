using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Module.Inventory;

// Token: 0x02002059 RID: 8281
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class ItemHintModel : ModelBase<ItemHintModel>
{
	// Token: 0x1700129D RID: 4765
	// (get) Token: 0x0600FC39 RID: 64569 RVA: 0x00454CA7 File Offset: 0x00452EA7
	// (set) Token: 0x0600FC3A RID: 64570 RVA: 0x00454CAF File Offset: 0x00452EAF
	public bool Visibility
	{
		get
		{
			return this.VisibilityInternal;
		}
		set
		{
			this.VisibilityInternal = value;
		}
	}

	// Token: 0x0600FC3B RID: 64571 RVA: 0x00454CB8 File Offset: 0x00452EB8
	protected override bool OnInit()
	{
		this.VisibilityInternal = true;
		return true;
	}

	// Token: 0x0600FC3C RID: 64572 RVA: 0x00454CC2 File Offset: 0x00452EC2
	protected override bool OnClear()
	{
		this.MainInterfaceData.Clear();
		this.PriorInterfaceData.Clear();
		this.ItemRewardDataArray = new List<ItemRewardData>();
		return true;
	}

	// Token: 0x0600FC3D RID: 64573 RVA: 0x00454CE8 File Offset: 0x00452EE8
	public void AddItemRewardList(ItemRewardNotify itemRewardInfo)
	{
		ItemRewardData itemRewardData = new ItemRewardData();
		itemRewardData.ItemReward = itemRewardInfo;
		this.ItemRewardDataArray.Add(itemRewardData);
	}

	// Token: 0x0600FC3E RID: 64574 RVA: 0x00454D10 File Offset: 0x00452F10
	public void AddAchievementItemRewardList(ItemRewardNotify itemRewardInfo)
	{
		ItemRewardData itemRewardData = new ItemRewardData();
		itemRewardData.ItemReward = itemRewardInfo;
		this.AchievementItemRewardDataArray.Add(itemRewardData);
	}

	// Token: 0x0600FC3F RID: 64575 RVA: 0x00454D38 File Offset: 0x00452F38
	public void AddItemRewardTest()
	{
		ItemRewardNotify itemRewardNotify = ItemRewardNotify.Create();
		RewardItemInfo rewardItemInfo = RewardItemInfo.Create();
		rewardItemInfo.Count = 1;
		rewardItemInfo.ItemId = 21010014;
		rewardItemInfo.ShowPlanId = 3;
		RewardItemInfoList rewardItemInfoList = new RewardItemInfoList();
		rewardItemInfoList.ItemList.Add(rewardItemInfo);
		itemRewardNotify.RewardItems.Add(0, rewardItemInfoList);
		ItemRewardData itemRewardData = new ItemRewardData();
		itemRewardData.ItemReward = itemRewardNotify;
		this.ItemRewardDataArray.Add(itemRewardData);
	}

	// Token: 0x0600FC40 RID: 64576 RVA: 0x00454DA2 File Offset: 0x00452FA2
	[NullableContext(2)]
	public ItemRewardData ShiftItemRewardListFirst()
	{
		if (this.ItemRewardDataArray.Count > 0)
		{
			ItemRewardData result = this.ItemRewardDataArray[0];
			this.ItemRewardDataArray.RemoveAt(0);
			return result;
		}
		return null;
	}

	// Token: 0x0600FC41 RID: 64577 RVA: 0x00454DCC File Offset: 0x00452FCC
	[NullableContext(2)]
	public ItemRewardData ShiftAchievementItemRewardListFirst()
	{
		if (this.AchievementItemRewardDataArray.Count > 0)
		{
			ItemRewardData result = this.AchievementItemRewardDataArray[0];
			this.AchievementItemRewardDataArray.RemoveAt(0);
			return result;
		}
		return null;
	}

	// Token: 0x0600FC42 RID: 64578 RVA: 0x00454DF6 File Offset: 0x00452FF6
	public ItemRewardData PeekItemRewardListFirst()
	{
		return this.ItemRewardDataArray[0];
	}

	// Token: 0x0600FC43 RID: 64579 RVA: 0x00454E04 File Offset: 0x00453004
	public void CleanItemRewardList()
	{
		this.ItemRewardDataArray = new List<ItemRewardData>();
	}

	// Token: 0x1700129E RID: 4766
	// (get) Token: 0x0600FC44 RID: 64580 RVA: 0x00454E11 File Offset: 0x00453011
	public bool IsItemRewardListEmpty
	{
		get
		{
			return this.ItemRewardDataArray.Count <= 0;
		}
	}

	// Token: 0x1700129F RID: 4767
	// (get) Token: 0x0600FC45 RID: 64581 RVA: 0x00454E24 File Offset: 0x00453024
	public bool IsAchievementItemRewardListEmpty
	{
		get
		{
			return this.AchievementItemRewardDataArray.Count <= 0;
		}
	}

	// Token: 0x0600FC46 RID: 64582 RVA: 0x00454E38 File Offset: 0x00453038
	public void MainInterfaceInsertItemRewardInfo(AddCountItemInfo[] addCountItemInfo)
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
				if (itemConfigData.ItemType.GetValueOrDefault() == InventoryDefine.EItemType.Phantom)
				{
					this.PriorInterfaceData.AddItemRewardInfo(itemRewardInfo);
				}
				else if (itemRewardInfo.Quality >= 4)
				{
					this.PriorInterfaceData.AddItemRewardInfo(itemRewardInfo);
				}
				else
				{
					this.MainInterfaceData.AddItemRewardInfo(itemRewardInfo);
				}
			}
		}
		this.MainInterfaceData.SortWaitList();
		this.PriorInterfaceData.SortWaitList();
	}

	// Token: 0x0600FC47 RID: 64583 RVA: 0x00454F10 File Offset: 0x00453110
	public void AddItemToPriorInterfaceData(int itemId, int count, int qualityId)
	{
		ItemRewardInfo itemRewardInfo = new ItemRewardInfo();
		itemRewardInfo.ItemId = new int?(itemId);
		itemRewardInfo.ItemCount = new int?(count);
		itemRewardInfo.Quality = qualityId;
		this.PriorInterfaceData.AddItemRewardInfo(itemRewardInfo);
	}

	// Token: 0x170012A0 RID: 4768
	// (get) Token: 0x0600FC48 RID: 64584 RVA: 0x00454F4E File Offset: 0x0045314E
	public bool IsMainInterfaceDataEmpty
	{
		get
		{
			return this.MainInterfaceData.WaitList.Count <= 0;
		}
	}

	// Token: 0x170012A1 RID: 4769
	// (get) Token: 0x0600FC49 RID: 64585 RVA: 0x00454F66 File Offset: 0x00453166
	public bool IsPriorInterfaceDataEmpty
	{
		get
		{
			return this.PriorInterfaceData.WaitList.Count <= 0;
		}
	}

	// Token: 0x0600FC4A RID: 64586 RVA: 0x00454F7E File Offset: 0x0045317E
	[NullableContext(2)]
	public ItemRewardInfo ShiftMainInterfaceData()
	{
		if (this.MainInterfaceData.WaitList.Count > 0)
		{
			ItemRewardInfo result = this.MainInterfaceData.WaitList[0];
			this.MainInterfaceData.WaitList.RemoveAt(0);
			return result;
		}
		return null;
	}

	// Token: 0x0600FC4B RID: 64587 RVA: 0x00454FB7 File Offset: 0x004531B7
	[NullableContext(2)]
	public ItemRewardInfo ShiftPriorInterfaceData()
	{
		if (this.PriorInterfaceData.WaitList.Count > 0)
		{
			ItemRewardInfo result = this.PriorInterfaceData.WaitList[0];
			this.PriorInterfaceData.WaitList.RemoveAt(0);
			return result;
		}
		return null;
	}

	// Token: 0x0600FC4C RID: 64588 RVA: 0x00454FF0 File Offset: 0x004531F0
	public void GmClear()
	{
		this.MainInterfaceData.WaitList.Clear();
		this.PriorInterfaceData.WaitList.Clear();
		this.CleanItemRewardList();
		this.AchievementItemRewardDataArray.Clear();
	}

	// Token: 0x0400790E RID: 30990
	private const int HIGH_QUALITY = 4;

	// Token: 0x0400790F RID: 30991
	private readonly MainInterfaceData MainInterfaceData = new MainInterfaceData();

	// Token: 0x04007910 RID: 30992
	private readonly MainInterfaceData PriorInterfaceData = new MainInterfaceData();

	// Token: 0x04007911 RID: 30993
	private List<ItemRewardData> ItemRewardDataArray = new List<ItemRewardData>();

	// Token: 0x04007912 RID: 30994
	private readonly List<ItemRewardData> AchievementItemRewardDataArray = new List<ItemRewardData>();

	// Token: 0x04007913 RID: 30995
	private bool VisibilityInternal;
}
