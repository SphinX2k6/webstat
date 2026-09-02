using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F54 RID: 16212
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletBeginVelocityLimit.EBulletBeginVelocityLimit")]
	public enum EBulletBeginVelocityLimit : byte
	{
		// Token: 0x04015549 RID: 87369
		上角度范围,
		// Token: 0x0401554A RID: 87370
		下角度范围,
		// Token: 0x0401554B RID: 87371
		左角度范围,
		// Token: 0x0401554C RID: 87372
		右下角度范围,
		// Token: 0x0401554D RID: 87373
		EBulletBeginVelocityLimit_MAX
	}
}
