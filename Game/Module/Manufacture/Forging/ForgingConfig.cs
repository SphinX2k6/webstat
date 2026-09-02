using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Manufacture.Forging
{
	// Token: 0x020059A0 RID: 22944
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class ForgingConfig : ConfigBase<ForgingConfig>
	{
		// Token: 0x0603A164 RID: 237924 RVA: 0x00EB350A File Offset: 0x00EB170A
		[NullableContext(1)]
		public string GetLocalText(string id)
		{
			return ConfigMultiTextLang.GetLocalTextNew(id, null) ?? "";
		}

		// Token: 0x0603A165 RID: 237925 RVA: 0x00EB351C File Offset: 0x00EB171C
		public ForgeFormula? GetForgeFormulaByFormulaItemId(int id)
		{
			ForgeFormula? config = ConfigForgeFormulaByFormulaItemId.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Forging;
				ELogAuthor author = ELogAuthor.LK;
				string message = "锻造配方获取失败，请检查锻造配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("FormulaItemId=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603A166 RID: 237926 RVA: 0x00EB356C File Offset: 0x00EB176C
		public ForgeFormula? GetForgeFormulaById(int id)
		{
			ForgeFormula? config = ConfigForgeFormulaById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Forging;
				ELogAuthor author = ELogAuthor.LK;
				string message = "锻造配方获取失败，请检查锻造配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id=", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603A167 RID: 237927 RVA: 0x00EB35BC File Offset: 0x00EB17BC
		public IReadOnlyList<ForgeFormula> GetForgeList()
		{
			IReadOnlyList<ForgeFormula> configList = ConfigForgeFormulaAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Forging, ELogAuthor.LK, "获取对应类型锻造数据列表失败，请检查锻造配方配置表是否正确", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x0603A168 RID: 237928 RVA: 0x00EB35F4 File Offset: 0x00EB17F4
		public IReadOnlyList<ForgeFormula> GetForgeListByType(int type)
		{
			IReadOnlyList<ForgeFormula> configList = ConfigForgeFormulaByTypeId.GetConfigList(type, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Forging;
				ELogAuthor author = ELogAuthor.LK;
				string message = "获取对应类型锻造数据失败，请检查锻造配方配置表是否正确";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("TypeId=", type);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}
	}
}
