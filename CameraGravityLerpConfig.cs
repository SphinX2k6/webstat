using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02000E18 RID: 3608
[NullableContext(1)]
[Nullable(0)]
public class CameraGravityLerpConfig
{
	// Token: 0x0600552E RID: 21806 RVA: 0x000D81B0 File Offset: 0x000D63B0
	public void SetConfig(SCamera_ChangeGravity config)
	{
		if (config == null)
		{
			return;
		}
		this.LerpMode = config.LerpMode;
		this.LerpTime = config.LerpTime;
		this.LerpAngleVelocity = config.LerpAngleVelocity;
		this.LerpAngleWhenFinish = config.LerpAngleWhenFinish;
	}

	// Token: 0x0600552F RID: 21807 RVA: 0x000D81FC File Offset: 0x000D63FC
	public void DeepCopy(CameraGravityLerpConfig config)
	{
		if (config == null)
		{
			return;
		}
		this.LerpMode = config.LerpMode;
		this.LerpTime = config.LerpTime;
		this.LerpTimeCurve = config.LerpTimeCurve;
		this.LerpAngleVelocity = config.LerpAngleVelocity;
		this.LerpAngleWhenFinish = config.LerpAngleWhenFinish;
	}

	// Token: 0x06005530 RID: 21808 RVA: 0x000D8249 File Offset: 0x000D6449
	public void Reset()
	{
		this.LerpMode = ECameraGravityLerpMode.None;
		this.LerpTime = 0f;
		this.LerpTimeCurve = null;
		this.LerpAngleVelocity = 0f;
		this.LerpAngleWhenFinish = false;
	}

	// Token: 0x06005531 RID: 21809 RVA: 0x000D8278 File Offset: 0x000D6478
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(62, 4);
		defaultInterpolatedStringHandler.AppendLiteral("LerpMode:");
		defaultInterpolatedStringHandler.AppendFormatted<ECameraGravityLerpMode>(this.LerpMode);
		defaultInterpolatedStringHandler.AppendLiteral(", LerpTime:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.LerpTime);
		defaultInterpolatedStringHandler.AppendLiteral(", LerpAngleVelocity:");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.LerpAngleVelocity);
		defaultInterpolatedStringHandler.AppendLiteral(", LerpAngleWhenFinish:");
		defaultInterpolatedStringHandler.AppendFormatted<bool>(this.LerpAngleWhenFinish);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x04001A36 RID: 6710
	public ECameraGravityLerpMode LerpMode;

	// Token: 0x04001A37 RID: 6711
	public float LerpTime;

	// Token: 0x04001A38 RID: 6712
	[Nullable(2)]
	public UCurveFloat LerpTimeCurve;

	// Token: 0x04001A39 RID: 6713
	public float LerpAngleVelocity;

	// Token: 0x04001A3A RID: 6714
	public bool LerpAngleWhenFinish;
}
