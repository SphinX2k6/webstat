using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004427 RID: 17447
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_AudioParamType.ENiagara_AudioParamType")]
	public enum ENiagara_AudioParamType : byte
	{
		// Token: 0x0401A345 RID: 107333
		Volume,
		// Token: 0x0401A346 RID: 107334
		Pitch,
		// Token: 0x0401A347 RID: 107335
		Location,
		// Token: 0x0401A348 RID: 107336
		Rotation,
		// Token: 0x0401A349 RID: 107337
		Boolean_Parameter,
		// Token: 0x0401A34A RID: 107338
		Float_Parameter,
		// Token: 0x0401A34B RID: 107339
		Integer_Parameter,
		// Token: 0x0401A34C RID: 107340
		Paused_State,
		// Token: 0x0401A34D RID: 107341
		ENiagara_MAX
	}
}
