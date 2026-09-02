using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033CD RID: 13261
public class RedDotSpring25AllLetter : RedDotBase
{
	// Token: 0x0601B93B RID: 112955 RVA: 0x0083C404 File Offset: 0x0083A604
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.Spring25CloseLetterList, new Action(base.EventCheck));
	}

	// Token: 0x0601B93C RID: 112956 RVA: 0x0083C468 File Offset: 0x0083A668
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25InviteDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25ActivityParseDone, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.Spring25CloseLetterList, new Action(base.EventCheck));
	}

	// Token: 0x0601B93D RID: 112957 RVA: 0x0083C4C9 File Offset: 0x0083A6C9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<Spring25Model>.Instance.HasNewLetter;
	}
}
