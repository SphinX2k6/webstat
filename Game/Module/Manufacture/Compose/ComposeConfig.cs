using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Manufacture.Compose
{
	// Token: 0x020059B2 RID: 22962
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ComposeConfig : ConfigBase<ComposeConfig>
	{
		// Token: 0x0603A232 RID: 238130 RVA: 0x00EB8373 File Offset: 0x00EB6573
		[NullableContext(1)]
		public string GetLocalText(string id)
		{
			return ConfigMultiTextLang.GetLocalTextNew(id, null) ?? "";
		}

		// Token: 0x0603A233 RID: 238131 RVA: 0x00EB8388 File Offset: 0x00EB6588
		public SynthesisFormula? GetSynthesisFormulaByFormulaItemId(int id)
		{
			SynthesisFormula? config = ConfigSynthesisFormulaByFormulaItemId.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.LK;
				string message = "合成配方获取失败，请检查合成配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("FormulaItemId", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603A234 RID: 238132 RVA: 0x00EB83D6 File Offset: 0x00EB65D6
		public SynthesisFormula? GetSynthesisFormulaByItemId(int itemId)
		{
			return ConfigSynthesisFormulaByItemId.GetConfig(itemId, true);
		}

		// Token: 0x0603A235 RID: 238133 RVA: 0x00EB83E0 File Offset: 0x00EB65E0
		public SynthesisFormula? GetSynthesisFormulaById(int id)
		{
			SynthesisFormula? config = ConfigSynthesisFormulaById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.LK;
				string message = "合成配方获取失败，请检查合成配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603A236 RID: 238134 RVA: 0x00EB8430 File Offset: 0x00EB6630
		public IReadOnlyList<SynthesisFormula> GetComposeListByType(int type)
		{
			IReadOnlyList<SynthesisFormula> configList = ConfigSynthesisFormulaByFormulaType.GetConfigList(type, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Compose;
				ELogAuthor author = ELogAuthor.LK;
				string message = "获取对应类型合成数据失败，请检查合成配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("FormulaType", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x0603A237 RID: 238135 RVA: 0x00EB8478 File Offset: 0x00EB6678
		public IReadOnlyList<MaterialReplace> GetExchangeList()
		{
			IReadOnlyList<MaterialReplace> configList = ConfigMaterialReplaceAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Compose, ELogAuthor.LJQ, "获取置换数据列表失败，请检查合成表是否正确", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603A238 RID: 238136 RVA: 0x00EB84AC File Offset: 0x00EB66AC
		public IReadOnlyList<SynthesisLevel> GetComposeLevel()
		{
			IReadOnlyList<SynthesisLevel> configList = ConfigSynthesisLevelAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Compose, ELogAuthor.LK, "获取制药证书相关配置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603A239 RID: 238137 RVA: 0x00EB84E1 File Offset: 0x00EB66E1
		public ConditionGroup? GetConditionInfo(int upConditionId)
		{
			return ConfigConditionGroupById.GetConfig(upConditionId, true);
		}

		// Token: 0x0603A23A RID: 238138 RVA: 0x00EB84EA File Offset: 0x00EB66EA
		public IReadOnlyList<MaterialReplace> GetExchangeByGroupId(int groupId)
		{
			return ConfigMaterialReplaceByGroupId.GetConfigList(groupId, true);
		}
	}
}
