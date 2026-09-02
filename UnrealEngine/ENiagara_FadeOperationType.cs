using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004433 RID: 17459
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_FadeOperationType.ENiagara_FadeOperationType")]
	public enum ENiagara_FadeOperationType : byte
	{
		// Token: 0x0401A383 RID: 107395
		Linear,
		// Token: 0x0401A384 RID: 107396
		Percentage,
		// Token: 0x0401A385 RID: 107397
		ENiagara_MAX
	}
}
