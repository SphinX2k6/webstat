using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004402 RID: 17410
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraExpansionMode.ENiagaraExpansionMode")]
	public enum ENiagaraExpansionMode : byte
	{
		// Token: 0x0401A28A RID: 107146
		Inside,
		// Token: 0x0401A28B RID: 107147
		Centered,
		// Token: 0x0401A28C RID: 107148
		Outside,
		// Token: 0x0401A28D RID: 107149
		ENiagaraExpansionMode_MAX
	}
}
