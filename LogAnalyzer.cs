using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using CSharpScript.Typing;
using UnrealEngine;
using UnrealEngine.Bulitin.Utils;

// Token: 0x0200004B RID: 75
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class LogAnalyzer : Singleton<LogAnalyzer>
{
	// Token: 0x06000133 RID: 307 RVA: 0x000085E0 File Offset: 0x000067E0
	public void SetPlayerId(int playerId)
	{
		this.PlayerId = playerId;
	}

	// Token: 0x06000134 RID: 308 RVA: 0x000085EC File Offset: 0x000067EC
	public void SetP4Version(string version)
	{
		this.P4Version = version;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Log;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "P4Version信息";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("P4Version", this.P4Version);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06000135 RID: 309 RVA: 0x0000862A File Offset: 0x0000682A
	public string GetP4Version()
	{
		return this.P4Version;
	}

	// Token: 0x06000136 RID: 310 RVA: 0x00008634 File Offset: 0x00006834
	public void SetBranch(string inBranch)
	{
		string text = inBranch;
		if (text.StartsWith("branch_"))
		{
			text = text.Substring("branch_".Length);
		}
		this.Branch = text;
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Log;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "Branch信息";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Branch", this.Branch);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x06000137 RID: 311 RVA: 0x00008692 File Offset: 0x00006892
	public string GetBranch()
	{
		return this.Branch;
	}

	// Token: 0x06000138 RID: 312 RVA: 0x0000869C File Offset: 0x0000689C
	public unsafe void Initialize(bool enable, string branch)
	{
		this.SetBranch(branch);
		if (!enable)
		{
			return;
		}
		this.InitCounter();
		this.InitReport();
		int inVerbosity = 2;
		FLogDelegate flogDelegate = global::DelegateUtils.ToManualReleaseDelegate<FLogDelegate>(new Action<FName, int, string, string>(this.EngineLogHandle));
		bool flag = UKuroLogAnalyzerLibrary.Initialize(inVerbosity, flogDelegate, 4096);
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Log;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "LogAnalyzer.Initialize";
		<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("结果", flag);
		*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("Branch", this.Branch);
		instance.Info(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
	}

	// Token: 0x06000139 RID: 313 RVA: 0x0000873C File Offset: 0x0000693C
	public void Clear()
	{
		bool flag = UKuroLogAnalyzerLibrary.Clear();
		Log instance = Singleton<Log>.Instance;
		ELogModule module = ELogModule.Log;
		ELogAuthor author = ELogAuthor.LFJW;
		string message = "LogAnalyzer.Clear";
		ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("结果", flag);
		instance.Info(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
	}

	// Token: 0x0600013A RID: 314 RVA: 0x0000877C File Offset: 0x0000697C
	private unsafe void InitCounter()
	{
		Singleton<Log>.Instance.Delegate = new Action<int, global::ELogLevel, ELogModule, ELogAuthor, string, UnsafeStringBuilder, string>(this.Count);
		int num9 = Enum.GetNames(typeof(global::ELogLevel)).Length;
		this.LevelStatistics = new int[num9];
		int num2 = Enum.GetNames(typeof(ELogAuthor)).Length;
		this.AuthorStatistics = new int[num2];
		int num3 = Enum.GetNames(typeof(ELogModule)).Length;
		this.ModuleStatistics = new int[num3];
		if (this.StatisticsTimer != null)
		{
			TimerSystem.Instance.Remove(this.StatisticsTimer);
			this.StatisticsTimer = null;
		}
		int num = 0;
		this.StatisticsTimer = TimerSystem.GameplayTimeInstance.Forever(delegate(float delta)
		{
			num++;
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.Log;
			ELogAuthor author = ELogAuthor.LCC;
			string message = "日志级别统计";
			<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray = default(<>y__InlineArray2<ValueTuple<string, object>>);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 0) = new ValueTuple<string, object>("num", num);
			*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray, 1) = new ValueTuple<string, object>("detail", this.LevelStatistics);
			instance.Warn(module, author, message, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray, 2));
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('{');
			for (int i = 0; i < this.LevelStatistics.Length; i++)
			{
				if (i > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append('"');
				stringBuilder.Append(i);
				stringBuilder.Append("\":");
				stringBuilder.Append(this.LevelStatistics[i]);
				this.LevelStatistics[i] = 0;
			}
			stringBuilder.Append('}');
			this.Track("log_level_report", new LogReportRecord(this.PlayerId, num, stringBuilder, null, null));
			List<ValueTuple<ELogModule, int>> list = new List<ValueTuple<ELogModule, int>>();
			for (int j = 0; j < this.ModuleStatistics.Length; j++)
			{
				int num4 = this.ModuleStatistics[j];
				if (num4 > 10)
				{
					list.Add(new ValueTuple<ELogModule, int>((ELogModule)j, num4));
				}
				this.ModuleStatistics[j] = 0;
			}
			if (list.Count > 0)
			{
				list.Sort((ValueTuple<ELogModule, int> a, ValueTuple<ELogModule, int> b) => b.Item2.CompareTo(a.Item2));
				LogAnalyzer.KeepTop<ValueTuple<ELogModule, int>>(list, 10);
				Log instance2 = Singleton<Log>.Instance;
				ELogModule module2 = ELogModule.Log;
				ELogAuthor author2 = ELogAuthor.LCC;
				string message2 = "模块输出统计";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray2 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 0) = new ValueTuple<string, object>("num", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray2, 1) = new ValueTuple<string, object>("detail", list);
				instance2.Warn(module2, author2, message2, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray2, 2));
				StringBuilder stringBuilder2 = new StringBuilder();
				stringBuilder2.Append('{');
				for (int k = 0; k < list.Count; k++)
				{
					if (k > 0)
					{
						stringBuilder2.Append(',');
					}
					ValueTuple<ELogModule, int> valueTuple = list[k];
					stringBuilder2.Append('"');
					stringBuilder2.Append(valueTuple.Item1.ToEnumString());
					stringBuilder2.Append("\":");
					stringBuilder2.Append(valueTuple.Item2);
				}
				stringBuilder2.Append('}');
				this.Track("log_module_report", new LogReportRecord(this.PlayerId, num, stringBuilder2, null, null));
			}
			List<ValueTuple<FName, int>> list2 = new List<ValueTuple<FName, int>>();
			foreach (KeyValuePair<FName, int> keyValuePair in this.EngineCategoryStatistics)
			{
				if (keyValuePair.Value > 10)
				{
					list2.Add(new ValueTuple<FName, int>(keyValuePair.Key, keyValuePair.Value));
				}
			}
			this.EngineCategoryStatistics.Clear();
			if (list2.Count > 0)
			{
				list2.Sort((ValueTuple<FName, int> a, ValueTuple<FName, int> b) => b.Item2.CompareTo(a.Item2));
				LogAnalyzer.KeepTop<ValueTuple<FName, int>>(list2, 10);
				Log instance3 = Singleton<Log>.Instance;
				ELogModule module3 = ELogModule.Log;
				ELogAuthor author3 = ELogAuthor.LCC;
				string message3 = "Category输出统计";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray3 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 0) = new ValueTuple<string, object>("num", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray3, 1) = new ValueTuple<string, object>("detail", list2);
				instance3.Warn(module3, author3, message3, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray3, 2));
				StringBuilder stringBuilder3 = new StringBuilder();
				stringBuilder3.Append('{');
				for (int l = 0; l < list2.Count; l++)
				{
					if (l > 0)
					{
						stringBuilder3.Append(',');
					}
					ValueTuple<FName, int> valueTuple2 = list2[l];
					stringBuilder3.Append('"');
					stringBuilder3.Append(LogRecordJsonWriter.EscapeJsString(valueTuple2.Item1.ToString()));
					stringBuilder3.Append("\":");
					stringBuilder3.Append(valueTuple2.Item2);
				}
				stringBuilder3.Append('}');
				this.Track("log_engine_category_report", new LogReportRecord(this.PlayerId, num, stringBuilder3, null, null));
			}
			List<ValueTuple<string, int>> list3 = new List<ValueTuple<string, int>>();
			for (int m = 0; m < this.AuthorStatistics.Length; m++)
			{
				int num5 = this.AuthorStatistics[m];
				if (num5 > 10)
				{
					list3.Add(new ValueTuple<string, int>(LogDefine.logAuthorInfo[m].Item1, num5));
				}
			}
			for (int n = 0; n < this.AuthorStatistics.Length; n++)
			{
				this.AuthorStatistics[n] = 0;
			}
			if (list3.Count > 0)
			{
				list3.Sort(([Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<string, int> a, [Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<string, int> b) => b.Item2.CompareTo(a.Item2));
				LogAnalyzer.KeepTop<ValueTuple<string, int>>(list3, 10);
				Log instance4 = Singleton<Log>.Instance;
				ELogModule module4 = ELogModule.Log;
				ELogAuthor author4 = ELogAuthor.LCC;
				string message4 = "作者输出统计";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray4 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 0) = new ValueTuple<string, object>("num", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray4, 1) = new ValueTuple<string, object>("detail", list3);
				instance4.Warn(module4, author4, message4, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray4, 2));
				StringBuilder stringBuilder4 = new StringBuilder();
				stringBuilder4.Append('{');
				for (int num6 = 0; num6 < list3.Count; num6++)
				{
					if (num6 > 0)
					{
						stringBuilder4.Append(',');
					}
					ValueTuple<string, int> valueTuple3 = list3[num6];
					stringBuilder4.Append('"');
					stringBuilder4.Append(LogRecordJsonWriter.EscapeJsString(valueTuple3.Item1));
					stringBuilder4.Append("\":");
					stringBuilder4.Append(valueTuple3.Item2);
				}
				stringBuilder4.Append('}');
				this.Track("log_author_report", new LogReportRecord(this.PlayerId, num, stringBuilder4, null, null));
			}
			double num7 = (double)delta * 0.01;
			List<ValueTuple<string, int>> list4 = new List<ValueTuple<string, int>>();
			List<ValueTuple<string, int>> list5 = new List<ValueTuple<string, int>>();
			foreach (KeyValuePair<string, int> keyValuePair2 in this.MessageStatistics)
			{
				int value = keyValuePair2.Value;
				if ((double)value > num7)
				{
					list4.Add(new ValueTuple<string, int>(keyValuePair2.Key, value));
				}
				else if (value > 10)
				{
					list5.Add(new ValueTuple<string, int>(keyValuePair2.Key, value));
				}
			}
			this.MessageStatistics.Clear();
			if (list4.Count > 0)
			{
				Log instance5 = Singleton<Log>.Instance;
				ELogModule module5 = ELogModule.Log;
				ELogAuthor author5 = ELogAuthor.LCC;
				string message5 = "日志输出过多";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray5 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 0) = new ValueTuple<string, object>("num", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray5, 1) = new ValueTuple<string, object>("detail", list4);
				instance5.Error(module5, author5, message5, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray5, 2));
			}
			if (list5.Count > 0)
			{
				list5.Sort(([Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<string, int> a, [Nullable(new byte[]
				{
					0,
					1
				})] ValueTuple<string, int> b) => b.Item2.CompareTo(a.Item2));
				LogAnalyzer.KeepTop<ValueTuple<string, int>>(list5, 10);
				Log instance6 = Singleton<Log>.Instance;
				ELogModule module6 = ELogModule.Log;
				ELogAuthor author6 = ELogAuthor.LCC;
				string message6 = "日志输出统计";
				<>y__InlineArray2<ValueTuple<string, object>> <>y__InlineArray6 = default(<>y__InlineArray2<ValueTuple<string, object>>);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 0) = new ValueTuple<string, object>("num", num);
				*<PrivateImplementationDetails>.InlineArrayElementRef<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(ref <>y__InlineArray6, 1) = new ValueTuple<string, object>("detail", list5);
				instance6.Warn(module6, author6, message6, <PrivateImplementationDetails>.InlineArrayAsReadOnlySpan<<>y__InlineArray2<ValueTuple<string, object>>, ValueTuple<string, object>>(<>y__InlineArray6, 2));
				StringBuilder stringBuilder5 = new StringBuilder();
				stringBuilder5.Append('{');
				for (int num8 = 0; num8 < list5.Count; num8++)
				{
					if (num8 > 0)
					{
						stringBuilder5.Append(',');
					}
					ValueTuple<string, int> valueTuple4 = list5[num8];
					stringBuilder5.Append('"');
					stringBuilder5.Append(num8);
					stringBuilder5.Append("\":{\"Msg\":\"");
					stringBuilder5.Append(LogRecordJsonWriter.EscapeJsString(valueTuple4.Item1));
					stringBuilder5.Append("\",\"Count\":");
					stringBuilder5.Append(valueTuple4.Item2);
					stringBuilder5.Append('}');
				}
				stringBuilder5.Append('}');
				this.Track("log_message_report", new LogReportRecord(this.PlayerId, num, stringBuilder5, null, null));
			}
		}, 600000f, 1f, null, "LogAnalyzer.StatisticsTimer", false);
	}

	// Token: 0x0600013B RID: 315 RVA: 0x0000885C File Offset: 0x00006A5C
	private void InitReport()
	{
		if (this.ReportTimer != null)
		{
			TimerSystem.Instance.Remove(this.ReportTimer);
			this.ReportTimer = null;
		}
		int num = 0;
		this.ReportTimer = TimerSystem.Instance.Forever(delegate(float _)
		{
			int num;
			num++;
			this.ReportCount = 0;
			if (this.SimplifyReports.Count == 0)
			{
				return;
			}
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append('{');
			num = 0;
			foreach (KeyValuePair<string, int> keyValuePair in this.SimplifyReports)
			{
				if (num > 0)
				{
					stringBuilder.Append(',');
				}
				stringBuilder.Append('"');
				stringBuilder.Append(num);
				stringBuilder.Append("\":{\"Msg\":\"");
				stringBuilder.Append(LogRecordJsonWriter.EscapeJsString(keyValuePair.Key));
				stringBuilder.Append("\",\"Count\":");
				stringBuilder.Append(keyValuePair.Value);
				stringBuilder.Append('}');
				num++;
			}
			stringBuilder.Append('}');
			this.SimplifyReports.Clear();
			this.Track("log_report", new LogReportRecord(this.PlayerId, num, stringBuilder, this.P4Version, this.Branch));
		}, 60000f, 1f, null, null, true);
	}

	// Token: 0x0600013C RID: 316 RVA: 0x000088C8 File Offset: 0x00006AC8
	private void Count(int id, global::ELogLevel level, ELogModule module, ELogAuthor author, string message, [Nullable(2)] UnsafeStringBuilder context, string stack)
	{
		this.LogInternal(true, id, level, module, author, null, message, context, stack, null);
	}

	// Token: 0x0600013D RID: 317 RVA: 0x000088F1 File Offset: 0x00006AF1
	public bool NeedLogContext(global::ELogLevel level)
	{
		return level <= global::ELogLevel.Error && this.ReportCount < 10;
	}

	// Token: 0x0600013E RID: 318 RVA: 0x00008908 File Offset: 0x00006B08
	private void LogInternal(bool ts, int id, global::ELogLevel level, ELogModule module, ELogAuthor author, [Nullable(2)] string format, string message, [Nullable(2)] UnsafeStringBuilder context, string stack, FName? engineCategory = null)
	{
		this.LevelStatistics[(int)level]++;
		if (module < (ELogModule)this.ModuleStatistics.Length)
		{
			this.ModuleStatistics[(int)module]++;
		}
		this.AuthorStatistics[(int)author]++;
		if (ts)
		{
			LogAnalyzer.IncreaseCount<string>(this.MessageStatistics, message);
		}
		else
		{
			LogAnalyzer.IncreaseCount<string>(this.MessageStatistics, format);
			LogAnalyzer.IncreaseCount<FName>(this.EngineCategoryStatistics, engineCategory.Value);
		}
		if (level > global::ELogLevel.Error)
		{
			return;
		}
		if (this.ReportCount < 10)
		{
			this.ReportCount++;
			string msg = message;
			string context2;
			if (!ts && message != format)
			{
				msg = format;
				context2 = "{\"0\":{\"Key\":\"0\",\"Value\":\"" + LogRecordJsonWriter.EscapeJsString(message) + "\"}}";
			}
			else
			{
				context2 = ((context != null) ? context.ToString() : null);
			}
			this.Track("log", new LogRecord(this.P4Version, this.Branch, this.PlayerId, id, level, module, (engineCategory != null) ? engineCategory.GetValueOrDefault().ToString() : null, LogDefine.logAuthorInfo[(int)author].Item1, msg, context2, stack));
			return;
		}
		if (this.SimplifyReports.Count < 100)
		{
			string key = ts ? ((message.Length > 100) ? message.Substring(0, 100) : message) : format;
			LogAnalyzer.IncreaseCount<string>(this.SimplifyReports, key);
		}
	}

	// Token: 0x0600013F RID: 319 RVA: 0x00008A80 File Offset: 0x00006C80
	private unsafe static void IncreaseCount<TKey>(Dictionary<TKey, int> statistics, TKey key)
	{
		bool flag;
		(*CollectionsMarshal.GetValueRefOrAddDefault<TKey, int>(statistics, key, out flag))++;
	}

	// Token: 0x06000140 RID: 320 RVA: 0x00008A9B File Offset: 0x00006C9B
	private static void KeepTop<[Nullable(2)] T>(List<T> list, int maxCount)
	{
		if (list.Count > maxCount)
		{
			list.RemoveRange(maxCount, list.Count - maxCount);
		}
	}

	// Token: 0x06000141 RID: 321 RVA: 0x00008AB8 File Offset: 0x00006CB8
	private bool Track(string eventName, ILogRecord content)
	{
		string text = LogRecordJsonWriter.Write(content);
		if (string.IsNullOrEmpty(text))
		{
			return false;
		}
		FThinkingAnalyticsForCSharp.Track(eventName, text, 0);
		FKuroAnalyticsForCSharp.Track(eventName, text, 0);
		return true;
	}

	// Token: 0x06000142 RID: 322 RVA: 0x00008AEC File Offset: 0x00006CEC
	private void EngineLogHandle(FName category, int verbosity, string format, string message)
	{
		global::ELogLevel elogLevel;
		if (verbosity - 1 > 1)
		{
			if (verbosity != 3)
			{
				elogLevel = global::ELogLevel.Info;
			}
			else
			{
				elogLevel = global::ELogLevel.Warn;
			}
		}
		else
		{
			elogLevel = global::ELogLevel.Error;
		}
		global::ELogLevel elogLevel2 = elogLevel;
		if (elogLevel2 == global::ELogLevel.Info)
		{
			return;
		}
		this.LogInternal(false, Singleton<Log>.Instance.GenLogId(), elogLevel2, ELogModule.Engine, ELogAuthor.Engine, format, message, null, string.Empty, new FName?(category));
	}

	// Token: 0x04000145 RID: 325
	private const int STATISTICS_INTERVAL = 600000;

	// Token: 0x04000146 RID: 326
	private const double STATISTICS_MESSAGE_ERRO_THRESHOLD = 0.01;

	// Token: 0x04000147 RID: 327
	private const int STATISTICS_THRESHOLD = 10;

	// Token: 0x04000148 RID: 328
	private const int STATISTICS_MODULE_TOP_NUM = 10;

	// Token: 0x04000149 RID: 329
	private const int STATISTICS_ENGINE_CATEGORY_TOP_NUM = 10;

	// Token: 0x0400014A RID: 330
	private const int STATISTICS_AUTHOR_TOP_NUM = 10;

	// Token: 0x0400014B RID: 331
	private const int STATISTICS_MESSAGE_TOP_NUM = 10;

	// Token: 0x0400014C RID: 332
	private const int REPORT_INTERVAL = 60000;

	// Token: 0x0400014D RID: 333
	private const global::ELogLevel REPORT_LEVEL = global::ELogLevel.Error;

	// Token: 0x0400014E RID: 334
	private const int REPORT_NUM = 10;

	// Token: 0x0400014F RID: 335
	private const int SIMPLIFY_REPORT_NUM = 100;

	// Token: 0x04000150 RID: 336
	private const int SIMPLIFY_REPORT_MESSAGE_MAX_LENGTH = 100;

	// Token: 0x04000151 RID: 337
	private const string REPLACE_BRANCH_WORD = "branch_";

	// Token: 0x04000152 RID: 338
	private int[] LevelStatistics = Array.Empty<int>();

	// Token: 0x04000153 RID: 339
	private int[] ModuleStatistics = Array.Empty<int>();

	// Token: 0x04000154 RID: 340
	private readonly Dictionary<FName, int> EngineCategoryStatistics = new Dictionary<FName, int>();

	// Token: 0x04000155 RID: 341
	private int[] AuthorStatistics = Array.Empty<int>();

	// Token: 0x04000156 RID: 342
	private readonly Dictionary<string, int> MessageStatistics = new Dictionary<string, int>();

	// Token: 0x04000157 RID: 343
	[Nullable(2)]
	private TimerHandle StatisticsTimer;

	// Token: 0x04000158 RID: 344
	[Nullable(2)]
	private TimerHandle ReportTimer;

	// Token: 0x04000159 RID: 345
	private int ReportCount;

	// Token: 0x0400015A RID: 346
	private readonly Dictionary<string, int> SimplifyReports = new Dictionary<string, int>();

	// Token: 0x0400015B RID: 347
	private int PlayerId;

	// Token: 0x0400015C RID: 348
	private string P4Version;

	// Token: 0x0400015D RID: 349
	private string Branch;

	// Token: 0x0400015E RID: 350
	private readonly Stat StatisticsStat = Stat.Create("LogAnalyzer.Statistics", "", "");

	// Token: 0x0400015F RID: 351
	private readonly Stat ReportStat = Stat.Create("LogAnalyzer.Report", "", "");

	// Token: 0x04000160 RID: 352
	private readonly Stat CountStat = Stat.Create("LogAnalyzer.Count", "", "");

	// Token: 0x04000161 RID: 353
	private readonly Stat TrackStat = Stat.Create("LogAnalyzer.Track", "", "");
}
