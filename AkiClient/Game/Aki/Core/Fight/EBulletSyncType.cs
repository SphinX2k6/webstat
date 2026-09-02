using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F5F RID: 16223
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletSyncType.EBulletSyncType")]
	public enum EBulletSyncType : byte
	{
		// Token: 0x0401558F RID: 87439
		本地子弹,
		// Token: 0x04015590 RID: 87440
		网络同步子弹,
		// Token: 0x04015591 RID: 87441
		EBulletSyncType_MAX
	}
}
