using System;

// Token: 0x0200265B RID: 9819
public enum EQuestSpecialState
{
	// Token: 0x04009701 RID: 38657
	None,
	// Token: 0x04009702 RID: 38658
	PreShow,
	// Token: 0x04009703 RID: 38659
	LockByLackResource,
	// Token: 0x04009704 RID: 38660
	ResourceReadyButLock,
	// Token: 0x04009705 RID: 38661
	Suspend,
	// Token: 0x04009706 RID: 38662
	LockQuestSuspendByOnline,
	// Token: 0x04009707 RID: 38663
	HasRecommendQuest,
	// Token: 0x04009708 RID: 38664
	RefOccupiedEntity,
	// Token: 0x04009709 RID: 38665
	LockByFocusMode,
	// Token: 0x0400970A RID: 38666
	NotInFocusModeButLock,
	// Token: 0x0400970B RID: 38667
	FocusOtherQuest,
	// Token: 0x0400970C RID: 38668
	ActivityGuideQuest,
	// Token: 0x0400970D RID: 38669
	ActivityQuest
}
