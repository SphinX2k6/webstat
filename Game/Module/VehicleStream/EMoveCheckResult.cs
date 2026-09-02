using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C43 RID: 19523
	[EnumExtensions]
	public enum EMoveCheckResult
	{
		// Token: 0x0401D9D8 RID: 121304
		None,
		// Token: 0x0401D9D9 RID: 121305
		TraceBlock,
		// Token: 0x0401D9DA RID: 121306
		CheckPlayerBlock,
		// Token: 0x0401D9DB RID: 121307
		SameRoadwayVehicleBlock,
		// Token: 0x0401D9DC RID: 121308
		NextRoadwayVehicleBlock,
		// Token: 0x0401D9DD RID: 121309
		Intersection,
		// Token: 0x0401D9DE RID: 121310
		CrossPlayer,
		// Token: 0x0401D9DF RID: 121311
		CrossSameRoadwayVehicle,
		// Token: 0x0401D9E0 RID: 121312
		CrossNextRoadwayVehicle,
		// Token: 0x0401D9E1 RID: 121313
		HeadOverRoadOnWaitIntersection
	}
}
