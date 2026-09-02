using System;

// Token: 0x02001C10 RID: 7184
public class FloroRanchDayEndTask : FloroRanchDailyTaskBase
{
	// Token: 0x0600D12A RID: 53546 RVA: 0x00378952 File Offset: 0x00376B52
	protected override void OnExecute()
	{
		FloroRanchEntityActionSystem.DayEnd();
		base.Complete(null);
	}
}
