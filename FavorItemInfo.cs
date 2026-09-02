using System;

// Token: 0x020027B4 RID: 10164
public class FavorItemInfo
{
	// Token: 0x1700197F RID: 6527
	// (get) Token: 0x06014198 RID: 82328 RVA: 0x0059DA70 File Offset: 0x0059BC70
	// (set) Token: 0x06014199 RID: 82329 RVA: 0x0059DA78 File Offset: 0x0059BC78
	public int Id { get; set; }

	// Token: 0x17001980 RID: 6528
	// (get) Token: 0x0601419A RID: 82330 RVA: 0x0059DA81 File Offset: 0x0059BC81
	// (set) Token: 0x0601419B RID: 82331 RVA: 0x0059DA89 File Offset: 0x0059BC89
	public EFavorItemStatus Status { get; set; }

	// Token: 0x0601419C RID: 82332 RVA: 0x0059DA92 File Offset: 0x0059BC92
	public FavorItemInfo(int id, EFavorItemStatus status)
	{
		this.Id = id;
		this.Status = status;
	}
}
