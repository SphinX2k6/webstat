using System;

// Token: 0x02001110 RID: 4368
public class CardPositionConfig : ICardPositionConfig
{
	// Token: 0x1700092B RID: 2347
	// (get) Token: 0x0600717F RID: 29055 RVA: 0x001DAB87 File Offset: 0x001D8D87
	// (set) Token: 0x06007180 RID: 29056 RVA: 0x001DAB8F File Offset: 0x001D8D8F
	public float PositionRate { get; set; }

	// Token: 0x1700092C RID: 2348
	// (get) Token: 0x06007181 RID: 29057 RVA: 0x001DAB98 File Offset: 0x001D8D98
	// (set) Token: 0x06007182 RID: 29058 RVA: 0x001DABA0 File Offset: 0x001D8DA0
	public float Spacing { get; set; }

	// Token: 0x1700092D RID: 2349
	// (get) Token: 0x06007183 RID: 29059 RVA: 0x001DABA9 File Offset: 0x001D8DA9
	// (set) Token: 0x06007184 RID: 29060 RVA: 0x001DABB1 File Offset: 0x001D8DB1
	public float? UpOffset { get; set; }

	// Token: 0x1700092E RID: 2350
	// (get) Token: 0x06007185 RID: 29061 RVA: 0x001DABBA File Offset: 0x001D8DBA
	// (set) Token: 0x06007186 RID: 29062 RVA: 0x001DABC2 File Offset: 0x001D8DC2
	public float? Size { get; set; }

	// Token: 0x1700092F RID: 2351
	// (get) Token: 0x06007187 RID: 29063 RVA: 0x001DABCB File Offset: 0x001D8DCB
	// (set) Token: 0x06007188 RID: 29064 RVA: 0x001DABD3 File Offset: 0x001D8DD3
	public float? Alpha { get; set; }
}
