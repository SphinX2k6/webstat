using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004210 RID: 16912
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/Enum_PositionToTarget.Enum_PositionToTarget")]
	public enum Enum_PositionToTarget : byte
	{
		// Token: 0x04019164 RID: 102756
		技能目标,
		// Token: 0x04019165 RID: 102757
		召唤者,
		// Token: 0x04019166 RID: 102758
		Enum_MAX
	}
}
