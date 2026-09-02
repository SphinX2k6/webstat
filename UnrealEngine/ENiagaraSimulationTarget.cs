using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004417 RID: 17431
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSimulationTarget.ENiagaraSimulationTarget")]
	public enum ENiagaraSimulationTarget : byte
	{
		// Token: 0x0401A2F7 RID: 107255
		CPU_Sim,
		// Token: 0x0401A2F8 RID: 107256
		GPUCompute_Sim,
		// Token: 0x0401A2F9 RID: 107257
		ENiagaraSimulationTarget_MAX
	}
}
