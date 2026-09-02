using System;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004961 RID: 18785
	public class CameraAimTarget : FollowShooterAimTarget
	{
		// Token: 0x060311F4 RID: 201204 RVA: 0x00C3A2F3 File Offset: 0x00C384F3
		public CameraAimTarget(float cameraForwardDistance, FVector upVector)
		{
			this.CameraForwardDistance = cameraForwardDistance;
			this.UpVector = upVector;
		}

		// Token: 0x060311F5 RID: 201205 RVA: 0x00C3A30C File Offset: 0x00C3850C
		protected override FRotator ComputeBaseRotator(FVectorDouble fromLocationDouble)
		{
			FVectorDouble fvectorDouble = Global.CharacterCameraManager.D_GetActorForwardVector();
			FVectorDouble fvectorDouble2 = Global.CharacterCameraManager.D_GetCameraLocation();
			FVectorDouble fvectorDouble3 = fvectorDouble * (double)this.CameraForwardDistance;
			FVectorDouble fvectorDouble4 = fvectorDouble2 + fvectorDouble3;
			fvectorDouble2 = fvectorDouble4 - fromLocationDouble;
			FVector fvector = fvectorDouble2.GetSafeNormal(0.0001).ToVector();
			return UKuroAnimMathLibrary.LookRotation_ForwardFirst(fvector, this.UpVector);
		}

		// Token: 0x0401C48D RID: 115853
		public readonly float CameraForwardDistance;

		// Token: 0x0401C48E RID: 115854
		public readonly FVector UpVector;
	}
}
