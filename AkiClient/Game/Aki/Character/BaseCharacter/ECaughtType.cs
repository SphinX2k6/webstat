using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041EB RID: 16875
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECaughtType.ECaughtType")]
	public enum ECaughtType : byte
	{
		// Token: 0x04019054 RID: 102484
		Socket,
		// Token: 0x04019055 RID: 102485
		Bullet,
		// Token: 0x04019056 RID: 102486
		ECaughtType_MAX
	}
}
