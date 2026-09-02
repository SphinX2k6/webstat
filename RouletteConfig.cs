using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200290A RID: 10506
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class RouletteConfig : ConfigBase<RouletteConfig>
{
	// Token: 0x06014DC9 RID: 85449 RVA: 0x005C7711 File Offset: 0x005C5911
	public ExploreTools? GetExploreConfigById(int id)
	{
		return ConfigExploreToolsByPhantomSkillId.GetConfig(id, true);
	}

	// Token: 0x06014DCA RID: 85450 RVA: 0x005C771A File Offset: 0x005C591A
	public IReadOnlyList<ExploreRoulette> GetExploreRouletteConfig()
	{
		return ConfigExploreRouletteAll.GetConfigList(true) ?? new List<ExploreRoulette>();
	}

	// Token: 0x06014DCB RID: 85451 RVA: 0x005C772B File Offset: 0x005C592B
	public IReadOnlyList<ExploreRouletteReplace> GetAllReplaceConfig()
	{
		return ConfigExploreRouletteReplaceAll.GetConfigList(true) ?? new List<ExploreRouletteReplace>();
	}

	// Token: 0x06014DCC RID: 85452 RVA: 0x005C773C File Offset: 0x005C593C
	public ExploreRouletteReplace? GetReplaceConfigById(int id)
	{
		return ConfigExploreRouletteReplaceById.GetConfig(id, true);
	}

	// Token: 0x06014DCD RID: 85453 RVA: 0x005C7745 File Offset: 0x005C5945
	public FuncMenuWheel? GetFuncConfigById(int id)
	{
		return ConfigFuncMenuWheelByFuncId.GetConfig(id, true);
	}

	// Token: 0x06014DCE RID: 85454 RVA: 0x005C774E File Offset: 0x005C594E
	[NullableContext(2)]
	public IReadOnlyList<ExploreTools> GetAllExploreConfig()
	{
		return ConfigExploreToolsAll.GetConfigList(true);
	}

	// Token: 0x06014DCF RID: 85455 RVA: 0x005C7756 File Offset: 0x005C5956
	[NullableContext(2)]
	public IReadOnlyList<FuncMenuWheel> GetAllFuncConfig()
	{
		return ConfigFuncMenuWheelAll.GetConfigList(true);
	}

	// Token: 0x06014DD0 RID: 85456 RVA: 0x005C775E File Offset: 0x005C595E
	public string GetFuncMenuIconPathByConfig(FuncMenuWheel config)
	{
		if (config.UnlockCondition == 10001)
		{
			return ConfigBase<FunctionConfig>.Instance.GetRoleFunctionIconPath();
		}
		return config.FuncMenuIconPath;
	}

	// Token: 0x06014DD1 RID: 85457 RVA: 0x005C7780 File Offset: 0x005C5980
	public FuncMenuReplace? GetFuncReplaceConfig(int instSubType)
	{
		return ConfigFuncMenuReplaceInstSubType.GetConfig(instSubType, true);
	}

	// Token: 0x06014DD2 RID: 85458 RVA: 0x005C7789 File Offset: 0x005C5989
	public FuncMenuReplace? GetFuncReplaceConfigById(int id)
	{
		return ConfigFuncMenuReplaceId.GetConfig(id, true);
	}

	// Token: 0x06014DD3 RID: 85459 RVA: 0x005C7792 File Offset: 0x005C5992
	public IReadOnlyList<FuncMenuReplace> GetAllFuncReplaceConfig()
	{
		return ConfigFuncMenuReplaceAll.GetConfigList(true) ?? new List<FuncMenuReplace>();
	}

	// Token: 0x06014DD4 RID: 85460 RVA: 0x005C77A4 File Offset: 0x005C59A4
	[NullableContext(2)]
	public string GetNameByPhantomSkillId(int phantomSkillId)
	{
		ExploreTools? config = ConfigExploreToolsByPhantomSkillId.GetConfig(phantomSkillId, true);
		if (config == null)
		{
			return null;
		}
		return ConfigMultiTextLang.GetLocalTextNew(config.Value.Name, null);
	}

	// Token: 0x06014DD5 RID: 85461 RVA: 0x005C77DC File Offset: 0x005C59DC
	[NullableContext(2)]
	public Dictionary<int, int> GetCostByPhantomSkillId(int phantomSkillId)
	{
		ExploreTools? config = ConfigExploreToolsByPhantomSkillId.GetConfig(phantomSkillId, true);
		if (config == null)
		{
			return null;
		}
		return config.Value.Cost();
	}

	// Token: 0x06014DD6 RID: 85462 RVA: 0x005C780B File Offset: 0x005C5A0B
	public ExploreRouletteType? GetExploreRouletteTypeById(int typeId)
	{
		return ConfigExploreRouletteTypeById.GetConfig(typeId, true);
	}

	// Token: 0x06014DD7 RID: 85463 RVA: 0x005C7814 File Offset: 0x005C5A14
	public IReadOnlyList<ExploreRouletteType> GetAllRouletteTypeConfig()
	{
		return ConfigExploreRouletteTypeAll.GetConfigList(true) ?? new List<ExploreRouletteType>();
	}

	// Token: 0x06014DD8 RID: 85464 RVA: 0x005C7828 File Offset: 0x005C5A28
	public int GetTreasureBoxDetectorPlaceLimit()
	{
		return ConfigCommonParamById.GetIntConfig("TreasureBoxDetectionMaxNum").GetValueOrDefault();
	}

	// Token: 0x06014DD9 RID: 85465 RVA: 0x005C7848 File Offset: 0x005C5A48
	public int GetTempTeleporterPlaceLimit()
	{
		return ConfigCommonParamById.GetIntConfig("TemporaryTeleportCountLimit").GetValueOrDefault();
	}

	// Token: 0x06014DDA RID: 85466 RVA: 0x005C7868 File Offset: 0x005C5A68
	public int GetSoundBoxPlaceLimit()
	{
		return ConfigCommonParamById.GetIntConfig("SoundBoxUseTimes").GetValueOrDefault();
	}
}
