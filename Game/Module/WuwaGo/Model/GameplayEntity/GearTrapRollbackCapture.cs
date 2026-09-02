using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE4 RID: 19172
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	public class GearTrapRollbackCapture : GameplayEntityRollbackCapture<WuWaGoGearTrapEntity>
	{
		// Token: 0x06031FCA RID: 204746 RVA: 0x00C83074 File Offset: 0x00C81274
		public GearTrapRollbackCapture(WuWaGoGearTrapEntity entity) : base(entity)
		{
			this.MoveDirection = Vector.Create();
			this.MoveDirection.DeepCopy(entity.MoveDirection);
			this.Position = Vector.Create();
			this.Position.DeepCopy(entity.Position);
			this.Coordinate = Vector.Create();
			this.Coordinate.DeepCopy(entity.Coordinate);
			this.Rotator = Rotator.Create();
			this.Rotator.DeepCopy(entity.Rotator);
			this.PendingAttackTargetUnitId = entity.PeekPendingAttackTargetUnitId();
		}

		// Token: 0x06031FCB RID: 204747 RVA: 0x00C83104 File Offset: 0x00C81304
		public override void Restore()
		{
			base.Restore();
			base.Entity.UpdatePosition(this.Position);
			base.Entity.SetCoordinate(this.Coordinate);
			base.Entity.SetRotator(this.Rotator);
			base.Entity.SetMoveDirection(this.MoveDirection);
			base.Entity.SetPendingAttackTargetUnitIdForRollback(this.PendingAttackTargetUnitId);
		}

		// Token: 0x0401D3E6 RID: 119782
		private readonly Vector MoveDirection;

		// Token: 0x0401D3E7 RID: 119783
		private readonly Vector Position;

		// Token: 0x0401D3E8 RID: 119784
		private readonly Vector Coordinate;

		// Token: 0x0401D3E9 RID: 119785
		private readonly Rotator Rotator;

		// Token: 0x0401D3EA RID: 119786
		private readonly int? PendingAttackTargetUnitId;
	}
}
