using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Movement;
using UnrealEngine;

namespace CSharpScript.Game.Module.WuwaGo.Model
{
	// Token: 0x02004AD4 RID: 19156
	[NullableContext(1)]
	[Nullable(0)]
	internal class GridRollbackCapture : IRollbackCapture
	{
		// Token: 0x06031F15 RID: 204565 RVA: 0x00C80FF3 File Offset: 0x00C7F1F3
		public GridRollbackCapture(WuWaGoGrid grid)
		{
			this.Grid = grid;
			this.PreCoordinate = Vector.Create();
			this.PreCoordinate.DeepCopy(this.Grid.Coordinate);
		}

		// Token: 0x06031F16 RID: 204566 RVA: 0x00C81024 File Offset: 0x00C7F224
		public void Restore()
		{
			Transform originTransform = ModelBase<WuWaGoModel>.Instance.GameData.OriginTransform;
			if (originTransform == null)
			{
				return;
			}
			Vector coordinate = this.Grid.Coordinate;
			if (coordinate.Equals(this.PreCoordinate, 9.999999747378752E-05))
			{
				return;
			}
			AActor applique = this.Grid.Applique;
			if (applique != null && applique.IsValid())
			{
				WuWaGoActorMoveHelper.SnapMoveTargetsByGridCoordinateDelta(originTransform, coordinate, this.PreCoordinate, new List<IWuWaGoWorldMoveTarget>
				{
					new WuWaGoWorldMoveTarget
					{
						Actor = applique
					}
				});
			}
			this.Grid.SetCoordinate(this.PreCoordinate);
		}

		// Token: 0x0401D3A1 RID: 119713
		private readonly Vector PreCoordinate;

		// Token: 0x0401D3A2 RID: 119714
		private readonly WuWaGoGrid Grid;
	}
}
