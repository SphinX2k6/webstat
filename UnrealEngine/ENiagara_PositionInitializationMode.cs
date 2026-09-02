using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200443C RID: 17468
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_PositionInitializationMode.ENiagara_PositionInitializationMode")]
	public enum ENiagara_PositionInitializationMode : byte
	{
		// Token: 0x0401A3AF RID: 107439
		Unset,
		// Token: 0x0401A3B0 RID: 107440
		Direct_Set,
		// Token: 0x0401A3B1 RID: 107441
		Simulation_Position,
		// Token: 0x0401A3B2 RID: 107442
		ENiagara_MAX
	}
}
