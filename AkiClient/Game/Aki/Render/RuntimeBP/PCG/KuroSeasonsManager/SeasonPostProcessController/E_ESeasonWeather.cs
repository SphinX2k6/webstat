using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.PCG.KuroSeasonsManager.SeasonPostProcessController
{
	// Token: 0x02003BE8 RID: 15336
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/PCG/KuroSeasonsManager/SeasonPostProcessController/E_ESeasonWeather.E_ESeasonWeather")]
	public enum E_ESeasonWeather : byte
	{
		// Token: 0x040117AC RID: 71596
		Idle,
		// Token: 0x040117AD RID: 71597
		Waiting,
		// Token: 0x040117AE RID: 71598
		Active,
		// Token: 0x040117AF RID: 71599
		Cooldown,
		// Token: 0x040117B0 RID: 71600
		E_MAX
	}
}
