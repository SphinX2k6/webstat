using System;
using System.Runtime.CompilerServices;
using Aki.TDConfigMgr.Action;
using UnrealEngine;

// Token: 0x02001DB4 RID: 7604
[NullableContext(1)]
[Nullable(0)]
public class StopGamepadShakeImpl : ActionParams, IStopGamepadShake
{
	// Token: 0x17001189 RID: 4489
	// (get) Token: 0x0600E069 RID: 57449 RVA: 0x003C5651 File Offset: 0x003C3851
	// (set) Token: 0x0600E06A RID: 57450 RVA: 0x003C5659 File Offset: 0x003C3859
	public FName Tag { get; set; }

	// Token: 0x1700118A RID: 4490
	// (get) Token: 0x0600E06B RID: 57451 RVA: 0x003C5662 File Offset: 0x003C3862
	// (set) Token: 0x0600E06C RID: 57452 RVA: 0x003C566A File Offset: 0x003C386A
	public UKuroForceFeedbackEffect GamepadShakeAsset { get; set; }

	// Token: 0x1700118B RID: 4491
	// (get) Token: 0x0600E06D RID: 57453 RVA: 0x003C5673 File Offset: 0x003C3873
	// (set) Token: 0x0600E06E RID: 57454 RVA: 0x003C567B File Offset: 0x003C387B
	public UForceFeedbackComponent FeedbackComponent { get; set; }
}
