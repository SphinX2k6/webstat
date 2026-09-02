using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Effect.Struct
{
	// Token: 0x02003F00 RID: 16128
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Effect/Struct/EEffectType.EEffectType")]
	public enum EEffectType : byte
	{
		// Token: 0x040151E3 RID: 86499
		Fight,
		// Token: 0x040151E4 RID: 86500
		UiScene3D,
		// Token: 0x040151E5 RID: 86501
		UI,
		// Token: 0x040151E6 RID: 86502
		Scene,
		// Token: 0x040151E7 RID: 86503
		EEffectType_MAX
	}
}
