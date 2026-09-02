using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004207 RID: 16903
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EHipsDirection.EHipsDirection")]
	public enum EHipsDirection : byte
	{
		// Token: 0x04019125 RID: 102693
		前,
		// Token: 0x04019126 RID: 102694
		后,
		// Token: 0x04019127 RID: 102695
		左前,
		// Token: 0x04019128 RID: 102696
		左后,
		// Token: 0x04019129 RID: 102697
		右前,
		// Token: 0x0401912A RID: 102698
		右后,
		// Token: 0x0401912B RID: 102699
		EHipsDirection_MAX
	}
}
