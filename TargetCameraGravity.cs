using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000E16 RID: 3606
public class TargetCameraGravity : BaseCameraGravity
{
	// Token: 0x0600552A RID: 21802 RVA: 0x000D8045 File Offset: 0x000D6245
	protected override void SetCameraGravityMode()
	{
		base.InternalSetCameraGravityMode(ECameraGravityMode.CameraTargetGravityDirect);
	}

	// Token: 0x0600552B RID: 21803 RVA: 0x000D804E File Offset: 0x000D624E
	[NullableContext(1)]
	public override Vector GravityEndLerpVector()
	{
		this.EndLerpGravityVector.DeepCopy(this.Owner.GetGravityDirectForActor());
		return this.EndLerpGravityVector;
	}
}
