using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Module.Inventory;

// Token: 0x0200157F RID: 5503
[NullableContext(1)]
[Nullable(0)]
public class ActivityRoleTrialData : ActivityBaseData
{
	// Token: 0x06009A9A RID: 39578 RVA: 0x00287C19 File Offset: 0x00285E19
	public void SetRoleTrialState(ERoleTrialFlowState state)
	{
		this.RoleTrialState = state;
	}

	// Token: 0x06009A9B RID: 39579 RVA: 0x00287C22 File Offset: 0x00285E22
	public bool IsRolePreviewOn()
	{
		return this.RoleTrialState == ERoleTrialFlowState.RolePreview;
	}

	// Token: 0x06009A9C RID: 39580 RVA: 0x00287C2D File Offset: 0x00285E2D
	public bool IsRoleInstanceOn()
	{
		return this.RoleTrialState == ERoleTrialFlowState.RoleInstance;
	}

	// Token: 0x06009A9D RID: 39581 RVA: 0x00287C38 File Offset: 0x00285E38
	protected override void PhraseEx(ActivityData data)
	{
		if (this.CheckIfInShowTime() && !ControllerBase<ActivityRoleTrialController>.Instance.CurrentActivityIdList.Contains(data.Id))
		{
			ControllerBase<ActivityRoleTrialController>.Instance.CurrentActivityIdList.Add(data.Id);
		}
		this.RoleIdList.Clear();
		this.RoleTrialIdList.Clear();
		RoleTrialInfoActivity roleTrialInfoActivity = data.RoleTrialInfoActivity;
		if (roleTrialInfoActivity == null)
		{
			return;
		}
		this.RoleTrialTaskList = roleTrialInfoActivity.RoleTrialTask.ToList<RoleTrialTask>();
		this.RefreshExData();
		this.RefreshIsNewMap();
		ControllerBase<ActivityRoleTrialController>.Instance.TryRefreshIsNewMap(this);
	}

	// Token: 0x06009A9E RID: 39582 RVA: 0x00287CC4 File Offset: 0x00285EC4
	public void RefreshExData()
	{
		this.RoleIdList.Clear();
		this.RoleTrialIdList.Clear();
		double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
		foreach (RoleTrialTask roleTrialTask in this.RoleTrialTaskList)
		{
			ERoleTrialRewardState value = this.StateResolver[roleTrialTask.ChallengeState];
			RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(roleTrialTask.RoleId);
			this.TrialToIdMap[roleTrialInfoConfigByRoleId.Value.TrialRoleId] = roleTrialTask.RoleId;
			this.RoleRewardStateMap[roleTrialTask.RoleId] = value;
			long beginOpenTime = roleTrialTask.BeginOpenTime;
			if (beginOpenTime != 0L)
			{
				long endOpenTime = roleTrialTask.EndOpenTime;
				this.RoleBeginEndTimeMap[roleTrialTask.RoleId] = new Tuple<double, double>((double)beginOpenTime, (double)endOpenTime);
				if (serverTime >= (double)beginOpenTime && serverTime < (double)endOpenTime)
				{
					this.RoleIdList.Add(roleTrialTask.RoleId);
					this.RoleTrialIdList.Add(roleTrialInfoConfigByRoleId.Value.TrialRoleId);
				}
			}
			else
			{
				this.RoleIdList.Add(roleTrialTask.RoleId);
				this.RoleTrialIdList.Add(roleTrialInfoConfigByRoleId.Value.TrialRoleId);
			}
		}
	}

	// Token: 0x06009A9F RID: 39583 RVA: 0x00287E30 File Offset: 0x00286030
	public ERoleTrialRewardState GetRewardStateByRoleId(int roleId)
	{
		ERoleTrialRewardState result;
		if (this.RoleRewardStateMap.TryGetValue(roleId, out result))
		{
			return result;
		}
		return ERoleTrialRewardState.InActive;
	}

	// Token: 0x06009AA0 RID: 39584 RVA: 0x00287E50 File Offset: 0x00286050
	public void SetRewardStateByRoleId(int roleId, ERoleTrialRewardState state)
	{
		this.RoleRewardStateMap[roleId] = state;
	}

	// Token: 0x06009AA1 RID: 39585 RVA: 0x00287E60 File Offset: 0x00286060
	public int? GetInstanceIdByRoleId(int roleId)
	{
		RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(roleId);
		if (roleTrialInfoConfigByRoleId == null)
		{
			return null;
		}
		return new int?(roleTrialInfoConfigByRoleId.GetValueOrDefault().InstanceId);
	}

	// Token: 0x06009AA2 RID: 39586 RVA: 0x00287EA0 File Offset: 0x002860A0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<IItemGridData> GetRewardDataByRoleId(int roleId)
	{
		RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(roleId);
		if (roleTrialInfoConfigByRoleId == null || roleTrialInfoConfigByRoleId.Value.RewardItemLength == 0)
		{
			return null;
		}
		ERoleTrialRewardState rewardStateByRoleId = this.GetRewardStateByRoleId(roleId);
		List<IItemGridData> list = new List<IItemGridData>();
		for (int i = 0; i < roleTrialInfoConfigByRoleId.Value.RewardItemLength; i++)
		{
			DicIntInt value = roleTrialInfoConfigByRoleId.Value.RewardItem(i).Value;
			int key = value.Key;
			int value2 = value.Value;
			TItem item = new TItem(new InventoryDefine.GetItemData(key, 0), value2);
			ItemGridData item2 = new ItemGridData
			{
				Item = item,
				HasClaimed = (rewardStateByRoleId == ERoleTrialRewardState.FinishedAndClaimed)
			};
			list.Add(item2);
		}
		return list;
	}

	// Token: 0x06009AA3 RID: 39587 RVA: 0x00287F64 File Offset: 0x00286164
	public bool GetIsNewByRoleId(int roleId)
	{
		bool flag;
		return this.RoleIsNewMap.TryGetValue(roleId, out flag) && flag;
	}

	// Token: 0x06009AA4 RID: 39588 RVA: 0x00287F84 File Offset: 0x00286184
	public void RefreshIsNewMap()
	{
		Dictionary<int, Dictionary<int, double>> player = LocalStorage.GetPlayer<Dictionary<int, Dictionary<int, double>>>(ELocalStoragePlayerKey.RoleTrialRemindMap, null);
		foreach (RoleTrialTask roleTrialTask in this.RoleTrialTaskList)
		{
			int roleId = roleTrialTask.RoleId;
			Tuple<double, double> tuple;
			if (!this.RoleBeginEndTimeMap.TryGetValue(roleId, out tuple))
			{
				this.RoleIsNewMap[roleId] = false;
			}
			else
			{
				double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
				if (serverTime < tuple.Item1 || serverTime >= tuple.Item2)
				{
					this.RoleIsNewMap[roleId] = false;
				}
				else
				{
					double num = 0.0;
					Dictionary<int, double> dictionary;
					if (player != null && player.TryGetValue(base.Id, out dictionary))
					{
						dictionary.TryGetValue(roleId, out num);
					}
					this.RoleIsNewMap[roleId] = (num == 0.0 || num < tuple.Item1);
				}
			}
		}
	}

	// Token: 0x06009AA5 RID: 39589 RVA: 0x00288084 File Offset: 0x00286284
	public RoleTrialInfo? GetConfigByRoleAndInstance(int roleInfoId, int instanceId)
	{
		foreach (int id in this.RoleIdList)
		{
			RoleTrialInfo? roleTrialInfoConfigByRoleId = ConfigBase<ActivityRoleTrialConfig>.Instance.GetRoleTrialInfoConfigByRoleId(id);
			if (roleTrialInfoConfigByRoleId != null && roleTrialInfoConfigByRoleId.Value.RoleId == roleInfoId && roleTrialInfoConfigByRoleId.Value.InstanceId == instanceId)
			{
				return roleTrialInfoConfigByRoleId;
			}
		}
		return null;
	}

	// Token: 0x06009AA6 RID: 39590 RVA: 0x0028811C File Offset: 0x0028631C
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06009AA7 RID: 39591 RVA: 0x00288120 File Offset: 0x00286320
	public override bool GetExDataRedPointShowState()
	{
		foreach (KeyValuePair<int, ERoleTrialRewardState> keyValuePair in this.RoleRewardStateMap)
		{
			if (keyValuePair.Value == ERoleTrialRewardState.FinishedAndUnClaimed && this.RoleIdList.Contains(keyValuePair.Key))
			{
				return true;
			}
		}
		foreach (KeyValuePair<int, bool> keyValuePair2 in this.RoleIsNewMap)
		{
			if (keyValuePair2.Value && this.RoleIdList.Contains(keyValuePair2.Key))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06009AA8 RID: 39592 RVA: 0x002881F0 File Offset: 0x002863F0
	protected override bool GetExDataFinishShowState()
	{
		if (this.RoleRewardStateMap.Count == 0)
		{
			return false;
		}
		foreach (KeyValuePair<int, ERoleTrialRewardState> keyValuePair in this.RoleRewardStateMap)
		{
			if (keyValuePair.Value != ERoleTrialRewardState.FinishedAndClaimed)
			{
				return false;
			}
		}
		using (Dictionary<int, bool>.ValueCollection.Enumerator enumerator2 = this.RoleIsNewMap.Values.GetEnumerator())
		{
			while (enumerator2.MoveNext())
			{
				if (enumerator2.Current)
				{
					return false;
				}
			}
		}
		return true;
	}

	// Token: 0x06009AA9 RID: 39593 RVA: 0x002882A4 File Offset: 0x002864A4
	public void SaveRemindTime(int roleId)
	{
		Dictionary<int, Dictionary<int, double>> dictionary = LocalStorage.GetPlayer<Dictionary<int, Dictionary<int, double>>>(ELocalStoragePlayerKey.RoleTrialRemindMap, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, Dictionary<int, double>>();
		}
		Dictionary<int, double> dictionary2;
		if (!dictionary.TryGetValue(base.Id, out dictionary2))
		{
			dictionary2 = new Dictionary<int, double>();
			dictionary[base.Id] = dictionary2;
		}
		dictionary2[roleId] = Singleton<TimeUtil>.Instance.GetServerTime();
		LocalStorage.SetPlayer<Dictionary<int, Dictionary<int, double>>>(ELocalStoragePlayerKey.RoleTrialRemindMap, dictionary);
		this.RoleIsNewMap[roleId] = false;
	}

	// Token: 0x0400472F RID: 18223
	public List<RoleTrialTask> RoleTrialTaskList = new List<RoleTrialTask>();

	// Token: 0x04004730 RID: 18224
	public readonly Dictionary<ChallengeState, ERoleTrialRewardState> StateResolver = new Dictionary<ChallengeState, ERoleTrialRewardState>
	{
		{
			ChallengeState.Running,
			ERoleTrialRewardState.InActive
		},
		{
			ChallengeState.WaitTakeReward,
			ERoleTrialRewardState.FinishedAndUnClaimed
		},
		{
			ChallengeState.Finish,
			ERoleTrialRewardState.FinishedAndClaimed
		}
	};

	// Token: 0x04004731 RID: 18225
	public List<int> RoleIdList = new List<int>();

	// Token: 0x04004732 RID: 18226
	public List<int> RoleTrialIdList = new List<int>();

	// Token: 0x04004733 RID: 18227
	public Dictionary<int, Tuple<double, double>> RoleBeginEndTimeMap = new Dictionary<int, Tuple<double, double>>();

	// Token: 0x04004734 RID: 18228
	public readonly Dictionary<int, int> TrialToIdMap = new Dictionary<int, int>();

	// Token: 0x04004735 RID: 18229
	private readonly Dictionary<int, ERoleTrialRewardState> RoleRewardStateMap = new Dictionary<int, ERoleTrialRewardState>();

	// Token: 0x04004736 RID: 18230
	private readonly Dictionary<int, bool> RoleIsNewMap = new Dictionary<int, bool>();

	// Token: 0x04004737 RID: 18231
	public int CurrentRoleId;

	// Token: 0x04004738 RID: 18232
	private ERoleTrialFlowState RoleTrialState;
}
