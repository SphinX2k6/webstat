using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004214 RID: 16916
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EPokerIdleState.EPokerIdleState")]
	public enum EPokerIdleState : byte
	{
		// Token: 0x04019177 RID: 102775
		Normal,
		// Token: 0x04019178 RID: 102776
		Disadvantage,
		// Token: 0x04019179 RID: 102777
		Advantage,
		// Token: 0x0401917A RID: 102778
		EPokerIdleState_MAX
	}
}
