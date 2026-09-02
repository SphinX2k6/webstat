using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F5C RID: 16220
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletLoadType.EBulletLoadType")]
	public enum EBulletLoadType : byte
	{
		// Token: 0x04015580 RID: 87424
		通用,
		// Token: 0x04015581 RID: 87425
		肉鸽,
		// Token: 0x04015582 RID: 87426
		EBulletLoadType_MAX
	}
}
