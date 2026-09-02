using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.Activity.ActivityContent.WheelTower;

// Token: 0x02001664 RID: 5732
[NullableContext(1)]
[Nullable(0)]
internal class WheelTowerResultScoreInfoItemData
{
	// Token: 0x17000D7F RID: 3455
	// (get) Token: 0x0600A08A RID: 41098 RVA: 0x002A0901 File Offset: 0x0029EB01
	// (set) Token: 0x0600A08B RID: 41099 RVA: 0x002A0909 File Offset: 0x0029EB09
	public string Desc { get; set; } = string.Empty;

	// Token: 0x17000D80 RID: 3456
	// (get) Token: 0x0600A08C RID: 41100 RVA: 0x002A0912 File Offset: 0x0029EB12
	// (set) Token: 0x0600A08D RID: 41101 RVA: 0x002A091A File Offset: 0x0029EB1A
	public string Score { get; set; } = string.Empty;

	// Token: 0x17000D81 RID: 3457
	// (get) Token: 0x0600A08E RID: 41102 RVA: 0x002A0923 File Offset: 0x0029EB23
	// (set) Token: 0x0600A08F RID: 41103 RVA: 0x002A092B File Offset: 0x0029EB2B
	public EScoreLevel ScoreLevel { get; set; }
}
