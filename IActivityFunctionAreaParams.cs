using System;
using System.Runtime.CompilerServices;

// Token: 0x0200116D RID: 4461
[NullableContext(1)]
public interface IActivityFunctionAreaParams
{
	// Token: 0x170009D5 RID: 2517
	// (get) Token: 0x06007574 RID: 30068
	// (set) Token: 0x06007575 RID: 30069
	string UnlockBtnTextId { get; set; }

	// Token: 0x170009D6 RID: 2518
	// (get) Token: 0x06007576 RID: 30070
	// (set) Token: 0x06007577 RID: 30071
	string[] UnlockBtnTextArgs { get; set; }

	// Token: 0x170009D7 RID: 2519
	// (get) Token: 0x06007578 RID: 30072
	// (set) Token: 0x06007579 RID: 30073
	Action UnlockBtnFunction { get; set; }

	// Token: 0x170009D8 RID: 2520
	// (get) Token: 0x0600757A RID: 30074
	// (set) Token: 0x0600757B RID: 30075
	Func<bool> BeforePreOpenCheck { get; set; }
}
