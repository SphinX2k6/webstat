using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043E0 RID: 17376
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/BlockoutToolsPlugin/Blueprints/Utility/EBlockoutStairsType.EBlockoutStairsType")]
	public enum EBlockoutStairsType : byte
	{
		// Token: 0x0401A1BA RID: 106938
		Box,
		// Token: 0x0401A1BB RID: 106939
		Sloped,
		// Token: 0x0401A1BC RID: 106940
		Closed,
		// Token: 0x0401A1BD RID: 106941
		EBlockoutStairsType_MAX
	}
}
