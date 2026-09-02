using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200442F RID: 17455
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_DirectReadParticleIDSampling.ENiagara_DirectReadParticleIDSampling")]
	public enum ENiagara_DirectReadParticleIDSampling : byte
	{
		// Token: 0x0401A370 RID: 107376
		Disabled,
		// Token: 0x0401A371 RID: 107377
		Apply_Sampled_ID_as_Ribbon_ID,
		// Token: 0x0401A372 RID: 107378
		Output_Only,
		// Token: 0x0401A373 RID: 107379
		ENiagara_MAX
	}
}
