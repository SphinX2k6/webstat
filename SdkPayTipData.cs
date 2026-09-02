using System;
using System.Runtime.CompilerServices;

// Token: 0x02002971 RID: 10609
[NullableContext(1)]
[Nullable(0)]
public class SdkPayTipData
{
	// Token: 0x0601515F RID: 86367 RVA: 0x005D5833 File Offset: 0x005D3A33
	public static SdkPayTipData Create(string payStateSpritePath, string payResultTextId, string payContentTextId, int countDownTime, string countDownTextId)
	{
		return new SdkPayTipData
		{
			PayStateSpritePath = payStateSpritePath,
			PayResultTextId = payResultTextId,
			PayContentTextId = payContentTextId,
			CountDownTime = countDownTime,
			CountDownTextId = countDownTextId
		};
	}

	// Token: 0x0400A261 RID: 41569
	public string PayStateSpritePath = "";

	// Token: 0x0400A262 RID: 41570
	public string PayResultTextId = "";

	// Token: 0x0400A263 RID: 41571
	public string PayContentTextId = "";

	// Token: 0x0400A264 RID: 41572
	public int CountDownTime;

	// Token: 0x0400A265 RID: 41573
	public string CountDownTextId = "";
}
