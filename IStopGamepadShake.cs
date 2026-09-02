using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

// Token: 0x02001DB3 RID: 7603
[NullableContext(1)]
public interface IStopGamepadShake
{
	// Token: 0x17001186 RID: 4486
	// (get) Token: 0x0600E063 RID: 57443
	// (set) Token: 0x0600E064 RID: 57444
	FName Tag { get; set; }

	// Token: 0x17001187 RID: 4487
	// (get) Token: 0x0600E065 RID: 57445
	// (set) Token: 0x0600E066 RID: 57446
	UKuroForceFeedbackEffect GamepadShakeAsset { get; set; }

	// Token: 0x17001188 RID: 4488
	// (get) Token: 0x0600E067 RID: 57447
	// (set) Token: 0x0600E068 RID: 57448
	UForceFeedbackComponent FeedbackComponent { get; set; }
}
