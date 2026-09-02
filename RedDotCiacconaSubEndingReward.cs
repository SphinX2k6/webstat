using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CiacconaGal;

// Token: 0x02003317 RID: 13079
public class RedDotCiacconaSubEndingReward : RedDotBase
{
	// Token: 0x0601B5E5 RID: 112101 RVA: 0x00835678 File Offset: 0x00833878
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaChapterDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B5E6 RID: 112102 RVA: 0x00835696 File Offset: 0x00833896
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaChapterDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B5E7 RID: 112103 RVA: 0x008356B4 File Offset: 0x008338B4
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<CiacconaGalModel>.Instance.HasAnySubEndingReward();
	}
}
