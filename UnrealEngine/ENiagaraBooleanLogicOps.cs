using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F7 RID: 17399
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraBooleanLogicOps.ENiagaraBooleanLogicOps")]
	public enum ENiagaraBooleanLogicOps : byte
	{
		// Token: 0x0401A24E RID: 107086
		Greater_Than,
		// Token: 0x0401A24F RID: 107087
		Greater_Than_Or_Equal_To,
		// Token: 0x0401A250 RID: 107088
		Equal_To,
		// Token: 0x0401A251 RID: 107089
		Not_Equal_To,
		// Token: 0x0401A252 RID: 107090
		ENiagaraBooleanLogicOps_MAX
	}
}
