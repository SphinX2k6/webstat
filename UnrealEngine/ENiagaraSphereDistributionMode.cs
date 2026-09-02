using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200441C RID: 17436
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSphereDistributionMode.ENiagaraSphereDistributionMode")]
	public enum ENiagaraSphereDistributionMode : byte
	{
		// Token: 0x0401A310 RID: 107280
		Random,
		// Token: 0x0401A311 RID: 107281
		Direct,
		// Token: 0x0401A312 RID: 107282
		Uniform,
		// Token: 0x0401A313 RID: 107283
		ENiagaraSphereDistributionMode_MAX
	}
}
