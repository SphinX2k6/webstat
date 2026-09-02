using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E7 RID: 16871
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBulletType.EBulletType")]
	public enum EBulletType : byte
	{
		// Token: 0x04019031 RID: 102449
		远程子弹,
		// Token: 0x04019032 RID: 102450
		瞄准射击子弹,
		// Token: 0x04019033 RID: 102451
		近战攻击子弹,
		// Token: 0x04019034 RID: 102452
		大范围子弹,
		// Token: 0x04019035 RID: 102453
		地刺型子弹,
		// Token: 0x04019036 RID: 102454
		EBulletType_MAX
	}
}
