using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043FA RID: 17402
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraChannelCorrelation.ENiagaraChannelCorrelation")]
	public enum ENiagaraChannelCorrelation : byte
	{
		// Token: 0x0401A261 RID: 107105
		Link_RGBA,
		// Token: 0x0401A262 RID: 107106
		Link_RGB___Link_A,
		// Token: 0x0401A263 RID: 107107
		Random_Individual_Channels,
		// Token: 0x0401A264 RID: 107108
		ENiagaraChannelCorrelation_MAX
	}
}
