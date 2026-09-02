using System;

// Token: 0x02003016 RID: 12310
public class GravityScale
{
	// Token: 0x06019168 RID: 102760 RVA: 0x00721AE4 File Offset: 0x0071FCE4
	public GravityScale(float scaleUp = 0f, float scaleDown = 0f, float scaleTop = 0f, float velocityTop = 0f, float duration = 0f, float elapsedTime = 0f, bool forceVelocityZero = false, bool enable = false)
	{
		this.ScaleUp = scaleUp;
		this.ScaleDown = scaleDown;
		this.ScaleTop = scaleTop;
		this.VelocityTop = velocityTop;
		this.Duration = duration;
		this.ElapsedTime = elapsedTime;
		this.ForceVelocityZero = forceVelocityZero;
		this.Enable = enable;
	}

	// Token: 0x0400C4A5 RID: 50341
	public float ScaleUp;

	// Token: 0x0400C4A6 RID: 50342
	public float ScaleDown;

	// Token: 0x0400C4A7 RID: 50343
	public float ScaleTop;

	// Token: 0x0400C4A8 RID: 50344
	public float VelocityTop;

	// Token: 0x0400C4A9 RID: 50345
	public float Duration;

	// Token: 0x0400C4AA RID: 50346
	public float ElapsedTime;

	// Token: 0x0400C4AB RID: 50347
	public bool ForceVelocityZero;

	// Token: 0x0400C4AC RID: 50348
	public bool Enable;
}
