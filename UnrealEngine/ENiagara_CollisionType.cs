using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200442B RID: 17451
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_CollisionType.ENiagara_CollisionType")]
	public enum ENiagara_CollisionType : byte
	{
		// Token: 0x0401A35E RID: 107358
		GPU_Depth_Buffer,
		// Token: 0x0401A35F RID: 107359
		GPU_Distance_Fields,
		// Token: 0x0401A360 RID: 107360
		ENiagara_MAX
	}
}
