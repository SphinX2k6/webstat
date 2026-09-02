using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x02004208 RID: 16904
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EHitAnim.EHitAnim")]
	public enum EHitAnim : byte
	{
		// Token: 0x0401912D RID: 102701
		轻左,
		// Token: 0x0401912E RID: 102702
		轻右,
		// Token: 0x0401912F RID: 102703
		重左,
		// Token: 0x04019130 RID: 102704
		重右,
		// Token: 0x04019131 RID: 102705
		击飞,
		// Token: 0x04019132 RID: 102706
		击倒,
		// Token: 0x04019133 RID: 102707
		压制,
		// Token: 0x04019134 RID: 102708
		被弹反,
		// Token: 0x04019135 RID: 102709
		轻前,
		// Token: 0x04019136 RID: 102710
		轻后,
		// Token: 0x04019137 RID: 102711
		重前,
		// Token: 0x04019138 RID: 102712
		重后,
		// Token: 0x04019139 RID: 102713
		被破弱,
		// Token: 0x0401913A RID: 102714
		EHitAnim_MAX
	}
}
