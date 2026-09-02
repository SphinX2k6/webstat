using System;
using System.Runtime.CompilerServices;

namespace CSharpScript.Game.LevelGamePlay
{
	// Token: 0x02006A54 RID: 27220
	public class SplinePointArrivalContext : GeneralContext
	{
		// Token: 0x06043522 RID: 275746 RVA: 0x0114DE74 File Offset: 0x0114C074
		public SplinePointArrivalContext()
		{
			this.Type = new EGeneralContextType?(EGeneralContextType.SplinePointArrival);
		}

		// Token: 0x06043523 RID: 275747 RVA: 0x0114DE89 File Offset: 0x0114C089
		public override void Reset()
		{
			base.Reset();
			this.EntityId = 0;
			this.SplineId = 0;
			this.PointIndex = 0;
		}

		// Token: 0x06043524 RID: 275748 RVA: 0x0114DEA8 File Offset: 0x0114C0A8
		[NullableContext(1)]
		public static SplinePointArrivalContext Create(int entityId, int splineId, int pointIndex)
		{
			SplinePointArrivalContext splinePointArrivalContext = GeneralContext.GetObj(EGeneralContextType.SplinePointArrival, null, () => new SplinePointArrivalContext()) as SplinePointArrivalContext;
			splinePointArrivalContext.EntityId = entityId;
			splinePointArrivalContext.SplineId = splineId;
			splinePointArrivalContext.PointIndex = pointIndex;
			return splinePointArrivalContext;
		}

		// Token: 0x040258AA RID: 153770
		public int EntityId;

		// Token: 0x040258AB RID: 153771
		public int SplineId;

		// Token: 0x040258AC RID: 153772
		public int PointIndex;
	}
}
