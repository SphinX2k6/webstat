using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200442A RID: 17450
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_CameraProperties.ENiagara_CameraProperties")]
	public enum ENiagara_CameraProperties : byte
	{
		// Token: 0x0401A357 RID: 107351
		Camera_Position,
		// Token: 0x0401A358 RID: 107352
		Camera_Forward_Vector,
		// Token: 0x0401A359 RID: 107353
		Camera_Up_Vector,
		// Token: 0x0401A35A RID: 107354
		Camera_Right_Vector,
		// Token: 0x0401A35B RID: 107355
		Vector_To_Camera,
		// Token: 0x0401A35C RID: 107356
		ENiagara_MAX
	}
}
