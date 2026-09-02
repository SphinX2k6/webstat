using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using CSharpScript.Game.Module.WuwaGo.Model;

namespace CSharpScript.Game.Module.WuwaGo.Movement
{
	// Token: 0x02004AC9 RID: 19145
	[NullableContext(1)]
	[Nullable(0)]
	public class WuWaGoGridController
	{
		// Token: 0x06031E9C RID: 204444 RVA: 0x00C7DB18 File Offset: 0x00C7BD18
		public WuWaGoGridController(WuWaGoGrid grid)
		{
		}

		// Token: 0x06031E9D RID: 204445 RVA: 0x00C7DB28 File Offset: 0x00C7BD28
		public IWuWaGoGridRelocationRequest CreateRelocationRequest(Vector targetCoordinate)
		{
			Vector vector = Vector.Create(this.Grid.Coordinate);
			Vector vector2 = Vector.Create(targetCoordinate);
			return new WuWaGoGridRelocationRequest
			{
				GridController = this,
				Grid = this.Grid,
				StartCoordinate = vector,
				TargetCoordinate = vector2,
				OldKey = WuWaGoUtil.GetCoordinateKeyByVector(vector),
				TargetKey = WuWaGoUtil.GetCoordinateKeyByVector(vector2),
				Participants = this.Grid.SnapshotMoveParticipants()
			};
		}

		// Token: 0x06031E9E RID: 204446 RVA: 0x00C7DB9C File Offset: 0x00C7BD9C
		public List<IWuWaGoWorldMoveTarget> BuildWorldMoveTargets(IWuWaGoGridRelocationRequest request)
		{
			List<IWuWaGoWorldMoveTarget> list = new List<IWuWaGoWorldMoveTarget>();
			foreach (IWuWaGoGridMoveParticipant wuWaGoGridMoveParticipant in request.Participants)
			{
				Func<IWuWaGoGridRelocationContext, IWuWaGoWorldMoveTarget> createWorldMoveTarget = wuWaGoGridMoveParticipant.CreateWorldMoveTarget;
				IWuWaGoWorldMoveTarget wuWaGoWorldMoveTarget = (createWorldMoveTarget != null) ? createWorldMoveTarget(request) : null;
				if (wuWaGoWorldMoveTarget != null)
				{
					list.Add(wuWaGoWorldMoveTarget);
				}
			}
			return WuWaGoActorMoveHelper.BuildGridMoveTargets(request.Grid, null, null, list);
		}

		// Token: 0x0401D357 RID: 119639
		public readonly WuWaGoGrid Grid = grid;
	}
}
