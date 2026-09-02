using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001CAC RID: 7340
[NullableContext(2)]
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class FunctionConfig : ConfigBase<FunctionConfig>
{
	// Token: 0x0600D77B RID: 55163 RVA: 0x0039A0E3 File Offset: 0x003982E3
	protected override bool OnInit()
	{
		return true;
	}

	// Token: 0x0600D77C RID: 55164 RVA: 0x0039A0E6 File Offset: 0x003982E6
	protected override bool OnClear()
	{
		return true;
	}

	// Token: 0x0600D77D RID: 55165 RVA: 0x0039A0E9 File Offset: 0x003982E9
	public IReadOnlyList<PlayerExp> GetRangePlayerExpConfig(int sourceLevel, int targetLevel)
	{
		return ConfigPlayerExpByPlayerLevelArea.GetConfigList(sourceLevel, targetLevel, true);
	}

	// Token: 0x0600D77E RID: 55166 RVA: 0x0039A0F3 File Offset: 0x003982F3
	public PlayerExp? GetPlayerLevelConfig(int playerLevel)
	{
		return ConfigPlayerExpByPlayerLevel.GetConfig(playerLevel, true);
	}

	// Token: 0x0600D77F RID: 55167 RVA: 0x0039A0FC File Offset: 0x003982FC
	public IReadOnlyList<FunctionMenu> GetAllFunctionList()
	{
		return ConfigFunctionMenuAll.GetConfigList(true);
	}

	// Token: 0x0600D780 RID: 55168 RVA: 0x0039A104 File Offset: 0x00398304
	public FunctionMenu? GetFunctionConfig(int functionId)
	{
		return ConfigFunctionMenuByFunctionId.GetConfig(functionId, true);
	}

	// Token: 0x0600D781 RID: 55169 RVA: 0x0039A10D File Offset: 0x0039830D
	public FunctionCondition? GetFunctionCondition(int functionId)
	{
		return ConfigFunctionConditionByFunctionId.GetConfig(functionId, true);
	}

	// Token: 0x0600D782 RID: 55170 RVA: 0x0039A118 File Offset: 0x00398318
	public int GetDifferenceExp(int sourceLevel, int sourceExp, int targetLevel, int targetExp)
	{
		int num = 0;
		IReadOnlyList<PlayerExp> configList = ConfigPlayerExpByPlayerLevelArea.GetConfigList(sourceLevel, targetLevel, true);
		if (configList != null)
		{
			foreach (PlayerExp playerExp in configList)
			{
				num += playerExp.LevelExp;
			}
		}
		return num - sourceExp + targetExp;
	}

	// Token: 0x0600D783 RID: 55171 RVA: 0x0039A178 File Offset: 0x00398378
	public string GetFunctionIconPath(int functionId)
	{
		FunctionMenu? functionConfig = this.GetFunctionConfig(functionId);
		if (functionConfig == null)
		{
			return null;
		}
		if (functionId == 10001)
		{
			return this.GetRoleFunctionIconPath();
		}
		return functionConfig.Value.FunctionIcon;
	}

	// Token: 0x0600D784 RID: 55172 RVA: 0x0039A1B8 File Offset: 0x003983B8
	[NullableContext(1)]
	public string GetRoleFunctionIconPath()
	{
		bool sex = ModelBase<WorldLevelModel>.Instance.Sex != 0;
		string resourceId = "SP_FuncIconRole";
		if (!sex)
		{
			resourceId = "SP_FuncIconRole2";
		}
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
	}

	// Token: 0x0600D785 RID: 55173 RVA: 0x0039A1E8 File Offset: 0x003983E8
	[NullableContext(1)]
	public string GetFightIconResonancePath()
	{
		bool sex = ModelBase<WorldLevelModel>.Instance.Sex != 0;
		string resourceId = "SP_FightIconResonance";
		if (!sex)
		{
			resourceId = "SP_FightIconResonance2";
		}
		return ConfigBase<UiResourceConfig>.Instance.GetResourcePath(resourceId);
	}
}
