using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200443D RID: 17469
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_RotationDefinitionApproach.ENiagara_RotationDefinitionApproach")]
	public enum ENiagara_RotationDefinitionApproach : byte
	{
		// Token: 0x0401A3B4 RID: 107444
		Euler,
		// Token: 0x0401A3B5 RID: 107445
		Quaternion,
		// Token: 0x0401A3B6 RID: 107446
		Axis_Angle_,
		// Token: 0x0401A3B7 RID: 107447
		Basis_Vectors,
		// Token: 0x0401A3B8 RID: 107448
		Matrix,
		// Token: 0x0401A3B9 RID: 107449
		ENiagara_MAX
	}
}
