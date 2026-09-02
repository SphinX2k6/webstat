using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.Activity.ActivityContent.SpringManor
{
	// Token: 0x020062FD RID: 25341
	[NullableContext(1)]
	[Nullable(0)]
	public class SpringManorData : ActivityBaseData
	{
		// Token: 0x0603FB43 RID: 260931 RVA: 0x01054CD4 File Offset: 0x01052ED4
		protected override void PhraseEx(ActivityData data)
		{
			SpringManorModel instance = ModelBase<SpringManorModel>.Instance;
			if (instance != null)
			{
				instance.SetActivityId(base.Id);
			}
			SpringFestivalActivityInfo springFestivalActivityInfo = data.SpringFestivalActivityInfo;
			if (springFestivalActivityInfo == null)
			{
				return;
			}
			this.ParseAtmosphere(springFestivalActivityInfo);
			this.ParseSkipEntryList(springFestivalActivityInfo.SpringSkipEntries);
			this.ParseUnlockedFunctionIdList(springFestivalActivityInfo.SpringFunctionIds);
			this.ParseRewardTaskInfo(springFestivalActivityInfo.ConditionTasks);
			this.ParseRewardScoreIdList(springFestivalActivityInfo.RewardScoreIds);
			this.ParseGuessJokerGameData(springFestivalActivityInfo.JokerLevelInfos);
			this.ParseDrinksGameData(springFestivalActivityInfo.DrinkMixData);
			int mapIdByActivityId = ConfigBase<SpringManorConfig>.Instance.GetMapIdByActivityId(base.Id);
			ControllerBase<FurnitureController>.Instance.UpdateData(base.Id, mapIdByActivityId, springFestivalActivityInfo.AreaInfos.ToArray<AreaInfo>(), springFestivalActivityInfo.UnlockFurnitures.ToArray<int>());
			this.ParseBrochureInfos(springFestivalActivityInfo.OneBrochureInfos);
		}

		// Token: 0x0603FB44 RID: 260932 RVA: 0x01054D98 File Offset: 0x01052F98
		public void ParseSkipEntryList(RepeatedField<SpringSkipEntry> skipEntryList)
		{
			this.SkipEntryMap.Clear();
			foreach (SpringSkipEntry springSkipEntry in skipEntryList)
			{
				this.SkipEntryMap.Add(springSkipEntry.Id, springSkipEntry);
			}
		}

		// Token: 0x0603FB45 RID: 260933 RVA: 0x01054DF8 File Offset: 0x01052FF8
		public void OnSkipEntryUpdateNotify(SpringSkipEntry skipEntry)
		{
			if (this.SkipEntryMap.ContainsKey(skipEntry.Id))
			{
				this.SkipEntryMap[skipEntry.Id] = skipEntry;
				return;
			}
			this.SkipEntryMap.Add(skipEntry.Id, skipEntry);
		}

		// Token: 0x0603FB46 RID: 260934 RVA: 0x01054E34 File Offset: 0x01053034
		public bool IsSkipEntryUnLock(int skipEntryId)
		{
			SpringSkipEntry springSkipEntry;
			return !this.SkipEntryMap.TryGetValue(skipEntryId, out springSkipEntry) || springSkipEntry == null || springSkipEntry.UnLock;
		}

		// Token: 0x0603FB47 RID: 260935 RVA: 0x01054E60 File Offset: 0x01053060
		public bool IsSkipEntryFinish(int skipEntryId)
		{
			SpringSkipEntry springSkipEntry;
			return this.SkipEntryMap.TryGetValue(skipEntryId, out springSkipEntry) && springSkipEntry != null && springSkipEntry.Finish;
		}

		// Token: 0x0603FB48 RID: 260936 RVA: 0x01054E8C File Offset: 0x0105308C
		private void ParseRewardScoreIdList(RepeatedField<int> rewardScoreIds)
		{
			foreach (int item in rewardScoreIds)
			{
				this.ScoreRewardClaimedSet.Add(item);
			}
		}

		// Token: 0x0603FB49 RID: 260937 RVA: 0x01054EDC File Offset: 0x010530DC
		public void OnScoreRewardClaimed(List<int> scoreRewardIdList)
		{
			foreach (int item in scoreRewardIdList)
			{
				this.ScoreRewardClaimedSet.Add(item);
			}
		}

		// Token: 0x0603FB4A RID: 260938 RVA: 0x01054F30 File Offset: 0x01053130
		public int GetCurrentMilestone()
		{
			if (this.MilestoneItemId == 0)
			{
				this.MilestoneItemId = ModelBase<SpringManorModel>.Instance.GetActivityConfig().ScoreItemId;
			}
			return ModelBase<InventoryModel>.Instance.GetItemCountByConfigId(this.MilestoneItemId, 0);
		}

		// Token: 0x0603FB4B RID: 260939 RVA: 0x01054F6E File Offset: 0x0105316E
		public bool IsScoreRewardReceived(int scoreRewardId)
		{
			return this.ScoreRewardClaimedSet.Contains(scoreRewardId);
		}

		// Token: 0x0603FB4C RID: 260940 RVA: 0x01054F7C File Offset: 0x0105317C
		public bool IsScoreRewardCanReceived(int scoreRewardId)
		{
			if (this.IsScoreRewardReceived(scoreRewardId))
			{
				return false;
			}
			SpringFestivalScoreReward? scoreRewardConfigById = ConfigBase<SpringManorConfig>.Instance.GetScoreRewardConfigById(scoreRewardId);
			return this.GetCurrentMilestone() >= scoreRewardConfigById.Value.Score;
		}

		// Token: 0x0603FB4D RID: 260941 RVA: 0x01054FBC File Offset: 0x010531BC
		public List<int> GetCanClaimedScoreRewardList()
		{
			List<int> list = new List<int>();
			foreach (SpringFestivalScoreReward springFestivalScoreReward in ConfigBase<SpringManorConfig>.Instance.GetScoreRewardConfigListByActivityId(base.Id))
			{
				if (this.IsScoreRewardCanReceived(springFestivalScoreReward.Id))
				{
					list.Add(springFestivalScoreReward.Id);
				}
			}
			return list;
		}

		// Token: 0x0603FB4E RID: 260942 RVA: 0x01055030 File Offset: 0x01053230
		public bool HasAnyScoreRewardCanClaim()
		{
			return this.GetCanClaimedScoreRewardList().Count > 0;
		}

		// Token: 0x0603FB4F RID: 260943 RVA: 0x01055040 File Offset: 0x01053240
		private void ParseRewardTaskInfo(RepeatedField<ConditionTask> rewardTaskInfo)
		{
			this.RewardTaskMap.Clear();
			foreach (ConditionTask taskData in rewardTaskInfo)
			{
				ActivitySpringManorTaskData activitySpringManorTaskData = new ActivitySpringManorTaskData();
				activitySpringManorTaskData.Refresh(taskData);
				if (this.RewardTaskMap.ContainsKey(activitySpringManorTaskData.Id))
				{
					this.RewardTaskMap[activitySpringManorTaskData.Id] = activitySpringManorTaskData;
				}
				else
				{
					this.RewardTaskMap.Add(activitySpringManorTaskData.Id, activitySpringManorTaskData);
				}
			}
		}

		// Token: 0x0603FB50 RID: 260944 RVA: 0x010550D4 File Offset: 0x010532D4
		public void OnTaskUpdateNotify(ConditionTask conditionTask)
		{
			ActivitySpringManorTaskData rewardTaskData = this.GetRewardTaskData(conditionTask.Id);
			if (rewardTaskData != null)
			{
				rewardTaskData.Refresh(conditionTask);
				return;
			}
			ActivitySpringManorTaskData activitySpringManorTaskData = new ActivitySpringManorTaskData();
			activitySpringManorTaskData.Refresh(conditionTask);
			this.RewardTaskMap.Add(activitySpringManorTaskData.Id, activitySpringManorTaskData);
		}

		// Token: 0x0603FB51 RID: 260945 RVA: 0x01055118 File Offset: 0x01053318
		public void OnRewardTaskClaimed(List<int> claimedTaskIdList)
		{
			foreach (int taskId in claimedTaskIdList)
			{
				ActivitySpringManorTaskData rewardTaskData = this.GetRewardTaskData(taskId);
				if (rewardTaskData != null)
				{
					rewardTaskData.Status = EActivityTaskState.FinishedAndClaimed;
				}
			}
		}

		// Token: 0x0603FB52 RID: 260946 RVA: 0x01055174 File Offset: 0x01053374
		[NullableContext(2)]
		public ActivitySpringManorTaskData GetRewardTaskData(int taskId)
		{
			ActivitySpringManorTaskData result;
			if (this.RewardTaskMap.TryGetValue(taskId, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0603FB53 RID: 260947 RVA: 0x01055194 File Offset: 0x01053394
		public bool IsTaskCanClaim(int taskId)
		{
			ActivitySpringManorTaskData activitySpringManorTaskData;
			return this.RewardTaskMap.TryGetValue(taskId, out activitySpringManorTaskData) && activitySpringManorTaskData.Status == EActivityTaskState.FinishedAndUnclaimed;
		}

		// Token: 0x0603FB54 RID: 260948 RVA: 0x010551BC File Offset: 0x010533BC
		public List<int> GetTabCanClaimableTaskId(int tabId)
		{
			List<int> rewardTaskListByTabId = this.GetRewardTaskListByTabId(tabId);
			List<int> list = new List<int>();
			foreach (int num in rewardTaskListByTabId)
			{
				if (this.IsTaskCanClaim(num))
				{
					list.Add(num);
				}
			}
			return list;
		}

		// Token: 0x0603FB55 RID: 260949 RVA: 0x01055220 File Offset: 0x01053420
		public bool IsTabHasAnyClaimable(int tabId)
		{
			foreach (int taskId in this.GetRewardTaskListByTabId(tabId))
			{
				if (this.IsTaskCanClaim(taskId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FB56 RID: 260950 RVA: 0x01055280 File Offset: 0x01053480
		public bool HasAnyClaimable()
		{
			foreach (int tabId in ModelBase<SpringManorModel>.Instance.GetRewardTaskTabList())
			{
				if (this.IsTabHasAnyClaimable(tabId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FB57 RID: 260951 RVA: 0x010552E0 File Offset: 0x010534E0
		public List<int> GetRewardTaskListByTabId(int tabId)
		{
			List<int> list = new List<int>();
			foreach (KeyValuePair<int, ActivitySpringManorTaskData> keyValuePair in this.RewardTaskMap)
			{
				ActivitySpringManorTaskData value = keyValuePair.Value;
				SpringFestivalReward? rewardTaskConfigById = ConfigBase<SpringManorConfig>.Instance.GetRewardTaskConfigById(value.Id);
				if (rewardTaskConfigById != null && rewardTaskConfigById.Value.TabId == tabId)
				{
					list.Add(value.Id);
				}
			}
			return list;
		}

		// Token: 0x0603FB58 RID: 260952 RVA: 0x01055378 File Offset: 0x01053578
		public int GetTotalRewardTaskProgress()
		{
			int num = 0;
			foreach (int tabId in ModelBase<SpringManorModel>.Instance.GetRewardTaskTabList())
			{
				List<int> rewardTaskListByTabId = this.GetRewardTaskListByTabId(tabId);
				num += rewardTaskListByTabId.Count;
			}
			return num;
		}

		// Token: 0x0603FB59 RID: 260953 RVA: 0x010553DC File Offset: 0x010535DC
		public int GetCurrentRewardTaskProgress()
		{
			int num = 0;
			foreach (int tabId in ModelBase<SpringManorModel>.Instance.GetRewardTaskTabList())
			{
				foreach (int taskId in this.GetRewardTaskListByTabId(tabId))
				{
					ActivitySpringManorTaskData rewardTaskData = this.GetRewardTaskData(taskId);
					if (rewardTaskData != null && rewardTaskData.Status == EActivityTaskState.FinishedAndClaimed)
					{
						num++;
					}
				}
			}
			return num;
		}

		// Token: 0x0603FB5A RID: 260954 RVA: 0x01055488 File Offset: 0x01053688
		public int GetAtmosphere()
		{
			return this.CurrentAtmosphere;
		}

		// Token: 0x0603FB5B RID: 260955 RVA: 0x01055490 File Offset: 0x01053690
		public int GetAtmosphereLevel()
		{
			return this.AtmosphereLevel;
		}

		// Token: 0x0603FB5C RID: 260956 RVA: 0x01055498 File Offset: 0x01053698
		public void OnAtmosphereUpdateNotify(int newAtmosphere, int newLevel)
		{
			this.CurrentAtmosphere = newAtmosphere;
			if (newLevel > this.AtmosphereLevel)
			{
				this.AtmosphereLevel = newLevel;
			}
		}

		// Token: 0x0603FB5D RID: 260957 RVA: 0x010554B4 File Offset: 0x010536B4
		private void ParseAtmosphere(SpringFestivalActivityInfo activityData)
		{
			foreach (int item in activityData.RewardLevelIds)
			{
				this.ClaimedLevelRewardSet.Add(item);
			}
			this.AtmosphereLevel = activityData.AtmosphereLevel;
			this.CurrentAtmosphere = activityData.Atmosphere;
		}

		// Token: 0x0603FB5E RID: 260958 RVA: 0x01055520 File Offset: 0x01053720
		public void OnAtmosphereLevelRewardUpdateNotify(List<int> levelIdList)
		{
			foreach (int item in levelIdList)
			{
				this.ClaimedLevelRewardSet.Add(item);
			}
		}

		// Token: 0x0603FB5F RID: 260959 RVA: 0x01055574 File Offset: 0x01053774
		public bool IsLevelRewardClaimed(int level)
		{
			return this.ClaimedLevelRewardSet.Contains(level);
		}

		// Token: 0x0603FB60 RID: 260960 RVA: 0x01055584 File Offset: 0x01053784
		public bool IsLevelCanReceive(int level)
		{
			if (this.IsLevelRewardClaimed(level))
			{
				return false;
			}
			AtmosphereLevel? atmosphereLevel;
			int? num = (ModelBase<SpringManorModel>.Instance.GetLevelConfig(level) != null) ? new int?(atmosphereLevel.GetValueOrDefault().DropId) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					return level <= this.GetAtmosphereLevel();
				}
			}
			return false;
		}

		// Token: 0x0603FB61 RID: 260961 RVA: 0x01055604 File Offset: 0x01053804
		public bool HasAnyLevelCanReceive()
		{
			int maxLevel = ModelBase<SpringManorModel>.Instance.GetMaxLevel();
			for (int i = 1; i <= maxLevel; i++)
			{
				if (this.IsLevelCanReceive(i))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FB62 RID: 260962 RVA: 0x01055634 File Offset: 0x01053834
		private void ParseUnlockedFunctionIdList(RepeatedField<int> unlockedFunctionIdList)
		{
			this.UnlockedFunctionSet.Clear();
			foreach (int item in unlockedFunctionIdList)
			{
				this.UnlockedFunctionSet.Add((ESpringFunctionType)item);
			}
		}

		// Token: 0x0603FB63 RID: 260963 RVA: 0x01055690 File Offset: 0x01053890
		public void OnFunctionUpdateNotify(int functionId)
		{
			this.UnlockedFunctionSet.Add((ESpringFunctionType)functionId);
		}

		// Token: 0x0603FB64 RID: 260964 RVA: 0x0105569F File Offset: 0x0105389F
		public bool IsFunctionUnlocked(ESpringFunctionType functionType)
		{
			if (functionType == ESpringFunctionType.Gameplay)
			{
				return this.HasAnyGameUnlocked();
			}
			return this.UnlockedFunctionSet.Contains(functionType);
		}

		// Token: 0x0603FB65 RID: 260965 RVA: 0x010556B8 File Offset: 0x010538B8
		public bool HasAnyGameUnlocked()
		{
			foreach (ESpringFunctionType functionType in SpringManorDefine.gameTypeList)
			{
				if (this.IsFunctionUnlocked(functionType))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FB66 RID: 260966 RVA: 0x01055714 File Offset: 0x01053914
		public void ParseGuessJokerGameData(RepeatedField<Aki.Protocol.GuessJokerLevelInfo> guessJokerGameData)
		{
			this.GuessJokerGameDataMap.Clear();
			foreach (Aki.Protocol.GuessJokerLevelInfo guessJokerLevelInfo in guessJokerGameData)
			{
				global::GuessJokerLevelInfo value = new global::GuessJokerLevelInfo
				{
					LevelId = guessJokerLevelInfo.LevelId,
					Unlock = guessJokerLevelInfo.UnLock,
					FirstPass = guessJokerLevelInfo.LevelPass,
					RewardGet = guessJokerLevelInfo.RewardGet,
					PlayerWin = guessJokerLevelInfo.PlayerWin
				};
				if (this.GuessJokerGameDataMap.ContainsKey(guessJokerLevelInfo.LevelId))
				{
					this.GuessJokerGameDataMap[guessJokerLevelInfo.LevelId] = value;
				}
				else
				{
					this.GuessJokerGameDataMap.Add(guessJokerLevelInfo.LevelId, value);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnGuessJokerRedDotNotify);
		}

		// Token: 0x0603FB67 RID: 260967 RVA: 0x010557F4 File Offset: 0x010539F4
		public void UpdateGuessJokerGameData(RepeatedField<Aki.Protocol.GuessJokerLevelInfo> data)
		{
			bool flag = false;
			bool flag2 = false;
			foreach (Aki.Protocol.GuessJokerLevelInfo guessJokerLevelInfo in data)
			{
				IGuessJokerLevelInfo guessJokerLevelInfo2;
				if (this.GuessJokerGameDataMap.TryGetValue(guessJokerLevelInfo.LevelId, out guessJokerLevelInfo2))
				{
					if (!guessJokerLevelInfo2.Unlock && guessJokerLevelInfo.UnLock)
					{
						flag = true;
					}
					if (!guessJokerLevelInfo2.FirstPass && guessJokerLevelInfo.LevelPass && !guessJokerLevelInfo.RewardGet)
					{
						flag2 = true;
						HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerFirstFinishAnim, null) ?? new HashSet<int>();
						hashSet.Add(guessJokerLevelInfo.LevelId);
						LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.GuessJokerFirstFinishAnim, hashSet);
					}
					guessJokerLevelInfo2.Unlock = guessJokerLevelInfo.UnLock;
					guessJokerLevelInfo2.RewardGet = guessJokerLevelInfo.RewardGet;
					guessJokerLevelInfo2.FirstPass = guessJokerLevelInfo.LevelPass;
					guessJokerLevelInfo2.PlayerWin = guessJokerLevelInfo.PlayerWin;
				}
				else
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.GuessJokerCard;
					ELogAuthor author = ELogAuthor.LRC;
					DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(36, 1);
					defaultInterpolatedStringHandler.AppendLiteral("UpdateGuessJokerGameData.");
					defaultInterpolatedStringHandler.AppendFormatted<int>(guessJokerLevelInfo.LevelId);
					defaultInterpolatedStringHandler.AppendLiteral("失败，因为：数据不存在");
					instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
				}
			}
			if (flag || flag2)
			{
				Singleton<EventSystem>.Instance.Emit(EEventName.OnGuessJokerRedDotNotify);
			}
		}

		// Token: 0x0603FB68 RID: 260968 RVA: 0x01055960 File Offset: 0x01053B60
		[NullableContext(2)]
		public IGuessJokerLevelInfo GetGuessJokerGameData(int levelId)
		{
			IGuessJokerLevelInfo result;
			if (this.GuessJokerGameDataMap.TryGetValue(levelId, out result))
			{
				return result;
			}
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.GuessJokerCard;
			ELogAuthor author = ELogAuthor.LRC;
			DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(33, 1);
			defaultInterpolatedStringHandler.AppendLiteral("GetGuessJokerGameData.");
			defaultInterpolatedStringHandler.AppendFormatted<int>(levelId);
			defaultInterpolatedStringHandler.AppendLiteral("失败，因为：数据不存在");
			instance.Error(module, author, defaultInterpolatedStringHandler.ToStringAndClear(), default(ReadOnlySpan<ValueTuple<string, object>>));
			return null;
		}

		// Token: 0x0603FB69 RID: 260969 RVA: 0x010559CC File Offset: 0x01053BCC
		public int GetGuessJokerCurrentProgress()
		{
			int num = 0;
			foreach (KeyValuePair<int, IGuessJokerLevelInfo> keyValuePair in this.GuessJokerGameDataMap)
			{
				if (keyValuePair.Value.RewardGet)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0603FB6A RID: 260970 RVA: 0x01055A30 File Offset: 0x01053C30
		public int GetGuessJokerTotalProgress()
		{
			return this.GuessJokerGameDataMap.Count;
		}

		// Token: 0x0603FB6B RID: 260971 RVA: 0x01055A40 File Offset: 0x01053C40
		public void UpdateLevelGetReward(int levelId)
		{
			IGuessJokerLevelInfo guessJokerGameData = this.GetGuessJokerGameData(levelId);
			if (guessJokerGameData != null)
			{
				guessJokerGameData.RewardGet = true;
				Singleton<EventSystem>.Instance.Emit(EEventName.OnGuessJokerRedDotNotify);
			}
		}

		// Token: 0x0603FB6C RID: 260972 RVA: 0x01055A70 File Offset: 0x01053C70
		[NullableContext(2)]
		private void ParseDrinksGameData(DrinkMixData data)
		{
			if (data == null)
			{
				return;
			}
			foreach (DrinkMixRole drinkMixRole in data.RoleLevelInfo)
			{
				DrinksMixRoleInfo value = new DrinksMixRoleInfo
				{
					RoleId = drinkMixRole.RoleId,
					FirstPass = drinkMixRole.FirstPass,
					MaxLike = drinkMixRole.MaxLike,
					RewardGet = drinkMixRole.RewardGet
				};
				if (this.DrinksRoleDataMap.ContainsKey(drinkMixRole.RoleId))
				{
					this.DrinksRoleDataMap[drinkMixRole.RoleId] = value;
				}
				else
				{
					this.DrinksRoleDataMap.Add(drinkMixRole.RoleId, value);
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnDrinksUnlockClickedNotify);
		}

		// Token: 0x0603FB6D RID: 260973 RVA: 0x01055B3C File Offset: 0x01053D3C
		public int GetDrinksCurrentProgress()
		{
			int num = 0;
			foreach (KeyValuePair<int, IDrinksMixRoleInfo> keyValuePair in this.DrinksRoleDataMap)
			{
				if (keyValuePair.Value.RewardGet)
				{
					num++;
				}
			}
			return num;
		}

		// Token: 0x0603FB6E RID: 260974 RVA: 0x01055BA0 File Offset: 0x01053DA0
		public int GetDrinksTotalProgress()
		{
			return ConfigBase<DrinksConfig>.Instance.GetAllInvite().Count;
		}

		// Token: 0x0603FB6F RID: 260975 RVA: 0x01055BB1 File Offset: 0x01053DB1
		public Dictionary<int, IDrinksMixRoleInfo> GetDrinksProgressMap()
		{
			return this.DrinksRoleDataMap;
		}

		// Token: 0x0603FB70 RID: 260976 RVA: 0x01055BBC File Offset: 0x01053DBC
		public void ParseBrochureInfos(RepeatedField<OneBrochureInfo> data)
		{
			this.InitTargetTypeBookItemData(EBrochureType.Character);
			this.InitTargetTypeBookItemData(EBrochureType.EasterEggBook);
			this.InitTargetTypeBookItemData(EBrochureType.Brochure);
			if (data == null)
			{
				return;
			}
			foreach (OneBrochureInfo oneBrochureInfo in data)
			{
				int brochureId = oneBrochureInfo.BrochureId;
				List<int> brochureUnlockIds = this.BrochureUnlockIds;
				if (brochureUnlockIds != null)
				{
					brochureUnlockIds.Add(brochureId);
				}
				foreach (BookItemInfo bookItemInfo in oneBrochureInfo.BookItemInfos)
				{
					if (this.BookItemMap.ContainsKey(bookItemInfo.BookItemId))
					{
						this.BookItemMap[bookItemInfo.BookItemId] = bookItemInfo;
					}
					else
					{
						this.BookItemMap.Add(bookItemInfo.BookItemId, bookItemInfo);
					}
				}
			}
			Singleton<EventSystem>.Instance.Emit(EEventName.OnBrochureBookItemStateUpdate);
		}

		// Token: 0x0603FB71 RID: 260977 RVA: 0x01055CB4 File Offset: 0x01053EB4
		public void InitTargetTypeBookItemData(EBrochureType brochureType)
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureByActivityAndType(base.Id, brochureType) : null;
			if (brochure == null)
			{
				return;
			}
			for (int i = 0; i < brochure.Value.BookItemIdsLength; i++)
			{
				int num = brochure.Value.BookItemIds(i);
				BookItemInfo value = new BookItemInfo
				{
					BookItemId = num,
					BookItemState = BookItemState.BookItemLock
				};
				if (this.BookItemMap.ContainsKey(num))
				{
					this.BookItemMap[num] = value;
				}
				else
				{
					this.BookItemMap.Add(num, value);
				}
			}
		}

		// Token: 0x0603FB72 RID: 260978 RVA: 0x01055D5A File Offset: 0x01053F5A
		public void AddUnlockBrochureId(int id)
		{
			if (this.BrochureUnlockIds == null)
			{
				return;
			}
			List<int> brochureUnlockIds = this.BrochureUnlockIds;
			if (brochureUnlockIds == null)
			{
				return;
			}
			brochureUnlockIds.Add(id);
		}

		// Token: 0x0603FB73 RID: 260979 RVA: 0x01055D76 File Offset: 0x01053F76
		public void SetBookItemDataById(int id, BookItemInfo info)
		{
			if (info == null)
			{
				return;
			}
			if (this.BookItemMap.ContainsKey(id))
			{
				this.BookItemMap[id] = info;
				return;
			}
			this.BookItemMap.Add(id, info);
		}

		// Token: 0x0603FB74 RID: 260980 RVA: 0x01055DA8 File Offset: 0x01053FA8
		[NullableContext(2)]
		public BookItemInfo GetBookItemDataById(int id)
		{
			if (!this.BookItemMap.ContainsKey(id))
			{
				return null;
			}
			BookItemInfo result;
			if (this.BookItemMap.TryGetValue(id, out result))
			{
				return result;
			}
			return null;
		}

		// Token: 0x0603FB75 RID: 260981 RVA: 0x01055DD8 File Offset: 0x01053FD8
		public void SetTargetBookItemState(int id, BookItemState state)
		{
			BookItemInfo bookItemDataById = this.GetBookItemDataById(id);
			if (bookItemDataById != null)
			{
				bookItemDataById.BookItemState = state;
			}
		}

		// Token: 0x0603FB76 RID: 260982 RVA: 0x01055DF8 File Offset: 0x01053FF8
		public EBrochureState GetBookItemStateById(int id)
		{
			BookItemInfo bookItemDataById = this.GetBookItemDataById(id);
			if (bookItemDataById != null)
			{
				return this.SwitchBookItemState(bookItemDataById.BookItemState);
			}
			return EBrochureState.None;
		}

		// Token: 0x0603FB77 RID: 260983 RVA: 0x01055E1E File Offset: 0x0105401E
		public EBrochureState SwitchBookItemState(BookItemState state)
		{
			switch (state)
			{
			case BookItemState.BookItemLock:
				return EBrochureState.Lock;
			case BookItemState.BookItemUnlock:
				return EBrochureState.Unlock;
			case BookItemState.BookItemRewarded:
				return EBrochureState.Rewarded;
			default:
				return EBrochureState.None;
			}
		}

		// Token: 0x0603FB78 RID: 260984 RVA: 0x01055E3C File Offset: 0x0105403C
		public int GetNextLockBookItemId(int currentItemId)
		{
			SpringManorConfig instance = ConfigBase<SpringManorConfig>.Instance;
			Brochure? brochure = (instance != null) ? instance.GetSpringManorBrochureByActivityAndType(base.Id, EBrochureType.Brochure) : null;
			if (brochure == null)
			{
				return 0;
			}
			int num = 0;
			for (int i = brochure.Value.BookItemIdsLength - 1; i >= 0; i--)
			{
				int num2 = brochure.Value.BookItemIds(i);
				if (num2 == currentItemId && num > 0)
				{
					break;
				}
				if (this.GetBookItemStateById(num2) == EBrochureState.Lock)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x0603FB79 RID: 260985 RVA: 0x01055EBE File Offset: 0x010540BE
		public void ReadFirstOpenRedDot()
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			if (instance != null)
			{
				instance.SaveActivityData(base.Id, 0, 0, 0, 1);
			}
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, base.Id);
		}

		// Token: 0x0603FB7A RID: 260986 RVA: 0x01055EF0 File Offset: 0x010540F0
		public bool HasActivityRedDot()
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			int? num = (instance != null) ? new int?(instance.GetActivityCacheData(base.Id, 0, 0, 0, 0)) : null;
			if (num != null)
			{
				int? num2 = num;
				int num3 = 0;
				if (!(num2.GetValueOrDefault() == num3 & num2 != null))
				{
					return this.HasRewardRedDot() || this.HasAtmosphereRedDot() || this.HasAnySubQuestRedDot() || ModelBase<DrinksModel>.Instance.CheckRedDot() || ModelBase<GuessJokerGamePlayModel>.Instance.CheckRedDot() || ModelBase<FurnitureModel>.Instance.CheckFurnitureEntranceRedDot() || ModelBase<SpringManorModel>.Instance.CheckAnyBookItemRedDot();
				}
			}
			return true;
		}

		// Token: 0x0603FB7B RID: 260987 RVA: 0x01055F94 File Offset: 0x01054194
		public bool HasRewardRedDot()
		{
			return this.HasAnyClaimable() || this.HasAnyScoreRewardCanClaim();
		}

		// Token: 0x0603FB7C RID: 260988 RVA: 0x01055FA6 File Offset: 0x010541A6
		public bool HasAtmosphereRedDot()
		{
			return this.HasAnyLevelCanReceive();
		}

		// Token: 0x0603FB7D RID: 260989 RVA: 0x01055FB0 File Offset: 0x010541B0
		public bool HasAnySubQuestRedDot()
		{
			foreach (int questId in ModelBase<SpringManorModel>.Instance.GetSubQuestList())
			{
				if (this.HasSubQuestRedDot(questId))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603FB7E RID: 260990 RVA: 0x01056010 File Offset: 0x01054210
		public bool HasSubQuestRedDot(int questId)
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			return ((instance != null) ? new int?(instance.GetActivityCacheData(base.Id, 0, 1, questId, 0)) : null).GetValueOrDefault() != 1;
		}

		// Token: 0x0603FB7F RID: 260991 RVA: 0x01056053 File Offset: 0x01054253
		public void ReadSubQuestRedDot(int questId)
		{
			ActivityModel instance = ModelBase<ActivityModel>.Instance;
			if (instance == null)
			{
				return;
			}
			instance.SaveActivityData(base.Id, 1, questId, 0, 1);
		}

		// Token: 0x0603FB80 RID: 260992 RVA: 0x0105606E File Offset: 0x0105426E
		public override bool GetExDataRedPointShowState()
		{
			return this.HasActivityRedDot();
		}

		// Token: 0x0603FB81 RID: 260993 RVA: 0x01056078 File Offset: 0x01054278
		protected override bool GetExDataFinishShowState()
		{
			foreach (ESpringFunctionType key in SpringManorDefine.gameTypeList)
			{
				SpringManorGameHandleBase springManorGameHandleBase;
				if (SpringManorGameHandleDefine.springManorGameHandleDefine.TryGetValue(key, out springManorGameHandleBase) && springManorGameHandleBase.GetCurrentProgress() < springManorGameHandleBase.GetTotalProgress())
				{
					return false;
				}
			}
			foreach (KeyValuePair<int, ActivitySpringManorTaskData> keyValuePair in this.RewardTaskMap)
			{
				if (keyValuePair.Value.Status != EActivityTaskState.FinishedAndClaimed)
				{
					return false;
				}
			}
			if (ModelBase<SpringManorModel>.Instance.GetScoreRewardConfigList().Count > this.ScoreRewardClaimedSet.Count)
			{
				return false;
			}
			int maxLevel = ModelBase<SpringManorModel>.Instance.GetMaxLevel();
			return this.ClaimedLevelRewardSet.Count >= maxLevel;
		}

		// Token: 0x04023C11 RID: 146449
		private readonly Dictionary<int, SpringSkipEntry> SkipEntryMap = new Dictionary<int, SpringSkipEntry>();

		// Token: 0x04023C12 RID: 146450
		private readonly HashSet<int> ScoreRewardClaimedSet = new HashSet<int>();

		// Token: 0x04023C13 RID: 146451
		private int MilestoneItemId;

		// Token: 0x04023C14 RID: 146452
		private readonly Dictionary<int, ActivitySpringManorTaskData> RewardTaskMap = new Dictionary<int, ActivitySpringManorTaskData>();

		// Token: 0x04023C15 RID: 146453
		private int CurrentAtmosphere;

		// Token: 0x04023C16 RID: 146454
		private int AtmosphereLevel;

		// Token: 0x04023C17 RID: 146455
		private readonly HashSet<int> ClaimedLevelRewardSet = new HashSet<int>();

		// Token: 0x04023C18 RID: 146456
		private readonly HashSet<ESpringFunctionType> UnlockedFunctionSet = new HashSet<ESpringFunctionType>();

		// Token: 0x04023C19 RID: 146457
		private readonly Dictionary<int, IGuessJokerLevelInfo> GuessJokerGameDataMap = new Dictionary<int, IGuessJokerLevelInfo>();

		// Token: 0x04023C1A RID: 146458
		private readonly Dictionary<int, IDrinksMixRoleInfo> DrinksRoleDataMap = new Dictionary<int, IDrinksMixRoleInfo>();

		// Token: 0x04023C1B RID: 146459
		private readonly Dictionary<int, BookItemInfo> BookItemMap = new Dictionary<int, BookItemInfo>();

		// Token: 0x04023C1C RID: 146460
		[Nullable(2)]
		private readonly List<int> BrochureUnlockIds = new List<int>();
	}
}
