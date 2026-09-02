using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200440E RID: 17422
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraMeshTransforms.ENiagaraMeshTransforms")]
	public enum ENiagaraMeshTransforms : byte
	{
		// Token: 0x0401A2C8 RID: 107208
		Simulation,
		// Token: 0x0401A2C9 RID: 107209
		World,
		// Token: 0x0401A2CA RID: 107210
		Local,
		// Token: 0x0401A2CB RID: 107211
		Mesh,
		// Token: 0x0401A2CC RID: 107212
		ENiagaraMeshTransforms_MAX
	}
}
