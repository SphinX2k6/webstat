using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F4 RID: 17396
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraArraySamplingMode.ENiagaraArraySamplingMode")]
	public enum ENiagaraArraySamplingMode : byte
	{
		// Token: 0x0401A23D RID: 107069
		Random,
		// Token: 0x0401A23E RID: 107070
		Direct,
		// Token: 0x0401A23F RID: 107071
		Interpolate,
		// Token: 0x0401A240 RID: 107072
		ENiagaraArraySamplingMode_MAX
	}
}
