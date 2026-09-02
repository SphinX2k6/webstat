using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay.Common.GameplayAction.ActionImplement
{
	// Token: 0x02006F3B RID: 28475
	[NullableContext(1)]
	[Nullable(0)]
	public class EntityJumpFixTimeAction : EntityMoveAction
	{
		// Token: 0x06044EE9 RID: 282345 RVA: 0x011F15B0 File Offset: 0x011EF7B0
		protected override void OnExecuteAction()
		{
			BaseActorComponent moveActorComp = base.GetMoveActorComp();
			if (moveActorComp == null)
			{
				base.FinishExecute();
				return;
			}
			IJumpConfig jumpConfig = this.Config as IJumpConfig;
			this.CurrentJumpTime = 0f;
			this.StartLocation.DeepCopy(moveActorComp.ActorLocationProxy);
			float num = (float)(this.TargetLocation.Z - this.StartLocation.Z);
			if (num >= 0f)
			{
				this.SignOffsetRate = MathCommon.Clamp(num / jumpConfig.MaxRiseHeightEdge, 0f, 1f);
				return;
			}
			this.SignOffsetRate = MathCommon.Clamp(num / jumpConfig.MaxFallHeightEdge, -1f, 0f);
		}

		// Token: 0x06044EEA RID: 282346 RVA: 0x011F1652 File Offset: 0x011EF852
		protected override void OnInterruptAction()
		{
		}

		// Token: 0x06044EEB RID: 282347 RVA: 0x011F1654 File Offset: 0x011EF854
		public override void TickAction(float delta)
		{
			BaseActorComponent moveActorComp = base.GetMoveActorComp();
			if (moveActorComp == null)
			{
				base.FinishExecute();
				return;
			}
			IJumpConfig jumpConfig = this.Config as IJumpConfig;
			this.CurrentJumpTime += delta;
			if (this.CurrentJumpTime >= jumpConfig.JumpTime)
			{
				moveActorComp.SetActorLocationAndRotation(this.TargetLocation.ToUeVector(false), this.TargetRotator.ToUeRotator(), "EntityJumpFixTimeAction", false, null);
				CharacterActorComponent characterActorComponent = moveActorComp as CharacterActorComponent;
				if (characterActorComponent != null)
				{
					characterActorComponent.SetInputRotator(this.TempRotator);
				}
				base.FinishExecute();
				return;
			}
			float num = MathCommon.Clamp(this.CurrentJumpTime / jumpConfig.JumpTime, 0f, 1f);
			Vector.Lerp(this.StartLocation, this.TargetLocation, (double)num, this.TempVector);
			float powerCurveValue = this.GetPowerCurveValue(num, 2f);
			float floatValue;
			if (this.SignOffsetRate > 0f)
			{
				floatValue = jumpConfig.MoveRiseCurve.GetFloatValue(num);
			}
			else
			{
				floatValue = jumpConfig.MoveFallCurve.GetFloatValue(num);
			}
			float num2 = Math.Abs(this.SignOffsetRate);
			float num3 = (powerCurveValue * (1f - num2) + floatValue * num2) * jumpConfig.MoveBaseHeightOffset;
			this.TempVector.Z += (double)num3;
			Rotator actorRotationProxy = moveActorComp.ActorRotationProxy;
			if (!actorRotationProxy.Equals2(this.TargetRotator, 0.0001f))
			{
				this.TempRotator.DeepCopy(this.TargetRotator);
				Singleton<MathUtils>.Instance.RotatorInterpConstantTo(actorRotationProxy, this.TempRotator, delta * 0.001f, jumpConfig.RotateSpeed, this.TempRotator);
				moveActorComp.SetActorLocationAndRotation(this.TempVector.ToUeVector(false), this.TempRotator.ToUeRotator(), "EntityJumpFixTimeAction", false, null);
				CharacterActorComponent characterActorComponent2 = moveActorComp as CharacterActorComponent;
				if (characterActorComponent2 != null)
				{
					characterActorComponent2.SetInputRotator(this.TempRotator);
				}
				return;
			}
			moveActorComp.SetActorLocation(this.TempVector.ToUeVector(false), "EntityJumpFixTimeAction", false);
		}

		// Token: 0x06044EEC RID: 282348 RVA: 0x011F1845 File Offset: 0x011EFA45
		private float GetPowerCurveValue(float key, float pow)
		{
			return 1f - (float)Math.Pow((double)Math.Abs(2f * key - 1f), (double)pow);
		}

		// Token: 0x040266EF RID: 157423
		private float CurrentJumpTime;

		// Token: 0x040266F0 RID: 157424
		private float SignOffsetRate;

		// Token: 0x040266F1 RID: 157425
		private readonly Vector StartLocation = Vector.Create();

		// Token: 0x040266F2 RID: 157426
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x040266F3 RID: 157427
		private readonly Rotator TempRotator = Rotator.Create();
	}
}
