using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Inventory;
using CSharpScript.Game.Module.TowerDefence;
using CSharpScript.Module.InstanceDungeon;

// Token: 0x02002BC8 RID: 11208
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class TowerDefenseModel : ModelBase<TowerDefenseModel>
{
	// Token: 0x17001D77 RID: 7543
	// (get) Token: 0x060165CB RID: 91595 RVA: 0x00632F10 File Offset: 0x00631110
	// (set) Token: 0x060165CC RID: 91596 RVA: 0x00632F70 File Offset: 0x00631170
	public bool IsEnterInActivityClicked
	{
		get
		{
			if (this.IsEnterInActivityClickedCache == null)
			{
				bool? flag = new bool?(LocalStorage.GetPlayer<bool>(ELocalStoragePlayerKey.TowerDefenseEntered, false));
				if (flag == null)
				{
					LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.TowerDefenseEntered, false);
					flag = new bool?(false);
				}
				this.IsEnterInActivityClickedCache = new bool?(flag.Value);
			}
			return this.IsEnterInActivityClickedCache.Value;
		}
		set
		{
			bool? isEnterInActivityClickedCache = this.IsEnterInActivityClickedCache;
			if (!(isEnterInActivityClickedCache.GetValueOrDefault() == value & isEnterInActivityClickedCache != null))
			{
				this.IsEnterInActivityClickedCache = new bool?(value);
				LocalStorage.SetPlayer<bool>(ELocalStoragePlayerKey.TowerDefenseEntered, value);
			}
		}
	}

	// Token: 0x17001D78 RID: 7544
	// (get) Token: 0x060165CD RID: 91597 RVA: 0x00632FAF File Offset: 0x006311AF
	public Dictionary<int, ITowerDefensePhantomConfig> PhantomConfigCache { get; } = new Dictionary<int, ITowerDefensePhantomConfig>();

	// Token: 0x17001D79 RID: 7545
	// (get) Token: 0x060165CE RID: 91598 RVA: 0x00632FB7 File Offset: 0x006311B7
	public List<ITowerDefensePhantomConfig> SortedPhantomConfigCache { get; } = new List<ITowerDefensePhantomConfig>();

	// Token: 0x060165CF RID: 91599 RVA: 0x00632FC0 File Offset: 0x006311C0
	public unsafe int GetCurrentPhantomIdInBattle()
	{
		SceneTeamItem currentSceneTeamItem = ControllerBase<TowerDefenseController>.Instance.GetCurrentSceneTeamItem();
		int playerId = currentSceneTeamItem.GetPlayerId();
		int getConfigId = currentSceneTeamItem.GetConfigId;
		ITowerDefensePhantomDataOwner ownerData = this.GetOwnerData(playerId, getConfigId);
		if (ownerData == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "塔防战斗中获取声骸ID失败：未获取OwnerData";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("PlayerID", playerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("RoleCfgID", getConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 2) = new ValueTuple<string, object>("Owner Data", ownerData);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 3));
			return 0;
		}
		if (ownerData.PhantomId <= 0)
		{
			Log instance2 = Singleton<Log>.Instance;
			ELogModule module2 = ELogModule.TowerDefense;
			ELogAuthor author2 = ELogAuthor.WZ;
			string message2 = "塔防战斗中获取声骸ID失败：未赋值声骸";
			<>y__InlineArray3<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray3<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("PlayerID", playerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("RoleCfgID", getConfigId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 2) = new ValueTuple<string, object>("Owner Data", ownerData);
			instance2.Error(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray3<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 3));
		}
		return ownerData.PhantomId;
	}

	// Token: 0x060165D0 RID: 91600 RVA: 0x006330F4 File Offset: 0x006312F4
	private List<ITowerDefensePhantomConfigSkillData> GetCurrentPhantomSkillCfgCore(int phantomId)
	{
		ITowerDefensePhantomConfig towerDefensePhantomConfig;
		if (!this.PhantomConfigCache.TryGetValue(phantomId, out towerDefensePhantomConfig))
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "未能获得塔防声骸技能配置";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TowerDefensePhantomId", phantomId);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return new List<ITowerDefensePhantomConfigSkillData>();
		}
		return towerDefensePhantomConfig.SkillDataList;
	}

	// Token: 0x060165D1 RID: 91601 RVA: 0x0063314C File Offset: 0x0063134C
	public List<ITowerDefensePhantomConfigSkillData> GetCurrentPhantomSkillCfgListInBattle()
	{
		int currentPhantomIdInBattle = this.GetCurrentPhantomIdInBattle();
		return this.GetCurrentPhantomSkillCfgCore(currentPhantomIdInBattle);
	}

	// Token: 0x060165D2 RID: 91602 RVA: 0x00633168 File Offset: 0x00631368
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public List<string> GetCurrentPhantomSkillDescriptionArgsInBattle()
	{
		int currentPhantomIdInBattle = this.GetCurrentPhantomIdInBattle();
		string[] phantomSkillDescriptionArgsByPhantomId = ControllerBase<TowerDefenseController>.Instance.GetPhantomSkillDescriptionArgsByPhantomId(currentPhantomIdInBattle);
		if (phantomSkillDescriptionArgsByPhantomId == null)
		{
			return null;
		}
		return phantomSkillDescriptionArgsByPhantomId.ToList<string>();
	}

	// Token: 0x060165D3 RID: 91603 RVA: 0x00633194 File Offset: 0x00631394
	public int GetCurrentPhantomLevelInBattle()
	{
		int currentPhantomIdInBattle = this.GetCurrentPhantomIdInBattle();
		TowerDefencePhantomInfo towerDefencePhantomInfo;
		if (this.PhantomMessageCache.OwnPhantomInBattleDataCache.TryGetValue(currentPhantomIdInBattle, out towerDefencePhantomInfo))
		{
			return towerDefencePhantomInfo.Level;
		}
		return 1;
	}

	// Token: 0x060165D4 RID: 91604 RVA: 0x006331C8 File Offset: 0x006313C8
	public ITowerDefensePhantomExp GetCurrentPhantomExpPairInBattle()
	{
		int currentPhantomIdInBattle = this.GetCurrentPhantomIdInBattle();
		Dictionary<int, TowerDefencePhantomInfo> ownPhantomInBattleDataCache = this.PhantomMessageCache.OwnPhantomInBattleDataCache;
		ITowerDefensePhantomExp towerDefensePhantomExp = new TowerDefensePhantomExp
		{
			Exp = 0.0,
			Threshold = 0.0
		};
		TowerDefencePhantomInfo towerDefencePhantomInfo;
		if (ownPhantomInBattleDataCache.TryGetValue(currentPhantomIdInBattle, out towerDefencePhantomInfo))
		{
			ITowerDefensePhantomConfig towerDefensePhantomConfig;
			if (!this.PhantomConfigCache.TryGetValue(towerDefencePhantomInfo.Id, out towerDefensePhantomConfig))
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.TowerDefense;
				ELogAuthor author = ELogAuthor.WZ;
				string message = "战斗中声骸ID，协议与配置不匹配，以协议ID找不到配置数据";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("协议声骸ID", towerDefencePhantomInfo.Id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return towerDefensePhantomExp;
			}
			int level = towerDefencePhantomInfo.Level;
			double num = 0.0;
			if (level >= 1 && towerDefensePhantomConfig.MaxLevel > 1)
			{
				num = ((towerDefensePhantomConfig.MaxLevel == towerDefencePhantomInfo.Level) ? towerDefensePhantomConfig.SkillDataList[level - 2].ExpThreshold : towerDefensePhantomConfig.SkillDataList[level - 1].ExpThreshold).GetValueOrDefault();
			}
			towerDefensePhantomExp.Exp = ((towerDefensePhantomConfig.MaxLevel == towerDefencePhantomInfo.Level) ? num : ((double)towerDefencePhantomInfo.Exp));
			towerDefensePhantomExp.Threshold = num;
		}
		else
		{
			ITowerDefensePhantomConfig towerDefensePhantomConfig2;
			if (!this.PhantomConfigCache.TryGetValue(currentPhantomIdInBattle, out towerDefensePhantomConfig2))
			{
				return towerDefensePhantomExp;
			}
			towerDefensePhantomExp.Exp = 0.0;
			towerDefensePhantomExp.Threshold = towerDefensePhantomConfig2.SkillDataList[0].ExpThreshold.GetValueOrDefault();
		}
		return towerDefensePhantomExp;
	}

	// Token: 0x060165D5 RID: 91605 RVA: 0x00633338 File Offset: 0x00631538
	public string GetCurrentPhantomNameTextId()
	{
		TowerDefencePhantom? config = ConfigTowerDefencePhantomById.GetConfig(this.GetCurrentPhantomIdInBattle(), true);
		if (config != null)
		{
			return config.Value.PhantomName;
		}
		return "";
	}

	// Token: 0x060165D6 RID: 91606 RVA: 0x00633370 File Offset: 0x00631570
	public List<ITowerDefensePhantomConfigSkillData> GetCurrentPhantomSkillCfgTemp()
	{
		return this.GetCurrentPhantomSkillCfgCore(this.CurrentSelfPhantomIdInUiTemp);
	}

	// Token: 0x060165D7 RID: 91607 RVA: 0x0063337E File Offset: 0x0063157E
	public ParsedTowerDefenseMsg GetOrCreateParsedTowerDefenseMsg()
	{
		if (this.PhantomMessageCache == null)
		{
			this.PhantomMessageCache = new ParsedTowerDefenseMsg();
		}
		return this.PhantomMessageCache;
	}

	// Token: 0x060165D8 RID: 91608 RVA: 0x0063339C File Offset: 0x0063159C
	[return: Nullable(2)]
	public List<int> GetProtocolPhantomIdList(List<int> roleCfgIdList)
	{
		if (ControllerBase<TowerDefenseController>.Instance.CheckInUiFlow() || ControllerBase<TowerDefenseController>.Instance.CheckInInstanceDungeon())
		{
			List<int> list = new List<int>();
			int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
			foreach (int roleCfgId in roleCfgIdList)
			{
				ITowerDefensePhantomDataOwner ownerData = this.GetOwnerData(value, roleCfgId);
				list.Add(ownerData.PhantomId);
			}
			return list;
		}
		return null;
	}

	// Token: 0x060165D9 RID: 91609 RVA: 0x00633430 File Offset: 0x00631630
	[NullableContext(0)]
	[return: TupleElementNames(new string[]
	{
		"rewardedCount",
		"totalCount"
	})]
	public ValueTuple<int, int> GetPreviewRewardCount()
	{
		int num = 0;
		int num2 = 0;
		IReadOnlyList<TowerDefenceReward> configList = ConfigTowerDefenceRewardAll.GetConfigList(true);
		if (configList == null)
		{
			return new ValueTuple<int, int>(num, num2);
		}
		foreach (TowerDefenceReward towerDefenceReward in configList)
		{
			if (towerDefenceReward.ActivityId == this.PhantomMessageCache.Id)
			{
				if (this.PhantomMessageCache.GetScoreRewardStateById(towerDefenceReward.Id) == EActivityRewardState.Claimed)
				{
					num++;
				}
				num2++;
			}
		}
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in this.PhantomMessageCache.StageListCache)
		{
			if (this.PhantomMessageCache.GetPassRewardStateById(towerDefenseParsedStageMessage.Id) == EActivityRewardState.Claimed)
			{
				num++;
			}
			num2++;
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x060165DA RID: 91610 RVA: 0x00633520 File Offset: 0x00631720
	public IActivityRewardViewData GetPreviewRewardData()
	{
		IReadOnlyList<TowerDefenceReward> configList = ConfigTowerDefenceRewardAll.GetConfigList(true);
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		if (configList != null)
		{
			foreach (TowerDefenceReward towerDefenceReward in configList)
			{
				if (towerDefenceReward.ActivityId == this.PhantomMessageCache.Id)
				{
					List<TItem> list2 = new List<TItem>();
					foreach (KeyValuePair<int, int> keyValuePair in ConfigDropPackageById.GetConfig(towerDefenceReward.RewardId, true).Value.DropPreview())
					{
						list2.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair.Key, 0), keyValuePair.Value));
					}
					EActivityRewardState scoreRewardStateById = this.PhantomMessageCache.GetScoreRewardStateById(towerDefenceReward.Id);
					ActivityRewardData item = new ActivityRewardData
					{
						Id = new int?(towerDefenceReward.Id),
						NameText = "",
						NameTextId = "ConditionGroup_12100402_HintText",
						NameTextArgs = new string[]
						{
							towerDefenceReward.Score.ToString()
						},
						RewardList = list2.ToArray(),
						RewardState = scoreRewardStateById,
						RewardButtonText = this.GetPreviewButtonTextByState(scoreRewardStateById),
						RewardButtonRedDot = new bool?(scoreRewardStateById == EActivityRewardState.Enable),
						ProgressText = this.BuildScoreProgressText(towerDefenceReward.Score, -1),
						ClickFunction = delegate
						{
							ControllerBase<TowerDefenseController>.Instance.RequestScoreReward(this.CollectClaimableScoreRewardIds());
						}
					};
					list.Add(item);
				}
			}
		}
		list.Sort(new Comparison<IActivityRewardData>(this.SortRewardHandler));
		List<IActivityRewardData> list3 = new List<IActivityRewardData>();
		List<IActivityRewardData> list4 = new List<IActivityRewardData>();
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in this.PhantomMessageCache.StageListCache)
		{
			List<TItem> list5 = new List<TItem>();
			TowerDefenceInstance? towerDefenseInstanceCfg = ConfigTowerDefenceInstanceById.GetConfig(towerDefenseParsedStageMessage.Id, true);
			int instanceId = towerDefenseInstanceCfg.Value.InstanceId;
			string localTextNew = ConfigMultiTextLang.GetLocalTextNew(ConfigBase<InstanceDungeonConfig>.Instance.GetConfig(instanceId).Value.MapName, null);
			foreach (KeyValuePair<int, int> keyValuePair2 in ConfigDropPackageById.GetConfig(towerDefenseInstanceCfg.Value.RewardId, true).Value.DropPreview())
			{
				list5.Add(new TItem(new InventoryDefine.GetItemData(keyValuePair2.Key, 0), keyValuePair2.Value));
			}
			EActivityRewardState passRewardStateById = this.PhantomMessageCache.GetPassRewardStateById(towerDefenseParsedStageMessage.Id);
			string nameTextId = towerDefenseInstanceCfg.Value.IsDifficult ? "TowerDefenceclear" : "ConditionGroup_12100401_HintText";
			List<string> list7;
			if (!towerDefenseInstanceCfg.Value.IsDifficult)
			{
				List<string> list6 = new List<string>();
				list6.Add(localTextNew);
				list7 = list6;
				list6.Add(towerDefenseInstanceCfg.Value.RewardScore.ToString());
			}
			else
			{
				(list7 = new List<string>()).Add(localTextNew);
			}
			List<string> list8 = list7;
			ActivityRewardData item2 = new ActivityRewardData
			{
				Id = new int?(towerDefenseInstanceCfg.Value.Id),
				NameText = "",
				NameTextId = nameTextId,
				NameTextArgs = list8.ToArray(),
				RewardList = list5.ToArray(),
				RewardState = passRewardStateById,
				RewardButtonText = this.GetPreviewButtonTextByState(passRewardStateById),
				RewardButtonRedDot = new bool?(passRewardStateById == EActivityRewardState.Enable),
				ProgressText = (towerDefenseInstanceCfg.Value.IsDifficult ? null : this.BuildScoreProgressText(towerDefenseInstanceCfg.Value.RewardScore, towerDefenseParsedStageMessage.Record)),
				ClickFunction = delegate
				{
					ControllerBase<TowerDefenseController>.Instance.RequestInstanceReward(this.CollectClaimableInstanceRewardIds(towerDefenseInstanceCfg.Value.IsDifficult));
				}
			};
			if (towerDefenseInstanceCfg.Value.IsDifficult)
			{
				list4.Add(item2);
			}
			else
			{
				list3.Add(item2);
			}
		}
		list3.Sort(new Comparison<IActivityRewardData>(this.SortRewardHandler));
		list4.Sort(new Comparison<IActivityRewardData>(this.SortRewardHandler));
		string localTextNew2 = ConfigMultiTextLang.GetLocalTextNew("TowerDefenceFullPoint", null);
		string tabTips = (localTextNew2 != null) ? StringUtils.Format(localTextNew2, new string[]
		{
			this.PhantomMessageCache.TotalScore.ToString()
		}) : "";
		List<IActivityRewardDataPage> list9 = new List<IActivityRewardDataPage>();
		if (list3.Count > 0)
		{
			list9.Add(new ActivityRewardDataPage
			{
				TabName = ConfigMultiTextLang.GetLocalTextNew("TowerDefenceLevelRewardText", null),
				TabTips = tabTips,
				DataList = list3
			});
		}
		if (list.Count > 0)
		{
			list9.Add(new ActivityRewardDataPage
			{
				TabName = ConfigMultiTextLang.GetLocalTextNew("TowerDefenceScoreRewardText", null),
				TabTips = tabTips,
				DataList = list
			});
		}
		if (list4.Count > 0)
		{
			list9.Add(new ActivityRewardDataPage
			{
				TabName = ConfigMultiTextLang.GetLocalTextNew("PrefabTextItem_1347286118_Text", null),
				TabTips = tabTips,
				DataList = list4
			});
		}
		return new ActivityRewardViewData
		{
			DataPageList = list9,
			Source = EActivityRewardSource.TowerDefence
		};
	}

	// Token: 0x060165DB RID: 91611 RVA: 0x00633B0C File Offset: 0x00631D0C
	private List<int> CollectClaimableScoreRewardIds()
	{
		List<int> list = new List<int>();
		IReadOnlyList<TowerDefenceReward> configList = ConfigTowerDefenceRewardAll.GetConfigList(true);
		if (configList != null)
		{
			foreach (TowerDefenceReward towerDefenceReward in configList)
			{
				if (towerDefenceReward.ActivityId == this.PhantomMessageCache.Id && this.PhantomMessageCache.GetScoreRewardStateById(towerDefenceReward.Id) == EActivityRewardState.Enable)
				{
					list.Add(towerDefenceReward.Id);
				}
			}
		}
		return list;
	}

	// Token: 0x060165DC RID: 91612 RVA: 0x00633B94 File Offset: 0x00631D94
	private List<int> CollectClaimableInstanceRewardIds(bool isDifficult)
	{
		List<int> list = new List<int>();
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in this.PhantomMessageCache.StageListCache)
		{
			TowerDefenceInstance? config = ConfigTowerDefenceInstanceById.GetConfig(towerDefenseParsedStageMessage.Id, true);
			if (config != null && config.Value.IsDifficult == isDifficult && this.PhantomMessageCache.GetPassRewardStateById(towerDefenseParsedStageMessage.Id) == EActivityRewardState.Enable)
			{
				list.Add(towerDefenseParsedStageMessage.Id);
			}
		}
		return list;
	}

	// Token: 0x060165DD RID: 91613 RVA: 0x00633C38 File Offset: 0x00631E38
	private string BuildScoreProgressText(int requiredScore, int current = -1)
	{
		int value = Math.Min((current < 0) ? this.PhantomMessageCache.TotalScore : current, requiredScore);
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(1, 2);
		defaultInterpolatedStringHandler.AppendFormatted<int>(value);
		defaultInterpolatedStringHandler.AppendLiteral("/");
		defaultInterpolatedStringHandler.AppendFormatted<int>(requiredScore);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x060165DE RID: 91614 RVA: 0x00633C8C File Offset: 0x00631E8C
	private int SortRewardHandler(IActivityRewardData a, IActivityRewardData b)
	{
		if (a.RewardState == b.RewardState)
		{
			return a.Id.Value - b.Id.Value;
		}
		if (a.RewardState == EActivityRewardState.Enable)
		{
			return -1;
		}
		if (b.RewardState == EActivityRewardState.Enable)
		{
			return 1;
		}
		if (a.RewardState == EActivityRewardState.Disabled)
		{
			return -1;
		}
		if (b.RewardState == EActivityRewardState.Disabled)
		{
			return 1;
		}
		return 0;
	}

	// Token: 0x060165DF RID: 91615 RVA: 0x00633CF0 File Offset: 0x00631EF0
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

	// Token: 0x060165E0 RID: 91616 RVA: 0x00633D58 File Offset: 0x00631F58
	public void ResetCurrentPhantomIdInUiTempToFirstAvailable()
	{
		foreach (ITowerDefensePhantomConfig towerDefensePhantomConfig in this.SortedPhantomConfigCache)
		{
			if (towerDefensePhantomConfig.ActivityId == this.PhantomMessageCache.Id)
			{
				bool flag = false;
				using (List<ITowerDefensePhantomDataOwner>.Enumerator enumerator2 = this.PhantomOwnerDataList.GetEnumerator())
				{
					while (enumerator2.MoveNext())
					{
						if (enumerator2.Current.PhantomId == towerDefensePhantomConfig.Id)
						{
							flag = true;
							break;
						}
					}
				}
				if (!flag)
				{
					this.CurrentSelfPhantomIdInUiTemp = towerDefensePhantomConfig.Id;
					return;
				}
			}
		}
		this.CurrentSelfPhantomIdInUiTemp = 0;
	}

	// Token: 0x060165E1 RID: 91617 RVA: 0x00633E1C File Offset: 0x0063201C
	public void ResetPhantomOwnerDataList()
	{
		this.PhantomOwnerDataList.Clear();
		for (int i = 0; i < 3; i++)
		{
			this.PhantomOwnerDataList.Add(new TowerDefensePhantomDataOwner
			{
				PlayerId = (long)ModelBase<PlayerInfoModel>.Instance.GetId().GetValueOrDefault(),
				IsSelf = true,
				RoleCfgId = 0,
				RoleSkinId = 0,
				PhantomId = 0
			});
		}
	}

	// Token: 0x060165E2 RID: 91618 RVA: 0x00633E88 File Offset: 0x00632088
	public void ResetPhantomOwnerDataByIndex(int index)
	{
		this.PhantomOwnerDataList[index].PlayerId = (long)ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		this.PhantomOwnerDataList[index].IsSelf = true;
		this.PhantomOwnerDataList[index].RoleCfgId = 0;
		this.PhantomOwnerDataList[index].RoleSkinId = 0;
		this.PhantomOwnerDataList[index].PhantomId = 0;
	}

	// Token: 0x060165E3 RID: 91619 RVA: 0x00633F04 File Offset: 0x00632104
	public void ResetAllCache()
	{
		this.CurrentSelfPhantomIdInUiTemp = 0;
		for (int i = 0; i < this.PhantomOwnerDataList.Count; i++)
		{
			this.ResetPhantomOwnerDataByIndex(i);
		}
		this.RoleCfgId2PhantomIdMapCache.Clear();
	}

	// Token: 0x060165E4 RID: 91620 RVA: 0x00633F40 File Offset: 0x00632140
	public void ResetPhantomOwnerDataByConfigId(int configId)
	{
		for (int i = 0; i < this.PhantomOwnerDataList.Count; i++)
		{
			ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner = this.PhantomOwnerDataList[i];
			if (towerDefensePhantomDataOwner.IsSelf && towerDefensePhantomDataOwner.RoleCfgId == configId)
			{
				this.ResetPhantomOwnerDataByIndex(i);
				break;
			}
		}
		this.RoleCfgId2PhantomIdMapCache.Remove(configId);
	}

	// Token: 0x060165E5 RID: 91621 RVA: 0x00633F98 File Offset: 0x00632198
	public void ResetTimerCacheInBattle()
	{
		foreach (KeyValuePair<int, Dictionary<int, TimerHandle>> keyValuePair in this.TimerCacheInBattle)
		{
			foreach (KeyValuePair<int, TimerHandle> keyValuePair2 in keyValuePair.Value)
			{
				keyValuePair2.Value.Remove();
			}
			keyValuePair.Value.Clear();
		}
		this.TimerCacheInBattle.Clear();
	}

	// Token: 0x060165E6 RID: 91622 RVA: 0x00634044 File Offset: 0x00632244
	[NullableContext(2)]
	public unsafe void TryAddTimerInBattle(TimerHandle handle, int playerId, int roleId)
	{
		if (handle == null)
		{
			return;
		}
		if (!this.TimerCacheInBattle.ContainsKey(playerId))
		{
			this.TimerCacheInBattle[playerId] = new Dictionary<int, TimerHandle>();
		}
		Dictionary<int, TimerHandle> dictionary = this.TimerCacheInBattle[playerId];
		if (dictionary.ContainsKey(roleId))
		{
			dictionary[roleId].Remove();
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.WZ;
			string message = "同一玩家的同一角色已经有timer用于复活倒计时，其将被停止，用新timer取代";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("playerId", playerId);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("roleId", roleId);
			instance.Error(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
		}
		dictionary[roleId] = handle;
	}

	// Token: 0x060165E7 RID: 91623 RVA: 0x00634100 File Offset: 0x00632300
	public void TryRemoveTimerInBattle(int playerId, int? roleId = null)
	{
		Dictionary<int, TimerHandle> dictionary;
		if (!this.TimerCacheInBattle.TryGetValue(playerId, out dictionary))
		{
			return;
		}
		if (roleId == null)
		{
			foreach (KeyValuePair<int, TimerHandle> keyValuePair in dictionary)
			{
				keyValuePair.Value.Remove();
			}
			this.TimerCacheInBattle.Remove(playerId);
			return;
		}
		TimerHandle timerHandle;
		if (!dictionary.TryGetValue(roleId.Value, out timerHandle))
		{
			return;
		}
		timerHandle.Remove();
		dictionary.Remove(roleId.Value);
		if (dictionary.Count == 0)
		{
			this.TimerCacheInBattle.Remove(playerId);
		}
	}

	// Token: 0x060165E8 RID: 91624 RVA: 0x006341B8 File Offset: 0x006323B8
	public bool CheckHasReward()
	{
		return this.CheckHasPassReward() || this.CheckHasScoreReward();
	}

	// Token: 0x060165E9 RID: 91625 RVA: 0x006341CC File Offset: 0x006323CC
	public bool CheckHasScoreReward()
	{
		IEnumerable<TowerDefenceReward> configList = ConfigTowerDefenceRewardAll.GetConfigList(true);
		ParsedTowerDefenseMsg phantomMessageCache = this.PhantomMessageCache;
		foreach (TowerDefenceReward towerDefenceReward in configList)
		{
			if (towerDefenceReward.ActivityId == this.PhantomMessageCache.Id && phantomMessageCache.TotalScore >= towerDefenceReward.Score && !phantomMessageCache.ScoreRewardCache.ContainsKey(towerDefenceReward.Id))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060165EA RID: 91626 RVA: 0x00634258 File Offset: 0x00632458
	public int GetMaxScoreRewardThreshold()
	{
		IReadOnlyList<TowerDefenceReward> configList = ConfigTowerDefenceRewardAll.GetConfigList(true);
		if (configList == null)
		{
			return 0;
		}
		int num = 0;
		foreach (TowerDefenceReward towerDefenceReward in configList)
		{
			if (towerDefenceReward.ActivityId == this.PhantomMessageCache.Id && towerDefenceReward.Score > num)
			{
				num = towerDefenceReward.Score;
			}
		}
		return num;
	}

	// Token: 0x060165EB RID: 91627 RVA: 0x006342D0 File Offset: 0x006324D0
	public bool CheckHasPassReward()
	{
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in this.PhantomMessageCache.StageListCache)
		{
			TowerDefenceInstance? config = ConfigTowerDefenceInstanceById.GetConfig(towerDefenseParsedStageMessage.Id, true);
			if (config == null)
			{
				return false;
			}
			if (config.Value.IsDifficult)
			{
				if (towerDefenseParsedStageMessage.Passed && !towerDefenseParsedStageMessage.Rewarded)
				{
					return true;
				}
			}
			else if (towerDefenseParsedStageMessage.RecordOverThreshold && !towerDefenseParsedStageMessage.Rewarded)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060165EC RID: 91628 RVA: 0x00634378 File Offset: 0x00632578
	public bool CheckHasNewStage()
	{
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in this.PhantomMessageCache.StageListCache)
		{
			if ((double)towerDefenseParsedStageMessage.UnlockTime < serverTimeStamp && !towerDefenseParsedStageMessage.Passed)
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060165ED RID: 91629 RVA: 0x006343F0 File Offset: 0x006325F0
	private bool CheckLevelHasClickByInstanceId(int instanceId)
	{
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TowerDefenseNewLevel, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, bool>();
			LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TowerDefenseNewLevel, dictionary);
			return false;
		}
		bool flag;
		return dictionary.TryGetValue(instanceId, out flag) && flag;
	}

	// Token: 0x060165EE RID: 91630 RVA: 0x00634428 File Offset: 0x00632628
	public bool CheckTowerDefenseInstanceHasRedDot(int instanceId)
	{
		TowerDefenceInstance? towerDefenceInstance;
		int num = (ConfigTowerDefenceInstanceByInstanceId.GetConfig(instanceId, true) != null) ? towerDefenceInstance.GetValueOrDefault().Id : 0;
		return num > 0 && ControllerBase<TowerDefenseController>.Instance.CheckStageUnlockById(num) && !this.CheckLevelHasClickByInstanceId(instanceId);
	}

	// Token: 0x060165EF RID: 91631 RVA: 0x00634478 File Offset: 0x00632678
	public void SetLevelHasClickByInstanceId(int instanceId)
	{
		List<ITowerDefenseParsedStageMessage> stageListCache = this.PhantomMessageCache.StageListCache;
		bool flag = false;
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in stageListCache)
		{
			TowerDefenceInstance? towerDefenceInstance;
			int num = (ConfigTowerDefenceInstanceById.GetConfig(towerDefenseParsedStageMessage.Id, true) != null) ? towerDefenceInstance.GetValueOrDefault().InstanceId : 0;
			if (num != 0 && num == instanceId)
			{
				if (!ModelBase<InstanceDungeonEntranceModel>.Instance.CheckInstanceUnlock(instanceId))
				{
					return;
				}
				flag = true;
				break;
			}
		}
		if (!flag)
		{
			return;
		}
		Dictionary<int, bool> dictionary = LocalStorage.GetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TowerDefenseNewLevel, null);
		if (dictionary == null)
		{
			dictionary = new Dictionary<int, bool>();
		}
		dictionary[instanceId] = true;
		LocalStorage.SetPlayer<Dictionary<int, bool>>(ELocalStoragePlayerKey.TowerDefenseNewLevel, dictionary);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.RefreshCommonActivityRedDot, this.PhantomMessageCache.Id);
		Singleton<EventSystem>.Instance.Emit<int>(EEventName.OnChallengeInstanceRedDot, instanceId);
	}

	// Token: 0x060165F0 RID: 91632 RVA: 0x00634564 File Offset: 0x00632764
	public bool HasNotClickNewLevel()
	{
		if (!this.PhantomMessageCache.GetPreGuideQuestFinishState())
		{
			return false;
		}
		foreach (ITowerDefenseParsedStageMessage towerDefenseParsedStageMessage in this.PhantomMessageCache.StageListCache)
		{
			TowerDefenceInstance? towerDefenceInstance;
			int num = (ConfigTowerDefenceInstanceById.GetConfig(towerDefenseParsedStageMessage.Id, true) != null) ? towerDefenceInstance.GetValueOrDefault().InstanceId : 0;
			if (num != 0 && this.CheckTowerDefenseInstanceHasRedDot(num))
			{
				return true;
			}
		}
		return false;
	}

	// Token: 0x060165F1 RID: 91633 RVA: 0x00634600 File Offset: 0x00632800
	public bool CheckPhantomAvailableInActivityByActivityId(int id)
	{
		return id == this.PhantomMessageCache.Id;
	}

	// Token: 0x060165F2 RID: 91634 RVA: 0x00634610 File Offset: 0x00632810
	public bool CheckCurrentActivityShowDifferent()
	{
		TowerDefenseConfig? currentActivityConfig = this.GetCurrentActivityConfig();
		if (currentActivityConfig == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "塔防活动配置数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", this.PhantomMessageCache.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return false;
		}
		return currentActivityConfig.Value.ShowDifferent;
	}

	// Token: 0x060165F3 RID: 91635 RVA: 0x00634677 File Offset: 0x00632877
	public bool CheckPhantomIsOccupied(int id)
	{
		return false;
	}

	// Token: 0x060165F4 RID: 91636 RVA: 0x0063467C File Offset: 0x0063287C
	[NullableContext(2)]
	public ITowerDefensePhantomDataOwner GetOwnerData(int playerId, int roleCfgId)
	{
		foreach (ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner in this.PhantomOwnerDataList)
		{
			if (towerDefensePhantomDataOwner.PlayerId == (long)playerId && towerDefensePhantomDataOwner.RoleCfgId == roleCfgId)
			{
				return towerDefensePhantomDataOwner;
			}
		}
		return null;
	}

	// Token: 0x060165F5 RID: 91637 RVA: 0x006346E4 File Offset: 0x006328E4
	public List<ITowerDefensePhantomDataOwner> GetOwnerDataListByPlayerId(int playerId)
	{
		List<ITowerDefensePhantomDataOwner> list = new List<ITowerDefensePhantomDataOwner>();
		foreach (ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner in this.PhantomOwnerDataList)
		{
			if (towerDefensePhantomDataOwner.PlayerId == (long)playerId)
			{
				list.Add(towerDefensePhantomDataOwner);
			}
		}
		return list;
	}

	// Token: 0x060165F6 RID: 91638 RVA: 0x00634748 File Offset: 0x00632948
	public bool CheckHasSurvivalPhantom()
	{
		int value = ModelBase<PlayerInfoModel>.Instance.GetId().Value;
		foreach (ITowerDefensePhantomDataOwner towerDefensePhantomDataOwner in this.PhantomOwnerDataList)
		{
			if ((long)value == towerDefensePhantomDataOwner.PlayerId && towerDefensePhantomDataOwner.PhantomId > 0)
			{
				TowerDefencePhantom? config = ConfigTowerDefencePhantomById.GetConfig(towerDefensePhantomDataOwner.PhantomId, true);
				if (config != null && config.Value.IsSurvivalType)
				{
					return true;
				}
			}
		}
		return false;
	}

	// Token: 0x060165F7 RID: 91639 RVA: 0x006347EC File Offset: 0x006329EC
	public TowerDefenseConfig? GetCurrentActivityConfig()
	{
		TowerDefenseConfig? towerDefenseConfigByActivityId = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigByActivityId(this.PhantomMessageCache.Id);
		if (towerDefenseConfigByActivityId == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.TowerDefense;
			ELogAuthor author = ELogAuthor.XXJ;
			string message = "塔防活动配置数据为空";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ActivityId", this.PhantomMessageCache.Id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			return null;
		}
		return towerDefenseConfigByActivityId;
	}

	// Token: 0x060165F8 RID: 91640 RVA: 0x0063485C File Offset: 0x00632A5C
	[NullableContext(2)]
	public Dictionary<int, int> GetSortedByTitleEntranceInstanceIdList()
	{
		List<int> entranceInstanceIdList = ModelBase<InstanceDungeonEntranceModel>.Instance.EntranceInstanceIdList;
		if (entranceInstanceIdList == null)
		{
			return null;
		}
		Dictionary<int, int> dictionary = new Dictionary<int, int>();
		foreach (int num in entranceInstanceIdList)
		{
			dictionary[num] = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseInstanceByInstance(num).Value.GroupId;
		}
		return dictionary;
	}

	// Token: 0x060165F9 RID: 91641 RVA: 0x006348E0 File Offset: 0x00632AE0
	public bool GetInstanceUnlockState(int preConfigId, int configId)
	{
		TowerDefenceInstance? towerDefenseConfigById = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(configId);
		if (!this.PhantomMessageCache.IsStageUnLocked(towerDefenseConfigById.Value.InstanceId))
		{
			return false;
		}
		if (preConfigId != 0)
		{
			TowerDefenceInstance? towerDefenseConfigById2 = ConfigBase<InstanceDungeonConfig>.Instance.GetTowerDefenseConfigById(preConfigId);
			if (!ModelBase<TowerDefenseModel>.Instance.PhantomMessageCache.IsPassedInstance(towerDefenseConfigById2.Value.InstanceId))
			{
				return false;
			}
		}
		return true;
	}

	// Token: 0x060165FA RID: 91642 RVA: 0x00634949 File Offset: 0x00632B49
	protected override bool OnInit()
	{
		this.ParseTowerDefensePhantomCfg();
		this.ResetCurrentPhantomIdInUiTempToFirstAvailable();
		this.ResetPhantomOwnerDataList();
		return true;
	}

	// Token: 0x060165FB RID: 91643 RVA: 0x0063495E File Offset: 0x00632B5E
	protected override bool OnLeaveLevel()
	{
		this.PhantomMessageCache.OwnPhantomInBattleDataCache.Clear();
		return true;
	}

	// Token: 0x060165FC RID: 91644 RVA: 0x00634974 File Offset: 0x00632B74
	private void ParseTowerDefensePhantomCfg()
	{
		IReadOnlyList<TowerDefencePhantom> configList = ConfigTowerDefencePhantomAll.GetConfigList(true);
		if (configList == null)
		{
			return;
		}
		foreach (TowerDefencePhantom towerDefencePhantom in configList)
		{
			List<ITowerDefensePhantomConfigSkillData> list = new List<ITowerDefensePhantomConfigSkillData>();
			IReadOnlyList<TowerDefencePhantomLevel> configList2 = ConfigTowerDefencePhantomLevelByGroupId.GetConfigList(towerDefencePhantom.SkillGroup, true);
			if (configList2 != null)
			{
				foreach (TowerDefencePhantomLevel towerDefencePhantomLevel in configList2)
				{
					ITowerDefensePhantomConfigSkillData item = new TowerDefensePhantomConfigSkillData
					{
						Name = towerDefencePhantomLevel.Title,
						Description = towerDefencePhantomLevel.Description,
						UnlockDescription = towerDefencePhantomLevel.UnlockDescription,
						ExpThreshold = new double?((double)towerDefencePhantomLevel.ExpLevel),
						PhantomSkill = towerDefencePhantomLevel.PhantomSkill
					};
					list.Add(item);
				}
				ITowerDefensePhantomConfig towerDefensePhantomConfig = new TowerDefensePhantomConfig
				{
					Id = towerDefencePhantom.Id,
					PhantomItemId = towerDefencePhantom.PhantomItemId,
					ActivityId = towerDefencePhantom.ActivityId,
					PhantomNameTextId = towerDefencePhantom.PhantomName,
					PhantomTypeTextId = towerDefencePhantom.TypeTextId,
					TypeIconPath = (ConfigBase<UiResourceConfig>.Instance.GetResourcePath(towerDefencePhantom.TypeIcon) ?? ""),
					MarkResourceId = towerDefencePhantom.MarkHex,
					SkillDataList = list,
					MaxLevel = list.Count
				};
				this.PhantomConfigCache[towerDefencePhantom.Id] = towerDefensePhantomConfig;
				this.SortedPhantomConfigCache.Add(towerDefensePhantomConfig);
			}
		}
		this.SortedPhantomConfigCache.Sort(new Comparison<ITowerDefensePhantomConfig>(this.SortCache));
	}

	// Token: 0x060165FD RID: 91645 RVA: 0x00634B48 File Offset: 0x00632D48
	private int SortCache(ITowerDefensePhantomConfig a, ITowerDefensePhantomConfig b)
	{
		return a.Id.CompareTo(b.Id);
	}

	// Token: 0x0400ACF2 RID: 44274
	public int CurrentSelfPhantomIdInUiTemp;

	// Token: 0x0400ACF3 RID: 44275
	[Nullable(2)]
	public TowerDefenceEndNotify DelayedEndNotify;

	// Token: 0x0400ACF4 RID: 44276
	private bool? IsEnterInActivityClickedCache;

	// Token: 0x0400ACF5 RID: 44277
	public bool IsPhantomViewOpened;

	// Token: 0x0400ACF6 RID: 44278
	public bool IsNeedShowMainView;

	// Token: 0x0400ACF7 RID: 44279
	public bool IsUiFlowOpen;

	// Token: 0x0400ACF8 RID: 44280
	public ParsedTowerDefenseMsg PhantomMessageCache = new ParsedTowerDefenseMsg();

	// Token: 0x0400ACF9 RID: 44281
	public List<ITowerDefensePhantomDataOwner> PhantomOwnerDataList = new List<ITowerDefensePhantomDataOwner>();

	// Token: 0x0400ACFA RID: 44282
	public TowerDefenseRankGlobalData RankData = new TowerDefenseRankGlobalData();

	// Token: 0x0400ACFB RID: 44283
	public Dictionary<int, int> RoleCfgId2PhantomIdMapCache = new Dictionary<int, int>();

	// Token: 0x0400ACFC RID: 44284
	public long? SelfReviveTargetTimestampForUi;

	// Token: 0x0400ACFD RID: 44285
	public Dictionary<int, Dictionary<int, TimerHandle>> TimerCacheInBattle = new Dictionary<int, Dictionary<int, TimerHandle>>();
}
