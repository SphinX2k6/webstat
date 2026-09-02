using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.Module.WuwaGo.Model.GameplayEntity
{
	// Token: 0x02004AE6 RID: 19174
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	internal class MovableFloorRollbackCapture : GameplayEntityRollbackCapture<WuWaGoMovableFloorEntity>
	{
		// Token: 0x06031FE4 RID: 204772 RVA: 0x00C834AC File Offset: 0x00C816AC
		public MovableFloorRollbackCapture(WuWaGoMovableFloorEntity entity) : base(entity)
		{
			this.CurrentStateIndex = entity.StateIndex;
			this.Coordinate = Vector.Create();
			this.Coordinate.DeepCopy(entity.Coordinate);
		}

		// Token: 0x06031FE5 RID: 204773 RVA: 0x00C834DD File Offset: 0x00C816DD
		public override void Restore()
		{
			base.Restore();
			base.Entity.RestoreMoveStateForRollback(this.CurrentStateIndex);
			base.Entity.SetCoordinate(this.Coordinate);
		}

		// Token: 0x0401D3F1 RID: 119793
		private readonly int CurrentStateIndex;

		// Token: 0x0401D3F2 RID: 119794
		private readonly Vector Coordinate;
	}
}
