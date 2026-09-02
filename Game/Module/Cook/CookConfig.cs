using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Cook
{
	// Token: 0x02005DF0 RID: 24048
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class CookConfig : ConfigBase<CookConfig>
	{
		// Token: 0x0603C81B RID: 247835 RVA: 0x00F5DCBD File Offset: 0x00F5BEBD
		public string GetLocalText(string id)
		{
			return ConfigMultiTextLang.GetLocalTextNew(id, null) ?? "";
		}

		// Token: 0x0603C81C RID: 247836 RVA: 0x00F5DCD0 File Offset: 0x00F5BED0
		public CookFormula GetCookFormulaByFormulaItemId(int id)
		{
			CookFormula? config = ConfigCookFormulaByFormulaItemId.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "烹饪配方获取失败，请检查烹饪配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("FormulaItemId=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603C81D RID: 247837 RVA: 0x00F5DD24 File Offset: 0x00F5BF24
		[NullableContext(2)]
		public IReadOnlyList<CookFormula> GetCookFormula()
		{
			return ConfigCookFormulaAll.GetConfigList(true);
		}

		// Token: 0x0603C81E RID: 247838 RVA: 0x00F5DD2C File Offset: 0x00F5BF2C
		public CookFormula GetCookFormulaById(int id)
		{
			CookFormula? config = ConfigCookFormulaById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "烹饪配方获取失败，请检查烹饪配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603C81F RID: 247839 RVA: 0x00F5DD80 File Offset: 0x00F5BF80
		public CookProcessed GetCookProcessedById(int id)
		{
			CookProcessed? config = ConfigCookProcessedById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "食材加工获取失败，请检查食材加工配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603C820 RID: 247840 RVA: 0x00F5DDD4 File Offset: 0x00F5BFD4
		public IReadOnlyList<CookProcessed> GetCookProcessed()
		{
			IReadOnlyList<CookProcessed> configList = ConfigCookProcessedAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Cook, ELogAuthor.LK, "食材加工列表获取失败，请检查食材加工配置表是否正确", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603C821 RID: 247841 RVA: 0x00F5DE0C File Offset: 0x00F5C00C
		public CookProcessMsg GetCookProcessMsgById(int id)
		{
			CookProcessMsg? config = ConfigCookProcessMsgById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "食材加工获取失败，请检查食材加工配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603C822 RID: 247842 RVA: 0x00F5DE60 File Offset: 0x00F5C060
		public IReadOnlyList<CookLevel> GetCookLevel()
		{
			IReadOnlyList<CookLevel> configList = ConfigCookLevelAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Cook, ELogAuthor.LK, "获取厨师证书相关配置失败", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603C823 RID: 247843 RVA: 0x00F5DE98 File Offset: 0x00F5C098
		public CookLevel GetCookLevelByLevel(int level)
		{
			CookLevel? config = ConfigCookLevelById.GetConfig(level, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "获取目标等级厨师证书相关配置失败";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id=", level);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}

		// Token: 0x0603C824 RID: 247844 RVA: 0x00F5DEEC File Offset: 0x00F5C0EC
		public CookFixTool GetCookFixToolById(int id)
		{
			CookFixTool? config = ConfigCookFixToolById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Cook;
				ELogAuthor author = ELogAuthor.LK;
				string message = "食材修理工具获取失败，请检查食材修理工具配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config.Value;
		}
	}
}
