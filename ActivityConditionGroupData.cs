using System;
using CSharpScript.Game.Ui;

// Token: 0x02001176 RID: 4470
public class ActivityConditionGroupData : UiPopViewData
{
	// Token: 0x060075A9 RID: 30121 RVA: 0x001ED1F9 File Offset: 0x001EB3F9
	public ActivityConditionGroupData(int activityId)
	{
		this.ActivityId = activityId;
	}

	// Token: 0x170009E7 RID: 2535
	// (get) Token: 0x060075AA RID: 30122 RVA: 0x001ED208 File Offset: 0x001EB408
	public int ActivityId { get; }
}
