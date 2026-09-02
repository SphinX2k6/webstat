using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Cook;
using FilterDefine;

// Token: 0x020018E6 RID: 6374
[NullableContext(1)]
[Nullable(0)]
public class CookFilter : CommonFilter
{
	// Token: 0x0600B72E RID: 46894 RVA: 0x0030C0A5 File Offset: 0x0030A2A5
	protected object GetCookTypeList(object data, Dictionary<int, string> currentSelectMap)
	{
		if (((ICookItemData)data).MainType == ECookListType.Cooking)
		{
			return ((ICookingData)data).EffectType;
		}
		return 0;
	}

	// Token: 0x0600B72F RID: 46895 RVA: 0x0030C0CB File Offset: 0x0030A2CB
	protected object GetCookMenuList(object data, Dictionary<int, string> currentSelectMap)
	{
		if (((ICookItemData)data).MainType == ECookListType.Cooking)
		{
			return ((ICookingData)data).SubType;
		}
		return 0;
	}

	// Token: 0x0600B730 RID: 46896 RVA: 0x0030C0F1 File Offset: 0x0030A2F1
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.CookMenu, new TFilterConfig(this.GetCookMenuList));
		this.FilterMap.Add(FilterDefine.EFilterType.CookType, new TFilterConfig(this.GetCookTypeList));
	}
}
