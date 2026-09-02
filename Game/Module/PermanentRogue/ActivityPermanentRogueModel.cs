using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.RougeActivity;
using CSharpScript.Game.Module.InstanceDungeon.ExchangeReward;
using CSharpScript.Game.Module.MapRogue;
using CSharpScript.Game.Module.PayShop;
using CSharpScript.Game.Ui;
using CSharpScript.Module.InstanceDungeon;
using Google.Protobuf.Collections;

namespace CSharpScript.Game.Module.PermanentRogue
{
	// Token: 0x02005653 RID: 22099
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class ActivityPermanentRogueModel : ModelBase<ActivityPermanentRogueModel>
	{
		// Token: 0x0603856A RID: 230762 RVA: 0x00E43EFB File Offset: 0x00E420FB
		protected override bool OnInit()
		{
			Singleton<UiManager>.Instance.AddOpenViewCheckFunction(EUiViewName.RogueTaskView, new Func<EUiViewName, object, bool>(this.CanOpenTaskView), "ActivityPermanentRogueModel.CanOpenTaskView");
			return true;
		}

		// Token: 0x0603856B RID: 230763 RVA: 0x00E43F1E File Offset: 0x00E4211E
		protected override bool OnClear()
		{
			Singleton<UiManager>.Instance.RemoveOpenViewCheckFunction(EUiViewName.RogueTaskView, new Func<EUiViewName, object, bool>(this.CanOpenTaskView));
			return true;
		}

		// Token: 0x0603856C RID: 230764 RVA: 0x00E43F3C File Offset: 0x00E4213C
		public ActivityPermanentRogueData GetActivityData()
		{
			return ModelBase<ActivityModel>.Instance.GetActivityById(ControllerBase<ActivityPermanentRogueController>.Instance.ActivityId) as ActivityPermanentRogueData;
		}

		// Token: 0x0603856D RID: 230765 RVA: 0x00E43F57 File Offset: 0x00E42157
		public int GetNewSeasonId()
		{
			return this.GetActivityData().GetNewSeasonId();
		}

		// Token: 0x0603856E RID: 230766 RVA: 0x00E43F64 File Offset: 0x00E42164
		public void InitCurrency(IDictionary<int, int> currencyDict)
		{
			this.CurrencyMap.Clear();
			foreach (int num in currencyDict.Keys)
			{
				int num2 = num;
				int num3 = currencyDict[num];
				this.CurrencyMap[num2] = currencyDict[num];
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, num2);
			}
			this.SkillCurrencySet.Clear();
			foreach (RogueResTheme rogueResTheme in ConfigRogueResThemeAll.GetConfigList(true))
			{
				this.SkillCurrencySet[rogueResTheme.SkillItem] = rogueResTheme.Id;
			}
		}

		// Token: 0x0603856F RID: 230767 RVA: 0x00E44040 File Offset: 0x00E42240
		public void UpdateCurrency(IDictionary<int, int> currencyDict, int? eventType = null)
		{
			foreach (int num in currencyDict.Keys)
			{
				int num2 = num;
				int num3 = currencyDict[num];
				int? num4 = null;
				int value;
				if (this.CurrencyMap.TryGetValue(num2, out value))
				{
					num4 = new int?(value);
				}
				if (this.SkillCurrencySet.ContainsKey(num2))
				{
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSkillCurrencyRedDotUpdate, this.SkillCurrencySet[num2]);
					Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, this.SkillCurrencySet[num2]);
				}
				if (num4 != null)
				{
					this.CurrencyMap[num2] = num4.Value + num3;
				}
				else
				{
					this.CurrencyMap[num2] = num3;
				}
				MapRogueGameInfo gameInfo = ModelBase<MapRogueModel>.Instance.GameInfo;
				if (gameInfo != null)
				{
					if (gameInfo.InBattle)
					{
						if (num3 > 0)
						{
							ControllerBase<ItemHintController>.Instance.AddRoguelikeItemList(num2, num3);
						}
					}
					else if (eventType != null && ConfigBase<MapRogueConfig>.Instance.GetGlobalParamConfig().Value.ShowCurrencyChangeEventTypeIter().Contains(eventType.Value))
					{
						MapRogueGameInfo gameInfo2 = ModelBase<MapRogueModel>.Instance.GameInfo;
						if (gameInfo2 != null)
						{
							gameInfo2.PushGetItemData(num2, num3);
						}
					}
				}
				Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnPlayerCurrencyChange, num2);
			}
		}

		// Token: 0x06038570 RID: 230768 RVA: 0x00E441BC File Offset: 0x00E423BC
		public int GetCurrency(int id)
		{
			int result;
			if (this.CurrencyMap.TryGetValue(id, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06038571 RID: 230769 RVA: 0x00E441DC File Offset: 0x00E423DC
		public int? GetSeasonHelpId(int seasonId)
		{
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			if (config == null)
			{
				return null;
			}
			return new int?(config.Value.HelpId);
		}

		// Token: 0x06038572 RID: 230770 RVA: 0x00E44218 File Offset: 0x00E42418
		public bool GetMapNoteShowState()
		{
			ActivityRogueData currentActivityData = ControllerBase<ActivityPermanentRogueController>.Instance.GetCurrentActivityData();
			if (currentActivityData == null || !currentActivityData.IsUnLock())
			{
				return false;
			}
			if (!currentActivityData.GetPreGuideQuestFinishState())
			{
				return false;
			}
			int newSeasonId = this.GetNewSeasonId();
			int latestDungeon = this.GetLatestDungeon(newSeasonId);
			ExchangeRewardModel instance = ModelBase<ExchangeRewardModel>.Instance;
			return instance == null || !instance.IsFinishInstance(latestDungeon);
		}

		// Token: 0x06038573 RID: 230771 RVA: 0x00E4426C File Offset: 0x00E4246C
		public int GetCurrentSelectedInst(int seasonId)
		{
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RogueResDungeonSelected, null) ?? null;
			int result;
			if (dictionary != null && dictionary.TryGetValue(seasonId, out result))
			{
				return result;
			}
			return 0;
		}

		// Token: 0x06038574 RID: 230772 RVA: 0x00E4429C File Offset: 0x00E4249C
		public void SetCurrentSelectedInst(int inst)
		{
			RogueResDungeonConfig? config = ConfigRogueResDungeonConfigById.GetConfig(inst, true);
			if (config == null)
			{
				return;
			}
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RogueResDungeonSelected, null) ?? new Dictionary<int, int>();
			dictionary[config.Value.SeasonId] = inst;
			LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RogueResDungeonSelected, dictionary);
		}

		// Token: 0x06038575 RID: 230773 RVA: 0x00E442F4 File Offset: 0x00E424F4
		public int[] GetTokenCount(int season)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			int[] array = new int[2];
			Dictionary<int, SignState> allIllustratedState = activityData.GetAllIllustratedState();
			HashSet<int> tokenIndexSet = activityData.GetTokenIndexSet(season);
			array[1] = tokenIndexSet.Count;
			foreach (int key in tokenIndexSet)
			{
				array[0] += ((allIllustratedState.ContainsKey(key) && allIllustratedState[key] != SignState.Lock) ? 1 : 0);
			}
			return array;
		}

		// Token: 0x06038576 RID: 230774 RVA: 0x00E44388 File Offset: 0x00E42588
		public int[] GetEventCount(int season, bool isNormal)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			int[] array = new int[2];
			Dictionary<int, SignState> allIllustratedState = activityData.GetAllIllustratedState();
			HashSet<int> hashSet = isNormal ? activityData.GetNormalIndexSet(season) : activityData.GetMapIndexSet(season);
			array[1] = hashSet.Count;
			foreach (int key in hashSet)
			{
				array[0] += ((allIllustratedState.ContainsKey(key) && allIllustratedState[key] != SignState.Lock) ? 1 : 0);
			}
			return array;
		}

		// Token: 0x06038577 RID: 230775 RVA: 0x00E44428 File Offset: 0x00E42628
		public Dictionary<int, int[]> GetTypeIllustratedCountInfo()
		{
			Dictionary<int, int[]> dictionary = new Dictionary<int, int[]>();
			foreach (KeyValuePair<int, SignState> keyValuePair in this.GetActivityData().GetAllIllustratedState())
			{
				RogueResCollection? config = ConfigRogueResCollectionByIdKey.GetConfig(keyValuePair.Key, true);
				if (config == null)
				{
					Log instance = Singleton<Log>.Instance;
					ELogModule module = ELogModule.Activity;
					ELogAuthor author = ELogAuthor.WHJ;
					string message = "未找到肉鸽图鉴配置";
					ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("collectId", keyValuePair.Key);
					instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				}
				else
				{
					int type = config.Value.Type;
					if (!dictionary.ContainsKey(type))
					{
						dictionary[type] = new int[2];
					}
					dictionary[type][1]++;
					dictionary[type][0] += ((keyValuePair.Value > SignState.Lock) ? 1 : 0);
				}
			}
			return dictionary;
		}

		// Token: 0x06038578 RID: 230776 RVA: 0x00E44530 File Offset: 0x00E42730
		public RogueResGainData GetTokenTipsData(int tokenId)
		{
			RogueResGainData result;
			if (this.DetailDataMap.TryGetValue(tokenId, out result))
			{
				return result;
			}
			RogueResGainData rogueResGainData = RogueResGainData.Create();
			rogueResGainData.RogueResToken = RogueResToken.Create();
			rogueResGainData.RogueResToken.IsNew = false;
			rogueResGainData.RogueResToken.ConfigId = tokenId;
			this.DetailDataMap[tokenId] = rogueResGainData;
			return rogueResGainData;
		}

		// Token: 0x06038579 RID: 230777 RVA: 0x00E44586 File Offset: 0x00E42786
		public bool CheckIllustratedRedDot()
		{
			return this.GetActivityData().IsIllustratedReward();
		}

		// Token: 0x0603857A RID: 230778 RVA: 0x00E44594 File Offset: 0x00E42794
		public HashSet<int> GetTokenIndexSet(RogueResTheme? config)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			if (config == null)
			{
				return activityData.GetTokenIndexSet(ActivityPermanentRogueModel.ALL_SEASON_ID);
			}
			return activityData.GetTokenIndexSet(config.Value.Id);
		}

		// Token: 0x0603857B RID: 230779 RVA: 0x00E445D4 File Offset: 0x00E427D4
		public HashSet<int> GetNormalIndexSet(RogueResTheme? config)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			if (config == null)
			{
				return activityData.GetNormalIndexSet(ActivityPermanentRogueModel.ALL_SEASON_ID);
			}
			return activityData.GetNormalIndexSet(config.Value.Id);
		}

		// Token: 0x0603857C RID: 230780 RVA: 0x00E44614 File Offset: 0x00E42814
		public HashSet<int> GetMapIndexSet(RogueResTheme? config)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			if (config == null)
			{
				return activityData.GetMapIndexSet(ActivityPermanentRogueModel.ALL_SEASON_ID);
			}
			return activityData.GetMapIndexSet(config.Value.Id);
		}

		// Token: 0x0603857D RID: 230781 RVA: 0x00E44652 File Offset: 0x00E42852
		public SignState GetCollectItemState(int index)
		{
			return this.GetActivityData().GetCollectItemState(index);
		}

		// Token: 0x0603857E RID: 230782 RVA: 0x00E44660 File Offset: 0x00E42860
		public bool GetHaveTokenAward(int seasonId)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			HashSet<int> tokenIndexSet = activityData.GetTokenIndexSet(seasonId);
			Dictionary<int, SignState> allIllustratedState = activityData.GetAllIllustratedState();
			foreach (int key in tokenIndexSet)
			{
				if (allIllustratedState.ContainsKey(key) && allIllustratedState[key] == SignState.Unlock)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603857F RID: 230783 RVA: 0x00E446D8 File Offset: 0x00E428D8
		public bool GetHaveNormalAward(int seasonId)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			HashSet<int> normalIndexSet = activityData.GetNormalIndexSet(seasonId);
			Dictionary<int, SignState> allIllustratedState = activityData.GetAllIllustratedState();
			foreach (int key in normalIndexSet)
			{
				if (allIllustratedState.ContainsKey(key) && allIllustratedState[key] == SignState.Unlock)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06038580 RID: 230784 RVA: 0x00E44750 File Offset: 0x00E42950
		public bool GetHaveMapAward(int seasonId)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			HashSet<int> mapIndexSet = activityData.GetMapIndexSet(seasonId);
			Dictionary<int, SignState> allIllustratedState = activityData.GetAllIllustratedState();
			foreach (int key in mapIndexSet)
			{
				if (allIllustratedState.ContainsKey(key) && allIllustratedState[key] == SignState.Unlock)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06038581 RID: 230785 RVA: 0x00E447C8 File Offset: 0x00E429C8
		public bool GetTaskIsEnd()
		{
			return (double)this.GetTaskEndTime() < Singleton<TimeUtil>.Instance.GetServerTime();
		}

		// Token: 0x06038582 RID: 230786 RVA: 0x00E447DD File Offset: 0x00E429DD
		public long GetTaskEndTime()
		{
			return this.GetActivityData().TaskEndTime;
		}

		// Token: 0x06038583 RID: 230787 RVA: 0x00E447EC File Offset: 0x00E429EC
		public int[] GetTaskCount()
		{
			int[] array = new int[2];
			ActivityPermanentRogueData activityData = this.GetActivityData();
			if (activityData.GetTaskThemeId() == 0)
			{
				return array;
			}
			RogueResTaskTheme? config = ConfigRogueResTaskThemeById.GetConfig(activityData.GetTaskThemeId(), true);
			if (config == null)
			{
				return array;
			}
			foreach (DicIntString dicIntString in config.Value.TabNamesIter())
			{
				List<int> taskListByType = activityData.GetTaskListByType(dicIntString.Key);
				array[1] += taskListByType.Count;
				foreach (int configId in taskListByType)
				{
					array[0] += ((activityData.GetTaskById(configId).Status > ActivityTaskState.ActivityTaskRunning) ? 1 : 0);
				}
			}
			return array;
		}

		// Token: 0x06038584 RID: 230788 RVA: 0x00E448E4 File Offset: 0x00E42AE4
		public int GetTaskProgressByType(int type)
		{
			int num = 0;
			List<int> taskListById = this.GetTaskListById(type);
			if (taskListById.Count == 0)
			{
				return 0;
			}
			ActivityPermanentRogueData activityData = this.GetActivityData();
			foreach (int configId in taskListById)
			{
				ActivityTaskState status = activityData.GetTaskById(configId).Status;
				num += ((status > ActivityTaskState.ActivityTaskRunning) ? 1 : 0);
			}
			return num / taskListById.Count * 100;
		}

		// Token: 0x06038585 RID: 230789 RVA: 0x00E4496C File Offset: 0x00E42B6C
		public List<int> GetTaskListById(int id)
		{
			return this.GetActivityData().GetTaskListByType(id);
		}

		// Token: 0x06038586 RID: 230790 RVA: 0x00E4497A File Offset: 0x00E42B7A
		public RogueTaskData GetTaskById(int id)
		{
			return this.GetActivityData().GetTaskById(id);
		}

		// Token: 0x06038587 RID: 230791 RVA: 0x00E44988 File Offset: 0x00E42B88
		public List<RogueTaskData> GetTaskDataListById(int id)
		{
			List<int> taskListById = this.GetTaskListById(id);
			List<RogueTaskData> list = new List<RogueTaskData>();
			foreach (int id2 in taskListById)
			{
				RogueTaskData taskById = this.GetTaskById(id2);
				list.Add(taskById);
			}
			return list;
		}

		// Token: 0x06038588 RID: 230792 RVA: 0x00E449EC File Offset: 0x00E42BEC
		public bool CheckAllTaskRedDot()
		{
			if (this.GetTaskIsEnd())
			{
				return false;
			}
			long cacheTaskOpen = this.GetCacheTaskOpen();
			return Singleton<TimeUtil>.Instance.GetServerTime() >= (double)cacheTaskOpen || this.GetActivityData().IsTaskReward();
		}

		// Token: 0x06038589 RID: 230793 RVA: 0x00E44A28 File Offset: 0x00E42C28
		public bool CheckTaskRedDot(int taskTabIndex)
		{
			if (this.CheckTaskExtraRedDot(taskTabIndex))
			{
				return true;
			}
			foreach (int id in this.GetTaskListById(taskTabIndex))
			{
				if (this.GetTaskById(id).Status == ActivityTaskState.ActivityTaskFinish)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x0603858A RID: 230794 RVA: 0x00E44A98 File Offset: 0x00E42C98
		private bool CheckTaskExtraRedDot(int taskTabIndex)
		{
			if (taskTabIndex == 4)
			{
				ActivityPermanentRogueData activityData = this.GetActivityData();
				return activityData != null && activityData.GetFirstCheckRedDotState(EPermanentRogueSaveFlag.NewTaskCheck);
			}
			return false;
		}

		// Token: 0x0603858B RID: 230795 RVA: 0x00E44AB2 File Offset: 0x00E42CB2
		private int TaskStateSwitch(ActivityTaskState a)
		{
			if (a == ActivityTaskState.ActivityTaskFinish)
			{
				return 0;
			}
			if (a == ActivityTaskState.ActivityTaskTaken)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x0603858C RID: 230796 RVA: 0x00E44AC1 File Offset: 0x00E42CC1
		public int SortTaskData(RogueTaskData a, RogueTaskData b)
		{
			if (a.Status == b.Status)
			{
				return a.Id - b.Id;
			}
			return this.TaskStateSwitch(a.Status) - this.TaskStateSwitch(b.Status);
		}

		// Token: 0x0603858D RID: 230797 RVA: 0x00E44AF8 File Offset: 0x00E42CF8
		public List<int> GetTaskRoleList()
		{
			RogueResTaskTheme? config = ConfigRogueResTaskThemeById.GetConfig(this.GetActivityData().GetTaskThemeId(), true);
			if (config == null)
			{
				return new List<int>();
			}
			return config.Value.RoleImageIter().ToList<int>();
		}

		// Token: 0x0603858E RID: 230798 RVA: 0x00E44B3C File Offset: 0x00E42D3C
		public long GetCacheTaskOpen()
		{
			long player = LocalStorage.GetPlayer<long>(ELocalStoragePlayerKey.RogueResTaskOpen, 0L);
			if (player == 0L)
			{
				return -1L;
			}
			return player;
		}

		// Token: 0x0603858F RID: 230799 RVA: 0x00E44B60 File Offset: 0x00E42D60
		public void SetCacheTaskOpen()
		{
			long value = Singleton<MathUtils>.Instance.LongToNumber(this.GetTaskEndTime());
			LocalStorage.SetPlayer<long>(ELocalStoragePlayerKey.RogueResTaskOpen, value);
		}

		// Token: 0x06038590 RID: 230800 RVA: 0x00E44B8A File Offset: 0x00E42D8A
		private bool CanOpenTaskView(EUiViewName viewName, object param)
		{
			return !ModelBase<ActivityPermanentRogueModel>.Instance.GetTaskIsEnd();
		}

		// Token: 0x06038591 RID: 230801 RVA: 0x00E44B9C File Offset: 0x00E42D9C
		public int? GetCacheDungeonNewest(int seasonId)
		{
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RogueResDungeonNewest, null) ?? null;
			int value;
			if (dictionary != null && dictionary.TryGetValue(seasonId, out value))
			{
				return new int?(value);
			}
			return null;
		}

		// Token: 0x06038592 RID: 230802 RVA: 0x00E44BD8 File Offset: 0x00E42DD8
		public void SetCacheDungeonNewest(int seasonId)
		{
			Dictionary<int, int> dictionary = LocalStorage.GetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RogueResDungeonNewest, null) ?? new Dictionary<int, int>();
			int latestDungeon = this.GetLatestDungeon(seasonId);
			dictionary[seasonId] = latestDungeon;
			LocalStorage.SetPlayer<Dictionary<int, int>>(ELocalStoragePlayerKey.RogueResDungeonNewest, dictionary);
		}

		// Token: 0x06038593 RID: 230803 RVA: 0x00E44C10 File Offset: 0x00E42E10
		public bool CheckDungeonRedDot(int seasonId)
		{
			int? cacheDungeonNewest = this.GetCacheDungeonNewest(seasonId);
			if (cacheDungeonNewest == null)
			{
				return true;
			}
			int latestDungeon = this.GetLatestDungeon(seasonId);
			int? num = cacheDungeonNewest;
			int num2 = latestDungeon;
			return !(num.GetValueOrDefault() == num2 & num != null);
		}

		// Token: 0x06038594 RID: 230804 RVA: 0x00E44C50 File Offset: 0x00E42E50
		public int GetLatestDungeon(int seasonId)
		{
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			int result = 0;
			foreach (int num in config.Value.GetInstsArray())
			{
				if (ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(num))
				{
					result = num;
					if (!ModelBase<ExchangeRewardModel>.Instance.IsFinishInstance(num))
					{
						return num;
					}
				}
			}
			return result;
		}

		// Token: 0x06038595 RID: 230805 RVA: 0x00E44CB0 File Offset: 0x00E42EB0
		public ERogueResInstState GetInstDungeonState(int instId)
		{
			int instDungeonEndingReachedCount = this.GetInstDungeonEndingReachedCount(instId);
			int num = 0;
			HashSet<int> hashSet;
			if (this.InstEndingMap.TryGetValue(instId, out hashSet))
			{
				num = hashSet.Count;
			}
			if (num == 0)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "副本未配置结局数据！";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("instId", instId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return ERogueResInstState.Lock;
			}
			if (instDungeonEndingReachedCount == num)
			{
				return ERogueResInstState.Finished;
			}
			if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(instId))
			{
				return ERogueResInstState.Lock;
			}
			return ERogueResInstState.Unlock;
		}

		// Token: 0x06038596 RID: 230806 RVA: 0x00E44D28 File Offset: 0x00E42F28
		public int GetInstDungeonEndingTotalCount(int instId)
		{
			return this.InstEndingMap[instId].Count;
		}

		// Token: 0x06038597 RID: 230807 RVA: 0x00E44D3C File Offset: 0x00E42F3C
		public int GetInstDungeonEndingReachedCount(int instId)
		{
			if (!this.InstEndingMap.ContainsKey(instId))
			{
				foreach (RogueResEnd rogueResEnd in ConfigRogueResEndAll.GetConfigList(true))
				{
					int instId2 = rogueResEnd.InstId;
					if (!this.InstEndingMap.ContainsKey(instId2))
					{
						this.InstEndingMap[instId2] = new HashSet<int>();
					}
					this.InstEndingMap[instId2].Add(rogueResEnd.Id);
				}
			}
			int num = 0;
			ActivityPermanentRogueData activityData = this.GetActivityData();
			int seasonId = ConfigRogueResDungeonConfigById.GetConfig(instId, true).Value.SeasonId;
			if (!this.InstEndingMap.ContainsKey(instId))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.RogueBattle;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "未找到副本相关结局";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("InstId", instId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return 0;
			}
			foreach (int endingId in this.InstEndingMap[instId])
			{
				num += ((activityData.GetEndingReachedById(seasonId, endingId) > false) ? 1 : 0);
			}
			return num;
		}

		// Token: 0x06038598 RID: 230808 RVA: 0x00E44E90 File Offset: 0x00E43090
		public int GetLatestDungeonIndex(int seasonId)
		{
			List<int> list = ConfigRogueResThemeById.GetConfig(seasonId, true).Value.GetInstsArray().ToList<int>();
			int latestDungeon = this.GetLatestDungeon(seasonId);
			return list.IndexOf(latestDungeon);
		}

		// Token: 0x06038599 RID: 230809 RVA: 0x00E44EC8 File Offset: 0x00E430C8
		public int GetSkillTreeLevel(int seasonId)
		{
			MapField<int, int> talentSkillDict = this.GetActivityData().GetSeasonDataById(seasonId).TalentSkillDict;
			int num = 0;
			foreach (int key in talentSkillDict.Keys)
			{
				num += ((talentSkillDict[key] > 0) ? talentSkillDict[key] : 0);
			}
			return num;
		}

		// Token: 0x0603859A RID: 230810 RVA: 0x00E44F3C File Offset: 0x00E4313C
		public IDictionary<int, int> GetSkillDict(int seasonId)
		{
			return this.GetActivityData().GetSeasonDataById(seasonId).TalentSkillDict.ToDictionary<int, int>();
		}

		// Token: 0x0603859B RID: 230811 RVA: 0x00E44F54 File Offset: 0x00E43154
		public int GetSkillLevelById(int talentId)
		{
			return this.GetActivityData().GetSeasonDataById(ConfigRogueResTalentTreeById.GetConfig(talentId, true).Value.SeasonId).TalentSkillDict[talentId];
		}

		// Token: 0x0603859C RID: 230812 RVA: 0x00E44F90 File Offset: 0x00E43190
		public int GetNextCanUnlockSkillId(int seasonId)
		{
			int num = 0;
			MapField<int, int> talentSkillDict = this.GetActivityData().GetSeasonDataById(seasonId).TalentSkillDict;
			int currency = this.GetCurrency(ConfigRogueResThemeById.GetConfig(seasonId, true).Value.SkillItem);
			foreach (int num2 in talentSkillDict.Keys)
			{
				if (talentSkillDict[num2] == 0)
				{
					num = num2;
					if (ConfigRogueResTalentTreeById.GetConfig(num, true).Value.Consule(0) <= currency)
					{
						return num;
					}
				}
				if (num == 0)
				{
					num = num2;
				}
			}
			return num;
		}

		// Token: 0x0603859D RID: 230813 RVA: 0x00E45048 File Offset: 0x00E43248
		public bool GetCacheSkillTreeOpen(int seasonId)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RogueResSkillTreeOpen, null) ?? null;
			return hashSet != null && hashSet.Contains(seasonId);
		}

		// Token: 0x0603859E RID: 230814 RVA: 0x00E45074 File Offset: 0x00E43274
		public void SetCacheSkillTreeOpen(int seasonId)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RogueResSkillTreeOpen, null) ?? new HashSet<int>();
			hashSet.Add(seasonId);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RogueResSkillTreeOpen, hashSet);
		}

		// Token: 0x0603859F RID: 230815 RVA: 0x00E450AC File Offset: 0x00E432AC
		public bool CheckSkillTreeRedDot(int seasonId)
		{
			if (seasonId == 0)
			{
				return false;
			}
			if (!this.GetCacheSkillTreeOpen(seasonId))
			{
				return true;
			}
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			if (config == null)
			{
				return false;
			}
			int currency = this.GetCurrency(config.Value.SkillItem);
			MapField<int, int> talentSkillDict = this.GetActivityData().GetSeasonDataById(seasonId).TalentSkillDict;
			foreach (int num in talentSkillDict.Keys)
			{
				int num2 = talentSkillDict[num];
				if (num2 == 0 && ConfigRogueResTalentTreeById.GetConfig(num, true).Value.Consule(num2) <= currency)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060385A0 RID: 230816 RVA: 0x00E4517C File Offset: 0x00E4337C
		public void UpdateSkillTreeUnlockState(int skillId)
		{
			this.GetActivityData().UpgradeSkill(skillId, 0);
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.RogueResTalentLevelUp, skillId);
		}

		// Token: 0x060385A1 RID: 230817 RVA: 0x00E4519C File Offset: 0x00E4339C
		public int[] GetShopCount(int seasonId)
		{
			int[] array = new int[2];
			array[0] = this.GetTotalShopItem(seasonId);
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			array[1] = ((config != null) ? config.GetValueOrDefault().PointItemMax : 0);
			return array;
		}

		// Token: 0x060385A2 RID: 230818 RVA: 0x00E451E0 File Offset: 0x00E433E0
		public bool HasShopGoodsSoldOut(int seasonId)
		{
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			if (config == null)
			{
				return true;
			}
			foreach (PayShopGoods payShopGoods in ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)config.Value.ShopId, 1, true))
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData != null && goodsData.HasBuyLimit() && goodsData.GetRemainingCount() != 0)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x060385A3 RID: 230819 RVA: 0x00E45278 File Offset: 0x00E43478
		public bool CheckShopRedDot(int seasonId)
		{
			if (seasonId == 0)
			{
				return false;
			}
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			if (config == null)
			{
				return false;
			}
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)config.Value.ShopId, 1, true);
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			foreach (PayShopGoods payShopGoods in payShopTabData)
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData.GetIfCanBuy())
				{
					list2.Add(goodsData.Id);
				}
				list.Add(goodsData.Id);
			}
			list.Sort((int a, int b) => a - b);
			if (!this.GetCacheShopNewGoods(seasonId, string.Join<int>(",", list)))
			{
				return true;
			}
			list2.Sort((int a, int b) => a - b);
			return !this.GetCacheShopOpen(seasonId, string.Join<int>(",", list2));
		}

		// Token: 0x060385A4 RID: 230820 RVA: 0x00E4539C File Offset: 0x00E4359C
		public void RefreshShopRedDot(int seasonId)
		{
			RogueResTheme? config = ConfigRogueResThemeById.GetConfig(seasonId, true);
			List<PayShopGoods> payShopTabData = ModelBase<PayShopModel>.Instance.GetPayShopTabData((PayShopDefine.EPayShopTabType)config.Value.ShopId, 1, true);
			List<int> list = new List<int>();
			List<int> list2 = new List<int>();
			foreach (PayShopGoods payShopGoods in payShopTabData)
			{
				PayShopGoodsData goodsData = payShopGoods.GetGoodsData();
				if (goodsData.GetIfCanBuy())
				{
					list2.Add(goodsData.Id);
				}
				list.Add(goodsData.Id);
			}
			list.Sort((int a, int b) => a - b);
			list2.Sort((int a, int b) => a - b);
			this.SetCacheShopOpen(seasonId, string.Join<int>(",", list2));
			this.SetCacheShopNewGoods(seasonId, string.Join<int>(",", list));
			Singleton<EventSystem>.Instance.Emit<int>(EEventName.PermanentRogueSeasonRedDotUpdate, seasonId);
		}

		// Token: 0x060385A5 RID: 230821 RVA: 0x00E454BC File Offset: 0x00E436BC
		public void UpdateTotalShopItem(int season, int count)
		{
			this.GetActivityData().UpdateTotalShopItem(season, count);
		}

		// Token: 0x060385A6 RID: 230822 RVA: 0x00E454CB File Offset: 0x00E436CB
		public int GetTotalShopItem(int season)
		{
			return this.GetActivityData().GetTotalShopItem(season);
		}

		// Token: 0x060385A7 RID: 230823 RVA: 0x00E454DC File Offset: 0x00E436DC
		public bool GetCacheShopOpen(int season, string shopData)
		{
			Dictionary<int, string> dictionary = LocalStorage.GetPlayer<Dictionary<int, string>>(ELocalStoragePlayerKey.RogueResShopRefresh, null) ?? null;
			string text;
			return dictionary != null && (dictionary.TryGetValue(season, out text) ? text : "") == shopData;
		}

		// Token: 0x060385A8 RID: 230824 RVA: 0x00E45518 File Offset: 0x00E43718
		public void SetCacheShopOpen(int season, string shopData)
		{
			Dictionary<int, string> dictionary = LocalStorage.GetPlayer<Dictionary<int, string>>(ELocalStoragePlayerKey.RogueResShopRefresh, null) ?? new Dictionary<int, string>();
			dictionary[season] = shopData;
			LocalStorage.SetPlayer<Dictionary<int, string>>(ELocalStoragePlayerKey.RogueResShopRefresh, dictionary);
		}

		// Token: 0x060385A9 RID: 230825 RVA: 0x00E45550 File Offset: 0x00E43750
		public bool GetCacheShopNewGoods(int season, string shopData)
		{
			Dictionary<int, string> dictionary = LocalStorage.GetPlayer<Dictionary<int, string>>(ELocalStoragePlayerKey.RogueResShopNewGoods, null) ?? null;
			string text;
			return dictionary != null && (dictionary.TryGetValue(season, out text) ? text : "") == shopData;
		}

		// Token: 0x060385AA RID: 230826 RVA: 0x00E4558C File Offset: 0x00E4378C
		public void SetCacheShopNewGoods(int season, string shopData)
		{
			Dictionary<int, string> dictionary = LocalStorage.GetPlayer<Dictionary<int, string>>(ELocalStoragePlayerKey.RogueResShopNewGoods, null) ?? new Dictionary<int, string>();
			dictionary[season] = shopData;
			LocalStorage.SetPlayer<Dictionary<int, string>>(ELocalStoragePlayerKey.RogueResShopNewGoods, dictionary);
		}

		// Token: 0x060385AB RID: 230827 RVA: 0x00E455C2 File Offset: 0x00E437C2
		public void SetEndingAwardData(int taskId)
		{
			this.GetActivityData().UpdateEndingAward(taskId);
		}

		// Token: 0x060385AC RID: 230828 RVA: 0x00E455D0 File Offset: 0x00E437D0
		public IActivityRewardViewData GetEndingAwardViewData(int seasonId)
		{
			List<IActivityRewardData> list = new List<IActivityRewardData>(this.GetEndingAwardList(seasonId));
			list.Sort(delegate(IActivityRewardData a, IActivityRewardData b)
			{
				if (a.RewardState == b.RewardState)
				{
					RogueResEndAward value = ConfigRogueResEndAwardById.GetConfig(a.Id.Value, true).Value;
					RogueResEndAward value2 = ConfigRogueResEndAwardById.GetConfig(b.Id.Value, true).Value;
					return value.Index - value2.Index;
				}
				return ActivityPermanentRogueModel.<GetEndingAwardViewData>g__stateSwitch|74_0(a.RewardState) - ActivityPermanentRogueModel.<GetEndingAwardViewData>g__stateSwitch|74_0(b.RewardState);
			});
			ActivityRewardDataPage item = new ActivityRewardDataPage
			{
				DataList = list,
				TabName = ConfigMultiTextLang.GetLocalTextNew("Rogue_End_S1_Task_Title", null),
				TabTips = " "
			};
			return new ActivityRewardViewData
			{
				DataPageList = new List<IActivityRewardDataPage>
				{
					item
				},
				Source = EActivityRewardSource.Collection
			};
		}

		// Token: 0x060385AD RID: 230829 RVA: 0x00E4565A File Offset: 0x00E4385A
		public List<IActivityRewardData> GetEndingAwardList(int seasonId)
		{
			return this.GetActivityData().GetEndingAwardList(seasonId);
		}

		// Token: 0x060385AE RID: 230830 RVA: 0x00E45668 File Offset: 0x00E43868
		public int[] GetEndingAwardCount(int seasonId)
		{
			List<IActivityRewardData> endingAwardList = this.GetEndingAwardList(seasonId);
			int[] array = new int[]
			{
				0,
				(endingAwardList != null) ? endingAwardList.Count : 0
			};
			if (endingAwardList != null)
			{
				foreach (IActivityRewardData activityRewardData in endingAwardList)
				{
					array[0] += ((activityRewardData.RewardState > EActivityRewardState.Disabled) ? 1 : 0);
				}
			}
			return array;
		}

		// Token: 0x060385AF RID: 230831 RVA: 0x00E456E8 File Offset: 0x00E438E8
		public bool CheckEndingAwardRedDot(int seasonId)
		{
			List<IActivityRewardData> endingAwardList = this.GetEndingAwardList(seasonId);
			if (endingAwardList != null)
			{
				using (List<IActivityRewardData>.Enumerator enumerator = endingAwardList.GetEnumerator())
				{
					while (enumerator.MoveNext())
					{
						if (enumerator.Current.RewardState == EActivityRewardState.Enable)
						{
							return true;
						}
					}
				}
				return false;
			}
			return false;
		}

		// Token: 0x060385B0 RID: 230832 RVA: 0x00E45748 File Offset: 0x00E43948
		public int[] GetEndingCount(int seasonId)
		{
			ActivityPermanentRogueData activityData = this.GetActivityData();
			int[] array = new int[2];
			List<int> endingListBySeasonId = this.GetEndingListBySeasonId(seasonId);
			array[1] = endingListBySeasonId.Count;
			foreach (int endingId in endingListBySeasonId)
			{
				array[0] += ((activityData.GetEndingReachedById(seasonId, endingId) > false) ? 1 : 0);
			}
			return array;
		}

		// Token: 0x060385B1 RID: 230833 RVA: 0x00E457C8 File Offset: 0x00E439C8
		public void SetEndingMainSelectedIndex(int id)
		{
			this.CurEndingSelectedIndex = id;
		}

		// Token: 0x060385B2 RID: 230834 RVA: 0x00E457D1 File Offset: 0x00E439D1
		public int GetEndingMainSelectedIndex()
		{
			return this.CurEndingSelectedIndex;
		}

		// Token: 0x060385B3 RID: 230835 RVA: 0x00E457DC File Offset: 0x00E439DC
		public List<int> GetEndingListBySeasonId(int id)
		{
			IEnumerable<RogueResEnd> configList = ConfigRogueResEndAll.GetConfigList(true);
			List<int> list = new List<int>();
			foreach (RogueResEnd rogueResEnd in configList)
			{
				if (rogueResEnd.SeasonId == id)
				{
					list.Add(rogueResEnd.Id);
				}
			}
			return list;
		}

		// Token: 0x060385B4 RID: 230836 RVA: 0x00E45840 File Offset: 0x00E43A40
		public bool GetEndingIsUnlock(int id)
		{
			int seasonId = ConfigRogueResEndById.GetConfig(id, true).Value.SeasonId;
			return this.GetActivityData().GetEndingReachedById(seasonId, id);
		}

		// Token: 0x060385B5 RID: 230837 RVA: 0x00E45874 File Offset: 0x00E43A74
		public bool GetCacheEndingOpen(int ending)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RogueResEndingOpen, null) ?? null;
			return hashSet != null && hashSet.Contains(ending);
		}

		// Token: 0x060385B6 RID: 230838 RVA: 0x00E458A0 File Offset: 0x00E43AA0
		public void SetCacheEndingOpen(int ending)
		{
			HashSet<int> hashSet = LocalStorage.GetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RogueResEndingOpen, null) ?? new HashSet<int>();
			hashSet.Add(ending);
			LocalStorage.SetPlayer<HashSet<int>>(ELocalStoragePlayerKey.RogueResEndingOpen, hashSet);
			Singleton<EventSystem>.Instance.Emit(EEventName.RogueResEndingRedDotUpdate);
		}

		// Token: 0x060385B7 RID: 230839 RVA: 0x00E458E8 File Offset: 0x00E43AE8
		public List<int> GetTrailRole(int season, ERogueResTrialType type)
		{
			RogueResSeasonData seasonDataById = this.GetActivityData().GetSeasonDataById(season);
			if (type == ERogueResTrialType.Static)
			{
				if (((seasonDataById != null) ? seasonDataById.StaticTrialRoles : null) == null)
				{
					return new List<int>();
				}
				return new List<int>(seasonDataById.StaticTrialRoles);
			}
			else
			{
				if (((seasonDataById != null) ? seasonDataById.DynamicTrialRoles : null) == null)
				{
					return new List<int>();
				}
				return new List<int>(seasonDataById.DynamicTrialRoles);
			}
		}

		// Token: 0x060385B8 RID: 230840 RVA: 0x00E45944 File Offset: 0x00E43B44
		public string GetTrailRemainTime(int season)
		{
			RogueResSeasonData seasonDataById = this.GetActivityData().GetSeasonDataById(season);
			long endTime = Singleton<MathUtils>.Instance.LongToNumber(seasonDataById.EndTime);
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew("ActivityRemainingTime", null);
			return ModelBase<ActivityModel>.Instance.GetRemainTimeText(endTime, localTextNew);
		}

		// Token: 0x060385B9 RID: 230841 RVA: 0x00E45987 File Offset: 0x00E43B87
		public long GetTrailEndTime(int season)
		{
			return this.GetActivityData().GetSeasonDataById(season).EndTime;
		}

		// Token: 0x060385BA RID: 230842 RVA: 0x00E4599C File Offset: 0x00E43B9C
		public long GetCacheTrailOpen(int season)
		{
			Dictionary<int, long> dictionary = LocalStorage.GetPlayer<Dictionary<int, long>>(ELocalStoragePlayerKey.RogueResTrialOpen, null) ?? null;
			if (dictionary == null)
			{
				return -1L;
			}
			return dictionary.GetValueOrDefault(season, -1L);
		}

		// Token: 0x060385BB RID: 230843 RVA: 0x00E459CC File Offset: 0x00E43BCC
		public void SetCacheTrailOpen(int season)
		{
			Dictionary<int, long> dictionary = LocalStorage.GetPlayer<Dictionary<int, long>>(ELocalStoragePlayerKey.RogueResTrialOpen, null) ?? new Dictionary<int, long>();
			long endTime = this.GetActivityData().GetSeasonDataById(season).EndTime;
			dictionary[season] = endTime;
			LocalStorage.SetPlayer<Dictionary<int, long>>(ELocalStoragePlayerKey.RogueResTrialOpen, dictionary);
		}

		// Token: 0x060385BC RID: 230844 RVA: 0x00E45A14 File Offset: 0x00E43C14
		public bool CheckTrialRedDot(int season)
		{
			double serverTime = Singleton<TimeUtil>.Instance.GetServerTime();
			long cacheTrailOpen = this.GetCacheTrailOpen(season);
			return serverTime >= (double)cacheTrailOpen;
		}

		// Token: 0x060385BE RID: 230846 RVA: 0x00E45A6E File Offset: 0x00E43C6E
		[CompilerGenerated]
		internal static int <GetEndingAwardViewData>g__stateSwitch|74_0(EActivityRewardState a)
		{
			if (a == EActivityRewardState.Enable)
			{
				return 0;
			}
			if (a == EActivityRewardState.Claimed)
			{
				return 2;
			}
			return 1;
		}

		// Token: 0x04020226 RID: 131622
		private static readonly int ALL_SEASON_ID;

		// Token: 0x04020227 RID: 131623
		public int SelectSkillId;

		// Token: 0x04020228 RID: 131624
		private readonly Dictionary<int, int> CurrencyMap = new Dictionary<int, int>();

		// Token: 0x04020229 RID: 131625
		private readonly Dictionary<int, int> SkillCurrencySet = new Dictionary<int, int>();

		// Token: 0x0402022A RID: 131626
		private readonly Dictionary<int, HashSet<int>> InstEndingMap = new Dictionary<int, HashSet<int>>();

		// Token: 0x0402022B RID: 131627
		private readonly Dictionary<int, RogueResGainData> DetailDataMap = new Dictionary<int, RogueResGainData>();

		// Token: 0x0402022C RID: 131628
		private int CurEndingSelectedIndex;

		// Token: 0x0200B704 RID: 46852
		[NullableContext(0)]
		private enum ESortPriority
		{
			// Token: 0x040389F4 RID: 231924
			First,
			// Token: 0x040389F5 RID: 231925
			Second,
			// Token: 0x040389F6 RID: 231926
			Third
		}
	}
}
