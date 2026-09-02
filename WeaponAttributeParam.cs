using System;
using Aki.Config;

// Token: 0x02002D05 RID: 11525
public class WeaponAttributeParam : IWeaponAttributeParam
{
	// Token: 0x17001E9C RID: 7836
	// (get) Token: 0x06017432 RID: 95282 RVA: 0x0067334E File Offset: 0x0067154E
	// (set) Token: 0x06017433 RID: 95283 RVA: 0x00673356 File Offset: 0x00671556
	public ConfigPropValue PropId { get; set; }

	// Token: 0x17001E9D RID: 7837
	// (get) Token: 0x06017434 RID: 95284 RVA: 0x0067335F File Offset: 0x0067155F
	// (set) Token: 0x06017435 RID: 95285 RVA: 0x00673367 File Offset: 0x00671567
	public int CurveId { get; set; }
}
