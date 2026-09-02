using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.ServerStorage;
using CSharpScript.Game.ServerStorage.Container;

// Token: 0x020010AA RID: 4266
[NullableContext(1)]
[Nullable(0)]
public class GolemHackingActivityData : ActivityBaseData
{
	// Token: 0x06006F35 RID: 28469 RVA: 0x001CED90 File Offset: 0x001CCF90
	protected override void OnInit(ActivityData data)
	{
		GolemCrackActivityInfo golemCrackActivityInfo = data.GolemCrackActivityInfo;
		if (golemCrackActivityInfo == null)
		{
			return;
		}
		this.UpdateLevelInfo(golemCrackActivityInfo.GolemCrackLevelInfos);
	}

	// Token: 0x06006F36 RID: 28470 RVA: 0x001CEDB4 File Offset: 0x001CCFB4
	protected override void PhraseEx(ActivityData data)
	{
		GolemCrackActivityInfo golemCrackActivityInfo = data.GolemCrackActivityInfo;
		if (golemCrackActivityInfo == null)
		{
			return;
		}
		this.UpdateLevelInfo(golemCrackActivityInfo.GolemCrackLevelInfos);
	}

	// Token: 0x06006F37 RID: 28471 RVA: 0x001CEDD8 File Offset: 0x001CCFD8
	public override bool GetExDataRedPointShowState()
	{
		return this.CheckRedDot();
	}

	// Token: 0x06006F38 RID: 28472 RVA: 0x001CEDE0 File Offset: 0x001CCFE0
	protected override bool GetExDataFinishShowState()
	{
		ValueTuple<int, int> groupProgressState = this.GetGroupProgressState();
		int item = groupProgressState.Item1;
		int item2 = groupProgressState.Item2;
		return item == item2;
	}

	// Token: 0x06006F39 RID: 28473 RVA: 0x001CEE04 File Offset: 0x001CD004
	public int? GetCurrentId()
	{
		return this.CurrentConfigId;
	}

	// Token: 0x06006F3A RID: 28474 RVA: 0x001CEE0C File Offset: 0x001CD00C
	public void SetCurrentId(int? currentId)
	{
		this.CurrentConfigId = currentId;
	}

	// Token: 0x06006F3B RID: 28475 RVA: 0x001CEE18 File Offset: 0x001CD018
	public void UpdateLevelInfo(IEnumerable<GolemCrackLevelInfo> levels)
	{
		foreach (GolemCrackLevelInfo golemCrackLevelInfo in levels)
		{
			if (!this.LevelInfo.ContainsKey(golemCrackLevelInfo.Id))
			{
				GolemCrack value = ConfigGolemCrackById.GetConfig(golemCrackLevelInfo.Id, true).Value;
				GolemHackingLevelInfo value2 = new GolemHackingLevelInfo
				{
					LevelId = golemCrackLevelInfo.Id,
					UnlockTime = this.GetUnlockTime(golemCrackLevelInfo.UnlockTime),
					UnlockId = value.UnlockId,
					State = golemCrackLevelInfo.State
				};
				this.LevelInfo[golemCrackLevelInfo.Id] = value2;
				int group = value.Group;
				if (!this.LevelGroup.ContainsKey(group))
				{
					GolemHackingLevelGroupInfo value3 = new GolemHackingLevelGroupInfo
					{
						Group = group,
						LevelGroup = new List<int>()
					};
					this.LevelGroup[group] = value3;
				}
				this.LevelGroup[group].LevelGroup.Add(golemCrackLevelInfo.Id);
				if (value.UnlockId != golemCrackLevelInfo.Id)
				{
					if (!this.LevelUnlock.ContainsKey(value.UnlockId))
					{
						this.LevelUnlock[value.UnlockId] = new List<int>();
					}
					this.LevelUnlock[value.UnlockId].Add(golemCrackLevelInfo.Id);
				}
			}
			else
			{
				GolemHackingLevelInfo golemHackingLevelInfo = this.LevelInfo[golemCrackLevelInfo.Id];
				golemHackingLevelInfo.UnlockTime = this.GetUnlockTime(golemCrackLevelInfo.UnlockTime);
				golemHackingLevelInfo.State = golemCrackLevelInfo.State;
			}
		}
	}

	// Token: 0x06006F3C RID: 28476 RVA: 0x001CEFCC File Offset: 0x001CD1CC
	private long GetUnlockTime(long time)
	{
		return time;
	}

	// Token: 0x06006F3D RID: 28477 RVA: 0x001CEFD0 File Offset: 0x001CD1D0
	public void OnLevelClear(int unlockLevelId)
	{
		List<int> list;
		bool flag = this.LevelUnlock.TryGetValue(unlockLevelId, out list);
		this.LevelInfo[unlockLevelId].State = GolemCrackState.GolemCrackFinished;
		if (!flag)
		{
			return;
		}
		foreach (int key in list)
		{
			GolemHackingLevelInfo golemHackingLevelInfo = this.LevelInfo[key];
			if (golemHackingLevelInfo.State == GolemCrackState.GolemCrackLocked && (double)golemHackingLevelInfo.UnlockTime <= Singleton<TimeUtil>.Instance.GetServerTime())
			{
				golemHackingLevelInfo.State = GolemCrackState.GolemCrackUnlocked;
			}
		}
	}

	// Token: 0x06006F3E RID: 28478 RVA: 0x001CF06C File Offset: 0x001CD26C
	[NullableContext(0)]
	public ValueTuple<int, int> GetGroupProgressState()
	{
		bool flag = true;
		int num = 0;
		int num2 = 0;
		foreach (KeyValuePair<int, GolemHackingLevelGroupInfo> keyValuePair in this.LevelGroup)
		{
			int num3;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo;
			keyValuePair.Deconstruct(out num3, out golemHackingLevelGroupInfo);
			int num4 = num3;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo2 = golemHackingLevelGroupInfo;
			if (num4 != 7)
			{
				num2 += golemHackingLevelGroupInfo2.LevelGroup.Count;
				foreach (int key in golemHackingLevelGroupInfo2.LevelGroup)
				{
					GolemHackingLevelInfo golemHackingLevelInfo = this.LevelInfo[key];
					num += ((golemHackingLevelInfo.State == GolemCrackState.GolemCrackFinished) ? 1 : 0);
					if (golemHackingLevelInfo.State != GolemCrackState.GolemCrackFinished)
					{
						flag = false;
					}
				}
			}
		}
		GolemHackingLevelGroupInfo golemHackingLevelGroupInfo3;
		if (num2 > 0 && flag && this.LevelGroup.TryGetValue(7, out golemHackingLevelGroupInfo3))
		{
			num2 += golemHackingLevelGroupInfo3.LevelGroup.Count;
			foreach (int key2 in golemHackingLevelGroupInfo3.LevelGroup)
			{
				GolemHackingLevelInfo golemHackingLevelInfo2 = this.LevelInfo[key2];
				num += ((golemHackingLevelInfo2.State == GolemCrackState.GolemCrackFinished) ? 1 : 0);
			}
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x06006F3F RID: 28479 RVA: 0x001CF1D8 File Offset: 0x001CD3D8
	[NullableContext(0)]
	public ValueTuple<EGolemHackingGroupState, int, int> GetGroupState(int id)
	{
		int num = 0;
		int num2 = 0;
		GolemHackingLevelGroupInfo golemHackingLevelGroupInfo = this.LevelGroup[id];
		foreach (int key in golemHackingLevelGroupInfo.LevelGroup)
		{
			GolemHackingLevelInfo golemHackingLevelInfo = this.LevelInfo[key];
			num += ((golemHackingLevelInfo.State == GolemCrackState.GolemCrackFinished) ? 1 : 0);
			num2 += ((golemHackingLevelInfo.State == GolemCrackState.GolemCrackLocked) ? 1 : 0);
		}
		if (num == golemHackingLevelGroupInfo.LevelGroup.Count)
		{
			return new ValueTuple<EGolemHackingGroupState, int, int>(EGolemHackingGroupState.Clear, num, num);
		}
		if (num2 == golemHackingLevelGroupInfo.LevelGroup.Count)
		{
			return new ValueTuple<EGolemHackingGroupState, int, int>(EGolemHackingGroupState.Locked, num2, num2);
		}
		return new ValueTuple<EGolemHackingGroupState, int, int>(EGolemHackingGroupState.Normal, num, golemHackingLevelGroupInfo.LevelGroup.Count);
	}

	// Token: 0x06006F40 RID: 28480 RVA: 0x001CF2A0 File Offset: 0x001CD4A0
	public List<GolemHackingLevelGroupInfo> GetLevelGroupList()
	{
		List<GolemHackingLevelGroupInfo> list = new List<GolemHackingLevelGroupInfo>();
		bool flag = true;
		foreach (KeyValuePair<int, GolemHackingLevelGroupInfo> keyValuePair in this.LevelGroup)
		{
			int num;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo;
			keyValuePair.Deconstruct(out num, out golemHackingLevelGroupInfo);
			int num2 = num;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo2 = golemHackingLevelGroupInfo;
			if (num2 != 7)
			{
				list.Add(golemHackingLevelGroupInfo2);
				foreach (int key in golemHackingLevelGroupInfo2.LevelGroup)
				{
					if (this.LevelInfo[key].State != GolemCrackState.GolemCrackFinished)
					{
						flag = false;
					}
				}
			}
		}
		GolemHackingLevelGroupInfo item;
		if (flag && this.LevelGroup.TryGetValue(7, out item))
		{
			list.Add(item);
		}
		list.Sort((GolemHackingLevelGroupInfo a, GolemHackingLevelGroupInfo b) => a.Group - b.Group);
		return list;
	}

	// Token: 0x06006F41 RID: 28481 RVA: 0x001CF3A4 File Offset: 0x001CD5A4
	public GolemHackingLevelGroupInfo GetGroupLevels(int groupId)
	{
		return this.LevelGroup[groupId];
	}

	// Token: 0x06006F42 RID: 28482 RVA: 0x001CF3B4 File Offset: 0x001CD5B4
	[return: Nullable(new byte[]
	{
		0,
		1
	})]
	public ValueTuple<bool, string> GetGroupLockTxt(int groupId)
	{
		int key = this.LevelGroup[groupId].LevelGroup[0];
		GolemHackingLevelInfo golemHackingLevelInfo = this.LevelInfo[key];
		if (Singleton<TimeUtil>.Instance.GetServerTime() >= (double)golemHackingLevelInfo.UnlockTime)
		{
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("IntrusionProtocolActivity_Locked");
			return new ValueTuple<bool, string>(false, configTextByKey);
		}
		string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("IntrusionProtocolActivity_NotOpened");
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(golemHackingLevelInfo.UnlockTime, configTextByKey2);
		return new ValueTuple<bool, string>(true, remainTimeText);
	}

	// Token: 0x06006F43 RID: 28483 RVA: 0x001CF43C File Offset: 0x001CD63C
	public void GetGroupLockTips(int groupId)
	{
		int key = this.LevelGroup[groupId].LevelGroup[0];
		GolemHackingLevelInfo golemHackingLevelInfo = this.LevelInfo[key];
		if (Singleton<TimeUtil>.Instance.GetServerTime() >= (double)golemHackingLevelInfo.UnlockTime)
		{
			string configTextByKey = Singleton<PublicUtil>.Instance.GetConfigTextByKey("IntrusionProtocolActivity_LockedTips");
			ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(configTextByKey);
			return;
		}
		string configTextByKey2 = Singleton<PublicUtil>.Instance.GetConfigTextByKey("IntrusionProtocolActivity_NotOpenedTips");
		string remainTimeText = ModelBase<ActivityModel>.Instance.GetRemainTimeText(golemHackingLevelInfo.UnlockTime, configTextByKey2);
		ControllerBase<ScrollingTipsController>.Instance.ShowTipsByText(remainTimeText);
	}

	// Token: 0x06006F44 RID: 28484 RVA: 0x001CF4CC File Offset: 0x001CD6CC
	public GolemHackingLevelInfo GetLevelInfo(int levelId)
	{
		return this.LevelInfo[levelId];
	}

	// Token: 0x06006F45 RID: 28485 RVA: 0x001CF4DC File Offset: 0x001CD6DC
	public bool CheckRedDot()
	{
		bool flag = this.IsBonusGroupUnlocked();
		foreach (KeyValuePair<int, GolemHackingLevelGroupInfo> keyValuePair in this.LevelGroup)
		{
			int num;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo;
			keyValuePair.Deconstruct(out num, out golemHackingLevelGroupInfo);
			int num2 = num;
			if ((num2 != 7 || flag) && this.CheckGroupRedDot(num2))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06006F46 RID: 28486 RVA: 0x001CF558 File Offset: 0x001CD758
	private bool IsBonusGroupUnlocked()
	{
		foreach (KeyValuePair<int, GolemHackingLevelGroupInfo> keyValuePair in this.LevelGroup)
		{
			int num;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo;
			keyValuePair.Deconstruct(out num, out golemHackingLevelGroupInfo);
			int num2 = num;
			GolemHackingLevelGroupInfo golemHackingLevelGroupInfo2 = golemHackingLevelGroupInfo;
			if (num2 != 7)
			{
				foreach (int key in golemHackingLevelGroupInfo2.LevelGroup)
				{
					if (this.LevelInfo[key].State != GolemCrackState.GolemCrackFinished)
					{
						return false;
					}
				}
			}
		}
		return true;
	}

	// Token: 0x06006F47 RID: 28487 RVA: 0x001CF614 File Offset: 0x001CD814
	public bool CheckGroupRedDot(int groupId)
	{
		GolemHackingLevelGroupInfo golemHackingLevelGroupInfo;
		if (!this.LevelGroup.TryGetValue(groupId, out golemHackingLevelGroupInfo))
		{
			return false;
		}
		foreach (int levelId in golemHackingLevelGroupInfo.LevelGroup)
		{
			if (this.CheckLevelRedDot(levelId))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06006F48 RID: 28488 RVA: 0x001CF684 File Offset: 0x001CD884
	public bool CheckLevelRedDot(int levelId)
	{
		GolemHackingLevelInfo golemHackingLevelInfo;
		if (this.LevelInfo.TryGetValue(levelId, out golemHackingLevelInfo) && golemHackingLevelInfo.State == GolemCrackState.GolemCrackLocked)
		{
			return false;
		}
		GolemCrack? config = ConfigGolemCrackById.GetConfig(levelId, true);
		if (config == null)
		{
			return false;
		}
		ServerStorageMap serverStorageMap = ModelBase<ServerStorageModel>.Instance.Get(EClientStorageSystemIdType.GolemCrack) as ServerStorageMap;
		for (int i = 0; i < config.Value.ConfigIdsLength; i++)
		{
			int key = config.Value.ConfigIds(i);
			if (serverStorageMap == null || serverStorageMap.Get(key) != null)
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x06006F49 RID: 28489 RVA: 0x001CF718 File Offset: 0x001CD918
	public void CheckIsUnlockWhenTimeUnlock(int groupId)
	{
		foreach (int num in this.LevelGroup[groupId].LevelGroup)
		{
			foreach (KeyValuePair<int, List<int>> keyValuePair in this.LevelUnlock)
			{
				int num2;
				List<int> list;
				keyValuePair.Deconstruct(out num2, out list);
				int key = num2;
				if (list.Contains(num) && this.LevelInfo[key].State == GolemCrackState.GolemCrackFinished)
				{
					this.LevelInfo[num].State = GolemCrackState.GolemCrackUnlocked;
				}
			}
		}
	}

	// Token: 0x04003537 RID: 13623
	protected Dictionary<int, GolemHackingLevelGroupInfo> LevelGroup = new Dictionary<int, GolemHackingLevelGroupInfo>();

	// Token: 0x04003538 RID: 13624
	protected Dictionary<int, List<int>> LevelUnlock = new Dictionary<int, List<int>>();

	// Token: 0x04003539 RID: 13625
	protected Dictionary<int, GolemHackingLevelInfo> LevelInfo = new Dictionary<int, GolemHackingLevelInfo>();

	// Token: 0x0400353A RID: 13626
	protected int? CurrentConfigId;
}
