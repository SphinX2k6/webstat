using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;

// Token: 0x0200200B RID: 8203
[NullableContext(1)]
[Nullable(0)]
public class ExternalInteractInfo
{
	// Token: 0x17001287 RID: 4743
	// (get) Token: 0x0600F7EA RID: 63466 RVA: 0x0043E30B File Offset: 0x0043C50B
	// (set) Token: 0x0600F7EB RID: 63467 RVA: 0x0043E313 File Offset: 0x0043C513
	public string Text { get; set; }

	// Token: 0x17001288 RID: 4744
	// (get) Token: 0x0600F7EC RID: 63468 RVA: 0x0043E31C File Offset: 0x0043C51C
	// (set) Token: 0x0600F7ED RID: 63469 RVA: 0x0043E324 File Offset: 0x0043C524
	public EInteractIcon IconType { get; set; }

	// Token: 0x17001289 RID: 4745
	// (get) Token: 0x0600F7EE RID: 63470 RVA: 0x0043E32D File Offset: 0x0043C52D
	// (set) Token: 0x0600F7EF RID: 63471 RVA: 0x0043E335 File Offset: 0x0043C535
	public Action Callback { get; set; }
}
