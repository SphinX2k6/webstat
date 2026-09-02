using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004213 RID: 16915
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EPawnChannel.EPawnChannel")]
	public enum EPawnChannel : byte
	{
		// Token: 0x04019171 RID: 102769
		All,
		// Token: 0x04019172 RID: 102770
		Pawn,
		// Token: 0x04019173 RID: 102771
		PawnPlayer,
		// Token: 0x04019174 RID: 102772
		PawnMonster,
		// Token: 0x04019175 RID: 102773
		EPawnChannel_MAX
	}
}
