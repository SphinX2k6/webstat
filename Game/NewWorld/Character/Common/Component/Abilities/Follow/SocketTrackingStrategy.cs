using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Data.Fight.Struct;
using UnrealEngine;

namespace CSharpScript.Game.NewWorld.Character.Common.Component.Abilities.Follow
{
	// Token: 0x02004964 RID: 18788
	[NullableContext(1)]
	[Nullable(0)]
	internal class SocketTrackingStrategy : IFollowShooterAttachStrategy
	{
		// Token: 0x060311FC RID: 201212 RVA: 0x00C3A4A8 File Offset: 0x00C386A8
		public void OnAttach(USceneComponent sceneComponent, SLockOnFollowShooterAttachmentRule attachmentRule, USceneComponent targetComponent)
		{
			this.TrackingMap[sceneComponent] = new SocketTrackingInfo
			{
				TargetComponent = new WeakReference<USceneComponent>(targetComponent),
				SocketName = attachmentRule.Socket
			};
			FTransformDouble ftransformDouble = targetComponent.D_GetSocketTransform(attachmentRule.Socket, ERelativeTransformSpace.RTS_World);
			sceneComponent.D_K2_SetWorldTransform(ftransformDouble, false, ref WorldGlobal.SweepHitResult, true);
		}

		// Token: 0x060311FD RID: 201213 RVA: 0x00C3A4FB File Offset: 0x00C386FB
		public void OnDetach(USceneComponent sceneComponent, SLockOnFollowShooterAttachmentRule attachmentRule)
		{
			this.TrackingMap.Remove(sceneComponent);
		}

		// Token: 0x060311FE RID: 201214 RVA: 0x00C3A50A File Offset: 0x00C3870A
		public void ClearForSceneComponent(USceneComponent sceneComponent)
		{
			this.TrackingMap.Remove(sceneComponent);
		}

		// Token: 0x060311FF RID: 201215 RVA: 0x00C3A51C File Offset: 0x00C3871C
		public float? UpdateTransform(USceneComponent sceneComponent, IUpdateRotationParams @params)
		{
			ISocketTrackingInfo validTrackingInfo = this.GetValidTrackingInfo(sceneComponent);
			if (validTrackingInfo == null)
			{
				return null;
			}
			USceneComponent usceneComponent;
			validTrackingInfo.TargetComponent.TryGetTarget(out usceneComponent);
			if (usceneComponent == null || !usceneComponent.IsValid())
			{
				return null;
			}
			FVectorDouble fromLocationDouble = usceneComponent.D_K2_GetComponentLocation();
			FRotator target = @params.AimTarget.ComputeTargetWorldRotator(fromLocationDouble, @params.RotateOffset);
			FRotator fakeParentRotation = UKismetMathLibrary.RInterpTo(this.DeriveFakeParentRotation(sceneComponent, validTrackingInfo) ?? sceneComponent.K2_GetComponentRotation(), target, @params.DeltaTimeMs / 1000f, @params.RotationInterpSpeed);
			FQuat fquat = fakeParentRotation.Quaternion();
			FQuat fquat2 = target.Quaternion();
			float value = fquat.AngularDistance(fquat2) * 57.29578f;
			FTransformDouble? ftransformDouble = this.ComputeFakeSocketWorldTransform(validTrackingInfo, fakeParentRotation);
			if (ftransformDouble != null)
			{
				FTransformDouble value2 = ftransformDouble.Value;
				sceneComponent.D_K2_SetWorldTransform(value2, false, ref WorldGlobal.SweepHitResult, true);
			}
			return new float?(value);
		}

		// Token: 0x06031200 RID: 201216 RVA: 0x00C3A614 File Offset: 0x00C38814
		[return: Nullable(2)]
		private ISocketTrackingInfo GetValidTrackingInfo(USceneComponent sceneComponent)
		{
			ISocketTrackingInfo socketTrackingInfo;
			if (!this.TrackingMap.TryGetValue(sceneComponent, out socketTrackingInfo))
			{
				return null;
			}
			USceneComponent usceneComponent;
			socketTrackingInfo.TargetComponent.TryGetTarget(out usceneComponent);
			if (usceneComponent == null || !usceneComponent.IsValid())
			{
				this.TrackingMap.Remove(sceneComponent);
				return null;
			}
			return socketTrackingInfo;
		}

		// Token: 0x06031201 RID: 201217 RVA: 0x00C3A664 File Offset: 0x00C38864
		private FTransformDouble? ComputeFakeSocketWorldTransform(ISocketTrackingInfo trackingInfo, FRotator fakeParentRotation)
		{
			USceneComponent usceneComponent;
			trackingInfo.TargetComponent.TryGetTarget(out usceneComponent);
			if (usceneComponent == null || !usceneComponent.IsValid())
			{
				return null;
			}
			FTransformDouble ftransformDouble = usceneComponent.D_GetSocketTransform(trackingInfo.SocketName, ERelativeTransformSpace.RTS_Component);
			FTransformDouble ftransformDouble2 = usceneComponent.D_K2_GetComponentToWorld();
			FTransformDouble ftransformDouble3 = UKismetMathLibrary.MakeTransformDouble(ftransformDouble2.GetLocation(), fakeParentRotation, ftransformDouble2.GetScale3D());
			return new FTransformDouble?(UKismetMathLibrary.D_ComposeTransforms(ftransformDouble, ftransformDouble3));
		}

		// Token: 0x06031202 RID: 201218 RVA: 0x00C3A6D4 File Offset: 0x00C388D4
		private FRotator? DeriveFakeParentRotation(USceneComponent sceneComponent, ISocketTrackingInfo trackingInfo)
		{
			USceneComponent usceneComponent;
			trackingInfo.TargetComponent.TryGetTarget(out usceneComponent);
			if (usceneComponent == null || !usceneComponent.IsValid())
			{
				return null;
			}
			FTransformDouble ftransformDouble = usceneComponent.D_GetSocketTransform(trackingInfo.SocketName, ERelativeTransformSpace.RTS_Component);
			FRotator frotator = sceneComponent.K2_GetComponentRotation();
			FQuat fquat = ftransformDouble.GetRotation();
			FQuat fquat2 = fquat.Inverse();
			fquat = frotator.Quaternion();
			return new FRotator?((fquat * fquat2).Rotator());
		}

		// Token: 0x0401C490 RID: 115856
		private readonly Dictionary<USceneComponent, ISocketTrackingInfo> TrackingMap = new Dictionary<USceneComponent, ISocketTrackingInfo>();
	}
}
