using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

// Token: 0x02001265 RID: 4709
[NullableContext(1)]
[Nullable(0)]
public class ActivityBlackCoastData : ActivityBaseData
{
	// Token: 0x06007D88 RID: 32136 RVA: 0x00211D70 File Offset: 0x0020FF70
	protected override void OnInit(ActivityData data)
	{
		this.InitProgressReward();
		this.InitStages();
	}

	// Token: 0x06007D89 RID: 32137 RVA: 0x00211D80 File Offset: 0x0020FF80
	protected override void PhraseEx(ActivityData data)
	{
		BlackCoastThemeActivity blackCoastThemeActivityData = data.BlackCoastThemeActivityData;
		if (blackCoastThemeActivityData == null)
		{
			return;
		}
		this.StageUpdate(blackCoastThemeActivityData.Stages.ToArray<BlackCoastThemeStageInfo>());
		foreach (int num in blackCoastThemeActivityData.ActiveRewardedIds)
		{
			BlackCoastProgressRewardData progressRewardDataById = this.GetProgressRewardDataById(num);
			if (progressRewardDataById == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[BlackCoastActivity] 奖励Id不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("RewardId", num);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				progressRewardDataById.Achieved = true;
			}
		}
	}

	// Token: 0x06007D8A RID: 32138 RVA: 0x00211E28 File Offset: 0x00210028
	public override bool NeedSelfControlFirstRedPoint()
	{
		return false;
	}

	// Token: 0x06007D8B RID: 32139 RVA: 0x00211E2B File Offset: 0x0021002B
	public override bool GetExDataRedPointShowState()
	{
		return this.RewardRedDotState();
	}

	// Token: 0x06007D8C RID: 32140 RVA: 0x00211E33 File Offset: 0x00210033
	public bool RewardRedDotState()
	{
		return this.HasProgressRewardRedDot() || this.HasStageRewardRedDot() || this.HasAnyNewStageRedDot();
	}

	// Token: 0x06007D8D RID: 32141 RVA: 0x00211E4D File Offset: 0x0021004D
	public int GetProgressItemCount()
	{
		return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.ProgressItemId, 0);
	}

	// Token: 0x06007D8E RID: 32142 RVA: 0x00211E60 File Offset: 0x00210060
	public int GetProgressItemTotal()
	{
		return this.ProgressItemTotal;
	}

	// Token: 0x17000AB0 RID: 2736
	// (get) Token: 0x06007D8F RID: 32143 RVA: 0x00211E68 File Offset: 0x00210068
	public int GetProgressItemId
	{
		get
		{
			return this.ProgressItemId;
		}
	}

	// Token: 0x06007D90 RID: 32144 RVA: 0x00211E70 File Offset: 0x00210070
	public void InitProgressReward()
	{
		this.ProgressRewardMap.Clear();
		BlackCoastThemeConfig? activityConfig = ConfigBase<ActivityBlackCoastConfig>.Instance.GetActivityConfig(base.Id);
		if (activityConfig == null)
		{
			return;
		}
		this.ProgressItemId = activityConfig.Value.ItemId;
		foreach (BlackCoastThemeRewardRe blackCoastThemeRewardRe in ConfigBase<ActivityBlackCoastConfig>.Instance.GetAllRewardConfigByActivityId(base.Id))
		{
			BlackCoastProgressRewardData blackCoastProgressRewardData = new BlackCoastProgressRewardData();
			blackCoastProgressRewardData.Id = blackCoastThemeRewardRe.Id;
			blackCoastProgressRewardData.Goal = blackCoastThemeRewardRe.Active;
			blackCoastProgressRewardData.DropId = blackCoastThemeRewardRe.DropId;
			blackCoastProgressRewardData.GetCurrentGoal = new Func<int>(this.GetProgressItemCount);
			this.ProgressItemTotal = Math.Max(this.ProgressItemTotal, blackCoastProgressRewardData.Goal);
			this.ProgressRewardMap[blackCoastThemeRewardRe.Id] = blackCoastProgressRewardData;
		}
	}

	// Token: 0x06007D91 RID: 32145 RVA: 0x00211F6C File Offset: 0x0021016C
	private int SortRewardData(BlackCoastProgressRewardData a, BlackCoastProgressRewardData b)
	{
		return a.Goal - b.Goal;
	}

	// Token: 0x06007D92 RID: 32146 RVA: 0x00211F7C File Offset: 0x0021017C
	public BlackCoastProgressRewardData GetProgressRewardDataById(int id)
	{
		BlackCoastProgressRewardData result;
		this.ProgressRewardMap.TryGetValue(id, out result);
		return result;
	}

	// Token: 0x06007D93 RID: 32147 RVA: 0x00211F99 File Offset: 0x00210199
	public BlackCoastProgressRewardData[] GetAllProgressRewardData()
	{
		return (from x in this.ProgressRewardMap.Values
		orderby x.Goal
		select x).ToArray<BlackCoastProgressRewardData>();
	}

	// Token: 0x06007D94 RID: 32148 RVA: 0x00211FD0 File Offset: 0x002101D0
	public int[] GetAllAvailableProgressRewardIds()
	{
		List<int> list = new List<int>();
		foreach (BlackCoastProgressRewardData blackCoastProgressRewardData in this.GetAllProgressRewardData())
		{
			if (blackCoastProgressRewardData.GetState() == EActivityTaskState.FinishedAndUnclaimed)
			{
				list.Add(blackCoastProgressRewardData.Id);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06007D95 RID: 32149 RVA: 0x00212018 File Offset: 0x00210218
	public void SetProgressRewardDataGot(int[] ids)
	{
		foreach (int id in ids)
		{
			BlackCoastProgressRewardData progressRewardDataById = this.GetProgressRewardDataById(id);
			if (progressRewardDataById != null)
			{
				progressRewardDataById.Achieved = true;
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007D96 RID: 32150 RVA: 0x00212064 File Offset: 0x00210264
	public bool HasProgressRewardRedDot()
	{
		using (Dictionary<int, BlackCoastProgressRewardData>.ValueCollection.Enumerator enumerator = this.ProgressRewardMap.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetState() == EActivityTaskState.FinishedAndUnclaimed)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06007D97 RID: 32151 RVA: 0x002120C4 File Offset: 0x002102C4
	public void SetTaskRewardGot(int stageId, int taskId)
	{
		BlackCoastStageInfo blackCoastStageInfo;
		this.Stages.TryGetValue(stageId, out blackCoastStageInfo);
		blackCoastStageInfo.SetTaskRewardGot(taskId);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007D98 RID: 32152 RVA: 0x00212100 File Offset: 0x00210300
	private void InitStages()
	{
		this.Stages.Clear();
		IReadOnlyList<BlackCoastThemeStageRe> allStageConfigByActivityId = ConfigBase<ActivityBlackCoastConfig>.Instance.GetAllStageConfigByActivityId(base.Id);
		for (int i = 0; i < allStageConfigByActivityId.Count; i++)
		{
			BlackCoastThemeStageRe blackCoastThemeStageRe = allStageConfigByActivityId[i];
			BlackCoastStageInfo value = new BlackCoastStageInfo(blackCoastThemeStageRe.Id, i);
			this.Stages[blackCoastThemeStageRe.Id] = value;
		}
	}

	// Token: 0x06007D99 RID: 32153 RVA: 0x00212164 File Offset: 0x00210364
	public BlackCoastStageInfo GetStageById(int stageId)
	{
		BlackCoastStageInfo result;
		this.Stages.TryGetValue(stageId, out result);
		return result;
	}

	// Token: 0x06007D9A RID: 32154 RVA: 0x00212181 File Offset: 0x00210381
	public BlackCoastStageInfo[] GetAllStages()
	{
		return (from x in this.Stages.Values
		orderby x.StageId
		select x).ToArray<BlackCoastStageInfo>();
	}

	// Token: 0x06007D9B RID: 32155 RVA: 0x002121B7 File Offset: 0x002103B7
	public int[] GetAllStagesId()
	{
		return (from x in this.Stages.Keys
		orderby x
		select x).ToArray<int>();
	}

	// Token: 0x06007D9C RID: 32156 RVA: 0x002121F0 File Offset: 0x002103F0
	public void StageUpdate(BlackCoastThemeStageInfo[] stageInfoList)
	{
		foreach (BlackCoastThemeStageInfo blackCoastThemeStageInfo in stageInfoList)
		{
			BlackCoastStageInfo blackCoastStageInfo;
			this.Stages.TryGetValue(blackCoastThemeStageInfo.Id, out blackCoastStageInfo);
			if (blackCoastStageInfo == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[BlackCoastActivity] 活动Stage不存在";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", blackCoastThemeStageInfo.Id);
				instance.Warn(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			else
			{
				blackCoastStageInfo.StageUpdate(blackCoastThemeStageInfo);
			}
		}
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007D9D RID: 32157 RVA: 0x00212280 File Offset: 0x00210480
	public bool HasStageRewardRedDot()
	{
		using (Dictionary<int, BlackCoastStageInfo>.ValueCollection.Enumerator enumerator = this.Stages.Values.GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				if (enumerator.Current.GetRewardState())
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x06007D9E RID: 32158 RVA: 0x002122E0 File Offset: 0x002104E0
	public bool HasAnyNewStageRedDot()
	{
		foreach (BlackCoastStageInfo blackCoastStageInfo in this.Stages.Values)
		{
			if (blackCoastStageInfo.StageState == EStageState.Active && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, blackCoastStageInfo.StageId, 0, 0) == 0)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x06007D9F RID: 32159 RVA: 0x0021235C File Offset: 0x0021055C
	public bool HasNewStageFlag(int stageId)
	{
		BlackCoastStageInfo blackCoastStageInfo;
		this.Stages.TryGetValue(stageId, out blackCoastStageInfo);
		return blackCoastStageInfo.StageState == EStageState.Active && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, stageId, 0, 0) == 0;
	}

	// Token: 0x06007DA0 RID: 32160 RVA: 0x0021239A File Offset: 0x0021059A
	public void SaveNewStageFlag(int stageId)
	{
		ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, stageId, 0, 0, 1);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
	}

	// Token: 0x06007DA1 RID: 32161 RVA: 0x002123C8 File Offset: 0x002105C8
	public int? GetCurrentLockQuestId()
	{
		BlackCoastStageInfo[] allStages = this.GetAllStages();
		int i = 0;
		while (i < allStages.Length)
		{
			BlackCoastStageInfo blackCoastStageInfo = allStages[i];
			if (!blackCoastStageInfo.IsUnlock)
			{
				BlackCoastThemeStageRe? stageConfig = ConfigBase<ActivityBlackCoastConfig>.Instance.GetStageConfig(blackCoastStageInfo.StageId);
				if (stageConfig == null)
				{
					return null;
				}
				return new int?(stageConfig.Value.QuestionId);
			}
			else
			{
				i++;
			}
		}
		return null;
	}

	// Token: 0x06007DA2 RID: 32162 RVA: 0x0021243C File Offset: 0x0021063C
	public WeaponTrialData[] GetPreviewWeaponDataList()
	{
		List<WeaponTrialData> list = new List<WeaponTrialData>();
		BlackCoastThemeConfig? activityConfig = ConfigBase<ActivityBlackCoastConfig>.Instance.GetActivityConfig(base.Id);
		if (activityConfig == null)
		{
			return list.ToArray();
		}
		for (int i = 0; i < activityConfig.Value.WeaponPreviewIdLength; i++)
		{
			int trialId = activityConfig.Value.WeaponPreviewId(i);
			WeaponTrialData weaponTrialData = new WeaponTrialData();
			weaponTrialData.SetTrialId(trialId, true);
			list.Add(weaponTrialData);
		}
		return list.ToArray();
	}

	// Token: 0x04003C42 RID: 15426
	private Dictionary<int, BlackCoastProgressRewardData> ProgressRewardMap = new Dictionary<int, BlackCoastProgressRewardData>();

	// Token: 0x04003C43 RID: 15427
	private Dictionary<int, BlackCoastStageInfo> Stages = new Dictionary<int, BlackCoastStageInfo>();

	// Token: 0x04003C44 RID: 15428
	private int ProgressItemId;

	// Token: 0x04003C45 RID: 15429
	private int ProgressItemTotal;
}
