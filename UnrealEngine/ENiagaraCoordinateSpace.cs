using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043FC RID: 17404
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraCoordinateSpace.ENiagaraCoordinateSpace")]
	public enum ENiagaraCoordinateSpace : byte
	{
		// Token: 0x0401A26B RID: 107115
		Simulation,
		// Token: 0x0401A26C RID: 107116
		World,
		// Token: 0x0401A26D RID: 107117
		Local,
		// Token: 0x0401A26E RID: 107118
		ENiagaraCoordinateSpace_MAX
	}
}
