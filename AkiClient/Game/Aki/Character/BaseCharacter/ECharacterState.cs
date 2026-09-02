using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041EC RID: 16876
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECharacterState.ECharacterState")]
	public enum ECharacterState : byte
	{
		// Token: 0x04019058 RID: 102488
		None,
		// Token: 0x04019059 RID: 102489
		休眠,
		// Token: 0x0401905A RID: 102490
		出生,
		// Token: 0x0401905B RID: 102491
		其他,
		// Token: 0x0401905C RID: 102492
		ECharacterState_MAX
	}
}
