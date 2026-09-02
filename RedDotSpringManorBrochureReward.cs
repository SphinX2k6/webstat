using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.SpringManor;

// Token: 0x020033D6 RID: 13270
public class RedDotSpringManorBrochureReward : RedDotBase
{
	// Token: 0x0601B964 RID: 112996 RVA: 0x0083CB45 File Offset: 0x0083AD45
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBrochureBookItemStateUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B965 RID: 112997 RVA: 0x0083CB7F File Offset: 0x0083AD7F
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnBrochureBookItemStateUpdate, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.SpringManorFunctionOpenNotify, new Action(base.EventCheck));
	}

	// Token: 0x0601B966 RID: 112998 RVA: 0x0083CBB9 File Offset: 0x0083ADB9
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<SpringManorModel>.Instance.CheckBookItemRedDot(EBrochureType.Brochure);
	}

	// Token: 0x0601B967 RID: 112999 RVA: 0x0083CBC6 File Offset: 0x0083ADC6
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.SpringManorGameEntrance);
	}
}
