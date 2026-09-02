using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004426 RID: 17446
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraVertexSamplingMode.ENiagaraVertexSamplingMode")]
	public enum ENiagaraVertexSamplingMode : byte
	{
		// Token: 0x0401A33F RID: 107327
		Random__All_Vertices_,
		// Token: 0x0401A340 RID: 107328
		Random__Sampling_Regions_,
		// Token: 0x0401A341 RID: 107329
		Direct__All_Vertices_,
		// Token: 0x0401A342 RID: 107330
		Direct__Sampling_Regions_,
		// Token: 0x0401A343 RID: 107331
		ENiagaraVertexSamplingMode_MAX
	}
}
