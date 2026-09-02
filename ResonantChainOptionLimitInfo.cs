using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;

// Token: 0x02001CBE RID: 7358
[NullableContext(1)]
[Nullable(0)]
public class ResonantChainOptionLimitInfo
{
	// Token: 0x0600D7EE RID: 55278 RVA: 0x0039BF38 File Offset: 0x0039A138
	public ResonantChainOptionLimitInfo(int limitNum, ResonantChainOptionalLimitResponse response)
	{
		this.LimitNum = limitNum;
		foreach (ResonantChainOptionalLimitInfo resonantChainOptionalLimitInfo in response.Infos)
		{
			this.ItemInfos.Add(new ResonantChainOptionLimitItemInfo(resonantChainOptionalLimitInfo.ItemId, resonantChainOptionalLimitInfo.Count));
		}
	}

	// Token: 0x040066CF RID: 26319
	public int LimitNum;

	// Token: 0x040066D0 RID: 26320
	public List<ResonantChainOptionLimitItemInfo> ItemInfos = new List<ResonantChainOptionLimitItemInfo>();
}
