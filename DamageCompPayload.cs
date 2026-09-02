using System;
using System.Runtime.CompilerServices;

// Token: 0x02002E5E RID: 11870
[NullableContext(2)]
[Nullable(0)]
public class DamageCompPayload
{
	// Token: 0x170020B4 RID: 8372
	// (get) Token: 0x0601860A RID: 99850 RVA: 0x006D2DAF File Offset: 0x006D0FAF
	// (set) Token: 0x0601860B RID: 99851 RVA: 0x006D2DB7 File Offset: 0x006D0FB7
	public BaseDamageComponent Target { get; set; }

	// Token: 0x170020B5 RID: 8373
	// (get) Token: 0x0601860C RID: 99852 RVA: 0x006D2DC0 File Offset: 0x006D0FC0
	// (set) Token: 0x0601860D RID: 99853 RVA: 0x006D2DC8 File Offset: 0x006D0FC8
	public BaseDamageComponent Attacker { get; set; }
}
