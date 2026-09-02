using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004407 RID: 17415
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraKillVolumeOptions.ENiagaraKillVolumeOptions")]
	public enum ENiagaraKillVolumeOptions : byte
	{
		// Token: 0x0401A2A2 RID: 107170
		Sphere,
		// Token: 0x0401A2A3 RID: 107171
		Box,
		// Token: 0x0401A2A4 RID: 107172
		Plane,
		// Token: 0x0401A2A5 RID: 107173
		Slab,
		// Token: 0x0401A2A6 RID: 107174
		Cone,
		// Token: 0x0401A2A7 RID: 107175
		ENiagaraKillVolumeOptions_MAX
	}
}
