using System;

// Token: 0x020017D4 RID: 6100
public interface ICalabashUpgradeSuccessViedData
{
	// Token: 0x17000DFA RID: 3578
	// (get) Token: 0x0600AD25 RID: 44325
	// (set) Token: 0x0600AD26 RID: 44326
	bool AddExp { get; set; }

	// Token: 0x17000DFB RID: 3579
	// (get) Token: 0x0600AD27 RID: 44327
	// (set) Token: 0x0600AD28 RID: 44328
	int PreLevel { get; set; }

	// Token: 0x17000DFC RID: 3580
	// (get) Token: 0x0600AD29 RID: 44329
	// (set) Token: 0x0600AD2A RID: 44330
	int PreExp { get; set; }

	// Token: 0x17000DFD RID: 3581
	// (get) Token: 0x0600AD2B RID: 44331
	// (set) Token: 0x0600AD2C RID: 44332
	int CurLevel { get; set; }

	// Token: 0x17000DFE RID: 3582
	// (get) Token: 0x0600AD2D RID: 44333
	// (set) Token: 0x0600AD2E RID: 44334
	int CurExp { get; set; }
}
