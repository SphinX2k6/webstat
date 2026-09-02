using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F19 RID: 28441
	public class DgmClawMovingDownState : DgmClawBaseMoveState
	{
		// Token: 0x06044E2E RID: 282158 RVA: 0x011ED800 File Offset: 0x011EBA00
		[NullableContext(1)]
		public DgmClawMovingDownState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, AActor clawChainActor, FTransformDouble ownerActorTransform) : base(owner, clawActor, clawRootActor, ownerActorTransform)
		{
			this.ClawChainActor = clawChainActor;
			this.StateInternal = EDollGrabMachineClawState.MovingDown;
			this.NextStateMap.Add(EDollGrabMachineClawState.Grabbing, null);
		}

		// Token: 0x06044E2F RID: 282159 RVA: 0x011ED830 File Offset: 0x011EBA30
		public override void Enter()
		{
			if (!this.IsFirstEnter && ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig != null)
			{
				this.IsFirstEnter = true;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				this.MoveSpeed = dollGrabMachineGlobalConfig.钩爪下探速度;
				this.ChainScaleRatio = dollGrabMachineGlobalConfig.钩爪锁链缩放比例;
				this.DownMaxDistance = dollGrabMachineGlobalConfig.钩爪下探距离限制 * 100f;
			}
			this.Owner.StartClawTriggerOverlap();
			this.CurrentDownDistance = 0f;
		}

		// Token: 0x06044E30 RID: 282160 RVA: 0x011ED8A4 File Offset: 0x011EBAA4
		public override void Update(float delta)
		{
			if (this.ClawMoveEventHandle < 0)
			{
				this.ClawMoveEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_crane_up_down", this.ClawRootActor, null);
			}
			float num = this.MoveSpeed * delta / 10f;
			this.CurrentDownDistance += num;
			if (this.CurrentDownDistance >= this.DownMaxDistance)
			{
				num -= this.CurrentDownDistance - this.DownMaxDistance;
			}
			Singleton<MathUtils>.Instance.CommonTempVector.Set(0.0, 0.0, (double)(-(double)num));
			float num2 = num / this.ChainScaleRatio;
			FVectorDouble newScale3D = this.ClawChainActor.D_GetActorScale3D();
			newScale3D.Z += (double)num2;
			this.ClawChainActor.D_SetActorScale3D(newScale3D);
			FHitResult fhitResult = null;
			this.ClawActor.K2_AddActorWorldOffset(Singleton<MathUtils>.Instance.CommonTempVector.ToUeVectorOld(), false, ref fhitResult, false);
			if (this.CurrentDownDistance >= this.DownMaxDistance)
			{
				this.End();
			}
		}

		// Token: 0x06044E31 RID: 282161 RVA: 0x011ED9A0 File Offset: 0x011EBBA0
		public override void Pause()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x06044E32 RID: 282162 RVA: 0x011ED9D8 File Offset: 0x011EBBD8
		public override void Resume()
		{
			if (this.ClawMoveEventHandle < 0)
			{
				this.ClawMoveEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_crane_up_down", this.ClawRootActor, null);
			}
		}

		// Token: 0x06044E33 RID: 282163 RVA: 0x011EDA14 File Offset: 0x011EBC14
		public override void Exit()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x04026653 RID: 157267
		private float DownMaxDistance;

		// Token: 0x04026654 RID: 157268
		private float CurrentDownDistance;

		// Token: 0x04026655 RID: 157269
		private float ChainScaleRatio;

		// Token: 0x04026656 RID: 157270
		[Nullable(2)]
		private readonly AActor ClawChainActor;

		// Token: 0x04026657 RID: 157271
		private float MoveSpeed;

		// Token: 0x04026658 RID: 157272
		private int ClawMoveEventHandle = -1;
	}
}
