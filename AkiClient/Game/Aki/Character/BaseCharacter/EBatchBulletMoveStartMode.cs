using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041DF RID: 16863
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/EBatchBulletMoveStartMode.EBatchBulletMoveStartMode")]
	public enum EBatchBulletMoveStartMode : byte
	{
		// Token: 0x04018FFF RID: 102399
		每个生成就移动,
		// Token: 0x04019000 RID: 102400
		所有生成才移动,
		// Token: 0x04019001 RID: 102401
		EBatchBulletMoveStartMode_MAX
	}
}
