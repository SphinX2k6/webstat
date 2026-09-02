using System;
using System.Runtime.CompilerServices;

// Token: 0x02002250 RID: 8784
[NullableContext(2)]
public interface IPreemptiveFrameTask
{
	// Token: 0x17001477 RID: 5239
	// (get) Token: 0x0601092C RID: 67884
	// (set) Token: 0x0601092D RID: 67885
	int Priority { get; set; }

	// Token: 0x17001478 RID: 5240
	// (get) Token: 0x0601092E RID: 67886
	// (set) Token: 0x0601092F RID: 67887
	[Nullable(1)]
	TPreemptiveExecuteMethod Execute { [NullableContext(1)] get; [NullableContext(1)] set; }

	// Token: 0x17001479 RID: 5241
	// (get) Token: 0x06010930 RID: 67888
	// (set) Token: 0x06010931 RID: 67889
	TPreemptiveExecuteMethod FrameExecute { get; set; }

	// Token: 0x1700147A RID: 5242
	// (get) Token: 0x06010932 RID: 67890
	// (set) Token: 0x06010933 RID: 67891
	TPreemptiveIsCompleteMethod IsComplete { get; set; }

	// Token: 0x1700147B RID: 5243
	// (get) Token: 0x06010934 RID: 67892
	// (set) Token: 0x06010935 RID: 67893
	TPreemptiveCancelMethod Cancel { get; set; }

	// Token: 0x1700147C RID: 5244
	// (get) Token: 0x06010936 RID: 67894
	// (set) Token: 0x06010937 RID: 67895
	TGetPreemptiveResultMethod GetResult { get; set; }
}
