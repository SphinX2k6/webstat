using System;

// Token: 0x02003169 RID: 12649
public class WeaponVisibleState
{
	// Token: 0x1700239D RID: 9117
	// (get) Token: 0x0601A37C RID: 107388 RVA: 0x007B457C File Offset: 0x007B277C
	// (set) Token: 0x0601A37D RID: 107389 RVA: 0x007B4584 File Offset: 0x007B2784
	public bool IsHidden { get; set; }

	// Token: 0x1700239E RID: 9118
	// (get) Token: 0x0601A37E RID: 107390 RVA: 0x007B458D File Offset: 0x007B278D
	// (set) Token: 0x0601A37F RID: 107391 RVA: 0x007B4595 File Offset: 0x007B2795
	public bool Active { get; set; }

	// Token: 0x1700239F RID: 9119
	// (get) Token: 0x0601A380 RID: 107392 RVA: 0x007B459E File Offset: 0x007B279E
	// (set) Token: 0x0601A381 RID: 107393 RVA: 0x007B45A6 File Offset: 0x007B27A6
	public int Priority { get; set; }

	// Token: 0x0601A382 RID: 107394 RVA: 0x007B45AF File Offset: 0x007B27AF
	public WeaponVisibleState(bool isHidden = false, bool active = true, int priority = 0)
	{
		this.IsHidden = isHidden;
		this.Active = active;
		this.Priority = priority;
	}
}
