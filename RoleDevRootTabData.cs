using System;
using System.Runtime.CompilerServices;

// Token: 0x020027E7 RID: 10215
[NullableContext(1)]
[Nullable(0)]
public class RoleDevRootTabData : IRoleDevRootTabData
{
	// Token: 0x170019B5 RID: 6581
	// (get) Token: 0x060142C5 RID: 82629 RVA: 0x005A0A96 File Offset: 0x0059EC96
	// (set) Token: 0x060142C6 RID: 82630 RVA: 0x005A0A9E File Offset: 0x0059EC9E
	public ERoleDevTabType TabIndex { get; set; }

	// Token: 0x170019B6 RID: 6582
	// (get) Token: 0x060142C7 RID: 82631 RVA: 0x005A0AA7 File Offset: 0x0059ECA7
	// (set) Token: 0x060142C8 RID: 82632 RVA: 0x005A0AAF File Offset: 0x0059ECAF
	public string TabName { get; set; }

	// Token: 0x170019B7 RID: 6583
	// (get) Token: 0x060142C9 RID: 82633 RVA: 0x005A0AB8 File Offset: 0x0059ECB8
	// (set) Token: 0x060142CA RID: 82634 RVA: 0x005A0AC0 File Offset: 0x0059ECC0
	public bool TabIsUpgrade { get; set; }

	// Token: 0x170019B8 RID: 6584
	// (get) Token: 0x060142CB RID: 82635 RVA: 0x005A0AC9 File Offset: 0x0059ECC9
	// (set) Token: 0x060142CC RID: 82636 RVA: 0x005A0AD1 File Offset: 0x0059ECD1
	public bool TabIsFinish { get; set; }
}
