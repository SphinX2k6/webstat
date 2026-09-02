using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F5E RID: 16222
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletSpecificEffect.EBulletSpecificEffect")]
	public enum EBulletSpecificEffect : byte
	{
		// Token: 0x0401558A RID: 87434
		无,
		// Token: 0x0401558B RID: 87435
		激光末端,
		// Token: 0x0401558C RID: 87436
		激光阻碍,
		// Token: 0x0401558D RID: 87437
		EBulletSpecificEffect_MAX
	}
}
