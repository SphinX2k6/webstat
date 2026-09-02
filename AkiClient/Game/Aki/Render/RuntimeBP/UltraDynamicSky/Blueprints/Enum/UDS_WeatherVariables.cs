using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A1F RID: 14879
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_WeatherVariables.UDS_WeatherVariables")]
	public enum UDS_WeatherVariables : byte
	{
		// Token: 0x0400F139 RID: 61753
		Weather_Intensity,
		// Token: 0x0400F13A RID: 61754
		Cloudiness,
		// Token: 0x0400F13B RID: 61755
		Wind_Intensity,
		// Token: 0x0400F13C RID: 61756
		Rain_Snow,
		// Token: 0x0400F13D RID: 61757
		UDS_MAX
	}
}
