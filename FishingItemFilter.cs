using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.Fishing;
using FilterDefine;

// Token: 0x020018E9 RID: 6377
[NullableContext(1)]
[Nullable(0)]
public class FishingItemFilter : CommonFilter
{
	// Token: 0x0600B73D RID: 46909 RVA: 0x0030C348 File Offset: 0x0030A548
	protected object GetFishingItemTech(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IFishingHandBookItemData)data).Tech;
	}

	// Token: 0x0600B73E RID: 46910 RVA: 0x0030C355 File Offset: 0x0030A555
	protected object GetFishingItemTime(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IFishingHandBookItemData)data).Time;
	}

	// Token: 0x0600B73F RID: 46911 RVA: 0x0030C367 File Offset: 0x0030A567
	protected object GetFishingItemArea(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IFishingHandBookItemData)data).Area;
	}

	// Token: 0x0600B740 RID: 46912 RVA: 0x0030C374 File Offset: 0x0030A574
	protected object GetFishingItemType(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IFishingHandBookItemData)data).Type;
	}

	// Token: 0x0600B741 RID: 46913 RVA: 0x0030C388 File Offset: 0x0030A588
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.FishingTech, new TFilterConfig(this.GetFishingItemTech));
		this.FilterMap.Add(FilterDefine.EFilterType.FishingTime, new TFilterConfig(this.GetFishingItemTime));
		this.FilterMap.Add(FilterDefine.EFilterType.FishingArea, new TFilterConfig(this.GetFishingItemArea));
		this.FilterMap.Add(FilterDefine.EFilterType.FishingType, new TFilterConfig(this.GetFishingItemType));
	}
}
