using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A1B RID: 14875
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_SkyLightMode.UDS_SkyLightMode")]
	public enum UDS_SkyLightMode : byte
	{
		// Token: 0x0400F11A RID: 61722
		Capture_Based,
		// Token: 0x0400F11B RID: 61723
		Custom_Cubemap,
		// Token: 0x0400F11C RID: 61724
		Cubemap_with_Dynamic_Color_Tinting,
		// Token: 0x0400F11D RID: 61725
		UDS_MAX
	}
}
