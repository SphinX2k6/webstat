using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x0200420D RID: 16909
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EMovementProcessDirection.EMovementProcessDirection")]
	public enum EMovementProcessDirection : byte
	{
		// Token: 0x0401914F RID: 102735
		None,
		// Token: 0x04019150 RID: 102736
		AlongTrack,
		// Token: 0x04019151 RID: 102737
		TowardsTarget,
		// Token: 0x04019152 RID: 102738
		EMovementProcessDirection_MAX
	}
}
