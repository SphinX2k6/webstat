using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Game.Ui;

namespace CSharpScript.Game.Module.DreamLink
{
	// Token: 0x02005D93 RID: 23955
	[NullableContext(1)]
	[Nullable(0)]
	public class DreamLinkData : ActivityBaseData
	{
		// Token: 0x0603C518 RID: 247064 RVA: 0x00F4EA36 File Offset: 0x00F4CC36
		protected override void OnInit(ActivityData data)
		{
			if (data.RogueWhiteCatData == null)
			{
				return;
			}
			this.InitEnergyRewardData();
			this.InitBossRewardData();
			this.InitBossInstData();
		}

		// Token: 0x0603C519 RID: 247065 RVA: 0x00F4EA53 File Offset: 0x00F4CC53
		protected override void PhraseEx(ActivityData data)
		{
			this.RefreshDreamLinkData(data.RogueWhiteCatData);
		}

		// Token: 0x0603C51A RID: 247066 RVA: 0x00F4EA61 File Offset: 0x00F4CC61
		public void UpdateData(RogueWhiteCatDataUpdateNotify data)
		{
			this.RefreshDreamLinkData(data.RogueWhiteCatData);
		}

		// Token: 0x0603C51B RID: 247067 RVA: 0x00F4EA70 File Offset: 0x00F4CC70
		protected override bool GetExDataFinishShowState()
		{
			using (List<DreamLinkRewardData>.Enumerator enumerator = this.GetEnergyRewardDataList().GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status != EActivityTaskState.FinishedAndClaimed)
					{
						return false;
					}
				}
			}
			using (Dictionary<int, DreamLinkRewardData>.ValueCollection.Enumerator enumerator2 = this.BossRewardMap.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current.Status != EActivityTaskState.FinishedAndClaimed)
					{
						return false;
					}
				}
			}
			using (Dictionary<int, DreamLinkRunTaskData>.ValueCollection.Enumerator enumerator3 = this.RunTaskMap.Values.GetEnumerator())
			{
				while (enumerator3.MoveNext())
				{
					if (enumerator3.Current.Status != EDreamLinkRunTaskState.FinishedAndClaimed)
					{
						return false;
					}
				}
			}
			return true;
		}

		// Token: 0x0603C51C RID: 247068 RVA: 0x00F4EB64 File Offset: 0x00F4CD64
		public override bool GetExDataRedPointShowState()
		{
			if (!this.IsDreamLinkFunctionUnlock(0))
			{
				return this.GetQuestRedDotState() || this.CheckHasLimitTimeReward() || this.CheckHasEnergyReward();
			}
			if (this.IsDreamLinkFunctionUnlock(1))
			{
				bool flag = this.CheckHasRunRedDot();
				if (flag)
				{
					return flag;
				}
			}
			if (this.IsDreamLinkFunctionUnlock(2))
			{
				bool flag2 = this.CheckDungeonRedDotState();
				if (flag2)
				{
					return flag2;
				}
			}
			if (this.IsDreamLinkFunctionUnlock(3))
			{
				bool flag3 = this.CheckHasBossReward() || this.CheckAllBossInstRedDotState();
				if (flag3)
				{
					return flag3;
				}
			}
			return this.CheckHasLimitTimeReward() || this.CheckHasEnergyReward();
		}

		// Token: 0x0603C51D RID: 247069 RVA: 0x00F4EBED File Offset: 0x00F4CDED
		public override bool GetExternalButtonRedPointState()
		{
			if (!this.IsDreamLinkFunctionUnlock(0))
			{
				return this.GetQuestRedDotState();
			}
			return this.RedPointShowState;
		}

		// Token: 0x0603C51E RID: 247070 RVA: 0x00F4EC08 File Offset: 0x00F4CE08
		[NullableContext(2)]
		private void RefreshDreamLinkData(RogueWhiteCatData data)
		{
			if (data == null)
			{
				return;
			}
			this.MaxEnergy = data.MaxEnergy;
			this.RoleInstanceList = data.RogueRoleInstData.ToList<RogueRoleInstData>();
			this.LimitTimeRewardOpenTime = data.LimitedStartTime;
			this.LimitTimeRewardEndTime = data.LimitedEndTime;
			this.DungeonProgressRecord = data.Record;
			this.RefreshEnergyDataState(data.SignStateList.ToList<SignState>());
			this.RefreshBossRewardState(data.BossRewardStateList.ToList<SignState>());
			this.RefreshAllLimitTimeReward(data.RogueLimitedAwards.ToList<RogueLimitedAward>());
			this.UnlockMainFunction = data.UnlockButtons.ToList<int>();
			foreach (RogueLevelPlayData runTaskData in data.RogueLevelPlayData)
			{
				this.RefreshRunTask(runTaskData);
			}
			foreach (int num in data.ScoreMap.Keys)
			{
				int value = data.ScoreMap[num];
				this.RefreshBossInstDataByInstId(num, new int?(value), null, null, null);
			}
			foreach (RogueBossInstData rogueBossInstData in data.RogueBossInstDatas)
			{
				this.RefreshBossInstDataByInstId(rogueBossInstData.InstId, null, new bool?(rogueBossInstData.IsUnlock), new bool?(rogueBossInstData.IsFinish), new long?(rogueBossInstData.UnlockTime));
				this.RefreshBossInstDataRole(rogueBossInstData.InstId);
			}
			this.RefreshRewardPerformance();
		}

		// Token: 0x0603C51F RID: 247071 RVA: 0x00F4EDDC File Offset: 0x00F4CFDC
		public void RefreshActivityRedDotState()
		{
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603C520 RID: 247072 RVA: 0x00F4EDF4 File Offset: 0x00F4CFF4
		public void RefreshRewardPerformance()
		{
			Singleton<EventSystem>.Instance.Emit(EEventName.DreamLinkRewardRefresh);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
			if (Singleton<UiManager>.Instance.IsViewOpen(EUiViewName.ActivityRewardPopUpView))
			{
				Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, this.GetBossRewardData());
			}
		}

		// Token: 0x0603C521 RID: 247073 RVA: 0x00F4EE4E File Offset: 0x00F4D04E
		public void RefreshLimitRewardPerformance()
		{
			if (this.IsLimitTimeRewardOn())
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
				Singleton<EventSystem>.Instance.Emit(EEventName.DreamLinkLimitRewardRefresh);
			}
		}

		// Token: 0x0603C522 RID: 247074 RVA: 0x00F4EE80 File Offset: 0x00F4D080
		public int GetLastUnFinishInst()
		{
			int result = 6;
			for (int i = 0; i < this.RoleInstanceList.Count; i++)
			{
				if (!this.RoleInstanceList[i].IsFinish)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0603C523 RID: 247075 RVA: 0x00F4EEC0 File Offset: 0x00F4D0C0
		public int GetLastUnlockInst()
		{
			int result = 0;
			for (int i = this.RoleInstanceList.Count - 1; i >= 0; i--)
			{
				if (this.RoleInstanceList[i].IsUnlock)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0603C524 RID: 247076 RVA: 0x00F4EF00 File Offset: 0x00F4D100
		public int GetLastFinishInst()
		{
			int result = 0;
			for (int i = this.RoleInstanceList.Count - 1; i >= 0; i--)
			{
				if (this.RoleInstanceList[i].IsFinish)
				{
					result = i;
					break;
				}
			}
			return result;
		}

		// Token: 0x0603C525 RID: 247077 RVA: 0x00F4EF40 File Offset: 0x00F4D140
		public List<RogueRoleInstData> GetInstListByPages(int page, int pageSize)
		{
			int num = page * pageSize;
			int num2 = num + pageSize;
			return this.RoleInstanceList.GetRange(num, Math.Min(num2 - num, this.RoleInstanceList.Count - num));
		}

		// Token: 0x0603C526 RID: 247078 RVA: 0x00F4EF78 File Offset: 0x00F4D178
		public int GetRoleInstDataIndex(int instId)
		{
			return this.RoleInstanceList.FindIndex((RogueRoleInstData roleInst) => roleInst.InstId == instId);
		}

		// Token: 0x0603C527 RID: 247079 RVA: 0x00F4EFA9 File Offset: 0x00F4D1A9
		[NullableContext(2)]
		public RogueRoleInstData GetRoleInstDataByIndex(int index)
		{
			if (index < 0 || index >= this.RoleInstanceList.Count)
			{
				return null;
			}
			return this.RoleInstanceList[index];
		}

		// Token: 0x0603C528 RID: 247080 RVA: 0x00F4EFCC File Offset: 0x00F4D1CC
		public int GetCurrentCatProgress()
		{
			int num = 0;
			RogueWhiteCat activityConfig = this.GetActivityConfig();
			foreach (RogueRoleInstData rogueRoleInstData in this.RoleInstanceList)
			{
				DreamLinkRoleDungeon? dreamLinkRoleDungeonConfig = ConfigBase<DreamLinkConfig>.Instance.GetDreamLinkRoleDungeonConfig(rogueRoleInstData.InstId);
				if (rogueRoleInstData.IsFinish)
				{
					num += dreamLinkRoleDungeonConfig.Value.AddProgress;
				}
			}
			return num + activityConfig.DungeonBaseProgress;
		}

		// Token: 0x0603C529 RID: 247081 RVA: 0x00F4F058 File Offset: 0x00F4D258
		public RogueWhiteCat GetActivityConfig()
		{
			return ConfigBase<DreamLinkConfig>.Instance.GetActivityConfig(base.Id).Value;
		}

		// Token: 0x0603C52A RID: 247082 RVA: 0x00F4F080 File Offset: 0x00F4D280
		public bool IsDreamLinkInst(int id)
		{
			return this.RoleInstanceList.FindIndex((RogueRoleInstData roleInst) => roleInst.InstId == id) != -1;
		}

		// Token: 0x0603C52B RID: 247083 RVA: 0x00F4F0B7 File Offset: 0x00F4D2B7
		public bool IsDreamLinkFunctionUnlock(int id)
		{
			return this.UnlockMainFunction.Contains(id);
		}

		// Token: 0x0603C52C RID: 247084 RVA: 0x00F4F0C8 File Offset: 0x00F4D2C8
		public int GetFinishInstCount()
		{
			int num = 0;
			using (List<RogueRoleInstData>.Enumerator enumerator = this.RoleInstanceList.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.IsFinish)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0603C52D RID: 247085 RVA: 0x00F4F124 File Offset: 0x00F4D324
		public bool IsAllInstFinished()
		{
			return this.GetFinishInstCount() == this.RoleInstanceList.Count;
		}

		// Token: 0x0603C52E RID: 247086 RVA: 0x00F4F139 File Offset: 0x00F4D339
		public EDreamLinkStage GetInstStage()
		{
			if (this.GetFinishInstCount() >= 3)
			{
				return EDreamLinkStage.Second;
			}
			return EDreamLinkStage.First;
		}

		// Token: 0x0603C52F RID: 247087 RVA: 0x00F4F148 File Offset: 0x00F4D348
		public IDreamLinkDungeonToggleItemParams GetDungeonToggleItemParams()
		{
			if (this.GetFinishInstCount() >= 3)
			{
				return new DreamLinkDungeonToggleItemParams
				{
					TextureBgPath = (ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DreamLinkDungeonBgRed") ?? ""),
					TextureLightPath = (ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DreamLinkDungeonLightRed") ?? ""),
					EffectColor = "#cff7ff"
				};
			}
			return new DreamLinkDungeonToggleItemParams
			{
				TextureBgPath = (ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DreamLinkDungeonBgBlue") ?? ""),
				TextureLightPath = (ConfigBase<UiResourceConfig>.Instance.GetResourcePath("DreamLinkDungeonLightBlue") ?? ""),
				EffectColor = "#ffe5e7"
			};
		}

		// Token: 0x0603C530 RID: 247088 RVA: 0x00F4F1F8 File Offset: 0x00F4D3F8
		public bool CheckDungeonRedDotStateByInstId(int instId)
		{
			int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 2, instId, 0);
			int roleInstDataIndex = this.GetRoleInstDataIndex(instId);
			RogueRoleInstData rogueRoleInstData = this.RoleInstanceList[roleInstDataIndex];
			bool flag = rogueRoleInstData.IsUnlock && !rogueRoleInstData.IsFinish;
			if (activityCacheData == 0)
			{
				return flag;
			}
			return Singleton<TimeUtil>.Instance.GetServerTime() - (double)activityCacheData > 259200.0 && flag;
		}

		// Token: 0x0603C531 RID: 247089 RVA: 0x00F4F264 File Offset: 0x00F4D464
		public void SaveDungeonRedDotStateByInstId(int instId)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 2, instId, 0, (int)serverTime);
			this.RefreshActivityRedDotState();
		}

		// Token: 0x0603C532 RID: 247090 RVA: 0x00F4F298 File Offset: 0x00F4D498
		public bool CheckDungeonRedDotStateByPage(int page, int pageCount)
		{
			if (page < 0 || pageCount <= 0)
			{
				return false;
			}
			int num = page * pageCount;
			while (num < (page + 1) * pageCount && num < this.RoleInstanceList.Count)
			{
				RogueRoleInstData rogueRoleInstData = this.RoleInstanceList[num];
				if (this.CheckDungeonRedDotStateByInstId(rogueRoleInstData.InstId))
				{
					return true;
				}
				num++;
			}
			return false;
		}

		// Token: 0x0603C533 RID: 247091 RVA: 0x00F4F2F0 File Offset: 0x00F4D4F0
		public bool CheckDungeonRedDotState()
		{
			foreach (RogueRoleInstData rogueRoleInstData in this.RoleInstanceList)
			{
				if (this.CheckDungeonRedDotStateByInstId(rogueRoleInstData.InstId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C534 RID: 247092 RVA: 0x00F4F354 File Offset: 0x00F4D554
		public bool GetQuestRedDotState()
		{
			int unFinishPreGuideQuestId = base.GetUnFinishPreGuideQuestId();
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 6, unFinishPreGuideQuestId, 0) == 0;
		}

		// Token: 0x0603C535 RID: 247093 RVA: 0x00F4F380 File Offset: 0x00F4D580
		public void SaveQuestRedDotState()
		{
			if (base.GetPreGuideQuestFinishState())
			{
				return;
			}
			int unFinishPreGuideQuestId = base.GetUnFinishPreGuideQuestId();
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 6, unFinishPreGuideQuestId, 0, 1);
			this.RefreshActivityRedDotState();
		}

		// Token: 0x0603C536 RID: 247094 RVA: 0x00F4F3B7 File Offset: 0x00F4D5B7
		public void SaveFirstCheckRedDotState(int functionId, int id = 0)
		{
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, functionId, id, 0, 1);
			this.RefreshActivityRedDotState();
		}

		// Token: 0x0603C537 RID: 247095 RVA: 0x00F4F3D4 File Offset: 0x00F4D5D4
		private void InitBossInstData()
		{
			this.BossInstDataMap.Clear();
			foreach (int num in this.GetActivityConfig().BossInstanceList())
			{
				RogueBossInstance? rogueBossInstanceConfig = ConfigBase<DreamLinkConfig>.Instance.GetRogueBossInstanceConfig(num);
				int instanceId = rogueBossInstanceConfig.Value.InstanceId;
				DreamLinkBossInstanceData value = new DreamLinkBossInstanceData(num, instanceId, rogueBossInstanceConfig.Value.ConditionGroupId);
				this.BossInstDataMap.Add(instanceId, value);
			}
		}

		// Token: 0x0603C538 RID: 247096 RVA: 0x00F4F458 File Offset: 0x00F4D658
		private void RefreshBossInstDataByInstId(int instId, int? score = null, bool? isUnlock = null, bool? isFinished = null, long? unlockTime = null)
		{
			DreamLinkBossInstanceData dreamLinkBossInstanceData;
			if (!this.BossInstDataMap.TryGetValue(instId, out dreamLinkBossInstanceData))
			{
				return;
			}
			if (score != null)
			{
				dreamLinkBossInstanceData.Score = score.Value;
			}
			if (isUnlock != null)
			{
				dreamLinkBossInstanceData.IsUnlock = isUnlock.Value;
			}
			if (isFinished != null)
			{
				dreamLinkBossInstanceData.IsFinished = isFinished.Value;
			}
			if (unlockTime != null)
			{
				dreamLinkBossInstanceData.UnlockTime = unlockTime.Value;
			}
		}

		// Token: 0x0603C539 RID: 247097 RVA: 0x00F4F4D0 File Offset: 0x00F4D6D0
		private void RefreshBossInstDataRole(int instId)
		{
			DreamLinkBossInstanceData dreamLinkBossInstanceData;
			if (!this.BossInstDataMap.TryGetValue(instId, out dreamLinkBossInstanceData))
			{
				return;
			}
			for (int i = 0; i < 3; i++)
			{
				int activityCacheData = ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, instId, i, 0);
				dreamLinkBossInstanceData.SetBossRoleIdByIndex(i, activityCacheData);
			}
		}

		// Token: 0x0603C53A RID: 247098 RVA: 0x00F4F517 File Offset: 0x00F4D717
		public List<DreamLinkBossInstanceData> GetAllBossInstData()
		{
			return (from a in this.BossInstDataMap.Values
			orderby a.TypeId
			select a).ToList<DreamLinkBossInstanceData>();
		}

		// Token: 0x0603C53B RID: 247099 RVA: 0x00F4F550 File Offset: 0x00F4D750
		public void FixBossRoleId(int instId)
		{
			List<int> allBossRoleId = this.GetAllBossRoleId(instId);
			for (int i = 0; i < allBossRoleId.Count; i++)
			{
				int num = allBossRoleId[i];
				if (ModelBase<RoleModel>.Instance.IsMainRole(num))
				{
					int num2 = num;
					int? curSelectMainRoleId = ModelBase<RoleModel>.Instance.GetCurSelectMainRoleId();
					if (!(num2 == curSelectMainRoleId.GetValueOrDefault() & curSelectMainRoleId != null))
					{
						this.SetBossRoleId(instId, i, 0);
					}
				}
			}
		}

		// Token: 0x0603C53C RID: 247100 RVA: 0x00F4F5B3 File Offset: 0x00F4D7B3
		public int GetBossRoleId(int instId, int index)
		{
			return this.BossInstDataMap[instId].GetBossRoleIdByIndex(index);
		}

		// Token: 0x0603C53D RID: 247101 RVA: 0x00F4F5C7 File Offset: 0x00F4D7C7
		public void SetBossRoleId(int instId, int index, int roleId)
		{
			this.BossInstDataMap[instId].SetBossRoleIdByIndex(index, roleId);
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, instId, index, 0, roleId);
		}

		// Token: 0x0603C53E RID: 247102 RVA: 0x00F4F5F0 File Offset: 0x00F4D7F0
		public List<int> GetAllBossRoleId(int instId)
		{
			return this.BossInstDataMap[instId].GetBossRoleIdList().ToList<int>();
		}

		// Token: 0x0603C53F RID: 247103 RVA: 0x00F4F608 File Offset: 0x00F4D808
		public bool CheckAllBossInstRedDotState()
		{
			foreach (DreamLinkBossInstanceData dreamLinkBossInstanceData in this.BossInstDataMap.Values)
			{
				if (dreamLinkBossInstanceData.IsUnlock && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 3, dreamLinkBossInstanceData.InstId, 0) == 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C540 RID: 247104 RVA: 0x00F4F684 File Offset: 0x00F4D884
		public bool GetBossInstRedDotState(int instId)
		{
			return this.BossInstDataMap[instId].IsUnlock && ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 3, instId, 0) == 0;
		}

		// Token: 0x0603C541 RID: 247105 RVA: 0x00F4F6B2 File Offset: 0x00F4D8B2
		public void SaveBossInstRedDotState(int instId)
		{
			if (!this.BossInstDataMap[instId].IsUnlock)
			{
				return;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, 3, instId, 0, 1);
			this.RefreshActivityRedDotState();
		}

		// Token: 0x0603C542 RID: 247106 RVA: 0x00F4F6E2 File Offset: 0x00F4D8E2
		public void SetRunTaskDone(int id)
		{
			this.RunTaskMap[id].Status = EDreamLinkRunTaskState.FinishedAndClaimed;
		}

		// Token: 0x0603C543 RID: 247107 RVA: 0x00F4F6F6 File Offset: 0x00F4D8F6
		public List<DreamLinkRunTaskData> GetDreamLinkRunTaskDataList()
		{
			return (from a in this.RunTaskMap.Values
			orderby a.Id
			select a).ToList<DreamLinkRunTaskData>();
		}

		// Token: 0x0603C544 RID: 247108 RVA: 0x00F4F72C File Offset: 0x00F4D92C
		public bool IsDreamLinkRunMarkShow(int markId)
		{
			DreamLinkWorldRun? worldRunConfigByMarkId = ConfigBase<DreamLinkConfig>.Instance.GetWorldRunConfigByMarkId(markId);
			DreamLinkRunTaskData dreamLinkRunTaskData;
			return worldRunConfigByMarkId != null && this.RunTaskMap.TryGetValue(worldRunConfigByMarkId.Value.Id, out dreamLinkRunTaskData) && dreamLinkRunTaskData.Status > EDreamLinkRunTaskState.Lock;
		}

		// Token: 0x0603C545 RID: 247109 RVA: 0x00F4F77C File Offset: 0x00F4D97C
		public bool CheckHasRunRedDot()
		{
			foreach (DreamLinkRunTaskData dreamLinkRunTaskData in this.RunTaskMap.Values)
			{
				EDreamLinkRunTaskState status = dreamLinkRunTaskData.Status;
				if (status != EDreamLinkRunTaskState.Active)
				{
					if (status == EDreamLinkRunTaskState.FinishedAndUnclaimed)
					{
						return true;
					}
				}
				else if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, dreamLinkRunTaskData.Id, 0) == 0)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603C546 RID: 247110 RVA: 0x00F4F804 File Offset: 0x00F4DA04
		public bool GetRunRedDotState(int id)
		{
			DreamLinkRunTaskData dreamLinkRunTaskData = this.RunTaskMap[id];
			EDreamLinkRunTaskState status = dreamLinkRunTaskData.Status;
			if (status != EDreamLinkRunTaskState.Active)
			{
				return status == EDreamLinkRunTaskState.FinishedAndUnclaimed;
			}
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 1, dreamLinkRunTaskData.Id, 0) == 0;
		}

		// Token: 0x0603C547 RID: 247111 RVA: 0x00F4F850 File Offset: 0x00F4DA50
		public bool CheckHasRunFinished()
		{
			foreach (DreamLinkRunTaskData dreamLinkRunTaskData in this.RunTaskMap.Values)
			{
				if (dreamLinkRunTaskData.Status == EDreamLinkRunTaskState.Active || dreamLinkRunTaskData.Status == EDreamLinkRunTaskState.Lock)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x0603C548 RID: 247112 RVA: 0x00F4F8BC File Offset: 0x00F4DABC
		[NullableContext(2)]
		private DreamLinkRunTaskData CreateRunTask(int id)
		{
			DreamLinkWorldRun? worldRunConfig = ConfigBase<DreamLinkConfig>.Instance.GetWorldRunConfig(id);
			if (worldRunConfig == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Activity;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "[DreamLink] RunTask Config Error";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return null;
			}
			DreamLinkRunTaskData dreamLinkRunTaskData = new DreamLinkRunTaskData(id);
			dreamLinkRunTaskData.ConditionGroupId = worldRunConfig.Value.ConditionGroupId;
			dreamLinkRunTaskData.TitleTextId = worldRunConfig.Value.Title;
			dreamLinkRunTaskData.RewardList = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance.GetDropPackagePreviewItemList(worldRunConfig.Value.RewardId);
			dreamLinkRunTaskData.MarkId = worldRunConfig.Value.MarkId;
			this.RunTaskMap.Add(id, dreamLinkRunTaskData);
			return dreamLinkRunTaskData;
		}

		// Token: 0x0603C549 RID: 247113 RVA: 0x00F4F984 File Offset: 0x00F4DB84
		private void RefreshRunTask(RogueLevelPlayData runTaskData)
		{
			DreamLinkRunTaskData dreamLinkRunTaskData;
			if (!this.RunTaskMap.TryGetValue(runTaskData.Index, out dreamLinkRunTaskData))
			{
				dreamLinkRunTaskData = this.CreateRunTask(runTaskData.Index);
				if (dreamLinkRunTaskData == null)
				{
					return;
				}
			}
			dreamLinkRunTaskData.PlayTime = runTaskData.Record;
			dreamLinkRunTaskData.UnlockTime = runTaskData.UnlockTime;
			switch (runTaskData.Reward)
			{
			case SignState.Lock:
				dreamLinkRunTaskData.Status = (runTaskData.IsUnlock ? EDreamLinkRunTaskState.Active : EDreamLinkRunTaskState.Lock);
				return;
			case SignState.Unlock:
				dreamLinkRunTaskData.Status = EDreamLinkRunTaskState.FinishedAndUnclaimed;
				return;
			case SignState.IsReceive:
				dreamLinkRunTaskData.Status = EDreamLinkRunTaskState.FinishedAndClaimed;
				return;
			default:
				return;
			}
		}

		// Token: 0x0603C54A RID: 247114 RVA: 0x00F4FA0C File Offset: 0x00F4DC0C
		public int GetEnergyItemId()
		{
			return this.GetActivityConfig().EnergyId;
		}

		// Token: 0x0603C54B RID: 247115 RVA: 0x00F4FA27 File Offset: 0x00F4DC27
		public int GetEnergyItemCount()
		{
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.GetEnergyItemId(), 0);
		}

		// Token: 0x0603C54C RID: 247116 RVA: 0x00F4FA3A File Offset: 0x00F4DC3A
		public List<DreamLinkRewardData> GetEnergyRewardDataList()
		{
			return (from a in this.EnergyRewardMap.Values
			orderby a.Id
			select a).ToList<DreamLinkRewardData>();
		}

		// Token: 0x0603C54D RID: 247117 RVA: 0x00F4FA70 File Offset: 0x00F4DC70
		public bool CheckHasEnergyReward()
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 5, 0, 0) == 0)
			{
				return true;
			}
			using (Dictionary<int, DreamLinkRewardData>.ValueCollection.Enumerator enumerator = this.EnergyRewardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C54E RID: 247118 RVA: 0x00F4FAEC File Offset: 0x00F4DCEC
		private void InitEnergyRewardData()
		{
			this.EnergyRewardMap.Clear();
			foreach (int num in this.GetActivityConfig().Rewards())
			{
				RogueWhiteCatReward? energyRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetEnergyRewardConfig(num);
				DreamLinkRewardData dreamLinkRewardData = new DreamLinkRewardData(num);
				dreamLinkRewardData.Status = EActivityTaskState.Active;
				dreamLinkRewardData.Target = energyRewardConfig.Value.NeedEnergy;
				this.EnergyRewardMap.Add(num, dreamLinkRewardData);
			}
		}

		// Token: 0x0603C54F RID: 247119 RVA: 0x00F4FB68 File Offset: 0x00F4DD68
		private void RefreshEnergyDataState(List<SignState> rewardStateList)
		{
			RogueWhiteCat activityConfig = this.GetActivityConfig();
			for (int i = 0; i < rewardStateList.Count; i++)
			{
				int id = activityConfig.Rewards(i);
				this.RefreshEnergyRewardData(id, DreamLinkDefine.signStateResolver[rewardStateList[i]]);
			}
		}

		// Token: 0x0603C550 RID: 247120 RVA: 0x00F4FBB0 File Offset: 0x00F4DDB0
		public void RefreshEnergyRewardData(int id, EActivityTaskState status)
		{
			DreamLinkRewardData dreamLinkRewardData;
			if (!this.EnergyRewardMap.TryGetValue(id, out dreamLinkRewardData))
			{
				return;
			}
			dreamLinkRewardData.Status = status;
		}

		// Token: 0x0603C551 RID: 247121 RVA: 0x00F4FBD8 File Offset: 0x00F4DDD8
		private void InitBossRewardData()
		{
			this.BossRewardMap.Clear();
			this.BossTypeRewardMap.Clear();
			foreach (int num in this.GetActivityConfig().BossRewards())
			{
				DreamLinkRewardData dreamLinkRewardData = new DreamLinkRewardData(num);
				dreamLinkRewardData.Status = EActivityTaskState.Active;
				RogueWhiteCatBossReward? bossRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetBossRewardConfig(num);
				List<DreamLinkRewardData> list;
				if (!this.BossTypeRewardMap.TryGetValue(bossRewardConfig.Value.InstanceType, out list))
				{
					list = new List<DreamLinkRewardData>();
					this.BossTypeRewardMap.Add(bossRewardConfig.Value.InstanceType, list);
				}
				list.Add(dreamLinkRewardData);
				this.BossRewardMap.Add(num, dreamLinkRewardData);
			}
		}

		// Token: 0x0603C552 RID: 247122 RVA: 0x00F4FC98 File Offset: 0x00F4DE98
		private void RefreshBossRewardState(List<SignState> rewardStateList)
		{
			RogueWhiteCat activityConfig = this.GetActivityConfig();
			for (int i = 0; i < rewardStateList.Count; i++)
			{
				int id = activityConfig.BossRewards(i);
				this.RefreshBossRewardData(id, DreamLinkDefine.signStateResolver[rewardStateList[i]]);
			}
		}

		// Token: 0x0603C553 RID: 247123 RVA: 0x00F4FCE0 File Offset: 0x00F4DEE0
		public void RefreshBossRewardData(int id, EActivityTaskState status)
		{
			DreamLinkRewardData dreamLinkRewardData;
			if (!this.BossRewardMap.TryGetValue(id, out dreamLinkRewardData))
			{
				return;
			}
			dreamLinkRewardData.Status = status;
		}

		// Token: 0x0603C554 RID: 247124 RVA: 0x00F4FD08 File Offset: 0x00F4DF08
		public IActivityRewardViewData GetBossRewardData()
		{
			RogueWhiteCat activityConfig = this.GetActivityConfig();
			List<IActivityRewardDataPage> list = new List<IActivityRewardDataPage>();
			foreach (int num in activityConfig.BossTabText().Keys)
			{
				List<IActivityRewardData> list2 = new List<IActivityRewardData>();
				List<DreamLinkRewardData> list3;
				if (this.BossTypeRewardMap.TryGetValue(num, out list3))
				{
					foreach (DreamLinkRewardData data in list3)
					{
						IActivityRewardData bossRewardViewData = this.GetBossRewardViewData(data);
						list2.Add(bossRewardViewData);
					}
				}
				list2.Sort(new Comparison<IActivityRewardData>(this.SortReward));
				ActivityRewardDataPage item = new ActivityRewardDataPage
				{
					TabName = this.GetRewardTabNameByType(num),
					DataList = list2
				};
				list.Add(item);
			}
			return new ActivityRewardViewData
			{
				DataPageList = list,
				Source = EActivityRewardSource.DreamLink
			};
		}

		// Token: 0x0603C555 RID: 247125 RVA: 0x00F4FE20 File Offset: 0x00F4E020
		private string GetRewardTabNameByType(int type)
		{
			string text;
			return ConfigMultiTextLang.GetLocalTextNew(this.GetActivityConfig().BossTabText().TryGetValue(type, out text) ? text : "", null) ?? "";
		}

		// Token: 0x0603C556 RID: 247126 RVA: 0x00F4FE5C File Offset: 0x00F4E05C
		private IActivityRewardData GetBossRewardViewData(DreamLinkRewardData data)
		{
			RogueWhiteCatBossReward? bossRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetBossRewardConfig(data.Id);
			EActivityRewardState rewardState = EActivityRewardState.Disabled;
			string text = "";
			Action clickFunction = delegate()
			{
			};
			bool value = false;
			switch (data.Status)
			{
			case EActivityTaskState.FinishedAndUnclaimed:
				rewardState = EActivityRewardState.Enable;
				text = "Text_DaMaoZhan_Gain";
				value = true;
				clickFunction = delegate()
				{
					ControllerBase<DreamLinkController>.Instance.BossRewardRequest(data.Id);
				};
				break;
			case EActivityTaskState.Active:
				text = "Text_DaMaoZhan_OnProgress";
				break;
			case EActivityTaskState.FinishedAndClaimed:
				rewardState = EActivityRewardState.Claimed;
				break;
			}
			if (!StringUtils.IsEmpty(text))
			{
				text = (ConfigMultiTextLang.GetLocalTextNew(text, null) ?? "");
			}
			return new ActivityRewardData
			{
				Id = new int?(data.Id),
				NameText = "",
				NameTextId = bossRewardConfig.Value.Title,
				RewardList = base.GetPreviewReward(new int?(bossRewardConfig.Value.DropId)).ToArray(),
				RewardState = rewardState,
				RewardButtonText = text,
				RewardButtonRedDot = new bool?(value),
				ClickFunction = clickFunction
			};
		}

		// Token: 0x0603C557 RID: 247127 RVA: 0x00F4FFA0 File Offset: 0x00F4E1A0
		private int SortReward(IActivityRewardData a, IActivityRewardData b)
		{
			DreamLinkRewardData dreamLinkRewardData = this.BossRewardMap[a.Id.Value];
			DreamLinkRewardData dreamLinkRewardData2 = this.BossRewardMap[b.Id.Value];
			if (dreamLinkRewardData.Status == dreamLinkRewardData2.Status)
			{
				return dreamLinkRewardData.Id - dreamLinkRewardData2.Id;
			}
			return dreamLinkRewardData.Status - dreamLinkRewardData2.Status;
		}

		// Token: 0x0603C558 RID: 247128 RVA: 0x00F5000C File Offset: 0x00F4E20C
		public bool CheckHasBossReward()
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 7, 0, 0) == 0)
			{
				return true;
			}
			using (Dictionary<int, DreamLinkRewardData>.ValueCollection.Enumerator enumerator = this.BossRewardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C559 RID: 247129 RVA: 0x00F50088 File Offset: 0x00F4E288
		public int GetLimitTimeRewardTypeLength()
		{
			return this.GetActivityConfig().TabTextLength;
		}

		// Token: 0x0603C55A RID: 247130 RVA: 0x00F500A4 File Offset: 0x00F4E2A4
		public void RefreshAllLimitTimeReward(List<RogueLimitedAward> data)
		{
			foreach (RogueLimitedAward rogueLimitedAward in data)
			{
				this.RefreshLimitTimeRewardData(rogueLimitedAward.ConfigId, DreamLinkDefine.signStateResolver[rogueLimitedAward.SignState], new int?(rogueLimitedAward.CurProgress), new int?(rogueLimitedAward.MaxProgress));
			}
		}

		// Token: 0x0603C55B RID: 247131 RVA: 0x00F50120 File Offset: 0x00F4E320
		public void RefreshLimitTimeRewardData(int id, EActivityTaskState status, int? current = null, int? target = null)
		{
			DreamLinkRewardData dreamLinkRewardData;
			if (!this.LimitTimeRewardMap.TryGetValue(id, out dreamLinkRewardData))
			{
				dreamLinkRewardData = new DreamLinkRewardData(id);
				this.LimitTimeRewardMap.Add(id, dreamLinkRewardData);
				RogueLimitTimeReward? limitTimeRewardConfig = ConfigBase<DreamLinkConfig>.Instance.GetLimitTimeRewardConfig(id);
				List<DreamLinkRewardData> list;
				if (!this.LimitTimeTypeRewardMap.TryGetValue((EDreamLinkRewardType)limitTimeRewardConfig.Value.Type, out list))
				{
					list = new List<DreamLinkRewardData>();
					this.LimitTimeTypeRewardMap.Add((EDreamLinkRewardType)limitTimeRewardConfig.Value.Type, list);
				}
				list.Add(dreamLinkRewardData);
			}
			if (current != null)
			{
				dreamLinkRewardData.Current = current.Value;
			}
			if (target != null)
			{
				dreamLinkRewardData.Target = target.Value;
			}
			dreamLinkRewardData.Status = status;
		}

		// Token: 0x0603C55C RID: 247132 RVA: 0x00F501D6 File Offset: 0x00F4E3D6
		private int SortTargetData(DreamLinkRewardData a, DreamLinkRewardData b)
		{
			if (a.Status == b.Status)
			{
				return a.Id - b.Id;
			}
			return a.Status - b.Status;
		}

		// Token: 0x0603C55D RID: 247133 RVA: 0x00F50201 File Offset: 0x00F4E401
		public long GetLimitTimeEndTime()
		{
			return this.LimitTimeRewardEndTime;
		}

		// Token: 0x0603C55E RID: 247134 RVA: 0x00F5020C File Offset: 0x00F4E40C
		public bool IsLimitTimeRewardOn()
		{
			if (!base.IsUnLock())
			{
				return false;
			}
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			return serverTime >= (double)this.LimitTimeRewardOpenTime && serverTime <= (double)this.LimitTimeRewardEndTime;
		}

		// Token: 0x0603C55F RID: 247135 RVA: 0x00F50248 File Offset: 0x00F4E448
		public bool CheckHasLimitTimeReward()
		{
			if (!this.IsLimitTimeRewardOn())
			{
				return false;
			}
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, 4, 0, 0) == 0)
			{
				return true;
			}
			using (Dictionary<int, DreamLinkRewardData>.ValueCollection.Enumerator enumerator = this.LimitTimeRewardMap.Values.GetEnumerator())
			{
				while (enumerator.MoveNext())
				{
					if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
					{
						return true;
					}
				}
			}
			return false;
		}

		// Token: 0x0603C560 RID: 247136 RVA: 0x00F502CC File Offset: 0x00F4E4CC
		public bool CheckHasLimitTimeTabReward(int tabId)
		{
			if (!this.IsLimitTimeRewardOn())
			{
				return false;
			}
			List<DreamLinkRewardData> list;
			if (this.LimitTimeTypeRewardMap.TryGetValue((EDreamLinkRewardType)tabId, out list))
			{
				using (List<DreamLinkRewardData>.Enumerator enumerator = list.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.Status == EActivityTaskState.FinishedAndUnclaimed)
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x0603C561 RID: 247137 RVA: 0x00F5033C File Offset: 0x00F4E53C
		public Tuple<string, string> GetTypeInfoByTabId(int tabId)
		{
			RogueWhiteCat activityConfig = this.GetActivityConfig();
			string text;
			string item = activityConfig.TabText().TryGetValue(tabId, out text) ? text : "";
			string text2;
			string item2 = activityConfig.TabIcon().TryGetValue(tabId, out text2) ? text2 : "";
			return Tuple.Create<string, string>(item, item2);
		}

		// Token: 0x0603C562 RID: 247138 RVA: 0x00F5038C File Offset: 0x00F4E58C
		public List<DreamLinkRewardData> GetLimitTimeRewardListByTabId(int tabId)
		{
			List<DreamLinkRewardData> list;
			if (!this.LimitTimeTypeRewardMap.TryGetValue((EDreamLinkRewardType)tabId, out list))
			{
				return new List<DreamLinkRewardData>();
			}
			list.Sort(new Comparison<DreamLinkRewardData>(this.SortTargetData));
			return list;
		}

		// Token: 0x0603C563 RID: 247139 RVA: 0x00F503C4 File Offset: 0x00F4E5C4
		public int GetPreviewWeaponId()
		{
			return this.GetActivityConfig().WeaponPreviewId;
		}

		// Token: 0x04021EAB RID: 138923
		public List<RogueRoleInstData> RoleInstanceList = new List<RogueRoleInstData>();

		// Token: 0x04021EAC RID: 138924
		public Dictionary<int, DreamLinkRunTaskData> RunTaskMap = new Dictionary<int, DreamLinkRunTaskData>();

		// Token: 0x04021EAD RID: 138925
		public int MaxEnergy;

		// Token: 0x04021EAE RID: 138926
		private long LimitTimeRewardOpenTime;

		// Token: 0x04021EAF RID: 138927
		private long LimitTimeRewardEndTime;

		// Token: 0x04021EB0 RID: 138928
		private List<int> UnlockMainFunction = new List<int>();

		// Token: 0x04021EB1 RID: 138929
		private readonly Dictionary<int, DreamLinkRewardData> EnergyRewardMap = new Dictionary<int, DreamLinkRewardData>();

		// Token: 0x04021EB2 RID: 138930
		private readonly Dictionary<int, DreamLinkRewardData> LimitTimeRewardMap = new Dictionary<int, DreamLinkRewardData>();

		// Token: 0x04021EB3 RID: 138931
		private readonly Dictionary<int, DreamLinkRewardData> BossRewardMap = new Dictionary<int, DreamLinkRewardData>();

		// Token: 0x04021EB4 RID: 138932
		private readonly Dictionary<int, List<DreamLinkRewardData>> BossTypeRewardMap = new Dictionary<int, List<DreamLinkRewardData>>();

		// Token: 0x04021EB5 RID: 138933
		private readonly Dictionary<EDreamLinkRewardType, List<DreamLinkRewardData>> LimitTimeTypeRewardMap = new Dictionary<EDreamLinkRewardType, List<DreamLinkRewardData>>();

		// Token: 0x04021EB6 RID: 138934
		private readonly Dictionary<int, DreamLinkBossInstanceData> BossInstDataMap = new Dictionary<int, DreamLinkBossInstanceData>();

		// Token: 0x04021EB7 RID: 138935
		public int DungeonProgressRecord;
	}
}
