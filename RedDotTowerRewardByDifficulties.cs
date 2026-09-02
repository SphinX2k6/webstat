using System;
using CSharpScript.Game.Common.Event;

// Token: 0x020033DA RID: 13274
public class RedDotTowerRewardByDifficulties : RedDotBase
{
	// Token: 0x0601B976 RID: 113014 RVA: 0x0083CD3C File Offset: 0x0083AF3C
	protected override void AddCheckEvent()
	{
		Singleton<EventSystem>.Instance.Add(EEventName.OnTowerRewardReceived, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Add<int>(EEventName.RedDotTowerRewardByDifficulties, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B977 RID: 113015 RVA: 0x0083CD76 File Offset: 0x0083AF76
	protected override void RemoveCheckEvent()
	{
		Singleton<EventSystem>.Instance.Remove(EEventName.OnTowerRewardReceived, new Action(base.EventCheck));
		Singleton<EventSystem>.Instance.Remove<int>(EEventName.RedDotTowerRewardByDifficulties, new Action<int>(base.EventCheckWithUid));
	}

	// Token: 0x0601B978 RID: 113016 RVA: 0x0083CDB0 File Offset: 0x0083AFB0
	protected override bool OnCheck(int uId = 0)
	{
		switch (uId)
		{
		case 1:
			return ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(1);
		case 2:
			return ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(2);
		case 3:
		{
			int loopTowerIsClickSeason = ModelBase<TowerModel>.Instance.GetLoopTowerIsClickSeason();
			return ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(3) || loopTowerIsClickSeason < ModelBase<TowerModel>.Instance.CurrentSeason;
		}
		case 4:
			return ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(4);
		case 5:
		{
			bool flag = ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(1);
			bool flag2 = ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(2);
			bool flag3 = ModelBase<TowerModel>.Instance.CanGetRewardByDifficulties(4);
			return flag || flag2 || flag3;
		}
		default:
			return false;
		}
	}
}
