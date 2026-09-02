using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Core.Fight
{
	// Token: 0x02003F57 RID: 16215
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Core/Fight/EBUlletChose.EBulletChose")]
	public enum EBulletChose : byte
	{
		// Token: 0x0401555C RID: 87388
		受重力加速度影响,
		// Token: 0x0401555D RID: 87389
		反弹和滑落,
		// Token: 0x0401555E RID: 87390
		遇到障碍物停止运动,
		// Token: 0x0401555F RID: 87391
		EBulletChose_MAX
	}
}
