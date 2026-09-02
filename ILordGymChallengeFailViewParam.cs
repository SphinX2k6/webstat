using System;

// Token: 0x020021F0 RID: 8688
public interface ILordGymChallengeFailViewParam
{
	// Token: 0x1700143B RID: 5179
	// (get) Token: 0x06010627 RID: 67111
	// (set) Token: 0x06010628 RID: 67112
	int LordId { get; set; }

	// Token: 0x1700143C RID: 5180
	// (get) Token: 0x06010629 RID: 67113
	// (set) Token: 0x0601062A RID: 67114
	ELordGymVersion Version { get; set; }

	// Token: 0x1700143D RID: 5181
	// (get) Token: 0x0601062B RID: 67115
	// (set) Token: 0x0601062C RID: 67116
	bool IsFromGuide { get; set; }
}
