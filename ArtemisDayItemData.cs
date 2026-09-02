using System;

// Token: 0x020011AB RID: 4523
public class ArtemisDayItemData : IArtemisDayItemData
{
	// Token: 0x17000A05 RID: 2565
	// (get) Token: 0x0600770D RID: 30477 RVA: 0x001F29F1 File Offset: 0x001F0BF1
	// (set) Token: 0x0600770E RID: 30478 RVA: 0x001F29F9 File Offset: 0x001F0BF9
	public int Index { get; set; }

	// Token: 0x17000A06 RID: 2566
	// (get) Token: 0x0600770F RID: 30479 RVA: 0x001F2A02 File Offset: 0x001F0C02
	// (set) Token: 0x06007710 RID: 30480 RVA: 0x001F2A0A File Offset: 0x001F0C0A
	public EArtemisState? State { get; set; }
}
