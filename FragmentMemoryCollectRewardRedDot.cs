using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003332 RID: 13106
public class FragmentMemoryCollectRewardRedDot : RedDotBase
{
	// Token: 0x0601B662 RID: 112226 RVA: 0x008363DF File Offset: 0x008345DF
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.FragmentRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B663 RID: 112227 RVA: 0x008363FD File Offset: 0x008345FD
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.FragmentRewardRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B664 RID: 112228 RVA: 0x0083641C File Offset: 0x0083461C
	protected override bool OnCheck(int uId = 0)
	{
		FragmentMemoryCollectData collectDataById = ModelBase<FragmentMemoryModel>.Instance.GetCollectDataById(uId);
		return collectDataById != null && collectDataById.GetIfCanGetReward();
	}
}
