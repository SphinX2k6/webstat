using System;

// Token: 0x0200151E RID: 5406
public struct IRegressLevelProgressData
{
	// Token: 0x17000D01 RID: 3329
	// (get) Token: 0x06009725 RID: 38693 RVA: 0x00278DD0 File Offset: 0x00276FD0
	// (set) Token: 0x06009726 RID: 38694 RVA: 0x00278DD8 File Offset: 0x00276FD8
	public int Level { readonly get; set; }

	// Token: 0x17000D02 RID: 3330
	// (get) Token: 0x06009727 RID: 38695 RVA: 0x00278DE1 File Offset: 0x00276FE1
	// (set) Token: 0x06009728 RID: 38696 RVA: 0x00278DE9 File Offset: 0x00276FE9
	public int MaxLevel { readonly get; set; }

	// Token: 0x17000D03 RID: 3331
	// (get) Token: 0x06009729 RID: 38697 RVA: 0x00278DF2 File Offset: 0x00276FF2
	// (set) Token: 0x0600972A RID: 38698 RVA: 0x00278DFA File Offset: 0x00276FFA
	public int CurScore { readonly get; set; }

	// Token: 0x17000D04 RID: 3332
	// (get) Token: 0x0600972B RID: 38699 RVA: 0x00278E03 File Offset: 0x00277003
	// (set) Token: 0x0600972C RID: 38700 RVA: 0x00278E0B File Offset: 0x0027700B
	public int NeedScore { readonly get; set; }
}
