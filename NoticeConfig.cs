using System;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x0200232A RID: 9002
[NullableContext(2)]
[Nullable(0)]
public class NoticeConfig
{
	// Token: 0x060111FD RID: 70141 RVA: 0x004B46B8 File Offset: 0x004B28B8
	public static string GetNoticeTitle()
	{
		return ConfigCommonParamLang.GetLocalText(ConfigCommonParamById.GetIntConfig("NoticeTitle").GetValueOrDefault(), null);
	}

	// Token: 0x060111FE RID: 70142 RVA: 0x004B46DD File Offset: 0x004B28DD
	public static string GetNoticeUrl()
	{
		return ConfigCommonParamById.GetStringConfig("NoticeUrl");
	}
}
