using System;

// Token: 0x02002378 RID: 9080
public class BattlePassUpLevelViewData : IBattlePassUpLevelViewData
{
	// Token: 0x17001591 RID: 5521
	// (get) Token: 0x06011628 RID: 71208 RVA: 0x004CA0F8 File Offset: 0x004C82F8
	// (set) Token: 0x06011629 RID: 71209 RVA: 0x004CA100 File Offset: 0x004C8300
	public int IncreasedLevel { get; set; }

	// Token: 0x17001592 RID: 5522
	// (get) Token: 0x0601162A RID: 71210 RVA: 0x004CA109 File Offset: 0x004C8309
	// (set) Token: 0x0601162B RID: 71211 RVA: 0x004CA111 File Offset: 0x004C8311
	public bool FirstUnlockPass { get; set; }
}
