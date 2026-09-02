using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Render.RuntimeBP.FluidNinjaLive.Core
{
	// Token: 0x02003D0C RID: 15628
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Render/RuntimeBP/FluidNinjaLive/Core/QuantizerAxisIgnore.QuantizerAxisIgnore")]
	public enum QuantizerAxisIgnore : byte
	{
		// Token: 0x040137C7 RID: 79815
		X,
		// Token: 0x040137C8 RID: 79816
		Y,
		// Token: 0x040137C9 RID: 79817
		Z,
		// Token: 0x040137CA RID: 79818
		CAMERA,
		// Token: 0x040137CB RID: 79819
		NONE,
		// Token: 0x040137CC RID: 79820
		ALL,
		// Token: 0x040137CD RID: 79821
		QuantizerAxisIgnore_MAX
	}
}
