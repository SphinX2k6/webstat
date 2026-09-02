using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003305 RID: 13061
public class RedDotBattlePassPayButton : RedDotBase
{
	// Token: 0x0601B597 RID: 112023 RVA: 0x00834D05 File Offset: 0x00832F05
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.BattlePass);
	}

	// Token: 0x0601B598 RID: 112024 RVA: 0x00834D0E File Offset: 0x00832F0E
	protected override bool OnCheck(int uId = 0)
	{
		return (ModelBase<BattlePassModel>.Instance.PayButtonRedDotState || !ModelBase<BattlePassModel>.Instance.HadEnter) && ModelBase<BattlePassModel>.Instance.GetInTimeRange();
	}

	// Token: 0x0601B599 RID: 112025 RVA: 0x00834D34 File Offset: 0x00832F34
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.BattlePassHadEnterUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B59A RID: 112026 RVA: 0x00834D52 File Offset: 0x00832F52
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.BattlePassHadEnterUpdate, new Action(base.EventCheck));
	}

	// Token: 0x0601B59B RID: 112027 RVA: 0x00834D70 File Offset: 0x00832F70
	protected override void AddActiveEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.UpdateBattlePassTaskEvent, new Action(base.OnActiveEvent));
	}

	// Token: 0x0601B59C RID: 112028 RVA: 0x00834D8E File Offset: 0x00832F8E
	protected override void AddDisActiveEvents()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnBattlePassExpireEvent, new Action(base.OnDisActiveEvent));
	}
}
