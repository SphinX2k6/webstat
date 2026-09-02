using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Scene.Gacha.Blueprint
{
	// Token: 0x020039EA RID: 14826
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Scene/Gacha/Blueprint/E_GachaResult.E_GachaResult")]
	public enum E_GachaResult : byte
	{
		// Token: 0x0400EBE9 RID: 60393
		OneShotNormal,
		// Token: 0x0400EBEA RID: 60394
		OneShotPurple,
		// Token: 0x0400EBEB RID: 60395
		OneShotGolden,
		// Token: 0x0400EBEC RID: 60396
		TenShotsPurple,
		// Token: 0x0400EBED RID: 60397
		TenShotsGolden,
		// Token: 0x0400EBEE RID: 60398
		E_MAX
	}
}
