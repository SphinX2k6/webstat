using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033D2 RID: 13266
public class RedDotGuessJokerUnlockLevel : RedDotBase
{
	// Token: 0x0601B954 RID: 112980 RVA: 0x0083C971 File Offset: 0x0083AB71
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnGuessJokerRedDotNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B955 RID: 112981 RVA: 0x0083C9AB File Offset: 0x0083ABAB
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnGuessJokerRedDotNotify, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B956 RID: 112982 RVA: 0x0083C9E5 File Offset: 0x0083ABE5
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<GuessJokerGamePlayModel>.Instance.CheckRedDot();
	}

	// Token: 0x0601B957 RID: 112983 RVA: 0x0083C9F1 File Offset: 0x0083ABF1
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.SpringManorGameEntrance);
	}
}
