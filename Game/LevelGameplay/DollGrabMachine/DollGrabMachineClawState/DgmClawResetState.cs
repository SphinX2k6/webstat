using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.DollGrabMachine.DollGrabMachineClawState
{
	// Token: 0x02006F1C RID: 28444
	public class DgmClawResetState : DgmClawBaseMoveState
	{
		// Token: 0x06044E45 RID: 282181 RVA: 0x011EE1E5 File Offset: 0x011EC3E5
		[NullableContext(1)]
		public DgmClawResetState(SceneItemDollGrabMachineComponent owner, AActor clawActor, AActor clawRootActor, FTransformDouble ownerActorTransform) : base(owner, clawActor, clawRootActor, ownerActorTransform)
		{
			this.StateInternal = EDollGrabMachineClawState.Reset;
			this.NextStateMap.Add(EDollGrabMachineClawState.Idle, null);
			this.OriginalPosition = this.ClawRootActor.D_K2_GetActorLocation();
		}

		// Token: 0x06044E46 RID: 282182 RVA: 0x011EE218 File Offset: 0x011EC418
		public override void Enter()
		{
			FVectorDouble fvectorDouble = this.ClawRootActor.D_K2_GetActorLocation();
			double num = this.OriginalPosition.X - fvectorDouble.X;
			double num2 = this.OriginalPosition.Y - fvectorDouble.Y;
			this.ResetTime = ModelBase<DollGrabModel>.Instance.DollGrabMachineGlobalConfig.钩爪复位时间 * 1000f;
			this.RightMoveSpeed = (float)num / this.ResetTime;
			this.UpMoveSpeed = (float)num2 / this.ResetTime;
		}

		// Token: 0x06044E47 RID: 282183 RVA: 0x011EE290 File Offset: 0x011EC490
		public override void Update(float deltaTime)
		{
			base.Update(deltaTime);
			float num = this.RightMoveSpeed * deltaTime;
			float num2 = this.UpMoveSpeed * deltaTime;
			Vector commonTempVector = Singleton<MathUtils>.Instance.CommonTempVector;
			FVectorDouble fvectorDouble = this.ClawRootActor.D_K2_GetActorLocation();
			commonTempVector.FromUeVector(fvectorDouble);
			Singleton<MathUtils>.Instance.CommonTempVector.X += (double)num;
			Singleton<MathUtils>.Instance.CommonTempVector.Y += (double)num2;
			this.ResetTime -= deltaTime;
			if (this.ResetTime <= 0f || (Singleton<MathUtils>.Instance.IsNearlyZero((double)num, null) && Singleton<MathUtils>.Instance.IsNearlyZero((double)num2, null)))
			{
				this.ClawRootActor.D_K2_SetActorLocation(this.OriginalPosition, false, ref WorldGlobal.SweepHitResult, true);
				this.End();
				this.Owner.ChangeClawState(EDollGrabMachineClawState.Idle);
				return;
			}
			this.ClawRootActor.D_K2_SetActorLocation(Singleton<MathUtils>.Instance.CommonTempVector.ToUeVector(false), false, ref WorldGlobal.SweepHitResult, true);
		}

		// Token: 0x0402666A RID: 157290
		private float ResetTime;

		// Token: 0x0402666B RID: 157291
		private readonly FVectorDouble OriginalPosition;

		// Token: 0x0402666C RID: 157292
		private float RightMoveSpeed;

		// Token: 0x0402666D RID: 157293
		private float UpMoveSpeed;
	}
}
