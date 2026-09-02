using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000E15 RID: 3605
public class FixedCameraGravity : BaseCameraGravity
{
	// Token: 0x06005527 RID: 21799 RVA: 0x000D8016 File Offset: 0x000D6216
	protected override void SetCameraGravityMode()
	{
		base.InternalSetCameraGravityMode(ECameraGravityMode.FixedGravityDirect);
	}

	// Token: 0x06005528 RID: 21800 RVA: 0x000D801F File Offset: 0x000D621F
	[NullableContext(1)]
	public override Vector GravityEndLerpVector()
	{
		this.EndLerpGravityVector.DeepCopy(this.CameraGravityConfig.TargetGravity);
		return this.EndLerpGravityVector;
	}
}
