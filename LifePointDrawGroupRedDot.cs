using System;
using CSharpScript.Game.Common.Event;

// Token: 0x0200134E RID: 4942
public class LifePointDrawGroupRedDot : RedDotBase
{
	// Token: 0x06008724 RID: 34596 RVA: 0x0023981D File Offset: 0x00237A1D
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshLifePointDrawGroupRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x06008725 RID: 34597 RVA: 0x0023983B File Offset: 0x00237A3B
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshLifePointDrawGroupRedDot, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x06008726 RID: 34598 RVA: 0x00239859 File Offset: 0x00237A59
	protected override bool OnCheck(int groupId)
	{
		return ModelBase<LifePointDrawModel>.Instance.GetGroupRedDotState(groupId);
	}
}
