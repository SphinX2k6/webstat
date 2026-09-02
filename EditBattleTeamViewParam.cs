using System;

// Token: 0x02001B3E RID: 6974
public class EditBattleTeamViewParam : IEditBattleTeamViewParam
{
	// Token: 0x17001039 RID: 4153
	// (get) Token: 0x0600C95A RID: 51546 RVA: 0x00355F35 File Offset: 0x00354135
	// (set) Token: 0x0600C95B RID: 51547 RVA: 0x00355F3D File Offset: 0x0035413D
	public bool IsHideTitle { get; set; }

	// Token: 0x1700103A RID: 4154
	// (get) Token: 0x0600C95C RID: 51548 RVA: 0x00355F46 File Offset: 0x00354146
	// (set) Token: 0x0600C95D RID: 51549 RVA: 0x00355F4E File Offset: 0x0035414E
	public bool CanUseSpecialTrailRole { get; set; }
}
