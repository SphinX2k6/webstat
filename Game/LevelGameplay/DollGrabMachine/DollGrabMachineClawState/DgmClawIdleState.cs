using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F18 RID: 28440
	public class DgmClawIdleState : DgmClawBaseMoveState
	{
		// Token: 0x06044E27 RID: 282151 RVA: 0x011ED4AC File Offset: 0x011EB6AC
		[NullableContext(1)]
		public DgmClawIdleState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, FTransformDouble ownerActorTransform) : base(owner, clawActor, clawRootActor, ownerActorTransform)
		{
			this.NextStateMap.Add(EDollGrabMachineClawState.Release, () => this.Owner.IsMachineActive);
			this.NextStateMap.Add(EDollGrabMachineClawState.Reset, () => !this.Owner.IsMachineActive);
		}

		// Token: 0x06044E28 RID: 282152 RVA: 0x011ED4FC File Offset: 0x011EB6FC
		public override void Enter()
		{
			if (!this.IsFirstEnter && ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig != null)
			{
				this.IsFirstEnter = true;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				this.MoveSpeed = dollGrabMachineGlobalConfig.钩爪移动速度;
				this.RightMaxDistance = dollGrabMachineGlobalConfig.钩爪X轴移动距离限制 * 100f * 0.5f + dollGrabMachineGlobalConfig.钩爪X轴起始偏移 * 100f;
				this.RightMinDistance = dollGrabMachineGlobalConfig.钩爪X轴移动距离限制 * 100f * -0.5f + dollGrabMachineGlobalConfig.钩爪X轴起始偏移 * 100f;
				this.ForwardMaxDistance = dollGrabMachineGlobalConfig.钩爪Y轴移动距离限制 * 100f * 0.5f + dollGrabMachineGlobalConfig.钩爪Y轴起始偏移 * 100f;
				this.ForwardMinDistance = dollGrabMachineGlobalConfig.钩爪Y轴移动距离限制 * 100f * -0.5f + dollGrabMachineGlobalConfig.钩爪Y轴起始偏移 * 100f;
			}
		}

		// Token: 0x06044E29 RID: 282153 RVA: 0x011ED5D8 File Offset: 0x011EB7D8
		public override void Update(float delta)
		{
			DollGrabMachineClawDirection clawMoveDirection = this.Owner.ClawMoveDirection;
			float num = clawMoveDirection.X * this.MoveSpeed * delta / 10f;
			float num2 = clawMoveDirection.Y * this.MoveSpeed * delta / 10f;
			if (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) && Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null))
			{
				if (this.ClawMoveEventHandle > 0)
				{
					Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
					this.ClawMoveEventHandle = -1;
				}
				return;
			}
			Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			FVectorDouble fvectorDouble = this.ClawRootActor.D_K2_GetActorLocation();
			commonTempVector.FromUeVector(fvectorDouble);
			Vector commonTempVector2 = Singleton<MathUtils>.Instance.CommonTempVector2;
			Singleton<MathUtils>.Instance.InverseTransformPosition(this.OwnerLocation, this.OwnerRotation, this.OwnerScale, Singleton<MathUtils>.Instance.CommonTempVector, commonTempVector2);
			commonTempVector2.X += (double)num;
			commonTempVector2.Y += (double)num2;
			if (this.ClawMoveEventHandle < 0)
			{
				this.ClawMoveEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_crane_move", this.ClawRootActor, null);
			}
			commonTempVector2.X = Singleton<MathUtils>.Instance.Clamp(commonTempVector2.X, (double)this.RightMinDistance, (double)this.RightMaxDistance);
			commonTempVector2.Y = Singleton<MathUtils>.Instance.Clamp(commonTempVector2.Y, (double)this.ForwardMinDistance, (double)this.ForwardMaxDistance);
			FHitResult fhitResult = null;
			this.ClawRootActor.D_K2_SetActorRelativeLocation(commonTempVector2.ToUeVector(false), false, ref fhitResult, false);
		}

		// Token: 0x06044E2A RID: 282154 RVA: 0x011ED774 File Offset: 0x011EB974
		public override void Pause()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x06044E2B RID: 282155 RVA: 0x011ED7AC File Offset: 0x011EB9AC
		public override void Exit()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x0402664D RID: 157261
		private float MoveSpeed;

		// Token: 0x0402664E RID: 157262
		private float RightMaxDistance;

		// Token: 0x0402664F RID: 157263
		private float RightMinDistance;

		// Token: 0x04026650 RID: 157264
		private float ForwardMaxDistance;

		// Token: 0x04026651 RID: 157265
		private float ForwardMinDistance;

		// Token: 0x04026652 RID: 157266
		private int ClawMoveEventHandle = -1;
	}
}
