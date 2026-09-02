using System;

// Token: 0x02002752 RID: 10066
public class ReconnectResult
{
	// Token: 0x06013DEC RID: 81388 RVA: 0x005897F1 File Offset: 0x005879F1
	public ReconnectResult(EReconnectResult result, EReconnectProcessStep step, int? errorCode = null, bool isPermittedSilentLogin = false)
	{
		this.Result = result;
		this.Step = step;
		this.ErrorCode = errorCode;
		this.IsPermittedSilentLogin = isPermittedSilentLogin;
	}

	// Token: 0x04009A87 RID: 39559
	public EReconnectResult Result;

	// Token: 0x04009A88 RID: 39560
	public EReconnectProcessStep Step = EReconnectProcessStep.Max;

	// Token: 0x04009A89 RID: 39561
	public int? ErrorCode;

	// Token: 0x04009A8A RID: 39562
	public bool IsPermittedSilentLogin;
}
