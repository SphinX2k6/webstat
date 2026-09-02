using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.Sheriff
{
	// Token: 0x02004FA6 RID: 20390
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class SheriffConfig : ConfigBase<SheriffConfig>
	{
		// Token: 0x060349F9 RID: 215545 RVA: 0x00D3368C File Offset: 0x00D3188C
		public SheriffAnomaly? GetAnomalyConfigById(int id)
		{
			SheriffAnomaly? config = ConfigSheriffAnomalyById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffAnomaly数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060349FA RID: 215546 RVA: 0x00D336DC File Offset: 0x00D318DC
		public SheriffClue? GetClueConfigById(int id)
		{
			SheriffClue? config = ConfigSheriffClueById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffClue数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060349FB RID: 215547 RVA: 0x00D3372C File Offset: 0x00D3192C
		public SheriffAnomaly? GetAnomalyConfigByQuestionId(int questionId)
		{
			SheriffAnomaly? config = ConfigSheriffAnomalyByQuestionId.GetConfig(questionId, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffAnomaly数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("QuestionId", questionId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060349FC RID: 215548 RVA: 0x00D3377C File Offset: 0x00D3197C
		public IReadOnlyList<SheriffClue> GetAllClueConfig()
		{
			IReadOnlyList<SheriffClue> configList = ConfigSheriffClueAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.WHJ, "SheriffClue数据无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			IReadOnlyList<SheriffClue> readOnlyList = configList;
			return readOnlyList ?? new List<SheriffClue>();
		}

		// Token: 0x060349FD RID: 215549 RVA: 0x00D337BC File Offset: 0x00D319BC
		public SheriffCriminal? GetCriminalConfigById(int id)
		{
			SheriffCriminal? config = ConfigSheriffCriminalById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffCriminal数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060349FE RID: 215550 RVA: 0x00D3380C File Offset: 0x00D31A0C
		public SheriffCriminal? GetCriminalConfigByIdentityId(int identityId)
		{
			IReadOnlyList<SheriffCriminal> configList = ConfigSheriffCriminalByIdentityId.GetConfigList(identityId, true);
			SheriffCriminal? result = (configList != null && configList.Count > 0) ? new SheriffCriminal?(configList[0]) : null;
			if (result == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffCriminal数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("IdentityId", identityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return result;
		}

		// Token: 0x060349FF RID: 215551 RVA: 0x00D33880 File Offset: 0x00D31A80
		public SheriffEnding? GetEndingConfigById(int id)
		{
			SheriffEnding? config = ConfigSheriffEndingById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffEnding数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A00 RID: 215552 RVA: 0x00D338D0 File Offset: 0x00D31AD0
		public SheriffIdentity? GetIdentityConfigById(int id)
		{
			SheriffIdentity? config = ConfigSheriffIdentityById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffIdentity数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A01 RID: 215553 RVA: 0x00D33920 File Offset: 0x00D31B20
		public SheriffProgress? GetProgressConfigById(int id)
		{
			SheriffProgress? config = ConfigSheriffProgressById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffProgress数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A02 RID: 215554 RVA: 0x00D33970 File Offset: 0x00D31B70
		public SheriffZone? GetZoneConfigById(int id)
		{
			SheriffZone? config = ConfigSheriffZoneById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffZone数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A03 RID: 215555 RVA: 0x00D339C0 File Offset: 0x00D31BC0
		public IReadOnlyList<SheriffZone> GetZoneConfigAll()
		{
			IReadOnlyList<SheriffZone> configList = ConfigSheriffZoneAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.WHJ, "SheriffZone数据无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			IReadOnlyList<SheriffZone> readOnlyList = configList;
			return readOnlyList ?? new List<SheriffZone>();
		}

		// Token: 0x06034A04 RID: 215556 RVA: 0x00D33A00 File Offset: 0x00D31C00
		public SheriffQuestionMainCsv? GetQuestionMainById(int id)
		{
			SheriffQuestionMainCsv? config = ConfigSheriffQuestionMainCsvById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffQuestionMain数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A05 RID: 215557 RVA: 0x00D33A50 File Offset: 0x00D31C50
		public SheriffQuestionCsv? GetQuestionById(int id)
		{
			SheriffQuestionCsv? config = ConfigSheriffQuestionCsvById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.WHJ;
				string message = "SheriffQuestion数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A06 RID: 215558 RVA: 0x00D33AA0 File Offset: 0x00D31CA0
		public SheriffMap? GetMapConfigById(int id)
		{
			SheriffMap? config = ConfigSheriffMapById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.CB;
				string message = "SheriffMap数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x06034A07 RID: 215559 RVA: 0x00D33AF0 File Offset: 0x00D31CF0
		public SheriffAnomaly? GetAnomalyConfigByMarkId(int markId)
		{
			SheriffAnomaly? config = ConfigSheriffAnomalyByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.CB, "SheriffAnomaly数据无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return config;
		}

		// Token: 0x06034A08 RID: 215560 RVA: 0x00D33B30 File Offset: 0x00D31D30
		public SheriffQuest? GetQuestConfigByMarkId(int markId)
		{
			SheriffQuest? config = ConfigSheriffQuestByMarkId.GetConfig(markId, true);
			if (config == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.CB, "SheriffQuest数据无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return config;
		}

		// Token: 0x06034A09 RID: 215561 RVA: 0x00D33B70 File Offset: 0x00D31D70
		public SheriffQuest? GetQuestConfigByQuestId(int questId)
		{
			SheriffQuest? config = ConfigSheriffQuestByQuestId.GetConfig(questId, true);
			if (config == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.CB, "SheriffQuest数据无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return config;
		}

		// Token: 0x06034A0A RID: 215562 RVA: 0x00D33BB0 File Offset: 0x00D31DB0
		[NullableContext(2)]
		public IReadOnlyList<SheriffQuest> GetQuestConfigByZoneId(int zoneId)
		{
			IReadOnlyList<SheriffQuest> configList = ConfigSheriffQuestByZoneId.GetConfigList(zoneId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.CB;
				string message = "SheriffQuest数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("ZoneId", zoneId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return configList;
		}

		// Token: 0x06034A0B RID: 215563 RVA: 0x00D33BF8 File Offset: 0x00D31DF8
		public SheriffAnomaly? GetAnomalyConfigByCriminalId(int criminalId)
		{
			SheriffAnomaly? config = ConfigSheriffAnomalyByCriminalId.GetConfig(criminalId, true);
			if (config == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.Sheriff, ELogAuthor.CB, "SheriffAnomaly数据无效", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return config;
		}

		// Token: 0x06034A0C RID: 215564 RVA: 0x00D33C38 File Offset: 0x00D31E38
		public IReadOnlyList<SheriffProgress> GetProgressConfigListByAnomalyId(int anomalyId)
		{
			IReadOnlyList<SheriffProgress> configList = ConfigSheriffProgressBySheriffAnomalyId.GetConfigList(anomalyId, true);
			if (configList == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.Sheriff;
				ELogAuthor author = ELogAuthor.CB;
				string message = "SheriffProgress数据无效";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", anomalyId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			IReadOnlyList<SheriffProgress> readOnlyList = configList;
			return readOnlyList ?? new List<SheriffProgress>();
		}
	}
}
