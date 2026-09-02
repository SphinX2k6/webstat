using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02000E10 RID: 3600
[NullableContext(1)]
[Nullable(0)]
public class CameraGravityConfig
{
	// Token: 0x060054F6 RID: 21750 RVA: 0x000D7334 File Offset: 0x000D5534
	public void SetConfig(SCamera_ChangeGravity config)
	{
		if (config == null)
		{
			return;
		}
		this.GravityMode = config.GravityMode;
		Vector targetGravity = this.TargetGravity;
		FVector targetGravity2 = config.TargetGravity;
		FVectorDouble fvectorDouble = targetGravity2;
		targetGravity.DeepCopy(fvectorDouble);
		this.LerpMode = config.LerpMode;
		this.LerpTime = config.LerpTime;
		this.LerpTimeCurve = config.LerpTimeCurve;
		this.LerpAngleVelocity = config.LerpAngleVelocity;
		this.LerpAngleWhenFinish = config.LerpAngleWhenFinish;
	}

	// Token: 0x060054F7 RID: 21751 RVA: 0x000D73BC File Offset: 0x000D55BC
	public void DeepCopy(CameraGravityConfig config)
	{
		if (config == null)
		{
			return;
		}
		this.GravityMode = config.GravityMode;
		this.TargetGravity.DeepCopy(config.TargetGravity);
		this.LerpMode = config.LerpMode;
		this.LerpTime = config.LerpTime;
		this.LerpTimeCurve = config.LerpTimeCurve;
		this.LerpAngleVelocity = config.LerpAngleVelocity;
		this.LerpAngleWhenFinish = config.LerpAngleWhenFinish;
	}

	// Token: 0x060054F8 RID: 21752 RVA: 0x000D7428 File Offset: 0x000D5628
	public void Reset()
	{
		this.GravityMode = ECameraGravityMode.CameraTargetGravityDirect;
		Vector targetGravity = this.TargetGravity;
		FVectorDouble fvectorDouble = Vector.DownVector;
		targetGravity.DeepCopy(fvectorDouble);
		this.LerpMode = ECameraGravityLerpMode.None;
		this.LerpTime = 0f;
		this.LerpTimeCurve = null;
		this.LerpAngleVelocity = 0f;
		this.LerpAngleWhenFinish = false;
	}

	// Token: 0x060054F9 RID: 21753 RVA: 0x000D7480 File Offset: 0x000D5680
	public override string ToString()
	{
		DefaultInterpolatedStringHandler defaultInterpolatedStringHandler = new DefaultInterpolatedStringHandler(75, 5);
		defaultInterpolatedStringHandler.AppendLiteral("GravityMode: ");
		defaultInterpolatedStringHandler.AppendFormatted<ECameraGravityMode>(this.GravityMode);
		defaultInterpolatedStringHandler.AppendLiteral(", TargetGravity: ");
		defaultInterpolatedStringHandler.AppendFormatted(this.TargetGravity.ToString());
		defaultInterpolatedStringHandler.AppendLiteral(", LerpMode: ");
		defaultInterpolatedStringHandler.AppendFormatted<ECameraGravityLerpMode>(this.LerpMode);
		defaultInterpolatedStringHandler.AppendLiteral(", LerpTime: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.LerpTime);
		defaultInterpolatedStringHandler.AppendLiteral(", LerpAngleVelocity: ");
		defaultInterpolatedStringHandler.AppendFormatted<float>(this.LerpAngleVelocity);
		return defaultInterpolatedStringHandler.ToStringAndClear();
	}

	// Token: 0x04001A10 RID: 6672
	public ECameraGravityMode GravityMode;

	// Token: 0x04001A11 RID: 6673
	public Vector TargetGravity = Vector.Create();

	// Token: 0x04001A12 RID: 6674
	public ECameraGravityLerpMode LerpMode;

	// Token: 0x04001A13 RID: 6675
	public float LerpTime;

	// Token: 0x04001A14 RID: 6676
	[Nullable(2)]
	public UCurveFloat LerpTimeCurve;

	// Token: 0x04001A15 RID: 6677
	public float LerpAngleVelocity;

	// Token: 0x04001A16 RID: 6678
	public bool LerpAngleWhenFinish;
}
