using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043E9 RID: 17385
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/ImpostorBaker/ImpostorBaker/BP/Enums/EImposterLayoutType.EImposterLayoutType")]
	public enum EImposterLayoutType : byte
	{
		// Token: 0x0401A1F5 RID: 106997
		Full_Sphere_View,
		// Token: 0x0401A1F6 RID: 106998
		Upper_Hemisphere_Only,
		// Token: 0x0401A1F7 RID: 106999
		Traditional_Billboards,
		// Token: 0x0401A1F8 RID: 107000
		EImposterLayoutType_MAX
	}
}
