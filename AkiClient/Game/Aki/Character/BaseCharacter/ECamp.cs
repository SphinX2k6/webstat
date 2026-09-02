using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E8 RID: 16872
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECamp.ECamp")]
	public enum ECamp : byte
	{
		// Token: 0x04019038 RID: 102456
		Player,
		// Token: 0x04019039 RID: 102457
		Monster,
		// Token: 0x0401903A RID: 102458
		Common_friend,
		// Token: 0x0401903B RID: 102459
		liufangzhe_e,
		// Token: 0x0401903C RID: 102460
		liufangzhe_f,
		// Token: 0x0401903D RID: 102461
		Animal_attack,
		// Token: 0x0401903E RID: 102462
		Animal_unattack,
		// Token: 0x0401903F RID: 102463
		Common_enemy,
		// Token: 0x04019040 RID: 102464
		Camp_hha,
		// Token: 0x04019041 RID: 102465
		Camp_jn,
		// Token: 0x04019042 RID: 102466
		Camp_wj,
		// Token: 0x04019043 RID: 102467
		Camp_wtn,
		// Token: 0x04019044 RID: 102468
		Camp_yfk,
		// Token: 0x04019045 RID: 102469
		Camp_None,
		// Token: 0x04019046 RID: 102470
		Camp_yegui,
		// Token: 0x04019047 RID: 102471
		ECamp_MAX
	}
}
