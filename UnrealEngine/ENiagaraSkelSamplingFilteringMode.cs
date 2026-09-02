using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004419 RID: 17433
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSkelSamplingFilteringMode.ENiagaraSkelSamplingFilteringMode")]
	public enum ENiagaraSkelSamplingFilteringMode : byte
	{
		// Token: 0x0401A300 RID: 107264
		All,
		// Token: 0x0401A301 RID: 107265
		Filtered,
		// Token: 0x0401A302 RID: 107266
		Unfiltered,
		// Token: 0x0401A303 RID: 107267
		ENiagaraSkelSamplingFilteringMode_MAX
	}
}
