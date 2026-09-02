using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

// Token: 0x02002286 RID: 8838
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MotionModel : ModelBase<MotionModel>
{
	// Token: 0x06010B4E RID: 68430 RVA: 0x00493224 File Offset: 0x00491424
	public void OnMotionUnlock(int roleId, int motionId)
	{
		this.ClearRoleMapMotion(roleId, motionId);
		this.TryAddUnLockMotion(roleId, motionId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.UpdateRoleFavorData, roleId);
		Singleton<EventSystem>.Instance.Emit<int, int>(EEventName.UnLockRoleFavorItem, roleId, motionId);
	}

	// Token: 0x06010B4F RID: 68431 RVA: 0x00493259 File Offset: 0x00491459
	public void OnNewMotionCanUnlock(int roleId, int motionId)
	{
		this.ClearRoleMapMotion(roleId, motionId);
		this.TryAddCanUnLockMotion(roleId, motionId);
	}

	// Token: 0x06010B50 RID: 68432 RVA: 0x0049326C File Offset: 0x0049146C
	public void OnRoleMotionActive(RoleMotionActiveNotify message)
	{
		RoleMotion roleMotionInfo = message.RoleMotionInfo;
		if (roleMotionInfo == null || roleMotionInfo.MotionIds == null)
		{
			return;
		}
		foreach (FavorItem favorItem in roleMotionInfo.MotionIds)
		{
			this.ClearRoleMapMotion(roleMotionInfo.RoleId, favorItem.Id);
			if (favorItem.Status == FavorItemStatus.ItemLocked)
			{
				this.TryAddLockMotion(roleMotionInfo.RoleId, favorItem.Id);
			}
			else if (favorItem.Status == FavorItemStatus.ItemUnLocked)
			{
				this.TryAddUnLockMotion(roleMotionInfo.RoleId, favorItem.Id);
			}
			else if (favorItem.Status == FavorItemStatus.ItemCanUnLock)
			{
				this.TryAddCanUnLockMotion(roleMotionInfo.RoleId, favorItem.Id);
			}
		}
	}

	// Token: 0x06010B51 RID: 68433 RVA: 0x0049332C File Offset: 0x0049152C
	public void OnGetAllRoleMotionInfo(RoleMotionListNotify message)
	{
		this.CurrentUnlockMotionsMap.Clear();
		this.CurrentLockMotionMap.Clear();
		this.CurrentCanUnlockMotionMap.Clear();
		foreach (RoleMotion roleMotion in message.MotionList)
		{
			if (roleMotion.MotionIds != null)
			{
				foreach (FavorItem favorItem in roleMotion.MotionIds)
				{
					this.ClearRoleMapMotion(roleMotion.RoleId, favorItem.Id);
					if (favorItem.Status == FavorItemStatus.ItemLocked)
					{
						this.TryAddLockMotion(roleMotion.RoleId, favorItem.Id);
					}
					else if (favorItem.Status == FavorItemStatus.ItemUnLocked)
					{
						this.TryAddUnLockMotion(roleMotion.RoleId, favorItem.Id);
					}
					else if (favorItem.Status == FavorItemStatus.ItemCanUnLock)
					{
						this.TryAddCanUnLockMotion(roleMotion.RoleId, favorItem.Id);
					}
				}
			}
		}
		foreach (KeyValuePair<int, ConditionInfo> keyValuePair in message.RoleConditionInfoMap)
		{
			int key = keyValuePair.Key;
			this.UpdateCondition(key, keyValuePair.Value);
		}
	}

	// Token: 0x06010B52 RID: 68434 RVA: 0x00493494 File Offset: 0x00491694
	public void OnMotionFinishCondition(RoleMotionFinishConditionNotify message)
	{
		foreach (KeyValuePair<int, ConditionInfo> keyValuePair in message.RoleConditionInfoMap)
		{
			int key = keyValuePair.Key;
			this.UpdateCondition(key, keyValuePair.Value);
		}
	}

	// Token: 0x06010B53 RID: 68435 RVA: 0x004934F0 File Offset: 0x004916F0
	public MotionModel.EMotionState GetRoleMotionState(int roleId, int motionId)
	{
		HashSet<int> hashSet;
		if (this.CurrentUnlockMotionsMap.TryGetValue(roleId, out hashSet) && hashSet.Contains(motionId))
		{
			return MotionModel.EMotionState.Unlock;
		}
		if (this.CurrentLockMotionMap.TryGetValue(roleId, out hashSet) && hashSet.Contains(motionId))
		{
			return MotionModel.EMotionState.Lock;
		}
		if (this.CurrentCanUnlockMotionMap.TryGetValue(roleId, out hashSet) && hashSet.Contains(motionId))
		{
			return MotionModel.EMotionState.CanUnlock;
		}
		return MotionModel.EMotionState.Lock;
	}

	// Token: 0x06010B54 RID: 68436 RVA: 0x00493550 File Offset: 0x00491750
	public bool IsCondtionFinish(int roleId, int id, int conditionId)
	{
		Dictionary<int, Dictionary<int, List<int>>> dictionary;
		if (!this.RoleFavorConditionMap.TryGetValue(roleId, out dictionary))
		{
			return false;
		}
		Dictionary<int, List<int>> dictionary2;
		if (!dictionary.TryGetValue(0, out dictionary2))
		{
			return false;
		}
		List<int> list;
		if (!dictionary2.TryGetValue(id, out list))
		{
			return false;
		}
		int count = list.Count;
		for (int i = 0; i < count; i++)
		{
			if (list[i] == conditionId)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06010B55 RID: 68437 RVA: 0x004935B0 File Offset: 0x004917B0
	public void UpdateCondition(int roleId, ConditionInfo conditionInfo)
	{
		Dictionary<int, Dictionary<int, List<int>>> dictionary;
		if (!this.RoleFavorConditionMap.TryGetValue(roleId, out dictionary))
		{
			dictionary = new Dictionary<int, Dictionary<int, List<int>>>();
		}
		foreach (KeyValuePair<int, ConditionItem> keyValuePair in conditionInfo.FinishConditionMap)
		{
			int key = keyValuePair.Key;
			MapField<int, ItemFinishList> itemFinishMap = keyValuePair.Value.ItemFinishMap;
			Dictionary<int, List<int>> dictionary2;
			if (!dictionary.TryGetValue(key, out dictionary2))
			{
				dictionary2 = new Dictionary<int, List<int>>();
			}
			foreach (KeyValuePair<int, ItemFinishList> keyValuePair2 in itemFinishMap)
			{
				int key2 = keyValuePair2.Key;
				RepeatedField<int> conditionIdList = keyValuePair2.Value.ConditionIdList;
				List<int> list;
				if (!dictionary2.TryGetValue(key2, out list))
				{
					list = new List<int>();
				}
				int count = conditionIdList.Count;
				for (int i = 0; i < count; i++)
				{
					int item = conditionIdList[i];
					list.Add(item);
				}
				dictionary2[key2] = list;
			}
			dictionary[key] = dictionary2;
		}
		this.RoleFavorConditionMap[roleId] = dictionary;
	}

	// Token: 0x06010B56 RID: 68438 RVA: 0x004936E8 File Offset: 0x004918E8
	private void ClearRoleMapMotion(int roleId, int motionId)
	{
		HashSet<int> hashSet;
		if (this.CurrentUnlockMotionsMap.TryGetValue(roleId, out hashSet))
		{
			hashSet.Remove(motionId);
		}
		HashSet<int> hashSet2;
		if (this.CurrentLockMotionMap.TryGetValue(roleId, out hashSet2))
		{
			hashSet2.Remove(motionId);
		}
		HashSet<int> hashSet3;
		if (this.CurrentCanUnlockMotionMap.TryGetValue(roleId, out hashSet3))
		{
			hashSet3.Remove(motionId);
		}
	}

	// Token: 0x06010B57 RID: 68439 RVA: 0x00493740 File Offset: 0x00491940
	private void TryAddUnLockMotion(int roleId, int motionId)
	{
		HashSet<int> hashSet;
		if (this.CurrentUnlockMotionsMap.TryGetValue(roleId, out hashSet))
		{
			hashSet.Add(motionId);
			return;
		}
		HashSet<int> hashSet2 = new HashSet<int>();
		hashSet2.Add(motionId);
		this.CurrentUnlockMotionsMap[roleId] = hashSet2;
	}

	// Token: 0x06010B58 RID: 68440 RVA: 0x00493784 File Offset: 0x00491984
	private void TryAddCanUnLockMotion(int roleId, int motionId)
	{
		HashSet<int> hashSet;
		if (this.CurrentCanUnlockMotionMap.TryGetValue(roleId, out hashSet))
		{
			hashSet.Add(motionId);
			return;
		}
		HashSet<int> hashSet2 = new HashSet<int>();
		hashSet2.Add(motionId);
		this.CurrentCanUnlockMotionMap[roleId] = hashSet2;
	}

	// Token: 0x06010B59 RID: 68441 RVA: 0x004937C8 File Offset: 0x004919C8
	private void TryAddLockMotion(int roleId, int motionId)
	{
		HashSet<int> hashSet;
		if (this.CurrentLockMotionMap.TryGetValue(roleId, out hashSet))
		{
			hashSet.Add(motionId);
			return;
		}
		HashSet<int> hashSet2 = new HashSet<int>();
		hashSet2.Add(motionId);
		this.CurrentLockMotionMap[roleId] = hashSet2;
	}

	// Token: 0x06010B5A RID: 68442 RVA: 0x0049380C File Offset: 0x00491A0C
	public bool IfRoleMotionCanUnlock(int roleId)
	{
		HashSet<int> hashSet;
		return this.CurrentCanUnlockMotionMap.TryGetValue(roleId, out hashSet) && hashSet.Count > 0;
	}

	// Token: 0x040083DE RID: 33758
	private readonly Dictionary<int, HashSet<int>> CurrentUnlockMotionsMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x040083DF RID: 33759
	private readonly Dictionary<int, HashSet<int>> CurrentCanUnlockMotionMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x040083E0 RID: 33760
	private readonly Dictionary<int, HashSet<int>> CurrentLockMotionMap = new Dictionary<int, HashSet<int>>();

	// Token: 0x040083E1 RID: 33761
	private readonly Dictionary<int, Dictionary<int, Dictionary<int, List<int>>>> RoleFavorConditionMap = new Dictionary<int, Dictionary<int, Dictionary<int, List<int>>>>();

	// Token: 0x0200854B RID: 34123
	[NullableContext(0)]
	public enum EMotionState
	{
		// Token: 0x0402D1C8 RID: 184776
		Lock,
		// Token: 0x0402D1C9 RID: 184777
		CanUnlock,
		// Token: 0x0402D1CA RID: 184778
		Unlock
	}
}
