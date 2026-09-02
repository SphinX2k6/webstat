using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004441 RID: 17473
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_SubUVLookupMode.ENiagara_SubUVLookupMode")]
	public enum ENiagara_SubUVLookupMode : byte
	{
		// Token: 0x0401A3CC RID: 107468
		Linear,
		// Token: 0x0401A3CD RID: 107469
		Curve,
		// Token: 0x0401A3CE RID: 107470
		Random,
		// Token: 0x0401A3CF RID: 107471
		Infinite,
		// Token: 0x0401A3D0 RID: 107472
		ENiagara_MAX
	}
}
