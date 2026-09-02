using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02002E61 RID: 11873
[NullableContext(2)]
[Nullable(0)]
public class DamageEventInfo
{
	// Token: 0x170020C6 RID: 8390
	// (get) Token: 0x06018631 RID: 99889 RVA: 0x006D2EF9 File Offset: 0x006D10F9
	// (set) Token: 0x06018632 RID: 99890 RVA: 0x006D2F01 File Offset: 0x006D1101
	public BaseDamageComponent Attacker { get; set; }

	// Token: 0x170020C7 RID: 8391
	// (get) Token: 0x06018633 RID: 99891 RVA: 0x006D2F0A File Offset: 0x006D110A
	// (set) Token: 0x06018634 RID: 99892 RVA: 0x006D2F12 File Offset: 0x006D1112
	public FVectorDouble HitPosition { get; set; }
}
