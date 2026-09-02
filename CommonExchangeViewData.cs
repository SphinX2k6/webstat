using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

// Token: 0x0200204E RID: 8270
[NullableContext(1)]
[Nullable(0)]
public class CommonExchangeViewData
{
	// Token: 0x0600FBE8 RID: 64488 RVA: 0x00452C2A File Offset: 0x00450E2A
	public void CreateData(CommonExchangeData exchangeData, int maxEx = 0, int ownNum = 0)
	{
		this.MaxExchangeTime = maxEx;
		this.OwnSrcItemNum = ownNum;
		this.ExchangeData = exchangeData;
	}

	// Token: 0x040078ED RID: 30957
	public int MaxExchangeTime;

	// Token: 0x040078EE RID: 30958
	public int OwnSrcItemNum;

	// Token: 0x040078EF RID: 30959
	[Nullable(2)]
	public CommonExchangeData ExchangeData;

	// Token: 0x040078F0 RID: 30960
	public int StartSliderValue;

	// Token: 0x040078F1 RID: 30961
	public List<int> ShowCurrencyList = new List<int>();

	// Token: 0x040078F2 RID: 30962
	public Func<int, int, int> GetConsumeCount = (int itemId, int exchangeCount) => 0;

	// Token: 0x040078F3 RID: 30963
	public Func<int, int, int> GetConsumeTotalCount = (int consumeCount, int exchangeTime) => 0;

	// Token: 0x040078F4 RID: 30964
	public Func<int, int, int> GetGainCount = (int itemId, int exchangeCount) => 0;
}
