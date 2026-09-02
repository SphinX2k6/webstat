using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x020021ED RID: 8685
[NullableContext(1)]
public interface IResultData
{
	// Token: 0x17001434 RID: 5172
	// (get) Token: 0x0601060A RID: 67082
	EGamePlayResult Result { get; }

	// Token: 0x17001435 RID: 5173
	// (get) Token: 0x0601060B RID: 67083
	int? Score { get; }

	// Token: 0x17001436 RID: 5174
	// (get) Token: 0x0601060C RID: 67084
	int? PassTime { get; }

	// Token: 0x17001437 RID: 5175
	// (get) Token: 0x0601060D RID: 67085
	bool IsNewRecord { get; }

	// Token: 0x17001438 RID: 5176
	// (get) Token: 0x0601060E RID: 67086
	[Nullable(2)]
	TItem[] Reward { [NullableContext(2)] get; }

	// Token: 0x17001439 RID: 5177
	// (get) Token: 0x0601060F RID: 67087
	int AutoCloseTime { get; }

	// Token: 0x1700143A RID: 5178
	// (get) Token: 0x06010610 RID: 67088
	IReadOnlyList<IButtonPreset> ButtonList { get; }
}
