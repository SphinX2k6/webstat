using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using FilterDefine;

// Token: 0x020018E7 RID: 6375
[NullableContext(1)]
[Nullable(0)]
public class DangoAbyssPluginFilter : CommonFilter
{
	// Token: 0x0600B732 RID: 46898 RVA: 0x0030C12D File Offset: 0x0030A32D
	protected object GetDangoAbyssPluginQuality(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((AbyssPluginItemInfo)data).GetQuality();
	}

	// Token: 0x0600B733 RID: 46899 RVA: 0x0030C140 File Offset: 0x0030A340
	protected object GetDangoAbyssPluginProp(object data, Dictionary<int, string> currentSelectMap)
	{
		ConfigPropValue[] prop = ((AbyssPluginItemInfo)data).GetProp();
		List<int> list = new List<int>();
		foreach (ConfigPropValue configPropValue in prop)
		{
			list.Add(configPropValue.Id);
		}
		return list.ToArray();
	}

	// Token: 0x0600B734 RID: 46900 RVA: 0x0030C188 File Offset: 0x0030A388
	protected object GetDangoAbyssPluginTag(object data, Dictionary<int, string> currentSelectMap)
	{
		AbyssItem? abyssItem = ((AbyssPluginItemInfo)data).GetConfig().As<AbyssItem>();
		List<int> list = new List<int>();
		foreach (int item in abyssItem.Value.AddTag().Keys)
		{
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600B735 RID: 46901 RVA: 0x0030C208 File Offset: 0x0030A408
	protected object GetDangoAbyssPluginEquipState(object data, Dictionary<int, string> currentSelectMap)
	{
		return (((AbyssPluginItemInfo)data).GetRoleId() > 0) ? 1 : -1;
	}

	// Token: 0x0600B736 RID: 46902 RVA: 0x0030C221 File Offset: 0x0030A421
	protected object GetDangoAbyssPluginLockState(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((AbyssPluginItemInfo)data).GetIsLock() ? 1 : -1;
	}

	// Token: 0x0600B737 RID: 46903 RVA: 0x0030C239 File Offset: 0x0030A439
	protected object GetDangoAbyssPluginDeprecateState(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((AbyssPluginItemInfo)data).GetIsDeprecated() ? 1 : -1;
	}

	// Token: 0x0600B738 RID: 46904 RVA: 0x0030C254 File Offset: 0x0030A454
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.DangoAbyssPluginQuality, new TFilterConfig(this.GetDangoAbyssPluginQuality));
		this.FilterMap.Add(FilterDefine.EFilterType.DangoAbyssPluginProp, new TFilterConfig(this.GetDangoAbyssPluginProp));
		this.FilterMap.Add(FilterDefine.EFilterType.DangoAbyssPluginTag, new TFilterConfig(this.GetDangoAbyssPluginTag));
		this.FilterMap.Add(FilterDefine.EFilterType.DangoAbyssPluginEquipState, new TFilterConfig(this.GetDangoAbyssPluginEquipState));
		this.FilterMap.Add(FilterDefine.EFilterType.DangoAbyssPluginLockState, new TFilterConfig(this.GetDangoAbyssPluginLockState));
		this.FilterMap.Add(FilterDefine.EFilterType.DangoAbyssPluginDeprecateState, new TFilterConfig(this.GetDangoAbyssPluginDeprecateState));
	}
}
