using System;
using System.Runtime.CompilerServices;

// Token: 0x020020D7 RID: 8407
[NullableContext(2)]
[Nullable(0)]
public class HonamiStoryLoadingDataImpl : IHonamiStoryLoadingData, ISpecialCustomLoadingData
{
	// Token: 0x17001351 RID: 4945
	// (get) Token: 0x060100F1 RID: 65777 RVA: 0x00468C23 File Offset: 0x00466E23
	// (set) Token: 0x060100F2 RID: 65778 RVA: 0x00468C2B File Offset: 0x00466E2B
	public string View { get; set; }

	// Token: 0x17001352 RID: 4946
	// (get) Token: 0x060100F3 RID: 65779 RVA: 0x00468C34 File Offset: 0x00466E34
	// (set) Token: 0x060100F4 RID: 65780 RVA: 0x00468C3C File Offset: 0x00466E3C
	public int? LoadingId { get; set; }

	// Token: 0x17001353 RID: 4947
	// (get) Token: 0x060100F5 RID: 65781 RVA: 0x00468C45 File Offset: 0x00466E45
	// (set) Token: 0x060100F6 RID: 65782 RVA: 0x00468C4D File Offset: 0x00466E4D
	public int? BtId { get; set; }

	// Token: 0x17001354 RID: 4948
	// (get) Token: 0x060100F7 RID: 65783 RVA: 0x00468C56 File Offset: 0x00466E56
	// (set) Token: 0x060100F8 RID: 65784 RVA: 0x00468C5E File Offset: 0x00466E5E
	public int? Timing { get; set; }
}
