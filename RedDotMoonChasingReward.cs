using System;
using CSharpScript.Game.Common.Event;

// Token: 0x02003362 RID: 13154
public class RedDotMoonChasingReward : RedDotBase
{
	// Token: 0x0601B72C RID: 112428 RVA: 0x00837F69 File Offset: 0x00836169
	protected override ERedDotName? OnGetParentName()
	{
		return new ERedDotName?(ERedDotName.MoonChasingRewardAndShop);
	}

	// Token: 0x0601B72D RID: 112429 RVA: 0x00837F75 File Offset: 0x00836175
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add<int>(EEventName.TakenRewardTargetData, new Action<int>(this.OnTakenRewardTargetData));
		Singleton<EventSystem>.Instance.Add(EEventName.RefreshRewardTargetData, new Action(base.EventCheck));
	}

	// Token: 0x0601B72E RID: 112430 RVA: 0x00837FAF File Offset: 0x008361AF
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.TakenRewardTargetData, new Action<int>(this.OnTakenRewardTargetData));
		Singleton<EventSystem>.Instance.Remove(EEventName.RefreshRewardTargetData, new Action(base.EventCheck));
	}

	// Token: 0x0601B72F RID: 112431 RVA: 0x00837FE9 File Offset: 0x008361E9
	protected override bool IsAllEventParamAsUId()
	{
		return false;
	}

	// Token: 0x0601B730 RID: 112432 RVA: 0x00837FEC File Offset: 0x008361EC
	protected override bool OnCheck(int uId = 0)
	{
		ControllerBase<ActivityMoonChasingController>.Instance.RefreshActivityRedDot();
		return ModelBase<MoonChasingRewardModel>.Instance.GetAllTaskDataRedDotState(true);
	}

	// Token: 0x0601B731 RID: 112433 RVA: 0x00838003 File Offset: 0x00836203
	private void OnTakenRewardTargetData(int _)
	{
		base.EventCheck();
	}
}
