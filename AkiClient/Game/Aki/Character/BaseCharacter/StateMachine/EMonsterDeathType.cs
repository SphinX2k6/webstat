using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter.StateMachine
{
	// Token: 0x020042E3 RID: 17123
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/StateMachine/EMonsterDeathType.EMonsterDeathType")]
	public enum EMonsterDeathType : byte
	{
		// Token: 0x040197A0 RID: 104352
		地面死亡,
		// Token: 0x040197A1 RID: 104353
		水中死亡,
		// Token: 0x040197A2 RID: 104354
		空中死亡,
		// Token: 0x040197A3 RID: 104355
		EMonsterDeathType_MAX
	}
}
