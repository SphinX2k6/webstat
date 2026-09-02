using System;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Utils;
using UnrealEngine;

namespace CSharpScript.Game.LevelFlow.Condition
{
	// Token: 0x02006F81 RID: 28545
	[NullableContext(1)]
	[Nullable(0)]
	public class LevelFlowCubeRangeCondition : LevelFlowConditionBase
	{
		// Token: 0x06045149 RID: 282953 RVA: 0x012035FC File Offset: 0x012017FC
		public LevelFlowCubeRangeCondition Init(Vector center, Vector extent, Rotator rotation)
		{
			if (Global.BaseCharacter == null)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "Invalid BaseCharacter", default(ReadOnlySpan<ValueTuple<string, object>>));
				return this;
			}
			EntityHandle entityById = ModelBase<CreatureModel>.Instance.GetEntityById(Global.BaseCharacter.EntityId);
			if (entityById == null || !entityById.Valid)
			{
				Log instance = Singleton<Log>.Instance;
				ELogModule module = ELogModule.LevelFlow;
				ELogAuthor author = ELogAuthor.BB;
				string message = "Invalid EntityId";
				ValueTuple<string, object> valueTuple = new ValueTuple<string, object>("targetEntityId", Global.BaseCharacter.EntityId);
				instance.Error(module, author, message, new ReadOnlySpan<ValueTuple<string, object>>(ref valueTuple));
				return this;
			}
			this.TargetActorComponent = entityById.Entity.CheckGetComponent<BaseActorComponent>();
			if (this.TargetActorComponent == null)
			{
				return this;
			}
			this.Center = center;
			this.Extent = extent;
			this.Rotation = rotation;
			return this;
		}

		// Token: 0x0604514A RID: 282954 RVA: 0x012036BC File Offset: 0x012018BC
		protected override void OnTick(float delta)
		{
			if (this.TargetActorComponent == null || !this.TargetActorComponent.Valid)
			{
				Singleton<Log>.Instance.Error(ELogModule.LevelFlow, ELogAuthor.BB, "TargetActorComponent is invalid", default(ReadOnlySpan<ValueTuple<string, object>>));
				base.FinishExecute(false);
				return;
			}
			Vector actorLocationProxy = this.TargetActorComponent.ActorLocationProxy;
			if (this.PrePosition.Equals(Vector.ZeroVectorProxy, 9.999999747378752E-05))
			{
				this.WorldPositionToLocal(actorLocationProxy, this.PrePosition);
				if (this.CheckInside(this.PrePosition))
				{
					this.PrePosition.DeepCopy(Vector.ZeroVectorProxy);
					base.FinishExecute(true);
				}
			}
			else
			{
				this.WorldPositionToLocal(actorLocationProxy, this.TempVector);
				if (this.CheckSegmentInCube(this.PrePosition, this.TempVector))
				{
					this.PrePosition.DeepCopy(Vector.ZeroVectorProxy);
					base.FinishExecute(true);
				}
				else
				{
					this.PrePosition.DeepCopy(this.TempVector);
				}
			}
			if (ModelBase<LevelFlowModel>.Instance.IsDebug)
			{
				UKismetSystemLibrary.D_DrawDebugBox(GlobalData.World, this.Center.ToUeVector(false), this.Extent.ToUeVector(false), ColorUtils.LinearRed, this.Rotation.ToUeRotator(), 1f, 10f);
			}
		}

		// Token: 0x0604514B RID: 282955 RVA: 0x012037F4 File Offset: 0x012019F4
		private bool CheckInside(Vector position)
		{
			return Math.Abs(position.X) <= this.Extent.X && Math.Abs(position.Y) <= this.Extent.Y && Math.Abs(position.Z) <= this.Extent.Z;
		}

		// Token: 0x0604514C RID: 282956 RVA: 0x01203850 File Offset: 0x01201A50
		private void WorldPositionToLocal(Vector worldPos, Vector localPos)
		{
			Vector inV = worldPos.Subtraction(this.Center, localPos);
			this.Rotation.Quaternion(this.TempQuat);
			this.TempQuat.Inverse(this.TempQuat);
			this.TempQuat.RotateVector(inV, localPos);
		}

		// Token: 0x0604514D RID: 282957 RVA: 0x0120389C File Offset: 0x01201A9C
		private bool CheckSegmentInCube(Vector segmentStart, Vector segmentEnd)
		{
			segmentEnd.Subtraction(segmentStart, this.TempVector1);
			LevelFlowCubeRangeCondition.<>c__DisplayClass12_0 CS$<>8__locals1;
			CS$<>8__locals1.min = 0.0;
			CS$<>8__locals1.max = 1.0;
			return LevelFlowCubeRangeCondition.<CheckSegmentInCube>g__checkAxisInCube|12_0(segmentStart.X, this.TempVector1.X, -this.Extent.X, this.Extent.X, ref CS$<>8__locals1) && LevelFlowCubeRangeCondition.<CheckSegmentInCube>g__checkAxisInCube|12_0(segmentStart.Y, this.TempVector1.Y, -this.Extent.Y, this.Extent.Y, ref CS$<>8__locals1) && LevelFlowCubeRangeCondition.<CheckSegmentInCube>g__checkAxisInCube|12_0(segmentStart.Z, this.TempVector1.Z, -this.Extent.Z, this.Extent.Z, ref CS$<>8__locals1);
		}

		// Token: 0x0604514F RID: 282959 RVA: 0x01203A04 File Offset: 0x01201C04
		[CompilerGenerated]
		internal static bool <CheckSegmentInCube>g__checkAxisInCube|12_0(double original, double delta, double minValue, double maxValue, ref LevelFlowCubeRangeCondition.<>c__DisplayClass12_0 A_4)
		{
			if (Math.Abs(delta) < 9.999999747378752E-05)
			{
				if (original < minValue || original > maxValue)
				{
					return false;
				}
			}
			else
			{
				double num = (minValue - original) / delta;
				double num2 = (maxValue - original) / delta;
				if (num > num2)
				{
					double num3 = num2;
					num2 = num;
					num = num3;
				}
				A_4.min = Math.Max(num, A_4.min);
				A_4.max = Math.Min(num2, A_4.max);
				if (A_4.min > A_4.max)
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x040268C2 RID: 157890
		private Vector Center = Vector.ZeroVectorProxy;

		// Token: 0x040268C3 RID: 157891
		private Vector Extent = Vector.ZeroVectorProxy;

		// Token: 0x040268C4 RID: 157892
		private Rotator Rotation = Rotator.Create();

		// Token: 0x040268C5 RID: 157893
		[Nullable(2)]
		private BaseActorComponent TargetActorComponent;

		// Token: 0x040268C6 RID: 157894
		private readonly Vector PrePosition = Vector.Create(0.0, 0.0, 0.0);

		// Token: 0x040268C7 RID: 157895
		private readonly Vector TempVector = Vector.Create();

		// Token: 0x040268C8 RID: 157896
		private readonly Vector TempVector1 = Vector.Create();

		// Token: 0x040268C9 RID: 157897
		private readonly Quat TempQuat = Quat.Create(0f, 0f, 0f, 1f);
	}
}
