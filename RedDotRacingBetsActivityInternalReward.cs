using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;

// Token: 0x020033A3 RID: 13219
public class RedDotRacingBetsActivityInternalReward : RedDotBase
{
	// Token: 0x0601B869 RID: 112745 RVA: 0x0083A49A File Offset: 0x0083869A
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsRewardRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataRefresh));
	}

	// Token: 0x0601B86A RID: 112746 RVA: 0x0083A4D4 File Offset: 0x008386D4
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsRewardRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataRefresh));
	}

	// Token: 0x0601B86B RID: 112747 RVA: 0x0083A510 File Offset: 0x00838710
	protected override bool OnCheck(int uId = 0)
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		return racingBetsSeasonData != null && racingBetsSeasonData.GetGroupRewardData(ERacingBetsRewardType.DailyGameEarn).CanReceiveRewards();
	}

	// Token: 0x0601B86C RID: 112748 RVA: 0x0083A539 File Offset: 0x00838739
	[NullableContext(1)]
	private void OnRacingBetsDataRefresh(RacingBetsSeasonData seasonData)
	{
		base.EventCheck();
	}
}
