using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003335 RID: 13109
public class FragmentMemoryTopicRedDot : RedDotBase
{
	// Token: 0x0601B66E RID: 112238 RVA: 0x00836500 File Offset: 0x00834700
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FragmentRewardTopicRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B66F RID: 112239 RVA: 0x0083651E File Offset: 0x0083471E
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.FragmentRewardTopicRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B670 RID: 112240 RVA: 0x0083653C File Offset: 0x0083473C
	protected override bool OnCheck(int uId = 0)
	{
		FragmentMemoryTopicData topicDataById = ModelBase<FragmentMemoryModel>.Instance.GetTopicDataById(uId);
		return topicDataById != null && topicDataById.GetRedDotState();
	}
}
