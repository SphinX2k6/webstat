using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.UltraDynamicSky.Blueprints.Enum
{
	// Token: 0x02003A1D RID: 14877
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/UltraDynamicSky/Blueprints/Enum/UDS_TemperatureType.UDS_TemperatureType")]
	public enum UDS_TemperatureType : byte
	{
		// Token: 0x0400F127 RID: 61735
		Fahrenheit,
		// Token: 0x0400F128 RID: 61736
		Celsius,
		// Token: 0x0400F129 RID: 61737
		UDS_MAX
	}
}
