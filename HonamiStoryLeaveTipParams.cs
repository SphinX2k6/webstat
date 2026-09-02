using System;
using System.Runtime.CompilerServices;

// Token: 0x02001F26 RID: 7974
[NullableContext(1)]
[Nullable(0)]
public class HonamiStoryLeaveTipParams : IHonamiStoryLeaveTipParams
{
	// Token: 0x1700122F RID: 4655
	// (get) Token: 0x0600EE88 RID: 61064 RVA: 0x0041262F File Offset: 0x0041082F
	// (set) Token: 0x0600EE89 RID: 61065 RVA: 0x00412637 File Offset: 0x00410837
	public EHonamiStoryLeaveType LeaveType { get; set; }

	// Token: 0x17001230 RID: 4656
	// (get) Token: 0x0600EE8A RID: 61066 RVA: 0x00412640 File Offset: 0x00410840
	// (set) Token: 0x0600EE8B RID: 61067 RVA: 0x00412648 File Offset: 0x00410848
	public Action ConfirmCallback { get; set; }

	// Token: 0x17001231 RID: 4657
	// (get) Token: 0x0600EE8C RID: 61068 RVA: 0x00412651 File Offset: 0x00410851
	// (set) Token: 0x0600EE8D RID: 61069 RVA: 0x00412659 File Offset: 0x00410859
	[Nullable(2)]
	public Action CancelCallback { [NullableContext(2)] get; [NullableContext(2)] set; }

	// Token: 0x17001232 RID: 4658
	// (get) Token: 0x0600EE8E RID: 61070 RVA: 0x00412662 File Offset: 0x00410862
	// (set) Token: 0x0600EE8F RID: 61071 RVA: 0x0041266A File Offset: 0x0041086A
	public bool ShowSafeLeaveUpdate { get; set; }
}
