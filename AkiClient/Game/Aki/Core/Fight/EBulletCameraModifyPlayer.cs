using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F55 RID: 16213
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBulletCameraModifyPlayer.EBulletCameraModifyPlayer")]
	public enum EBulletCameraModifyPlayer : byte
	{
		// Token: 0x0401554F RID: 87375
		Attacker,
		// Token: 0x04015550 RID: 87376
		Victim,
		// Token: 0x04015551 RID: 87377
		AttackerAndVictim,
		// Token: 0x04015552 RID: 87378
		EBulletCameraModifyPlayer_MAX
	}
}
