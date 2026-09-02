using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004963 RID: 18787
	[NullableContext(1)]
	[Nullable(0)]
	internal class DirectAttachStrategy : IFollowShooterAttachStrategy
	{
		// Token: 0x060311F8 RID: 201208 RVA: 0x00C3A398 File Offset: 0x00C38598
		public void OnAttach(USceneComponent sceneComponent, SLockOnFollowShooterAttachmentRule attachmentRule, USceneComponent targetComponent)
		{
			sceneComponent.K2_AttachToComponent(targetComponent, attachmentRule.Socket, (EAttachmentRule)attachmentRule.AttachLocationRule, (EAttachmentRule)attachmentRule.AttachRotationRule, (EAttachmentRule)attachmentRule.AttachScaleRule, false, true);
			sceneComponent.SetAbsolute(attachmentRule.AbsoluteLocation, attachmentRule.AbsoluteRotation, attachmentRule.AbsoluteScale);
		}

		// Token: 0x060311F9 RID: 201209 RVA: 0x00C3A3EE File Offset: 0x00C385EE
		public void OnDetach(USceneComponent sceneComponent, SLockOnFollowShooterAttachmentRule attachmentRule)
		{
			sceneComponent.K2_DetachFromComponent((EDetachmentRule)attachmentRule.DetachLocationRule, (EDetachmentRule)attachmentRule.DetachRotationRule, (EDetachmentRule)attachmentRule.DetachScaleRule, false);
		}

		// Token: 0x060311FA RID: 201210 RVA: 0x00C3A418 File Offset: 0x00C38618
		public float? UpdateTransform(USceneComponent sceneComponent, IUpdateRotationParams @params)
		{
			sceneComponent.SetAbsolute(false, true, false);
			FTransformDouble ftransformDouble = sceneComponent.D_K2_GetComponentToWorld();
			FRotator target = @params.AimTarget.ComputeTargetWorldRotator(ftransformDouble.GetLocation(), @params.RotateOffset);
			FQuat rotation = ftransformDouble.GetRotation();
			FQuat fquat = target.Quaternion();
			float value = rotation.AngularDistance(fquat) * 57.29578f;
			FRotator newRotation = UKismetMathLibrary.RInterpTo(sceneComponent.K2_GetComponentRotation(), target, @params.DeltaTimeMs / 1000f, @params.RotationInterpSpeed);
			sceneComponent.K2_SetWorldRotation(newRotation, false, ref WorldGlobal.SweepHitResult, true);
			return new float?(value);
		}
	}
}
