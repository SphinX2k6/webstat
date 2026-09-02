using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Audio
{
	// Token: 0x0200437F RID: 17279
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Audio/EAudioPhysicalSurface.EAudioPhysicalSurface")]
	public enum EAudioPhysicalSurface : byte
	{
		// Token: 0x04019DA2 RID: 105890
		DirtSurface,
		// Token: 0x04019DA3 RID: 105891
		ConcreteSurface,
		// Token: 0x04019DA4 RID: 105892
		GrassSurface,
		// Token: 0x04019DA5 RID: 105893
		MetalSheetSurface,
		// Token: 0x04019DA6 RID: 105894
		MetalHardSurface,
		// Token: 0x04019DA7 RID: 105895
		WoodFloorSurface,
		// Token: 0x04019DA8 RID: 105896
		Default,
		// Token: 0x04019DA9 RID: 105897
		FabricSurface,
		// Token: 0x04019DAA RID: 105898
		SandSurface,
		// Token: 0x04019DAB RID: 105899
		IceSurface,
		// Token: 0x04019DAC RID: 105900
		EAudioPhysicalSurface_MAX
	}
}
