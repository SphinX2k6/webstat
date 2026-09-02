using System;

// Token: 0x02000D74 RID: 3444
internal class RotateToPlayerParam
{
	// Token: 0x06004AFC RID: 19196 RVA: 0x000A4D73 File Offset: 0x000A2F73
	public RotateToPlayerParam(float total)
	{
		this.NowTime = 0f;
		this.TotalDurationReciprocal = 1f / total;
	}

	// Token: 0x06004AFD RID: 19197 RVA: 0x000A4D93 File Offset: 0x000A2F93
	public void Update(float now, float total)
	{
		this.NowTime = now;
		this.TotalDurationReciprocal = 1f / total;
	}

	// Token: 0x04001560 RID: 5472
	public float NowTime;

	// Token: 0x04001561 RID: 5473
	public float TotalDurationReciprocal;
}
