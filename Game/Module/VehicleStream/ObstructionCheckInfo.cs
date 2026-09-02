using System;
using System.Runtime.CompilerServices;
using Aki.Protocol;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C42 RID: 19522
	[NullableContext(1)]
	[Nullable(0)]
	public class ObstructionCheckInfo
	{
		// Token: 0x06032E00 RID: 208384 RVA: 0x00CBE784 File Offset: 0x00CBC984
		public void Reset()
		{
			this.HitChanged = false;
			this.CheckResultType = EObstructionCheckResult.None;
			this.HitDistance = float.MaxValue;
			this.HitEntityCreatureDataId = 0L;
			this.DistanceToKeep = 0f;
			this.HitEntityType = null;
			this.IsPlayer = false;
			this.PlayerHitDistance = 0f;
		}

		// Token: 0x06032E01 RID: 208385 RVA: 0x00CBE7DC File Offset: 0x00CBC9DC
		public void DeepCopy(ObstructionCheckInfo info)
		{
			this.CheckResultType = info.CheckResultType;
			this.HitDistance = info.HitDistance;
			this.HitChanged = info.HitChanged;
			this.HitEntityCreatureDataId = info.HitEntityCreatureDataId;
			this.HitEntityType = info.HitEntityType;
			this.DistanceToKeep = info.DistanceToKeep;
			this.IsPlayer = info.IsPlayer;
			this.PlayerHitDistance = info.PlayerHitDistance;
		}

		// Token: 0x06032E02 RID: 208386 RVA: 0x00CBE849 File Offset: 0x00CBCA49
		public bool IsHitTargetChanged(ObstructionCheckInfo info)
		{
			return this.CheckResultType != info.CheckResultType || this.HitEntityCreatureDataId != info.HitEntityCreatureDataId;
		}

		// Token: 0x06032E03 RID: 208387 RVA: 0x00CBE86C File Offset: 0x00CBCA6C
		public void TryUpdateHitDistance(EObstructionCheckResult checkResult, long hitEntityCreatureDataId, EEntityType hitEntityType, float hitDistance, bool bPlayer = false)
		{
			if (hitDistance >= this.HitDistance)
			{
				return;
			}
			this.CheckResultType = checkResult;
			this.HitEntityCreatureDataId = hitEntityCreatureDataId;
			this.HitEntityType = new EEntityType?(hitEntityType);
			this.HitDistance = hitDistance;
			this.IsPlayer = bPlayer;
			switch (checkResult)
			{
			case EObstructionCheckResult.TraceBlock:
				this.DistanceToKeep = (bPlayer ? 5f : 3f);
				return;
			case EObstructionCheckResult.CheckPlayerBlock:
				this.DistanceToKeep = 5f;
				return;
			case EObstructionCheckResult.SameRoadwayVehicleBlock:
				this.DistanceToKeep = 3f;
				return;
			case EObstructionCheckResult.NextRoadwayVehicleBlock:
				this.DistanceToKeep = 6f;
				return;
			default:
				return;
			}
		}

		// Token: 0x0401D9CF RID: 121295
		public bool HitChanged;

		// Token: 0x0401D9D0 RID: 121296
		public EObstructionCheckResult CheckResultType;

		// Token: 0x0401D9D1 RID: 121297
		public float HitDistance;

		// Token: 0x0401D9D2 RID: 121298
		public long HitEntityCreatureDataId;

		// Token: 0x0401D9D3 RID: 121299
		public EEntityType? HitEntityType;

		// Token: 0x0401D9D4 RID: 121300
		public float DistanceToKeep = 3f;

		// Token: 0x0401D9D5 RID: 121301
		public bool IsPlayer;

		// Token: 0x0401D9D6 RID: 121302
		public float PlayerHitDistance;
	}
}
