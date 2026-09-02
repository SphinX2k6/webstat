using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018F0 RID: 6384
[NullableContext(1)]
[Nullable(0)]
public class PinballFormationFilter : CommonFilter
{
	// Token: 0x0600B75C RID: 46940 RVA: 0x0030CA8C File Offset: 0x0030AC8C
	protected object GetPinballRoleBd(object data, Dictionary<int, string> currentSelectMap)
	{
		int id = (int)data;
		return ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(id).Value.Bd;
	}

	// Token: 0x0600B75D RID: 46941 RVA: 0x0030CAC0 File Offset: 0x0030ACC0
	protected object GetPinballRoleClass(object data, Dictionary<int, string> currentSelectMap)
	{
		int id = (int)data;
		return ConfigBase<PinballConfig>.Instance.GetPinballRoleConfigById(id).Value.GetPinballClassArray();
	}

	// Token: 0x0600B75E RID: 46942 RVA: 0x0030CAEF File Offset: 0x0030ACEF
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.PinballRoleBd, new TFilterConfig(this.GetPinballRoleBd));
		this.FilterMap.Add(FilterDefine.EFilterType.PinballRoleClass, new TFilterConfig(this.GetPinballRoleClass));
	}
}
