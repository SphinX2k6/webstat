using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200339E RID: 13214
public class RedDotPreDownloadComplete : RedDotBase
{
	// Token: 0x0601B851 RID: 112721 RVA: 0x0083A05D File Offset: 0x0083825D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PreDownloadStateUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B852 RID: 112722 RVA: 0x0083A07B File Offset: 0x0083827B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PreDownloadStateUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B853 RID: 112723 RVA: 0x0083A099 File Offset: 0x00838299
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PreDownloadModel>.Instance.IsComplete();
	}
}
