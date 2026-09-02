using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041FD RID: 16893
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EDangoPerformLocationType.EDangoPerformLocationType")]
	public enum EDangoPerformLocationType : byte
	{
		// Token: 0x040190E0 RID: 102624
		跟随团子骨骼,
		// Token: 0x040190E1 RID: 102625
		当前底座位置,
		// Token: 0x040190E2 RID: 102626
		当前团子位置,
		// Token: 0x040190E3 RID: 102627
		EDangoPerformLocationType_MAX
	}
}
