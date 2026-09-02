using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

namespace CSharpScript.Game.Module.QuestMultiLine
{
	// Token: 0x02005312 RID: 21266
	[NullableContext(2)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Config(0)]
	public class QuestMultiLineConfig : ConfigBase<QuestMultiLineConfig>
	{
		// Token: 0x0603649C RID: 222364 RVA: 0x00DAF1D7 File Offset: 0x00DAD3D7
		protected override bool OnInit()
		{
			return true;
		}

		// Token: 0x0603649D RID: 222365 RVA: 0x00DAF1DA File Offset: 0x00DAD3DA
		protected override bool OnClear()
		{
			return true;
		}

		// Token: 0x0603649E RID: 222366 RVA: 0x00DAF1E0 File Offset: 0x00DAD3E0
		public static QuestTimePointConfig? GetTimePointConfigById(int id)
		{
			QuestTimePointConfig? config = ConfigQuestTimePointConfigById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestTimePointConfig表 无效id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x0603649F RID: 222367 RVA: 0x00DAF230 File Offset: 0x00DAD430
		public static QuestTimeComponentConfig? GetComponentConfigById(int id)
		{
			QuestTimeComponentConfig? config = ConfigQuestTimeComponentConfigById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestTimeComponentConfig表 无效id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060364A0 RID: 222368 RVA: 0x00DAF280 File Offset: 0x00DAD480
		public static QuestComponentStatusType? GetComponentStatusConfigById(int id)
		{
			QuestComponentStatusType? config = ConfigQuestComponentStatusTypeById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestComponentStatusType表 无效Id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060364A1 RID: 222369 RVA: 0x00DAF2D0 File Offset: 0x00DAD4D0
		public static QuestBranchPageConfig? GetBranchPageConfigById(int id)
		{
			QuestBranchPageConfig? config = ConfigQuestBranchPageConfigById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestBranchPageConfig表 无效id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060364A2 RID: 222370 RVA: 0x00DAF320 File Offset: 0x00DAD520
		public static QuestBranchConfig? GetQuestBranchConfig(int id)
		{
			QuestBranchConfig? config = ConfigQuestBranchConfigById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestBranchConfig表 无效id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}

		// Token: 0x060364A3 RID: 222371 RVA: 0x00DAF370 File Offset: 0x00DAD570
		public static IReadOnlyList<QuestTimePointConfig> GetAllTimePointConfigs()
		{
			IReadOnlyList<QuestTimePointConfig> configList = ConfigQuestTimePointConfigAll.GetConfigList(true);
			if (configList == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.QuestMultiLine, ELogAuthor.CCJ, "QuestTimePointConfig表无数据", default(ReadOnlySpan<ValueTuple<string, object>>));
			}
			return configList;
		}

		// Token: 0x060364A4 RID: 222372 RVA: 0x00DAF3A8 File Offset: 0x00DAD5A8
		public static QuestBranchComponentGroup? GetBranchComponentGroupConfig(int id)
		{
			QuestBranchComponentGroup? config = ConfigQuestBranchComponentGroupById.GetConfig(id, true);
			if (config == null)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.QuestMultiLine;
				ELogAuthor author = ELogAuthor.CCJ;
				string message = "QuestBranchComponentGroup表 无效id";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("id", id);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
			}
			return config;
		}
	}
}
