using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001545 RID: 5445
[NullableContext(1)]
[Nullable(0)]
public class ActivityRegressTabGroupPanel
{
	// Token: 0x060098C9 RID: 39113 RVA: 0x0028057C File Offset: 0x0027E77C
	public ActivityRegressTabGroupPanel(UUIHorizontalLayout tabLayout, UUIItem tabItem, Action<int> tabCallBack)
	{
		this.TabLayout = tabLayout;
		this.TabItem = tabItem;
		this.TabCallBack = tabCallBack;
	}

	// Token: 0x060098CA RID: 39114 RVA: 0x00280599 File Offset: 0x0027E799
	public void Init()
	{
		this.TabGroup = new TabComponent<ActivityRegressTabSwitchItemPanel>(this.TabLayout.GetRootComponent(), new Func<UUIItem, int?, ActivityRegressTabSwitchItemPanel>(this.TabItemProxyCreate), new Action<int>(this.ToggleCallBack), this.TabItem);
	}

	// Token: 0x060098CB RID: 39115 RVA: 0x002805CF File Offset: 0x0027E7CF
	private ActivityRegressTabSwitchItemPanel TabItemProxyCreate([Nullable(2)] UUIItem uiItem, int? index)
	{
		return new ActivityRegressTabSwitchItemPanel();
	}

	// Token: 0x060098CC RID: 39116 RVA: 0x002805D6 File Offset: 0x0027E7D6
	private void ToggleCallBack(int gridIndex)
	{
		Action<int> tabCallBack = this.TabCallBack;
		if (tabCallBack == null)
		{
			return;
		}
		tabCallBack(gridIndex);
	}

	// Token: 0x060098CD RID: 39117 RVA: 0x002805E9 File Offset: 0x0027E7E9
	public void RefreshByData(List<ActivityRegressTabSwitchItemCommonData> tabCommonDataList, int subTabIndex)
	{
		this.TabCommonDataList = tabCommonDataList;
		if (tabCommonDataList.Count > 0)
		{
			this.UpdateTabs(subTabIndex);
		}
	}

	// Token: 0x060098CE RID: 39118 RVA: 0x00280604 File Offset: 0x0027E804
	private void UpdateTabs(int subTabIndex)
	{
		int count = this.TabCommonDataList.Count;
		int tabIndex = subTabIndex;
		this.TabGroup.RefreshTabItemByLength(count, delegate
		{
			foreach (KeyValuePair<int, ActivityRegressTabSwitchItemPanel> keyValuePair in this.TabGroup.GetTabItemMap())
			{
				int key = keyValuePair.Key;
				ActivityRegressTabSwitchItemPanel value = keyValuePair.Value;
				ActivityRegressTabSwitchItemCommonData tabData = this.TabCommonDataList[key];
				value.UpdateView(tabData);
			}
			this.TabGroup.SelectToggleByIndex(tabIndex, false, true);
		});
	}

	// Token: 0x060098CF RID: 39119 RVA: 0x00280649 File Offset: 0x0027E849
	public void Destroy()
	{
		this.TabGroup.Destroy(null);
	}

	// Token: 0x040046A6 RID: 18086
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private TabComponent<ActivityRegressTabSwitchItemPanel> TabGroup;

	// Token: 0x040046A7 RID: 18087
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private List<ActivityRegressTabSwitchItemCommonData> TabCommonDataList;

	// Token: 0x040046A8 RID: 18088
	public UUIHorizontalLayout TabLayout;

	// Token: 0x040046A9 RID: 18089
	public UUIItem TabItem;

	// Token: 0x040046AA RID: 18090
	[Nullable(2)]
	public readonly Action<int> TabCallBack;
}
