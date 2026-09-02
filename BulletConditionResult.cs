using System;

// Token: 0x02002DFC RID: 11772
public class BulletConditionResult
{
	// Token: 0x06017C6B RID: 97387 RVA: 0x006A05B2 File Offset: 0x0069E7B2
	public void Clear()
	{
		this.HasConstResult = false;
		this.ConstResult = false;
		this.KeepEnable = false;
		this.KeepDisable = false;
	}

	// Token: 0x0400B7A7 RID: 47015
	public bool HasConstResult;

	// Token: 0x0400B7A8 RID: 47016
	public bool ConstResult;

	// Token: 0x0400B7A9 RID: 47017
	public bool KeepEnable;

	// Token: 0x0400B7AA RID: 47018
	public bool KeepDisable;
}
