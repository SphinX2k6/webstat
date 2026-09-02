using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Roguelike;

// Token: 0x02002D60 RID: 11616
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class WeeklyRogueModel : ModelBase<WeeklyRogueModel>
{
	// Token: 0x17001EEB RID: 7915
	// (get) Token: 0x06017733 RID: 96051 RVA: 0x006801DD File Offset: 0x0067E3DD
	public Dictionary<int, int> CurrencyDictMap
	{
		get
		{
			return this.CurrencyDict;
		}
	}

	// Token: 0x06017734 RID: 96052 RVA: 0x006801E5 File Offset: 0x0067E3E5
	public void SetCurrency(int id, int count)
	{
		this.CurrencyDict[id] = count;
	}

	// Token: 0x06017735 RID: 96053 RVA: 0x006801F4 File Offset: 0x0067E3F4
	public int GetCurrency(int currencyId)
	{
		int result;
		if (!this.CurrencyDict.TryGetValue(currencyId, out result))
		{
			return 0;
		}
		return result;
	}

	// Token: 0x17001EEC RID: 7916
	// (get) Token: 0x06017736 RID: 96054 RVA: 0x00680214 File Offset: 0x0067E414
	public int CycleId
	{
		get
		{
			WeeklyRogueData activityDataNew = this.ActivityDataNew;
			if (activityDataNew == null)
			{
				return 0;
			}
			return activityDataNew.CycleId;
		}
	}

	// Token: 0x17001EED RID: 7917
	// (get) Token: 0x06017737 RID: 96055 RVA: 0x00680227 File Offset: 0x0067E427
	// (set) Token: 0x06017738 RID: 96056 RVA: 0x00680234 File Offset: 0x0067E434
	public string CurrentRoomMusicState
	{
		get
		{
			return this.CurrentRoomMusicStateInternal.State;
		}
		set
		{
			this.CurrentRoomMusicStateInternal.State = (value ?? "none");
		}
	}

	// Token: 0x17001EEE RID: 7918
	// (get) Token: 0x06017739 RID: 96057 RVA: 0x0068024C File Offset: 0x0067E44C
	[Nullable(2)]
	public WeeklyRogueData ActivityDataNew
	{
		[NullableContext(2)]
		get
		{
			if (this.CurrentActivityId == 0)
			{
				return null;
			}
			WeeklyRogueData weeklyRogueData = ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityId) as WeeklyRogueData;
			if (weeklyRogueData != null && !weeklyRogueData.CheckIfInShowTime())
			{
				return null;
			}
			return weeklyRogueData;
		}
	}

	// Token: 0x17001EEF RID: 7919
	// (get) Token: 0x0601773A RID: 96058 RVA: 0x00680288 File Offset: 0x0067E488
	public WeeklyRogueData ActivityData
	{
		get
		{
			WeeklyRogueData weeklyRogueData = ModelBase<ActivityModel>.Instance.GetActivityById(this.CurrentActivityId) as WeeklyRogueData;
			if (weeklyRogueData == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.WeeklyRogue;
				ELogAuthor author = ELogAuthor.YYZ;
				string message = "周常肉鸽数据未创建,请检查调用时机";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", this.CurrentActivityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return new WeeklyRogueData();
			}
			return weeklyRogueData;
		}
	}

	// Token: 0x0601773B RID: 96059 RVA: 0x006802EC File Offset: 0x0067E4EC
	public bool HasLastInfo()
	{
		WeeklyRogueData activityDataNew = this.ActivityDataNew;
		RogueWeeklyLastInfo rogueWeeklyLastInfo = (activityDataNew != null) ? activityDataNew.LastInstInfo : null;
		return rogueWeeklyLastInfo != null && rogueWeeklyLastInfo.InstId != 0;
	}

	// Token: 0x0601773C RID: 96060 RVA: 0x0068031A File Offset: 0x0067E51A
	public void ChangeDescMode()
	{
		this.DescMode = ((this.DescMode == EDescModel.SIMPLE) ? EDescModel.DETAIL : EDescModel.SIMPLE);
		Singleton<EventSystem>.Instance.Emit(EEventName.WeeklyRogueDescModeChange);
	}

	// Token: 0x0601773D RID: 96061 RVA: 0x0068033E File Offset: 0x0067E53E
	[NullableContext(2)]
	public RogueWeeklyOption GetCurrentOption()
	{
		return this.GetOptionByBindId(this.CurrentBindId);
	}

	// Token: 0x0601773E RID: 96062 RVA: 0x0068034C File Offset: 0x0067E54C
	[NullableContext(2)]
	public RogueWeeklyOption GetOptionByBindId(int bindId)
	{
		RogueWeeklyOption result;
		if (this.OptionMap.TryGetValue(bindId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0601773F RID: 96063 RVA: 0x0068036C File Offset: 0x0067E56C
	public void UpdateInstInfo(RogueWeeklyInstInfoNotify data)
	{
		this.BuffTypeMap.Clear();
		this.BuffList.Clear();
		this.BuffList.AddRange(data.RogueWeeklyBuffs);
		this.ModifierIdInForce = data.ConfigId;
		foreach (int num in data.RogueWeeklyBuffs)
		{
			RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(num);
			if (rogueWeeklyBuffPool != null)
			{
				List<int> list;
				if (!this.BuffTypeMap.TryGetValue((EWeeklyRogueBuffType)rogueWeeklyBuffPool.Value.BuffType, out list))
				{
					list = new List<int>();
					this.BuffTypeMap.Add((EWeeklyRogueBuffType)rogueWeeklyBuffPool.Value.BuffType, list);
				}
				list.Add(num);
			}
		}
		this.OptionMap.Clear();
		foreach (KeyValuePair<int, RogueWeeklyOption> keyValuePair in data.RogueWeeklyOptions)
		{
			this.OptionMap.Add(keyValuePair.Key, keyValuePair.Value);
		}
	}

	// Token: 0x06017740 RID: 96064 RVA: 0x006804A4 File Offset: 0x0067E6A4
	public List<int> GetBuffIdListByType(EWeeklyRogueBuffType type)
	{
		List<int> collection;
		if (!this.BuffTypeMap.TryGetValue(type, out collection))
		{
			return new List<int>();
		}
		return new List<int>(collection);
	}

	// Token: 0x06017741 RID: 96065 RVA: 0x006804D0 File Offset: 0x0067E6D0
	public int GetArtifactBuffId()
	{
		List<int> list;
		if (!this.BuffTypeMap.TryGetValue(EWeeklyRogueBuffType.Artifact, out list))
		{
			return 0;
		}
		return list[0];
	}

	// Token: 0x06017742 RID: 96066 RVA: 0x006804F8 File Offset: 0x0067E6F8
	public List<int> GetCoreTokenIdListByArtifactId(int artifactId)
	{
		IReadOnlyList<RogueWeeklyBuffPool> rogueWeeklyBuffPoolByRelatedArtifactId = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPoolByRelatedArtifactId(artifactId);
		List<int> list = new List<int>();
		if (rogueWeeklyBuffPoolByRelatedArtifactId != null)
		{
			foreach (RogueWeeklyBuffPool rogueWeeklyBuffPool in rogueWeeklyBuffPoolByRelatedArtifactId)
			{
				list.Add(rogueWeeklyBuffPool.Id);
			}
		}
		return list;
	}

	// Token: 0x06017743 RID: 96067 RVA: 0x0068055C File Offset: 0x0067E75C
	public List<int> GetRogueWeeklyBuffTagIdList(int id)
	{
		List<int> list = new List<int>();
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(id);
		if (rogueWeeklyBuffPool == null)
		{
			return list;
		}
		if (rogueWeeklyBuffPool.Value.BuffType == 1 && this.ModifierIdInForce != 0)
		{
			RogueWeeklyBuffPool? rogueWeeklyBuffPool2 = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.ModifierIdInForce);
			if (rogueWeeklyBuffPool2 != null && rogueWeeklyBuffPool2.Value.BuffTriggerTagId != 0)
			{
				list.Add(rogueWeeklyBuffPool2.Value.BuffTriggerTagId);
			}
		}
		else if (rogueWeeklyBuffPool.Value.BuffTriggerTagId != 0)
		{
			list.Add(rogueWeeklyBuffPool.Value.BuffTriggerTagId);
		}
		list.AddRange(rogueWeeklyBuffPool.Value.BuffTagId());
		return list;
	}

	// Token: 0x06017744 RID: 96068 RVA: 0x00680620 File Offset: 0x0067E820
	public List<string> GetRogueWeeklyBuffDescParam(int id)
	{
		List<string> list = new List<string>();
		RogueWeeklyBuffPool? rogueWeeklyBuffPool = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(id);
		if (rogueWeeklyBuffPool == null)
		{
			return list;
		}
		if (id == this.GetArtifactBuffId())
		{
			int buffTriggerTagId = rogueWeeklyBuffPool.Value.BuffTriggerTagId;
			if (this.ModifierIdInForce != 0)
			{
				RogueWeeklyBuffPool? rogueWeeklyBuffPool2 = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyBuffPool(this.ModifierIdInForce);
				if (rogueWeeklyBuffPool2 != null)
				{
					buffTriggerTagId = rogueWeeklyBuffPool2.Value.BuffTriggerTagId;
				}
			}
			RogueWeekTag? rogueWeekTagConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeekTagConfig(buffTriggerTagId);
			if (rogueWeekTagConfig != null)
			{
				list.Add(rogueWeekTagConfig.Value.Name);
			}
		}
		else
		{
			list.AddRange(rogueWeeklyBuffPool.Value.BuffDescParam());
		}
		return list;
	}

	// Token: 0x06017745 RID: 96069 RVA: 0x006806DC File Offset: 0x0067E8DC
	public bool CheckIsInWeeklyRogue()
	{
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(ModelBase<CreatureModel>.Instance.GetInstanceId());
		return config != null && config.GetValueOrDefault().InstSubType == 29 && ControllerBase<GameModeController>.Instance.IsInInstance();
	}

	// Token: 0x06017746 RID: 96070 RVA: 0x0068072C File Offset: 0x0067E92C
	public bool IsWeeklyRogueOpen()
	{
		int? getInstanceDungeonId = ModelBase<EditBattleTeamModel>.Instance.GetInstanceDungeonId;
		if (getInstanceDungeonId == null)
		{
			return false;
		}
		InstanceDungeon? config = ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(getInstanceDungeonId.Value);
		return config != null && config.Value.InstSubType == 29;
	}

	// Token: 0x06017747 RID: 96071 RVA: 0x00680780 File Offset: 0x0067E980
	public bool CheckIsRecommendRole(int roleId)
	{
		WeeklyRogueData activityDataNew = this.ActivityDataNew;
		RogueWeeklyCycle? rogueWeeklyCycle = (activityDataNew != null) ? activityDataNew.GetCycleConfig() : null;
		return rogueWeeklyCycle != null && rogueWeeklyCycle.Value.RecommendedRole().Contains(roleId);
	}

	// Token: 0x06017748 RID: 96072 RVA: 0x006807C8 File Offset: 0x0067E9C8
	public IReadOnlyList<int> GetAllRecommendRole()
	{
		WeeklyRogueData activityDataNew = this.ActivityDataNew;
		RogueWeeklyCycle? rogueWeeklyCycle = (activityDataNew != null) ? activityDataNew.GetCycleConfig() : null;
		if (rogueWeeklyCycle == null)
		{
			return new List<int>();
		}
		return rogueWeeklyCycle.Value.RecommendedRole();
	}

	// Token: 0x06017749 RID: 96073 RVA: 0x00680810 File Offset: 0x0067EA10
	public IActivityRewardViewData GetScoreRewardData()
	{
		List<IActivityRewardData> scoreDataList = new List<IActivityRewardData>();
		ActivityRewardDataPage item = new ActivityRewardDataPage
		{
			TabName = ConfigMultiTextLang.GetLocalTextNew("Text_WeeklyRogue_ScoreReward_Title", null),
			DataList = scoreDataList
		};
		WeeklyRogueData activityDataNew = this.ActivityDataNew;
		if (activityDataNew != null)
		{
			List<RogueWeeklyAward> awardsInfoList = activityDataNew.AwardsInfoList;
			if (awardsInfoList != null)
			{
				awardsInfoList.ForEach(delegate(RogueWeeklyAward awardInfo)
				{
					RogueWeeklyReward? rogueWeeklyRewardConfig = ConfigBase<WeeklyRogueConfig>.Instance.GetRogueWeeklyRewardConfig(awardInfo.ConfigId);
					if (rogueWeeklyRewardConfig == null)
					{
						return;
					}
					List<TItem> exchangeRewardPreviewRewardList = ConfigBase<ExchangeRewardConfig>.Instance.GetExchangeRewardPreviewRewardList(rogueWeeklyRewardConfig.Value.TargetReward, new int?(this.ActivityData.WorldLevel));
					EActivityRewardState scoreRewardStateById = this.ActivityData.GetScoreRewardStateById(awardInfo.ConfigId);
					int configId = awardInfo.ConfigId;
					ActivityRewardData activityRewardData = new ActivityRewardData();
					activityRewardData.Id = new int?(configId);
					activityRewardData.NameText = "";
					activityRewardData.NameTextId = "Text_WeeklyRogue_ScoreReward_ItemName";
					activityRewardData.NameTextArgs = new string[]
					{
						rogueWeeklyRewardConfig.Value.Score.ToString()
					};
					activityRewardData.RewardList = exchangeRewardPreviewRewardList.ToArray();
					activityRewardData.RewardState = this.ActivityData.GetScoreRewardStateById(configId);
					activityRewardData.RewardButtonText = this.GetPreviewButtonTextByState(scoreRewardStateById);
					activityRewardData.RewardButtonRedDot = new bool?(scoreRewardStateById == EActivityRewardState.Enable);
					activityRewardData.ClickFunction = delegate()
					{
						WeeklyRogueController instance = ControllerBase<WeeklyRogueController>.Instance;
						if (instance == null)
						{
							return;
						}
						instance.MultiRogueWeeklyRewardRequest();
					};
					ActivityRewardData item2 = activityRewardData;
					scoreDataList.Add(item2);
				});
			}
		}
		return new ActivityRewardViewData
		{
			DataPageList = new List<IActivityRewardDataPage>
			{
				item
			},
			Source = EActivityRewardSource.WeeklyRogue
		};
	}

	// Token: 0x0601774A RID: 96074 RVA: 0x006808A4 File Offset: 0x0067EAA4
	private string GetPreviewButtonTextByState(EActivityRewardState state)
	{
		switch (state)
		{
		case EActivityRewardState.Disabled:
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefence_Getbt3", null) ?? "";
		case EActivityRewardState.Enable:
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefence_Getbt1", null) ?? "";
		case EActivityRewardState.Claimed:
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefence_Getbt1", null) ?? "";
		default:
			return "";
		}
	}

	// Token: 0x0601774B RID: 96075 RVA: 0x0068090C File Offset: 0x0067EB0C
	public bool GetMapNoteShowState()
	{
		WeeklyRogueData activityDataNew = this.ActivityDataNew;
		return activityDataNew != null && activityDataNew.IsUnLock() && !activityDataNew.IsScoreRewardAllDone();
	}

	// Token: 0x0601774C RID: 96076 RVA: 0x0068093C File Offset: 0x0067EB3C
	[NullableContext(2)]
	public List<int> GetRewardIdsByDifficulties(bool isCanReceive)
	{
		WeeklyRogueData activityDataNew = this.ActivityDataNew;
		if (((activityDataNew != null) ? activityDataNew.AwardsInfoList : null) == null)
		{
			return null;
		}
		List<int> list = new List<int>();
		foreach (RogueWeeklyAward rogueWeeklyAward in this.ActivityDataNew.AwardsInfoList)
		{
			if (rogueWeeklyAward.SignState == (isCanReceive ? SignState.Unlock : SignState.IsReceive))
			{
				list.Add(rogueWeeklyAward.ConfigId);
			}
		}
		return list;
	}

	// Token: 0x0400B3CC RID: 46028
	public List<int> BuffList = new List<int>();

	// Token: 0x0400B3CD RID: 46029
	private readonly Dictionary<EWeeklyRogueBuffType, List<int>> BuffTypeMap = new Dictionary<EWeeklyRogueBuffType, List<int>>();

	// Token: 0x0400B3CE RID: 46030
	public int ModifierIdInForce;

	// Token: 0x0400B3CF RID: 46031
	public Dictionary<int, RogueWeeklyOption> OptionMap = new Dictionary<int, RogueWeeklyOption>();

	// Token: 0x0400B3D0 RID: 46032
	private readonly Dictionary<int, int> CurrencyDict = new Dictionary<int, int>();

	// Token: 0x0400B3D1 RID: 46033
	public int CurrentLayer;

	// Token: 0x0400B3D2 RID: 46034
	public int MaxLayer;

	// Token: 0x0400B3D3 RID: 46035
	public int CurrentBindId;

	// Token: 0x0400B3D4 RID: 46036
	public string CurrentRoomTypeId = "";

	// Token: 0x0400B3D5 RID: 46037
	public int CurrentRoomId;

	// Token: 0x0400B3D6 RID: 46038
	public int CurrentRoomType;

	// Token: 0x0400B3D7 RID: 46039
	public int CurrentScore;

	// Token: 0x0400B3D8 RID: 46040
	public EDescModel DescMode;

	// Token: 0x0400B3D9 RID: 46041
	public List<int> SelectRoleIdList = new List<int>();

	// Token: 0x0400B3DA RID: 46042
	[Nullable(2)]
	public RogueWeeklyEntry SelectEntry;

	// Token: 0x0400B3DB RID: 46043
	public int CurrentActivityId;

	// Token: 0x0400B3DC RID: 46044
	public bool IsOpenedViewByWorld;

	// Token: 0x0400B3DD RID: 46045
	private readonly StateRef CurrentRoomMusicStateInternal = new StateRef("game_rogue_room_type", "none");
}
