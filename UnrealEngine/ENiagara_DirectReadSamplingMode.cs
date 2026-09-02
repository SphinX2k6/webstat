using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004430 RID: 17456
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_DirectReadSamplingMode.ENiagara_DirectReadSamplingMode")]
	public enum ENiagara_DirectReadSamplingMode : byte
	{
		// Token: 0x0401A375 RID: 107381
		Disabled,
		// Token: 0x0401A376 RID: 107382
		Apply_to_Attribute,
		// Token: 0x0401A377 RID: 107383
		Output_Only,
		// Token: 0x0401A378 RID: 107384
		ENiagara_MAX
	}
}
