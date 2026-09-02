using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.Roverlike;

// Token: 0x020032F1 RID: 13041
public class RedDotRoverlikeQuestRewardBtn : RedDotBase
{
	// Token: 0x0601B53A RID: 111930 RVA: 0x0083413B File Offset: 0x0083233B
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RoverlikeQuestTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B53B RID: 111931 RVA: 0x00834159 File Offset: 0x00832359
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RoverlikeQuestTaskUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B53C RID: 111932 RVA: 0x00834178 File Offset: 0x00832378
	protected override bool OnCheck(int uId = 0)
	{
		RoverlikeActivityController instance = ControllerBase<RoverlikeActivityController>.Instance;
		RoverlikeActivityData roverlikeActivityData = (instance != null) ? instance.GetCurrentActivityData() : null;
		return roverlikeActivityData != null && roverlikeActivityData.QuestData.HasRedDot();
	}
}
