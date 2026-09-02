using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041DE RID: 16862
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBatchBulletBeginRotator.EBatchBulletBeginRotator")]
	public enum EBatchBulletBeginRotator : byte
	{
		// Token: 0x04018FFA RID: 102394
		读取子弹表,
		// Token: 0x04018FFB RID: 102395
		切线方向,
		// Token: 0x04018FFC RID: 102396
		法线方向,
		// Token: 0x04018FFD RID: 102397
		EBatchBulletBeginRotator_MAX
	}
}
