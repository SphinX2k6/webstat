using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Scene.NewGacha.BP
{
	// Token: 0x020039CC RID: 14796
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Scene/NewGacha/BP/E_GachaResultNew.E_GachaResultNew")]
	public enum E_GachaResultNew : byte
	{
		// Token: 0x0400EB7B RID: 60283
		OneShotNormal,
		// Token: 0x0400EB7C RID: 60284
		OneShotPurple,
		// Token: 0x0400EB7D RID: 60285
		OneShotGolden,
		// Token: 0x0400EB7E RID: 60286
		TenShotsPurple,
		// Token: 0x0400EB7F RID: 60287
		TenShotsGolden,
		// Token: 0x0400EB80 RID: 60288
		E_MAX
	}
}
