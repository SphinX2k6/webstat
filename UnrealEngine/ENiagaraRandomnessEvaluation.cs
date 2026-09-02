using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004413 RID: 17427
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraRandomnessEvaluation.ENiagaraRandomnessEvaluation")]
	public enum ENiagaraRandomnessEvaluation : byte
	{
		// Token: 0x0401A2E4 RID: 107236
		Spawn_Only,
		// Token: 0x0401A2E5 RID: 107237
		Every_Frame,
		// Token: 0x0401A2E6 RID: 107238
		ENiagaraRandomnessEvaluation_MAX
	}
}
