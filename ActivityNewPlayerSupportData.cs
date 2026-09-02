using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.RoleUi;
using Google.Protobuf.Collections;

// Token: 0x02001468 RID: 5224
[NullableContext(1)]
[Nullable(0)]
public class ActivityNewPlayerSupportData : ActivityBaseData
{
	// Token: 0x17000C1F RID: 3103
	// (get) Token: 0x0600920D RID: 37389 RVA: 0x0026884F File Offset: 0x00266A4F
	// (set) Token: 0x0600920E RID: 37390 RVA: 0x00268857 File Offset: 0x00266A57
	public bool AlreadyStartView
	{
		get
		{
			return this.IsAlreadyStartView;
		}
		set
		{
			this.IsAlreadyStartView = value;
		}
	}

	// Token: 0x17000C20 RID: 3104
	// (get) Token: 0x0600920F RID: 37391 RVA: 0x00268860 File Offset: 0x00266A60
	public bool IsActivityFirstShow
	{
		get
		{
			return this.IsFirstShow;
		}
	}

	// Token: 0x17000C21 RID: 3105
	// (get) Token: 0x06009210 RID: 37392 RVA: 0x00268868 File Offset: 0x00266A68
	public int? CurUseTrialRoleId
	{
		get
		{
			TrialRoleGroupData curUseTrialRole = ModelBase<TrialRoleModel>.Instance.GetCurUseTrialRole(ETrialRoleType.NewbieSupportTrial);
			if (curUseTrialRole == null)
			{
				return null;
			}
			return new int?(curUseTrialRole.TrialRoleId);
		}
	}

	// Token: 0x17000C22 RID: 3106
	// (get) Token: 0x06009211 RID: 37393 RVA: 0x00268898 File Offset: 0x00266A98
	[Nullable(2)]
	public TrialRoleGroupData CurUseTrialRoleData
	{
		[NullableContext(2)]
		get
		{
			return ModelBase<TrialRoleModel>.Instance.GetCurUseTrialRole(ETrialRoleType.NewbieSupportTrial);
		}
	}

	// Token: 0x06009212 RID: 37394 RVA: 0x002688A5 File Offset: 0x00266AA5
	protected override void OnInit(ActivityData data)
	{
		this.IsFirstShow = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityNewPlayerSupportFirstShow, false);
	}

	// Token: 0x06009213 RID: 37395 RVA: 0x002688B8 File Offset: 0x00266AB8
	protected override void PhraseEx(ActivityData data)
	{
		NewPlayerSupportActivityData newPlayerSupportActivityData = data.NewPlayerSupportActivityData;
		if (newPlayerSupportActivityData == null)
		{
			return;
		}
		this.ParseTrialRoles(newPlayerSupportActivityData.TrialRoleInfoList);
		this.ParseTaskInfos(newPlayerSupportActivityData.ConditionTasks);
		this.ParseCurUseTrialRole(newPlayerSupportActivityData.CurUseTrialRoleId, newPlayerSupportActivityData.CurUseRoleInfo);
		this.HaveFinishCarnivalRole = newPlayerSupportActivityData.NewPlayerPoolFinalGachaRoleId;
		this.CheckIsFirstShow();
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityNewPlayerSupportInfoUpdate);
	}

	// Token: 0x06009214 RID: 37396 RVA: 0x0026891C File Offset: 0x00266B1C
	[NullableContext(2)]
	private void ParseCurUseTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		if (!RoleUtils.IsTrialRole(trialRoleId))
		{
			return;
		}
		ModelBase<TrialRoleModel>.Instance.SetCurUseTrialRole(trialRoleId, trialRoleInfo);
	}

	// Token: 0x06009215 RID: 37397 RVA: 0x00268934 File Offset: 0x00266B34
	private void ParseTrialRoles(RepeatedField<NewTrialRoleInfo> roleList)
	{
		List<ITrialRoleCreateData> list = new List<ITrialRoleCreateData>();
		HashSet<int> hashSet = new HashSet<int>();
		foreach (NewTrialRoleInfo newTrialRoleInfo in roleList)
		{
			list.Add(new TrialRoleCreateData
			{
				TrialRoleId = newTrialRoleInfo.TrialRoleId,
				IsUnlocked = true
			});
			TrialRoleConfig instance = ConfigBase<TrialRoleConfig>.Instance;
			int? num = (instance != null) ? instance.GetTrialRoleGroupId(newTrialRoleInfo.TrialRoleId) : null;
			if (num != null)
			{
				hashSet.Add(num.Value);
			}
		}
		TrialRoleConfig instance2 = ConfigBase<TrialRoleConfig>.Instance;
		Dictionary<int, List<TrialRoleInfo>> dictionary = (instance2 != null) ? instance2.GetTrialRoleAllConfigByType(ETrialRoleType.NewbieSupportTrial) : null;
		if (dictionary != null)
		{
			foreach (KeyValuePair<int, List<TrialRoleInfo>> keyValuePair in dictionary)
			{
				int key = keyValuePair.Key;
				List<TrialRoleInfo> value = keyValuePair.Value;
				if (!hashSet.Contains(key) && value.Count > 0)
				{
					list.Add(new TrialRoleCreateData
					{
						TrialRoleId = value[0].Id,
						IsUnlocked = false
					});
				}
			}
		}
		ModelBase<TrialRoleModel>.Instance.AddTrialRoles(list);
	}

	// Token: 0x06009216 RID: 37398 RVA: 0x00268A84 File Offset: 0x00266C84
	private void ParseTaskInfos(RepeatedField<ConditionTask> tasks)
	{
		this.TaskDataList = new List<ActivityNewPlayerSupportTaskData>();
		this.UpdateTaskData(tasks);
	}

	// Token: 0x06009217 RID: 37399 RVA: 0x00268A98 File Offset: 0x00266C98
	private ActivityNewPlayerSupportTaskData GetOrCreateTaskData(int taskId)
	{
		ActivityNewPlayerSupportTaskData activityNewPlayerSupportTaskData = this.GetTaskData(taskId);
		if (activityNewPlayerSupportTaskData == null)
		{
			activityNewPlayerSupportTaskData = new ActivityNewPlayerSupportTaskData(taskId);
			this.TaskDataList.Add(activityNewPlayerSupportTaskData);
		}
		return activityNewPlayerSupportTaskData;
	}

	// Token: 0x06009218 RID: 37400 RVA: 0x00268AC4 File Offset: 0x00266CC4
	private int SortTaskData(ActivityNewPlayerSupportTaskData a, ActivityNewPlayerSupportTaskData b)
	{
		return a.Id - b.Id;
	}

	// Token: 0x06009219 RID: 37401 RVA: 0x00268AD3 File Offset: 0x00266CD3
	public List<ActivityNewPlayerSupportTaskData> GetTaskDataList()
	{
		this.TaskDataList.Sort(new Comparison<ActivityNewPlayerSupportTaskData>(this.SortTaskData));
		return this.TaskDataList;
	}

	// Token: 0x0600921A RID: 37402 RVA: 0x00268AF4 File Offset: 0x00266CF4
	[NullableContext(2)]
	public ActivityNewPlayerSupportTaskData GetTaskData(int id)
	{
		foreach (ActivityNewPlayerSupportTaskData activityNewPlayerSupportTaskData in this.TaskDataList)
		{
			if (activityNewPlayerSupportTaskData.Id == id)
			{
				return activityNewPlayerSupportTaskData;
			}
		}
		return null;
	}

	// Token: 0x0600921B RID: 37403 RVA: 0x00268B50 File Offset: 0x00266D50
	public List<int> GetCanReceiveTaskIdList()
	{
		List<int> list = new List<int>();
		foreach (ActivityNewPlayerSupportTaskData activityNewPlayerSupportTaskData in this.TaskDataList)
		{
			if (activityNewPlayerSupportTaskData.CanReceiveReward())
			{
				list.Add(activityNewPlayerSupportTaskData.Id);
			}
		}
		return list;
	}

	// Token: 0x0600921C RID: 37404 RVA: 0x00268BB8 File Offset: 0x00266DB8
	public List<TrialRoleGroupData> GetTrialRoleList()
	{
		return ModelBase<TrialRoleModel>.Instance.GetDataListByType(ETrialRoleType.NewbieSupportTrial);
	}

	// Token: 0x0600921D RID: 37405 RVA: 0x00268BC5 File Offset: 0x00266DC5
	[NullableContext(2)]
	public TrialRoleGroupData GetTrialRoleByGroupId(int groupId)
	{
		return ModelBase<TrialRoleModel>.Instance.GetDataByGroupId(groupId);
	}

	// Token: 0x0600921E RID: 37406 RVA: 0x00268BD2 File Offset: 0x00266DD2
	[NullableContext(2)]
	public void UpdateCurUseTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		ModelBase<TrialRoleModel>.Instance.SetCurUseTrialRole(trialRoleId, trialRoleInfo);
	}

	// Token: 0x0600921F RID: 37407 RVA: 0x00268BE0 File Offset: 0x00266DE0
	public void UpdateTaskData(RepeatedField<ConditionTask> taskData)
	{
		foreach (ConditionTask conditionTask in taskData)
		{
			this.GetOrCreateTaskData(conditionTask.Id).Refresh(conditionTask);
		}
	}

	// Token: 0x06009220 RID: 37408 RVA: 0x00268C34 File Offset: 0x00266E34
	[NullableContext(2)]
	public void UpdateActivatedTrialRole(int trialRoleId, roleInfo trialRoleInfo)
	{
		ModelBase<TrialRoleModel>.Instance.SetGroupTrialRoleId(trialRoleId, trialRoleInfo);
	}

	// Token: 0x06009221 RID: 37409 RVA: 0x00268C44 File Offset: 0x00266E44
	public string GetDesc()
	{
		return ConfigMultiTextLang.GetLocalTextNew(this.LocalConfig.Value.Desc, null);
	}

	// Token: 0x06009222 RID: 37410 RVA: 0x00268C6C File Offset: 0x00266E6C
	public bool HasUnlockTrialRole()
	{
		using (List<TrialRoleGroupData>.Enumerator enumerator = this.GetTrialRoleList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.IsUnlocked())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06009223 RID: 37411 RVA: 0x00268CC8 File Offset: 0x00266EC8
	public int? GetFirstUnFinishMainQuestId()
	{
		global::Quest firstShowQuestByType = ModelBase<QuestNewModel>.Instance.GetFirstShowQuestByType(1);
		if (firstShowQuestByType == null)
		{
			return null;
		}
		return new int?(firstShowQuestByType.Id);
	}

	// Token: 0x06009224 RID: 37412 RVA: 0x00268CF8 File Offset: 0x00266EF8
	public override bool GetExDataRedPointShowState()
	{
		return this.IsHasRewardRedPoint() || this.IsTrialRoleUpgradeRedPoint() || this.IsTrialRoleEntranceRedDot() || this.IsAdventureEntranceRedDot();
	}

	// Token: 0x06009225 RID: 37413 RVA: 0x00268D1C File Offset: 0x00266F1C
	public bool IsHasRewardRedPoint()
	{
		using (List<ActivityNewPlayerSupportTaskData>.Enumerator enumerator = this.TaskDataList.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CanReceiveReward())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06009226 RID: 37414 RVA: 0x00268D78 File Offset: 0x00266F78
	public bool IsTrialRoleUpgradeRedPoint()
	{
		using (List<TrialRoleGroupData>.Enumerator enumerator = this.GetTrialRoleList().GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.CanUpgrade())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06009227 RID: 37415 RVA: 0x00268DD4 File Offset: 0x00266FD4
	public bool IsTrialRoleEntranceRedDot()
	{
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.NewPlayerSupportTrialRoleEntranceRedDot, false);
	}

	// Token: 0x06009228 RID: 37416 RVA: 0x00268DE1 File Offset: 0x00266FE1
	public bool IsAdventureEntranceRedDot()
	{
		return !LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityRegressAdventureRedDotCheckedInPeriod, false);
	}

	// Token: 0x06009229 RID: 37417 RVA: 0x00268DEE File Offset: 0x00266FEE
	public void SaveTrailRoleEntranceRedDot(bool value)
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.NewPlayerSupportTrialRoleEntranceRedDot, value);
		Singleton<EventSystem>.Instance.Emit(EEventName.OnActivityNewPlayerSupportEntranceRedDotUpdate);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x0600922A RID: 37418 RVA: 0x00268E24 File Offset: 0x00267024
	private void CheckIsFirstShow()
	{
		bool player = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityNewPlayerSupportFirstShow, false);
		bool player2 = LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.ActivityNewPlayerSupportFirstShow, true);
		bool? flag = (player == player2) ? new bool?(player) : null;
		if (flag == null)
		{
			LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityNewPlayerSupportFirstShow, true);
		}
	}

	// Token: 0x0600922B RID: 37419 RVA: 0x00268E74 File Offset: 0x00267074
	public void RecordActivityFirstShow()
	{
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.ActivityNewPlayerSupportFirstShow, false);
	}

	// Token: 0x040043A8 RID: 17320
	private List<ActivityNewPlayerSupportTaskData> TaskDataList = new List<ActivityNewPlayerSupportTaskData>();

	// Token: 0x040043A9 RID: 17321
	private bool IsFirstShow;

	// Token: 0x040043AA RID: 17322
	private bool IsAlreadyStartView;

	// Token: 0x040043AB RID: 17323
	public int HaveFinishCarnivalRole;
}
