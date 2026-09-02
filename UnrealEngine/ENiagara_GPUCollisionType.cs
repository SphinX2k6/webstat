using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004435 RID: 17461
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_GPUCollisionType.ENiagara_GPUCollisionType")]
	public enum ENiagara_GPUCollisionType : byte
	{
		// Token: 0x0401A38D RID: 107405
		GPU_Depth_Buffer,
		// Token: 0x0401A38E RID: 107406
		GPU_Distance_Fields,
		// Token: 0x0401A38F RID: 107407
		Analytical_Planes,
		// Token: 0x0401A390 RID: 107408
		ENiagara_MAX
	}
}
