using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using FilterDefine;

// Token: 0x020018F2 RID: 6386
[NullableContext(1)]
[Nullable(0)]
public class PinballWeaponFilter : CommonFilter
{
	// Token: 0x0600B764 RID: 46948 RVA: 0x0030CBA0 File Offset: 0x0030ADA0
	protected object GetPinballWeaponType(object data, Dictionary<int, string> currentSelectMap)
	{
		PinballWeaponData pinballWeaponData = (PinballWeaponData)data;
		return ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(pinballWeaponData.Id).Value.Type;
	}

	// Token: 0x0600B765 RID: 46949 RVA: 0x0030CBDC File Offset: 0x0030ADDC
	protected object GetPinballWeaponQuality(object data, Dictionary<int, string> currentSelectMap)
	{
		PinballWeaponData pinballWeaponData = (PinballWeaponData)data;
		return ConfigBase<PinballConfig>.Instance.GetPinballWeaponConfigById(pinballWeaponData.Id).Value.QualityId;
	}

	// Token: 0x0600B766 RID: 46950 RVA: 0x0030CC15 File Offset: 0x0030AE15
	protected override void OnInitFilterMap()
	{
		this.FilterMap.Add(FilterDefine.EFilterType.PinballWeaponType, new TFilterConfig(this.GetPinballWeaponType));
		this.FilterMap.Add(FilterDefine.EFilterType.PinballWeaponQuality, new TFilterConfig(this.GetPinballWeaponQuality));
	}
}
