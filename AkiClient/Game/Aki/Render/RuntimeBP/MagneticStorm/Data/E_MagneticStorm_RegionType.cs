using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.MagneticStorm.Data
{
	// Token: 0x02003C5A RID: 15450
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/MagneticStorm/Data/E_MagneticStorm_RegionType.E_MagneticStorm_RegionType")]
	public enum E_MagneticStorm_RegionType : byte
	{
		// Token: 0x04012375 RID: 74613
		Box,
		// Token: 0x04012376 RID: 74614
		Hemisphere,
		// Token: 0x04012377 RID: 74615
		E_MagneticStorm_MAX
	}
}
