using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004439 RID: 17465
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_LifetimeMode.ENiagara_LifetimeMode")]
	public enum ENiagara_LifetimeMode : byte
	{
		// Token: 0x0401A3A0 RID: 107424
		Direct_Set,
		// Token: 0x0401A3A1 RID: 107425
		Random,
		// Token: 0x0401A3A2 RID: 107426
		ENiagara_MAX
	}
}
