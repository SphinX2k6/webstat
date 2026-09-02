using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x020015DA RID: 5594
[NullableContext(1)]
[Nullable(0)]
public class ActivityTowerGuideData : ActivityBaseData
{
	// Token: 0x06009D78 RID: 40312 RVA: 0x00293B08 File Offset: 0x00291D08
	protected override void PhraseEx(ActivityData data)
	{
		ControllerBase<ActivityTowerGuideController>.Instance.SetCurrentActivityId(base.Id);
		for (int i = 0; i < this.TowerDifficultIdList.Length; i++)
		{
			this.SetRewardClaimed(this.TowerDifficultIdList[i], false);
		}
		ControllerBase<ActivityTowerGuideController>.Instance.RequestTowerRewardInfo();
		TowerGuide? towerGuideById = ConfigBase<ActivityTowerGuideConfig>.Instance.GetTowerGuideById(1);
		if (towerGuideById == null)
		{
			return;
		}
		this.TrialRoleId = towerGuideById.Value.TrialRoleId;
		this.MapMarkId = towerGuideById.Value.MapMark;
	}

	// Token: 0x06009D79 RID: 40313 RVA: 0x00293B94 File Offset: 0x00291D94
	public override bool GetExDataRedPointShowState()
	{
		for (int i = 0; i < this.TowerDifficultIdList.Length; i++)
		{
			if (this.GetTowerProgressState(this.TowerDifficultIdList[i]) == ETowerProgressState.FinishedAndUnClaimed)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009D7A RID: 40314 RVA: 0x00293BC8 File Offset: 0x00291DC8
	protected override bool GetExDataFinishShowState()
	{
		for (int i = 0; i < this.TowerDifficultIdList.Length; i++)
		{
			if (this.GetTowerProgressState(this.TowerDifficultIdList[i]) != ETowerProgressState.FinishedAndClaimed)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06009D7B RID: 40315 RVA: 0x00293BFC File Offset: 0x00291DFC
	public ETowerGuideViewState GetViewState()
	{
		if (!base.IsUnLock())
		{
			return ETowerGuideViewState.InActive;
		}
		bool flag = true;
		for (int i = 0; i < this.TowerDifficultIdList.Length; i++)
		{
			if (this.GetTowerProgressState(this.TowerDifficultIdList[i]) != ETowerProgressState.FinishedAndClaimed)
			{
				flag = false;
				break;
			}
		}
		if (!flag)
		{
			return ETowerGuideViewState.Active;
		}
		return ETowerGuideViewState.Finished;
	}

	// Token: 0x06009D7C RID: 40316 RVA: 0x00293C43 File Offset: 0x00291E43
	public void SetRewardClaimed(int id, bool isClaimed)
	{
		this.TowerRewardClaimed[id] = isClaimed;
		this.RefreshRewardState((ETowerDifficultId)id);
	}

	// Token: 0x06009D7D RID: 40317 RVA: 0x00293C5C File Offset: 0x00291E5C
	public void RefreshRewardState(ETowerDifficultId id)
	{
		ETowerProgressState rewardState = this.GetRewardState(id);
		this.TowerRewardMap[(int)id] = rewardState;
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06009D7E RID: 40318 RVA: 0x00293C94 File Offset: 0x00291E94
	private ETowerProgressState GetRewardState(ETowerDifficultId id)
	{
		if (!base.IsUnLock())
		{
			return ETowerProgressState.InActive;
		}
		if (!ModelBase<TowerModel>.Instance.GetDifficultyIsClear((int)id))
		{
			return ETowerProgressState.Active;
		}
		bool flag;
		if (this.TowerRewardClaimed.TryGetValue((int)id, out flag) && flag)
		{
			return ETowerProgressState.FinishedAndClaimed;
		}
		return ETowerProgressState.FinishedAndUnClaimed;
	}

	// Token: 0x06009D7F RID: 40319 RVA: 0x00293CCF File Offset: 0x00291ECF
	[NullableContext(0)]
	public ValueTuple<int, int> GetTowerProgress(ETowerDifficultId id)
	{
		return ModelBase<TowerModel>.Instance.GetDifficultyProgress((int)id);
	}

	// Token: 0x06009D80 RID: 40320 RVA: 0x00293CDC File Offset: 0x00291EDC
	public ETowerProgressState GetTowerProgressState(int id)
	{
		ETowerProgressState result;
		if (!this.TowerRewardMap.TryGetValue(id, out result))
		{
			return ETowerProgressState.InActive;
		}
		return result;
	}

	// Token: 0x06009D81 RID: 40321 RVA: 0x00293CFC File Offset: 0x00291EFC
	[NullableContext(2)]
	public RoleDataBase GetTrialRoleData()
	{
		return ModelBase<RoleModel>.Instance.GetRoleDataById(this.TrialRoleId, true);
	}

	// Token: 0x04004880 RID: 18560
	public int[] TowerDifficultIdList = new int[]
	{
		1,
		2
	};

	// Token: 0x04004881 RID: 18561
	private readonly Dictionary<int, ETowerProgressState> TowerRewardMap = new Dictionary<int, ETowerProgressState>();

	// Token: 0x04004882 RID: 18562
	private readonly Dictionary<int, bool> TowerRewardClaimed = new Dictionary<int, bool>();

	// Token: 0x04004883 RID: 18563
	public int TrialRoleId;

	// Token: 0x04004884 RID: 18564
	public int MapMarkId;
}
