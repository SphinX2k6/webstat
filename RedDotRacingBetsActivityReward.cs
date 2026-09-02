using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RacingBets;
using CSharpScript.Game.Module.RacingBets.Data;

// Token: 0x020033A4 RID: 13220
public class RedDotRacingBetsActivityReward : RedDotBase
{
	// Token: 0x0601B86E RID: 112750 RVA: 0x0083A549 File Offset: 0x00838749
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsRewardRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataRefresh));
	}

	// Token: 0x0601B86F RID: 112751 RVA: 0x0083A583 File Offset: 0x00838783
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsRewardRefresh, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove(EEventName.OnRacingBetsDataRefresh, new Action<RacingBetsSeasonData>(this.OnRacingBetsDataRefresh));
	}

	// Token: 0x0601B870 RID: 112752 RVA: 0x0083A5C0 File Offset: 0x008387C0
	protected override bool OnCheck(int uId = 0)
	{
		RacingBetsSeasonData racingBetsSeasonData = ModelBase<RacingBetsModel>.Instance.GetRacingBetsSeasonData();
		if (racingBetsSeasonData == null)
		{
			return false;
		}
		RacingBetsGroupRewardData groupRewardData = racingBetsSeasonData.GetGroupRewardData(ERacingBetsRewardType.BetsCount);
		RacingBetsGroupRewardData groupRewardData2 = racingBetsSeasonData.GetGroupRewardData(ERacingBetsRewardType.DailyEarn);
		return groupRewardData.CanReceiveRewards() || groupRewardData2.CanReceiveRewards();
	}

	// Token: 0x0601B871 RID: 112753 RVA: 0x0083A5FD File Offset: 0x008387FD
	[NullableContext(1)]
	private void OnRacingBetsDataRefresh(RacingBetsSeasonData seasonData)
	{
		base.EventCheck();
	}
}
