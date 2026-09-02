using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004431 RID: 17457
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_EmitterLocSamplingMode.ENiagara_EmitterLocSamplingMode")]
	public enum ENiagara_EmitterLocSamplingMode : byte
	{
		// Token: 0x0401A37A RID: 107386
		Random,
		// Token: 0x0401A37B RID: 107387
		Sequential,
		// Token: 0x0401A37C RID: 107388
		ENiagara_MAX
	}
}
