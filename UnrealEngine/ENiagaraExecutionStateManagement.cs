using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004401 RID: 17409
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraExecutionStateManagement.ENiagaraExecutionStateManagement")]
	public enum ENiagaraExecutionStateManagement : byte
	{
		// Token: 0x0401A283 RID: 107139
		Awaken,
		// Token: 0x0401A284 RID: 107140
		Sleep_and_Let_Particles_Finish,
		// Token: 0x0401A285 RID: 107141
		Sleep_and_Clear_Particles,
		// Token: 0x0401A286 RID: 107142
		Kill_Immediately,
		// Token: 0x0401A287 RID: 107143
		Kill_After_Particles_Finish,
		// Token: 0x0401A288 RID: 107144
		ENiagaraExecutionStateManagement_MAX
	}
}
