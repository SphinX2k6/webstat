using System;
using Aki.Config;

// Token: 0x02002567 RID: 9575
public class PhoneMsgInputTimeData
{
	// Token: 0x060129F6 RID: 76278 RVA: 0x0052223B File Offset: 0x0052043B
	public PhoneMsgInputTimeData(PhoneInputTime config)
	{
		this.DelayTime = config.DelayTime;
		this.MinChatNum = config.StartChatNum;
		this.MaxChatNum = config.EndChatNum;
	}

	// Token: 0x060129F7 RID: 76279 RVA: 0x0052226A File Offset: 0x0052046A
	public int GetDelayTime(int chatNum)
	{
		if (this.MinChatNum <= chatNum && (this.MaxChatNum == 0 || chatNum < this.MaxChatNum))
		{
			return this.DelayTime;
		}
		return -1;
	}

	// Token: 0x0400916B RID: 37227
	public int DelayTime;

	// Token: 0x0400916C RID: 37228
	public int MinChatNum;

	// Token: 0x0400916D RID: 37229
	public int MaxChatNum;
}
