using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043E6 RID: 17382
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Engine/ArtTools/RenderToTexture/Enums/RenderToTexture_Flipbook_Enum.RenderToTexture_Flipbook_Enum")]
	public enum RenderToTexture_Flipbook_Enum : byte
	{
		// Token: 0x0401A1E1 RID: 106977
		Simple_Mesh_rotation,
		// Token: 0x0401A1E2 RID: 106978
		Material_Instance_Interpolation,
		// Token: 0x0401A1E3 RID: 106979
		Both_Mesh_rotation_and_Material_Instance_Interpolation,
		// Token: 0x0401A1E4 RID: 106980
		RenderToTexture_Flipbook_MAX
	}
}
