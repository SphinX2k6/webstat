using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Config;

// Token: 0x02002760 RID: 10080
[NullableContext(1)]
[Nullable(new byte[]
{
	0,
	1
})]
public class ReportConfig : Singleton<ReportConfig>
{
	// Token: 0x06013E52 RID: 81490 RVA: 0x0058B489 File Offset: 0x00589689
	public IReadOnlyList<ReportPlayerInfo> GetReportConfigList()
	{
		return ConfigReportPlayerInfoAll.GetConfigList(true);
	}

	// Token: 0x06013E53 RID: 81491 RVA: 0x0058B491 File Offset: 0x00589691
	public BanInfo? GetBanInfoById(int id)
	{
		return ConfigBanInfoById.GetConfig(id, true);
	}

	// Token: 0x06013E54 RID: 81492 RVA: 0x0058B49A File Offset: 0x0058969A
	public BanInfo? GetBanInfoByTypeAndReason(int typeId, int reasonId)
	{
		return ConfigBanInfoByTypeAndReason.GetConfig(typeId, reasonId, true);
	}
}
