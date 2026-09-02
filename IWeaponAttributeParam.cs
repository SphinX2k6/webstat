using System;
using Aki.Config;

// Token: 0x02002D04 RID: 11524
public interface IWeaponAttributeParam
{
	// Token: 0x17001E9A RID: 7834
	// (get) Token: 0x0601742E RID: 95278
	// (set) Token: 0x0601742F RID: 95279
	ConfigPropValue PropId { get; set; }

	// Token: 0x17001E9B RID: 7835
	// (get) Token: 0x06017430 RID: 95280
	// (set) Token: 0x06017431 RID: 95281
	int CurveId { get; set; }
}
