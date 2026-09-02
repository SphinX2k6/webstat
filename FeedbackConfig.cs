using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02001BA5 RID: 7077
[NullableContext(2)]
[Nullable(0)]
public class FeedbackConfig
{
	// Token: 0x0600CDD9 RID: 52697 RVA: 0x0036D7D8 File Offset: 0x0036B9D8
	public static string GetFeedbackTitle()
	{
		return ConfigCommonParamLang.GetLocalText(ConfigCommonParamById.GetIntConfig("FeedbackTitle").GetValueOrDefault(), null);
	}

	// Token: 0x0600CDDA RID: 52698 RVA: 0x0036D7FD File Offset: 0x0036B9FD
	public static string GetFeedbackPreUrl()
	{
		return ConfigCommonParamById.GetStringConfig("FeedbackUrl");
	}
}
