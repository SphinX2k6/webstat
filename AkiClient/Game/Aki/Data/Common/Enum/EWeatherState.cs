using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Common.Enum
{
	// Token: 0x02003F0D RID: 16141
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Common/Enum/EWeatherState.EWeatherState")]
	public enum EWeatherState : byte
	{
		// Token: 0x04015237 RID: 86583
		晴天,
		// Token: 0x04015238 RID: 86584
		下雨,
		// Token: 0x04015239 RID: 86585
		打雷,
		// Token: 0x0401523A RID: 86586
		多云,
		// Token: 0x0401523B RID: 86587
		下雪,
		// Token: 0x0401523C RID: 86588
		EWeatherState_MAX
	}
}
