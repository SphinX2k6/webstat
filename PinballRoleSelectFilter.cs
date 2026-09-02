using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018F1 RID: 6385
[NullableContext(1)]
[Nullable(0)]
public class PinballRoleSelectFilter : CommonFilter
{
	// Token: 0x0600B760 RID: 46944 RVA: 0x0030CB2C File Offset: 0x0030AD2C
	protected object GetPinballRoleBd(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IPinballRoleSelectGridItemData)data).ItemData.BdId.GetValueOrDefault();
	}

	// Token: 0x0600B761 RID: 46945 RVA: 0x0030CB56 File Offset: 0x0030AD56
	protected object GetPinballRoleClass(object data, Dictionary<int, string> currentSelectMap)
	{
		return ((IPinballRoleSelectGridItemData)data).ClassIdList;
	}

	// Token: 0x0600B762 RID: 46946 RVA: 0x0030CB63 File Offset: 0x0030AD63
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.PinballRoleBd, new TFilterConfig(this.GetPinballRoleBd));
		this.FilterMap.Add(FilterDefine.EFilterType.PinballRoleClass, new TFilterConfig(this.GetPinballRoleClass));
	}
}
