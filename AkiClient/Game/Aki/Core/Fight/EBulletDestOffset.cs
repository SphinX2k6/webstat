using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F58 RID: 16216
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletDestOffset.EBulletDestOffset")]
	public enum EBulletDestOffset : byte
	{
		// Token: 0x04015561 RID: 87393
		发射者朝向,
		// Token: 0x04015562 RID: 87394
		目标朝向,
		// Token: 0x04015563 RID: 87395
		发射者向目标点,
		// Token: 0x04015564 RID: 87396
		EBulletDestOffset_MAX
	}
}
