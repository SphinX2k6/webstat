using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200333E RID: 13118
public class RedDotFunctionNotice : RedDotBase
{
	// Token: 0x0601B692 RID: 112274 RVA: 0x00836B0F File Offset: 0x00834D0F
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewResonanceButton);
	}

	// Token: 0x0601B693 RID: 112275 RVA: 0x00836B17 File Offset: 0x00834D17
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SdkPostWebViewRedPointRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B694 RID: 112276 RVA: 0x00836B35 File Offset: 0x00834D35
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SdkPostWebViewRedPointRefresh, new Action(base.EventCheck));
	}

	// Token: 0x0601B695 RID: 112277 RVA: 0x00836B53 File Offset: 0x00834D53
	protected override bool OnCheck(int uId = 0)
	{
		return ControllerBase<KuroSdkController>.Instance.GetPostWebViewRedPointState();
	}
}
