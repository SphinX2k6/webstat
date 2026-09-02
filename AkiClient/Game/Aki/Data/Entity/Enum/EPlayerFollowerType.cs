using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Data.Entity.Enum
{
	// Token: 0x02003EFE RID: 16126
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Data/Entity/Enum/EPlayerFollowerType.EPlayerFollowerType")]
	public enum EPlayerFollowerType : byte
	{
		// Token: 0x040151D8 RID: 86488
		Common,
		// Token: 0x040151D9 RID: 86489
		SpecialItem,
		// Token: 0x040151DA RID: 86490
		LevelPlay,
		// Token: 0x040151DB RID: 86491
		Motor,
		// Token: 0x040151DC RID: 86492
		EPlayerFollowerType_MAX
	}
}
