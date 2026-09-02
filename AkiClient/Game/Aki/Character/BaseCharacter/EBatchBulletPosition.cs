using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041E0 RID: 16864
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBatchBulletPosition.EBatchBulletPosition")]
	public enum EBatchBulletPosition : byte
	{
		// Token: 0x04019003 RID: 102403
		DotMatrix,
		// Token: 0x04019004 RID: 102404
		Circle,
		// Token: 0x04019005 RID: 102405
		Spline,
		// Token: 0x04019006 RID: 102406
		EBatchBulletPosition_MAX
	}
}
