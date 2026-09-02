using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Ui;

// Token: 0x02001B31 RID: 6961
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class DynamicTabConfig : ConfigBase<DynamicTabConfig>
{
	// Token: 0x0600C8CA RID: 51402 RVA: 0x003535C8 File Offset: 0x003517C8
	public List<UiDynamicTab> GetViewTabList(string parentViewName)
	{
		List<UiDynamicTab> list = ConfigCommon.ToList<UiDynamicTab>(ConfigUiDynamicTabByParentViewName.GetConfigList(parentViewName, true));
		if (list != null)
		{
			list.Sort(new Comparison<UiDynamicTab>(this.SortByTabIndex));
		}
		return list ?? new List<UiDynamicTab>();
	}

	// Token: 0x0600C8CB RID: 51403 RVA: 0x00353604 File Offset: 0x00351804
	public List<EUiTabViewName> GetTabViewNameList(string parentViewName)
	{
		List<UiDynamicTab> viewTabList = this.GetViewTabList(parentViewName);
		List<EUiTabViewName> list = new List<EUiTabViewName>();
		foreach (UiDynamicTab uiDynamicTab in viewTabList)
		{
			list.Add((EUiTabViewName)uiDynamicTab.ChildViewName);
		}
		return list;
	}

	// Token: 0x0600C8CC RID: 51404 RVA: 0x0035366C File Offset: 0x0035186C
	public UiDynamicTab GetViewTab(string childViewName)
	{
		return ConfigUiDynamicTabByChildViewName.GetConfig(childViewName, true).GetValueOrDefault();
	}

	// Token: 0x0600C8CD RID: 51405 RVA: 0x00353688 File Offset: 0x00351888
	private int SortByTabIndex(UiDynamicTab a, UiDynamicTab b)
	{
		return a.TabIndex.CompareTo(b.TabIndex);
	}

	// Token: 0x0600C8CE RID: 51406 RVA: 0x003536AC File Offset: 0x003518AC
	public UiDynamicTab GetTabViewConfById(int id)
	{
		return ConfigUiDynamicTabById.GetConfig(id, true).GetValueOrDefault();
	}
}
