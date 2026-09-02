using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

// Token: 0x02000E12 RID: 3602
[NullableContext(1)]
[Nullable(0)]
public class CameraGravityDirectionConfig
{
	// Token: 0x0600551A RID: 21786 RVA: 0x000D7EDC File Offset: 0x000D60DC
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
	}

	// Token: 0x0600551B RID: 21787 RVA: 0x000D7F20 File Offset: 0x000D6120
	public void DeepCopy(CameraGravityDirectionConfig config)
	{
		if (config == null)
		{
			return;
		}
		this.GravityMode = config.GravityMode;
		this.TargetGravity.DeepCopy(config.TargetGravity);
	}

	// Token: 0x0600551C RID: 21788 RVA: 0x000D7F44 File Offset: 0x000D6144
	public void Reset()
	{
		this.GravityMode = ECameraGravityMode.CameraTargetGravityDirect;
		Vector targetGravity = this.TargetGravity;
		FVectorDouble fvectorDouble = Vector.DownVector;
		targetGravity.DeepCopy(fvectorDouble);
	}

	// Token: 0x04001A26 RID: 6694
	public ECameraGravityMode GravityMode;

	// Token: 0x04001A27 RID: 6695
	public Vector TargetGravity = Vector.Create();
}
