using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A19 RID: 14873
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_NoiseType.UDS_NoiseType")]
	public enum UDS_NoiseType : byte
	{
		// Token: 0x0400F10D RID: 61709
		Classic,
		// Token: 0x0400F10E RID: 61710
		Voronoi,
		// Token: 0x0400F10F RID: 61711
		Voronoi_Smooth,
		// Token: 0x0400F110 RID: 61712
		Voronoi_Diverse,
		// Token: 0x0400F111 RID: 61713
		Custom,
		// Token: 0x0400F112 RID: 61714
		UDS_MAX
	}
}
