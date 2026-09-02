using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004414 RID: 17428
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraRandomnessMode.ENiagaraRandomnessMode")]
	public enum ENiagaraRandomnessMode : byte
	{
		// Token: 0x0401A2E8 RID: 107240
		Simulation_Defaults,
		// Token: 0x0401A2E9 RID: 107241
		Determinisitic,
		// Token: 0x0401A2EA RID: 107242
		Non_Deterministic,
		// Token: 0x0401A2EB RID: 107243
		ENiagaraRandomnessMode_MAX
	}
}
