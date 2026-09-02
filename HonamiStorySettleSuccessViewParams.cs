using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x02001F7F RID: 8063
[NullableContext(1)]
[Nullable(0)]
public class HonamiStorySettleSuccessViewParams : IHonamiStorySettleSuccessViewParams
{
	// Token: 0x1700127C RID: 4732
	// (get) Token: 0x0600F19B RID: 61851 RVA: 0x0042021E File Offset: 0x0041E41E
	// (set) Token: 0x0600F19C RID: 61852 RVA: 0x00420226 File Offset: 0x0041E426
	public List<IHonamiStorySettleItemParams> DisplayItems { get; set; } = new List<IHonamiStorySettleItemParams>();

	// Token: 0x1700127D RID: 4733
	// (get) Token: 0x0600F19D RID: 61853 RVA: 0x0042022F File Offset: 0x0041E42F
	// (set) Token: 0x0600F19E RID: 61854 RVA: 0x00420237 File Offset: 0x0041E437
	public int TotalReward { get; set; }

	// Token: 0x1700127E RID: 4734
	// (get) Token: 0x0600F19F RID: 61855 RVA: 0x00420240 File Offset: 0x0041E440
	// (set) Token: 0x0600F1A0 RID: 61856 RVA: 0x00420248 File Offset: 0x0041E448
	public bool IsNewRecord { get; set; }
}
