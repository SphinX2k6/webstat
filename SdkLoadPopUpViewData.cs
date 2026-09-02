using System;
using System.Runtime.CompilerServices;

// Token: 0x02002972 RID: 10610
[NullableContext(1)]
[Nullable(0)]
public class SdkLoadPopUpViewData
{
	// Token: 0x06015161 RID: 86369 RVA: 0x005D5892 File Offset: 0x005D3A92
	public static SdkLoadPopUpViewData Create(int forceCloseTime, string openReason)
	{
		return new SdkLoadPopUpViewData
		{
			ForceCloseTime = forceCloseTime,
			OpenReason = openReason
		};
	}

	// Token: 0x0400A266 RID: 41574
	public int ForceCloseTime = 5;

	// Token: 0x0400A267 RID: 41575
	public string OpenReason = "";
}
