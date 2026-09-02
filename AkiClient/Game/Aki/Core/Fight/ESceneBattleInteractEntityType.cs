using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F68 RID: 16232
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/ESceneBattleInteractEntityType.ESceneBattleInteractEntityType")]
	public enum ESceneBattleInteractEntityType : byte
	{
		// Token: 0x040155F4 RID: 87540
		Player,
		// Token: 0x040155F5 RID: 87541
		Summoned,
		// Token: 0x040155F6 RID: 87542
		Monster,
		// Token: 0x040155F7 RID: 87543
		Weapon,
		// Token: 0x040155F8 RID: 87544
		ESceneBattleInteractEntityType_MAX
	}
}
