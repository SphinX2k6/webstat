using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004418 RID: 17432
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraSkeletalSpawning.ENiagaraSkeletalSpawning")]
	public enum ENiagaraSkeletalSpawning : byte
	{
		// Token: 0x0401A2FB RID: 107259
		Bones,
		// Token: 0x0401A2FC RID: 107260
		Sockets,
		// Token: 0x0401A2FD RID: 107261
		Bones_and_Sockets,
		// Token: 0x0401A2FE RID: 107262
		ENiagaraSkeletalSpawning_MAX
	}
}
