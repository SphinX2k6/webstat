using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace UnrealEngine
{
	// Token: 0x020043E5 RID: 17381
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Engine/ArtTools/RenderToTexture/Enums/RenderToTexture_Enum.RenderToTexture_Enum")]
	public enum RenderToTexture_Enum : byte
	{
		// Token: 0x0401A1D6 RID: 106966
		Material,
		// Token: 0x0401A1D7 RID: 106967
		_3D_Imposter_Sprites,
		// Token: 0x0401A1D8 RID: 106968
		Unwrapped_Mesh,
		// Token: 0x0401A1D9 RID: 106969
		Depth_Map,
		// Token: 0x0401A1DA RID: 106970
		Lightmaps,
		// Token: 0x0401A1DB RID: 106971
		Lightmaps_2_sided,
		// Token: 0x0401A1DC RID: 106972
		Flipbook_Mesh_Animation,
		// Token: 0x0401A1DD RID: 106973
		Physics_Ground___Tiling_Physics_Drop_of_Meshes,
		// Token: 0x0401A1DE RID: 106974
		Tiling_Material_from_Hand_Placed_Meshes,
		// Token: 0x0401A1DF RID: 106975
		RenderToTexture_MAX
	}
}
