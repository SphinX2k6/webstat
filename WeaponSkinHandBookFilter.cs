using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018FA RID: 6394
[NullableContext(1)]
[Nullable(0)]
public class WeaponSkinHandBookFilter : CommonFilter
{
	// Token: 0x0600B78C RID: 46988 RVA: 0x0030D5A0 File Offset: 0x0030B7A0
	protected object GetWeaponType(object data, Dictionary<int, string> currentSelectMap)
	{
		int id = (int)data;
		return ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(id).WeaponSkinType;
	}

	// Token: 0x0600B78D RID: 46989 RVA: 0x0030D5CC File Offset: 0x0030B7CC
	protected object GetItemQuality(object data, Dictionary<int, string> currentSelectMap)
	{
		int id = (int)data;
		return ConfigBase<WeaponConfig>.Instance.GetWeaponSkinConfig(id).QualityId;
	}

	// Token: 0x0600B78E RID: 46990 RVA: 0x0030D5F8 File Offset: 0x0030B7F8
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.Weapon, new TFilterConfig(this.GetWeaponType));
		this.FilterMap.Add(FilterDefine.EFilterType.ItemQuality, new TFilterConfig(this.GetItemQuality));
	}
}
