using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004412 RID: 17426
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraQuaternionDerivationTechnique.ENiagaraQuaternionDerivationTechnique")]
	public enum ENiagaraQuaternionDerivationTechnique : byte
	{
		// Token: 0x0401A2DF RID: 107231
		X_Vector,
		// Token: 0x0401A2E0 RID: 107232
		X_And_Y_Vectors,
		// Token: 0x0401A2E1 RID: 107233
		X_And_Z_Vectors,
		// Token: 0x0401A2E2 RID: 107234
		ENiagaraQuaternionDerivationTechnique_MAX
	}
}
