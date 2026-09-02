using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F17 RID: 28439
	[NullableContext(2)]
	[Nullable(0)]
	public class DgmClawGrabState : DgmClawBaseMoveState
	{
		// Token: 0x06044E1E RID: 282142 RVA: 0x011ECF6C File Offset: 0x011EB16C
		[NullableContext(1)]
		public DgmClawGrabState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, FTransformDouble ownerActorTransform) : base(owner, clawActor, clawRootActor, ownerActorTransform)
		{
			this.StateInternal = EDollGrabMachineClawState.Grabbing;
			this.NextStateMap.Add(EDollGrabMachineClawState.MovingUp, () => this.Owner.LastClawState.GetValueOrDefault() == EDollGrabMachineClawState.MovingDown);
			this.NextStateMap.Add(EDollGrabMachineClawState.Idle, () => this.Owner.LastClawState.GetValueOrDefault() == EDollGrabMachineClawState.Release && (this.Owner.IsMachineActive || this.Owner.IsMachinePause));
			this.NextStateMap.Add(EDollGrabMachineClawState.Reset, () => this.Owner.LastClawState.GetValueOrDefault() == EDollGrabMachineClawState.Release && !this.Owner.IsMachineActive && !this.Owner.IsMachinePause);
		}

		// Token: 0x06044E1F RID: 282143 RVA: 0x011ECFDC File Offset: 0x011EB1DC
		public override void Enter()
		{
			if (!this.IsFirstEnter)
			{
				this.IsFirstEnter = true;
				this.SeqActor = this.Owner.ClawAnimSeqActor;
				this.Model = ModelBase<DollGrabModel>.Instance;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = this.Model.DollGrabMachineGlobalConfig;
				if (dollGrabMachineGlobalConfig != null)
				{
					this.MoveSpeed = dollGrabMachineGlobalConfig.钩爪移动速度;
					this.RightMaxDistance = dollGrabMachineGlobalConfig.钩爪X轴移动距离限制 * 100f * 0.5f + dollGrabMachineGlobalConfig.钩爪X轴起始偏移 * 100f;
					this.RightMinDistance = dollGrabMachineGlobalConfig.钩爪X轴移动距离限制 * 100f * -0.5f + dollGrabMachineGlobalConfig.钩爪X轴起始偏移 * 100f;
					this.ForwardMaxDistance = dollGrabMachineGlobalConfig.钩爪Y轴移动距离限制 * 100f * 0.5f + dollGrabMachineGlobalConfig.钩爪Y轴起始偏移 * 100f;
					this.ForwardMinDistance = dollGrabMachineGlobalConfig.钩爪Y轴移动距离限制 * 100f * -0.5f + dollGrabMachineGlobalConfig.钩爪Y轴起始偏移 * 100f;
				}
			}
			if (this.SeqActor != null && this.SeqActor.SequencePlayer != null)
			{
				this.SeqActor.SequencePlayer.OnFinished.Add(new Action(this.OnSequenceFinished));
				this.SeqActor.SequencePlayer.PlayReverse();
			}
			this.CanMoveClaw = (this.Model.ClawReleaseStateCanMoveTimeLeave <= 0f);
		}

		// Token: 0x06044E20 RID: 282144 RVA: 0x011ED12C File Offset: 0x011EB32C
		public override void Update(float delta)
		{
			if (this.Model.ClawReleaseStateCanMoveTimeLeave > 0f)
			{
				this.Model.ClawReleaseStateCanMoveTimeLeave -= delta;
				if (this.Model.ClawReleaseStateCanMoveTimeLeave <= 0f)
				{
					this.CanMoveClaw = true;
				}
			}
			if (this.Owner.LastClawState.GetValueOrDefault() != EDollGrabMachineClawState.Release || !this.CanMoveClaw)
			{
				return;
			}
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
			this.ClawRootActor.D_K2_SetActorRelativeLocation(commonTempVector2.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, false);
		}

		// Token: 0x06044E21 RID: 282145 RVA: 0x011ED328 File Offset: 0x011EB528
		public override void Exit()
		{
			if (this.SeqActor != null && this.SeqActor.SequencePlayer != null)
			{
				this.SeqActor.SequencePlayer.OnFinished.Remove(new Action(this.OnSequenceFinished));
			}
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x06044E22 RID: 282146 RVA: 0x011ED398 File Offset: 0x011EB598
		public override void Pause()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x06044E23 RID: 282147 RVA: 0x011ED3CF File Offset: 0x011EB5CF
		private void OnSequenceFinished()
		{
			this.Owner.CheckTouchGetItemInClawTrigger();
			this.End();
			if (this.Owner.IsMachineActive || this.Owner.IsMachinePause)
			{
				this.Owner.ChangeClawState(EDollGrabMachineClawState.Idle);
			}
		}

		// Token: 0x04026644 RID: 157252
		private AKuroLevelSequenceActor SeqActor;

		// Token: 0x04026645 RID: 157253
		private float MoveSpeed;

		// Token: 0x04026646 RID: 157254
		private float RightMaxDistance;

		// Token: 0x04026647 RID: 157255
		private float RightMinDistance;

		// Token: 0x04026648 RID: 157256
		private float ForwardMaxDistance;

		// Token: 0x04026649 RID: 157257
		private float ForwardMinDistance;

		// Token: 0x0402664A RID: 157258
		private DollGrabModel Model;

		// Token: 0x0402664B RID: 157259
		private bool CanMoveClaw;

		// Token: 0x0402664C RID: 157260
		private int ClawMoveEventHandle = -1;
	}
}
