using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200333B RID: 13115
public class RedDotFunctionMail : RedDotBase
{
	// Token: 0x0601B686 RID: 112262 RVA: 0x008368AF File Offset: 0x00834AAF
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattleViewResonanceButton);
	}

	// Token: 0x0601B687 RID: 112263 RVA: 0x008368B8 File Offset: 0x00834AB8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.AddingNewMail, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnFunctionOpenUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B688 RID: 112264 RVA: 0x0083691C File Offset: 0x00834B1C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.SwitchUnfinishedFlag, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.AddingNewMail, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnFunctionOpenUpdateNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B689 RID: 112265 RVA: 0x0083697D File Offset: 0x00834B7D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<MailModel>.Instance.GetRedDotCouldLightOn();
	}
}
