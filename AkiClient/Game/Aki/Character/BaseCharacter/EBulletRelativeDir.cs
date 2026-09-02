using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E5 RID: 16869
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBulletRelativeDir.EBulletRelativeDir")]
	public enum EBulletRelativeDir : byte
	{
		// Token: 0x0401901E RID: 102430
		发射者,
		// Token: 0x0401901F RID: 102431
		子弹中心,
		// Token: 0x04019020 RID: 102432
		子弹方向,
		// Token: 0x04019021 RID: 102433
		无影响,
		// Token: 0x04019022 RID: 102434
		子弹中心相对位置,
		// Token: 0x04019023 RID: 102435
		EBulletRelativeDir_MAX
	}
}
