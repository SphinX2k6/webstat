using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041FF RID: 16895
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EDangoState.EDangoState")]
	public enum EDangoState : byte
	{
		// Token: 0x040190ED RID: 102637
		Stand,
		// Token: 0x040190EE RID: 102638
		ActionPerform,
		// Token: 0x040190EF RID: 102639
		MoveJump,
		// Token: 0x040190F0 RID: 102640
		EDangoState_MAX
	}
}
