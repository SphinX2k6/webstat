using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02002E5D RID: 11869
[NullableContext(2)]
[Nullable(0)]
public class SnapshotPayload
{
	// Token: 0x170020AE RID: 8366
	// (get) Token: 0x060185FD RID: 99837 RVA: 0x006D2D41 File Offset: 0x006D0F41
	// (set) Token: 0x060185FE RID: 99838 RVA: 0x006D2D49 File Offset: 0x006D0F49
	public BaseDamageComponent Target { get; set; }

	// Token: 0x170020AF RID: 8367
	// (get) Token: 0x060185FF RID: 99839 RVA: 0x006D2D52 File Offset: 0x006D0F52
	// (set) Token: 0x06018600 RID: 99840 RVA: 0x006D2D5A File Offset: 0x006D0F5A
	public BaseDamageComponent Attacker { get; set; }

	// Token: 0x170020B0 RID: 8368
	// (get) Token: 0x06018601 RID: 99841 RVA: 0x006D2D63 File Offset: 0x006D0F63
	// (set) Token: 0x06018602 RID: 99842 RVA: 0x006D2D6B File Offset: 0x006D0F6B
	public AttributeSnapshot TargetSnapshot { get; set; }

	// Token: 0x170020B1 RID: 8369
	// (get) Token: 0x06018603 RID: 99843 RVA: 0x006D2D74 File Offset: 0x006D0F74
	// (set) Token: 0x06018604 RID: 99844 RVA: 0x006D2D7C File Offset: 0x006D0F7C
	public AttributeSnapshot AttackerSnapshot { get; set; }

	// Token: 0x170020B2 RID: 8370
	// (get) Token: 0x06018605 RID: 99845 RVA: 0x006D2D85 File Offset: 0x006D0F85
	// (set) Token: 0x06018606 RID: 99846 RVA: 0x006D2D8D File Offset: 0x006D0F8D
	public bool HasDamageTransfer { get; set; }

	// Token: 0x170020B3 RID: 8371
	// (get) Token: 0x06018607 RID: 99847 RVA: 0x006D2D96 File Offset: 0x006D0F96
	// (set) Token: 0x06018608 RID: 99848 RVA: 0x006D2D9E File Offset: 0x006D0F9E
	[Nullable(new byte[]
	{
		2,
		1
	})]
	public List<DamageTransfer> DamageTransfers { [return: Nullable(new byte[]
	{
		2,
		1
	})] get; [param: Nullable(new byte[]
	{
		2,
		1
	})] set; }
}
