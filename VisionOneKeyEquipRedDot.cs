using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033EF RID: 13295
public class VisionOneKeyEquipRedDot : RedDotBase
{
	// Token: 0x0601B9C8 RID: 113096 RVA: 0x0083D53E File Offset: 0x0083B73E
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshVisionEquipRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9C9 RID: 113097 RVA: 0x0083D55C File Offset: 0x0083B75C
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshVisionEquipRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9CA RID: 113098 RVA: 0x0083D57A File Offset: 0x0083B77A
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B9CB RID: 113099 RVA: 0x0083D57D File Offset: 0x0083B77D
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<VisionRecommendModel>.Instance.CheckVisionOneKeyEquipRedDot(uId);
	}
}
