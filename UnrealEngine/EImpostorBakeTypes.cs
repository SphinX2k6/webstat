using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043EA RID: 17386
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/ImpostorBaker/ImpostorBaker/BP/Enums/EImpostorBakeTypes.EImpostorBakeTypes")]
	public enum EImpostorBakeTypes : byte
	{
		// Token: 0x0401A1FA RID: 107002
		BaseColor,
		// Token: 0x0401A1FB RID: 107003
		Metallic,
		// Token: 0x0401A1FC RID: 107004
		Specular,
		// Token: 0x0401A1FD RID: 107005
		Roughness,
		// Token: 0x0401A1FE RID: 107006
		Emissive,
		// Token: 0x0401A1FF RID: 107007
		Opacity,
		// Token: 0x0401A200 RID: 107008
		WorldNormal,
		// Token: 0x0401A201 RID: 107009
		Subsurface,
		// Token: 0x0401A202 RID: 107010
		Depth,
		// Token: 0x0401A203 RID: 107011
		Lit,
		// Token: 0x0401A204 RID: 107012
		CustomLighting,
		// Token: 0x0401A205 RID: 107013
		EImpostorBakeTypes_MAX
	}
}
