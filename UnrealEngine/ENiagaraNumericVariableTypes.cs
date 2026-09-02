using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004410 RID: 17424
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraNumericVariableTypes.ENiagaraNumericVariableTypes")]
	public enum ENiagaraNumericVariableTypes : byte
	{
		// Token: 0x0401A2D2 RID: 107218
		Float,
		// Token: 0x0401A2D3 RID: 107219
		Vector_2D,
		// Token: 0x0401A2D4 RID: 107220
		Vector_3D,
		// Token: 0x0401A2D5 RID: 107221
		Vector_4D,
		// Token: 0x0401A2D6 RID: 107222
		Linear_Color,
		// Token: 0x0401A2D7 RID: 107223
		Quaternion,
		// Token: 0x0401A2D8 RID: 107224
		ENiagaraNumericVariableTypes_MAX
	}
}
