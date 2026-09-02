using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041F5 RID: 16885
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECustomCameraMode.ECustomCameraMode")]
	public enum ECustomCameraMode : byte
	{
		// Token: 0x040190A7 RID: 102567
		LockOn,
		// Token: 0x040190A8 RID: 102568
		Sequence,
		// Token: 0x040190A9 RID: 102569
		Widget,
		// Token: 0x040190AA RID: 102570
		Scene,
		// Token: 0x040190AB RID: 102571
		Orbital,
		// Token: 0x040190AC RID: 102572
		Free,
		// Token: 0x040190AD RID: 102573
		ECustomCameraMode_MAX
	}
}
