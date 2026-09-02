using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200441A RID: 17434
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSkelSamplingModeFull.ENiagaraSkelSamplingModeFull")]
	public enum ENiagaraSkelSamplingModeFull : byte
	{
		// Token: 0x0401A305 RID: 107269
		Skeleton__Bones_,
		// Token: 0x0401A306 RID: 107270
		Skeleton__Sockets_,
		// Token: 0x0401A307 RID: 107271
		Skeleton__Bones_and_Sockets_,
		// Token: 0x0401A308 RID: 107272
		Surface__Triangles_,
		// Token: 0x0401A309 RID: 107273
		Surface__Vertices_,
		// Token: 0x0401A30A RID: 107274
		ENiagaraSkelSamplingModeFull_MAX
	}
}
