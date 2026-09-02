using System;
using System.Runtime.CompilerServices;
using UnrealEngine;

namespace CSharpScript.Game.Module.Reward
{
	// Token: 0x02005288 RID: 21128
	[NullableContext(1)]
	[Nullable(new byte[]
	{
		0,
		1
	})]
	[Model(0)]
	public class RewardModel : ModelBase<RewardModel>
	{
		// Token: 0x06036073 RID: 221299 RVA: 0x00D990C8 File Offset: 0x00D972C8
		private void InitTraceInfo()
		{
			this.GroundTrace = new UTraceSphereElement();
			this.GroundTrace.WorldContextObject = GlobalData.World;
			this.GroundTrace.bIsSingle = true;
			this.GroundTrace.bIgnoreSelf = true;
			this.GroundTrace.AddObjectTypeQuery(KuroObjectTypeQuery.WorldStatic);
			this.WaterTrace = new UTraceLineElement();
			this.WaterTrace.WorldContextObject = GlobalData.World;
			this.WaterTrace.bIsSingle = true;
			this.WaterTrace.bIgnoreSelf = true;
			this.WaterTrace.SetTraceTypeQuery(KuroTraceTypeQuery.Water);
		}

		// Token: 0x06036074 RID: 221300 RVA: 0x00D9915C File Offset: 0x00D9735C
		public bool CheckGroundHit(IVector centerLocation, float radius, float zOffset)
		{
			if (this.GroundTrace == null)
			{
				this.InitTraceInfo();
			}
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.GroundTrace, centerLocation);
			this.GroundTrace.SetEndLocation(centerLocation.X, centerLocation.Y, centerLocation.Z + (double)zOffset);
			this.GroundTrace.Radius = radius;
			bool result = false;
			if (Singleton<TraceElementCommon>.Instance.SphereTrace(this.GroundTrace, "RewardModel_CheckGroundHit") && this.GroundTrace.HitResult.bBlockingHit)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x06036075 RID: 221301 RVA: 0x00D991E4 File Offset: 0x00D973E4
		public bool CheckWaterHit(IVector preFrameLocation, IVector centerLocation, float zOffset, float radius)
		{
			if (this.WaterTrace == null)
			{
				this.InitTraceInfo();
			}
			Singleton<TraceElementCommon>.Instance.SetStartLocation(this.WaterTrace, preFrameLocation);
			this.WaterTrace.SetEndLocation(centerLocation.X, centerLocation.Y, centerLocation.Z - (double)zOffset);
			bool result = false;
			if (Singleton<TraceElementCommon>.Instance.LineTrace(this.WaterTrace, "RewardModel_CheckWaterHit") && this.WaterTrace.HitResult.bBlockingHit)
			{
				result = true;
			}
			return result;
		}

		// Token: 0x0401F0E1 RID: 127201
		private const string CHECK_GROUND_PROFILE_KEY = "RewardModel_CheckGroundHit";

		// Token: 0x0401F0E2 RID: 127202
		private const string CHECK_WATER_PROFILE_KEY = "RewardModel_CheckWaterHit";

		// Token: 0x0401F0E3 RID: 127203
		[Nullable(2)]
		private UTraceSphereElement GroundTrace;

		// Token: 0x0401F0E4 RID: 127204
		[Nullable(2)]
		private UTraceLineElement WaterTrace;
	}
}
