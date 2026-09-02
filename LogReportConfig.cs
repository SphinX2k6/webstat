using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200210B RID: 8459
[Nullable(new byte[]
{
	0,
	1
})]
[Config(0)]
public class LogReportConfig : ConfigBase<LogReportConfig>
{
	// Token: 0x0601032B RID: 66347 RVA: 0x0047477C File Offset: 0x0047297C
	public BeginnerGuide? GetBeginnerGuideConfig(int id)
	{
		BeginnerGuide? config = ConfigBeginnerGuideById.GetConfig(id, true);
		if (config == null)
		{
			Log instance = Singleton<Log>.Instance;
			ELogModule module = ELogModule.LogReport;
			ELogAuthor author = ELogAuthor.ZJC;
			string message = "新手打点表分表BeginnerGuide配置找不到";
			ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("Id", id);
			instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
		}
		return config;
	}
}
