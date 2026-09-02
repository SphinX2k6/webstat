using System;
using System.Runtime.CompilerServices;

// Token: 0x02002D5B RID: 11611
[NullableContext(1)]
public interface IWeeklyRogueRoleGroupTitleInfo
{
	// Token: 0x17001ED7 RID: 7895
	// (get) Token: 0x06017709 RID: 96009
	// (set) Token: 0x0601770A RID: 96010
	string TitleId { get; set; }

	// Token: 0x17001ED8 RID: 7896
	// (get) Token: 0x0601770B RID: 96011
	// (set) Token: 0x0601770C RID: 96012
	bool IsUp { get; set; }

	// Token: 0x17001ED9 RID: 7897
	// (get) Token: 0x0601770D RID: 96013
	// (set) Token: 0x0601770E RID: 96014
	int? ScoreRate { get; set; }

	// Token: 0x17001EDA RID: 7898
	// (get) Token: 0x0601770F RID: 96015
	// (set) Token: 0x06017710 RID: 96016
	bool IsEmpty { get; set; }
}
