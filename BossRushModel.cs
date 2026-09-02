using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Game.Module.Activity.ActivityContent.BossRush;

// Token: 0x0200127A RID: 4730
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class BossRushModel : ModelBase<BossRushModel>
{
	// Token: 0x06007E9C RID: 32412 RVA: 0x002179FC File Offset: 0x00215BFC
	public int GetFullScore(int activityId)
	{
		BossRushData bossRushData = ModelBase<ActivityModel>.Instance.GetActivityById(activityId) as BossRushData;
		if (bossRushData == null)
		{
			return 0;
		}
		int num = 0;
		foreach (BossRushLevelDetailInfo bossRushLevelDetailInfo in bossRushData.GetBossRushLevelDetailInfo())
		{
			num += bossRushLevelDetailInfo.GetScore();
		}
		return num;
	}

	// Token: 0x06007E9D RID: 32413 RVA: 0x00217A6C File Offset: 0x00215C6C
	public BossRushTeamInfo GetBossRushTeamInfoByActivityId(int activityId)
	{
		BossRushTeamInfo bossRushTeamInfo;
		if (!this.TeamInfoMap.TryGetValue(activityId, out bossRushTeamInfo))
		{
			bossRushTeamInfo = new BossRushTeamInfo();
			this.TeamInfoMap[activityId] = bossRushTeamInfo;
		}
		return bossRushTeamInfo;
	}

	// Token: 0x06007E9E RID: 32414 RVA: 0x00217AA0 File Offset: 0x00215CA0
	public int[] GetHaveUnTakeRewardIds(int activityId)
	{
		List<int> list = new List<int>();
		int fullScore = this.GetFullScore(activityId);
		List<int> list2 = new List<int>();
		foreach (int item in list)
		{
			int num = 0;
			List<int> list3;
			if (fullScore >= num && this.CurrentTakeRewardsMap.TryGetValue(activityId, out list3) && !list3.Contains(item))
			{
				list2.Add(item);
			}
		}
		return list2.ToArray();
	}

	// Token: 0x06007E9F RID: 32415 RVA: 0x00217B28 File Offset: 0x00215D28
	public int[] GetLevelSelectRoleIds(BossRushTeamInfo data)
	{
		return data.GetCurrentTeamMembers();
	}

	// Token: 0x06007EA0 RID: 32416 RVA: 0x00217B30 File Offset: 0x00215D30
	public bool CheckInBossRush()
	{
		int instanceId = ModelBase<CreatureModel>.Instance.GetInstanceId();
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId);
		return config != null && config.Value.InstSubType == 20 && ControllerBase<GameModeController>.Instance.IsInInstance();
	}

	// Token: 0x04003CB0 RID: 15536
	[Nullable(2)]
	public BossRushLevelDetailInfo CurrentSelectLevelDetailData;

	// Token: 0x04003CB1 RID: 15537
	[Nullable(2)]
	public BossRushTeamInfo CurrentTeamInfo;

	// Token: 0x04003CB2 RID: 15538
	public int CurrentChangeBuffSlot;

	// Token: 0x04003CB3 RID: 15539
	public bool PlayBackAnimation;

	// Token: 0x04003CB4 RID: 15540
	public List<int> CurrentOpenBossRushActivityIds = new List<int>();

	// Token: 0x04003CB5 RID: 15541
	public int CurrentSelectActivityId;

	// Token: 0x04003CB6 RID: 15542
	private readonly Dictionary<int, BossRushTeamInfo> TeamInfoMap = new Dictionary<int, BossRushTeamInfo>();

	// Token: 0x04003CB7 RID: 15543
	private readonly Dictionary<int, List<int>> CurrentTakeRewardsMap = new Dictionary<int, List<int>>();

	// Token: 0x04003CB8 RID: 15544
	public EBuffTabName CurrentSelectBuffTabName;

	// Token: 0x04003CB9 RID: 15545
	public bool OnlyOpenRewardView;

	// Token: 0x04003CBA RID: 15546
	public List<int> ChoseBuffInGameHandleList = new List<int>();
}
