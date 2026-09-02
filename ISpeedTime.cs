using System;

// Token: 0x02001C08 RID: 7176
public interface ISpeedTime
{
	// Token: 0x170010FE RID: 4350
	// (get) Token: 0x0600D091 RID: 53393
	// (set) Token: 0x0600D092 RID: 53394
	float PopupRewardStayTime { get; set; }

	// Token: 0x170010FF RID: 4351
	// (get) Token: 0x0600D093 RID: 53395
	// (set) Token: 0x0600D094 RID: 53396
	float PopupRewardWaitTime { get; set; }

	// Token: 0x17001100 RID: 4352
	// (get) Token: 0x0600D095 RID: 53397
	// (set) Token: 0x0600D096 RID: 53398
	float BezierCurveTime { get; set; }

	// Token: 0x17001101 RID: 4353
	// (get) Token: 0x0600D097 RID: 53399
	// (set) Token: 0x0600D098 RID: 53400
	float WageSettleWaitTime { get; set; }

	// Token: 0x17001102 RID: 4354
	// (get) Token: 0x0600D099 RID: 53401
	// (set) Token: 0x0600D09A RID: 53402
	float ToyLevelUpPlayRate { get; set; }
}
