using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004403 RID: 17411
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraFrictionMergeType.ENiagaraFrictionMergeType")]
	public enum ENiagaraFrictionMergeType : byte
	{
		// Token: 0x0401A28F RID: 107151
		Ignore,
		// Token: 0x0401A290 RID: 107152
		Average,
		// Token: 0x0401A291 RID: 107153
		Min,
		// Token: 0x0401A292 RID: 107154
		Max,
		// Token: 0x0401A293 RID: 107155
		ENiagaraFrictionMergeType_MAX
	}
}
