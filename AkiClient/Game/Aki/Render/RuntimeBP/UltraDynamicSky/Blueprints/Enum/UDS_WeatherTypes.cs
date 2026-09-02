using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A1E RID: 14878
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_WeatherTypes.UDS_WeatherTypes")]
	public enum UDS_WeatherTypes : byte
	{
		// Token: 0x0400F12B RID: 61739
		Clear_Skies,
		// Token: 0x0400F12C RID: 61740
		Partly_Cloudy,
		// Token: 0x0400F12D RID: 61741
		Cloudy,
		// Token: 0x0400F12E RID: 61742
		Overcast,
		// Token: 0x0400F12F RID: 61743
		Foggy,
		// Token: 0x0400F130 RID: 61744
		Light_Rain,
		// Token: 0x0400F131 RID: 61745
		Rain,
		// Token: 0x0400F132 RID: 61746
		Thunderstorm,
		// Token: 0x0400F133 RID: 61747
		Light_Snow,
		// Token: 0x0400F134 RID: 61748
		Snow,
		// Token: 0x0400F135 RID: 61749
		Blizzard,
		// Token: 0x0400F136 RID: 61750
		Select_Preset,
		// Token: 0x0400F137 RID: 61751
		UDS_MAX
	}
}
