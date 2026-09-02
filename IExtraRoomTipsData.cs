using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D46 RID: 11590
[NullableContext(2)]
public interface IExtraRoomTipsData
{
	// Token: 0x17001EC4 RID: 7876
	// (get) Token: 0x0601761E RID: 95774
	// (set) Token: 0x0601761F RID: 95775
	int CurScore { get; set; }

	// Token: 0x17001EC5 RID: 7877
	// (get) Token: 0x06017620 RID: 95776
	// (set) Token: 0x06017621 RID: 95777
	int MaxScore { get; set; }

	// Token: 0x17001EC6 RID: 7878
	// (get) Token: 0x06017622 RID: 95778
	// (set) Token: 0x06017623 RID: 95779
	Action CancelFunc { get; set; }

	// Token: 0x17001EC7 RID: 7879
	// (get) Token: 0x06017624 RID: 95780
	// (set) Token: 0x06017625 RID: 95781
	Action ConfirmFunc { get; set; }
}
