using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;
using CSharpScript.Core.Common;
using CSharpScript.Game.Module.AdventureGuide;

// Token: 0x0200173A RID: 5946
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class AdventureGuideConfig : ConfigBase<AdventureGuideConfig>
{
	// Token: 0x0600A638 RID: 42552 RVA: 0x002BF5F9 File Offset: 0x002BD7F9
	public AdventureGuideConfig()
	{
		this.PreOpenDetectionMap = new Dictionary<int, List<PreOpenDetection>>();
		this.LevelPlayNightMareConfigMapping = new Dictionary<int, ILevelPlayNightMareConfigData>();
	}

	// Token: 0x0600A639 RID: 42553 RVA: 0x002BF618 File Offset: 0x002BD818
	protected override bool OnInit()
	{
		IReadOnlyList<PreOpenDetection> preOpenDetectionConfAll = this.GetPreOpenDetectionConfAll();
		if (preOpenDetectionConfAll != null)
		{
			foreach (PreOpenDetection item in preOpenDetectionConfAll)
			{
				if (!this.PreOpenDetectionMap.ContainsKey(item.DetectionId))
				{
					this.PreOpenDetectionMap.Add(item.DetectionId, new List<PreOpenDetection>());
				}
				this.PreOpenDetectionMap[item.DetectionId].Add(item);
			}
		}
		IReadOnlyList<LevelPlayInfoMappingConfig> configList = ConfigLevelPlayInfoMappingConfigAll.GetConfigList(true);
		if (configList != null)
		{
			IReadOnlyList<LevelPlayInfoMappingConfig> readOnlyList = configList;
			for (int i = 0; i < readOnlyList.Count; i++)
			{
				LevelPlayInfoMappingConfig levelPlayInfoMappingConfig = readOnlyList[i];
				if (levelPlayInfoMappingConfig.Type == 2)
				{
					LevelPlayNightMareConfigData levelPlayNightMareConfigData = Json.Decode<LevelPlayNightMareConfigData>(levelPlayInfoMappingConfig.Data, null);
					if (levelPlayNightMareConfigData != null && !this.LevelPlayNightMareConfigMapping.ContainsKey(levelPlayNightMareConfigData.LevelPlayId))
					{
						this.LevelPlayNightMareConfigMapping.Add(levelPlayNightMareConfigData.LevelPlayId, levelPlayNightMareConfigData);
					}
				}
			}
		}
		return true;
	}

	// Token: 0x0600A63A RID: 42554 RVA: 0x002BF71C File Offset: 0x002BD91C
	public List<PreOpenDetection> GetPreOpenDetectionConfListByDetectionId(int detectionId, ESoundAreaDataType soundAreaDataType)
	{
		List<PreOpenDetection> list = new List<PreOpenDetection>();
		List<PreOpenDetection> list2;
		if (this.PreOpenDetectionMap.TryGetValue(detectionId, out list2))
		{
			foreach (PreOpenDetection item in list2)
			{
				if (item.SoundAreaType == (int)soundAreaDataType)
				{
					list.Add(item);
				}
			}
		}
		return list;
	}

	// Token: 0x0600A63B RID: 42555 RVA: 0x002BF78C File Offset: 0x002BD98C
	public List<PreOpenDetection> GetPreOpenDetectionConfList(int detectionId, ESoundAreaDataType soundAreaDataType, int preOpenDetectionId)
	{
		List<PreOpenDetection> preOpenDetectionConfListByDetectionId = this.GetPreOpenDetectionConfListByDetectionId(detectionId, soundAreaDataType);
		if (preOpenDetectionConfListByDetectionId.Count == 0 && preOpenDetectionId != 0)
		{
			PreOpenDetection? preOpenDetectionConfById = this.GetPreOpenDetectionConfById(preOpenDetectionId);
			if (preOpenDetectionConfById != null)
			{
				preOpenDetectionConfListByDetectionId.Add(preOpenDetectionConfById.Value);
			}
		}
		return preOpenDetectionConfListByDetectionId;
	}

	// Token: 0x0600A63C RID: 42556 RVA: 0x002BF7CC File Offset: 0x002BD9CC
	public AdventureTask? GetAdventureTaskConfig(int taskId)
	{
		AdventureTask? config = ConfigAdventureTaskById.GetConfig(taskId, true);
		if (config != null)
		{
			return new AdventureTask?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A63D RID: 42557 RVA: 0x002BF800 File Offset: 0x002BDA00
	[NullableContext(2)]
	public IReadOnlyList<AdventureTask> GetAllAdventureTaskConfig()
	{
		IReadOnlyList<AdventureTask> configList = ConfigAdventureTaskAll.GetConfigList(true);
		if (configList != null)
		{
			return configList;
		}
		return null;
	}

	// Token: 0x0600A63E RID: 42558 RVA: 0x002BF81C File Offset: 0x002BDA1C
	public Dictionary<int, int> GetDropShowInfo(int id)
	{
		DropPackage? config = ConfigDropPackageById.GetConfig(id, true);
		if (config != null)
		{
			return config.Value.DropPreview();
		}
		return new Dictionary<int, int>();
	}

	// Token: 0x0600A63F RID: 42559 RVA: 0x002BF850 File Offset: 0x002BDA50
	public Dictionary<int, int> GetShowReward(Dictionary<int, int> showRewardMap, int? level = null)
	{
		int curWorldLevel = ModelBase<WorldLevelModel>.Instance.CurWorldLevel;
		int num = 0;
		if (level != null)
		{
			if (!showRewardMap.TryGetValue(level.Value, out num))
			{
				for (int i = level.Value - 1; i >= 0; i--)
				{
					if (showRewardMap.TryGetValue(i, out num))
					{
						break;
					}
				}
			}
		}
		else if (!showRewardMap.TryGetValue(curWorldLevel, out num))
		{
			int num2 = curWorldLevel - 1;
			while (num2 >= 0 && !showRewardMap.TryGetValue(num2, out num))
			{
				num2--;
			}
		}
		if (num > 0)
		{
			DropPackage? config = ConfigDropPackageById.GetConfig(num, true);
			if (config != null)
			{
				return config.Value.DropPreview();
			}
		}
		int p0Id;
		if (showRewardMap.TryGetValue(1, out p0Id))
		{
			DropPackage? config2 = ConfigDropPackageById.GetConfig(p0Id, true);
			if (config2 != null)
			{
				return config2.Value.DropPreview();
			}
		}
		return new Dictionary<int, int>();
	}

	// Token: 0x0600A640 RID: 42560 RVA: 0x002BF928 File Offset: 0x002BDB28
	[NullableContext(2)]
	public Dictionary<int, int> GetNightMareShowReward(Dictionary<int, int> showRewardMap)
	{
		if (showRewardMap == null || showRewardMap.Count <= 0)
		{
			return null;
		}
		int calabashLevel = ModelBase<CalabashModel>.Instance.GetCalabashLevel();
		int num = 0;
		if (!showRewardMap.TryGetValue(calabashLevel, out num))
		{
			int num2 = calabashLevel - 1;
			while (num2 >= 0 && !showRewardMap.TryGetValue(num2, out num))
			{
				num2--;
			}
		}
		if (num > 0)
		{
			DropPackage? config = ConfigDropPackageById.GetConfig(num, true);
			if (config != null)
			{
				return config.Value.DropPreview();
			}
		}
		int p0Id;
		if (showRewardMap.TryGetValue(1, out p0Id))
		{
			DropPackage? config2 = ConfigDropPackageById.GetConfig(p0Id, true);
			if (config2 != null)
			{
				return config2.Value.DropPreview();
			}
		}
		return null;
	}

	// Token: 0x0600A641 RID: 42561 RVA: 0x002BF9CC File Offset: 0x002BDBCC
	public AdventureTaskChapter? GetChapterAdventureConfig(int chapter)
	{
		AdventureTaskChapter? config = ConfigAdventureTaskChapterById.GetConfig(chapter, true);
		if (config != null)
		{
			return new AdventureTaskChapter?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A642 RID: 42562 RVA: 0x002BFA00 File Offset: 0x002BDC00
	[NullableContext(2)]
	public IReadOnlyList<MonsterDetection> GetAllMonsterDetection()
	{
		IReadOnlyList<MonsterDetection> configList = ConfigMonsterDetectionAll.GetConfigList(true);
		if (configList != null)
		{
			return configList;
		}
		return null;
	}

	// Token: 0x0600A643 RID: 42563 RVA: 0x002BFA1C File Offset: 0x002BDC1C
	[NullableContext(2)]
	public IReadOnlyList<DungeonDetection> GetAllDungeonDetection()
	{
		IReadOnlyList<DungeonDetection> configList = ConfigDungeonDetectionAll.GetConfigList(true);
		if (configList != null)
		{
			return configList;
		}
		return null;
	}

	// Token: 0x0600A644 RID: 42564 RVA: 0x002BFA38 File Offset: 0x002BDC38
	[NullableContext(2)]
	public IReadOnlyList<SilentAreaDetection> GetAllSilentAreaDetection()
	{
		IReadOnlyList<SilentAreaDetection> configList = ConfigSilentAreaDetectionAll.GetConfigList(true);
		if (configList != null)
		{
			return configList;
		}
		return null;
	}

	// Token: 0x0600A645 RID: 42565 RVA: 0x002BFA54 File Offset: 0x002BDC54
	public MonsterDetection? GetMonsterDetectionConfById(int id)
	{
		MonsterDetection? config = ConfigMonsterDetectionById.GetConfig(id, true);
		if (config != null)
		{
			return new MonsterDetection?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A646 RID: 42566 RVA: 0x002BFA88 File Offset: 0x002BDC88
	public DungeonDetection? GetDungeonDetectionConfById(int id)
	{
		DungeonDetection? config = ConfigDungeonDetectionById.GetConfig(id, true);
		if (config != null)
		{
			return new DungeonDetection?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A647 RID: 42567 RVA: 0x002BFABC File Offset: 0x002BDCBC
	public SilentAreaDetection? GetSilentAreaDetectionConfById(int id)
	{
		SilentAreaDetection? config = ConfigSilentAreaDetectionById.GetConfig(id, true);
		if (config != null)
		{
			return new SilentAreaDetection?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A648 RID: 42568 RVA: 0x002BFAF0 File Offset: 0x002BDCF0
	public int GetMaxChapter()
	{
		IReadOnlyList<AdventureTaskChapter> configList = ConfigAdventureTaskChapterAll.GetConfigList(true);
		if (configList == null)
		{
			return 0;
		}
		List<AdventureTaskChapter> list = new List<AdventureTaskChapter>(configList);
		list.Sort((AdventureTaskChapter a, AdventureTaskChapter b) => b.Id - a.Id);
		return list[0].Id;
	}

	// Token: 0x0600A649 RID: 42569 RVA: 0x002BFB44 File Offset: 0x002BDD44
	public int GetMaxDungeonLevel(int enterId)
	{
		InstanceDungeonEntrance? config = ConfigInstanceDungeonEntranceById.GetConfig(enterId, true);
		if (config == null)
		{
			return 0;
		}
		int num = 0;
		int[] array = config.Value.InstanceDungeonList();
		for (int i = 0; i < array.Length; i++)
		{
			InstanceDungeon? config2 = ConfigInstanceDungeonById.GetConfig(array[i], true);
			if (config2 != null)
			{
				int num2 = config2.Value.DifficultyLevel()[config2.Value.DifficultyLevel().Length - 1];
				if (num2 > num)
				{
					num = num2;
				}
			}
		}
		return num;
	}

	// Token: 0x0600A64A RID: 42570 RVA: 0x002BFBCC File Offset: 0x002BDDCC
	public string GetSecondaryGuideDataTextById(int id)
	{
		SecondaryGuideData? config = ConfigSecondaryGuideDataById.GetConfig(id, true);
		if (config != null)
		{
			return config.Value.Text;
		}
		return "";
	}

	// Token: 0x0600A64B RID: 42571 RVA: 0x002BFC00 File Offset: 0x002BDE00
	public SecondaryGuideData? GetSecondaryGuideDataConf(int id)
	{
		SecondaryGuideData? config = ConfigSecondaryGuideDataById.GetConfig(id, true);
		if (config != null)
		{
			return new SecondaryGuideData?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A64C RID: 42572 RVA: 0x002BFC34 File Offset: 0x002BDE34
	public string GetLocalFilterTextById(int id)
	{
		SecondaryGuideData? config = ConfigSecondaryGuideDataById.GetConfig(id, true);
		if (config != null)
		{
			return ConfigMultiTextLang.GetLocalTextNew(config.Value.Text, null) ?? "";
		}
		return "";
	}

	// Token: 0x0600A64D RID: 42573 RVA: 0x002BFC78 File Offset: 0x002BDE78
	public PreOpenDetection? GetPreOpenDetectionConfById(int detectionId)
	{
		PreOpenDetection? config = ConfigPreOpenDetectionById.GetConfig(detectionId, true);
		if (config != null)
		{
			return new PreOpenDetection?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A64E RID: 42574 RVA: 0x002BFCAC File Offset: 0x002BDEAC
	[NullableContext(2)]
	public IReadOnlyList<PreOpenDetection> GetPreOpenDetectionConfAll()
	{
		IReadOnlyList<PreOpenDetection> configList = ConfigPreOpenDetectionAll.GetConfigList(true);
		if (configList != null)
		{
			return configList;
		}
		return null;
	}

	// Token: 0x0600A64F RID: 42575 RVA: 0x002BFCC8 File Offset: 0x002BDEC8
	public DetectionDropDownType? GetDropDownConfig(int type)
	{
		DetectionDropDownType? config = ConfigDetectionDropDownTypeById.GetConfig(type, true);
		if (config != null)
		{
			return new DetectionDropDownType?(config.Value);
		}
		return null;
	}

	// Token: 0x0600A650 RID: 42576 RVA: 0x002BFCFC File Offset: 0x002BDEFC
	[NullableContext(2)]
	public ILevelPlayNightMareConfigData GetLevelPlayNightMareConfig(int levelPlayNightMareId)
	{
		ILevelPlayNightMareConfigData result;
		if (this.LevelPlayNightMareConfigMapping.TryGetValue(levelPlayNightMareId, out result))
		{
			return result;
		}
		return null;
	}

	// Token: 0x0600A651 RID: 42577 RVA: 0x002BFD1C File Offset: 0x002BDF1C
	public DetectionTitlePanel? GetDetectionTitlePanelConfig(int detectionTitlePanelId)
	{
		DetectionTitlePanel? config = ConfigDetectionTitlePanelById.GetConfig(detectionTitlePanelId, true);
		if (config != null)
		{
			return new DetectionTitlePanel?(config.Value);
		}
		return null;
	}

	// Token: 0x04004EBC RID: 20156
	private readonly Dictionary<int, List<PreOpenDetection>> PreOpenDetectionMap;

	// Token: 0x04004EBD RID: 20157
	private readonly Dictionary<int, ILevelPlayNightMareConfigData> LevelPlayNightMareConfigMapping;
}
