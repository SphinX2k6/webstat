using System;

// Token: 0x02002E5B RID: 11867
public interface IExtraDamageResult
{
	// Token: 0x170020A5 RID: 8357
	// (get) Token: 0x060185EA RID: 99818
	// (set) Token: 0x060185EB RID: 99819
	float HardnessResult { get; set; }

	// Token: 0x170020A6 RID: 8358
	// (get) Token: 0x060185EC RID: 99820
	// (set) Token: 0x060185ED RID: 99821
	float RageResult { get; set; }

	// Token: 0x170020A7 RID: 8359
	// (get) Token: 0x060185EE RID: 99822
	// (set) Token: 0x060185EF RID: 99823
	bool HitWeakness { get; set; }

	// Token: 0x170020A8 RID: 8360
	// (get) Token: 0x060185F0 RID: 99824
	// (set) Token: 0x060185F1 RID: 99825
	bool PartDestroyed { get; set; }

	// Token: 0x170020A9 RID: 8361
	// (get) Token: 0x060185F2 RID: 99826
	// (set) Token: 0x060185F3 RID: 99827
	float EnergyResult { get; set; }

	// Token: 0x170020AA RID: 8362
	// (get) Token: 0x060185F4 RID: 99828
	// (set) Token: 0x060185F5 RID: 99829
	long CounterSkillId { get; set; }
}
