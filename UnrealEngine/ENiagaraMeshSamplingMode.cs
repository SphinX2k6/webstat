using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200440C RID: 17420
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraMeshSamplingMode.ENiagaraMeshSamplingMode")]
	public enum ENiagaraMeshSamplingMode : byte
	{
		// Token: 0x0401A2C0 RID: 107200
		Random,
		// Token: 0x0401A2C1 RID: 107201
		Direct,
		// Token: 0x0401A2C2 RID: 107202
		ENiagaraMeshSamplingMode_MAX
	}
}
