using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200339D RID: 13213
public class RedDotPreDownload : RedDotBase
{
	// Token: 0x0601B84D RID: 112717 RVA: 0x00839FFC File Offset: 0x008381FC
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.PreDownloadStateUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B84E RID: 112718 RVA: 0x0083A01A File Offset: 0x0083821A
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.PreDownloadStateUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B84F RID: 112719 RVA: 0x0083A038 File Offset: 0x00838238
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PreDownloadModel>.Instance.HasClickBtnCheck() && !ModelBase<PreDownloadModel>.Instance.IsComplete();
	}
}
