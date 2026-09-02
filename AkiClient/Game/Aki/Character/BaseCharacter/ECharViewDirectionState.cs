using System;
using UnrealEngine.Service;
using UnrealEngine.Service.Flags;

namespace AkiClient.Game.Aki.Character.BaseCharacter
{
	// Token: 0x020041EF RID: 16879
	[UEnum(EEnumFlags.None)]
	[UnrealObjectPath("/Game/Aki/Character/BaseCharacter/ECharViewDirectionState.ECharViewDirectionState")]
	public enum ECharViewDirectionState : byte
	{
		// Token: 0x04019085 RID: 102533
		注视方向,
		// Token: 0x04019086 RID: 102534
		瞄准方向,
		// Token: 0x04019087 RID: 102535
		面朝方向,
		// Token: 0x04019088 RID: 102536
		ECharViewDirectionState_MAX
	}
}
