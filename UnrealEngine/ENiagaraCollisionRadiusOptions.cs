using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043FB RID: 17403
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraCollisionRadiusOptions.ENiagaraCollisionRadiusOptions")]
	public enum ENiagaraCollisionRadiusOptions : byte
	{
		// Token: 0x0401A266 RID: 107110
		Sprite,
		// Token: 0x0401A267 RID: 107111
		Mesh,
		// Token: 0x0401A268 RID: 107112
		Custom,
		// Token: 0x0401A269 RID: 107113
		ENiagaraCollisionRadiusOptions_MAX
	}
}
