using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A1C RID: 14876
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_SkyMode.UDS_SkyMode")]
	public enum UDS_SkyMode : byte
	{
		// Token: 0x0400F11F RID: 61727
		Volumetric_Clouds,
		// Token: 0x0400F120 RID: 61728
		Static_Clouds,
		// Token: 0x0400F121 RID: 61729
		_2D_Dynamic_Clouds,
		// Token: 0x0400F122 RID: 61730
		No_Clouds,
		// Token: 0x0400F123 RID: 61731
		_2D_Clouds_using_Color_Curves__Legacy_Mode_,
		// Token: 0x0400F124 RID: 61732
		Volumetric_Aurora,
		// Token: 0x0400F125 RID: 61733
		UDS_MAX
	}
}
