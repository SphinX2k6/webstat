using System;
using System.Runtime.CompilerServices;

// Token: 0x020021DF RID: 8671
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ThinkingAnalyticsReporter : Singleton<ThinkingAnalyticsReporter>
{
	// Token: 0x06010599 RID: 66969 RVA: 0x00477A52 File Offset: 0x00475C52
	public void Init()
	{
		Singleton<RealThinkingAnalyticsReporter>.Instance.Init();
		Singleton<RealKRAnalyticsReporter>.Instance.Init();
	}

	// Token: 0x0601059A RID: 66970 RVA: 0x00477A68 File Offset: 0x00475C68
	public void Report(string key, string jsonLog)
	{
		Singleton<RealThinkingAnalyticsReporter>.Instance.Report(key, jsonLog);
		Singleton<RealKRAnalyticsReporter>.Instance.Report(key, jsonLog);
	}
}
