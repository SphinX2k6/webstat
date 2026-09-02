using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033F0 RID: 13296
public class VisionTabRedDot : RedDotBase
{
	// Token: 0x0601B9CD RID: 113101 RVA: 0x0083D592 File Offset: 0x0083B792
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshVisionEquipRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9CE RID: 113102 RVA: 0x0083D5B0 File Offset: 0x0083B7B0
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshVisionEquipRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9CF RID: 113103 RVA: 0x0083D5CE File Offset: 0x0083B7CE
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B9D0 RID: 113104 RVA: 0x0083D5D1 File Offset: 0x0083B7D1
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<VisionRecommendModel>.Instance.CheckVisionOneKeyEquipRedDot(uId) || ModelBase<VisionEquipGroupModel>.Instance.GetVisionGroupFirstOpenState();
	}
}
