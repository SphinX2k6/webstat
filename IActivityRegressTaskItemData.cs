using System;
using Aki.Config;

// Token: 0x02001558 RID: 5464
public struct IActivityRegressTaskItemData
{
	// Token: 0x17000D1E RID: 3358
	// (get) Token: 0x06009950 RID: 39248 RVA: 0x00282282 File Offset: 0x00280482
	// (set) Token: 0x06009951 RID: 39249 RVA: 0x0028228A File Offset: 0x0028048A
	public EActivityRegressDoubleDropEntryType Type { readonly get; set; }

	// Token: 0x17000D1F RID: 3359
	// (get) Token: 0x06009952 RID: 39250 RVA: 0x00282293 File Offset: 0x00280493
	// (set) Token: 0x06009953 RID: 39251 RVA: 0x0028229B File Offset: 0x0028049B
	public RegressDoubleDrop Config { readonly get; set; }
}
