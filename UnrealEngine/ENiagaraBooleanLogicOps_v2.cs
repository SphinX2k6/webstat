using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F8 RID: 17400
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraBooleanLogicOps_v2.ENiagaraBooleanLogicOps_v2")]
	public enum ENiagaraBooleanLogicOps_v2 : byte
	{
		// Token: 0x0401A254 RID: 107092
		A_Greater_Than_B,
		// Token: 0x0401A255 RID: 107093
		A_Greater_Than_Or_Equal_To_B,
		// Token: 0x0401A256 RID: 107094
		A_Equal_To_B,
		// Token: 0x0401A257 RID: 107095
		A_Not_Equal_To_B,
		// Token: 0x0401A258 RID: 107096
		A_Less_Than_B,
		// Token: 0x0401A259 RID: 107097
		A_Less_Than_Or_Equal_To_B,
		// Token: 0x0401A25A RID: 107098
		ENiagaraBooleanLogicOps_MAX
	}
}
