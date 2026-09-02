using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200442E RID: 17454
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_DirectReadApplicationMode.ENiagara_DirectReadApplicationMode")]
	public enum ENiagara_DirectReadApplicationMode : byte
	{
		// Token: 0x0401A36C RID: 107372
		Overwrite,
		// Token: 0x0401A36D RID: 107373
		Add,
		// Token: 0x0401A36E RID: 107374
		ENiagara_MAX
	}
}
