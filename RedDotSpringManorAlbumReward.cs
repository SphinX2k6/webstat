using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;

// Token: 0x020033D5 RID: 13269
public class RedDotSpringManorAlbumReward : RedDotBase
{
	// Token: 0x0601B95F RID: 112991 RVA: 0x0083CAA1 File Offset: 0x0083ACA1
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBrochureBookItemStateUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B960 RID: 112992 RVA: 0x0083CADB File Offset: 0x0083ACDB
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBrochureBookItemStateUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B961 RID: 112993 RVA: 0x0083CB15 File Offset: 0x0083AD15
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<SpringManorModel>.Instance.CheckBookItemRedDot(EBrochureType.Character) || ModelBase<SpringManorModel>.Instance.CheckBookItemRedDot(EBrochureType.EasterEggBook);
	}

	// Token: 0x0601B962 RID: 112994 RVA: 0x0083CB31 File Offset: 0x0083AD31
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.SpringManorGameEntrance);
	}
}
