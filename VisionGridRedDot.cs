using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033EC RID: 13292
public class VisionGridRedDot : RedDotBase
{
	// Token: 0x0601B9BB RID: 113083 RVA: 0x0083D3BD File Offset: 0x0083B5BD
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RefreshVisionEquipRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9BC RID: 113084 RVA: 0x0083D3DB File Offset: 0x0083B5DB
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RefreshVisionEquipRedPoint, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B9BD RID: 113085 RVA: 0x0083D3F9 File Offset: 0x0083B5F9
	protected override bool IsMultiple()
	{
		return true;
	}

	// Token: 0x0601B9BE RID: 113086 RVA: 0x0083D3FC File Offset: 0x0083B5FC
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<VisionRecommendModel>.Instance.CheckVisionOneKeyEquipRedDot(uId);
	}
}
