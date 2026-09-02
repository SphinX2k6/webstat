using System;

// Token: 0x02000F4E RID: 3918
public interface IDropData
{
	// Token: 0x1700074B RID: 1867
	// (get) Token: 0x06006273 RID: 25203
	// (set) Token: 0x06006274 RID: 25204
	int SubLevelIndex { get; set; }

	// Token: 0x1700074C RID: 1868
	// (get) Token: 0x06006275 RID: 25205
	// (set) Token: 0x06006276 RID: 25206
	int WaveGroupIndex { get; set; }

	// Token: 0x1700074D RID: 1869
	// (get) Token: 0x06006277 RID: 25207
	// (set) Token: 0x06006278 RID: 25208
	int MonsterId { get; set; }

	// Token: 0x1700074E RID: 1870
	// (get) Token: 0x06006279 RID: 25209
	// (set) Token: 0x0600627A RID: 25210
	int BuffGateId { get; set; }
}
