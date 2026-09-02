using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02001727 RID: 5927
public class ActivityExData
{
	// Token: 0x0600A531 RID: 42289 RVA: 0x002B9FEE File Offset: 0x002B81EE
	public ActivityExData(int id)
	{
		this.ActivityId = id;
	}

	// Token: 0x0600A532 RID: 42290 RVA: 0x002B9FFD File Offset: 0x002B81FD
	public int GetActivityId()
	{
		return this.ActivityId;
	}

	// Token: 0x0600A533 RID: 42291 RVA: 0x002BA005 File Offset: 0x002B8205
	protected void RefreshActivityRedPoint()
	{
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.ActivityId);
	}

	// Token: 0x04004E63 RID: 20067
	protected int ActivityId;
}
