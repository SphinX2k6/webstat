using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005652 RID: 22098
	[NullableContext(1)]
	[Nullable(0)]
	public class ActivityPermanentRogueData : ActivityBaseData
	{
		// Token: 0x0603853F RID: 230719 RVA: 0x00E4290C File Offset: 0x00E40B0C
		protected override bool GetExDataFinishShowState()
		{
			if (!base.GetPreGuideQuestFinishState())
			{
				return false;
			}
			ActivityPermanentRogueModel instance = ModelBase<ActivityPermanentRogueModel>.Instance;
			foreach (int seasonId in this.RogueSeasonDataMap.Keys)
			{
				using (List<IActivityRewardData>.Enumerator enumerator2 = instance.GetEndingAwardList(seasonId).GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.RewardState != EActivityRewardState.Claimed)
						{
							return false;
						}
					}
				}
				if (!instance.HasShopGoodsSoldOut(seasonId))
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06038540 RID: 230720 RVA: 0x00E429C8 File Offset: 0x00E40BC8
		public override bool GetExDataRedPointShowState()
		{
			if (!base.GetPreGuideQuestFinishState())
			{
				return false;
			}
			if (this.CheckAllRightSideRedDot())
			{
				return true;
			}
			ActivityPermanentRogueModel instance = ModelBase<ActivityPermanentRogueModel>.Instance;
			int newSeasonId = this.GetNewSeasonId();
			return instance.CheckAllTaskRedDot() || instance.CheckShopRedDot(newSeasonId);
		}

		// Token: 0x06038541 RID: 230721 RVA: 0x00E42A0A File Offset: 0x00E40C0A
		public bool GetFirstCheckRedDotState(EPermanentRogueSaveFlag saveFlag)
		{
			return ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, (int)saveFlag, 0, 0) == 0;
		}

		// Token: 0x06038542 RID: 230722 RVA: 0x00E42A23 File Offset: 0x00E40C23
		public bool SaveFirstCheckRedDotState(EPermanentRogueSaveFlag saveFlag)
		{
			if (ModelBase<ActivityModel>.Instance.GetActivityCacheData(base.Id, 0, (int)saveFlag, 0, 0) == 1)
			{
				return true;
			}
			ModelBase<ActivityModel>.Instance.SaveActivityData(base.Id, (int)saveFlag, 0, 0, 1);
			return false;
		}

		// Token: 0x06038543 RID: 230723 RVA: 0x00E42A58 File Offset: 0x00E40C58
		public bool CheckAllRightSideRedDot()
		{
			if (!base.GetPreGuideQuestFinishState())
			{
				return false;
			}
			int newSeasonId = this.GetNewSeasonId();
			ActivityPermanentRogueModel instance = ModelBase<ActivityPermanentRogueModel>.Instance;
			return instance.CheckSkillTreeRedDot(newSeasonId) || instance.CheckIllustratedRedDot() || (instance.CheckEndingAwardRedDot(newSeasonId) || instance.CheckDungeonRedDot(newSeasonId));
		}

		// Token: 0x06038544 RID: 230724 RVA: 0x00E42AA8 File Offset: 0x00E40CA8
		public bool IsIllustratedReward()
		{
			foreach (KeyValuePair<int, SignState> keyValuePair in this.IllustratedState)
			{
				if (keyValuePair.Value == SignState.Unlock)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06038545 RID: 230725 RVA: 0x00E42B08 File Offset: 0x00E40D08
		public bool IsTaskReward()
		{
			if (this.GetFirstCheckRedDotState(EPermanentRogueSaveFlag.NewTaskCheck))
			{
				return true;
			}
			foreach (KeyValuePair<int, RogueTaskData> keyValuePair in this.TaskDataMap)
			{
				if (keyValuePair.Value.Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06038546 RID: 230726 RVA: 0x00E42B78 File Offset: 0x00E40D78
		protected override void PhraseEx(ActivityData data)
		{
			RogueResActivityData rogueResActivityData = data.RogueResActivityData;
			if (rogueResActivityData == null)
			{
				return;
			}
			foreach (RogueResSeasonData rogueResSeasonData in rogueResActivityData.RogueResSeasonData)
			{
				this.RogueSeasonDataMap[rogueResSeasonData.SeasonId] = rogueResSeasonData;
			}
			this.InitIllustratedData(rogueResActivityData);
			this.InitRogueQuest(rogueResActivityData);
			this.InitEnding(rogueResActivityData.RogueResSeasonData);
			this.InitShopItem(rogueResActivityData.RogueResSeasonData);
		}

		// Token: 0x06038547 RID: 230727 RVA: 0x00E42C04 File Offset: 0x00E40E04
		[NullableContext(2)]
		public RogueResSeasonData GetSeasonDataById(int seasonId)
		{
			RogueResSeasonData result;
			if (this.RogueSeasonDataMap.TryGetValue(seasonId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x06038548 RID: 230728 RVA: 0x00E42C24 File Offset: 0x00E40E24
		public int GetNewSeasonId()
		{
			int num = -1;
			foreach (KeyValuePair<int, RogueResSeasonData> keyValuePair in this.RogueSeasonDataMap)
			{
				if (keyValuePair.Key > num)
				{
					num = keyValuePair.Key;
				}
			}
			return num;
		}

		// Token: 0x06038549 RID: 230729 RVA: 0x00E42C88 File Offset: 0x00E40E88
		public long GetCycleRemainTime()
		{
			int newSeasonId = this.GetNewSeasonId();
			return this.GetSeasonDataById(newSeasonId).EndTime;
		}

		// Token: 0x0603854A RID: 230730 RVA: 0x00E42CA8 File Offset: 0x00E40EA8
		private void InitIllustratedData(RogueResActivityData rogueData)
		{
			if (this.IllustratedTokenMap.Count == 0)
			{
				this.InitIllustratedMap();
			}
			foreach (int num in rogueData.RogueResGlobalInfo.Dict.Keys)
			{
				int num2 = num;
				this.IllustratedState[num2] = rogueData.RogueResGlobalInfo.Dict[num];
				RogueResCollection value = ConfigRogueResCollectionByIdKey.GetConfig(num2, true).Value;
				if (value.Type == 0)
				{
					this.SetTokenMapInfo(num2);
				}
				else if (value.Type == 1)
				{
					this.SetNormalMapInfo(num2);
				}
				else
				{
					this.SetMapMapInfo(num2);
				}
			}
		}

		// Token: 0x0603854B RID: 230731 RVA: 0x00E42D68 File Offset: 0x00E40F68
		private void InitIllustratedMap()
		{
			IReadOnlyList<RogueResTheme> configList = ConfigRogueResThemeAll.GetConfigList(true);
			this.IllustratedTokenMap[0] = new HashSet<int>();
			this.IllustratedNormalMap[0] = new HashSet<int>();
			this.IllustratedMapMap[0] = new HashSet<int>();
			if (configList == null)
			{
				return;
			}
			foreach (RogueResTheme rogueResTheme in configList)
			{
				this.IllustratedTokenMap[rogueResTheme.Id] = new HashSet<int>();
				this.IllustratedNormalMap[rogueResTheme.Id] = new HashSet<int>();
				this.IllustratedMapMap[rogueResTheme.Id] = new HashSet<int>();
			}
		}

		// Token: 0x0603854C RID: 230732 RVA: 0x00E42E2C File Offset: 0x00E4102C
		private void SetTokenMapInfo(int tokenIndex)
		{
			this.IllustratedTokenMap[0].Add(tokenIndex);
			RogueResCollectionRule? config = ConfigRogueResCollectionRuleById.GetConfig(ConfigRogueResCollectionByIdKey.GetConfig(tokenIndex, true).Value.RuleId, true);
			bool flag = config == null || config.Value.Type == 2;
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.IllustratedTokenMap)
			{
				int key = keyValuePair.Key;
				if (flag)
				{
					if (config == null || !config.Value.SeasonsIter().Contains(key))
					{
						this.IllustratedTokenMap[key].Add(tokenIndex);
					}
				}
				else if (config != null && config.Value.SeasonsIter().Contains(key))
				{
					this.IllustratedTokenMap[key].Add(tokenIndex);
				}
			}
		}

		// Token: 0x0603854D RID: 230733 RVA: 0x00E42F4C File Offset: 0x00E4114C
		private void SetNormalMapInfo(int index)
		{
			this.IllustratedNormalMap[0].Add(index);
			RogueResCollectionRule? config = ConfigRogueResCollectionRuleById.GetConfig(ConfigRogueResCollectionByIdKey.GetConfig(index, true).Value.RuleId, true);
			bool flag = config == null || config.Value.Type == 2;
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.IllustratedNormalMap)
			{
				int key = keyValuePair.Key;
				if (flag)
				{
					if (config == null || !config.Value.SeasonsIter().Contains(key))
					{
						this.IllustratedNormalMap[key].Add(index);
					}
				}
				else if (config != null && config.Value.SeasonsIter().Contains(key))
				{
					this.IllustratedNormalMap[key].Add(index);
				}
			}
		}

		// Token: 0x0603854E RID: 230734 RVA: 0x00E4306C File Offset: 0x00E4126C
		private void SetMapMapInfo(int index)
		{
			this.IllustratedMapMap[0].Add(index);
			RogueResCollectionRule? config = ConfigRogueResCollectionRuleById.GetConfig(ConfigRogueResCollectionByIdKey.GetConfig(index, true).Value.RuleId, true);
			bool flag = config == null || config.Value.Type == 2;
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.IllustratedMapMap)
			{
				int key = keyValuePair.Key;
				if (flag)
				{
					if (config == null || !config.Value.SeasonsIter().Contains(key))
					{
						this.IllustratedMapMap[key].Add(index);
					}
				}
				else if (config != null && config.Value.SeasonsIter().Contains(key))
				{
					this.IllustratedMapMap[key].Add(index);
				}
			}
		}

		// Token: 0x0603854F RID: 230735 RVA: 0x00E4318C File Offset: 0x00E4138C
		public void UpdateIllustrateState(RogueResIllustrationUpdateNotify updateData)
		{
			foreach (int num in updateData.Dict.Keys)
			{
				int num2 = num;
				this.IllustratedState[num2] = updateData.Dict[num];
				RogueResCollection? config = ConfigRogueResCollectionByIdKey.GetConfig(num2, true);
				if (config.Value.Type == 0)
				{
					this.SetTokenMapInfo(num2);
				}
				else if (config.Value.Type == 1)
				{
					this.SetNormalMapInfo(num2);
				}
				else
				{
					this.SetMapMapInfo(num2);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PermanentRogueRewardUpdate);
		}

		// Token: 0x06038550 RID: 230736 RVA: 0x00E43248 File Offset: 0x00E41448
		public HashSet<int> GetTokenIndexSet(int seasonId)
		{
			HashSet<int> result;
			if (this.IllustratedTokenMap.TryGetValue(seasonId, out result))
			{
				return result;
			}
			return new HashSet<int>();
		}

		// Token: 0x06038551 RID: 230737 RVA: 0x00E4326C File Offset: 0x00E4146C
		public List<int> GetTokenInSeason(int token)
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.IllustratedTokenMap)
			{
				if (keyValuePair.Value.Contains(token))
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x06038552 RID: 230738 RVA: 0x00E432DC File Offset: 0x00E414DC
		public HashSet<int> GetNormalIndexSet(int seasonId)
		{
			HashSet<int> result;
			if (this.IllustratedNormalMap.TryGetValue(seasonId, out result))
			{
				return result;
			}
			return new HashSet<int>();
		}

		// Token: 0x06038553 RID: 230739 RVA: 0x00E43300 File Offset: 0x00E41500
		public List<int> GetEventNormalInSeason(int id)
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.IllustratedNormalMap)
			{
				if (keyValuePair.Value.Contains(id))
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x06038554 RID: 230740 RVA: 0x00E43370 File Offset: 0x00E41570
		public HashSet<int> GetMapIndexSet(int seasonId)
		{
			HashSet<int> result;
			if (this.IllustratedMapMap.TryGetValue(seasonId, out result))
			{
				return result;
			}
			return new HashSet<int>();
		}

		// Token: 0x06038555 RID: 230741 RVA: 0x00E43394 File Offset: 0x00E41594
		public List<int> GetEventMapInSeason(int id)
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, HashSet<int>> keyValuePair in this.IllustratedMapMap)
			{
				if (keyValuePair.Value.Contains(id))
				{
					list.Add(keyValuePair.Key);
				}
			}
			return list;
		}

		// Token: 0x06038556 RID: 230742 RVA: 0x00E43404 File Offset: 0x00E41604
		public SignState GetCollectItemState(int index)
		{
			if (!this.IllustratedState.ContainsKey(index))
			{
				return SignState.Lock;
			}
			return this.IllustratedState[index];
		}

		// Token: 0x06038557 RID: 230743 RVA: 0x00E43422 File Offset: 0x00E41622
		public Dictionary<int, SignState> GetAllIllustratedState()
		{
			return this.IllustratedState;
		}

		// Token: 0x06038558 RID: 230744 RVA: 0x00E4342C File Offset: 0x00E4162C
		public void SetIllustratedRewardGot(int[] indexList)
		{
			foreach (int key in indexList)
			{
				this.IllustratedState[key] = SignState.IsReceive;
			}
		}

		// Token: 0x06038559 RID: 230745 RVA: 0x00E4345C File Offset: 0x00E4165C
		private void InitRogueQuest(RogueResActivityData rogueData)
		{
			RogueResTaskUpdateNotify rogueResTaskUpdateNotify = rogueData.RogueResGlobalInfo.RogueResTaskUpdateNotify;
			if (rogueResTaskUpdateNotify.RogueResBranchTaskTheme != null)
			{
				if (rogueResTaskUpdateNotify.RogueResBranchTaskTheme.RogueResTaskThemeId == 0)
				{
					return;
				}
				this.RogueTaskConfigId = rogueResTaskUpdateNotify.RogueResBranchTaskTheme.RogueResTaskThemeId;
				RogueResTaskTheme? config = ConfigRogueResTaskThemeById.GetConfig(this.RogueTaskConfigId, true);
				if (config == null)
				{
					return;
				}
				this.TaskEndTime = rogueResTaskUpdateNotify.RogueResBranchTaskTheme.EndTime;
				this.TaskDataListMap.Clear();
				this.TaskDataMap.Clear();
				foreach (DicIntString dicIntString in config.Value.TabNamesIter())
				{
					this.TaskDataListMap[dicIntString.Key] = new List<int>();
				}
				foreach (ActivityTask activityTask in rogueResTaskUpdateNotify.RogueResBranchTaskTheme.BranchActivityTasks)
				{
					RogueTaskData rogueTaskData = new RogueTaskData(activityTask.Id);
					rogueTaskData.Current = activityTask.Current;
					rogueTaskData.Target = activityTask.Target;
					rogueTaskData.Status = activityTask.Status;
					this.TaskDataMap[activityTask.Id] = rogueTaskData;
					RogueResTask? config2 = ConfigRogueResTaskById.GetConfig(activityTask.Id, true);
					this.TaskDataListMap[config2.Value.Type].Add(activityTask.Id);
				}
			}
		}

		// Token: 0x0603855A RID: 230746 RVA: 0x00E43600 File Offset: 0x00E41800
		public List<int> GetTaskListByType(int type)
		{
			List<int> result;
			if (this.TaskDataListMap.TryGetValue(type, out result))
			{
				return result;
			}
			return new List<int>();
		}

		// Token: 0x0603855B RID: 230747 RVA: 0x00E43624 File Offset: 0x00E41824
		public RogueTaskData GetTaskById(int configId)
		{
			return this.TaskDataMap[configId];
		}

		// Token: 0x0603855C RID: 230748 RVA: 0x00E43632 File Offset: 0x00E41832
		public int GetTaskThemeId()
		{
			return this.RogueTaskConfigId;
		}

		// Token: 0x0603855D RID: 230749 RVA: 0x00E4363A File Offset: 0x00E4183A
		public void SetTaskRewardGot(int configId)
		{
			if (!this.TaskDataMap.ContainsKey(configId))
			{
				return;
			}
			this.TaskDataMap[configId].Status = ActivityTaskState.ActivityTaskTaken;
		}

		// Token: 0x0603855E RID: 230750 RVA: 0x00E43660 File Offset: 0x00E41860
		public void UpdateTaskNotify(RogueResTaskUpdateNotify updateData)
		{
			if (updateData.RogueResBranchTaskTheme != null)
			{
				foreach (ActivityTask activityTask in updateData.RogueResBranchTaskTheme.BranchActivityTasks)
				{
					RogueTaskData rogueTaskData = new RogueTaskData(activityTask.Id);
					rogueTaskData.Current = activityTask.Current;
					rogueTaskData.Target = activityTask.Target;
					rogueTaskData.Status = activityTask.Status;
					this.TaskDataMap[activityTask.Id] = rogueTaskData;
					int type = ConfigRogueResTaskById.GetConfig(activityTask.Id, true).Value.Type;
					if (!this.TaskDataListMap[type].Contains(activityTask.Id))
					{
						this.TaskDataListMap[type].Add(activityTask.Id);
					}
				}
				if (updateData.RogueResBranchTaskTheme.RogueResTaskThemeId != 0)
				{
					this.RogueTaskConfigId = updateData.RogueResBranchTaskTheme.RogueResTaskThemeId;
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.PermanentRogueRewardUpdate);
		}

		// Token: 0x0603855F RID: 230751 RVA: 0x00E4377C File Offset: 0x00E4197C
		private void InitEnding(IList<RogueResSeasonData> seasons)
		{
			foreach (RogueResSeasonData rogueResSeasonData in seasons)
			{
				if (!this.EndingSetMap.ContainsKey(rogueResSeasonData.SeasonId))
				{
					this.EndingSetMap[rogueResSeasonData.SeasonId] = new HashSet<int>();
				}
				foreach (int item in rogueResSeasonData.Endings)
				{
					this.EndingSetMap[rogueResSeasonData.SeasonId].Add(item);
				}
				if (!this.EndingMultiReward.ContainsKey(rogueResSeasonData.SeasonId))
				{
					this.EndingMultiReward[rogueResSeasonData.SeasonId] = new List<int>();
				}
				foreach (ActivityTask activityTask in rogueResSeasonData.EndingRewardIds)
				{
					if (!this.EndingMultiReward[rogueResSeasonData.SeasonId].Contains(activityTask.Id))
					{
						this.EndingMultiReward[rogueResSeasonData.SeasonId].Add(activityTask.Id);
						this.UpdateEndingReward(activityTask);
					}
				}
			}
		}

		// Token: 0x06038560 RID: 230752 RVA: 0x00E43908 File Offset: 0x00E41B08
		public bool GetEndingReachedById(int seasonId, int endingId)
		{
			HashSet<int> hashSet;
			return this.EndingSetMap.TryGetValue(seasonId, out hashSet) && hashSet.Contains(endingId);
		}

		// Token: 0x06038561 RID: 230753 RVA: 0x00E43930 File Offset: 0x00E41B30
		public void UpdateEndingAward(int taskId)
		{
			IActivityRewardData activityRewardData = this.EndingMultiRewardState[taskId];
			activityRewardData.RewardState = EActivityRewardState.Claimed;
			this.EndingMultiRewardState[taskId] = activityRewardData;
		}

		// Token: 0x06038562 RID: 230754 RVA: 0x00E43960 File Offset: 0x00E41B60
		public void UpdateEndingNotify(RogueResEndingUpdateNotify message)
		{
			HashSet<int> hashSet = new HashSet<int>();
			foreach (int num in message.Endings)
			{
				RogueResEnd value = ConfigRogueResEndById.GetConfig(num, true).Value;
				if (!this.EndingSetMap.ContainsKey(value.SeasonId))
				{
					this.EndingSetMap[value.SeasonId] = new HashSet<int>();
				}
				this.EndingSetMap[value.SeasonId].Add(num);
			}
			foreach (ActivityTask activityTask in message.EndingRewardIds)
			{
				RogueResEndAward value2 = ConfigRogueResEndAwardById.GetConfig(activityTask.Id, true).Value;
				hashSet.Add(value2.SeasonId);
				if (!this.EndingMultiReward.ContainsKey(value2.SeasonId))
				{
					this.EndingMultiReward[value2.SeasonId] = new List<int>();
				}
				if (!this.EndingMultiReward[value2.SeasonId].Contains(activityTask.Id))
				{
					this.EndingMultiReward[value2.SeasonId].Add(activityTask.Id);
				}
				this.UpdateEndingReward(activityTask);
			}
			foreach (int p in hashSet)
			{
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, p);
			}
		}

		// Token: 0x06038563 RID: 230755 RVA: 0x00E43B24 File Offset: 0x00E41D24
		private void UpdateEndingReward(ActivityTask data)
		{
			IActivityRewardData activityRewardData;
			this.EndingMultiRewardState.TryGetValue(data.Id, out activityRewardData);
			string rewardButtonTextId = (this.TaskStateToRewardState[data.Status] == EActivityRewardState.Enable) ? "Moonfiesta_AwardGet" : "Moonfiesta_Underway";
			if (activityRewardData != null)
			{
				IActivityRewardData activityRewardData2 = activityRewardData;
				string[] array = new string[1];
				int num = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
				array[num] = defaultInterpolatedStringHandler.ToStringAndClear();
				activityRewardData2.NameTextArgs = array;
				activityRewardData.RewardState = this.TaskStateToRewardState[data.Status];
				activityRewardData.RewardButtonTextId = rewardButtonTextId;
			}
			else
			{
				RogueResEndAward config = ConfigRogueResEndAwardById.GetConfig(data.Id, true).Value;
				ActivityRewardData activityRewardData3 = new ActivityRewardData();
				activityRewardData3.Id = new int?(data.Id);
				activityRewardData3.NameText = "";
				activityRewardData3.NameTextId = config.Desc;
				ActivityRewardData activityRewardData4 = activityRewardData3;
				string[] array2 = new string[1];
				int num2 = 0;
				DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Current);
				defaultInterpolatedStringHandler.AppendLiteral("/");
				defaultInterpolatedStringHandler.AppendFormatted<int>(data.Target);
				array2[num2] = defaultInterpolatedStringHandler.ToStringAndClear();
				activityRewardData4.NameTextArgs = array2;
				activityRewardData3.RewardList = base.GetPreviewReward(new int?(config.Award)).ToArray();
				activityRewardData3.RewardState = this.TaskStateToRewardState[data.Status];
				activityRewardData3.ClickFunction = delegate()
				{
					ControllerBase<ActivityPermanentRogueController>.Instance.RequestRogueResEndingReward(config.SeasonId, data.Id, config.Index);
				};
				activityRewardData3.RewardButtonTextId = rewardButtonTextId;
				activityRewardData = activityRewardData3;
			}
			this.EndingMultiRewardState[data.Id] = activityRewardData;
		}

		// Token: 0x06038564 RID: 230756 RVA: 0x00E43D18 File Offset: 0x00E41F18
		public List<IActivityRewardData> GetEndingAwardList(int seasonId)
		{
			List<int> list;
			if (!this.EndingMultiReward.TryGetValue(seasonId, out list))
			{
				return new List<IActivityRewardData>();
			}
			List<IActivityRewardData> list2 = new List<IActivityRewardData>();
			foreach (int key in list)
			{
				list2.Add(this.EndingMultiRewardState[key]);
			}
			return list2;
		}

		// Token: 0x06038565 RID: 230757 RVA: 0x00E43D90 File Offset: 0x00E41F90
		public void InitShopItem(IList<RogueResSeasonData> data)
		{
			foreach (RogueResSeasonData rogueResSeasonData in data)
			{
				this.UpdateTotalShopItem(rogueResSeasonData.SeasonId, rogueResSeasonData.TotalShopItem);
			}
		}

		// Token: 0x06038566 RID: 230758 RVA: 0x00E43DE4 File Offset: 0x00E41FE4
		public void UpdateTotalShopItem(int season, int count)
		{
			this.ShopItemCount[season] = count;
		}

		// Token: 0x06038567 RID: 230759 RVA: 0x00E43DF4 File Offset: 0x00E41FF4
		public int GetTotalShopItem(int season)
		{
			int result;
			if (this.ShopItemCount.TryGetValue(season, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06038568 RID: 230760 RVA: 0x00E43E14 File Offset: 0x00E42014
		public void UpgradeSkill(int skillId, int level)
		{
			this.GetSeasonDataById(ConfigRogueResTalentTreeById.GetConfig(skillId, true).Value.SeasonId).TalentSkillDict[skillId] = level;
		}

		// Token: 0x04020217 RID: 131607
		private const int ALL_SEASON_ID = 0;

		// Token: 0x04020218 RID: 131608
		private readonly Dictionary<ActivityTaskState, EActivityRewardState> TaskStateToRewardState = new Dictionary<ActivityTaskState, EActivityRewardState>
		{
			{
				ActivityTaskState.ActivityTaskRunning,
				EActivityRewardState.Disabled
			},
			{
				ActivityTaskState.ActivityTaskFinish,
				EActivityRewardState.Enable
			},
			{
				ActivityTaskState.ActivityTaskTaken,
				EActivityRewardState.Claimed
			}
		};

		// Token: 0x04020219 RID: 131609
		private readonly Dictionary<int, RogueResSeasonData> RogueSeasonDataMap = new Dictionary<int, RogueResSeasonData>();

		// Token: 0x0402021A RID: 131610
		private readonly Dictionary<int, SignState> IllustratedState = new Dictionary<int, SignState>();

		// Token: 0x0402021B RID: 131611
		private readonly Dictionary<int, HashSet<int>> IllustratedTokenMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x0402021C RID: 131612
		private readonly Dictionary<int, HashSet<int>> IllustratedNormalMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x0402021D RID: 131613
		private readonly Dictionary<int, HashSet<int>> IllustratedMapMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x0402021E RID: 131614
		private readonly Dictionary<int, RogueTaskData> TaskDataMap = new Dictionary<int, RogueTaskData>();

		// Token: 0x0402021F RID: 131615
		public long TaskEndTime;

		// Token: 0x04020220 RID: 131616
		private readonly Dictionary<int, List<int>> TaskDataListMap = new Dictionary<int, List<int>>();

		// Token: 0x04020221 RID: 131617
		private readonly Dictionary<int, HashSet<int>> EndingSetMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x04020222 RID: 131618
		private readonly Dictionary<int, List<int>> EndingMultiReward = new Dictionary<int, List<int>>();

		// Token: 0x04020223 RID: 131619
		private readonly Dictionary<int, IActivityRewardData> EndingMultiRewardState = new Dictionary<int, IActivityRewardData>();

		// Token: 0x04020224 RID: 131620
		private readonly Dictionary<int, int> ShopItemCount = new Dictionary<int, int>();

		// Token: 0x04020225 RID: 131621
		private int RogueTaskConfigId;
	}
}
