using System;
using System.Runtime.CompilerServices;

// Token: 0x02001F25 RID: 7973
[NullableContext(1)]
public interface IHonamiStoryLeaveTipParams
{
	// Token: 0x1700122B RID: 4651
	// (get) Token: 0x0600EE84 RID: 61060
	EHonamiStoryLeaveType LeaveType { get; }

	// Token: 0x1700122C RID: 4652
	// (get) Token: 0x0600EE85 RID: 61061
	Action ConfirmCallback { get; }

	// Token: 0x1700122D RID: 4653
	// (get) Token: 0x0600EE86 RID: 61062
	[Nullable(2)]
	Action CancelCallback { [NullableContext(2)] get; }

	// Token: 0x1700122E RID: 4654
	// (get) Token: 0x0600EE87 RID: 61063
	bool ShowSafeLeaveUpdate { get; }
}
