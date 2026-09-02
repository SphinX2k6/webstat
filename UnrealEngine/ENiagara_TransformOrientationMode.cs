using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004444 RID: 17476
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_TransformOrientationMode.ENiagara_TransformOrientationMode")]
	public enum ENiagara_TransformOrientationMode : byte
	{
		// Token: 0x0401A3DA RID: 107482
		Yaw_Pitch_Roll,
		// Token: 0x0401A3DB RID: 107483
		Quaternion,
		// Token: 0x0401A3DC RID: 107484
		Matrix,
		// Token: 0x0401A3DD RID: 107485
		Basis_Vectors,
		// Token: 0x0401A3DE RID: 107486
		ENiagara_MAX
	}
}
