using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004415 RID: 17429
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraRestitutionMergeType.ENiagaraRestitutionMergeType")]
	public enum ENiagaraRestitutionMergeType : byte
	{
		// Token: 0x0401A2ED RID: 107245
		Ignore,
		// Token: 0x0401A2EE RID: 107246
		Min,
		// Token: 0x0401A2EF RID: 107247
		Max,
		// Token: 0x0401A2F0 RID: 107248
		Average,
		// Token: 0x0401A2F1 RID: 107249
		ENiagaraRestitutionMergeType_MAX
	}
}
