using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004200 RID: 16896
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EEnterClimb.EEnterClimb")]
	public enum EEnterClimb : byte
	{
		// Token: 0x040190F2 RID: 102642
		空中进入,
		// Token: 0x040190F3 RID: 102643
		水中进入,
		// Token: 0x040190F4 RID: 102644
		地面上爬进入,
		// Token: 0x040190F5 RID: 102645
		崖顶下爬进入,
		// Token: 0x040190F6 RID: 102646
		技能进入,
		// Token: 0x040190F7 RID: 102647
		EEnterClimb_MAX
	}
}
