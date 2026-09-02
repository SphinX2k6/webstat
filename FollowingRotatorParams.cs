using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Level.KeepFollowing;

// Token: 0x020030D7 RID: 12503
public class FollowingRotatorParams
{
	// Token: 0x06019CC9 RID: 105673 RVA: 0x00787FDC File Offset: 0x007861DC
	[NullableContext(2)]
	public FollowingRotatorParams(BP_KeepFollowingConfig_C data = null)
	{
		if (data != null)
		{
			this.ToleranceRotatorAngle = (float)data.转向角度容差;
			this.MaxRotatorDuration = (float)data.最大转向持续时间;
			this.RotatorSpeed = (float)data.转向速度;
		}
	}

	// Token: 0x0400CE31 RID: 52785
	public float RotatorSpeed = 360f;

	// Token: 0x0400CE32 RID: 52786
	public float ToleranceRotatorAngle = 10f;

	// Token: 0x0400CE33 RID: 52787
	public float MaxRotatorDuration = 400f;
}
