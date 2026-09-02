using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;

// Token: 0x02000E14 RID: 3604
public class DefaultCameraGravity : BaseCameraGravity
{
	// Token: 0x06005524 RID: 21796 RVA: 0x000D7FED File Offset: 0x000D61ED
	protected override void SetCameraGravityMode()
	{
		base.InternalSetCameraGravityMode(ECameraGravityMode.None);
	}

	// Token: 0x06005525 RID: 21797 RVA: 0x000D7FF6 File Offset: 0x000D61F6
	[NullableContext(1)]
	public override Vector GravityEndLerpVector()
	{
		this.EndLerpGravityVector.DeepCopy(Vector.DownVectorProxy);
		return this.EndLerpGravityVector;
	}
}
