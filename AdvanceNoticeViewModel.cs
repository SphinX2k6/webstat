using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x0200119E RID: 4510
[NullableContext(1)]
[Nullable(0)]
public class AdvanceNoticeViewModel
{
	// Token: 0x170009FE RID: 2558
	// (get) Token: 0x060076A3 RID: 30371 RVA: 0x001F0D3F File Offset: 0x001EEF3F
	public int TabId
	{
		get
		{
			return this.TabList[this.TabIndex];
		}
	}

	// Token: 0x170009FF RID: 2559
	// (get) Token: 0x060076A4 RID: 30372 RVA: 0x001F0D52 File Offset: 0x001EEF52
	public int CurrentSubTabId
	{
		get
		{
			return this.AdvanceNoticeThumbItemDataList[this.CurrentSubTabIndex].SubTabId;
		}
	}

	// Token: 0x060076A5 RID: 30373 RVA: 0x001F0D6C File Offset: 0x001EEF6C
	public void UpdateTabDataOnTabChange(int tabIndex)
	{
		this.TabIndex = tabIndex;
		int id = this.TabList[tabIndex];
		AdvertisingTabInfo advertisingTabInfoById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabInfoById(id);
		this.SubTabIdList.Clear();
		foreach (int item in advertisingTabInfoById.SubTabIdListIter())
		{
			this.SubTabIdList.Add(item);
		}
		this.CurrentSubTabIndex = 0;
		this.AdvanceNoticeThumbItemDataList.Clear();
		this.AdvanceNoticeThumbEnemyMap.Clear();
		this.CurrentTabView = AdvanceNoticeDefine.advanceNoticeTabTypeToTabViewName[(EAdvanceNoticeTabType)advertisingTabInfoById.Type];
		foreach (int subTabId in advertisingTabInfoById.SubTabIdListIter())
		{
			AdvanceNoticeThumbItemData item2 = this.BuildAdvanceNoticeThumbItemData((EAdvanceNoticeTabType)advertisingTabInfoById.Type, subTabId);
			this.AdvanceNoticeThumbItemDataList.Add(item2);
		}
		this.SetEnemyShowLineData();
	}

	// Token: 0x060076A6 RID: 30374 RVA: 0x001F0E7C File Offset: 0x001EF07C
	private AdvanceNoticeThumbItemData BuildAdvanceNoticeThumbItemData(EAdvanceNoticeTabType tabType, int subTabId)
	{
		AdvanceNoticeThumbItemData advanceNoticeThumbItemData = new AdvanceNoticeThumbItemData();
		switch (tabType)
		{
		case EAdvanceNoticeTabType.NewRole:
		{
			AdvertisingTabCharacter advertisingTabCharacterById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabCharacterById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabCharacterById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabCharacterById.ThumbnailText;
			break;
		}
		case EAdvanceNoticeTabType.NewJourney:
		{
			AdvertisingTabStory advertisingTabStoryById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabStoryById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabStoryById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabStoryById.ThumbnailText;
			break;
		}
		case EAdvanceNoticeTabType.NewArea:
		{
			AdvertisingTabRegion advertisingTabRegionById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabRegionById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabRegionById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabRegionById.ThumbnailText;
			break;
		}
		case EAdvanceNoticeTabType.NewSkin:
		{
			AdvertisingTabCostume advertisingTabCostumeById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabCostumeById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabCostumeById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabCostumeById.ThumbnailText;
			break;
		}
		case EAdvanceNoticeTabType.NewEnemy:
		{
			AdvertisingTabEnemy advertisingTabEnemyById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabEnemyById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabEnemyById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabEnemyById.ThumbnailText;
			this.AdvanceNoticeThumbEnemyMap[advertisingTabEnemyById.Type] = advanceNoticeThumbItemData;
			break;
		}
		case EAdvanceNoticeTabType.NewActivity:
		{
			AdvertisingTabActivity advertisingTabActivityById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabActivityById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabActivityById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabActivityById.ThumbnailText;
			break;
		}
		case EAdvanceNoticeTabType.NewSystemOptimize:
		{
			AdvertisingTabSystem advertisingTabSystemById = ConfigBase<AdvanceNoticeConfig>.Instance.GetAdvertisingTabSystemById(subTabId);
			advanceNoticeThumbItemData.BgTexturePath = advertisingTabSystemById.ThumbnailPic;
			advanceNoticeThumbItemData.NameTextId = advertisingTabSystemById.ThumbnailText;
			break;
		}
		}
		advanceNoticeThumbItemData.TabId = this.TabId;
		advanceNoticeThumbItemData.SubTabId = subTabId;
		return advanceNoticeThumbItemData;
	}

	// Token: 0x060076A7 RID: 30375 RVA: 0x001F1008 File Offset: 0x001EF208
	private void SetEnemyShowLineData()
	{
		int num = 0;
		int count = this.AdvanceNoticeThumbEnemyMap.Count;
		foreach (KeyValuePair<int, AdvanceNoticeThumbItemData> keyValuePair in this.AdvanceNoticeThumbEnemyMap)
		{
			num++;
			if (num == count)
			{
				break;
			}
			keyValuePair.Value.ShowLine = true;
		}
	}

	// Token: 0x060076A8 RID: 30376 RVA: 0x001F107C File Offset: 0x001EF27C
	public void OnSwitchSubTab(int subTabIndex)
	{
		this.CurrentSubTabIndex = subTabIndex;
		Action<int> onSwitchSubTabDelegate = this.OnSwitchSubTabDelegate;
		if (onSwitchSubTabDelegate == null)
		{
			return;
		}
		onSwitchSubTabDelegate(subTabIndex);
	}

	// Token: 0x060076A9 RID: 30377 RVA: 0x001F1098 File Offset: 0x001EF298
	public void ClickTabLogEvent()
	{
		NextVersionContentLogEvent nextVersionContentLogEvent = new NextVersionContentLogEvent();
		nextVersionContentLogEvent.i_activity_id = this.ActivityId;
		nextVersionContentLogEvent.i_second_tab = this.TabId;
		nextVersionContentLogEvent.i_third_tab = this.CurrentSubTabId;
		ControllerBase<LogReportController>.Instance.LogReport(nextVersionContentLogEvent);
	}

	// Token: 0x04003961 RID: 14689
	public int DefaultSelectedTabId;

	// Token: 0x04003962 RID: 14690
	public int TabIndex;

	// Token: 0x04003963 RID: 14691
	public int CurrentSubTabIndex;

	// Token: 0x04003964 RID: 14692
	public List<int> TabList = new List<int>();

	// Token: 0x04003965 RID: 14693
	public List<int> SubTabIdList = new List<int>();

	// Token: 0x04003966 RID: 14694
	public EUiTabViewName CurrentTabView = EUiTabViewName.AdvanceNoticeNewRoleTabView;

	// Token: 0x04003967 RID: 14695
	public List<AdvanceNoticeThumbItemData> AdvanceNoticeThumbItemDataList = new List<AdvanceNoticeThumbItemData>();

	// Token: 0x04003968 RID: 14696
	private readonly Dictionary<int, AdvanceNoticeThumbItemData> AdvanceNoticeThumbEnemyMap = new Dictionary<int, AdvanceNoticeThumbItemData>();

	// Token: 0x04003969 RID: 14697
	public int ActivityId;

	// Token: 0x0400396A RID: 14698
	[Nullable(2)]
	public Action<int> OnSwitchSubTabDelegate;
}
