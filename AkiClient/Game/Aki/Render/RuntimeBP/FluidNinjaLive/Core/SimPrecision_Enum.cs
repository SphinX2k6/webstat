using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D10 RID: 15632
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/SimPrecision_Enum.SimPrecision_Enum")]
	public enum SimPrecision_Enum : byte
	{
		// Token: 0x040137EB RID: 79851
		_16_bit,
		// Token: 0x040137EC RID: 79852
		_32_bit,
		// Token: 0x040137ED RID: 79853
		SimPrecision_MAX
	}
}
