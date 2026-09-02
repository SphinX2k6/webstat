using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018F9 RID: 6393
[NullableContext(1)]
[Nullable(0)]
public class WeaponHandBookFilter : CommonFilter
{
	// Token: 0x0600B788 RID: 46984 RVA: 0x0030D4FC File Offset: 0x0030B6FC
	protected object GetWeaponType(object data, Dictionary<int, string> currentSelectMap)
	{
		int itemId = (int)data;
		return ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId).Value.WeaponType;
	}

	// Token: 0x0600B789 RID: 46985 RVA: 0x0030D530 File Offset: 0x0030B730
	protected object GetItemQuality(object data, Dictionary<int, string> currentSelectMap)
	{
		int itemId = (int)data;
		return ConfigBase<WeaponConfig>.Instance.GetWeaponConfigByItemId(itemId).Value.QualityId;
	}

	// Token: 0x0600B78A RID: 46986 RVA: 0x0030D564 File Offset: 0x0030B764
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.Weapon, new TFilterConfig(this.GetWeaponType));
		this.FilterMap.Add(FilterDefine.EFilterType.ItemQuality, new TFilterConfig(this.GetItemQuality));
	}
}
