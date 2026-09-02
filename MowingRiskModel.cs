using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Aki.Config;
using Aki.Protocol;
using CSharpScript.Game.Common.Event;
using CSharpScript.Game.Module.Activity.ActivityContent.MowingRisk;
using CSharpScript.Game.Module.InstanceDungeon;
using CSharpScript.Game.Module.Reward;
using CSharpScript.Module.InstanceDungeon;
using Cysharp.Threading.Tasks;
using Google.Protobuf.Collections;

// Token: 0x02001425 RID: 5157
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Model(0)]
public class MowingRiskModel : ModelBase<MowingRiskModel>
{
	// Token: 0x17000BFF RID: 3071
	// (get) Token: 0x06008F09 RID: 36617 RVA: 0x00258A90 File Offset: 0x00256C90
	// (set) Token: 0x06008F0A RID: 36618 RVA: 0x00258A98 File Offset: 0x00256C98
	private MowingRiskConfigContext ConfigContext { get; set; }

	// Token: 0x17000C00 RID: 3072
	// (get) Token: 0x06008F0B RID: 36619 RVA: 0x00258AA1 File Offset: 0x00256CA1
	// (set) Token: 0x06008F0C RID: 36620 RVA: 0x00258AA9 File Offset: 0x00256CA9
	private MowingRiskProtocolContext ProtocolContext { get; set; }

	// Token: 0x17000C01 RID: 3073
	// (get) Token: 0x06008F0D RID: 36621 RVA: 0x00258AB2 File Offset: 0x00256CB2
	// (set) Token: 0x06008F0E RID: 36622 RVA: 0x00258ABA File Offset: 0x00256CBA
	private MowingRiskUiContext UiContext { get; set; }

	// Token: 0x17000C02 RID: 3074
	// (get) Token: 0x06008F0F RID: 36623 RVA: 0x00258AC3 File Offset: 0x00256CC3
	// (set) Token: 0x06008F10 RID: 36624 RVA: 0x00258ACB File Offset: 0x00256CCB
	private bool IsContextInit { get; set; }

	// Token: 0x06008F11 RID: 36625 RVA: 0x00258AD4 File Offset: 0x00256CD4
	public void InitContext()
	{
		if (this.IsContextInit)
		{
			return;
		}
		this.IsContextInit = true;
		this.ConfigContext = new MowingRiskConfigContext();
		this.ProtocolContext = new MowingRiskProtocolContext();
		this.UiContext = new MowingRiskUiContext(this);
	}

	// Token: 0x06008F12 RID: 36626 RVA: 0x00258B08 File Offset: 0x00256D08
	protected override bool OnClear()
	{
		MowingRiskConfigContext configContext = this.ConfigContext;
		if (configContext != null)
		{
			configContext.Dispose();
		}
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext != null)
		{
			protocolContext.Dispose();
		}
		MowingRiskUiContext uiContext = this.UiContext;
		if (uiContext != null)
		{
			uiContext.Dispose();
		}
		return true;
	}

	// Token: 0x06008F13 RID: 36627 RVA: 0x00258B3E File Offset: 0x00256D3E
	public void SyncProtocolRiskHarvestEndNotify(RiskHarvestEndNotify message)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext == null)
		{
			return;
		}
		protocolContext.ParseRiskHarvestEndNotify(message);
	}

	// Token: 0x06008F14 RID: 36628 RVA: 0x00258B51 File Offset: 0x00256D51
	public void SyncProtocolRiskHarvestInstUpdateNotify(RiskHarvestInstUpdateNotify message)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext == null)
		{
			return;
		}
		protocolContext.ParseRiskHarvestInstUpdateNotify(message);
	}

	// Token: 0x06008F15 RID: 36629 RVA: 0x00258B64 File Offset: 0x00256D64
	public void SyncProtocolRiskHarvestArtifactNotify(RiskHarvestArtifactNotify message)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext == null)
		{
			return;
		}
		protocolContext.ParseRiskHarvestArtifactNotify(message);
	}

	// Token: 0x06008F16 RID: 36630 RVA: 0x00258B77 File Offset: 0x00256D77
	public void SyncProtocolRiskHarvestBuffUpdateNotify(RiskHarvestBuffUpdateNotify message)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext != null)
		{
			protocolContext.ParseRiskHarvestBuffUpdateNotify(message);
		}
		MowingRiskUiContext uiContext = this.UiContext;
		if (uiContext == null)
		{
			return;
		}
		uiContext.SyncNewBuff(message.AddBuffGroups.ToList<int>());
	}

	// Token: 0x06008F17 RID: 36631 RVA: 0x00258BA6 File Offset: 0x00256DA6
	public void SyncProtocolRiskHarvestBuffUnlockNotify(RiskHarvestBuffUnlockNotify message)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext == null)
		{
			return;
		}
		protocolContext.ParseRiskHarvestBuffUnlockNotify(message);
	}

	// Token: 0x06008F18 RID: 36632 RVA: 0x00258BB9 File Offset: 0x00256DB9
	public void SyncProtocolRiskHarvestActivityUpdateNotify(RiskHarvestActivityUpdateNotify message)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext == null)
		{
			return;
		}
		protocolContext.ParseRiskHarvestActivityUpdateNotify(message);
	}

	// Token: 0x06008F19 RID: 36633 RVA: 0x00258BCC File Offset: 0x00256DCC
	public void ResetBuffViewCache()
	{
		this.CurrentBuffViewType = EMowingBuffTabViewType.Overview;
		this.CurrentChosenOverviewBuffId = null;
		this.CurrentChosenProgressIndex = null;
	}

	// Token: 0x06008F1A RID: 36634 RVA: 0x00258BFE File Offset: 0x00256DFE
	public void ResetCacheInBattle()
	{
		this.ProtocolContext.ResetCacheInBattle();
		this.UiContext.ResetCacheInBattle();
	}

	// Token: 0x06008F1B RID: 36635 RVA: 0x00258C16 File Offset: 0x00256E16
	public EMowingBuffType? GetBuffTypeByBuffId(int id)
	{
		return this.ConfigContext.GetBuffTypeById(id);
	}

	// Token: 0x06008F1C RID: 36636 RVA: 0x00258C24 File Offset: 0x00256E24
	public RiskHarvestInst GetRiskHarvestInstConfigByInstanceId(int instanceId)
	{
		return ConfigRiskHarvestInstById.GetConfig(this.ConfigContext.GetIdByInstanceId(instanceId).Value, true).Value;
	}

	// Token: 0x06008F1D RID: 36637 RVA: 0x00258C54 File Offset: 0x00256E54
	public RiskHarvestDifficulty GetDifficultyConfigByInstanceId(int instanceId)
	{
		return ConfigRiskHarvestDifficultyById.GetConfig(ConfigRiskHarvestInstById.GetConfig(this.ConfigContext.GetIdByInstanceId(instanceId).Value, true).Value.Difficulty, true).Value;
	}

	// Token: 0x06008F1E RID: 36638 RVA: 0x00258C9C File Offset: 0x00256E9C
	public int GetMonsterRatioByInstanceId(int instanceId)
	{
		return this.GetDifficultyConfigByInstanceId(instanceId).MonsterRatio;
	}

	// Token: 0x06008F1F RID: 36639 RVA: 0x00258CB8 File Offset: 0x00256EB8
	public int GetRecordScoreById(int id)
	{
		return this.ProtocolContext.GetScoreById(id);
	}

	// Token: 0x06008F20 RID: 36640 RVA: 0x00258CC8 File Offset: 0x00256EC8
	public int GetMaxScoreByInstanceId(int instanceId)
	{
		int value = this.ConfigContext.GetIdByInstanceId(instanceId).Value;
		return this.GetMaxScoreById(value);
	}

	// Token: 0x06008F21 RID: 36641 RVA: 0x00258CF4 File Offset: 0x00256EF4
	public int GetMaxScoreById(int id)
	{
		RiskHarvestInst? config = ConfigRiskHarvestInstById.GetConfig(id, true);
		if (config != null)
		{
			return config.Value.MaxScore;
		}
		return 0;
	}

	// Token: 0x06008F22 RID: 36642 RVA: 0x00258D23 File Offset: 0x00256F23
	public float GetProgressOverallPercentage(int artifactId, int count)
	{
		return this.ConfigContext.GetProgressOverallPercentage(artifactId, count);
	}

	// Token: 0x06008F23 RID: 36643 RVA: 0x00258D34 File Offset: 0x00256F34
	public IMowingBuffIntroduceData BuildBuffIntroduceDataInOverviewById(int id)
	{
		MowingRiskConfigContext configContext = this.ConfigContext;
		bool flag = this.ProtocolContext.IsBuffUnlocked(id);
		int? buffCountInBattleById = this.ProtocolContext.GetBuffCountInBattleById(id);
		MowingBuffIntroduceData mowingBuffIntroduceData = new MowingBuffIntroduceData();
		mowingBuffIntroduceData.BackgroundPath = configContext.GetBuffIntroduceBackgroundPath(id);
		mowingBuffIntroduceData.LevelTextId = ((flag && buffCountInBattleById != null) ? "RiskHarvest_LV" : null);
		MowingBuffIntroduceData mowingBuffIntroduceData2 = mowingBuffIntroduceData;
		object levelTextArgs;
		if (!flag || buffCountInBattleById == null)
		{
			levelTextArgs = null;
		}
		else
		{
			(levelTextArgs = new string[1])[0] = buffCountInBattleById.Value.ToString();
		}
		mowingBuffIntroduceData2.LevelTextArgs = levelTextArgs;
		mowingBuffIntroduceData.NameTextId = (flag ? configContext.GetBuffNameTextIdById(id) : "RiskHarvest_TitleUnlock");
		mowingBuffIntroduceData.TipsTextId = (flag ? configContext.GetBuffDescriptionTextIdById(id) : "riskharvest_BuffunlockDesc");
		mowingBuffIntroduceData.TipsArgs = (flag ? configContext.GetBuffDescriptionArgsById(id) : new string[0]);
		mowingBuffIntroduceData.IconPath = (flag ? configContext.GetBuffIconPathById(id) : null);
		mowingBuffIntroduceData.HexColor = configContext.GetBuffHexColorById(id).ToString();
		mowingBuffIntroduceData.IsUnlock = flag;
		return mowingBuffIntroduceData;
	}

	// Token: 0x06008F24 RID: 36644 RVA: 0x00258E3C File Offset: 0x0025703C
	public IMowingBuffIntroduceData BuildBuffIntroduceDataInProgressById(int id)
	{
		MowingRiskConfigContext configContext = this.ConfigContext;
		return new MowingBuffIntroduceData
		{
			BackgroundPath = configContext.GetBuffIntroduceBackgroundPath(id),
			LevelTextId = null,
			LevelTextArgs = null,
			NameTextId = configContext.GetBuffNameTextIdById(id),
			TipsTextId = configContext.GetBuffDescriptionTextIdById(id),
			TipsArgs = configContext.GetBuffDescriptionArgsById(id),
			IconPath = configContext.GetBuffIconPathById(id),
			HexColor = configContext.GetBuffHexColorById(id).ToString(),
			IsUnlock = this.ProtocolContext.IsBuffUnlocked(id)
		};
	}

	// Token: 0x06008F25 RID: 36645 RVA: 0x00258ED4 File Offset: 0x002570D4
	public IMowingBuffGridItemData BuildBuffItemDataById(int id)
	{
		MowingRiskConfigContext configContext = this.ConfigContext;
		bool flag = this.ProtocolContext.IsBuffUnlocked(id);
		MowingBuffGridItemData mowingBuffGridItemData = new MowingBuffGridItemData();
		mowingBuffGridItemData.BuffId = id;
		mowingBuffGridItemData.QualityPath = configContext.GetBuffQualityPathById(id);
		mowingBuffGridItemData.IconPath = (flag ? configContext.GetBuffIconPathById(id) : null);
		mowingBuffGridItemData.NameTextId = (flag ? configContext.GetBuffNameTextIdById(id) : "RiskHarvest_TitleUnlock");
		mowingBuffGridItemData.IsShowBackground = true;
		int? currentChosenOverviewBuffId = this.CurrentChosenOverviewBuffId;
		mowingBuffGridItemData.IsChosen = (id == currentChosenOverviewBuffId.GetValueOrDefault() & currentChosenOverviewBuffId != null);
		mowingBuffGridItemData.IsUnlock = flag;
		mowingBuffGridItemData.LevelContent = this.GetBuffLevelContentById(id);
		return mowingBuffGridItemData;
	}

	// Token: 0x06008F26 RID: 36646 RVA: 0x00258F74 File Offset: 0x00257174
	public IMowingBuffUnitData[] BuildSuperBuffUnitDataListById(int id)
	{
		int artifactBasicBuffTotalCount = this.ProtocolContext.ArtifactBasicBuffTotalCount;
		MowingRiskConfigContext configContext = this.ConfigContext;
		RiskHarvestArtifact artifactConfig = configContext.GetArtifactConfig(id);
		List<IMowingBuffUnitData> list = new List<IMowingBuffUnitData>();
		for (int i = 0; i < artifactConfig.BuffGroupLength; i++)
		{
			int num = artifactConfig.BuffGroup(i);
			int buffThresholdByArtifactIdAndIndex = configContext.GetBuffThresholdByArtifactIdAndIndex(id, i);
			MowingBuffUnitData mowingBuffUnitData = new MowingBuffUnitData();
			mowingBuffUnitData.Index = i;
			mowingBuffUnitData.BuffId = num;
			int num2 = i;
			int? currentChosenProgressIndex = this.CurrentChosenProgressIndex;
			mowingBuffUnitData.IsChosen = (num2 == currentChosenProgressIndex.GetValueOrDefault() & currentChosenProgressIndex != null);
			mowingBuffUnitData.IsActive = (artifactBasicBuffTotalCount >= buffThresholdByArtifactIdAndIndex);
			mowingBuffUnitData.IconPath = configContext.GetBuffIconPathById(i);
			mowingBuffUnitData.NameTextId = configContext.GetBuffNameTextIdById(num);
			mowingBuffUnitData.ThresholdCount = buffThresholdByArtifactIdAndIndex;
			MowingBuffUnitData item = mowingBuffUnitData;
			list.Add(item);
		}
		return list.ToArray();
	}

	// Token: 0x06008F27 RID: 36647 RVA: 0x0025904C File Offset: 0x0025724C
	private IMowingBuffGridItemData[] BuildBuffItemListData(List<RiskHarvestBuffGroup> configList)
	{
		List<IMowingBuffGridItemData> list = new List<IMowingBuffGridItemData>();
		foreach (RiskHarvestBuffGroup riskHarvestBuffGroup in configList)
		{
			list.Add(this.BuildBuffItemDataById(riskHarvestBuffGroup.Id));
		}
		return list.ToArray();
	}

	// Token: 0x06008F28 RID: 36648 RVA: 0x002590B4 File Offset: 0x002572B4
	public IMowingBuffOverviewData BuildOverviewViewData()
	{
		if (this.CurrentChosenOverviewBuffId == null)
		{
			return null;
		}
		List<IMowingBuffGridGroupData> list = new List<IMowingBuffGridGroupData>();
		bool showUnlockText = this.CurrentBuffViewUsage == EMowingBuffViewUsage.BeforeBattle;
		RiskHarvestBuffGroup[] superBuffConfigsAfterSort = this.GetSuperBuffConfigsAfterSort();
		if (superBuffConfigsAfterSort.Length != 0)
		{
			list.Add(new MowingBuffGridGroupData
			{
				GroupNameTextId = "riskharvest_superbuff",
				BuffItemList = this.BuildBuffItemListData(superBuffConfigsAfterSort.ToList<RiskHarvestBuffGroup>()),
				ShowUnlockText = showUnlockText
			});
		}
		RiskHarvestBuffGroup[] basicBuffConfigsAfterSort = this.GetBasicBuffConfigsAfterSort();
		if (basicBuffConfigsAfterSort.Length != 0)
		{
			list.Add(new MowingBuffGridGroupData
			{
				GroupNameTextId = "riskharvest_normalbuff",
				BuffItemList = this.BuildBuffItemListData(basicBuffConfigsAfterSort.ToList<RiskHarvestBuffGroup>()),
				ShowUnlockText = showUnlockText
			});
		}
		return new MowingBuffOverviewData
		{
			IntroduceData = this.BuildBuffIntroduceDataInOverviewById(this.CurrentChosenOverviewBuffId.Value),
			BuffGroupData = list.ToArray()
		};
	}

	// Token: 0x06008F29 RID: 36649 RVA: 0x00259184 File Offset: 0x00257384
	public IMowingBuffProgressData BuildProgressViewData()
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		MowingRiskConfigContext configContext = this.ConfigContext;
		int artifactId = protocolContext.ArtifactId;
		int artifactBasicBuffTotalCount = protocolContext.ArtifactBasicBuffTotalCount;
		int buffMaxCountByArtifactId = configContext.GetBuffMaxCountByArtifactId(artifactId);
		int buffIdByArtifactIdAndIndex = configContext.GetBuffIdByArtifactIdAndIndex(artifactId, this.CurrentChosenProgressIndex.Value);
		return new MowingBuffProgressData
		{
			ArtifactId = artifactId,
			CurBasicBuffCount = artifactBasicBuffTotalCount,
			MaxBasicBuffCount = buffMaxCountByArtifactId,
			CountTextId = "PrefabTextItem_1333511122_Text",
			CountTextArgs = new string[]
			{
				artifactBasicBuffTotalCount.ToString(),
				buffMaxCountByArtifactId.ToString()
			},
			ProgressPercentage = configContext.GetProgressOverallPercentage(artifactId, artifactBasicBuffTotalCount),
			SuperBuffList = this.BuildSuperBuffUnitDataListById(artifactId),
			IntroduceData = this.BuildBuffIntroduceDataInProgressById(buffIdByArtifactIdAndIndex)
		};
	}

	// Token: 0x06008F2A RID: 36650 RVA: 0x00259248 File Offset: 0x00257448
	public IMowingBuffCaptionData BuildCaptionViewData()
	{
		InstanceDungeonEntranceConfig instance = ConfigBase<InstanceDungeonEntranceConfig>.Instance;
		InstanceDungeonEntrance? instanceDungeonEntrance = (instance != null) ? instance.GetConfig(8500) : null;
		return new MowingBuffCaptionData
		{
			TitleTextId = (((instanceDungeonEntrance != null) ? instanceDungeonEntrance.GetValueOrDefault().Name : null) ?? string.Empty),
			IconPath = (((instanceDungeonEntrance != null) ? instanceDungeonEntrance.GetValueOrDefault().TitleSprite : null) ?? string.Empty)
		};
	}

	// Token: 0x06008F2B RID: 36651 RVA: 0x002592D0 File Offset: 0x002574D0
	public IMowingRiskInstanceDetailData BuildInstanceDetailDataByInstanceId(int id)
	{
		InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
		InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(id) : null;
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(id);
		MowingRiskInstanceDetailData mowingRiskInstanceDetailData = new MowingRiskInstanceDetailData();
		mowingRiskInstanceDetailData.TitleTextId = (((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().MapName : null) ?? string.Empty);
		mowingRiskInstanceDetailData.ContentTextId = (((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().DungeonDesc : null) ?? string.Empty);
		MowingRiskInstanceDetailData mowingRiskInstanceDetailData2 = mowingRiskInstanceDetailData;
		IMowingRiskInstanceDetailAttributeItemData[] attributeList = new MowingRiskInstanceDetailAttributeItemData[]
		{
			new MowingRiskInstanceDetailAttributeItemData
			{
				AttributeTextId = ((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().MonsterTips : null)
			}
		};
		mowingRiskInstanceDetailData2.AttributeList = attributeList;
		mowingRiskInstanceDetailData.LockData = ((idByInstanceId != null && this.ProtocolContext.IsInstanceUnlockedById(idByInstanceId.Value)) ? null : this.BuildInstanceLockDataByInstanceId(id));
		return mowingRiskInstanceDetailData;
	}

	// Token: 0x06008F2C RID: 36652 RVA: 0x002593CC File Offset: 0x002575CC
	public IMowingRiskInstanceDetailLockItemData BuildInstanceDetailLockDataByInstanceId(int id)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(id);
		if (idByInstanceId == null || !this.ProtocolContext.IsInstanceUnlockedById(idByInstanceId.Value))
		{
			return this.BuildInstanceLockDataByInstanceId(id);
		}
		return null;
	}

	// Token: 0x06008F2D RID: 36653 RVA: 0x0025940C File Offset: 0x0025760C
	public IMowingRiskInstanceDetailLockItemData BuildInstanceLockDataByInstanceId(int id)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(id);
		MowingRiskInstanceDetailLockItemData mowingRiskInstanceDetailLockItemData = new MowingRiskInstanceDetailLockItemData
		{
			IsUnlock = false
		};
		if (idByInstanceId == null)
		{
			return mowingRiskInstanceDetailLockItemData;
		}
		mowingRiskInstanceDetailLockItemData.LockDescriptionTextId = this.BuildInstanceSubtitleTextIdById(idByInstanceId.Value);
		mowingRiskInstanceDetailLockItemData.LockDescriptionTextArgs = this.BuildInstanceSubtitleTextArgsById(idByInstanceId.Value);
		return mowingRiskInstanceDetailLockItemData;
	}

	// Token: 0x06008F2E RID: 36654 RVA: 0x00259468 File Offset: 0x00257668
	public IMowingRiskInstanceRecommendData BuildInstanceRecommendDataByInstanceId(int id)
	{
		InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
		int recommendLevel = (instance != null) ? instance.GetRecommendLevel(id, ModelBase<WorldLevelModel>.Instance.CurWorldLevel) : 0;
		return new MowingRiskInstanceRecommendData
		{
			TextId = "RecommendLevel",
			TextArgs = new string[]
			{
				recommendLevel.ToString()
			},
			RecommendLevel = recommendLevel
		};
	}

	// Token: 0x06008F2F RID: 36655 RVA: 0x002594C4 File Offset: 0x002576C4
	public string BuildInstanceTotalScore()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(0, 1);
		defaultInterpolatedStringHandler.AppendFormatted<int>(this.ProtocolContext.TotalScore);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x06008F30 RID: 36656 RVA: 0x002594F4 File Offset: 0x002576F4
	public IMowingRiskInBattleBuffData BuildInBattleBuffDataById(int id)
	{
		MowingRiskConfigContext configContext = this.ConfigContext;
		return new MowingRiskInBattleBuffData
		{
			IconPath = configContext.GetBuffIconPathById(id),
			TitleTextId = configContext.GetBuffNameTextIdById(id)
		};
	}

	// Token: 0x06008F31 RID: 36657 RVA: 0x00259528 File Offset: 0x00257728
	public IMowingRiskInBattleRootData BuildInBattleRootData()
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		MowingRiskConfigContext configContext = this.ConfigContext;
		int artifactId = protocolContext.ArtifactId;
		int artifactBasicBuffTotalCount = protocolContext.ArtifactBasicBuffTotalCount;
		return new MowingRiskInBattleRootData
		{
			LevelText = configContext.GetProgressLevel(artifactId, artifactBasicBuffTotalCount).ToString(),
			ProgressPercentage = configContext.GetProgressPartialPercentage(artifactId, artifactBasicBuffTotalCount)
		};
	}

	// Token: 0x06008F32 RID: 36658 RVA: 0x00259578 File Offset: 0x00257778
	public IActivityRewardViewData BuildActivityRewardViewData()
	{
		List<IActivityRewardDataPage> list = new List<IActivityRewardDataPage>();
		IActivityRewardDataPage activityRewardDataPage = this.BuildRewardPageByType(EMowingRiskRewardType.InstanceClear);
		if (activityRewardDataPage != null)
		{
			list.Add(activityRewardDataPage);
		}
		IActivityRewardDataPage activityRewardDataPage2 = this.BuildRewardPageByType(EMowingRiskRewardType.ScoreRecord);
		if (activityRewardDataPage2 != null)
		{
			list.Add(activityRewardDataPage2);
		}
		IActivityRewardDataPage activityRewardDataPage3 = this.BuildRewardPageByType(EMowingRiskRewardType.Star);
		if (activityRewardDataPage3 != null)
		{
			list.Add(activityRewardDataPage3);
		}
		return new ActivityRewardViewData
		{
			DataPageList = list.ToList<IActivityRewardDataPage>(),
			Source = EActivityRewardSource.MowingRisk
		};
	}

	// Token: 0x06008F33 RID: 36659 RVA: 0x002595E0 File Offset: 0x002577E0
	public IMowingRiskNewBasicBuffTipsData BuildNewBuffTipsDataById(int id)
	{
		MowingRiskConfigContext configContext = this.ConfigContext;
		return new MowingRiskNewBasicBuffTipsData
		{
			IsGolden = configContext.IsNewBuffGoldenById(id),
			NameTextId = configContext.GetBuffNameTextIdById(id),
			NameHexColor = configContext.GetNewBuffNameHexColorById(id),
			IconPath = configContext.GetBuffIconPathById(id),
			DescriptionTextId = configContext.GetBuffDescriptionTextIdById(id),
			DescriptionArgs = configContext.GetBuffDescriptionArgsById(id),
			QualityTexPath = configContext.GetNewBuffQualityTexPathById(id),
			QualityFlowPath = configContext.GetNewBuffQualityFlowTexPathById(id)
		};
	}

	// Token: 0x06008F34 RID: 36660 RVA: 0x00259664 File Offset: 0x00257864
	[NullableContext(2)]
	public string BuildInstanceSubtitleTextIdByInstanceId(int id)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(id);
		if (idByInstanceId == null)
		{
			return null;
		}
		return this.BuildInstanceSubtitleTextIdById(idByInstanceId.Value);
	}

	// Token: 0x06008F35 RID: 36661 RVA: 0x00259698 File Offset: 0x00257898
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] BuildInstanceSubtitleTextArgsByInstanceId(int id)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(id);
		if (idByInstanceId == null)
		{
			return null;
		}
		return this.BuildInstanceSubtitleTextArgsById(idByInstanceId.Value);
	}

	// Token: 0x06008F36 RID: 36662 RVA: 0x002596CC File Offset: 0x002578CC
	public bool CheckInstanceFinishedByInstanceId(int instanceId)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(instanceId);
		if (idByInstanceId == null)
		{
			return false;
		}
		if (this.ProtocolContext.IsInstanceUnlockedById(idByInstanceId.Value))
		{
			int scoreById = this.ProtocolContext.GetScoreById(idByInstanceId.Value);
			int maxScoreById = this.GetMaxScoreById(idByInstanceId.Value);
			return scoreById >= maxScoreById;
		}
		return false;
	}

	// Token: 0x06008F37 RID: 36663 RVA: 0x0025972D File Offset: 0x0025792D
	public bool IsSuperBuffById(int id)
	{
		return this.ConfigContext.IsSuperBuffByBuffId(id);
	}

	// Token: 0x06008F38 RID: 36664 RVA: 0x0025973C File Offset: 0x0025793C
	public bool IsBuffGottenInBattleById(int id)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		MowingRiskConfigContext configContext = this.ConfigContext;
		return protocolContext.BasicBuffInfoInBattle.ContainsKey(id) || (configContext.IsSuperBuffByBuffId(id) && this.ConfigContext.IsSuperBuffAvailable(protocolContext.ArtifactId, id, protocolContext.ArtifactBasicBuffTotalCount));
	}

	// Token: 0x06008F39 RID: 36665 RVA: 0x0025978C File Offset: 0x0025798C
	public List<RiskHarvestBuffGroup> GetBasicBuffConfigListInBattle()
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		MowingRiskConfigContext configContext = this.ConfigContext;
		List<RiskHarvestBuffGroup> list = new List<RiskHarvestBuffGroup>();
		foreach (int id in protocolContext.BasicBuffInfoInBattle.Keys)
		{
			RiskHarvestBuffGroup? buffConfigById = configContext.GetBuffConfigById(id);
			if (buffConfigById != null)
			{
				list.Add(buffConfigById.Value);
			}
		}
		return list;
	}

	// Token: 0x06008F3A RID: 36666 RVA: 0x00259810 File Offset: 0x00257A10
	public List<RiskHarvestBuffGroup> GetSuperBuffConfigListInBattle()
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		MowingRiskConfigContext configContext = this.ConfigContext;
		List<RiskHarvestBuffGroup> list = new List<RiskHarvestBuffGroup>();
		RiskHarvestArtifact artifactConfig = configContext.GetArtifactConfig(protocolContext.ArtifactId);
		int artifactBasicBuffTotalCount = protocolContext.ArtifactBasicBuffTotalCount;
		for (int i = 0; i < artifactConfig.BuffGroupLength; i++)
		{
			int id = artifactConfig.BuffGroup(i);
			int num = artifactConfig.BasicBuffGroup(i);
			if (artifactBasicBuffTotalCount >= num)
			{
				RiskHarvestBuffGroup? buffConfigById = configContext.GetBuffConfigById(id);
				if (buffConfigById != null)
				{
					list.Add(buffConfigById.Value);
				}
			}
		}
		return list;
	}

	// Token: 0x06008F3B RID: 36667 RVA: 0x00259899 File Offset: 0x00257A99
	public IReadOnlyList<RiskHarvestBuffGroup> GetBuffConfigList()
	{
		return this.ConfigContext.GetBuffConfigListByActivityId(this.ProtocolContext.Id);
	}

	// Token: 0x06008F3C RID: 36668 RVA: 0x002598B4 File Offset: 0x00257AB4
	public List<RiskHarvestBuffGroup> GetBasicBuffConfigListBeforeBattle()
	{
		IEnumerable<RiskHarvestBuffGroup> buffConfigList = this.GetBuffConfigList();
		List<RiskHarvestBuffGroup> list = new List<RiskHarvestBuffGroup>();
		foreach (RiskHarvestBuffGroup item in buffConfigList)
		{
			if (item.BuffProgress > 0)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06008F3D RID: 36669 RVA: 0x00259914 File Offset: 0x00257B14
	public List<RiskHarvestBuffGroup> GetSuperBuffConfigListBeforeBattle()
	{
		IEnumerable<RiskHarvestBuffGroup> buffConfigList = this.GetBuffConfigList();
		List<RiskHarvestBuffGroup> list = new List<RiskHarvestBuffGroup>();
		foreach (RiskHarvestBuffGroup item in buffConfigList)
		{
			if (item.BuffProgress == 0)
			{
				list.Add(item);
			}
		}
		return list;
	}

	// Token: 0x06008F3E RID: 36670 RVA: 0x00259974 File Offset: 0x00257B74
	public bool IsBuffAvailableInActivity(RiskHarvestBuffGroup buffCfg)
	{
		return this.ProtocolContext.Id == buffCfg.ActivityId;
	}

	// Token: 0x06008F3F RID: 36671 RVA: 0x0025998C File Offset: 0x00257B8C
	public bool IsInstanceUnlockedByInstanceId(int instanceId)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(instanceId);
		return idByInstanceId != null && this.ProtocolContext.IsInstanceUnlockedById(idByInstanceId.Value);
	}

	// Token: 0x06008F40 RID: 36672 RVA: 0x002599C4 File Offset: 0x00257BC4
	public bool IsInstanceNewById(int id)
	{
		bool flag;
		return this.ConfigContext.IsInstanceNewCache.TryGetValue(id, out flag) && flag;
	}

	// Token: 0x06008F41 RID: 36673 RVA: 0x002599E8 File Offset: 0x00257BE8
	public void SetInstanceOldById(int id)
	{
		Dictionary<int, bool> isInstanceNewCache = this.ConfigContext.IsInstanceNewCache;
		isInstanceNewCache[id] = false;
		this.ConfigContext.IsInstanceNewCache = isInstanceNewCache;
	}

	// Token: 0x06008F42 RID: 36674 RVA: 0x00259A18 File Offset: 0x00257C18
	public void SetCurrentInstancesOld()
	{
		Dictionary<int, RiskHarvestInstInfo> instanceInfo = this.ProtocolContext.InstanceInfo;
		Dictionary<int, bool> isInstanceNewCache = this.ConfigContext.IsInstanceNewCache;
		foreach (int num in instanceInfo.Keys)
		{
			if (this.ProtocolContext.IsInstancePassUnlockTimeById(num))
			{
				isInstanceNewCache[num] = false;
			}
		}
		this.ConfigContext.IsInstanceNewCache = isInstanceNewCache;
	}

	// Token: 0x06008F43 RID: 36675 RVA: 0x00259A9C File Offset: 0x00257C9C
	public void RecordBuffId(int buffId)
	{
		this.ProtocolContext.RecordBuffId(buffId);
	}

	// Token: 0x06008F44 RID: 36676 RVA: 0x00259AAA File Offset: 0x00257CAA
	public HashSet<int> GetRecordBuffIdSet()
	{
		return this.ProtocolContext.GetRecordBuffIdSet();
	}

	// Token: 0x06008F45 RID: 36677 RVA: 0x00259AB7 File Offset: 0x00257CB7
	public bool HasBuffIdRecord(int buffId)
	{
		return this.GetRecordBuffIdSet().Contains(buffId);
	}

	// Token: 0x06008F46 RID: 36678 RVA: 0x00259AC5 File Offset: 0x00257CC5
	public void RecordProgressPanelBasicBuffCount(int superBuffCount)
	{
		this.ProtocolContext.RecordProgressPanelBasicBuffCount(superBuffCount);
	}

	// Token: 0x06008F47 RID: 36679 RVA: 0x00259AD3 File Offset: 0x00257CD3
	public int GetProgressPanelBasicBuffCountRecord()
	{
		return this.ProtocolContext.GetProgressPanelBasicBuffCountRecord();
	}

	// Token: 0x06008F48 RID: 36680 RVA: 0x00259AE0 File Offset: 0x00257CE0
	private IActivityRewardDataPage BuildRewardPageByType(EMowingRiskRewardType type)
	{
		IActivityRewardData[] array = this.BuildRewardDataListByType(type);
		if (array == null || array.Length == 0)
		{
			return null;
		}
		return new ActivityRewardDataPage
		{
			TabName = this.GetRewardTabNameByType(type),
			TabTips = ((type == EMowingRiskRewardType.ScoreRecord) ? this.GetRewardTabTipsByType() : null),
			DataList = array.ToList<IActivityRewardData>()
		};
	}

	// Token: 0x06008F49 RID: 36681 RVA: 0x00259B2F File Offset: 0x00257D2F
	private IActivityRewardData[] BuildRewardDataListByType(EMowingRiskRewardType type)
	{
		switch (type)
		{
		case EMowingRiskRewardType.InstanceClear:
			return this.BuildRewardDataListOfInstanceClear();
		case EMowingRiskRewardType.ScoreRecord:
			return this.BuildRewardDataListOfScoreRecord();
		case EMowingRiskRewardType.Star:
			return this.BuildRewardDataListOfStar();
		default:
			return new IActivityRewardData[0];
		}
	}

	// Token: 0x06008F4A RID: 36682 RVA: 0x00259B60 File Offset: 0x00257D60
	private IActivityRewardData[] BuildRewardDataListOfInstanceClear()
	{
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		using (IEnumerator<RiskHarvestInst> enumerator = this.ConfigContext.GetRiskHarvestInstByActivityId(this.ProtocolContext.Id).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RiskHarvestInst instCfg = enumerator.Current;
				EActivityRewardState rewardStateByRiskHarvestInst = this.GetRewardStateByRiskHarvestInst(instCfg);
				ActivityRewardData activityRewardData = new ActivityRewardData();
				activityRewardData.NameText = string.Empty;
				activityRewardData.NameTextId = instCfg.Desc;
				CSharpScript.Game.Module.Reward.RewardConfig instance = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance;
				activityRewardData.RewardList = ((instance != null) ? instance.GetDropPackagePreviewItemList(instCfg.Reward).ToArray() : null);
				activityRewardData.RewardState = rewardStateByRiskHarvestInst;
				activityRewardData.RewardButtonText = this.GetPreviewButtonTextByState(rewardStateByRiskHarvestInst);
				activityRewardData.RewardButtonRedDot = new bool?(rewardStateByRiskHarvestInst == EActivityRewardState.Enable);
				activityRewardData.ClickFunction = delegate()
				{
					ControllerBase<ActivityMowingRiskController>.Instance.RequestRiskHarvestInstRewardRequest(instCfg.Id).ContinueWith(new Action(this.HandleRewardResponseFulfill));
				};
				ActivityRewardData item = activityRewardData;
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06008F4B RID: 36683 RVA: 0x00259C70 File Offset: 0x00257E70
	private IActivityRewardData[] BuildRewardDataListOfScoreRecord()
	{
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		using (IEnumerator<RiskHarvestScoreReward> enumerator = this.ConfigContext.GetRiskHarvestScoreRewardByActivityId(this.ProtocolContext.Id).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RiskHarvestScoreReward scoreCfg = enumerator.Current;
				EActivityRewardState rewardStateByRiskHarvestScoreReward = this.GetRewardStateByRiskHarvestScoreReward(scoreCfg);
				ActivityRewardData activityRewardData = new ActivityRewardData();
				activityRewardData.NameText = string.Empty;
				activityRewardData.NameTextId = scoreCfg.Desc;
				CSharpScript.Game.Module.Reward.RewardConfig instance = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance;
				activityRewardData.RewardList = ((instance != null) ? instance.GetDropPackagePreviewItemList(scoreCfg.Reward).ToArray() : null);
				activityRewardData.RewardState = rewardStateByRiskHarvestScoreReward;
				activityRewardData.RewardButtonText = this.GetPreviewButtonTextByState(rewardStateByRiskHarvestScoreReward);
				activityRewardData.RewardButtonRedDot = new bool?(rewardStateByRiskHarvestScoreReward == EActivityRewardState.Enable);
				activityRewardData.ClickFunction = delegate()
				{
					ControllerBase<ActivityMowingRiskController>.Instance.RequestRiskHarvestScoreRewardRequest(scoreCfg.Id).ContinueWith(new Action(this.HandleRewardResponseFulfill));
				};
				ActivityRewardData item = activityRewardData;
				list.Add(item);
			}
		}
		return list.ToArray();
	}

	// Token: 0x06008F4C RID: 36684 RVA: 0x00259D80 File Offset: 0x00257F80
	private IActivityRewardData[] BuildRewardDataListOfStar()
	{
		List<IActivityRewardData> list = new List<IActivityRewardData>();
		using (IEnumerator<RiskHarvestInst> enumerator = this.ConfigContext.GetRiskHarvestInstByActivityId(this.ProtocolContext.Id).GetEnumerator())
		{
			while (enumerator.MoveNext())
			{
				RiskHarvestInst instCfg = enumerator.Current;
				IntPair[] array = instCfg.StarRewardList();
				int num = array.Length;
				int index2;
				int index;
				Action <>9__0;
				for (index = 0; index < num; index = index2 + 1)
				{
					IntPair intPair = array[index];
					InstanceDungeonConfig instance = ConfigBase<InstanceDungeonConfig>.Instance;
					InstanceDungeon? instanceDungeon = (instance != null) ? instance.GetConfig(instCfg.InstanceID) : null;
					EActivityRewardState rewardStateByRiskHarvestStarReward = this.GetRewardStateByRiskHarvestStarReward(instCfg, index);
					ActivityRewardData activityRewardData = new ActivityRewardData();
					activityRewardData.NameText = string.Empty;
					activityRewardData.NameTextId = instCfg.StarRewardDesc;
					activityRewardData.NameTextArgs = new string[]
					{
						ConfigMultiTextLang.GetLocalTextNew((instanceDungeon != null) ? instanceDungeon.GetValueOrDefault().MapName : null, null) ?? string.Empty,
						this.GetStarRewardTargetScore(instCfg, index).ToString()
					};
					ActivityRewardData activityRewardData2 = activityRewardData;
					CSharpScript.Game.Module.Reward.RewardConfig instance2 = ConfigBase<CSharpScript.Game.Module.Reward.RewardConfig>.Instance;
					activityRewardData2.RewardList = ((instance2 != null) ? instance2.GetDropPackagePreviewItemList(intPair.Item2).ToArray() : null);
					activityRewardData.RewardState = rewardStateByRiskHarvestStarReward;
					activityRewardData.RewardButtonText = this.GetPreviewButtonTextByState(rewardStateByRiskHarvestStarReward);
					activityRewardData.RewardButtonRedDot = new bool?(rewardStateByRiskHarvestStarReward == EActivityRewardState.Enable);
					ActivityRewardData activityRewardData3 = activityRewardData;
					Action clickFunction;
					if ((clickFunction = <>9__0) == null)
					{
						clickFunction = (<>9__0 = delegate()
						{
							ControllerBase<ActivityMowingRiskController>.Instance.RequestRiskHarvestStarRewardRequest(instCfg.Id, index).ContinueWith(new Action(this.HandleRewardResponseFulfill));
						});
					}
					activityRewardData3.ClickFunction = clickFunction;
					ActivityRewardData item = activityRewardData;
					list.Add(item);
					index2 = index;
				}
			}
		}
		return list.ToArray();
	}

	// Token: 0x06008F4D RID: 36685 RVA: 0x00259F8C File Offset: 0x0025818C
	[NullableContext(0)]
	public ValueTuple<int, int> GetRewardCount()
	{
		int num = 0;
		int num2 = 0;
		foreach (RiskHarvestInst cfg in this.ConfigContext.GetRiskHarvestInstByActivityId(this.ProtocolContext.Id))
		{
			if (this.GetRewardStateByRiskHarvestInst(cfg) == EActivityRewardState.Claimed)
			{
				num++;
			}
			num2++;
			int num3 = cfg.StarRewardList().Length;
			for (int i = 0; i < num3; i++)
			{
				if (this.GetRewardStateByRiskHarvestStarReward(cfg, i) == EActivityRewardState.Claimed)
				{
					num++;
				}
			}
			num2 += num3;
		}
		foreach (RiskHarvestScoreReward cfg2 in this.ConfigContext.GetRiskHarvestScoreRewardByActivityId(this.ProtocolContext.Id))
		{
			if (this.GetRewardStateByRiskHarvestScoreReward(cfg2) == EActivityRewardState.Claimed)
			{
				num++;
			}
			num2++;
		}
		return new ValueTuple<int, int>(num, num2);
	}

	// Token: 0x06008F4E RID: 36686 RVA: 0x0025A090 File Offset: 0x00258290
	private EActivityRewardState GetRewardStateByRiskHarvestInst(RiskHarvestInst cfg)
	{
		RiskHarvestInstInfo riskHarvestInstInfo;
		if (!this.ProtocolContext.InstanceInfo.TryGetValue(cfg.Id, out riskHarvestInstInfo))
		{
			return EActivityRewardState.Disabled;
		}
		if (!riskHarvestInstInfo.IsUnlock || riskHarvestInstInfo.Score < cfg.RewardScore)
		{
			return EActivityRewardState.Disabled;
		}
		if (riskHarvestInstInfo.Rewarded)
		{
			return EActivityRewardState.Claimed;
		}
		return EActivityRewardState.Enable;
	}

	// Token: 0x06008F4F RID: 36687 RVA: 0x0025A0E0 File Offset: 0x002582E0
	private EActivityRewardState GetRewardStateByRiskHarvestStarReward(RiskHarvestInst cfg, int index)
	{
		RiskHarvestInstInfo riskHarvestInstInfo;
		if (!this.ProtocolContext.InstanceInfo.TryGetValue(cfg.Id, out riskHarvestInstInfo))
		{
			return EActivityRewardState.Disabled;
		}
		if (!riskHarvestInstInfo.IsUnlock)
		{
			return EActivityRewardState.Disabled;
		}
		RepeatedField<RiskHarvestStarRewardInfo> starRewardInfos = riskHarvestInstInfo.StarRewardInfos;
		if (starRewardInfos == null || index < 0 || index >= starRewardInfos.Count)
		{
			return EActivityRewardState.Disabled;
		}
		RiskHarvestStarRewardInfo riskHarvestStarRewardInfo = starRewardInfos[index];
		int targetScore = riskHarvestStarRewardInfo.TargetScore;
		if (riskHarvestInstInfo.Score < targetScore)
		{
			return EActivityRewardState.Disabled;
		}
		if (riskHarvestStarRewardInfo.StarRewardStates == StarRewardState.RiskHarvestRewarded)
		{
			return EActivityRewardState.Claimed;
		}
		return EActivityRewardState.Enable;
	}

	// Token: 0x06008F50 RID: 36688 RVA: 0x0025A154 File Offset: 0x00258354
	private EActivityRewardState GetRewardStateByRiskHarvestScoreReward(RiskHarvestScoreReward cfg)
	{
		MowingRiskProtocolContext protocolContext = this.ProtocolContext;
		if (protocolContext.TotalScore < cfg.Score)
		{
			return EActivityRewardState.Disabled;
		}
		if (protocolContext.HasScoreRewarded(cfg.Id))
		{
			return EActivityRewardState.Claimed;
		}
		return EActivityRewardState.Enable;
	}

	// Token: 0x06008F51 RID: 36689 RVA: 0x0025A18C File Offset: 0x0025838C
	private int GetStarRewardTargetScore(RiskHarvestInst cfg, int index)
	{
		RiskHarvestInstInfo riskHarvestInstInfo;
		if (!this.ProtocolContext.InstanceInfo.TryGetValue(cfg.Id, out riskHarvestInstInfo))
		{
			return 0;
		}
		RepeatedField<RiskHarvestStarRewardInfo> starRewardInfos = riskHarvestInstInfo.StarRewardInfos;
		if (starRewardInfos == null || index < 0 || index >= starRewardInfos.Count)
		{
			return 0;
		}
		return starRewardInfos[index].TargetScore;
	}

	// Token: 0x06008F52 RID: 36690 RVA: 0x0025A1DC File Offset: 0x002583DC
	private string GetPreviewButtonTextByState(EActivityRewardState state)
	{
		switch (state)
		{
		case EActivityRewardState.Disabled:
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefence_Getbt3", null) ?? string.Empty;
		case EActivityRewardState.Enable:
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefence_Getbt1", null) ?? string.Empty;
		case EActivityRewardState.Claimed:
			return ConfigMultiTextLang.GetLocalTextNew("TowerDefence_Getbt1", null) ?? string.Empty;
		default:
			return string.Empty;
		}
	}

	// Token: 0x06008F53 RID: 36691 RVA: 0x0025A244 File Offset: 0x00258444
	private string GetRewardTabNameByType(EMowingRiskRewardType type)
	{
		switch (type)
		{
		case EMowingRiskRewardType.InstanceClear:
			return ConfigBase<TextConfig>.Instance.GetTextById("BossRushLevelRewardText") ?? string.Empty;
		case EMowingRiskRewardType.ScoreRecord:
			return ConfigBase<TextConfig>.Instance.GetTextById("RiskHarvest_PointTap") ?? string.Empty;
		case EMowingRiskRewardType.Star:
			return ConfigMultiTextLang.GetLocalTextNew("RiskHarvest_StarRewardTap", null) ?? string.Empty;
		default:
			return string.Empty;
		}
	}

	// Token: 0x06008F54 RID: 36692 RVA: 0x0025A2B4 File Offset: 0x002584B4
	private string GetRewardTabTipsByType()
	{
		return StringUtils.Format(ConfigMultiTextLang.GetLocalTextNew("RiskHarvest_InstanceToppoint", null), new string[]
		{
			this.ProtocolContext.TotalScore.ToString()
		});
	}

	// Token: 0x06008F55 RID: 36693 RVA: 0x0025A2F0 File Offset: 0x002584F0
	private string GetBuffLevelContentById(int id)
	{
		int? buffCountInBattleById = this.ProtocolContext.GetBuffCountInBattleById(id);
		if (buffCountInBattleById == null)
		{
			return null;
		}
		return StringUtils.Format(ConfigBase<TextConfig>.Instance.GetTextById("OverSeaServerLv"), new string[]
		{
			buffCountInBattleById.Value.ToString()
		});
	}

	// Token: 0x06008F56 RID: 36694 RVA: 0x0025A341 File Offset: 0x00258541
	private string BuildInstanceSubtitleTextIdById(int id)
	{
		if (this.ProtocolContext.IsInstanceUnlockedById(id))
		{
			return this.GetInstanceUnlockTextIdById(id);
		}
		return this.GetInstanceLockTextIdById(id);
	}

	// Token: 0x06008F57 RID: 36695 RVA: 0x0025A360 File Offset: 0x00258560
	public string GetInstanceUnlockTextIdById(int id)
	{
		if (!ConfigRiskHarvestInstById.GetConfig(id, true).Value.Accumulate)
		{
			return "RiskHarvest_InstanceToppoint";
		}
		return "RiskHarvest_TotleScore";
	}

	// Token: 0x06008F58 RID: 36696 RVA: 0x0025A394 File Offset: 0x00258594
	public string GetInstanceLockTextIdByInstanceId(int instanceId)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(instanceId);
		if (idByInstanceId == null)
		{
			return string.Empty;
		}
		return this.GetInstanceLockTextIdById(idByInstanceId.Value);
	}

	// Token: 0x06008F59 RID: 36697 RVA: 0x0025A3CA File Offset: 0x002585CA
	public string GetInstanceLockTextIdById(int id)
	{
		if (!this.ProtocolContext.IsInstancePassUnlockTimeById(id))
		{
			return "Text_ActiveToOpenTime_Text";
		}
		return "RiskHarvest_Unlock";
	}

	// Token: 0x06008F5A RID: 36698 RVA: 0x0025A3E8 File Offset: 0x002585E8
	private string[] BuildInstanceSubtitleTextArgsById(int id)
	{
		if (this.ProtocolContext.IsInstanceUnlockedById(id))
		{
			return new string[]
			{
				this.ProtocolContext.GetScoreById(id).ToString()
			};
		}
		return this.GetLockTextArgsById(id);
	}

	// Token: 0x06008F5B RID: 36699 RVA: 0x0025A428 File Offset: 0x00258628
	public string[] GetLockTextArgsById(int id)
	{
		List<string> list = new List<string>();
		double instanceUnlockTimestampById = this.ProtocolContext.GetInstanceUnlockTimestampById(id);
		double serverTimeStamp = Singleton<TimeUtil>.Instance.GetServerTimeStamp();
		if (instanceUnlockTimestampById > serverTimeStamp)
		{
			double num = instanceUnlockTimestampById - serverTimeStamp;
			CommonDefine.ICountDown remainTimeDataFormat = Singleton<TimeUtil>.Instance.GetRemainTimeDataFormat(num * Singleton<TimeUtil>.Instance.Millisecond);
			list.Add(remainTimeDataFormat.CountDownText ?? string.Empty);
			return list.ToArray();
		}
		list.Add(this.ConfigContext.GetScoreToUnlockById(id).ToString());
		return list.ToArray();
	}

	// Token: 0x06008F5C RID: 36700 RVA: 0x0025A4B4 File Offset: 0x002586B4
	[return: Nullable(new byte[]
	{
		2,
		1
	})]
	public string[] GetLockTextArgsByInstanceId(int instanceId)
	{
		int? idByInstanceId = this.ConfigContext.GetIdByInstanceId(instanceId);
		if (idByInstanceId == null)
		{
			return null;
		}
		return this.GetLockTextArgsById(idByInstanceId.Value);
	}

	// Token: 0x06008F5D RID: 36701 RVA: 0x0025A4E6 File Offset: 0x002586E6
	private void HandleRewardResponseFulfill()
	{
		Singleton<EventSystem>.Instance.Emit<IActivityRewardViewData>(EEventName.RefreshCommonActivityRewardPopUpView, this.BuildActivityRewardViewData());
	}

	// Token: 0x17000C03 RID: 3075
	// (get) Token: 0x06008F5E RID: 36702 RVA: 0x0025A4FE File Offset: 0x002586FE
	public ActivityBaseData ActivityData
	{
		get
		{
			return this.ProtocolContext;
		}
	}

	// Token: 0x17000C04 RID: 3076
	// (get) Token: 0x06008F5F RID: 36703 RVA: 0x0025A506 File Offset: 0x00258706
	// (set) Token: 0x06008F60 RID: 36704 RVA: 0x0025A513 File Offset: 0x00258713
	public EMowingBuffViewUsage CurrentBuffViewUsage
	{
		get
		{
			return this.UiContext.CurrentBuffViewUsage;
		}
		set
		{
			this.UiContext.CurrentBuffViewUsage = value;
		}
	}

	// Token: 0x17000C05 RID: 3077
	// (get) Token: 0x06008F61 RID: 36705 RVA: 0x0025A521 File Offset: 0x00258721
	// (set) Token: 0x06008F62 RID: 36706 RVA: 0x0025A52E File Offset: 0x0025872E
	public EMowingBuffTabViewType CurrentBuffViewType
	{
		get
		{
			return this.UiContext.CurrentBuffViewType;
		}
		set
		{
			this.UiContext.CurrentBuffViewType = value;
		}
	}

	// Token: 0x17000C06 RID: 3078
	// (get) Token: 0x06008F63 RID: 36707 RVA: 0x0025A53C File Offset: 0x0025873C
	// (set) Token: 0x06008F64 RID: 36708 RVA: 0x0025A572 File Offset: 0x00258772
	public int? CurrentChosenOverviewBuffId
	{
		get
		{
			int? num = this.UiContext.CurrentChosenOverviewBuffId;
			if (num == null)
			{
				num = this.GetDefaultChosenOverviewBuffId();
				this.UiContext.CurrentChosenOverviewBuffId = num;
			}
			return num;
		}
		set
		{
			this.UiContext.CurrentChosenOverviewBuffId = value;
		}
	}

	// Token: 0x06008F65 RID: 36709 RVA: 0x0025A580 File Offset: 0x00258780
	public int? GetDefaultChosenOverviewBuffId()
	{
		List<RiskHarvestBuffGroup> basicBuffConfigListBeforeBattle = this.GetBasicBuffConfigListBeforeBattle();
		if (basicBuffConfigListBeforeBattle != null && basicBuffConfigListBeforeBattle.Count > 0)
		{
			return new int?(this.FindBuffConfigsFirstId(basicBuffConfigListBeforeBattle));
		}
		RiskHarvestBuffGroup[] superBuffConfigsAfterSort = this.GetSuperBuffConfigsAfterSort();
		return new int?(this.FindBuffConfigsFirstId(superBuffConfigsAfterSort.ToList<RiskHarvestBuffGroup>()));
	}

	// Token: 0x06008F66 RID: 36710 RVA: 0x0025A5C5 File Offset: 0x002587C5
	public RiskHarvestBuffGroup[] GetBasicBuffConfigsAfterSort()
	{
		List<RiskHarvestBuffGroup> list = (this.CurrentBuffViewUsage == EMowingBuffViewUsage.InBattle) ? this.GetBasicBuffConfigListInBattle() : this.GetBasicBuffConfigListBeforeBattle();
		list.Sort(new Comparison<RiskHarvestBuffGroup>(this.HandleCompareBuff));
		return list.ToArray();
	}

	// Token: 0x06008F67 RID: 36711 RVA: 0x0025A5F7 File Offset: 0x002587F7
	public RiskHarvestBuffGroup[] GetSuperBuffConfigsAfterSort()
	{
		List<RiskHarvestBuffGroup> list = (this.CurrentBuffViewUsage == EMowingBuffViewUsage.InBattle) ? this.GetSuperBuffConfigListInBattle() : this.GetSuperBuffConfigListBeforeBattle();
		list.Sort(new Comparison<RiskHarvestBuffGroup>(this.HandleCompareBuff));
		return list.ToArray();
	}

	// Token: 0x06008F68 RID: 36712 RVA: 0x0025A629 File Offset: 0x00258829
	private int HandleCompareBuff(RiskHarvestBuffGroup a, RiskHarvestBuffGroup b)
	{
		if (a.BuffType == b.BuffType)
		{
			return a.Id - b.Id;
		}
		return b.BuffType - a.BuffType;
	}

	// Token: 0x06008F69 RID: 36713 RVA: 0x0025A65C File Offset: 0x0025885C
	private int FindBuffConfigsFirstId(List<RiskHarvestBuffGroup> configList)
	{
		if (configList.Count == 0)
		{
			return 0;
		}
		RiskHarvestBuffGroup riskHarvestBuffGroup = configList[0];
		foreach (RiskHarvestBuffGroup riskHarvestBuffGroup2 in configList)
		{
			if (riskHarvestBuffGroup2.BuffType > riskHarvestBuffGroup.BuffType)
			{
				riskHarvestBuffGroup = riskHarvestBuffGroup2;
			}
			else if (riskHarvestBuffGroup2.BuffType == riskHarvestBuffGroup.BuffType && riskHarvestBuffGroup2.Id < riskHarvestBuffGroup.Id)
			{
				riskHarvestBuffGroup = riskHarvestBuffGroup2;
			}
		}
		return riskHarvestBuffGroup.Id;
	}

	// Token: 0x17000C07 RID: 3079
	// (get) Token: 0x06008F6A RID: 36714 RVA: 0x0025A6F4 File Offset: 0x002588F4
	// (set) Token: 0x06008F6B RID: 36715 RVA: 0x0025A72B File Offset: 0x0025892B
	public int? CurrentChosenProgressIndex
	{
		get
		{
			int? currentChosenProgressIndex = this.UiContext.CurrentChosenProgressIndex;
			if (currentChosenProgressIndex == null)
			{
				currentChosenProgressIndex = new int?(0);
				this.UiContext.CurrentChosenProgressIndex = currentChosenProgressIndex;
			}
			return currentChosenProgressIndex;
		}
		set
		{
			this.UiContext.CurrentChosenProgressIndex = value;
		}
	}

	// Token: 0x17000C08 RID: 3080
	// (get) Token: 0x06008F6C RID: 36716 RVA: 0x0025A739 File Offset: 0x00258939
	public int CurrentHelpButtonId
	{
		get
		{
			return this.ProtocolContext.GetHelpId();
		}
	}

	// Token: 0x17000C09 RID: 3081
	// (get) Token: 0x06008F6D RID: 36717 RVA: 0x0025A746 File Offset: 0x00258946
	public int CurrentInstanceId
	{
		get
		{
			InstanceDungeonEntranceModel instance = ModelBase<InstanceDungeonEntranceModel>.Instance;
			if (instance == null)
			{
				return 0;
			}
			return instance.SelectInstanceId;
		}
	}

	// Token: 0x17000C0A RID: 3082
	// (get) Token: 0x06008F6E RID: 36718 RVA: 0x0025A758 File Offset: 0x00258958
	public bool IsNewInstanceOpen
	{
		get
		{
			Dictionary<int, bool> isInstanceNewCache = this.ConfigContext.IsInstanceNewCache;
			Dictionary<double, bool> dictionary = new Dictionary<double, bool>();
			foreach (KeyValuePair<int, bool> keyValuePair in isInstanceNewCache)
			{
				int num;
				bool flag;
				keyValuePair.Deconstruct(out num, out flag);
				int id = num;
				bool flag2 = flag;
				double instanceUnlockTimestampById = this.ProtocolContext.GetInstanceUnlockTimestampById(id);
				bool flag3;
				if (!dictionary.TryGetValue(instanceUnlockTimestampById, out flag3))
				{
					flag3 = true;
				}
				bool flag4 = this.ProtocolContext.IsInstancePassUnlockTimeById(id);
				dictionary[instanceUnlockTimestampById] = (flag3 && !this.ProtocolContext.IsInstancePlayedById(id) && flag2 && flag4);
			}
			using (Dictionary<double, bool>.ValueCollection.Enumerator enumerator2 = dictionary.Values.GetEnumerator())
			{
				while (enumerator2.MoveNext())
				{
					if (enumerator2.Current)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x17000C0B RID: 3083
	// (get) Token: 0x06008F6F RID: 36719 RVA: 0x0025A858 File Offset: 0x00258A58
	public bool IsPreQuestFinished
	{
		get
		{
			return this.ProtocolContext.GetPreGuideQuestFinishState();
		}
	}

	// Token: 0x17000C0C RID: 3084
	// (get) Token: 0x06008F70 RID: 36720 RVA: 0x0025A865 File Offset: 0x00258A65
	public int UnFinishPreGuideQuestId
	{
		get
		{
			return this.ProtocolContext.GetUnFinishPreGuideQuestId();
		}
	}

	// Token: 0x17000C0D RID: 3085
	// (get) Token: 0x06008F71 RID: 36721 RVA: 0x0025A872 File Offset: 0x00258A72
	public string InstanceSubViewResourceId
	{
		get
		{
			return "UiItem_CheckpointsMowing";
		}
	}

	// Token: 0x17000C0E RID: 3086
	// (get) Token: 0x06008F72 RID: 36722 RVA: 0x0025A87C File Offset: 0x00258A7C
	public string ActivityTitleTextId
	{
		get
		{
			MowingRiskProtocolContext protocolContext = this.ProtocolContext;
			return ((protocolContext.LocalConfig != null) ? protocolContext.LocalConfig.GetValueOrDefault().Title : null) ?? string.Empty;
		}
	}

	// Token: 0x17000C0F RID: 3087
	// (get) Token: 0x06008F73 RID: 36723 RVA: 0x0025A8B8 File Offset: 0x00258AB8
	public string ActivityDescriptionTextId
	{
		get
		{
			MowingRiskProtocolContext protocolContext = this.ProtocolContext;
			return ((protocolContext.LocalConfig != null) ? protocolContext.LocalConfig.GetValueOrDefault().Desc : null) ?? string.Empty;
		}
	}

	// Token: 0x17000C10 RID: 3088
	// (get) Token: 0x06008F74 RID: 36724 RVA: 0x0025A8F2 File Offset: 0x00258AF2
	public bool HasAnyReward
	{
		get
		{
			return this.HasAnyInstanceReward || this.HasAnyScoreReward || this.HasAnyStarReward;
		}
	}

	// Token: 0x17000C11 RID: 3089
	// (get) Token: 0x06008F75 RID: 36725 RVA: 0x0025A90C File Offset: 0x00258B0C
	public bool HasAnyInstanceReward
	{
		get
		{
			foreach (RiskHarvestInst cfg in this.ConfigContext.GetRiskHarvestInstByActivityId(this.ProtocolContext.Id))
			{
				if (this.GetRewardStateByRiskHarvestInst(cfg) == EActivityRewardState.Enable)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x17000C12 RID: 3090
	// (get) Token: 0x06008F76 RID: 36726 RVA: 0x0025A974 File Offset: 0x00258B74
	public bool HasAnyScoreReward
	{
		get
		{
			foreach (RiskHarvestScoreReward cfg in this.ConfigContext.GetRiskHarvestScoreRewardByActivityId(this.ProtocolContext.Id))
			{
				if (this.GetRewardStateByRiskHarvestScoreReward(cfg) == EActivityRewardState.Enable)
				{
					return true;
				}
			}
			return false;
		}
	}

	// Token: 0x17000C13 RID: 3091
	// (get) Token: 0x06008F77 RID: 36727 RVA: 0x0025A9DC File Offset: 0x00258BDC
	public bool HasAnyStarReward
	{
		get
		{
			foreach (RiskHarvestInst cfg in this.ConfigContext.GetRiskHarvestInstByActivityId(this.ProtocolContext.Id))
			{
				int num = cfg.StarRewardList().Length;
				for (int i = 0; i < num; i++)
				{
					if (this.GetRewardStateByRiskHarvestStarReward(cfg, i) == EActivityRewardState.Enable)
					{
						return true;
					}
				}
			}
			return false;
		}
	}

	// Token: 0x17000C14 RID: 3092
	// (get) Token: 0x06008F78 RID: 36728 RVA: 0x0025AA5C File Offset: 0x00258C5C
	public int MapMarkId
	{
		get
		{
			return 380034;
		}
	}

	// Token: 0x17000C15 RID: 3093
	// (get) Token: 0x06008F79 RID: 36729 RVA: 0x0025AA63 File Offset: 0x00258C63
	public int MapMarkType
	{
		get
		{
			return 6;
		}
	}

	// Token: 0x17000C16 RID: 3094
	// (get) Token: 0x06008F7A RID: 36730 RVA: 0x0025AA68 File Offset: 0x00258C68
	public int? NextNewBuffId
	{
		get
		{
			if (this.UiContext.NewBuffToShowCache.Count > 0)
			{
				int value = this.UiContext.NewBuffToShowCache[0];
				this.UiContext.NewBuffToShowCache.RemoveAt(0);
				return new int?(value);
			}
			return null;
		}
	}
}
