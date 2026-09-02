using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Manufacture.Compose;
using FilterDefine;

// Token: 0x020018E5 RID: 6373
public class ComposeFilter : CommonFilter
{
	// Token: 0x0600B72B RID: 46891 RVA: 0x0030C034 File Offset: 0x0030A234
	[NullableContext(1)]
	protected object GetComposeMenuList(object data, Dictionary<int, string> currentSelectMap)
	{
		IBaseItemData baseItemData = (IBaseItemData)data;
		if (baseItemData.MainType == EComposeListType.ReagentProduction)
		{
			return ((IReagentProductionData)data).SubType;
		}
		if (baseItemData.MainType == EComposeListType.Structure)
		{
			return ((IStructureData)data).SubType;
		}
		return 0;
	}

	// Token: 0x0600B72C RID: 46892 RVA: 0x0030C082 File Offset: 0x0030A282
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.ComposeMenu, new TFilterConfig(this.GetComposeMenuList));
	}
}
