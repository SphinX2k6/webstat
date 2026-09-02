using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F1 RID: 17393
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/CascadeConversion/ECascadeNiagaraOrbitChainMode.ECascadeNiagaraOrbitChainMode")]
	public enum ECascadeNiagaraOrbitChainMode : byte
	{
		// Token: 0x0401A22E RID: 107054
		Add,
		// Token: 0x0401A22F RID: 107055
		Scale,
		// Token: 0x0401A230 RID: 107056
		Link,
		// Token: 0x0401A231 RID: 107057
		NONE,
		// Token: 0x0401A232 RID: 107058
		ECascadeNiagaraOrbitChainMode_MAX
	}
}
