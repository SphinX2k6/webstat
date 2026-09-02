using System;
using System.Runtime.CompilerServices;

// Token: 0x02002AFC RID: 11004
[NullableContext(2)]
[Nullable(0)]
public class SurvivorsWeaponGridData : ISurvivorsWeaponGridData
{
	// Token: 0x17001CA4 RID: 7332
	// (get) Token: 0x06015FFA RID: 90106 RVA: 0x0061A887 File Offset: 0x00618A87
	// (set) Token: 0x06015FFB RID: 90107 RVA: 0x0061A88F File Offset: 0x00618A8F
	public SurvivorsWeaponGainData WeaponData { get; set; }

	// Token: 0x17001CA5 RID: 7333
	// (get) Token: 0x06015FFC RID: 90108 RVA: 0x0061A898 File Offset: 0x00618A98
	// (set) Token: 0x06015FFD RID: 90109 RVA: 0x0061A8A0 File Offset: 0x00618AA0
	public int? BondPosition { get; set; }

	// Token: 0x17001CA6 RID: 7334
	// (get) Token: 0x06015FFE RID: 90110 RVA: 0x0061A8A9 File Offset: 0x00618AA9
	// (set) Token: 0x06015FFF RID: 90111 RVA: 0x0061A8B1 File Offset: 0x00618AB1
	public bool IsLock { get; set; }

	// Token: 0x17001CA7 RID: 7335
	// (get) Token: 0x06016000 RID: 90112 RVA: 0x0061A8BA File Offset: 0x00618ABA
	// (set) Token: 0x06016001 RID: 90113 RVA: 0x0061A8C2 File Offset: 0x00618AC2
	public int? UnlockBatch { get; set; }

	// Token: 0x17001CA8 RID: 7336
	// (get) Token: 0x06016002 RID: 90114 RVA: 0x0061A8CB File Offset: 0x00618ACB
	// (set) Token: 0x06016003 RID: 90115 RVA: 0x0061A8D3 File Offset: 0x00618AD3
	public bool IsDisable { get; set; }
}
