using System;

// Token: 0x02000F4F RID: 3919
public class DropData : IDropData
{
	// Token: 0x1700074F RID: 1871
	// (get) Token: 0x0600627B RID: 25211 RVA: 0x00189A93 File Offset: 0x00187C93
	// (set) Token: 0x0600627C RID: 25212 RVA: 0x00189A9B File Offset: 0x00187C9B
	public int SubLevelIndex { get; set; }

	// Token: 0x17000750 RID: 1872
	// (get) Token: 0x0600627D RID: 25213 RVA: 0x00189AA4 File Offset: 0x00187CA4
	// (set) Token: 0x0600627E RID: 25214 RVA: 0x00189AAC File Offset: 0x00187CAC
	public int WaveGroupIndex { get; set; }

	// Token: 0x17000751 RID: 1873
	// (get) Token: 0x0600627F RID: 25215 RVA: 0x00189AB5 File Offset: 0x00187CB5
	// (set) Token: 0x06006280 RID: 25216 RVA: 0x00189ABD File Offset: 0x00187CBD
	public int MonsterId { get; set; }

	// Token: 0x17000752 RID: 1874
	// (get) Token: 0x06006281 RID: 25217 RVA: 0x00189AC6 File Offset: 0x00187CC6
	// (set) Token: 0x06006282 RID: 25218 RVA: 0x00189ACE File Offset: 0x00187CCE
	public int BuffGateId { get; set; }
}
