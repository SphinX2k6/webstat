using System;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x0200497A RID: 18810
	public abstract class FollowShooterAimTarget
	{
		// Token: 0x0603129C RID: 201372
		protected abstract FRotator ComputeBaseRotator(FVectorDouble fromLocationDouble);

		// Token: 0x0603129D RID: 201373 RVA: 0x00C3DEB8 File Offset: 0x00C3C0B8
		public FRotator ComputeTargetWorldRotator(FVectorDouble fromLocationDouble, FRotator rotateOffset)
		{
			FQuat fquat = this.ComputeBaseRotator(fromLocationDouble).Quaternion();
			FQuat fquat2 = rotateOffset.Quaternion();
			return (fquat * fquat2).Rotator();
		}
	}
}
