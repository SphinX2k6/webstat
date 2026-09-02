using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AFE RID: 11006
[NullableContext(1)]
[Nullable(0)]
public class SurvivorsWeaponWithBondInfo : ISurvivorsWeaponWithBondInfo
{
	// Token: 0x17001CAB RID: 7339
	// (get) Token: 0x06016007 RID: 90119 RVA: 0x0061A8E4 File Offset: 0x00618AE4
	// (set) Token: 0x06016008 RID: 90120 RVA: 0x0061A8EC File Offset: 0x00618AEC
	public SurvivorsWeaponGainData WeaponData { get; set; }

	// Token: 0x17001CAC RID: 7340
	// (get) Token: 0x06016009 RID: 90121 RVA: 0x0061A8F5 File Offset: 0x00618AF5
	// (set) Token: 0x0601600A RID: 90122 RVA: 0x0061A8FD File Offset: 0x00618AFD
	public int BondPosition { get; set; }
}
