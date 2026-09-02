using System;
using System.Runtime.CompilerServices;

// Token: 0x020025D4 RID: 9684
[NullableContext(1)]
[Nullable(0)]
public class InfoData : IInfoData
{
	// Token: 0x170017B9 RID: 6073
	// (get) Token: 0x06012EEF RID: 77551 RVA: 0x0053CC7D File Offset: 0x0053AE7D
	// (set) Token: 0x06012EF0 RID: 77552 RVA: 0x0053CC85 File Offset: 0x0053AE85
	public string Text { get; set; } = "";

	// Token: 0x170017BA RID: 6074
	// (get) Token: 0x06012EF1 RID: 77553 RVA: 0x0053CC8E File Offset: 0x0053AE8E
	// (set) Token: 0x06012EF2 RID: 77554 RVA: 0x0053CC96 File Offset: 0x0053AE96
	public bool IsFinish { get; set; }

	// Token: 0x170017BB RID: 6075
	// (get) Token: 0x06012EF3 RID: 77555 RVA: 0x0053CC9F File Offset: 0x0053AE9F
	// (set) Token: 0x06012EF4 RID: 77556 RVA: 0x0053CCA7 File Offset: 0x0053AEA7
	public bool IsOptionFinished { get; set; }
}
