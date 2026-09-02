using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Aki.Protocol;
using AkiClient.Game.Aki.Data.Gameplay.RollBlock;
using UnrealEngine;

namespace CSharpScript.Game.LevelGamePlay.RollBlock.States
{
	// Token: 0x02006B26 RID: 27430
	[NullableContext(1)]
	[Nullable(0)]
	public class RbRollState : RbBaseMoveState
	{
		// Token: 0x06043C6C RID: 277612 RVA: 0x01181B51 File Offset: 0x0117FD51
		public RbRollState(RbBlockComponent owner) : base(owner)
		{
		}

		// Token: 0x06043C6D RID: 277613 RVA: 0x01181B7C File Offset: 0x0117FD7C
		public override void Enter([Nullable(new byte[]
		{
			0,
			1,
			1,
			1
		})] OneOf<RbBlockIdlePbState, RbJumpMovement, RbRollMovement> info)
		{
			if (!RollBlockDefind.isRbBlockRollState(info))
			{
				Singleton<Log>.Instance.Error(ELogModule.RollBlock, ELogAuthor.CH, "RbIdleState Enter without MovingState info", default(ReadOnlySpan<ValueTuple<string, object>>));
				return;
			}
			this.StateName = ERollBlockMoveState.Roll;
			this.Info = info.AsT3;
			this.Owner.AvailableInputDirs = new List<RbGridDirection>();
			RbRollMovement info2 = this.Info;
			RbGridDirection? rbGridDirection = (info2 != null) ? new RbGridDirection?(info2.Direction) : null;
			if (rbGridDirection != null)
			{
				this.CurMoveDir = this.Owner.PbDirToVector(rbGridDirection.Value);
			}
			this.RollingTimer = 0f;
			this.OriginTrans = new FTransformDouble?(this.Owner.Transform);
			this.GameplaySetting = ControllerBase<RollBlockController>.Instance.GameplaySetting;
			this.RotationAxis = global::Vector.Create(this.CurMoveDir);
			this.RotationAxis.CrossProductEqual(global::Vector.Create(0.0, 0.0, 1.0));
			this.RotationCenter = this.Owner.CalculateRotationCenter(50f, this.CurMoveDir);
			this.IsFinishedInternal = false;
			this.BlockRollTime = (this.Owner.IsMainController ? this.GameplaySetting.BlockRollTime : this.GameplaySetting.VisionBlockRollTime);
		}

		// Token: 0x06043C6E RID: 277614 RVA: 0x01181CD4 File Offset: 0x0117FED4
		public override void Update(float delta)
		{
			if (this.RollingTimer >= this.BlockRollTime)
			{
				return;
			}
			if (this.Info == null || this.CurMoveDir == null || this.OriginTrans == null || this.GameplaySetting == null || this.Owner == null)
			{
				return;
			}
			this.RollingTimer += delta / (float)Singleton<TimeUtil>.Instance.InverseMillisecond;
			float alpha = Singleton<MathUtils>.Instance.Clamp(this.RollingTimer / this.BlockRollTime, 0f, 1f);
			FTransformDouble actorTransform = this.CalcNewTransform(alpha);
			this.Owner.SetActorTransform(actorTransform);
			if (this.RollingTimer >= this.BlockRollTime)
			{
				this.OnBlockRollFinish(this.Owner.Entity);
			}
		}

		// Token: 0x06043C6F RID: 277615 RVA: 0x01181D90 File Offset: 0x0117FF90
		private FTransformDouble CalcNewTransform(float alpha)
		{
			global::Vector vector = global::Vector.Create(this.OriginTrans.Value.GetLocation());
			FQuat rotation = this.OriginTrans.Value.GetRotation();
			FVector fvector = this.RotationAxis.ToUeVectorOld();
			FQuat fquat = new FQuat(ref fvector, -1.5707964f * alpha);
			global::Vector vector2 = global::Vector.Create();
			vector.Subtraction(this.RotationCenter, vector2);
			fvector = vector2.ToUeVectorOld();
			FVector fvector2 = fquat.RotateVector(fvector);
			FVector fvector3 = this.RotationCenter.ToUeVectorOld();
			FVector fvector4 = fvector2 + fvector3;
			FRotator frotator = (fquat * rotation).Rotator();
			FVectorDouble fvectorDouble = new FVectorDouble(ref fvector4);
			fvector = this.OriginTrans.Value.GetScale3D();
			return new FTransformDouble(ref frotator, ref fvectorDouble, ref fvector);
		}

		// Token: 0x06043C70 RID: 277616 RVA: 0x01181E68 File Offset: 0x01180068
		private void OnBlockRollFinish(Entity entity)
		{
			FTransformDouble actorTransform = this.CalcNewTransform(1f);
			this.Owner.SetActorTransform(actorTransform);
			if (ControllerBase<RollBlockController>.Instance.IsCurrentIncId(this.Owner.IncId))
			{
				base.NotifyServerMovementFinish();
			}
			this.IsFinishedInternal = true;
		}

		// Token: 0x04025E78 RID: 155256
		[Nullable(2)]
		public RbRollMovement Info;

		// Token: 0x04025E79 RID: 155257
		[Nullable(2)]
		private global::Vector CurMoveDir = global::Vector.Create();

		// Token: 0x04025E7A RID: 155258
		private float RollingTimer;

		// Token: 0x04025E7B RID: 155259
		private global::Vector RotationCenter = global::Vector.Create();

		// Token: 0x04025E7C RID: 155260
		private global::Vector RotationAxis = global::Vector.Create();

		// Token: 0x04025E7D RID: 155261
		private float BlockRollTime;

		// Token: 0x04025E7E RID: 155262
		private FTransformDouble? OriginTrans;

		// Token: 0x04025E7F RID: 155263
		[Nullable(2)]
		public BP_RollBlockGameplaySetting_C GameplaySetting;
	}
}
