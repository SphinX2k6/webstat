using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043F5 RID: 17397
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagaraBoneSamplingMode.ENiagaraBoneSamplingMode")]
	public enum ENiagaraBoneSamplingMode : byte
	{
		// Token: 0x0401A242 RID: 107074
		Random__Filtered_Bones_,
		// Token: 0x0401A243 RID: 107075
		Random__Unfiltered_Bones_,
		// Token: 0x0401A244 RID: 107076
		Random__All_Bones_,
		// Token: 0x0401A245 RID: 107077
		Direct__Filtered_Bones_,
		// Token: 0x0401A246 RID: 107078
		Direct__Unfiltered_Bones_,
		// Token: 0x0401A247 RID: 107079
		Direct__All_Bones_,
		// Token: 0x0401A248 RID: 107080
		ENiagaraBoneSamplingMode_MAX
	}
}
