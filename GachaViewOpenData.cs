using System;

// Token: 0x02001CFC RID: 7420
public class GachaViewOpenData : IGachaViewOpenData
{
	// Token: 0x1700115A RID: 4442
	// (get) Token: 0x0600D9ED RID: 55789 RVA: 0x003A793B File Offset: 0x003A5B3B
	// (set) Token: 0x0600D9EE RID: 55790 RVA: 0x003A7943 File Offset: 0x003A5B43
	public bool SkipOnLoadResourceFinish { get; set; }

	// Token: 0x1700115B RID: 4443
	// (get) Token: 0x0600D9EF RID: 55791 RVA: 0x003A794C File Offset: 0x003A5B4C
	// (set) Token: 0x0600D9F0 RID: 55792 RVA: 0x003A7954 File Offset: 0x003A5B54
	public bool ResultViewHideExtraReward { get; set; }

	// Token: 0x1700115C RID: 4444
	// (get) Token: 0x0600D9F1 RID: 55793 RVA: 0x003A795D File Offset: 0x003A5B5D
	// (set) Token: 0x0600D9F2 RID: 55794 RVA: 0x003A7965 File Offset: 0x003A5B65
	public bool IsOnlyShowGold { get; set; }
}
