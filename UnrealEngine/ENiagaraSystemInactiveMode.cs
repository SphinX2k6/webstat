using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200441E RID: 17438
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSystemInactiveMode.ENiagaraSystemInactiveMode")]
	public enum ENiagaraSystemInactiveMode : byte
	{
		// Token: 0x0401A319 RID: 107289
		Complete__Let_Emitters_Finish_then_Kill_The_System_,
		// Token: 0x0401A31A RID: 107290
		Kill__System_and_Emitters_Die_Immediately_,
		// Token: 0x0401A31B RID: 107291
		ENiagaraSystemInactiveMode_MAX
	}
}
