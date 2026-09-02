using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003311 RID: 13073
public class RedDotVisionRecovery : RedDotBase
{
	// Token: 0x0601B5CD RID: 112077 RVA: 0x008353A5 File Offset: 0x008335A5
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnVisionRecoveryStorage, new Action(base.EventCheck));
	}

	// Token: 0x0601B5CE RID: 112078 RVA: 0x008353C3 File Offset: 0x008335C3
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnVisionRecoveryStorage, new Action(base.EventCheck));
	}

	// Token: 0x0601B5CF RID: 112079 RVA: 0x008353E1 File Offset: 0x008335E1
	protected override bool OnCheck(int uId = 0)
	{
		return ModelBase<PhantomBattleModel>.Instance.GetVisionRecoveryBatchRedDot() || ModelBase<PhantomBattleModel>.Instance.GetVisionRecoveryBatchAimRedDot();
	}
}
