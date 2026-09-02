using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Ui;

// Token: 0x020017EA RID: 6122
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class CalabashModel : ModelBase<CalabashModel>
{
	// Token: 0x0600ADCD RID: 44493 RVA: 0x002E37A4 File Offset: 0x002E19A4
	public CalabashModel()
	{
		this.UnlockTipsList = new List<VisionUnlockQualityData>();
	}

	// Token: 0x0600ADCE RID: 44494 RVA: 0x002E37B8 File Offset: 0x002E19B8
	protected override bool OnInit()
	{
		this.DirectionalFusionTimeMax = ConfigCommonParamById.GetIntConfig("PhantomDirectRefiningWeekTimes").Value;
		this.DirectionalFusionTargetFetterGroup = 1;
		return true;
	}

	// Token: 0x0600ADCF RID: 44495 RVA: 0x002E37E5 File Offset: 0x002E19E5
	private void InitCalabashInstance()
	{
		this.CalabashInstance = new CalabashInstance();
		this.InitCalabashDevelopRewardData();
		this.InitMonsterIdRecord();
	}

	// Token: 0x0600ADD0 RID: 44496 RVA: 0x002E3800 File Offset: 0x002E1A00
	private void InitCalabashDevelopRewardData()
	{
		IEnumerable<CalabashDevelopReward> calabashDevelopList = ConfigBase<CalabashConfig>.Instance.GetCalabashDevelopList();
		if (this.CalabashDevelopRewardDataMap == null)
		{
			this.CalabashDevelopRewardDataMap = new Dictionary<int, CalabashDevelopRewardData>();
		}
		foreach (CalabashDevelopReward developReward in calabashDevelopList)
		{
			Aki.Config.MonsterInfo? monsterInfoConfig = ConfigBase<MonsterInfoConfig>.Instance.GetMonsterInfoConfig(developReward.MonsterInfoId);
			CalabashDevelopRewardData value = new CalabashDevelopRewardData(developReward, monsterInfoConfig.Value.Name);
			if (developReward.IsShow)
			{
				this.CalabashDevelopRewardDataMap[developReward.MonsterId] = value;
			}
		}
	}

	// Token: 0x0600ADD1 RID: 44497 RVA: 0x002E38A4 File Offset: 0x002E1AA4
	public void UpdateCalabashDevelopRewardData()
	{
		foreach (KeyValuePair<int, List<ICalabashDevelopConditionState>> keyValuePair in this.GetUnlockCalabashDevelopRewards())
		{
			CalabashDevelopRewardData calabashDevelopRewardData = this.CalabashDevelopRewardDataMap[keyValuePair.Key];
			calabashDevelopRewardData.UnlockData = true;
			calabashDevelopRewardData.SetUnlockConditionMap(keyValuePair.Value);
			calabashDevelopRewardData.RewardNumData = keyValuePair.Value.Count;
		}
		Singleton<EventSystem>.Instance.Emit(EEventName.HasCalabashExp);
	}

	// Token: 0x0600ADD2 RID: 44498 RVA: 0x002E3938 File Offset: 0x002E1B38
	public CalabashDevelopRewardData[] GetCalabashDevelopRewardSortData()
	{
		List<CalabashDevelopRewardData> list = new List<CalabashDevelopRewardData>();
		foreach (CalabashDevelopRewardData item in this.CalabashDevelopRewardDataMap.Values)
		{
			list.Add(item);
		}
		list.Sort(new Comparison<CalabashDevelopRewardData>(this.SortByDevelopRewardSortId));
		return list.ToArray();
	}

	// Token: 0x0600ADD3 RID: 44499 RVA: 0x002E39B0 File Offset: 0x002E1BB0
	private int SortByDevelopRewardSortId(CalabashDevelopRewardData a, CalabashDevelopRewardData b)
	{
		return a.DevelopReward.SortId - b.DevelopReward.SortId;
	}

	// Token: 0x0600ADD4 RID: 44500 RVA: 0x002E39C9 File Offset: 0x002E1BC9
	public void SetCalabashInstanceBaseInfo(CalabashMsg baseInfo)
	{
		if (this.CalabashInstance == null)
		{
			this.InitCalabashInstance();
		}
		this.CalabashInstance.SetBaseInfo(baseInfo);
	}

	// Token: 0x0600ADD5 RID: 44501 RVA: 0x002E39E5 File Offset: 0x002E1BE5
	public void SetCalabashInstanceConfigInfo(CalabashCfg configInfo)
	{
		if (this.CalabashInstance == null)
		{
			this.InitCalabashInstance();
		}
		this.CalabashInstance.SetConfigInfo(configInfo);
	}

	// Token: 0x0600ADD6 RID: 44502 RVA: 0x002E3A04 File Offset: 0x002E1C04
	public void InitMonsterIdRecord()
	{
		this.MonsterIdRecordList = (LocalStorage.GetPlayer<List<int>>(ELocalStoragePlayerKey.CalabashCollect, null) ?? new List<int>());
		this.MonsterIdRecordSet = new HashSet<int>();
		foreach (int item in this.MonsterIdRecordList)
		{
			this.MonsterIdRecordSet.Add(item);
		}
	}

	// Token: 0x0600ADD7 RID: 44503 RVA: 0x002E3A80 File Offset: 0x002E1C80
	public void SetCalabashLevel(int level)
	{
		this.CalabashInstance.CalabashCurrentLevel = level;
		Singleton<EventSystem>.Instance.Emit(EEventName.CalabashLevelUpdate);
	}

	// Token: 0x0600ADD8 RID: 44504 RVA: 0x002E3A9E File Offset: 0x002E1C9E
	public int GetCalabashLevel()
	{
		return this.CalabashInstance.CalabashCurrentLevel;
	}

	// Token: 0x0600ADD9 RID: 44505 RVA: 0x002E3AAB File Offset: 0x002E1CAB
	public int GetCalabashMaxLevel()
	{
		return this.CalabashInstance.CalabashMaxLevel;
	}

	// Token: 0x0600ADDA RID: 44506 RVA: 0x002E3AB8 File Offset: 0x002E1CB8
	public int GetIdentifyGuaranteeCount()
	{
		return this.CalabashInstance.IdentifyGuaranteeCount;
	}

	// Token: 0x0600ADDB RID: 44507 RVA: 0x002E3AC5 File Offset: 0x002E1CC5
	public int GetLowCostIdentifyGuaranteeCount()
	{
		return this.CalabashInstance.LowCostIdentifyGuaranteeCount;
	}

	// Token: 0x0600ADDC RID: 44508 RVA: 0x002E3AD4 File Offset: 0x002E1CD4
	public int GetLeftIntensifyCaptureGuarantee()
	{
		int calabashCurrentLevel = this.CalabashInstance.CalabashCurrentLevel;
		CalabashLevel? calabashConfigByLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(calabashCurrentLevel);
		int num = (calabashConfigByLevel != null) ? calabashConfigByLevel.GetValueOrDefault().IntensifyCaptureGuarantee : 0;
		int identifyGuaranteeCount = this.GetIdentifyGuaranteeCount();
		return Math.Max(num - identifyGuaranteeCount, 0);
	}

	// Token: 0x0600ADDD RID: 44509 RVA: 0x002E3B24 File Offset: 0x002E1D24
	public int GetLeftLowCostIntensifyCaptureGuarantee()
	{
		int calabashCurrentLevel = this.CalabashInstance.CalabashCurrentLevel;
		CalabashLevel? calabashConfigByLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(calabashCurrentLevel);
		int num = (calabashConfigByLevel != null) ? calabashConfigByLevel.GetValueOrDefault().IntensifyCaptureGuarantee : 0;
		int lowCostIdentifyGuaranteeCount = this.GetLowCostIdentifyGuaranteeCount();
		return Math.Max(num - lowCostIdentifyGuaranteeCount, 0);
	}

	// Token: 0x0600ADDE RID: 44510 RVA: 0x002E3B73 File Offset: 0x002E1D73
	public void SetCurrentExp(int curExp)
	{
		this.CalabashInstance.CalabashCurrentExp = curExp;
	}

	// Token: 0x0600ADDF RID: 44511 RVA: 0x002E3B81 File Offset: 0x002E1D81
	public int GetCurrentExp()
	{
		return this.CalabashInstance.CalabashCurrentExp;
	}

	// Token: 0x0600ADE0 RID: 44512 RVA: 0x002E3B8E File Offset: 0x002E1D8E
	public void SetUnlockCalabashDevelopReward(CalabashDevelopInfo developReward)
	{
		this.CalabashInstance.SetUnlockCalabashDevelopReward(developReward);
	}

	// Token: 0x0600ADE1 RID: 44513 RVA: 0x002E3B9C File Offset: 0x002E1D9C
	public Dictionary<int, List<ICalabashDevelopConditionState>> GetUnlockCalabashDevelopRewards()
	{
		return this.CalabashInstance.GetUnlockCalabashDevelopRewards();
	}

	// Token: 0x0600ADE2 RID: 44514 RVA: 0x002E3BAC File Offset: 0x002E1DAC
	public bool CheckCalabashMonsterUnlocked(int monsterId)
	{
		CalabashDevelopRewardData calabashDevelopRewardData;
		return this.CalabashDevelopRewardDataMap.TryGetValue(monsterId, out calabashDevelopRewardData) && calabashDevelopRewardData.UnlockData;
	}

	// Token: 0x0600ADE3 RID: 44515 RVA: 0x002E3BD1 File Offset: 0x002E1DD1
	public string GetMonsterName(string id)
	{
		return "CalabashCatchGain_" + id;
	}

	// Token: 0x0600ADE4 RID: 44516 RVA: 0x002E3BE0 File Offset: 0x002E1DE0
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public ICalabashDevelopRewardInfoData[] GetCalabashDevelopRewardInfoData(int id)
	{
		CalabashDevelopRewardData calabashDevelopRewardData;
		if (!this.CalabashDevelopRewardDataMap.TryGetValue(id, out calabashDevelopRewardData))
		{
			return null;
		}
		List<ICalabashDevelopRewardInfoData> list = new List<ICalabashDevelopRewardInfoData>();
		foreach (int id2 in calabashDevelopRewardData.DevelopReward.DevelopCondition())
		{
			CalabashDevelopCondition calabashConditionById = ConfigBase<CalabashConfig>.Instance.GetCalabashConditionById(id2);
			bool flag;
			bool isUnlock = calabashDevelopRewardData.GetUnlockConditionMap().TryGetValue(calabashConditionById.Id, out flag) > false;
			CalabashDevelopRewardInfoData item = new CalabashDevelopRewardInfoData
			{
				IsUnlock = isUnlock,
				Info = calabashConditionById.Description,
				Num = ConfigBase<CalabashConfig>.Instance.GetCalabashConditionRewardExp(calabashConditionById)
			};
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x0600ADE5 RID: 44517 RVA: 0x002E3C88 File Offset: 0x002E1E88
	public unsafe int GetCalabashDevelopRewardExpByMonsterId(int monsterId)
	{
		int num = 0;
		CalabashDevelopRewardData calabashDevelopRewardData;
		if (!this.CalabashDevelopRewardDataMap.TryGetValue(monsterId, out calabashDevelopRewardData))
		{
			return num;
		}
		Span<int> developConditionBytes = calabashDevelopRewardData.DevelopReward.GetDevelopConditionBytes();
		for (int i = 0; i < developConditionBytes.Length; i++)
		{
			int id = *developConditionBytes[i];
			CalabashDevelopCondition calabashConditionById = ConfigBase<CalabashConfig>.Instance.GetCalabashConditionById(id);
			bool flag;
			if (calabashDevelopRewardData.GetUnlockConditionMap().TryGetValue(calabashConditionById.Id, out flag) && flag)
			{
				num += ConfigBase<CalabashConfig>.Instance.GetCalabashConditionRewardExp(calabashConditionById);
			}
		}
		return num;
	}

	// Token: 0x0600ADE6 RID: 44518 RVA: 0x002E3D0C File Offset: 0x002E1F0C
	public int GetCalabashAllSchedule()
	{
		int num = 0;
		foreach (CalabashDevelopRewardData calabashDevelopRewardData in this.CalabashDevelopRewardDataMap.Values)
		{
			num += calabashDevelopRewardData.RewardSumNumData;
		}
		return num;
	}

	// Token: 0x0600ADE7 RID: 44519 RVA: 0x002E3D6C File Offset: 0x002E1F6C
	public int GetCalabashOwnSchedule()
	{
		int num = 0;
		foreach (CalabashDevelopRewardData calabashDevelopRewardData in this.CalabashDevelopRewardDataMap.Values)
		{
			num += calabashDevelopRewardData.UnlockSize;
		}
		return num;
	}

	// Token: 0x17000E40 RID: 3648
	// (get) Token: 0x0600ADE8 RID: 44520 RVA: 0x002E3DCC File Offset: 0x002E1FCC
	// (set) Token: 0x0600ADE9 RID: 44521 RVA: 0x002E3DD4 File Offset: 0x002E1FD4
	public CalabashInstance CalabashInstance
	{
		get
		{
			return this.CalabashInstanceInternal;
		}
		set
		{
			this.CalabashInstanceInternal = value;
		}
	}

	// Token: 0x17000E41 RID: 3649
	// (get) Token: 0x0600ADEA RID: 44522 RVA: 0x002E3DDD File Offset: 0x002E1FDD
	public List<VisionUnlockQualityData> CalabashUnlockTipsList
	{
		get
		{
			return this.UnlockTipsList;
		}
	}

	// Token: 0x0600ADEB RID: 44523 RVA: 0x002E3DE8 File Offset: 0x002E1FE8
	public void AddCalabashUnlockTipsList(int monsterItemId, int unlockQuality)
	{
		VisionUnlockQualityData visionUnlockQualityData = new VisionUnlockQualityData();
		visionUnlockQualityData.MonsterItemId = monsterItemId;
		visionUnlockQualityData.UnlockQuality = unlockQuality;
		this.UnlockTipsList.Add(visionUnlockQualityData);
	}

	// Token: 0x0600ADEC RID: 44524 RVA: 0x002E3E15 File Offset: 0x002E2015
	public void SetCalabashLevelsReward(List<int> levelList)
	{
		this.CalabashInstance.SetRewardedLevelsSet(levelList);
		Singleton<EventSystem>.Instance.Emit(EEventName.GetCalabashReward);
	}

	// Token: 0x0600ADED RID: 44525 RVA: 0x002E3E34 File Offset: 0x002E2034
	public int GetCurrentExpByLevel(int level)
	{
		if (level < this.CalabashInstance.CalabashCurrentLevel)
		{
			return ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(level).Value.LevelUpExp;
		}
		if (level == this.CalabashInstance.CalabashCurrentLevel)
		{
			return this.CalabashInstance.CalabashCurrentExp;
		}
		return 0;
	}

	// Token: 0x0600ADEE RID: 44526 RVA: 0x002E3E88 File Offset: 0x002E2088
	public int GetMaxExpByLevel(int level)
	{
		return ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(level).Value.LevelUpExp;
	}

	// Token: 0x0600ADEF RID: 44527 RVA: 0x002E3EB0 File Offset: 0x002E20B0
	public ECalabashRewardState GetReceiveRewardStateByLevel(int level)
	{
		if (level == 0)
		{
			return ECalabashRewardState.None;
		}
		if (this.CalabashInstance.IsRewardedByLevel(level))
		{
			return ECalabashRewardState.HasReceived;
		}
		if (level > this.CalabashInstance.CalabashCurrentLevel)
		{
			return ECalabashRewardState.CantReceive;
		}
		return ECalabashRewardState.CanReceive;
	}

	// Token: 0x0600ADF0 RID: 44528 RVA: 0x002E3ED8 File Offset: 0x002E20D8
	public bool IsLimitToLevelUp(int level)
	{
		if (level != this.CalabashInstance.CalabashCurrentLevel)
		{
			return false;
		}
		CalabashLevel? calabashConfigByLevel = ConfigBase<CalabashConfig>.Instance.GetCalabashConfigByLevel(level);
		return this.CalabashInstance.CalabashCurrentExp >= calabashConfigByLevel.Value.LevelUpExp;
	}

	// Token: 0x0600ADF1 RID: 44529 RVA: 0x002E3F20 File Offset: 0x002E2120
	public int GetCatchGainByLevel(int level)
	{
		return this.CalabashInstance.GetCatchGainByLevel(level).GetValueOrDefault();
	}

	// Token: 0x0600ADF2 RID: 44530 RVA: 0x002E3F44 File Offset: 0x002E2144
	public bool CheckCanReceiveReward()
	{
		if (this.CalabashInstance == null)
		{
			return false;
		}
		for (int i = 1; i <= this.CalabashInstance.CalabashCurrentLevel; i++)
		{
			if (this.GetReceiveRewardStateByLevel(i) == ECalabashRewardState.CanReceive)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x0600ADF3 RID: 44531 RVA: 0x002E3F7E File Offset: 0x002E217E
	public bool RecordMonsterId(int monsterId)
	{
		HashSet<int> monsterIdRecordSet = this.MonsterIdRecordSet;
		if (monsterIdRecordSet != null && monsterIdRecordSet.Add(monsterId))
		{
			List<int> monsterIdRecordList = this.MonsterIdRecordList;
			if (monsterIdRecordList != null)
			{
				monsterIdRecordList.Add(monsterId);
			}
			LocalStorage.SetPlayer<List<int>>(ELocalStoragePlayerKey.CalabashCollect, this.MonsterIdRecordList);
			return true;
		}
		return false;
	}

	// Token: 0x0600ADF4 RID: 44532 RVA: 0x002E3FB8 File Offset: 0x002E21B8
	public bool CheckMonsterIdInRecord(int monsterId)
	{
		return this.MonsterIdRecordSet.Contains(monsterId);
	}

	// Token: 0x0600ADF5 RID: 44533 RVA: 0x002E3FC6 File Offset: 0x002E21C6
	public void CheckSimpleStateSave()
	{
		if (!LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.CalabashCollectIsSimpleDetail, false))
		{
			this.SaveIfSimpleState(true);
		}
	}

	// Token: 0x0600ADF6 RID: 44534 RVA: 0x002E3FD9 File Offset: 0x002E21D9
	public bool GetIfSimpleState()
	{
		return LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.CalabashCollectIsSimpleDetail, false);
	}

	// Token: 0x0600ADF7 RID: 44535 RVA: 0x002E3FE3 File Offset: 0x002E21E3
	public void SaveIfSimpleState(bool state)
	{
		if (LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.CalabashCollectIsSimpleDetail, false) == state)
		{
			return;
		}
		LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.CalabashCollectIsSimpleDetail, state);
		Singleton<EventSystem>.Instance.Emit(EEventName.ChangeCalabashCollectSimplyState);
	}

	// Token: 0x0600ADF8 RID: 44536 RVA: 0x002E400C File Offset: 0x002E220C
	public UiDynamicTab[] GetViewTabList()
	{
		List<UiDynamicTab> viewTabList = ConfigBase<DynamicTabConfig>.Instance.GetViewTabList(EUiViewName.CalabashRootView);
		if (this.OnlyShowBattleFettersTab)
		{
			List<UiDynamicTab> list = new List<UiDynamicTab>();
			foreach (UiDynamicTab item in viewTabList)
			{
				if (item.ChildViewName == EUiTabViewName.PhantomBattleFettersTabView.ToString())
				{
					list.Add(item);
				}
			}
			return list.ToArray();
		}
		List<UiDynamicTab> list2 = new List<UiDynamicTab>();
		foreach (UiDynamicTab item2 in viewTabList)
		{
			if (ModelBase<FunctionModel>.Instance.IsOpen(item2.FunctionId))
			{
				list2.Add(item2);
			}
		}
		return list2.ToArray();
	}

	// Token: 0x0600ADF9 RID: 44537 RVA: 0x002E4104 File Offset: 0x002E2304
	public PhantomFetterGroup[] GetPhantomFetterGroupList()
	{
		if (!this.OnlyShowBattleFettersTab)
		{
			return ConfigCommon.ToList<PhantomFetterGroup>(ConfigBase<PhantomBattleConfig>.Instance.GetPhantomFetterGroupList()).ToArray();
		}
		List<PhantomFetterGroup> list = new List<PhantomFetterGroup>();
		int[] array = this.OnlyShowPhantomFetterGroupIdList ?? new int[0];
		for (int i = 0; i < array.Length; i++)
		{
			PhantomFetterGroup? config = ConfigPhantomFetterGroupById.GetConfig(array[i], true);
			if (config != null)
			{
				list.Add(config.Value);
			}
		}
		return list.ToArray();
	}

	// Token: 0x0600ADFA RID: 44538 RVA: 0x002E4179 File Offset: 0x002E2379
	public void GmClearData()
	{
		this.UnlockTipsList.Clear();
	}

	// Token: 0x0600ADFB RID: 44539 RVA: 0x002E4188 File Offset: 0x002E2388
	public int[] GetVisionRefineRecommendAttributes(int cost, int fetter)
	{
		IReadOnlyList<RefineRecommend> configList = ConfigRefineRecommendByCost.GetConfigList(cost, true);
		if (configList.Count == 0)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Calabash;
			ELogAuthor author = ELogAuthor.WDX;
			string message = "获取洗炼推荐配置失败, 请检查配置表";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("cost", cost);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new int[0];
		}
		foreach (RefineRecommend refineRecommend in configList)
		{
			if (refineRecommend.FetterArray().Contains(fetter))
			{
				return refineRecommend.PropertyArray().ToArray<int>();
			}
		}
		return new int[0];
	}

	// Token: 0x0600ADFC RID: 44540 RVA: 0x002E4238 File Offset: 0x002E2438
	public void ClearOnlyShowData()
	{
		this.OnlyShowBattleFettersTab = false;
		this.OnlyMonsterCostShowMaxLevel = null;
	}

	// Token: 0x0600ADFD RID: 44541 RVA: 0x002E424D File Offset: 0x002E244D
	public void SetDirectionalFusionTargetFetter(int fetterId)
	{
		this.DirectionalFusionTargetFetterGroup = fetterId;
		Singleton<EventSystem>.Instance.Emit(EEventName.SelectDirectionalFusionTarget);
	}

	// Token: 0x04005252 RID: 21074
	public bool OnlyShowBattleFettersTab;

	// Token: 0x04005253 RID: 21075
	public int? OnlyMonsterCostShowMaxLevel;

	// Token: 0x04005254 RID: 21076
	[Nullable(2)]
	public int[] OnlyShowPhantomFetterGroupIdList;

	// Token: 0x04005255 RID: 21077
	[Nullable(2)]
	private CalabashInstance CalabashInstanceInternal;

	// Token: 0x04005256 RID: 21078
	[Nullable(new byte[]
	{
		2,
		1
	})]
	private Dictionary<int, CalabashDevelopRewardData> CalabashDevelopRewardDataMap;

	// Token: 0x04005257 RID: 21079
	[Nullable(2)]
	private HashSet<int> MonsterIdRecordSet;

	// Token: 0x04005258 RID: 21080
	[Nullable(2)]
	private List<int> MonsterIdRecordList;

	// Token: 0x04005259 RID: 21081
	public bool HideVisionRecoveryConfirmBox;

	// Token: 0x0400525A RID: 21082
	public bool IsNeedRefineSubConfirmBox;

	// Token: 0x0400525B RID: 21083
	public int DirectionalFusionTime;

	// Token: 0x0400525C RID: 21084
	public int DirectionalFusionTimeMax;

	// Token: 0x0400525D RID: 21085
	public int DirectionalFusionTargetFetterGroup;

	// Token: 0x0400525E RID: 21086
	private readonly List<VisionUnlockQualityData> UnlockTipsList;
}
