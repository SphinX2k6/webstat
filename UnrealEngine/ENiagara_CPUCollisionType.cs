using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200442D RID: 17453
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_CPUCollisionType.ENiagara_CPUCollisionType")]
	public enum ENiagara_CPUCollisionType : byte
	{
		// Token: 0x0401A368 RID: 107368
		Ray_Traced,
		// Token: 0x0401A369 RID: 107369
		Analytical_Planes,
		// Token: 0x0401A36A RID: 107370
		ENiagara_MAX
	}
}
