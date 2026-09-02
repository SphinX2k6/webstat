using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F1B RID: 28443
	[NullableContext(2)]
	[Nullable(0)]
	public class DgmClawReleaseState : DgmClawBaseMoveState
	{
		// Token: 0x06044E3C RID: 282172 RVA: 0x011EDCD4 File Offset: 0x011EBED4
		[NullableContext(1)]
		public DgmClawReleaseState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, FTransformDouble ownerActorTransform) : base(owner, clawActor, clawRootActor, ownerActorTransform)
		{
			this.StateInternal = EDollGrabMachineClawState.Release;
			this.NextStateMap.Add(EDollGrabMachineClawState.MovingDown, () => !this.HadGrabbingActor);
			this.NextStateMap.Add(EDollGrabMachineClawState.Grabbing, () => this.HadGrabbingActor);
			if (ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig != null)
			{
				this.DelayExitTime = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.钩爪延迟合上时间 * 1000f;
			}
		}

		// Token: 0x06044E3D RID: 282173 RVA: 0x011EDD54 File Offset: 0x011EBF54
		public override void Enter()
		{
			if (!this.IsFirstEnter)
			{
				this.IsFirstEnter = true;
				this.SeqActor = this.Owner.ClawAnimSeqActor;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				if (dollGrabMachineGlobalConfig != null)
				{
					this.MoveSpeed = dollGrabMachineGlobalConfig.钩爪移动速度;
					this.RightMaxDistance = dollGrabMachineGlobalConfig.钩爪X轴移动距离限制 * 100f * 0.5f + dollGrabMachineGlobalConfig.钩爪X轴起始偏移 * 100f;
					this.RightMinDistance = dollGrabMachineGlobalConfig.钩爪X轴移动距离限制 * 100f * -0.5f + dollGrabMachineGlobalConfig.钩爪X轴起始偏移 * 100f;
					this.ForwardMaxDistance = dollGrabMachineGlobalConfig.钩爪Y轴移动距离限制 * 100f * 0.5f + dollGrabMachineGlobalConfig.钩爪Y轴起始偏移 * 100f;
					this.ForwardMinDistance = dollGrabMachineGlobalConfig.钩爪Y轴移动距离限制 * 100f * -0.5f + dollGrabMachineGlobalConfig.钩爪Y轴起始偏移 * 100f;
				}
				this.Model = ModelBase<DollGrabModel>.Instance;
			}
			if (this.SeqActor != null && this.SeqActor.SequencePlayer != null)
			{
				this.SeqActor.SequencePlayer.OnFinished.Add(new Action(this.OnSequenceFinished));
				this.SeqActor.SequencePlayer.Play();
			}
			this.HadGrabbingActor = this.Owner.HasGrabbingActor;
			this.CanMoveClaw = true;
			this.Model.ClawReleaseStateCanMoveTimeLeave = 0f;
			if (this.HadGrabbingActor && this.Model.ClawReleaseStateCanMoveTime > 0f)
			{
				this.CanMoveClaw = false;
				this.Model.ClawReleaseStateCanMoveTimeLeave = this.Model.ClawReleaseStateCanMoveTime;
			}
		}

		// Token: 0x06044E3E RID: 282174 RVA: 0x011EDEE8 File Offset: 0x011EC0E8
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
			if (!this.HadGrabbingActor || !this.CanMoveClaw)
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

		// Token: 0x06044E3F RID: 282175 RVA: 0x011EE0D4 File Offset: 0x011EC2D4
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

		// Token: 0x06044E40 RID: 282176 RVA: 0x011EE144 File Offset: 0x011EC344
		public override void Pause()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x06044E41 RID: 282177 RVA: 0x011EE17C File Offset: 0x011EC37C
		private void OnSequenceFinished()
		{
			if (this.DelayExitTime > 0f && this.HadGrabbingActor)
			{
				TimerSystem.Instance.Delay(delegate(float _)
				{
					this.End();
				}, this.DelayExitTime, null, null, true, 1f);
				return;
			}
			this.End();
		}

		// Token: 0x0402665F RID: 157279
		private AKuroLevelSequenceActor SeqActor;

		// Token: 0x04026660 RID: 157280
		private bool HadGrabbingActor;

		// Token: 0x04026661 RID: 157281
		private readonly float DelayExitTime;

		// Token: 0x04026662 RID: 157282
		private float MoveSpeed;

		// Token: 0x04026663 RID: 157283
		private float RightMaxDistance;

		// Token: 0x04026664 RID: 157284
		private float RightMinDistance;

		// Token: 0x04026665 RID: 157285
		private float ForwardMaxDistance;

		// Token: 0x04026666 RID: 157286
		private float ForwardMinDistance;

		// Token: 0x04026667 RID: 157287
		private bool CanMoveClaw;

		// Token: 0x04026668 RID: 157288
		private int ClawMoveEventHandle = -1;

		// Token: 0x04026669 RID: 157289
		private DollGrabModel Model;
	}
}
