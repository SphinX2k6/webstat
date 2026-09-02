using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.TrapDefense;

// Token: 0x020033E6 RID: 13286
public class RedDotTrapDefenseTalentTree : RedDotBase
{
	// Token: 0x0601B99D RID: 113053 RVA: 0x0083D0C8 File Offset: 0x0083B2C8
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.TrapDefense);
	}

	// Token: 0x0601B99E RID: 113054 RVA: 0x0083D0D4 File Offset: 0x0083B2D4
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.RedDotUpdateTrapDefenseTalentTree, new Action(base.EventCheck));
	}

	// Token: 0x0601B99F RID: 113055 RVA: 0x0083D0F2 File Offset: 0x0083B2F2
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.RedDotUpdateTrapDefenseTalentTree, new Action(base.EventCheck));
	}

	// Token: 0x0601B9A0 RID: 113056 RVA: 0x0083D110 File Offset: 0x0083B310
	protected override bool OnCheck(int uId = 0)
	{
		TrapDefenseModel instance = ModelBase<TrapDefenseModel>.Instance;
		return instance != null && instance.TalentTreeData.HasAnyNodeCanUnlockAndAfford();
	}
}
