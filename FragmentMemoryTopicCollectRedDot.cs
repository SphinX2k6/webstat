using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003334 RID: 13108
public class FragmentMemoryTopicCollectRedDot : RedDotBase
{
	// Token: 0x0601B66A RID: 112234 RVA: 0x00836498 File Offset: 0x00834698
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FragmentRewardTopicRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B66B RID: 112235 RVA: 0x008364B6 File Offset: 0x008346B6
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.FragmentRewardTopicRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B66C RID: 112236 RVA: 0x008364D4 File Offset: 0x008346D4
	protected override bool OnCheck(int uId = 0)
	{
		FragmentMemoryTopicData topicDataById = ModelBase<FragmentMemoryModel>.Instance.GetTopicDataById(uId);
		return topicDataById != null && topicDataById.GetCollectRedDotState();
	}
}
