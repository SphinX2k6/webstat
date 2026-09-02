using System;
using System.Runtime.CompilerServices;
using AkiClient.Game.Aki.GamePlay.DollGrab;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F1A RID: 28442
	public class DgmClawMovingUpState : DgmClawBaseMoveState
	{
		// Token: 0x06044E34 RID: 282164 RVA: 0x011EDA4C File Offset: 0x011EBC4C
		[NullableContext(1)]
		public DgmClawMovingUpState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, AActor clawChainActor, FTransformDouble ownerActorTransform) : base(owner, clawActor, clawRootActor, ownerActorTransform)
		{
			this.StateInternal = EDollGrabMachineClawState.MovingUp;
			this.ClawChainActor = clawChainActor;
			this.NextStateMap.Add(EDollGrabMachineClawState.Idle, () => this.Owner.IsMachineActive);
			this.NextStateMap.Add(EDollGrabMachineClawState.Reset, () => !this.Owner.IsMachineActive);
		}

		// Token: 0x06044E35 RID: 282165 RVA: 0x011EDAAC File Offset: 0x011EBCAC
		public override void Enter()
		{
			if (!this.IsFirstEnter && ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig != null)
			{
				this.IsFirstEnter = true;
				BP_DollGrabMachineGlobalConfig_C dollGrabMachineGlobalConfig = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig;
				this.MoveSpeed = dollGrabMachineGlobalConfig.钩爪上升速度;
				this.ChainScaleRatio = dollGrabMachineGlobalConfig.钩爪锁链缩放比例;
				this.UpMaxDistance = dollGrabMachineGlobalConfig.钩爪下探距离限制 * 100f;
			}
			this.CurrentUpDistance = 0f;
		}

		// Token: 0x06044E36 RID: 282166 RVA: 0x011EDB14 File Offset: 0x011EBD14
		public override void Update(float delta)
		{
			if (this.ClawMoveEventHandle < 0)
			{
				this.ClawMoveEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_crane_up_down", this.ClawRootActor, null);
			}
			float num = this.MoveSpeed * delta / 10f;
			this.CurrentUpDistance += num;
			bool flag = this.CurrentUpDistance >= this.UpMaxDistance;
			if (flag)
			{
				num -= this.CurrentUpDistance - this.UpMaxDistance;
			}
			Singleton<MathUtils>.Instance.CommonTempVector.Set(0.0, 0.0, (double)num);
			float num2 = num / this.ChainScaleRatio;
			FVectorDouble newScale3D = this.ClawChainActor.D_GetActorScale3D();
			newScale3D.Z -= (double)num2;
			this.ClawChainActor.D_SetActorScale3D(newScale3D);
			FHitResult fhitResult = null;
			this.ClawActor.K2_AddActorWorldOffset(Singleton<MathUtils>.Instance.CommonTempVector.ToUeVectorOld(), false, ref fhitResult, false);
			if (flag)
			{
				this.End();
			}
		}

		// Token: 0x06044E37 RID: 282167 RVA: 0x011EDC0C File Offset: 0x011EBE0C
		public override void Pause()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x06044E38 RID: 282168 RVA: 0x011EDC44 File Offset: 0x011EBE44
		public override void Resume()
		{
			if (this.ClawMoveEventHandle < 0)
			{
				this.ClawMoveEventHandle = Singleton<AudioSystem>.Instance.PostEvent("play_nteract_crane_game_crane_up_down", this.ClawRootActor, null);
			}
		}

		// Token: 0x06044E39 RID: 282169 RVA: 0x011EDC80 File Offset: 0x011EBE80
		public override void Exit()
		{
			if (this.ClawMoveEventHandle > 0)
			{
				Singleton<AudioSystem>.Instance.ExecuteAction(this.ClawMoveEventHandle, EAudioActionType.Stop, null);
				this.ClawMoveEventHandle = -1;
			}
		}

		// Token: 0x04026659 RID: 157273
		[Nullable(2)]
		private readonly AActor ClawChainActor;

		// Token: 0x0402665A RID: 157274
		private float ChainScaleRatio;

		// Token: 0x0402665B RID: 157275
		private float UpMaxDistance;

		// Token: 0x0402665C RID: 157276
		private float CurrentUpDistance;

		// Token: 0x0402665D RID: 157277
		private float MoveSpeed;

		// Token: 0x0402665E RID: 157278
		private int ClawMoveEventHandle = -1;
	}
}
