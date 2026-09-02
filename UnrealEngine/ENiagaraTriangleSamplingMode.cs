using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004421 RID: 17441
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraTriangleSamplingMode.ENiagaraTriangleSamplingMode")]
	public enum ENiagaraTriangleSamplingMode : byte
	{
		// Token: 0x0401A326 RID: 107302
		Random__All_Triangles_,
		// Token: 0x0401A327 RID: 107303
		Random__Sampling_Regions_,
		// Token: 0x0401A328 RID: 107304
		Direct__All_Triangles_,
		// Token: 0x0401A329 RID: 107305
		Direct__Sampling_Regions_,
		// Token: 0x0401A32A RID: 107306
		ENiagaraTriangleSamplingMode_MAX
	}
}
