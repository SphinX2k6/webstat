using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004432 RID: 17458
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_EmitterStateOptions.ENiagara_EmitterStateOptions")]
	public enum ENiagara_EmitterStateOptions : byte
	{
		// Token: 0x0401A37E RID: 107390
		Infinite,
		// Token: 0x0401A37F RID: 107391
		Once,
		// Token: 0x0401A380 RID: 107392
		Multiple,
		// Token: 0x0401A381 RID: 107393
		ENiagara_MAX
	}
}
