using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x02004440 RID: 17472
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Niagara/Enums/ENiagara_SpriteRotationMode.ENiagara_SpriteRotationMode")]
	public enum ENiagara_SpriteRotationMode : byte
	{
		// Token: 0x0401A3C6 RID: 107462
		Unset,
		// Token: 0x0401A3C7 RID: 107463
		Random,
		// Token: 0x0401A3C8 RID: 107464
		Direct_Angle__Degrees_,
		// Token: 0x0401A3C9 RID: 107465
		Direct_Normalized_Angle__0_1_,
		// Token: 0x0401A3CA RID: 107466
		ENiagara_MAX
	}
}
