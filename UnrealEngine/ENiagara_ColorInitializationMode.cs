using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x0200442C RID: 17452
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_ColorInitializationMode.ENiagara_ColorInitializationMode")]
	public enum ENiagara_ColorInitializationMode : byte
	{
		// Token: 0x0401A362 RID: 107362
		Unset,
		// Token: 0x0401A363 RID: 107363
		Direct_Set,
		// Token: 0x0401A364 RID: 107364
		Random_Range,
		// Token: 0x0401A365 RID: 107365
		Random_Hue_Saturation_Value,
		// Token: 0x0401A366 RID: 107366
		ENiagara_MAX
	}
}
