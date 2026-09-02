using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004416 RID: 17430
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraScaleColorMode.ENiagaraScaleColorMode")]
	public enum ENiagaraScaleColorMode : byte
	{
		// Token: 0x0401A2F3 RID: 107251
		RGB_and_Alpha_Separately,
		// Token: 0x0401A2F4 RID: 107252
		RGBA_Together,
		// Token: 0x0401A2F5 RID: 107253
		ENiagaraScaleColorMode_MAX
	}
}
