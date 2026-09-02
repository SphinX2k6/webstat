using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200441B RID: 17435
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSocketSamplingMode.ENiagaraSocketSamplingMode")]
	public enum ENiagaraSocketSamplingMode : byte
	{
		// Token: 0x0401A30C RID: 107276
		Random__Filtered_Sockets_,
		// Token: 0x0401A30D RID: 107277
		Direct__Filtered_Sockets_,
		// Token: 0x0401A30E RID: 107278
		ENiagaraSocketSamplingMode_MAX
	}
}
