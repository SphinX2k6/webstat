using System;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.BossPiling
{
	// Token: 0x02005EDF RID: 24287
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class BossPilingConfig : ConfigBase<BossPilingConfig>
	{
		// Token: 0x0603D073 RID: 249971 RVA: 0x00F80918 File Offset: 0x00F7EB18
		public BossPilingLevels? GetLevelInfo(int id)
		{
			BossPilingLevels? config = ConfigBossPilingLevelsById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BossPiling;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "BossPilingLevels数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603D074 RID: 249972 RVA: 0x00F80968 File Offset: 0x00F7EB68
		public BossPilingBuff? GetBuffInfo(int id)
		{
			BossPilingBuff? config = ConfigBossPilingBuffById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BossPiling;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "BossPilingBuff数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603D075 RID: 249973 RVA: 0x00F809B8 File Offset: 0x00F7EBB8
		public BossPilingTask? GetTaskInfo(int id)
		{
			BossPilingTask? config = ConfigBossPilingTaskById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.BossPiling;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "BossPilingTask数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603D076 RID: 249974 RVA: 0x00F80A08 File Offset: 0x00F7EC08
		public ValueTuple<int, int> GetTipsPlayRate()
		{
			if (this.RateConfig == null)
			{
				int item = ConfigCommonParamById.GetIntConfig("BossPilingBuffTipsNormalPlayRate").GetValueOrDefault(1000) / 1000;
				int item2 = ConfigCommonParamById.GetIntConfig("BossPilingBuffTipsFastPlayRate").GetValueOrDefault(2000) / 1000;
				this.RateConfig = new ValueTuple<int, int>?(new ValueTuple<int, int>(item, item2));
			}
			return this.RateConfig.Value;
		}

		// Token: 0x040223E3 RID: 140259
		protected ValueTuple<int, int>? RateConfig;
	}
}
