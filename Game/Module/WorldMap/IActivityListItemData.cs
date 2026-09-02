using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WorldMap
{
	// Token: 0x02004B38 RID: 19256
	[NullableContext(1)]
	public interface IActivityListItemData
	{
		// Token: 0x1700860E RID: 34318
		// (get) Token: 0x060323AE RID: 205742
		// (set) Token: 0x060323AF RID: 205743
		EMapPeriodicActivityId Id { get; set; }

		// Token: 0x1700860F RID: 34319
		// (get) Token: 0x060323B0 RID: 205744
		// (set) Token: 0x060323B1 RID: 205745
		double LeftTime { get; set; }

		// Token: 0x17008610 RID: 34320
		// (get) Token: 0x060323B2 RID: 205746
		// (set) Token: 0x060323B3 RID: 205747
		string LeftTimeText { get; set; }

		// Token: 0x17008611 RID: 34321
		// (get) Token: 0x060323B4 RID: 205748
		// (set) Token: 0x060323B5 RID: 205749
		int CurrentNum { get; set; }

		// Token: 0x17008612 RID: 34322
		// (get) Token: 0x060323B6 RID: 205750
		// (set) Token: 0x060323B7 RID: 205751
		int TotalNum { get; set; }

		// Token: 0x17008613 RID: 34323
		// (get) Token: 0x060323B8 RID: 205752
		// (set) Token: 0x060323B9 RID: 205753
		bool IsFinish { get; set; }

		// Token: 0x17008614 RID: 34324
		// (get) Token: 0x060323BA RID: 205754
		// (set) Token: 0x060323BB RID: 205755
		bool RedPoint { get; set; }

		// Token: 0x17008615 RID: 34325
		// (get) Token: 0x060323BC RID: 205756
		// (set) Token: 0x060323BD RID: 205757
		Action OnClickCb { get; set; }

		// Token: 0x17008616 RID: 34326
		// (get) Token: 0x060323BE RID: 205758
		// (set) Token: 0x060323BF RID: 205759
		Action<IActivityListItemData> OnLeftTimeRefreshCb { get; set; }
	}
}
