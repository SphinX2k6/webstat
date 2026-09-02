using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004406 RID: 17414
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraInactiveMode.ENiagaraInactiveMode")]
	public enum ENiagaraInactiveMode : byte
	{
		// Token: 0x0401A29D RID: 107165
		Complete__Let_Particles_Finish_then_Kill_Emitter_,
		// Token: 0x0401A29E RID: 107166
		Kill__Emitter_and_Particles_Die_Immediately_,
		// Token: 0x0401A29F RID: 107167
		Continue__Emitter_Deactivates_But_Doesn_t_Die_Until_System_Does_,
		// Token: 0x0401A2A0 RID: 107168
		ENiagaraInactiveMode_MAX
	}
}
