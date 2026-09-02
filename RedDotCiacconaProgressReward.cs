using System;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.CiacconaGal;

// Token: 0x02003315 RID: 13077
public class RedDotCiacconaProgressReward : RedDotBase
{
	// Token: 0x0601B5DD RID: 112093 RVA: 0x008355D8 File Offset: 0x008337D8
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnCiacconaRewardDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B5DE RID: 112094 RVA: 0x008355F6 File Offset: 0x008337F6
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnCiacconaRewardDataUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B5DF RID: 112095 RVA: 0x00835614 File Offset: 0x00833814
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<CiacconaGalModel>.Instance.HasAnyProgressReward();
	}
}
