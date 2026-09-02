using System;
using CSharpScript.Core.Common;

namespace CSharpScript.Game.Module.VehicleStream
{
	// Token: 0x02004C40 RID: 19520
	[EnumExtensions]
	public enum EObstructionCheckResult
	{
		// Token: 0x0401D9C6 RID: 121286
		None,
		// Token: 0x0401D9C7 RID: 121287
		TraceBlock,
		// Token: 0x0401D9C8 RID: 121288
		CheckPlayerBlock,
		// Token: 0x0401D9C9 RID: 121289
		SameRoadwayVehicleBlock,
		// Token: 0x0401D9CA RID: 121290
		NextRoadwayVehicleBlock
	}
}
