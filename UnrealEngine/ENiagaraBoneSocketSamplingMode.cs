using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F6 RID: 17398
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraBoneSocketSamplingMode.ENiagaraBoneSocketSamplingMode")]
	public enum ENiagaraBoneSocketSamplingMode : byte
	{
		// Token: 0x0401A24A RID: 107082
		Random__Filtered_Bone_or_Sockets_,
		// Token: 0x0401A24B RID: 107083
		Direct__Filtered_Bone_or_Sockets_,
		// Token: 0x0401A24C RID: 107084
		ENiagaraBoneSocketSamplingMode_MAX
	}
}
