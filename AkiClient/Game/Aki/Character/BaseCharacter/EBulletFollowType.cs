using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E3 RID: 16867
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBulletFollowType.EBulletFollowType")]
	public enum EBulletFollowType : byte
	{
		// Token: 0x04019013 RID: 102419
		跟随骨骼,
		// Token: 0x04019014 RID: 102420
		固定位置,
		// Token: 0x04019015 RID: 102421
		攻击者锁定拉伸,
		// Token: 0x04019016 RID: 102422
		跟随骨骼位置旋转,
		// Token: 0x04019017 RID: 102423
		跟随父子弹特效骨骼,
		// Token: 0x04019018 RID: 102424
		EBulletFollowType_MAX
	}
}
