using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CiacconaGal;

// Token: 0x02003316 RID: 13078
public class RedDotCiacconaEndingReward : RedDotBase
{
	// Token: 0x0601B5E1 RID: 112097 RVA: 0x00835628 File Offset: 0x00833828
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaChapterDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B5E2 RID: 112098 RVA: 0x00835646 File Offset: 0x00833846
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaChapterDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B5E3 RID: 112099 RVA: 0x00835664 File Offset: 0x00833864
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<CiacconaGalModel>.Instance.HasAnyEndingReward();
	}
}
