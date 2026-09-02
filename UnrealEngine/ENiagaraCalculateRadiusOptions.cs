using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F9 RID: 17401
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraCalculateRadiusOptions.ENiagaraCalculateRadiusOptions")]
	public enum ENiagaraCalculateRadiusOptions : byte
	{
		// Token: 0x0401A25C RID: 107100
		Bounds,
		// Token: 0x0401A25D RID: 107101
		Minimum_Axis,
		// Token: 0x0401A25E RID: 107102
		Maximum_Axis,
		// Token: 0x0401A25F RID: 107103
		ENiagaraCalculateRadiusOptions_MAX
	}
}
