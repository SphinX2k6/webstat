using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004420 RID: 17440
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraTorusMode.ENiagaraTorusMode")]
	public enum ENiagaraTorusMode : byte
	{
		// Token: 0x0401A321 RID: 107297
		Torus,
		// Token: 0x0401A322 RID: 107298
		TorusKnot,
		// Token: 0x0401A323 RID: 107299
		Ring,
		// Token: 0x0401A324 RID: 107300
		ENiagaraTorusMode_MAX
	}
}
