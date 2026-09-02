using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004445 RID: 17477
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_UVFlippingMode.ENiagara_UVFlippingMode")]
	public enum ENiagara_UVFlippingMode : byte
	{
		// Token: 0x0401A3E0 RID: 107488
		Unset,
		// Token: 0x0401A3E1 RID: 107489
		Random_X,
		// Token: 0x0401A3E2 RID: 107490
		Random_Y,
		// Token: 0x0401A3E3 RID: 107491
		Random_X___Y,
		// Token: 0x0401A3E4 RID: 107492
		Custom,
		// Token: 0x0401A3E5 RID: 107493
		ENiagara_MAX
	}
}
