using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004404 RID: 17412
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraGPUDepthResponseType.ENiagaraGPUDepthResponseType")]
	public enum ENiagaraGPUDepthResponseType : byte
	{
		// Token: 0x0401A295 RID: 107157
		Kill,
		// Token: 0x0401A296 RID: 107158
		Bounce,
		// Token: 0x0401A297 RID: 107159
		ENiagaraGPUDepthResponseType_MAX
	}
}
