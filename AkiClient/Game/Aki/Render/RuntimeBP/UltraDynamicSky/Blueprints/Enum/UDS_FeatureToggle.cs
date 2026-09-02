using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A18 RID: 14872
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_FeatureToggle.UDS_FeatureToggle")]
	public enum UDS_FeatureToggle : byte
	{
		// Token: 0x0400F108 RID: 61704
		Use_Built_In_Component,
		// Token: 0x0400F109 RID: 61705
		Use_Custom_Actor,
		// Token: 0x0400F10A RID: 61706
		Disable_Completely,
		// Token: 0x0400F10B RID: 61707
		UDS_MAX
	}
}
