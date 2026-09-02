using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.Character.BaseCharacter.Camera;
using UnrealEngine;

namespace CSharpScript.Game.Camera.SceneCameraRotator
{
	// Token: 0x020070BF RID: 28863
	[NullableContext(1)]
	[Nullable(0)]
	public class SceneCameraFollowTargetRotator : SceneCameraRotatorBase
	{
		// Token: 0x06045FB8 RID: 286648 RVA: 0x0125B245 File Offset: 0x01259445
		public SceneCameraFollowTargetRotator(SceneCameraFollowConfig config)
		{
			this.CapturedConfig.DeepCopy(config);
		}

		// Token: 0x06045FB9 RID: 286649 RVA: 0x0125B264 File Offset: 0x01259464
		public override bool IsValid()
		{
			return true;
		}

		// Token: 0x06045FBA RID: 286650 RVA: 0x0125B268 File Offset: 0x01259468
		public override void ComputeExpectRotation()
		{
			this.HasValidExpectation = false;
			SceneSubCamera subCamera = this.SubCamera;
			BP_CineCamera_C bp_CineCamera_C = (subCamera != null) ? subCamera.Camera : null;
			if (bp_CineCamera_C == null || !bp_CineCamera_C.IsValid())
			{
				return;
			}
			Vector vector = this.ResolveTargetPosition();
			if (vector == null)
			{
				return;
			}
			this.ScratchVector1.DeepCopy(vector);
			Vector scratchVector = this.ScratchVector2;
			FVectorDouble fvectorDouble = bp_CineCamera_C.D_K2_GetActorLocation();
			scratchVector.DeepCopy(fvectorDouble);
			this.ScratchVector1.SubtractionEqual(this.ScratchVector2);
			if (Singleton<MathUtils>.Instance.IsNearlyZero(this.ScratchVector1.SizeSquared(), null))
			{
				return;
			}
			Singleton<MathUtils>.Instance.LookRotationForwardFirst(this.ScratchVector1, this.GravityUp, this.WorkingQuat);
			this.HasValidExpectation = true;
		}

		// Token: 0x06045FBB RID: 286651 RVA: 0x0125B31C File Offset: 0x0125951C
		public override void ApplyRotationLimit()
		{
		}

		// Token: 0x06045FBC RID: 286652 RVA: 0x0125B320 File Offset: 0x01259520
		public override void ApplyRotationToCameraActor()
		{
			if (!this.HasValidExpectation)
			{
				return;
			}
			SceneSubCamera subCamera = this.SubCamera;
			BP_CineCamera_C bp_CineCamera_C = (subCamera != null) ? subCamera.Camera : null;
			if (bp_CineCamera_C == null || !bp_CineCamera_C.IsValid())
			{
				return;
			}
			if (!this.IsNormalGravity)
			{
				base.ClearCameraGravityRoll();
			}
			this.WorkingQuat.Rotator(this.WorkingRotator);
			base.WriteCameraRotation();
		}

		// Token: 0x06045FBD RID: 286653 RVA: 0x0125B37C File Offset: 0x0125957C
		[NullableContext(2)]
		private Vector ResolveTargetPosition()
		{
			ESceneCameraFollowTargetType targetType = this.CapturedConfig.TargetType;
			if (targetType != ESceneCameraFollowTargetType.Player)
			{
				if (targetType != ESceneCameraFollowTargetType.Entity)
				{
					return null;
				}
				EntityHandle entityByPbDataId = ModelBase<CreatureModel>.Instance.GetEntityByPbDataId(this.CapturedConfig.EntityId);
				if (entityByPbDataId == null || !entityByPbDataId.Valid)
				{
					return null;
				}
				WorldEntity entity = entityByPbDataId.Entity;
				BaseActorComponent baseActorComponent = (entity != null) ? entity.GetComponent<BaseActorComponent>() : null;
				if (baseActorComponent == null)
				{
					return null;
				}
				return baseActorComponent.ActorLocationProxy;
			}
			else
			{
				FightCameraLogicComponent fightCameraLogicComp = this.FightCameraLogicComp;
				EntityHandle entityHandle = (fightCameraLogicComp != null) ? fightCameraLogicComp.CharacterEntityHandle : null;
				if (entityHandle == null || !entityHandle.Valid)
				{
					return null;
				}
				WorldEntity entity2 = entityHandle.Entity;
				CharacterActorComponent characterActorComponent = (entity2 != null) ? entity2.GetComponent<CharacterActorComponent>() : null;
				if (characterActorComponent == null)
				{
					return null;
				}
				return characterActorComponent.ActorLocationProxy;
			}
		}

		// Token: 0x04027398 RID: 160664
		private readonly SceneCameraFollowConfig CapturedConfig = new SceneCameraFollowConfig();

		// Token: 0x04027399 RID: 160665
		private bool HasValidExpectation;
	}
}
