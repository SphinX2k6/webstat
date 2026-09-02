using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E4 RID: 16868
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBulletHitDirectionType.EBulletHitDirectionType")]
	public enum EBulletHitDirectionType : byte
	{
		// Token: 0x0401901A RID: 102426
		以子弹发射者和被击者位置,
		// Token: 0x0401901B RID: 102427
		以子弹中心和被击者位置,
		// Token: 0x0401901C RID: 102428
		EBulletHitDirectionType_MAX
	}
}
