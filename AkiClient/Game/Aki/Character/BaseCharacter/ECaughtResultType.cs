using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041EA RID: 16874
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECaughtResultType.ECaughtResultType")]
	public enum ECaughtResultType : byte
	{
		// Token: 0x0401904F RID: 102479
		Success,
		// Token: 0x04019050 RID: 102480
		Fail,
		// Token: 0x04019051 RID: 102481
		Ignore,
		// Token: 0x04019052 RID: 102482
		ECaughtResultType_MAX
	}
}
