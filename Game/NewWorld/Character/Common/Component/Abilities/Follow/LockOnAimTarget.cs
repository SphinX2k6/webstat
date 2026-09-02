using System;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004962 RID: 18786
	public class LockOnAimTarget : FollowShooterAimTarget
	{
		// Token: 0x060311F6 RID: 201206 RVA: 0x00C3A37A File Offset: 0x00C3857A
		public LockOnAimTarget(FVectorDouble targetLocationDouble)
		{
			this.TargetLocationDouble = targetLocationDouble;
		}

		// Token: 0x060311F7 RID: 201207 RVA: 0x00C3A389 File Offset: 0x00C38589
		protected override FRotator ComputeBaseRotator(FVectorDouble fromLocationDouble)
		{
			return UKismetMathLibrary.D_FindLookAtRotation(fromLocationDouble, this.TargetLocationDouble);
		}

		// Token: 0x0401C48F RID: 115855
		public readonly FVectorDouble TargetLocationDouble;
	}
}
